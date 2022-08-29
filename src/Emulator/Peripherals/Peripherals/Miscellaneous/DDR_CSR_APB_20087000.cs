using Antmicro.Renode.Peripherals.Bus;
using Antmicro.Renode.Logging;

namespace Antmicro.Renode.Peripherals.Miscellaneous
{
    public class DDR_CSR_APB_20087000 : IDoubleWordPeripheral, IKnownSize
    {
        private ulong CFG_DQ_WIDTH = 0x00000000;
        private ulong CFG_ACTIVE_DQ_SEL = 0x00000000;

        public uint ReadDoubleWord(long offset)
        {
            ulong value = 0x0u;
            switch(offset)
            {
                case 0xC00:
                    value = CFG_DQ_WIDTH;
                    break;
                case 0xC04:
                    value = CFG_ACTIVE_DQ_SEL;
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
                case 0xC00:
                    CFG_DQ_WIDTH =  value;
                    break;
                case 0xC04:
                    CFG_ACTIVE_DQ_SEL =  value;
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


