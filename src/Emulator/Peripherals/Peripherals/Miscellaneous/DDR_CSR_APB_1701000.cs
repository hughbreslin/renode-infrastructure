using Antmicro.Renode.Peripherals.Bus;
using Antmicro.Renode.Logging;

namespace Antmicro.Renode.Peripherals.Miscellaneous
{
    public class DDR_CSR_APB_1701000 : IDoubleWordPeripheral, IKnownSize
    {
        private ulong BEU_1_cause = 0x0000000000000000;
        private ulong BEU_1_value = 0x0000000000000000;
        private ulong BEU_1_enable = 0x0000000000000000;
        private ulong BEU_1_plic_interrupt = 0x0000000000000000;
        private ulong BEU_1_accrued = 0x0000000000000000;
        private ulong BEU_1_local_interrupt = 0x0000000000000000;

        public uint ReadDoubleWord(long offset)
        {
            ulong value = 0x0u;
            switch(offset)
            {
                case 0x000:
                    value = BEU_1_cause;
                    break;
                case 0x008:
                    value = BEU_1_value;
                    break;
                case 0x010:
                    value = BEU_1_enable;
                    break;
                case 0x018:
                    value = BEU_1_plic_interrupt;
                    break;
                case 0x020:
                    value = BEU_1_accrued;
                    break;
                case 0x028:
                    value = BEU_1_local_interrupt;
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
                case 0x000:
                    BEU_1_cause =  value;
                    break;
                case 0x008:
                    BEU_1_value =  value;
                    break;
                case 0x010:
                    BEU_1_enable =  value;
                    break;
                case 0x018:
                    BEU_1_plic_interrupt =  value;
                    break;
                case 0x020:
                    BEU_1_accrued =  value;
                    break;
                case 0x028:
                    BEU_1_local_interrupt =  value;
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


