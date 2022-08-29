using Antmicro.Renode.Peripherals.Bus;
using Antmicro.Renode.Logging;

namespace Antmicro.Renode.Peripherals.Miscellaneous
{
    public class DDR_CSR_APB_3E040000 : IDoubleWordPeripheral, IKnownSize
    {
        private ulong SOFT_RESET = 0x00000000;
        private ulong IOC_REG0 = 0x00000000;
        private ulong IOC_REG1 = 0x00000000;
        private ulong IOC_REG2 = 0x00000000;
        private ulong IOC_REG3 = 0x00000000;
        private ulong IOC_REG4 = 0x00000000;
        private ulong IOC_REG5 = 0x00000000;
        private ulong IOC_REG6 = 0x00000000;

        public uint ReadDoubleWord(long offset)
        {
            ulong value = 0x0u;
            switch(offset)
            {
                case 0x00:
                    value = SOFT_RESET;
                    break;
                case 0x04:
                    value = IOC_REG0;
                    break;
                case 0x08:
                    value = IOC_REG1;
                    value = value | 0x14;
                    break;
                case 0x0C:
                    value = IOC_REG2;
                    break;
                case 0x10:
                    value = IOC_REG3;
                    break;
                case 0x14:
                    value = IOC_REG4;
                    break;
                case 0x18:
                    value = IOC_REG5;
                    break;
                case 0x1C:
                    value = IOC_REG6;
                    break;
                default:
                    value = 0x0;
                    break;
            }
            this.Log(LogLevel.Noisy, "Read word from DDR controller - offset: 0x{0:X}, value 0x{1:X}", offset, value);
            return (uint)value;
        }

        public void WriteDoubleWord(long offset, uint value)
        {
            switch(offset)
            {
                case 0x00:
                    SOFT_RESET =  value;
                    break;
                case 0x04:
                    IOC_REG0 =  value;
                    break;
                case 0x08:
                    IOC_REG1 =  value;
                    break;
                case 0x0C:
                    IOC_REG2 =  value;
                    break;
                case 0x10:
                    IOC_REG3 =  value;
                    break;
                case 0x14:
                    IOC_REG4 =  value;
                    break;
                case 0x18:
                    IOC_REG5 =  value;
                    break;
                case 0x1C:
                    IOC_REG6 =  value;
                    break;
                default:
                    break;
            }
            this.Log(LogLevel.Noisy, "write word to DDR controller - offset: 0x{0:X}, value 0x{1:X}", offset, value);
        }

        public void Reset()
        {
        }

public long Size => 0xFFF; // Size is address space on sysbus
    }
}


