using Antmicro.Renode.Peripherals.Bus;
using Antmicro.Renode.Logging;

namespace Antmicro.Renode.Peripherals.Miscellaneous
{
    public class DDR_CSR_APB_3E010000 : IDoubleWordPeripheral, IKnownSize
    {
        private ulong SOFT_RESET = 0x00000000;
        private ulong PLL_CTRL = 0x0000107C;
        private ulong PLL_REF_FB = 0x00000000;
        private ulong PLL_FRACN = 0x00000000;
        private ulong PLL_DIV_0_1 = 0x00000000;
        private ulong PLL_DIV_2_3 = 0x00000000;
        private ulong PLL_CTRL2 = 0x00001006;
        private ulong PLL_CAL = 0x00000000;
        private ulong PLL_PHADJ = 0x00004001;
        private ulong SSCG_REG_0 = 0x00000000;
        private ulong SSCG_REG_1 = 0x00000000;
        private ulong SSCG_REG_2 = 0x00000000;
        private ulong SSCG_REG_3 = 0x00000000;

        public uint ReadDoubleWord(long offset)
        {
            ulong value = 0x0u;
            switch(offset)
            {
                case 0x00:
                    value = SOFT_RESET;
                    break;
                case 0x04:
                    value = PLL_CTRL;
                    value = value | 0x2000000;
                    break;
                case 0x08:
                    value = PLL_REF_FB;
                    break;
                case 0x0C:
                    value = PLL_FRACN;
                    break;
                case 0x10:
                    value = PLL_DIV_0_1;
                    break;
                case 0x14:
                    value = PLL_DIV_2_3;
                    break;
                case 0x18:
                    value = PLL_CTRL2;
                    break;
                case 0x1C:
                    value = PLL_CAL;
                    break;
                case 0x20:
                    value = PLL_PHADJ;
                    break;
                case 0x24:
                    value = SSCG_REG_0;
                    break;
                case 0x28:
                    value = SSCG_REG_1;
                    break;
                case 0x2C:
                    value = SSCG_REG_2;
                    break;
                case 0x30:
                    value = SSCG_REG_3;
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
                    PLL_CTRL =  value;
                    break;
                case 0x08:
                    PLL_REF_FB =  value;
                    break;
                case 0x0C:
                    PLL_FRACN =  value;
                    break;
                case 0x10:
                    PLL_DIV_0_1 =  value;
                    break;
                case 0x14:
                    PLL_DIV_2_3 =  value;
                    break;
                case 0x18:
                    PLL_CTRL2 =  value;
                    break;
                case 0x1C:
                    PLL_CAL =  value;
                    break;
                case 0x20:
                    PLL_PHADJ =  value;
                    break;
                case 0x24:
                    SSCG_REG_0 =  value;
                    break;
                case 0x28:
                    SSCG_REG_1 =  value;
                    break;
                case 0x2C:
                    SSCG_REG_2 =  value;
                    break;
                case 0x30:
                    SSCG_REG_3 =  value;
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


