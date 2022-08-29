using Antmicro.Renode.Peripherals.Bus;
using Antmicro.Renode.Logging;

namespace Antmicro.Renode.Peripherals.Miscellaneous
{
    public class DDR_CSR_APB_3E020000 : IDoubleWordPeripheral, IKnownSize
    {
        private ulong SOFT_RESET = 0x00000000;
        private ulong DPC_BITS = 0x00000000;
        private ulong BANK_STATUS = 0x00000000;

        public uint ReadDoubleWord(long offset)
        {
            ulong value = 0x0u;
            switch(offset)
            {
                case 0x0:
                    value = SOFT_RESET;
                    break;
                case 0x4:
                    value = DPC_BITS;
                    break;
                case 0x8:
                    value = BANK_STATUS;
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
                case 0x0:
                    SOFT_RESET =  value;
                    break;
                case 0x4:
                    DPC_BITS =  value;
                    break;
                case 0x8:
                    BANK_STATUS =  value;
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


