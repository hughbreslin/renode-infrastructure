using Antmicro.Renode.Peripherals.Bus;
using Antmicro.Renode.Logging;

namespace Antmicro.Renode.Peripherals.Miscellaneous
{
    public class DDR_CSR_APB_20082000 : IDoubleWordPeripheral, IKnownSize
    {
        private ulong CFG_MANUAL_ADDRESS_MAP = 0x00000000;
        private ulong CFG_CHIPADDR_MAP = 0x00000000;
        private ulong CFG_CIDADDR_MAP = 0x00000000;
        private ulong CFG_MB_AUTOPCH_COL_BIT_POS_LOW = 0x00000004;
        private ulong CFG_MB_AUTOPCH_COL_BIT_POS_HIGH = 0x0000000A;
        private ulong CFG_BANKADDR_MAP_0 = 0x00000000;
        private ulong CFG_BANKADDR_MAP_1 = 0x00000000;
        private ulong CFG_ROWADDR_MAP_0 = 0x00000000;
        private ulong CFG_ROWADDR_MAP_1 = 0x00000000;
        private ulong CFG_ROWADDR_MAP_2 = 0x00000000;
        private ulong CFG_ROWADDR_MAP_3 = 0x00000000;
        private ulong CFG_COLADDR_MAP_0 = 0x00000000;
        private ulong CFG_COLADDR_MAP_1 = 0x00000000;
        private ulong CFG_COLADDR_MAP_2 = 0x00000000;
        private ulong CFG_VRCG_ENABLE = 0x00000140;
        private ulong CFG_VRCG_DISABLE = 0x000000A0;
        private ulong CFG_WRITE_LATENCY_SET = 0x00000000;
        private ulong CFG_THERMAL_OFFSET = 0x00000000;
        private ulong CFG_SOC_ODT = 0x00000000;
        private ulong CFG_ODTE_CK = 0x00000000;
        private ulong CFG_ODTE_CS = 0x00000000;
        private ulong CFG_ODTD_CA = 0x00000000;
        private ulong CFG_LPDDR4_FSP_OP = 0x00000000;
        private ulong CFG_GENERATE_REFRESH_ON_SRX = 0x00000001;
        private ulong CFG_DBI_CL = 0x00000016;
        private ulong CFG_NON_DBI_CL = 0x00000016;
        private ulong INIT_FORCE_WRITE_DATA_0 = 0x00000000;

        public uint ReadDoubleWord(long offset)
        {
            ulong value = 0x0u;
            switch(offset)
            {
                case 0x400:
                    value = CFG_MANUAL_ADDRESS_MAP;
                    break;
                case 0x404:
                    value = CFG_CHIPADDR_MAP;
                    break;
                case 0x408:
                    value = CFG_CIDADDR_MAP;
                    break;
                case 0x40C:
                    value = CFG_MB_AUTOPCH_COL_BIT_POS_LOW;
                    break;
                case 0x410:
                    value = CFG_MB_AUTOPCH_COL_BIT_POS_HIGH;
                    break;
                case 0x414:
                    value = CFG_BANKADDR_MAP_0;
                    break;
                case 0x418:
                    value = CFG_BANKADDR_MAP_1;
                    break;
                case 0x41C:
                    value = CFG_ROWADDR_MAP_0;
                    break;
                case 0x420:
                    value = CFG_ROWADDR_MAP_1;
                    break;
                case 0x424:
                    value = CFG_ROWADDR_MAP_2;
                    break;
                case 0x428:
                    value = CFG_ROWADDR_MAP_3;
                    break;
                case 0x42C:
                    value = CFG_COLADDR_MAP_0;
                    break;
                case 0x430:
                    value = CFG_COLADDR_MAP_1;
                    break;
                case 0x434:
                    value = CFG_COLADDR_MAP_2;
                    break;
                case 0x800:
                    value = CFG_VRCG_ENABLE;
                    break;
                case 0x804:
                    value = CFG_VRCG_DISABLE;
                    break;
                case 0x808:
                    value = CFG_WRITE_LATENCY_SET;
                    break;
                case 0x80C:
                    value = CFG_THERMAL_OFFSET;
                    break;
                case 0x810:
                    value = CFG_SOC_ODT;
                    break;
                case 0x814:
                    value = CFG_ODTE_CK;
                    break;
                case 0x818:
                    value = CFG_ODTE_CS;
                    break;
                case 0x81C:
                    value = CFG_ODTD_CA;
                    break;
                case 0x820:
                    value = CFG_LPDDR4_FSP_OP;
                    break;
                case 0x824:
                    value = CFG_GENERATE_REFRESH_ON_SRX;
                    break;
                case 0x828:
                    value = CFG_DBI_CL;
                    break;
                case 0x82C:
                    value = CFG_NON_DBI_CL;
                    break;
                case 0x830:
                    value = INIT_FORCE_WRITE_DATA_0;
                    break;
                default:
                    value = 0x0;
                    break;
            }
            this.Log(LogLevel.Noisy, "Read byte from DDR controller - offset: 0x{0:X}, value 0x{1:X}", offset, value);
            return (uint)value;
        }

        public void WriteDoubleWord(long offset, uint value)
        {
            switch(offset)
            {
                case 0x400:
                    CFG_MANUAL_ADDRESS_MAP =  value;
                    break;
                case 0x404:
                    CFG_CHIPADDR_MAP =  value;
                    break;
                case 0x408:
                    CFG_CIDADDR_MAP =  value;
                    break;
                case 0x40C:
                    CFG_MB_AUTOPCH_COL_BIT_POS_LOW =  value;
                    break;
                case 0x410:
                    CFG_MB_AUTOPCH_COL_BIT_POS_HIGH =  value;
                    break;
                case 0x414:
                    CFG_BANKADDR_MAP_0 =  value;
                    break;
                case 0x418:
                    CFG_BANKADDR_MAP_1 =  value;
                    break;
                case 0x41C:
                    CFG_ROWADDR_MAP_0 =  value;
                    break;
                case 0x420:
                    CFG_ROWADDR_MAP_1 =  value;
                    break;
                case 0x424:
                    CFG_ROWADDR_MAP_2 =  value;
                    break;
                case 0x428:
                    CFG_ROWADDR_MAP_3 =  value;
                    break;
                case 0x42C:
                    CFG_COLADDR_MAP_0 =  value;
                    break;
                case 0x430:
                    CFG_COLADDR_MAP_1 =  value;
                    break;
                case 0x434:
                    CFG_COLADDR_MAP_2 =  value;
                    break;
                case 0x800:
                    CFG_VRCG_ENABLE =  value;
                    break;
                case 0x804:
                    CFG_VRCG_DISABLE =  value;
                    break;
                case 0x808:
                    CFG_WRITE_LATENCY_SET =  value;
                    break;
                case 0x80C:
                    CFG_THERMAL_OFFSET =  value;
                    break;
                case 0x810:
                    CFG_SOC_ODT =  value;
                    break;
                case 0x814:
                    CFG_ODTE_CK =  value;
                    break;
                case 0x818:
                    CFG_ODTE_CS =  value;
                    break;
                case 0x81C:
                    CFG_ODTD_CA =  value;
                    break;
                case 0x820:
                    CFG_LPDDR4_FSP_OP =  value;
                    break;
                case 0x824:
                    CFG_GENERATE_REFRESH_ON_SRX =  value;
                    break;
                case 0x828:
                    CFG_DBI_CL =  value;
                    break;
                case 0x82C:
                    CFG_NON_DBI_CL =  value;
                    break;
                case 0x830:
                    INIT_FORCE_WRITE_DATA_0 =  value;
                    break;
                default:
                    break;
            }
            this.Log(LogLevel.Noisy, "write word DDR controller - offset: 0x{0:X}, value 0x{1:X}", offset, value);
        }

        public void Reset()
        {
        }

public long Size => 0xFFF; // Size is address space on sysbus
    }
}


