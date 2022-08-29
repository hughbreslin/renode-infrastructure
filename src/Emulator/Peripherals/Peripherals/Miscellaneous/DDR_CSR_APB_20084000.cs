using Antmicro.Renode.Peripherals.Bus;
using Antmicro.Renode.Logging;

namespace Antmicro.Renode.Peripherals.Miscellaneous
{
    public class DDR_CSR_APB_20084000 : IDoubleWordPeripheral, IKnownSize
    {
        private ulong CTRLR_SOFT_RESET_N = 0x00000000;
        private ulong CFG_LOOKAHEAD_PCH = 0x00000001;
        private ulong CFG_LOOKAHEAD_ACT = 0x00000001;
        private ulong INIT_AUTOINIT_DISABLE = 0x00000000;
        private ulong INIT_FORCE_RESET = 0x00000000;
        private ulong INIT_GEARDOWN_EN = 0x00000000;
        private ulong INIT_DISABLE_CKE = 0x00000000;
        private ulong INIT_CS = 0x00000000;
        private ulong INIT_PRECHARGE_ALL = 0x00000000;
        private ulong INIT_REFRESH = 0x00000000;
        private ulong INIT_ZQ_CAL_REQ = 0x00000000;
        private ulong INIT_ACK = 0x00000000;
        private ulong CFG_BL = 0x00000000;
        private ulong CTRLR_INIT = 0x00000000;
        private ulong CTRLR_INIT_DONE = 0x00000000;
        private ulong CFG_AUTO_REF_EN = 0x00000001;
        private ulong CFG_RAS = 0x0000001C;
        private ulong CFG_RCD = 0x0000000B;
        private ulong CFG_RRD = 0x00000005;
        private ulong CFG_RP = 0x0000000B;
        private ulong CFG_RC = 0x00000027;
        private ulong CFG_FAW = 0x00000018;
        private ulong CFG_RFC = 0x00000118;
        private ulong CFG_RTP = 0x00000006;
        private ulong CFG_WR = 0x0000000C;
        private ulong CFG_WTR = 0x00000006;
        private ulong CFG_PASR = 0x00000000;
        private ulong CFG_XP = 0x00000002;
        private ulong CFG_XSR = 0x00000002;
        private ulong CFG_CL = 0x0000000B;
        private ulong CFG_READ_TO_WRITE = 0x00000002;
        private ulong CFG_WRITE_TO_WRITE = 0x00000003;
        private ulong CFG_READ_TO_READ = 0x00000003;
        private ulong CFG_WRITE_TO_READ = 0x00000002;
        private ulong CFG_READ_TO_WRITE_ODT = 0x00000002;
        private ulong CFG_WRITE_TO_WRITE_ODT = 0x00000003;
        private ulong CFG_READ_TO_READ_ODT = 0x00000003;
        private ulong CFG_WRITE_TO_READ_ODT = 0x00000002;
        private ulong CFG_MIN_READ_IDLE = 0x00000000;
        private ulong CFG_MRD = 0x0000000C;
        private ulong CFG_BT = 0x00000000;
        private ulong CFG_DS = 0x00000000;
        private ulong CFG_QOFF = 0x00000000;
        private ulong CFG_RTT = 0x00000001;
        private ulong CFG_DLL_DISABLE = 0x00000000;
        private ulong CFG_REF_PER = 0x00001860;
        private ulong CFG_STARTUP_DELAY = 0x00027100;
        private ulong CFG_MEM_COLBITS = 0x0000000B;
        private ulong CFG_MEM_ROWBITS = 0x00000010;
        private ulong CFG_MEM_BANKBITS = 0x00000003;
        private ulong CFG_ODT_RD_MAP_CS0 = 0x00000002;
        private ulong CFG_ODT_RD_MAP_CS1 = 0x00000001;
        private ulong CFG_ODT_RD_MAP_CS2 = 0x00000008;
        private ulong CFG_ODT_RD_MAP_CS3 = 0x00000004;
        private ulong CFG_ODT_RD_MAP_CS4 = 0x00000020;
        private ulong CFG_ODT_RD_MAP_CS5 = 0x00000010;
        private ulong CFG_ODT_RD_MAP_CS6 = 0x00000080;
        private ulong CFG_ODT_RD_MAP_CS7 = 0x00000040;
        private ulong CFG_ODT_WR_MAP_CS0 = 0x00000001;
        private ulong CFG_ODT_WR_MAP_CS1 = 0x00000002;
        private ulong CFG_ODT_WR_MAP_CS2 = 0x00000004;
        private ulong CFG_ODT_WR_MAP_CS3 = 0x00000008;
        private ulong CFG_ODT_WR_MAP_CS4 = 0x00000010;
        private ulong CFG_ODT_WR_MAP_CS5 = 0x00000020;
        private ulong CFG_ODT_WR_MAP_CS6 = 0x00000040;
        private ulong CFG_ODT_WR_MAP_CS7 = 0x00000080;
        private ulong CFG_ODT_RD_TURN_ON = 0x00000000;
        private ulong CFG_ODT_WR_TURN_ON = 0x00000000;
        private ulong CFG_ODT_RD_TURN_OFF = 0x00000000;
        private ulong CFG_ODT_WR_TURN_OFF = 0x00000000;
        private ulong CFG_EMR3 = 0x00000000;
        private ulong CFG_TWO_T = 0x00000000;
        private ulong CFG_TWO_T_SEL_CYCLE = 0x00000000;
        private ulong CFG_REGDIMM = 0x00000000;
        private ulong CFG_MOD = 0x0000000C;
        private ulong CFG_XS = 0x00000120;
        private ulong CFG_XSDLL = 0x00000200;
        private ulong CFG_XPR = 0x00000120;
        private ulong CFG_AL_MODE = 0x00000000;
        private ulong CFG_CWL = 0x00000008;
        private ulong CFG_BL_MODE = 0x00000000;
        private ulong CFG_TDQS = 0x00000000;
        private ulong CFG_RTT_WR = 0x00000000;
        private ulong CFG_LP_ASR = 0x00000000;
        private ulong CFG_AUTO_SR = 0x00000000;
        private ulong CFG_SRT = 0x00000000;
        private ulong CFG_ADDR_MIRROR = 0x00000000;
        private ulong CFG_ZQ_CAL_TYPE = 0x00000000;
        private ulong CFG_ZQ_CAL_PER = 0x00003F40;
        private ulong CFG_AUTO_ZQ_CAL_EN = 0x00000001;
        private ulong CFG_MEMORY_TYPE = 0x00000008;
        private ulong CFG_ONLY_SRANK_CMDS = 0x00000000;
        private ulong CFG_NUM_RANKS = 0x00000002;
        private ulong CFG_QUAD_RANK = 0x00000000;
        private ulong CFG_EARLY_RANK_TO_WR_START = 0x00000000;
        private ulong CFG_EARLY_RANK_TO_RD_START = 0x00000000;
        private ulong CFG_PASR_BANK = 0x00000000;
        private ulong CFG_PASR_SEG = 0x00000000;
        private ulong INIT_MRR_MODE = 0x00000000;
        private ulong INIT_MR_W_REQ = 0x00000000;
        private ulong INIT_MR_ADDR = 0x00000000;
        private ulong INIT_MR_WR_DATA = 0x00000000;
        private ulong INIT_MR_WR_MASK = 0x00000000;
        private ulong INIT_NOP = 0x00000000;
        private ulong CFG_INIT_DURATION = 0x000029B0;
        private ulong CFG_ZQINIT_CAL_DURATION = 0x00000200;
        private ulong CFG_ZQ_CAL_L_DURATION = 0x00000100;
        private ulong CFG_ZQ_CAL_S_DURATION = 0x00000040;
        private ulong CFG_ZQ_CAL_R_DURATION = 0x00000035;
        private ulong CFG_MRR = 0x00000002;
        private ulong CFG_MRW = 0x0000000C;
        private ulong CFG_ODT_POWERDOWN = 0x00000000;
        private ulong CFG_WL = 0x00000008;
        private ulong CFG_RL = 0x0000000B;
        private ulong CFG_CAL_READ_PERIOD = 0x00000000;
        private ulong CFG_NUM_CAL_READS = 0x00000000;
        private ulong INIT_SELF_REFRESH = 0x00000000;
        private ulong INIT_SELF_REFRESH_STATUS = 0x00000000;
        private ulong INIT_POWER_DOWN = 0x00000000;
        private ulong INIT_POWER_DOWN_STATUS = 0x00000000;
        private ulong INIT_FORCE_WRITE = 0x00000000;
        private ulong INIT_FORCE_WRITE_CS = 0x00000000;
        private ulong CFG_CTRLR_INIT_DISABLE = 0x00000000;
        private ulong CTRLR_READY = 0x00000000;
        private ulong INIT_RDIMM_READY = 0x00000000;
        private ulong INIT_RDIMM_COMPLETE = 0x00000000;
        private ulong CFG_RDIMM_LAT = 0x00000000;
        private ulong CFG_RDIMM_BSIDE_INVERT = 0x00000001;
        private ulong CFG_LRDIMM = 0x00000000;
        private ulong INIT_MEMORY_RESET_MASK = 0x00000000;
        private ulong CFG_RD_PREAMB_TOGGLE = 0x00000000;
        private ulong CFG_RD_POSTAMBLE = 0x00000000;
        private ulong CFG_PU_CAL = 0x00000000;
        private ulong CFG_DQ_ODT = 0x00000000;
        private ulong CFG_CA_ODT = 0x00000000;
        private ulong CFG_ZQLATCH_DURATION = 0x00000030;
        private ulong INIT_CAL_SELECT = 0x00000000;
        private ulong INIT_CAL_L_R_REQ = 0x00000000;
        private ulong INIT_CAL_L_B_SIZE = 0x00000000;
        private ulong INIT_CAL_L_R_ACK = 0x00000000;
        private ulong INIT_CAL_L_READ_COMPLETE = 0x00000000;
        private ulong INIT_RWFIFO = 0x00000000;
        private ulong INIT_RD_DQCAL = 0x00000000;
        private ulong INIT_START_DQSOSC = 0x00000000;
        private ulong INIT_STOP_DQSOSC = 0x00000000;
        private ulong INIT_ZQ_CAL_START = 0x00000000;
        private ulong CFG_WR_POSTAMBLE = 0x00000000;
        private ulong INIT_CAL_L_ADDR_0 = 0x00000000;
        private ulong INIT_CAL_L_ADDR_1 = 0x00000000;
        private ulong CFG_CTRLUPD_TRIG = 0x00000001;
        private ulong CFG_CTRLUPD_START_DELAY = 0x00000016;
        private ulong CFG_DFI_T_CTRLUPD_MAX = 0x000000C8;
        private ulong CFG_CTRLR_BUSY_SEL = 0x00000000;
        private ulong CFG_CTRLR_BUSY_VALUE = 0x00000000;
        private ulong CFG_CTRLR_BUSY_TURN_OFF_DELAY = 0x00000000;
        private ulong CFG_CTRLR_BUSY_SLOW_RESTART_WINDOW = 0x00000000;
        private ulong CFG_CTRLR_BUSY_RESTART_HOLDOFF = 0x00000000;
        private ulong CFG_PARITY_RDIMM_DELAY = 0x00000001;
        private ulong CFG_CTRLR_BUSY_ENABLE = 0x00000000;
        private ulong CFG_ASYNC_ODT = 0x00000000;
        private ulong CFG_ZQ_CAL_DURATION = 0x00000640;
        private ulong CFG_MRRI = 0x00000000;
        private ulong INIT_ODT_FORCE_EN = 0x00000000;
        private ulong INIT_ODT_FORCE_RANK = 0x00000000;
        private ulong CFG_PHYUPD_ACK_DELAY = 0x00000000;
        private ulong CFG_MIRROR_X16_BG0_BG1 = 0x00000000;
        private ulong INIT_PDA_MR_W_REQ = 0x00000000;
        private ulong INIT_PDA_NIBBLE_SELECT = 0x00000000;
        private ulong CFG_DRAM_CLK_DISABLE_IN_SELF_REFRESH = 0x00000000;
        private ulong CFG_CKSRE = 0x00000008;
        private ulong CFG_CKSRX = 0x00000008;
        private ulong CFG_RCD_STAB = 0x00000000;
        private ulong CFG_DFI_T_CTRL_DELAY = 0x00000000;
        private ulong CFG_DFI_T_DRAM_CLK_ENABLE = 0x00000000;
        private ulong CFG_IDLE_TIME_TO_SELF_REFRESH = 0x00000000;
        private ulong CFG_IDLE_TIME_TO_POWER_DOWN = 0x00000000;
        private ulong CFG_BURST_RW_REFRESH_HOLDOFF = 0x00000000;
        private ulong INIT_REFRESH_COUNT = 0x00000000;
        private ulong CFG_BG_INTERLEAVE = 0x00000001;
        private ulong CFG_REFRESH_DURING_PHY_TRAINING = 0x00000000;
        private ulong MT_EN = 0x00000000;
        private ulong MT_EN_SINGLE = 0x00000000;
        private ulong MT_STOP_ON_ERROR = 0x00000000;
        private ulong MT_RD_ONLY = 0x00000000;
        private ulong MT_WR_ONLY = 0x00000000;
        private ulong MT_DATA_PATTERN = 0x00000000;
        private ulong MT_ADDR_PATTERN = 0x00000000;
        private ulong MT_DATA_INVERT = 0x00000000;
        private ulong MT_ADDR_BITS = 0x00000008;
        private ulong MT_ERROR_STS = 0x00000000;
        private ulong MT_DONE_ACK = 0x00000000;
        private ulong MT_START_ADDR_0 = 0x00000000;
        private ulong MT_START_ADDR_1 = 0x00000000;
        private ulong MT_ERROR_MASK_0 = 0x00000000;
        private ulong MT_ERROR_MASK_1 = 0x00000000;
        private ulong MT_ERROR_MASK_2 = 0x00000000;
        private ulong MT_ERROR_MASK_3 = 0x00000000;
        private ulong MT_ERROR_MASK_4 = 0x00000000;
        private ulong MT_USER_DATA_PATTERN = 0x00000000;
        private ulong MT_ALG_AUTO_PCH = 0x00000000;
        private ulong CFG_STARVE_TIMEOUT_P0 = 0x00000000;
        private ulong CFG_STARVE_TIMEOUT_P1 = 0x00000000;
        private ulong CFG_STARVE_TIMEOUT_P2 = 0x00000000;
        private ulong CFG_STARVE_TIMEOUT_P3 = 0x00000000;
        private ulong CFG_STARVE_TIMEOUT_P4 = 0x00000000;
        private ulong CFG_STARVE_TIMEOUT_P5 = 0x00000000;
        private ulong CFG_STARVE_TIMEOUT_P6 = 0x00000000;
        private ulong CFG_STARVE_TIMEOUT_P7 = 0x00000000;

        public uint ReadDoubleWord(long offset)
        {
            ulong value = 0x0u;
            switch(offset)
            {
                case 0x000:
                    value = CTRLR_SOFT_RESET_N;
                    break;
                case 0x008:
                    value = CFG_LOOKAHEAD_PCH;
                    break;
                case 0x00C:
                    value = CFG_LOOKAHEAD_ACT;
                    break;
                case 0x010:
                    value = INIT_AUTOINIT_DISABLE;
                    break;
                case 0x014:
                    value = INIT_FORCE_RESET;
                    break;
                case 0x018:
                    value = INIT_GEARDOWN_EN;
                    break;
                case 0x01C:
                    value = INIT_DISABLE_CKE;
                    break;
                case 0x020:
                    value = INIT_CS;
                    break;
                case 0x024:
                    value = INIT_PRECHARGE_ALL;
                    break;
                case 0x028:
                    value = INIT_REFRESH;
                    break;
                case 0x02C:
                    value = INIT_ZQ_CAL_REQ;
                    break;
                case 0x030:
                    value = INIT_ACK;
                    break;
                case 0x034:
                    value = CFG_BL;
                    break;
                case 0x038:
                    value = CTRLR_INIT;
                    break;
                case 0x03C:
                    value = CTRLR_INIT_DONE;
                    break;
                case 0x040:
                    value = CFG_AUTO_REF_EN;
                    break;
                case 0x044:
                    value = CFG_RAS;
                    break;
                case 0x048:
                    value = CFG_RCD;
                    break;
                case 0x04C:
                    value = CFG_RRD;
                    break;
                case 0x050:
                    value = CFG_RP;
                    break;
                case 0x054:
                    value = CFG_RC;
                    break;
                case 0x058:
                    value = CFG_FAW;
                    break;
                case 0x05C:
                    value = CFG_RFC;
                    break;
                case 0x060:
                    value = CFG_RTP;
                    break;
                case 0x064:
                    value = CFG_WR;
                    break;
                case 0x068:
                    value = CFG_WTR;
                    break;
                case 0x070:
                    value = CFG_PASR;
                    break;
                case 0x074:
                    value = CFG_XP;
                    break;
                case 0x078:
                    value = CFG_XSR;
                    break;
                case 0x080:
                    value = CFG_CL;
                    break;
                case 0x088:
                    value = CFG_READ_TO_WRITE;
                    break;
                case 0x08C:
                    value = CFG_WRITE_TO_WRITE;
                    break;
                case 0x090:
                    value = CFG_READ_TO_READ;
                    break;
                case 0x094:
                    value = CFG_WRITE_TO_READ;
                    break;
                case 0x098:
                    value = CFG_READ_TO_WRITE_ODT;
                    break;
                case 0x09C:
                    value = CFG_WRITE_TO_WRITE_ODT;
                    break;
                case 0x0A0:
                    value = CFG_READ_TO_READ_ODT;
                    break;
                case 0x0A4:
                    value = CFG_WRITE_TO_READ_ODT;
                    break;
                case 0x0A8:
                    value = CFG_MIN_READ_IDLE;
                    break;
                case 0x0AC:
                    value = CFG_MRD;
                    break;
                case 0x0B0:
                    value = CFG_BT;
                    break;
                case 0x0B4:
                    value = CFG_DS;
                    break;
                case 0x0B8:
                    value = CFG_QOFF;
                    break;
                case 0x0C4:
                    value = CFG_RTT;
                    break;
                case 0x0C8:
                    value = CFG_DLL_DISABLE;
                    break;
                case 0x0CC:
                    value = CFG_REF_PER;
                    break;
                case 0x0D0:
                    value = CFG_STARTUP_DELAY;
                    break;
                case 0x0D4:
                    value = CFG_MEM_COLBITS;
                    break;
                case 0x0D8:
                    value = CFG_MEM_ROWBITS;
                    break;
                case 0x0DC:
                    value = CFG_MEM_BANKBITS;
                    break;
                case 0x0E0:
                    value = CFG_ODT_RD_MAP_CS0;
                    break;
                case 0x0E4:
                    value = CFG_ODT_RD_MAP_CS1;
                    break;
                case 0x0E8:
                    value = CFG_ODT_RD_MAP_CS2;
                    break;
                case 0x0EC:
                    value = CFG_ODT_RD_MAP_CS3;
                    break;
                case 0x0F0:
                    value = CFG_ODT_RD_MAP_CS4;
                    break;
                case 0x0F4:
                    value = CFG_ODT_RD_MAP_CS5;
                    break;
                case 0x0F8:
                    value = CFG_ODT_RD_MAP_CS6;
                    break;
                case 0x0FC:
                    value = CFG_ODT_RD_MAP_CS7;
                    break;
                case 0x120:
                    value = CFG_ODT_WR_MAP_CS0;
                    break;
                case 0x124:
                    value = CFG_ODT_WR_MAP_CS1;
                    break;
                case 0x128:
                    value = CFG_ODT_WR_MAP_CS2;
                    break;
                case 0x12C:
                    value = CFG_ODT_WR_MAP_CS3;
                    break;
                case 0x130:
                    value = CFG_ODT_WR_MAP_CS4;
                    break;
                case 0x134:
                    value = CFG_ODT_WR_MAP_CS5;
                    break;
                case 0x138:
                    value = CFG_ODT_WR_MAP_CS6;
                    break;
                case 0x13C:
                    value = CFG_ODT_WR_MAP_CS7;
                    break;
                case 0x160:
                    value = CFG_ODT_RD_TURN_ON;
                    break;
                case 0x164:
                    value = CFG_ODT_WR_TURN_ON;
                    break;
                case 0x168:
                    value = CFG_ODT_RD_TURN_OFF;
                    break;
                case 0x16C:
                    value = CFG_ODT_WR_TURN_OFF;
                    break;
                case 0x178:
                    value = CFG_EMR3;
                    break;
                case 0x17C:
                    value = CFG_TWO_T;
                    break;
                case 0x180:
                    value = CFG_TWO_T_SEL_CYCLE;
                    break;
                case 0x184:
                    value = CFG_REGDIMM;
                    break;
                case 0x188:
                    value = CFG_MOD;
                    break;
                case 0x18C:
                    value = CFG_XS;
                    break;
                case 0x190:
                    value = CFG_XSDLL;
                    break;
                case 0x194:
                    value = CFG_XPR;
                    break;
                case 0x198:
                    value = CFG_AL_MODE;
                    break;
                case 0x19C:
                    value = CFG_CWL;
                    break;
                case 0x1A0:
                    value = CFG_BL_MODE;
                    break;
                case 0x1A4:
                    value = CFG_TDQS;
                    break;
                case 0x1A8:
                    value = CFG_RTT_WR;
                    break;
                case 0x1AC:
                    value = CFG_LP_ASR;
                    break;
                case 0x1B0:
                    value = CFG_AUTO_SR;
                    break;
                case 0x1B4:
                    value = CFG_SRT;
                    break;
                case 0x1B8:
                    value = CFG_ADDR_MIRROR;
                    break;
                case 0x1BC:
                    value = CFG_ZQ_CAL_TYPE;
                    break;
                case 0x1C0:
                    value = CFG_ZQ_CAL_PER;
                    break;
                case 0x1C4:
                    value = CFG_AUTO_ZQ_CAL_EN;
                    break;
                case 0x1C8:
                    value = CFG_MEMORY_TYPE;
                    break;
                case 0x1CC:
                    value = CFG_ONLY_SRANK_CMDS;
                    break;
                case 0x1D0:
                    value = CFG_NUM_RANKS;
                    break;
                case 0x1D4:
                    value = CFG_QUAD_RANK;
                    break;
                case 0x1DC:
                    value = CFG_EARLY_RANK_TO_WR_START;
                    break;
                case 0x1E0:
                    value = CFG_EARLY_RANK_TO_RD_START;
                    break;
                case 0x1E4:
                    value = CFG_PASR_BANK;
                    break;
                case 0x1E8:
                    value = CFG_PASR_SEG;
                    break;
                case 0x1EC:
                    value = INIT_MRR_MODE;
                    break;
                case 0x1F0:
                    value = INIT_MR_W_REQ;
                    break;
                case 0x1F4:
                    value = INIT_MR_ADDR;
                    break;
                case 0x1F8:
                    value = INIT_MR_WR_DATA;
                    break;
                case 0x1FC:
                    value = INIT_MR_WR_MASK;
                    break;
                case 0x200:
                    value = INIT_NOP;
                    break;
                case 0x204:
                    value = CFG_INIT_DURATION;
                    break;
                case 0x208:
                    value = CFG_ZQINIT_CAL_DURATION;
                    break;
                case 0x20C:
                    value = CFG_ZQ_CAL_L_DURATION;
                    break;
                case 0x210:
                    value = CFG_ZQ_CAL_S_DURATION;
                    break;
                case 0x214:
                    value = CFG_ZQ_CAL_R_DURATION;
                    break;
                case 0x218:
                    value = CFG_MRR;
                    break;
                case 0x21C:
                    value = CFG_MRW;
                    break;
                case 0x220:
                    value = CFG_ODT_POWERDOWN;
                    break;
                case 0x224:
                    value = CFG_WL;
                    break;
                case 0x228:
                    value = CFG_RL;
                    break;
                case 0x22C:
                    value = CFG_CAL_READ_PERIOD;
                    break;
                case 0x230:
                    value = CFG_NUM_CAL_READS;
                    break;
                case 0x234:
                    value = INIT_SELF_REFRESH;
                    break;
                case 0x238:
                    value = INIT_SELF_REFRESH_STATUS;
                    break;
                case 0x23C:
                    value = INIT_POWER_DOWN;
                    break;
                case 0x240:
                    value = INIT_POWER_DOWN_STATUS;
                    break;
                case 0x244:
                    value = INIT_FORCE_WRITE;
                    break;
                case 0x248:
                    value = INIT_FORCE_WRITE_CS;
                    break;
                case 0x24C:
                    value = CFG_CTRLR_INIT_DISABLE;
                    break;
                case 0x250:
                    value = CTRLR_READY;
                    break;
                case 0x254:
                    value = INIT_RDIMM_READY;
                    break;
                case 0x258:
                    value = INIT_RDIMM_COMPLETE;
                    break;
                case 0x25C:
                    value = CFG_RDIMM_LAT;
                    break;
                case 0x260:
                    value = CFG_RDIMM_BSIDE_INVERT;
                    break;
                case 0x264:
                    value = CFG_LRDIMM;
                    break;
                case 0x268:
                    value = INIT_MEMORY_RESET_MASK;
                    break;
                case 0x26C:
                    value = CFG_RD_PREAMB_TOGGLE;
                    break;
                case 0x270:
                    value = CFG_RD_POSTAMBLE;
                    break;
                case 0x274:
                    value = CFG_PU_CAL;
                    break;
                case 0x278:
                    value = CFG_DQ_ODT;
                    break;
                case 0x27C:
                    value = CFG_CA_ODT;
                    break;
                case 0x280:
                    value = CFG_ZQLATCH_DURATION;
                    break;
                case 0x284:
                    value = INIT_CAL_SELECT;
                    break;
                case 0x288:
                    value = INIT_CAL_L_R_REQ;
                    break;
                case 0x28C:
                    value = INIT_CAL_L_B_SIZE;
                    break;
                case 0x290:
                    value = INIT_CAL_L_R_ACK;
                    break;
                case 0x294:
                    value = INIT_CAL_L_READ_COMPLETE;
                    break;
                case 0x2A0:
                    value = INIT_RWFIFO;
                    break;
                case 0x2A4:
                    value = INIT_RD_DQCAL;
                    break;
                case 0x2A8:
                    value = INIT_START_DQSOSC;
                    break;
                case 0x2AC:
                    value = INIT_STOP_DQSOSC;
                    break;
                case 0x2B0:
                    value = INIT_ZQ_CAL_START;
                    break;
                case 0x2B4:
                    value = CFG_WR_POSTAMBLE;
                    break;
                case 0x2BC:
                    value = INIT_CAL_L_ADDR_0;
                    break;
                case 0x2C0:
                    value = INIT_CAL_L_ADDR_1;
                    break;
                case 0x2C4:
                    value = CFG_CTRLUPD_TRIG;
                    break;
                case 0x2C8:
                    value = CFG_CTRLUPD_START_DELAY;
                    break;
                case 0x2CC:
                    value = CFG_DFI_T_CTRLUPD_MAX;
                    break;
                case 0x2D0:
                    value = CFG_CTRLR_BUSY_SEL;
                    break;
                case 0x2D4:
                    value = CFG_CTRLR_BUSY_VALUE;
                    break;
                case 0x2D8:
                    value = CFG_CTRLR_BUSY_TURN_OFF_DELAY;
                    break;
                case 0x2DC:
                    value = CFG_CTRLR_BUSY_SLOW_RESTART_WINDOW;
                    break;
                case 0x2E0:
                    value = CFG_CTRLR_BUSY_RESTART_HOLDOFF;
                    break;
                case 0x2E4:
                    value = CFG_PARITY_RDIMM_DELAY;
                    break;
                case 0x2E8:
                    value = CFG_CTRLR_BUSY_ENABLE;
                    break;
                case 0x2EC:
                    value = CFG_ASYNC_ODT;
                    break;
                case 0x2F0:
                    value = CFG_ZQ_CAL_DURATION;
                    break;
                case 0x2F4:
                    value = CFG_MRRI;
                    break;
                case 0x2F8:
                    value = INIT_ODT_FORCE_EN;
                    break;
                case 0x2FC:
                    value = INIT_ODT_FORCE_RANK;
                    break;
                case 0x300:
                    value = CFG_PHYUPD_ACK_DELAY;
                    break;
                case 0x304:
                    value = CFG_MIRROR_X16_BG0_BG1;
                    break;
                case 0x308:
                    value = INIT_PDA_MR_W_REQ;
                    break;
                case 0x30C:
                    value = INIT_PDA_NIBBLE_SELECT;
                    break;
                case 0x310:
                    value = CFG_DRAM_CLK_DISABLE_IN_SELF_REFRESH;
                    break;
                case 0x314:
                    value = CFG_CKSRE;
                    break;
                case 0x318:
                    value = CFG_CKSRX;
                    break;
                case 0x31C:
                    value = CFG_RCD_STAB;
                    break;
                case 0x320:
                    value = CFG_DFI_T_CTRL_DELAY;
                    break;
                case 0x324:
                    value = CFG_DFI_T_DRAM_CLK_ENABLE;
                    break;
                case 0x328:
                    value = CFG_IDLE_TIME_TO_SELF_REFRESH;
                    break;
                case 0x32C:
                    value = CFG_IDLE_TIME_TO_POWER_DOWN;
                    break;
                case 0x330:
                    value = CFG_BURST_RW_REFRESH_HOLDOFF;
                    break;
                case 0x334:
                    value = INIT_REFRESH_COUNT;
                    break;
                case 0x384:
                    value = CFG_BG_INTERLEAVE;
                    break;
                case 0x3FC:
                    value = CFG_REFRESH_DURING_PHY_TRAINING;
                    break;
                case 0x400:
                    value = MT_EN;
                    break;
                case 0x404:
                    value = MT_EN_SINGLE;
                    break;
                case 0x408:
                    value = MT_STOP_ON_ERROR;
                    break;
                case 0x40C:
                    value = MT_RD_ONLY;
                    break;
                case 0x410:
                    value = MT_WR_ONLY;
                    break;
                case 0x414:
                    value = MT_DATA_PATTERN;
                    break;
                case 0x418:
                    value = MT_ADDR_PATTERN;
                    break;
                case 0x41C:
                    value = MT_DATA_INVERT;
                    break;
                case 0x420:
                    value = MT_ADDR_BITS;
                    break;
                case 0x424:
                    value = MT_ERROR_STS;
                    break;
                case 0x428:
                    value = MT_DONE_ACK;
                    break;
                case 0x4B4:
                    value = MT_START_ADDR_0;
                    break;
                case 0x4B8:
                    value = MT_START_ADDR_1;
                    break;
                case 0x4BC:
                    value = MT_ERROR_MASK_0;
                    break;
                case 0x4C0:
                    value = MT_ERROR_MASK_1;
                    break;
                case 0x4C4:
                    value = MT_ERROR_MASK_2;
                    break;
                case 0x4C8:
                    value = MT_ERROR_MASK_3;
                    break;
                case 0x4CC:
                    value = MT_ERROR_MASK_4;
                    break;
                case 0x670:
                    value = MT_USER_DATA_PATTERN;
                    break;
                case 0x67C:
                    value = MT_ALG_AUTO_PCH;
                    break;
                case 0xC00:
                    value = CFG_STARVE_TIMEOUT_P0;
                    break;
                case 0xC04:
                    value = CFG_STARVE_TIMEOUT_P1;
                    break;
                case 0xC08:
                    value = CFG_STARVE_TIMEOUT_P2;
                    break;
                case 0xC0C:
                    value = CFG_STARVE_TIMEOUT_P3;
                    break;
                case 0xC10:
                    value = CFG_STARVE_TIMEOUT_P4;
                    break;
                case 0xC14:
                    value = CFG_STARVE_TIMEOUT_P5;
                    break;
                case 0xC18:
                    value = CFG_STARVE_TIMEOUT_P6;
                    break;
                case 0xC1C:
                    value = CFG_STARVE_TIMEOUT_P7;
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
                    CTRLR_SOFT_RESET_N =  value;
                    break;
                case 0x008:
                    CFG_LOOKAHEAD_PCH =  value;
                    break;
                case 0x00C:
                    CFG_LOOKAHEAD_ACT =  value;
                    break;
                case 0x010:
                    INIT_AUTOINIT_DISABLE =  value;
                    break;
                case 0x014:
                    INIT_FORCE_RESET =  value;
                    break;
                case 0x018:
                    INIT_GEARDOWN_EN =  value;
                    break;
                case 0x01C:
                    INIT_DISABLE_CKE =  value;
                    break;
                case 0x020:
                    INIT_CS =  value;
                    break;
                case 0x024:
                    INIT_PRECHARGE_ALL =  value;
                    break;
                case 0x028:
                    INIT_REFRESH =  value;
                    break;
                case 0x02C:
                    INIT_ZQ_CAL_REQ =  value;
                    break;
                case 0x030:
                    INIT_ACK =  value;
                    break;
                case 0x034:
                    CFG_BL =  value;
                    break;
                case 0x038:
                    CTRLR_INIT =  value;
                    break;
                case 0x03C:
                    CTRLR_INIT_DONE =  value;
                    break;
                case 0x040:
                    CFG_AUTO_REF_EN =  value;
                    break;
                case 0x044:
                    CFG_RAS =  value;
                    break;
                case 0x048:
                    CFG_RCD =  value;
                    break;
                case 0x04C:
                    CFG_RRD =  value;
                    break;
                case 0x050:
                    CFG_RP =  value;
                    break;
                case 0x054:
                    CFG_RC =  value;
                    break;
                case 0x058:
                    CFG_FAW =  value;
                    break;
                case 0x05C:
                    CFG_RFC =  value;
                    break;
                case 0x060:
                    CFG_RTP =  value;
                    break;
                case 0x064:
                    CFG_WR =  value;
                    break;
                case 0x068:
                    CFG_WTR =  value;
                    break;
                case 0x070:
                    CFG_PASR =  value;
                    break;
                case 0x074:
                    CFG_XP =  value;
                    break;
                case 0x078:
                    CFG_XSR =  value;
                    break;
                case 0x080:
                    CFG_CL =  value;
                    break;
                case 0x088:
                    CFG_READ_TO_WRITE =  value;
                    break;
                case 0x08C:
                    CFG_WRITE_TO_WRITE =  value;
                    break;
                case 0x090:
                    CFG_READ_TO_READ =  value;
                    break;
                case 0x094:
                    CFG_WRITE_TO_READ =  value;
                    break;
                case 0x098:
                    CFG_READ_TO_WRITE_ODT =  value;
                    break;
                case 0x09C:
                    CFG_WRITE_TO_WRITE_ODT =  value;
                    break;
                case 0x0A0:
                    CFG_READ_TO_READ_ODT =  value;
                    break;
                case 0x0A4:
                    CFG_WRITE_TO_READ_ODT =  value;
                    break;
                case 0x0A8:
                    CFG_MIN_READ_IDLE =  value;
                    break;
                case 0x0AC:
                    CFG_MRD =  value;
                    break;
                case 0x0B0:
                    CFG_BT =  value;
                    break;
                case 0x0B4:
                    CFG_DS =  value;
                    break;
                case 0x0B8:
                    CFG_QOFF =  value;
                    break;
                case 0x0C4:
                    CFG_RTT =  value;
                    break;
                case 0x0C8:
                    CFG_DLL_DISABLE =  value;
                    break;
                case 0x0CC:
                    CFG_REF_PER =  value;
                    break;
                case 0x0D0:
                    CFG_STARTUP_DELAY =  value;
                    break;
                case 0x0D4:
                    CFG_MEM_COLBITS =  value;
                    break;
                case 0x0D8:
                    CFG_MEM_ROWBITS =  value;
                    break;
                case 0x0DC:
                    CFG_MEM_BANKBITS =  value;
                    break;
                case 0x0E0:
                    CFG_ODT_RD_MAP_CS0 =  value;
                    break;
                case 0x0E4:
                    CFG_ODT_RD_MAP_CS1 =  value;
                    break;
                case 0x0E8:
                    CFG_ODT_RD_MAP_CS2 =  value;
                    break;
                case 0x0EC:
                    CFG_ODT_RD_MAP_CS3 =  value;
                    break;
                case 0x0F0:
                    CFG_ODT_RD_MAP_CS4 =  value;
                    break;
                case 0x0F4:
                    CFG_ODT_RD_MAP_CS5 =  value;
                    break;
                case 0x0F8:
                    CFG_ODT_RD_MAP_CS6 =  value;
                    break;
                case 0x0FC:
                    CFG_ODT_RD_MAP_CS7 =  value;
                    break;
                case 0x120:
                    CFG_ODT_WR_MAP_CS0 =  value;
                    break;
                case 0x124:
                    CFG_ODT_WR_MAP_CS1 =  value;
                    break;
                case 0x128:
                    CFG_ODT_WR_MAP_CS2 =  value;
                    break;
                case 0x12C:
                    CFG_ODT_WR_MAP_CS3 =  value;
                    break;
                case 0x130:
                    CFG_ODT_WR_MAP_CS4 =  value;
                    break;
                case 0x134:
                    CFG_ODT_WR_MAP_CS5 =  value;
                    break;
                case 0x138:
                    CFG_ODT_WR_MAP_CS6 =  value;
                    break;
                case 0x13C:
                    CFG_ODT_WR_MAP_CS7 =  value;
                    break;
                case 0x160:
                    CFG_ODT_RD_TURN_ON =  value;
                    break;
                case 0x164:
                    CFG_ODT_WR_TURN_ON =  value;
                    break;
                case 0x168:
                    CFG_ODT_RD_TURN_OFF =  value;
                    break;
                case 0x16C:
                    CFG_ODT_WR_TURN_OFF =  value;
                    break;
                case 0x178:
                    CFG_EMR3 =  value;
                    break;
                case 0x17C:
                    CFG_TWO_T =  value;
                    break;
                case 0x180:
                    CFG_TWO_T_SEL_CYCLE =  value;
                    break;
                case 0x184:
                    CFG_REGDIMM =  value;
                    break;
                case 0x188:
                    CFG_MOD =  value;
                    break;
                case 0x18C:
                    CFG_XS =  value;
                    break;
                case 0x190:
                    CFG_XSDLL =  value;
                    break;
                case 0x194:
                    CFG_XPR =  value;
                    break;
                case 0x198:
                    CFG_AL_MODE =  value;
                    break;
                case 0x19C:
                    CFG_CWL =  value;
                    break;
                case 0x1A0:
                    CFG_BL_MODE =  value;
                    break;
                case 0x1A4:
                    CFG_TDQS =  value;
                    break;
                case 0x1A8:
                    CFG_RTT_WR =  value;
                    break;
                case 0x1AC:
                    CFG_LP_ASR =  value;
                    break;
                case 0x1B0:
                    CFG_AUTO_SR =  value;
                    break;
                case 0x1B4:
                    CFG_SRT =  value;
                    break;
                case 0x1B8:
                    CFG_ADDR_MIRROR =  value;
                    break;
                case 0x1BC:
                    CFG_ZQ_CAL_TYPE =  value;
                    break;
                case 0x1C0:
                    CFG_ZQ_CAL_PER =  value;
                    break;
                case 0x1C4:
                    CFG_AUTO_ZQ_CAL_EN =  value;
                    break;
                case 0x1C8:
                    CFG_MEMORY_TYPE =  value;
                    break;
                case 0x1CC:
                    CFG_ONLY_SRANK_CMDS =  value;
                    break;
                case 0x1D0:
                    CFG_NUM_RANKS =  value;
                    break;
                case 0x1D4:
                    CFG_QUAD_RANK =  value;
                    break;
                case 0x1DC:
                    CFG_EARLY_RANK_TO_WR_START =  value;
                    break;
                case 0x1E0:
                    CFG_EARLY_RANK_TO_RD_START =  value;
                    break;
                case 0x1E4:
                    CFG_PASR_BANK =  value;
                    break;
                case 0x1E8:
                    CFG_PASR_SEG =  value;
                    break;
                case 0x1EC:
                    INIT_MRR_MODE =  value;
                    break;
                case 0x1F0:
                    INIT_MR_W_REQ =  value;
                    break;
                case 0x1F4:
                    INIT_MR_ADDR =  value;
                    break;
                case 0x1F8:
                    INIT_MR_WR_DATA =  value;
                    break;
                case 0x1FC:
                    INIT_MR_WR_MASK =  value;
                    break;
                case 0x200:
                    INIT_NOP =  value;
                    break;
                case 0x204:
                    CFG_INIT_DURATION =  value;
                    break;
                case 0x208:
                    CFG_ZQINIT_CAL_DURATION =  value;
                    break;
                case 0x20C:
                    CFG_ZQ_CAL_L_DURATION =  value;
                    break;
                case 0x210:
                    CFG_ZQ_CAL_S_DURATION =  value;
                    break;
                case 0x214:
                    CFG_ZQ_CAL_R_DURATION =  value;
                    break;
                case 0x218:
                    CFG_MRR =  value;
                    break;
                case 0x21C:
                    CFG_MRW =  value;
                    break;
                case 0x220:
                    CFG_ODT_POWERDOWN =  value;
                    break;
                case 0x224:
                    CFG_WL =  value;
                    break;
                case 0x228:
                    CFG_RL =  value;
                    break;
                case 0x22C:
                    CFG_CAL_READ_PERIOD =  value;
                    break;
                case 0x230:
                    CFG_NUM_CAL_READS =  value;
                    break;
                case 0x234:
                    INIT_SELF_REFRESH =  value;
                    break;
                case 0x238:
                    INIT_SELF_REFRESH_STATUS =  value;
                    break;
                case 0x23C:
                    INIT_POWER_DOWN =  value;
                    break;
                case 0x240:
                    INIT_POWER_DOWN_STATUS =  value;
                    break;
                case 0x244:
                    INIT_FORCE_WRITE =  value;
                    break;
                case 0x248:
                    INIT_FORCE_WRITE_CS =  value;
                    break;
                case 0x24C:
                    CFG_CTRLR_INIT_DISABLE =  value;
                    break;
                case 0x250:
                    CTRLR_READY =  value;
                    break;
                case 0x254:
                    INIT_RDIMM_READY =  value;
                    break;
                case 0x258:
                    INIT_RDIMM_COMPLETE =  value;
                    break;
                case 0x25C:
                    CFG_RDIMM_LAT =  value;
                    break;
                case 0x260:
                    CFG_RDIMM_BSIDE_INVERT =  value;
                    break;
                case 0x264:
                    CFG_LRDIMM =  value;
                    break;
                case 0x268:
                    INIT_MEMORY_RESET_MASK =  value;
                    break;
                case 0x26C:
                    CFG_RD_PREAMB_TOGGLE =  value;
                    break;
                case 0x270:
                    CFG_RD_POSTAMBLE =  value;
                    break;
                case 0x274:
                    CFG_PU_CAL =  value;
                    break;
                case 0x278:
                    CFG_DQ_ODT =  value;
                    break;
                case 0x27C:
                    CFG_CA_ODT =  value;
                    break;
                case 0x280:
                    CFG_ZQLATCH_DURATION =  value;
                    break;
                case 0x284:
                    INIT_CAL_SELECT =  value;
                    break;
                case 0x288:
                    INIT_CAL_L_R_REQ =  value;
                    break;
                case 0x28C:
                    INIT_CAL_L_B_SIZE =  value;
                    break;
                case 0x290:
                    INIT_CAL_L_R_ACK =  value;
                    break;
                case 0x294:
                    INIT_CAL_L_READ_COMPLETE =  value;
                    break;
                case 0x2A0:
                    INIT_RWFIFO =  value;
                    break;
                case 0x2A4:
                    INIT_RD_DQCAL =  value;
                    break;
                case 0x2A8:
                    INIT_START_DQSOSC =  value;
                    break;
                case 0x2AC:
                    INIT_STOP_DQSOSC =  value;
                    break;
                case 0x2B0:
                    INIT_ZQ_CAL_START =  value;
                    break;
                case 0x2B4:
                    CFG_WR_POSTAMBLE =  value;
                    break;
                case 0x2BC:
                    INIT_CAL_L_ADDR_0 =  value;
                    break;
                case 0x2C0:
                    INIT_CAL_L_ADDR_1 =  value;
                    break;
                case 0x2C4:
                    CFG_CTRLUPD_TRIG =  value;
                    break;
                case 0x2C8:
                    CFG_CTRLUPD_START_DELAY =  value;
                    break;
                case 0x2CC:
                    CFG_DFI_T_CTRLUPD_MAX =  value;
                    break;
                case 0x2D0:
                    CFG_CTRLR_BUSY_SEL =  value;
                    break;
                case 0x2D4:
                    CFG_CTRLR_BUSY_VALUE =  value;
                    break;
                case 0x2D8:
                    CFG_CTRLR_BUSY_TURN_OFF_DELAY =  value;
                    break;
                case 0x2DC:
                    CFG_CTRLR_BUSY_SLOW_RESTART_WINDOW =  value;
                    break;
                case 0x2E0:
                    CFG_CTRLR_BUSY_RESTART_HOLDOFF =  value;
                    break;
                case 0x2E4:
                    CFG_PARITY_RDIMM_DELAY =  value;
                    break;
                case 0x2E8:
                    CFG_CTRLR_BUSY_ENABLE =  value;
                    break;
                case 0x2EC:
                    CFG_ASYNC_ODT =  value;
                    break;
                case 0x2F0:
                    CFG_ZQ_CAL_DURATION =  value;
                    break;
                case 0x2F4:
                    CFG_MRRI =  value;
                    break;
                case 0x2F8:
                    INIT_ODT_FORCE_EN =  value;
                    break;
                case 0x2FC:
                    INIT_ODT_FORCE_RANK =  value;
                    break;
                case 0x300:
                    CFG_PHYUPD_ACK_DELAY =  value;
                    break;
                case 0x304:
                    CFG_MIRROR_X16_BG0_BG1 =  value;
                    break;
                case 0x308:
                    INIT_PDA_MR_W_REQ =  value;
                    break;
                case 0x30C:
                    INIT_PDA_NIBBLE_SELECT =  value;
                    break;
                case 0x310:
                    CFG_DRAM_CLK_DISABLE_IN_SELF_REFRESH =  value;
                    break;
                case 0x314:
                    CFG_CKSRE =  value;
                    break;
                case 0x318:
                    CFG_CKSRX =  value;
                    break;
                case 0x31C:
                    CFG_RCD_STAB =  value;
                    break;
                case 0x320:
                    CFG_DFI_T_CTRL_DELAY =  value;
                    break;
                case 0x324:
                    CFG_DFI_T_DRAM_CLK_ENABLE =  value;
                    break;
                case 0x328:
                    CFG_IDLE_TIME_TO_SELF_REFRESH =  value;
                    break;
                case 0x32C:
                    CFG_IDLE_TIME_TO_POWER_DOWN =  value;
                    break;
                case 0x330:
                    CFG_BURST_RW_REFRESH_HOLDOFF =  value;
                    break;
                case 0x334:
                    INIT_REFRESH_COUNT =  value;
                    break;
                case 0x384:
                    CFG_BG_INTERLEAVE =  value;
                    break;
                case 0x3FC:
                    CFG_REFRESH_DURING_PHY_TRAINING =  value;
                    break;
                case 0x400:
                    MT_EN =  value;
                    break;
                case 0x404:
                    MT_EN_SINGLE =  value;
                    break;
                case 0x408:
                    MT_STOP_ON_ERROR =  value;
                    break;
                case 0x40C:
                    MT_RD_ONLY =  value;
                    break;
                case 0x410:
                    MT_WR_ONLY =  value;
                    break;
                case 0x414:
                    MT_DATA_PATTERN =  value;
                    break;
                case 0x418:
                    MT_ADDR_PATTERN =  value;
                    break;
                case 0x41C:
                    MT_DATA_INVERT =  value;
                    break;
                case 0x420:
                    MT_ADDR_BITS =  value;
                    break;
                case 0x424:
                    MT_ERROR_STS =  value;
                    break;
                case 0x428:
                    MT_DONE_ACK =  value;
                    break;
                case 0x4B4:
                    MT_START_ADDR_0 =  value;
                    break;
                case 0x4B8:
                    MT_START_ADDR_1 =  value;
                    break;
                case 0x4BC:
                    MT_ERROR_MASK_0 =  value;
                    break;
                case 0x4C0:
                    MT_ERROR_MASK_1 =  value;
                    break;
                case 0x4C4:
                    MT_ERROR_MASK_2 =  value;
                    break;
                case 0x4C8:
                    MT_ERROR_MASK_3 =  value;
                    break;
                case 0x4CC:
                    MT_ERROR_MASK_4 =  value;
                    break;
                case 0x670:
                    MT_USER_DATA_PATTERN =  value;
                    break;
                case 0x67C:
                    MT_ALG_AUTO_PCH =  value;
                    break;
                case 0xC00:
                    CFG_STARVE_TIMEOUT_P0 =  value;
                    break;
                case 0xC04:
                    CFG_STARVE_TIMEOUT_P1 =  value;
                    break;
                case 0xC08:
                    CFG_STARVE_TIMEOUT_P2 =  value;
                    break;
                case 0xC0C:
                    CFG_STARVE_TIMEOUT_P3 =  value;
                    break;
                case 0xC10:
                    CFG_STARVE_TIMEOUT_P4 =  value;
                    break;
                case 0xC14:
                    CFG_STARVE_TIMEOUT_P5 =  value;
                    break;
                case 0xC18:
                    CFG_STARVE_TIMEOUT_P6 =  value;
                    break;
                case 0xC1C:
                    CFG_STARVE_TIMEOUT_P7 =  value;
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


