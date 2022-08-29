using Antmicro.Renode.Peripherals.Bus;
using Antmicro.Renode.Logging;

namespace Antmicro.Renode.Peripherals.Miscellaneous
{
    public class DDR_CSR_APB_20090000 : IDoubleWordPeripheral, IKnownSize
    {
        private ulong CFG_DFI_T_RDDATA_EN = 0x00000014;
        private ulong CFG_DFI_T_PHY_RDLAT = 0x00000005;
        private ulong CFG_DFI_T_PHY_WRLAT = 0x00000005;
        private ulong CFG_DFI_PHYUPD_EN = 0x00000001;
        private ulong INIT_DFI_LP_DATA_REQ = 0x00000000;
        private ulong INIT_DFI_LP_CTRL_REQ = 0x00000000;
        private ulong STAT_DFI_LP_ACK = 0x00000000;
        private ulong INIT_DFI_LP_WAKEUP = 0x00000000;
        private ulong INIT_DFI_DRAM_CLK_DISABLE = 0x00000000;
        private ulong STAT_DFI_TRAINING_ERROR = 0x00000000;
        private ulong STAT_DFI_ERROR = 0x00000000;
        private ulong STAT_DFI_ERROR_INFO = 0x00000000;
        private ulong CFG_DFI_DATA_BYTE_DISABLE = 0x00000000;
        private ulong STAT_DFI_INIT_COMPLETE = 0x00000000;
        private ulong STAT_DFI_TRAINING_COMPLETE = 0x00000000;
        private ulong CFG_DFI_LVL_SEL = 0x00000000;
        private ulong CFG_DFI_LVL_PERIODIC = 0x00000000;
        private ulong CFG_DFI_LVL_PATTERN = 0x00000000;
        private ulong PHY_DFI_INIT_START = 0x00000000;

        public uint ReadDoubleWord(long offset)
        {
            ulong value = 0x0u;
            switch(offset)
            {
                case 0x000:
                    value = CFG_DFI_T_RDDATA_EN;
                    break;
                case 0x004:
                    value = CFG_DFI_T_PHY_RDLAT;
                    break;
                case 0x008:
                    value = CFG_DFI_T_PHY_WRLAT;
                    break;
                case 0x00C:
                    value = CFG_DFI_PHYUPD_EN;
                    break;
                case 0x010:
                    value = INIT_DFI_LP_DATA_REQ;
                    break;
                case 0x014:
                    value = INIT_DFI_LP_CTRL_REQ;
                    break;
                case 0x018:
                    value = STAT_DFI_LP_ACK;
                    break;
                case 0x01C:
                    value = INIT_DFI_LP_WAKEUP;
                    break;
                case 0x020:
                    value = INIT_DFI_DRAM_CLK_DISABLE;
                    break;
                case 0x024:
                    value = STAT_DFI_TRAINING_ERROR;
                    break;
                case 0x028:
                    value = STAT_DFI_ERROR;
                    break;
                case 0x02C:
                    value = STAT_DFI_ERROR_INFO;
                    break;
                case 0x030:
                    value = CFG_DFI_DATA_BYTE_DISABLE;
                    break;
                case 0x034:
                    value = STAT_DFI_INIT_COMPLETE;
                    break;
                case 0x038:
                    value = STAT_DFI_TRAINING_COMPLETE;
                    break;
                case 0x03C:
                    value = CFG_DFI_LVL_SEL;
                    break;
                case 0x040:
                    value = CFG_DFI_LVL_PERIODIC;
                    break;
                case 0x044:
                    value = CFG_DFI_LVL_PATTERN;
                    break;
                case 0x050:
                    value = PHY_DFI_INIT_START;
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
                    CFG_DFI_T_RDDATA_EN =  value;
                    break;
                case 0x004:
                    CFG_DFI_T_PHY_RDLAT =  value;
                    break;
                case 0x008:
                    CFG_DFI_T_PHY_WRLAT =  value;
                    break;
                case 0x00C:
                    CFG_DFI_PHYUPD_EN =  value;
                    break;
                case 0x010:
                    INIT_DFI_LP_DATA_REQ =  value;
                    break;
                case 0x014:
                    INIT_DFI_LP_CTRL_REQ =  value;
                    break;
                case 0x018:
                    STAT_DFI_LP_ACK =  value;
                    break;
                case 0x01C:
                    INIT_DFI_LP_WAKEUP =  value;
                    break;
                case 0x020:
                    INIT_DFI_DRAM_CLK_DISABLE =  value;
                    break;
                case 0x024:
                    STAT_DFI_TRAINING_ERROR =  value;
                    break;
                case 0x028:
                    STAT_DFI_ERROR =  value;
                    break;
                case 0x02C:
                    STAT_DFI_ERROR_INFO =  value;
                    break;
                case 0x030:
                    CFG_DFI_DATA_BYTE_DISABLE =  value;
                    break;
                case 0x034:
                    STAT_DFI_INIT_COMPLETE =  value;
                    break;
                case 0x038:
                    STAT_DFI_TRAINING_COMPLETE =  value;
                    break;
                case 0x03C:
                    CFG_DFI_LVL_SEL =  value;
                    break;
                case 0x040:
                    CFG_DFI_LVL_PERIODIC =  value;
                    break;
                case 0x044:
                    CFG_DFI_LVL_PATTERN =  value;
                    break;
                case 0x050:
                    PHY_DFI_INIT_START =  value;
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


