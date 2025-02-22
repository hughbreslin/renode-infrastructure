//
// Copyright (c) 2010-2022 Antmicro
//
// This file is licensed under the MIT License.
// Full license text is available in 'licenses/MIT.txt'.
//
using Antmicro.Renode.Core;
using Antmicro.Renode.Core.Structure.Registers;
using Antmicro.Renode.Peripherals.Miscellaneous;

namespace Antmicro.Renode.Peripherals.Timers
{
    public class MAX32650_WDT : BasicDoubleWordPeripheral, IKnownSize
    {
        public MAX32650_WDT(Machine machine, MAX32650_GCR gcr) : base(machine)
        {
            IRQ = new GPIO();

            interruptTimer = new LimitTimer(machine.ClockSource, gcr.SysClk / 2, this, "interrupt_timer", InitialLimit, eventEnabled: true);
            interruptTimer.LimitReached += () =>
            {
                interruptPending.Value = true;
                UpdateInterrupts();
            };

            resetTimer = new LimitTimer(machine.ClockSource, gcr.SysClk / 2, this, "reset_timer", InitialLimit, eventEnabled: true);
            resetTimer.LimitReached += () =>
            {
                systemReset = true;
                machine.RequestReset();
            };

            gcr.SysClkChanged += (newFrequency) =>
            {
                interruptTimer.Frequency = newFrequency / 2;
                resetTimer.Frequency = newFrequency / 2;
            };

            DefineRegisters();
        }

        public override void Reset()
        {
            base.Reset();
            interruptTimer.Reset();
            resetTimer.Reset();
            IRQ.Unset();

            // We are intentionally not clearing systemReset variable
            // as it should persist after watchdog-triggered reset.
        }

        public long Size => 0x400;

        public GPIO IRQ { get; }

        private void UpdateInterrupts()
        {
            IRQ.Set(interruptTimer.EventEnabled && interruptPending.Value);
        }

        private void DefineRegisters()
        {
            Registers.Control.Define(this)
                .WithValueField(0, 4, name: "CTRL.int_period",
                    changeCallback: (_, value) =>
                    {
                        interruptTimer.Limit = 1UL << (31 - (int)value);
                        interruptTimer.Value = interruptTimer.Limit;
                    })
                .WithValueField(4, 4, name: "CTRL.rst_period",
                    changeCallback: (_, value) =>
                    {
                        resetTimer.Limit = 1UL << (31 - (int)value);
                        interruptTimer.Value = interruptTimer.Limit;
                    })
                .WithFlag(8, name: "CTRL.wdt_en",
                    writeCallback: (_, value) =>
                    {
                        if(value && resetSequence == ResetSequence.Armed)
                        {
                            resetSequence = ResetSequence.Idle;
                            interruptTimer.Enabled = true;
                            resetTimer.Enabled = true;
                        }
                        else if(!value)
                        {
                            interruptTimer.Enabled = false;
                            resetTimer.Enabled = false;
                        }
                    })
                .WithFlag(9, out interruptPending, FieldMode.WriteOneToClear, name: "CTRL.int_flag",
                    writeCallback: (_, __) => UpdateInterrupts())
                .WithFlag(10, name: "CTRL.int_en",
                    valueProviderCallback: _ => interruptTimer.EventEnabled,
                    writeCallback: (_, value) =>
                    {
                        interruptTimer.EventEnabled = value;
                        UpdateInterrupts();
                    })
                .WithFlag(11, name: "CTRL.rst_en",
                    valueProviderCallback: _ => resetTimer.EventEnabled,
                    changeCallback: (_, value) => resetTimer.EventEnabled = value)
                .WithReservedBits(12, 19)
                .WithFlag(31, name: "CTRL.rst_flag",
                    valueProviderCallback: _ => systemReset,
                    writeCallback: (_, value) => systemReset = value)
            ;

            Registers.Reset.Define(this)
                .WithValueField(0, 8, name: "RST.wdt_rst",
                    writeCallback: (_, value) =>
                    {
                        if(resetSequence == ResetSequence.Idle && value == FirstResetByte)
                        {
                            resetSequence = ResetSequence.WaitForSecondByte;
                        }
                        else if(resetSequence == ResetSequence.WaitForSecondByte && value == SecondResetByte)
                        {
                            resetSequence = interruptTimer.Enabled ? ResetSequence.Idle : ResetSequence.Armed;
                            interruptTimer.Value = interruptTimer.Limit;
                            resetTimer.Value = resetTimer.Limit;
                        }
                        else
                        {
                            resetSequence = ResetSequence.Idle;
                        }
                    })
                .WithReservedBits(8, 24)
            ;
        }

        private ResetSequence resetSequence = ResetSequence.Idle;
        private bool systemReset;

        private IFlagRegisterField interruptPending;

        private readonly LimitTimer interruptTimer;
        private readonly LimitTimer resetTimer;

        private const ulong InitialLimit = (1UL << 31);
        private const byte FirstResetByte = 0xA5;
        private const byte SecondResetByte = 0x5A;

        private enum ResetSequence
        {
            Idle,
            WaitForSecondByte,
            Armed,
        }

        private enum Registers
        {
            Control = 0x00,
            Reset = 0x04,
        }
    }
}
