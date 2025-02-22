//
// Copyright (c) 2010-2022 Antmicro
//
// This file is licensed under the MIT License.
// Full license text is available in 'licenses/MIT.txt'.
//
using Antmicro.Renode.Core;
using Antmicro.Renode.Core.Structure.Registers;
using Antmicro.Renode.Exceptions;
using Antmicro.Renode.Logging;
using Antmicro.Renode.Peripherals.Bus;
using Antmicro.Renode.Time;
using System;

namespace Antmicro.Renode.Peripherals.Timers
{
    [AllowedTranslations(AllowedTranslation.ByteToDoubleWord | AllowedTranslation.WordToDoubleWord)]
    public class AmbiqApollo4_RTC : BasicDoubleWordPeripheral, IKnownSize
    {
        public AmbiqApollo4_RTC(Machine machine) : base(machine)
        {
            IRQ = new GPIO();
            var baseDateTime = new DateTime(2000, 1, 1);
            since2000Timer = new RTCTimer(machine, this, baseDateTime, alarmAction: () => InterruptStatus = true);

            DefineRegisters();
            Reset();
        }

        public override void Reset()
        {
            interruptStatus = false;
            InitializeBCDValueFields();
            IRQ.Unset();
            since2000Timer.Reset();
            valueReadWithCountersLower = 0;
            base.Reset();
        }

        public string PrintCurrentDateTime()
        {
            return since2000Timer.GetCurrentDateTime().ToString("o");
        }

        public string PrintNextAlarmDateTime()
        {
            return since2000Timer.IsAlarmSet() ? since2000Timer.GetNextAlarmDateTime().ToString("o") : "Alarm not set.";
        }

        private void UpdateCounterFields()
        {
            if(lastUpdateTimerValue == since2000Timer.Value)
            {
                return;
            }

            var dateTime = since2000Timer.GetCurrentDateTime();

            secondHundredths.SetFromInteger((int)Math.Round(dateTime.Millisecond / 10.0, 0));
            seconds.SetFromInteger(dateTime.Second);
            minutes.SetFromInteger(dateTime.Minute);
            hours.SetFromInteger(dateTime.Hour);
            day.SetFromInteger(dateTime.Day);
            month.SetFromInteger(dateTime.Month);
            yearsSince2X00.SetFromInteger(dateTime.Year % 100);
            weekday.SetFromInteger((int)dateTime.DayOfWeek);
            if(centuryChangeEnabled.Value)
            {
                centuryPassed.Value = dateTime.Year <= 2000 || dateTime.Year >= 2100;
            }

            lastUpdateTimerValue = since2000Timer.Value;
        }

        public override uint ReadDoubleWord(long offset)
        {
            if(offset == (long)Registers.CountersLower || offset == (long)Registers.CountersUpper)
            {
                // Cannot be done in read callback because field values are established first.
                UpdateCounterFields();
            }

            return base.ReadDoubleWord(offset);
        }
        public override void WriteDoubleWord(long offset, uint value)
        {
            if(!counterWritesEnabled.Value &&
                (offset == (long)Registers.CountersLower || offset == (long)Registers.CountersUpper))
            {
                this.Log(LogLevel.Warning, "The {0} register ({1}) cannot be written to; WRTC isn't set!", (Registers)offset, offset);
                return;
            }

            base.WriteDoubleWord(offset, value);
        }

        public void SetDateTime(int year, int month = 1, int day = 1, int hours = 0, int minutes = 0, int seconds = 0, int secondHundredths = 0)
        {
            if(year < 2000 || year > 2199)
            {
                throw new RecoverableException("Year has to be in range: 2000 .. 2199.");
            }
            centuryPassed.Value = year >= 2100;

            // Set the CountersUpper and CountersLower registers accordingly.
            yearsSince2X00.SetFromInteger(year % 100, throwException: true);
            this.month.SetFromInteger(month, throwException: true);
            this.day.SetFromInteger(day, throwException: true);
            this.hours.SetFromInteger(hours, throwException: true);
            this.minutes.SetFromInteger(minutes, throwException: true);
            this.seconds.SetFromInteger(seconds, throwException: true);
            this.secondHundredths.SetFromInteger(secondHundredths, throwException: true);

            SetDateTimeInternal(new DateTime(year, month, day, hours, minutes, seconds, secondHundredths * 10));
        }

        public GPIO IRQ { get; }

        public long Size => 0x210;

        private void DefineRegisters()
        {
            Registers.AlarmsLower.Define(this)
                .WithValueField(0, 8, name: "ALM100", writeCallback: (_, newValue) => alarmSecondHundredths.BCDSet((byte)newValue), valueProviderCallback: _ => alarmSecondHundredths.BCDGet())
                .WithValueField(8, 7, name: "ALMSEC", writeCallback: (_, newValue) => alarmSeconds.BCDSet((byte)newValue), valueProviderCallback: _ => alarmSeconds.BCDGet())
                .WithReservedBits(15, 1)
                .WithValueField(16, 7, name: "ALMMIN", writeCallback: (_, newValue) => alarmMinutes.BCDSet((byte)newValue), valueProviderCallback: _ => alarmMinutes.BCDGet())
                .WithReservedBits(23, 1)
                .WithValueField(24, 6, name: "ALMHR", writeCallback: (_, newValue) => alarmHours.BCDSet((byte)newValue), valueProviderCallback: _ => alarmHours.BCDGet())
                .WithReservedBits(30, 2)
                .WithChangeCallback((_, __) => UpdateAlarm())
                ;

            Registers.AlarmsUpper.Define(this)
                .WithValueField(0, 6, name: "ALMDATE", writeCallback: (_, newValue) => alarmDay.BCDSet((byte)newValue), valueProviderCallback: _ => alarmDay.BCDGet())
                .WithReservedBits(6, 2)
                .WithValueField(8, 5, name: "ALMMO", writeCallback: (_, newValue) => alarmMonth.BCDSet((byte)newValue), valueProviderCallback: _ => alarmMonth.BCDGet())
                .WithReservedBits(13, 3)
                .WithValueField(16, 3, name: "ALMWKDY", writeCallback: (_, newValue) => alarmWeekday.BCDSet((byte)newValue), valueProviderCallback: _ => alarmWeekday.BCDGet())
                .WithReservedBits(19, 13)
                .WithChangeCallback((_, __) => UpdateAlarm())
                ;

            Registers.Control.Define(this)
                .WithFlag(0, out counterWritesEnabled, name: "WRTC")
                .WithEnumField(1, 3, out alarmRepeatInterval, name: "RPT", changeCallback: (_, __) => UpdateAlarm())
                .WithFlag(4, name: "RSTOP", writeCallback: (_, newValue) => { since2000Timer.Enabled = !newValue; }, valueProviderCallback: _ => !since2000Timer.Enabled)
                .WithReservedBits(5, 27)
                ;

            Registers.CountersLower.Define(this)
                .WithValueField(0, 8, name: "CTR100", writeCallback: (_, newValue) => secondHundredths.BCDSet((byte)newValue), valueProviderCallback: _ => secondHundredths.BCDGet())
                .WithValueField(8, 7, name: "CTRSEC", writeCallback: (_, newValue) => seconds.BCDSet((byte)newValue), valueProviderCallback: _ => seconds.BCDGet())
                .WithReservedBits(15, 1)
                .WithValueField(16, 7, name: "CTRMIN", writeCallback: (_, newValue) => minutes.BCDSet((byte)newValue), valueProviderCallback: _ => minutes.BCDGet())
                .WithReservedBits(23, 1)
                .WithValueField(24, 6, name: "CTRHR", writeCallback: (_, newValue) => hours.BCDSet((byte)newValue), valueProviderCallback: _ => hours.BCDGet())
                .WithReservedBits(30, 2)
                .WithReadCallback((_, __) => { valueReadWithCountersLower = since2000Timer.Value; readError.Value = false; })
                .WithWriteCallback((_, __) => writeBusy = true)
                ;

            Registers.CountersUpper.Define(this)
                .WithValueField(0, 6, name: "CTRDATE", writeCallback: (_, newValue) => day.BCDSet((byte)newValue), valueProviderCallback: _ => day.BCDGet())
                .WithReservedBits(6, 2)
                .WithValueField(8, 5, name: "CTRMO", writeCallback: (_, newValue) => month.BCDSet((byte)newValue), valueProviderCallback: _ => month.BCDGet())
                .WithReservedBits(13, 3)
                .WithValueField(16, 8, name: "CTRYR", writeCallback: (_, newValue) => yearsSince2X00.BCDSet((byte)newValue), valueProviderCallback: _ => yearsSince2X00.BCDGet())
                .WithValueField(24, 3, name: "CTRWKDY", writeCallback: (_, newValue) => weekday.BCDSet((byte)newValue), valueProviderCallback: _ => weekday.BCDGet())
                .WithReservedBits(27, 1)
                // Documentation on Century Bit set: "Century is 1900s/2100s" so let's assume it means 2100s.
                .WithFlag(28, out centuryPassed, name: "CB")
                .WithFlag(29, out centuryChangeEnabled, name: "CEB")
                .WithReservedBits(30, 1)
                .WithFlag(31, out readError, name: "CTERR")
                .WithWriteCallback((_, __) =>
                {
                    readError.Value = valueReadWithCountersLower == since2000Timer.Value;
                    if(!writeBusy)
                    {
                        this.Log(LogLevel.Warning, "The Counters Upper register written without prior write to the Counters Lower register!", Registers.CountersLower);
                    }
                    writeBusy = false;

                    var year = 2000 + (centuryPassed.Value ? 100 : 0) + yearsSince2X00;
                    var newDateTime = new DateTime(year, month, day, hours, minutes, seconds, secondHundredths * 10);

                    // Check if weekday matches (Sunday is 0 for both).
                    if(weekday != (int)newDateTime.DayOfWeek)
                    {
                        this.Log(LogLevel.Warning, "Weekday given doesn't match the given date! New date's day of week: {0} ({1})", newDateTime.DayOfWeek, (int)newDateTime.DayOfWeek);
                    }

                    SetDateTimeInternal(newDateTime);
                })
                ;

            Registers.InterruptClear.Define(this)
                .WithFlag(0, FieldMode.Write, name: "ALM", writeCallback: (_, newValue) => { if(newValue) InterruptStatus = false; })
                .WithReservedBits(1, 31)
                ;

            Registers.InterruptEnable.Define(this)
                .WithFlag(0, out interruptEnable, name: "ALM", changeCallback: (_, __) => UpdateInterrupt())
                .WithReservedBits(1, 31)
                ;

            Registers.InterruptSet.Define(this)
                .WithFlag(0, FieldMode.Write, name: "ALM", writeCallback: (_, newValue) => { if(newValue) InterruptStatus = true; })
                .WithReservedBits(1, 31)
                ;

            Registers.InterruptStatus.Define(this)
                .WithFlag(0, FieldMode.Read, name: "ALM", valueProviderCallback: _ => InterruptStatus)
                .WithReservedBits(1, 31)
                ;

            Registers.Status.Define(this)
                .WithFlag(0, FieldMode.Read, name: "WRITEBUSY", valueProviderCallback: _ => writeBusy)
                .WithReservedBits(1, 31)
                ;
        }

        private void InitializeBCDValueFields()
        {
            alarmDay = new BCDValueField(this, "days", 0x31, zeroAllowed: false);
            alarmHours = new BCDValueField(this, "hours", 0x23);
            alarmMinutes = new BCDValueField(this, "minutes", 0x59);
            alarmMonth = new BCDValueField(this, "months", 0x12, zeroAllowed: false);
            alarmSeconds = new BCDValueField(this, "seconds", 0x59);
            alarmSecondHundredths = new BCDValueField(this, "hundredths of a second");
            alarmWeekday = new BCDValueField(this, "weekdays", 0x6);
            day = new BCDValueField(this, "days", 0x31, zeroAllowed: false);
            hours = new BCDValueField(this, "hours", 0x23);
            minutes = new BCDValueField(this, "minutes", 0x59);
            month = new BCDValueField(this, "months", 0x12, zeroAllowed: false);
            secondHundredths = new BCDValueField(this, "hundredths of a second");
            seconds = new BCDValueField(this, "seconds", 0x59);
            weekday = new BCDValueField(this, "weekdays", 0x6);
            yearsSince2X00 = new BCDValueField(this, "years since 2X00");
        }

        private void SetDateTimeInternal(DateTime dateTime)
        {
            since2000Timer.SetDateTime(dateTime);
            UpdateAlarm();
        }

        private void UpdateAlarm()
        {
            since2000Timer.UpdateAlarm(alarmRepeatInterval.Value, alarmMonth, alarmWeekday, alarmDay, alarmHours, alarmMinutes, alarmSeconds, alarmSecondHundredths * 10);
        }

        private void UpdateInterrupt()
        {
            var newIrqState = interruptEnable.Value && interruptStatus;
            if(newIrqState != IRQ.IsSet)
            {
                this.Log(LogLevel.Debug, "IRQ {0}", newIrqState ? "set" : "reset");
                IRQ.Set(newIrqState);
            }
        }

        private bool InterruptStatus
        {
            get => interruptStatus;
            set
            {
                interruptStatus = value;
                UpdateInterrupt();
            }
        }

        private readonly RTCTimer since2000Timer;

        private bool interruptStatus;
        private ulong lastUpdateTimerValue;
        private bool writeBusy;
        private ulong valueReadWithCountersLower;

        private BCDValueField alarmDay;
        private BCDValueField alarmHours;
        private BCDValueField alarmMinutes;
        private BCDValueField alarmMonth;
        private BCDValueField alarmSeconds;
        private BCDValueField alarmSecondHundredths;
        private BCDValueField alarmWeekday;
        private BCDValueField day;
        private BCDValueField hours;
        private BCDValueField minutes;
        private BCDValueField month;
        private BCDValueField secondHundredths;  // 0.01s
        private BCDValueField seconds;
        private BCDValueField weekday;
        private BCDValueField yearsSince2X00;

        private IEnumRegisterField<AlarmRepeatIntervals> alarmRepeatInterval;
        private IFlagRegisterField centuryChangeEnabled;
        private IFlagRegisterField centuryPassed;
        private IFlagRegisterField counterWritesEnabled;
        private IFlagRegisterField interruptEnable;
        private IFlagRegisterField readError;

        private class BCDValueField
        {
            static public implicit operator int(BCDValueField field)
            {
                return field.GetInteger();
            }

            public BCDValueField(IPeripheral owner, string fieldTypeName, byte maxValueBCD = 0x99, bool zeroAllowed = true)
            {
                this.fieldTypeName = fieldTypeName;
                this.maxValueBCD = maxValueBCD;
                this.owner = owner;
                this.zeroAllowed = zeroAllowed;
            }

            public byte BCDGet()
            {
                return value;
            }

            public void BCDSet(byte bcdValue, bool throwException = false)
            {
                if(bcdValue > maxValueBCD || (!zeroAllowed && bcdValue == 0x0))
                {
                    HandleInvalidValue(bcdValue.ToString("X"), throwException);
                }
                value = bcdValue;
            }

            public int GetInteger()
            {
                var units = value & 0x0F;
                var tens = (value & 0xF0) >> 4;
                return (tens * 10) + units;
            }

            public void SetFromInteger(int value, bool throwException = false)
            {
                if(value > 99 || value < 0)
                {
                    HandleInvalidValue(value.ToString(), throwException);
                }
                var nibbleLow = value % 10;
                var nibbleHigh = value / 10;
                BCDSet((byte)((nibbleHigh << 4) | nibbleLow), throwException);
            }

            public override string ToString()
            {
                // BCD value printed in hex is always equal to its decimal value.
                return $"{value:X}";
            }

            protected void HandleInvalidValue(string value, bool throwException)
            {
                string message = $"Invalid value for {fieldTypeName}: {value}";
                if(throwException)
                {
                    throw new RecoverableException(message);
                }
                else
                {
                    owner.Log(LogLevel.Warning, message);
                }
            }

            private readonly string fieldTypeName;
            private readonly byte maxValueBCD;
            private readonly IPeripheral owner;
            private readonly bool zeroAllowed;

            private byte value;
        }

        private class RTCTimer : LimitTimer
        {
            public RTCTimer(Machine machine, IPeripheral owner, DateTime baseDateTime, Action alarmAction) : base(machine.ClockSource, Frequency, owner, "RTC",
                limit: ulong.MaxValue, direction: Direction.Ascending, enabled: true, workMode: WorkMode.Periodic, eventEnabled: true)
            {
                this.alarmAction = alarmAction;
                baseDateTimeTicks = baseDateTime.Ticks;
                this.owner = owner;
                systemBus = machine.SystemBus;

                // It can be reached only after setting up the alarm.
                LimitReached += AlarmHandler;
            }

            public DateTime GetCurrentDateTime()
            {
                return ValueToDateTime(Value);
            }

            public DateTime GetNextAlarmDateTime()
            {
                return ValueToDateTime(nextAlarmValue);
            }

            public bool IsAlarmSet()
            {
                return Limit != ulong.MaxValue;
            }

            public override void Reset()
            {
                ResetAlarm();
                base.Reset();
            }

            public void SetDateTime(DateTime newDateTime)
            {
                ResetAlarm();
                Value = ValueFromDateTime(newDateTime);
                owner.Log(LogLevel.Info, "New date time set: {0:o}", newDateTime);
            }

            public void UpdateAlarm(AlarmRepeatIntervals interval, int month, int weekday, int day, int hour, int minute, int second, int millisecond)
            {
                if(interval == AlarmRepeatIntervals.Month || interval == AlarmRepeatIntervals.Year)
                {
                    if(day == 0)
                    {
                        owner.Log(LogLevel.Warning, "Day cannot be zero for the {0} alarm repeat interval! Using 1st as an alarm day.", interval);
                        day = 1;
                    }
                }

                if(interval == AlarmRepeatIntervals.Year)
                {
                    if(month == 0)
                    {
                        owner.Log(LogLevel.Warning, "Month cannot be zero for the {0} alarm repeat interval! Using January as an alarm month.", interval);
                        month = 1;
                    }
                }

                var currentDateTime = GetCurrentDateTime();
                DateTime firstAlarm, intervalDateTime;
                switch(interval)
                {
                    case AlarmRepeatIntervals.Second:
                        firstAlarm = new DateTime(currentDateTime.Year, currentDateTime.Month, currentDateTime.Day,
                            currentDateTime.Hour, currentDateTime.Minute, currentDateTime.Second, millisecond);
                        intervalDateTime = new DateTime().AddSeconds(1);
                        break;
                    case AlarmRepeatIntervals.Minute:
                        firstAlarm = new DateTime(currentDateTime.Year, currentDateTime.Month, currentDateTime.Day,
                            currentDateTime.Hour, currentDateTime.Minute, second, millisecond);
                        intervalDateTime = new DateTime().AddMinutes(1);
                        break;
                    case AlarmRepeatIntervals.Hour:
                        firstAlarm = new DateTime(currentDateTime.Year, currentDateTime.Month, currentDateTime.Day,
                            currentDateTime.Hour, minute, second, millisecond);
                        intervalDateTime = new DateTime().AddHours(1);
                        break;
                    case AlarmRepeatIntervals.Day:
                        firstAlarm = new DateTime(currentDateTime.Year, currentDateTime.Month, currentDateTime.Day, hour,
                            minute, second, millisecond);
                        intervalDateTime = new DateTime().AddDays(1);
                        break;
                    case AlarmRepeatIntervals.Week:
                        firstAlarm = new DateTime(currentDateTime.Year, currentDateTime.Month, currentDateTime.Day, hour,
                            minute, second, millisecond);
                        // This can take us "back in time" but we're always adjusting such a 'firstAlarm' nevertheless.
                        var daysToTheNearestAlarmWeekday = weekday - (int)firstAlarm.DayOfWeek;
                        firstAlarm = firstAlarm.AddDays(daysToTheNearestAlarmWeekday);
                        intervalDateTime = new DateTime().AddDays(7);
                        break;
                    case AlarmRepeatIntervals.Month:
                        firstAlarm = new DateTime(currentDateTime.Year, currentDateTime.Month, day, hour, minute, second,
                            millisecond);
                        intervalDateTime = new DateTime().AddMonths(1);
                        break;
                    case AlarmRepeatIntervals.Year:
                        firstAlarm = new DateTime(currentDateTime.Year, month, day, hour, minute, second, millisecond);
                        intervalDateTime = new DateTime().AddYears(1);
                        break;
                    case AlarmRepeatIntervals.Disabled:
                        ResetAlarm();
                        return;
                    default:
                        throw new ArgumentException("Something's very wrong; this should never happen.");
                }

                // Before this adjustment 'firstAlarm' can be in the past.
                if(firstAlarm < currentDateTime)
                {
                    firstAlarm = firstAlarm.AddTicks(intervalDateTime.Ticks);
                }

                alarmIntervalTicks = (ulong)intervalDateTime.Ticks / TimerTickToDateTimeTicks;
                nextAlarmValue = ValueFromDateTime(firstAlarm);
                Limit = nextAlarmValue;
                owner.Log(LogLevel.Debug, "First alarm set to: {0:o}, alarm repeat interval: {1}", firstAlarm, interval);
            }

            public new ulong Value
            {
                get
                {
                    if(systemBus.TryGetCurrentCPU(out var cpu))
                    {
                        // being here means we are on the CPU thread
                        cpu.SyncTime();
                    }
                    else
                    {
                        owner.Log(LogLevel.Noisy, "Couldn't synchronize time: returned value might lack precision");
                    }
                    return base.Value;
                }

                set => base.Value = value;
            }

            static private readonly ulong TimerTickToDateTimeTicks = (ulong)new DateTime().AddSeconds(1.0 / Frequency).Ticks;

            private void AlarmHandler()
            {
                alarmAction();

                // Value is automatically reset when the limit is reached.
                Value = nextAlarmValue;

                nextAlarmValue += alarmIntervalTicks;
                Limit = nextAlarmValue;

                owner.Log(LogLevel.Debug, "Alarm occurred at: {0:o}; next alarm: {1:o}", GetCurrentDateTime(), GetNextAlarmDateTime());
            }

            private void ResetAlarm()
            {
                Limit = ulong.MaxValue;
                alarmIntervalTicks = 0;
                nextAlarmValue = 0;
            }

            private ulong ValueFromDateTime(DateTime dateTime)
            {
                var newDateTimeTicks = (ulong)(dateTime.Ticks - baseDateTimeTicks);
                if(newDateTimeTicks % TimerTickToDateTimeTicks != 0)
                {
                    owner.Log(LogLevel.Warning, "Requested time for RTC is more precise than it supports (0.01s): {0:o}", dateTime);
                }
                return newDateTimeTicks / TimerTickToDateTimeTicks;
            }

            private DateTime ValueToDateTime(ulong value)
            {
                var dateTimeTicksPassed = value * TimerTickToDateTimeTicks;
                return new DateTime(baseDateTimeTicks + (long)dateTimeTicksPassed);
            }

            private readonly Action alarmAction;
            private readonly long baseDateTimeTicks;
            private readonly IPeripheral owner;
            private readonly SystemBus systemBus;

            private ulong alarmIntervalTicks;
            private ulong nextAlarmValue;

            private new const long Frequency = 100;
        }

        private enum AlarmRepeatIntervals
        {
            Disabled,
            Year,
            Month,
            Week,
            Day,
            Hour,
            Minute,
            // Docs: "Interrupt every second/10th/100th".
            Second,
        }

        private enum Registers : long
        {
            Control = 0x0,
            Status = 0x4,
            CountersLower = 0x20,
            CountersUpper = 0x24,
            AlarmsLower = 0x30,
            AlarmsUpper = 0x34,
            InterruptEnable = 0x200,
            InterruptStatus = 0x204,
            InterruptClear = 0x208,
            InterruptSet = 0x20C,
        }
    }
}
