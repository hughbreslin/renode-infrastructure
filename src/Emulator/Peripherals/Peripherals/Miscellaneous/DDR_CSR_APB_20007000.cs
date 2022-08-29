using Antmicro.Renode.Peripherals.Bus;
using Antmicro.Renode.Logging;

namespace Antmicro.Renode.Peripherals.Miscellaneous
{
    public class DDR_CSR_APB_20007000 : IDoubleWordPeripheral, IKnownSize
    {
        private ulong SOFT_RESET_DDR_PHY = 0x00000000;
        private ulong DDRPHY_MODE = 0x00000002;
        private ulong DDRPHY_STARTUP = 0x00200000;
        private ulong SPARE_0 = 0x00000000;
        private ulong SOFT_RESET_MAIN_PLL = 0x00000000;
        private ulong PLL_CTRL_MAIN = 0x000010BE;
        private ulong PLL_REF_FB_MAIN = 0x00000100;
        private ulong PLL_FRACN_MAIN = 0x00000000;
        private ulong PLL_DIV_0_1_MAIN = 0x08000200;
        private ulong PLL_DIV_2_3_MAIN = 0x14000800;
        private ulong PLL_CTRL2_MAIN = 0x00001018;
        private ulong PLL_CAL_MAIN = 0x00000008;
        private ulong PLL_PHADJ_MAIN = 0x00000001;
        private ulong SSCG_REG_0_MAIN = 0x00000000;
        private ulong SSCG_REG_1_MAIN = 0x0000000A;
        private ulong SSCG_REG_2_MAIN = 0x00000030;
        private ulong SSCG_REG_3_MAIN = 0x00000001;
        private ulong RPC_RESET_MAIN_PLL = 0x00000000;
        private ulong SOFT_RESET_IOSCB_PLL = 0x00000000;
        private ulong PLL_CTRL_IOSCB = 0x000010BE;
        private ulong PLL_REF_FB_IOSCB = 0x00000100;
        private ulong PLL_FRACN_IOSCB = 0x00000000;
        private ulong PLL_DIV_0_1_IOSCB = 0x02000100;
        private ulong PLL_DIV_2_3_IOSCB = 0x01000100;
        private ulong PLL_CTRL2_IOSCB = 0x00001018;
        private ulong PLL_CAL_IOSCB = 0x00000008;
        private ulong PLL_PHADJ_IOSCB = 0x00004001;
        private ulong SSCG_REG_0_IOSCB = 0x00000000;
        private ulong SSCG_REG_1_IOSCB = 0x0000000A;
        private ulong SSCG_REG_2_IOSCB = 0x00000020;
        private ulong SSCG_REG_3_IOSCB = 0x00000001;
        private ulong RPC_RESET_IOSCB = 0x00000000;
        private ulong SOFT_RESET_BANK_CTRL = 0x00000000;
        private ulong DPC_BITS = 0x0005C5C3;
        private ulong BANK_STATUS = 0x00000000;
        private ulong RPC_RESET_BANK_CTRL = 0x00000000;
        private ulong SOFT_RESET_IOCALIB = 0x00000000;
        private ulong IOC_REG0 = 0x00008000;
        private ulong IOC_REG1 = 0x00000000;
        private ulong IOC_REG2 = 0x00000000;
        private ulong IOC_REG3 = 0x00000000;
        private ulong IOC_REG4 = 0x00000000;
        private ulong IOC_REG5 = 0x00000000;
        private ulong IOC_REG6 = 0x00000005;
        private ulong RPC_RESET_IOCALIB = 0x00000000;
        private ulong RPC_calib = 0x00000000;
        private ulong SOFT_RESET_CFM = 0x00000000;
        private ulong BCLKMUX = 0x00000208;
        private ulong PLL_CKMUX = 0x00000005;
        private ulong MSSCLKMUX = 0x00000000;
        private ulong SPARE0 = 0x00000000;
        private ulong FMETER_ADDR = 0x00000000;
        private ulong FMETER_DATAW = 0x00000000;
        private ulong FMETER_DATAR = 0x00000000;
        private ulong TEST_CTRL = 0x00000000;
        private ulong RPC_RESET_CFM = 0x00000000;
        private ulong SOFT_RESET_DECODER_DRIVER = 0x00000000;
        private ulong RPC1_DRV = 0x00000000;
        private ulong RPC2_DRV = 0x00000000;
        private ulong RPC3_DRV = 0x00000000;
        private ulong RPC4_DRV = 0x00000000;
        private ulong SOFT_RESET_DECODER_ODT = 0x00000000;
        private ulong RPC1_ODT = 0x00000000;
        private ulong RPC2_ODT = 0x00000000;
        private ulong RPC3_ODT = 0x00000000;
        private ulong RPC4_ODT = 0x00000000;
        private ulong RPC5_ODT = 0x00000000;
        private ulong RPC6_ODT = 0x00000000;
        private ulong RPC7_ODT = 0x00000000;
        private ulong RPC8_ODT = 0x00000000;
        private ulong RPC9_ODT = 0x00000000;
        private ulong RPC10_ODT = 0x00000000;
        private ulong RPC11_ODT = 0x00000000;
        private ulong SOFT_RESET_DECODER_IO = 0x00000000;
        private ulong OVRT1 = 0x00000000;
        private ulong OVRT2 = 0x00000000;
        private ulong OVRT3 = 0x00000000;
        private ulong OVRT4 = 0x00000000;
        private ulong OVRT5 = 0x00000000;
        private ulong OVRT6 = 0x00000000;
        private ulong OVRT7 = 0x00000000;
        private ulong OVRT8 = 0x00000000;
        private ulong OVRT9 = 0x00000000;
        private ulong OVRT10 = 0x00000000;
        private ulong OVRT11 = 0x00000000;
        private ulong OVRT12 = 0x00000000;
        private ulong OVRT13 = 0x00000000;
        private ulong OVRT14 = 0x00000000;
        private ulong OVRT15 = 0x00000000;
        private ulong OVRT16 = 0x00000000;
        private ulong RPC17 = 0x00000000;
        private ulong RPC18 = 0x00000000;
        private ulong RPC19 = 0x00000000;
        private ulong RPC20 = 0x00000000;
        private ulong RPC21 = 0x00000000;
        private ulong RPC22 = 0x00000000;
        private ulong RPC23 = 0x00000000;
        private ulong RPC24 = 0x00000000;
        private ulong RPC25 = 0x00000000;
        private ulong RPC26 = 0x00000000;
        private ulong RPC27 = 0x00000000;
        private ulong RPC28 = 0x00000000;
        private ulong RPC29 = 0x00000000;
        private ulong RPC30 = 0x00000000;
        private ulong RPC31 = 0x00000000;
        private ulong RPC32 = 0x00000000;
        private ulong RPC33 = 0x00000000;
        private ulong RPC34 = 0x00000000;
        private ulong RPC35 = 0x00000000;
        private ulong RPC36 = 0x00000000;
        private ulong RPC37 = 0x00000000;
        private ulong RPC38 = 0x00000000;
        private ulong RPC39 = 0x00000000;
        private ulong RPC40 = 0x00000000;
        private ulong RPC41 = 0x00000000;
        private ulong RPC42 = 0x00000000;
        private ulong RPC43 = 0x00000000;
        private ulong RPC44 = 0x00000000;
        private ulong RPC45 = 0x00000000;
        private ulong RPC46 = 0x00000000;
        private ulong RPC47 = 0x00000000;
        private ulong RPC48 = 0x00000000;
        private ulong RPC49 = 0x00000000;
        private ulong RPC50 = 0x00000000;
        private ulong RPC51 = 0x00000000;
        private ulong RPC52 = 0x00000000;
        private ulong RPC53 = 0x00000000;
        private ulong RPC54 = 0x00000000;
        private ulong RPC55 = 0x00000000;
        private ulong RPC56 = 0x00000000;
        private ulong RPC57 = 0x00000000;
        private ulong RPC58 = 0x00000000;
        private ulong RPC59 = 0x00000000;
        private ulong RPC60 = 0x00000000;
        private ulong RPC61 = 0x00000000;
        private ulong RPC62 = 0x00000000;
        private ulong RPC63 = 0x00000000;
        private ulong RPC64 = 0x00000000;
        private ulong RPC65 = 0x00000000;
        private ulong RPC66 = 0x00000000;
        private ulong RPC67 = 0x00000000;
        private ulong RPC68 = 0x00000000;
        private ulong RPC69 = 0x00000000;
        private ulong RPC70 = 0x00000000;
        private ulong RPC71 = 0x00000000;
        private ulong RPC72 = 0x00000000;
        private ulong RPC73 = 0x00000000;
        private ulong RPC74 = 0x00000000;
        private ulong RPC75 = 0x00000000;
        private ulong RPC76 = 0x00000000;
        private ulong RPC77 = 0x00000000;
        private ulong RPC78 = 0x00000000;
        private ulong RPC79 = 0x00000000;
        private ulong RPC80 = 0x00000000;
        private ulong RPC81 = 0x00000000;
        private ulong RPC82 = 0x00000000;
        private ulong RPC83 = 0x00000000;
        private ulong RPC84 = 0x00000000;
        private ulong RPC85 = 0x00000000;
        private ulong RPC86 = 0x00000000;
        private ulong RPC87 = 0x00000000;
        private ulong RPC88 = 0x00000000;
        private ulong RPC89 = 0x00000000;
        private ulong RPC90 = 0x00000000;
        private ulong RPC91 = 0x00000000;
        private ulong RPC92 = 0x00000000;
        private ulong RPC93 = 0x00000000;
        private ulong RPC94 = 0x00000000;
        private ulong RPC95 = 0x00000000;
        private ulong RPC96 = 0x00000000;
        private ulong RPC97 = 0x00000000;
        private ulong RPC98 = 0x00000000;
        private ulong RPC99 = 0x00000000;
        private ulong RPC100 = 0x00000000;
        private ulong RPC101 = 0x00000000;
        private ulong RPC102 = 0x00000000;
        private ulong RPC103 = 0x00000000;
        private ulong RPC104 = 0x00000000;
        private ulong RPC105 = 0x00000000;
        private ulong RPC106 = 0x00000000;
        private ulong RPC107 = 0x00000000;
        private ulong RPC108 = 0x00000000;
        private ulong RPC109 = 0x00000000;
        private ulong RPC110 = 0x00000000;
        private ulong RPC111 = 0x00000000;
        private ulong RPC112 = 0x00000000;
        private ulong RPC113 = 0x00000000;
        private ulong RPC114 = 0x00000000;
        private ulong RPC115 = 0x00000000;
        private ulong RPC116 = 0x00000000;
        private ulong RPC117 = 0x00000000;
        private ulong RPC118 = 0x00000000;
        private ulong RPC119 = 0x00000000;
        private ulong RPC120 = 0x00000000;
        private ulong RPC121 = 0x00000000;
        private ulong RPC122 = 0x00000000;
        private ulong RPC123 = 0x00000000;
        private ulong RPC124 = 0x00000000;
        private ulong RPC125 = 0x00000000;
        private ulong RPC126 = 0x00000000;
        private ulong RPC127 = 0x00000000;
        private ulong RPC128 = 0x00000000;
        private ulong RPC129 = 0x00000000;
        private ulong RPC130 = 0x00000000;
        private ulong RPC131 = 0x00000000;
        private ulong RPC132 = 0x00000000;
        private ulong RPC133 = 0x00000000;
        private ulong RPC134 = 0x00000000;
        private ulong RPC135 = 0x00000000;
        private ulong RPC136 = 0x00000000;
        private ulong RPC137 = 0x00000000;
        private ulong RPC138 = 0x00000000;
        private ulong RPC139 = 0x00000000;
        private ulong RPC140 = 0x00000000;
        private ulong RPC141 = 0x00000000;
        private ulong RPC142 = 0x00000000;
        private ulong RPC143 = 0x00000000;
        private ulong RPC144 = 0x00000000;
        private ulong RPC145 = 0x00000000;
        private ulong RPC146 = 0x00000000;
        private ulong RPC147 = 0x00000000;
        private ulong RPC148 = 0x00000000;
        private ulong RPC149 = 0x00000000;
        private ulong RPC150 = 0x00000000;
        private ulong RPC151 = 0x00000000;
        private ulong RPC152 = 0x00000000;
        private ulong RPC153 = 0x00000000;
        private ulong RPC154 = 0x00000000;
        private ulong RPC155 = 0x00000000;
        private ulong RPC156 = 0x00000000;
        private ulong RPC157 = 0x00000000;
        private ulong RPC158 = 0x00000000;
        private ulong RPC159 = 0x00000000;
        private ulong RPC160 = 0x00000000;
        private ulong RPC161 = 0x00000000;
        private ulong RPC162 = 0x00000000;
        private ulong RPC163 = 0x00000000;
        private ulong RPC164 = 0x00000000;
        private ulong RPC165 = 0x00000000;
        private ulong RPC166 = 0x00000000;
        private ulong RPC167 = 0x00000000;
        private ulong RPC168 = 0x00000000;
        private ulong RPC169 = 0x00000000;
        private ulong RPC170 = 0x00000000;
        private ulong RPC171 = 0x00000000;
        private ulong RPC172 = 0x00000000;
        private ulong RPC173 = 0x00000000;
        private ulong RPC174 = 0x00000000;
        private ulong RPC175 = 0x00000000;
        private ulong RPC176 = 0x00000000;
        private ulong RPC177 = 0x00000000;
        private ulong RPC178 = 0x00000000;
        private ulong RPC179 = 0x00000000;
        private ulong RPC180 = 0x00000000;
        private ulong RPC181 = 0x00000000;
        private ulong RPC182 = 0x00000000;
        private ulong RPC183 = 0x00000000;
        private ulong RPC184 = 0x00000000;
        private ulong RPC185 = 0x00000000;
        private ulong RPC186 = 0x00000000;
        private ulong RPC187 = 0x00000000;
        private ulong RPC188 = 0x00000000;
        private ulong RPC189 = 0x00000000;
        private ulong RPC190 = 0x00000000;
        private ulong RPC191 = 0x00000000;
        private ulong RPC192 = 0x00000000;
        private ulong RPC193 = 0x00000000;
        private ulong RPC194 = 0x00000000;
        private ulong RPC195 = 0x00000000;
        private ulong RPC196 = 0x00000000;
        private ulong RPC197 = 0x00000000;
        private ulong RPC198 = 0x00000000;
        private ulong RPC199 = 0x00000000;
        private ulong RPC200 = 0x00000000;
        private ulong RPC201 = 0x00000000;
        private ulong RPC202 = 0x00000000;
        private ulong RPC203 = 0x00000000;
        private ulong RPC204 = 0x00000000;
        private ulong RPC205 = 0x00000000;
        private ulong RPC206 = 0x00000000;
        private ulong RPC207 = 0x00000000;
        private ulong RPC208 = 0x00000000;
        private ulong RPC209 = 0x00000000;
        private ulong RPC210 = 0x00000000;
        private ulong RPC211 = 0x00000000;
        private ulong RPC212 = 0x00000000;
        private ulong RPC213 = 0x00000000;
        private ulong RPC214 = 0x00000000;
        private ulong RPC215 = 0x00000000;
        private ulong RPC216 = 0x00000000;
        private ulong RPC217 = 0x00000000;
        private ulong RPC218 = 0x00000000;
        private ulong RPC219 = 0x00000000;
        private ulong RPC220 = 0x00000000;
        private ulong RPC221 = 0x00000000;
        private ulong RPC222 = 0x00000000;
        private ulong RPC223 = 0x00000000;
        private ulong RPC224 = 0x00000000;
        private ulong RPC225 = 0x00000000;
        private ulong RPC226 = 0x00000000;
        private ulong RPC227 = 0x00000000;
        private ulong RPC228 = 0x00000000;
        private ulong RPC229 = 0x00000000;
        private ulong RPC230 = 0x00000000;
        private ulong RPC231 = 0x00000000;
        private ulong RPC232 = 0x00000000;
        private ulong RPC233 = 0x00000000;
        private ulong RPC234 = 0x00000000;
        private ulong RPC235 = 0x00000000;
        private ulong RPC236 = 0x00000000;
        private ulong RPC237 = 0x00000000;
        private ulong RPC238 = 0x00000000;
        private ulong RPC239 = 0x00000000;
        private ulong RPC240 = 0x00000000;
        private ulong RPC241 = 0x00000000;
        private ulong RPC242 = 0x00000000;
        private ulong RPC243 = 0x00000000;
        private ulong RPC244 = 0x00000000;
        private ulong RPC245 = 0x00000000;
        private ulong RPC246 = 0x00000000;
        private ulong RPC247 = 0x00000000;
        private ulong RPC248 = 0x00000000;
        private ulong RPC249 = 0x00000000;
        private ulong RPC250 = 0x00000000;
        private ulong SPIO251 = 0x00000000;
        private ulong SPIO252 = 0x00000000;
        private ulong SPIO253 = 0x00000000;
        private ulong SOFT_RESET_TIP = 0x00000000;
        private ulong RANK_SELECT = 0x00000000;
        private ulong LANE_SELECT = 0x00000000;
        private ulong TRAINING_SKIP = 0x00000000;
        private ulong TRAINING_START = 0x00000000;
        private ulong TRAINING_STATUS = 0x00000000;
        private ulong TRAINING_RESET = 0x00000000;
        private ulong GT_ERR_COMB = 0x00000000;
        private ulong GT_CLK_SEL = 0x00000000;
        private ulong GT_TXDLY = 0x00000000;
        private ulong GT_STEPS_180 = 0x00000000;
        private ulong GT_STATE = 0x00000000;
        private ulong WL_DELAY_0 = 0x00000000;
        private ulong DQ_DQS_ERR_DONE = 0x00000000;
        private ulong DQDQS_WINDOW = 0x00000000;
        private ulong DQDQS_STATE = 0x00000000;
        private ulong DELTA0 = 0x00000000;
        private ulong DELTA1 = 0x00000000;
        private ulong DQDQS_STATUS0 = 0x00000000;
        private ulong DQDQS_STATUS1 = 0x00000000;
        private ulong DQDQS_STATUS2 = 0x00000000;
        private ulong DQDQS_STATUS3 = 0x00000000;
        private ulong DQDQS_STATUS4 = 0x00000000;
        private ulong DQDQS_STATUS5 = 0x00000000;
        private ulong DQDQS_STATUS6 = 0x00000000;
        private ulong ADDCMD_STATUS0 = 0x00000000;
        private ulong ADDCMD_STATUS1 = 0x00000000;
        private ulong ADDCMD_ANSWER = 0x00000000;
        private ulong BCLKSCLK_ANSWER = 0x00000000;
        private ulong DQDQS_WRCALIB_OFFSET = 0x00000000;
        private ulong EXPERT_MODE_EN = 0x00000000;
        private ulong EXPERT_DLYCNT_MOVE_REG0 = 0x00000000;
        private ulong EXPERT_DLYCNT_MOVE_REG1 = 0x00000000;
        private ulong EXPERT_DLYCNT_DIRECTION_REG0 = 0x00000000;
        private ulong EXPERT_DLYCNT_DIRECTION_REG1 = 0x00000000;
        private ulong EXPERT_DLYCNT_LOAD_REG0 = 0x00000000;
        private ulong EXPERT_DLYCNT_LOAD_REG1 = 0x00000000;
        private ulong EXPERT_DLYCNT_OOR_REG0 = 0x00000000;
        private ulong EXPERT_DLYCNT_OOR_REG1 = 0x00000000;
        private ulong EXPERT_DLYCNT_MV_RD_DLY_REG = 0x00000000;
        private ulong EXPERT_DLYCNT_PAUSE = 0x00000000;
        private ulong EXPERT_PLLCNT = 0x00000004;
        private ulong EXPERT_DQLANE_READBACK = 0x00000000;
        private ulong EXPERT_ADDCMD_LN_READBACK = 0x00000000;
        private ulong EXPERT_READ_GATE_CONTROLS = 0x00000000;
        private ulong EXPERT_DQ_DQS_OPTIMIZATION0 = 0x00000000;
        private ulong EXPERT_DQ_DQS_OPTIMIZATION1 = 0x00000000;
        private ulong EXPERT_WRCALIB = 0x00000000;
        private ulong EXPERT_CALIF = 0x00000000;
        private ulong EXPERT_CALIF_READBACK = 0x00000000;
        private ulong EXPERT_CALIF_READBACK1 = 0x00000000;
        private ulong EXPERT_DFI_STATUS_OVERRIDE_TO_SHIM = 0x00000000;
        private ulong TIP_CFG_PARAMS = 0x00000000;
        private ulong TIP_VREF_PARAM = 0x00000000;
        private ulong LANE_ALIGNMENT_FIFO_CONTROL = 0x00000002;
        private ulong SOFT_RESET_SGMII = 0x00000000;
        private ulong SGMII_MODE = 0x0040E60C;
        private ulong PLL_CNTL = 0x80140101;
        private ulong CH0_CNTL = 0x009C0000;
        private ulong CH1_CNTL = 0x009C0000;
        private ulong RECAL_CNTL = 0x00000008;
        private ulong CLK_CNTL = 0xF0000000;
        private ulong DYN_CNTL = 0x00000400;
        private ulong PVT_STAT = 0x80000000;
        private ulong SPARE_CNTL = 0xFF000000;
        private ulong SPARE_STAT = 0x00000000;

        public uint ReadDoubleWord(long offset)
        {
            ulong value = 0x0u;
            switch(offset)
            {
                case 0x000:
                    value = SOFT_RESET_DDR_PHY;
                    break;
                case 0x004:
                    value = DDRPHY_MODE;
                    break;
                case 0x008:
                    value = DDRPHY_STARTUP;
                    break;
                case 0x00C:
                    value = SPARE_0;
                    break;
                case 0x080:
                    value = SOFT_RESET_MAIN_PLL;
                    break;
                case 0x084:
                    value = PLL_CTRL_MAIN;
                    break;
                case 0x088:
                    value = PLL_REF_FB_MAIN;
                    break;
                case 0x08C:
                    value = PLL_FRACN_MAIN;
                    break;
                case 0x090:
                    value = PLL_DIV_0_1_MAIN;
                    break;
                case 0x094:
                    value = PLL_DIV_2_3_MAIN;
                    break;
                case 0x098:
                    value = PLL_CTRL2_MAIN;
                    break;
                case 0x09C:
                    value = PLL_CAL_MAIN;
                    break;
                case 0x0A0:
                    value = PLL_PHADJ_MAIN;
                    break;
                case 0x0A4:
                    value = SSCG_REG_0_MAIN;
                    break;
                case 0x0A8:
                    value = SSCG_REG_1_MAIN;
                    break;
                case 0x0AC:
                    value = SSCG_REG_2_MAIN;
                    break;
                case 0x0B0:
                    value = SSCG_REG_3_MAIN;
                    break;
                case 0x0B4:
                    value = RPC_RESET_MAIN_PLL;
                    break;
                case 0x100:
                    value = SOFT_RESET_IOSCB_PLL;
                    break;
                case 0x104:
                    value = PLL_CTRL_IOSCB;
                    break;
                case 0x108:
                    value = PLL_REF_FB_IOSCB;
                    break;
                case 0x10C:
                    value = PLL_FRACN_IOSCB;
                    break;
                case 0x110:
                    value = PLL_DIV_0_1_IOSCB;
                    break;
                case 0x114:
                    value = PLL_DIV_2_3_IOSCB;
                    break;
                case 0x118:
                    value = PLL_CTRL2_IOSCB;
                    break;
                case 0x11C:
                    value = PLL_CAL_IOSCB;
                    break;
                case 0x120:
                    value = PLL_PHADJ_IOSCB;
                    break;
                case 0x124:
                    value = SSCG_REG_0_IOSCB;
                    break;
                case 0x128:
                    value = SSCG_REG_1_IOSCB;
                    break;
                case 0x12C:
                    value = SSCG_REG_2_IOSCB;
                    break;
                case 0x130:
                    value = SSCG_REG_3_IOSCB;
                    break;
                case 0x134:
                    value = RPC_RESET_IOSCB;
                    break;
                case 0x180:
                    value = SOFT_RESET_BANK_CTRL;
                    break;
                case 0x184:
                    value = DPC_BITS;
                    break;
                case 0x188:
                    value = BANK_STATUS;
                    break;
                case 0x18C:
                    value = RPC_RESET_BANK_CTRL;
                    break;
                case 0x200:
                    value = SOFT_RESET_IOCALIB;
                    break;
                case 0x204:
                    value = IOC_REG0;
                    break;
                case 0x208:
                    value = IOC_REG1;
                    break;
                case 0x20C:
                    value = IOC_REG2;
                    break;
                case 0x210:
                    value = IOC_REG3;
                    break;
                case 0x214:
                    value = IOC_REG4;
                    break;
                case 0x218:
                    value = IOC_REG5;
                    break;
                case 0x21C:
                    value = IOC_REG6;
                    break;
                case 0x220:
                    value = RPC_RESET_IOCALIB;
                    break;
                case 0x224:
                    value = RPC_calib;
                    break;
                case 0x280:
                    value = SOFT_RESET_CFM;
                    break;
                case 0x284:
                    value = BCLKMUX;
                    break;
                case 0x288:
                    value = PLL_CKMUX;
                    break;
                case 0x28C:
                    value = MSSCLKMUX;
                    break;
                case 0x290:
                    value = SPARE0;
                    break;
                case 0x294:
                    value = FMETER_ADDR;
                    break;
                case 0x298:
                    value = FMETER_DATAW;
                    break;
                case 0x29C:
                    value = FMETER_DATAR;
                    break;
                case 0x2A0:
                    value = TEST_CTRL;
                    break;
                case 0x2A4:
                    value = RPC_RESET_CFM;
                    break;
                case 0x300:
                    value = SOFT_RESET_DECODER_DRIVER;
                    break;
                case 0x304:
                    value = RPC1_DRV;
                    break;
                case 0x308:
                    value = RPC2_DRV;
                    break;
                case 0x30C:
                    value = RPC3_DRV;
                    break;
                case 0x310:
                    value = RPC4_DRV;
                    break;
                case 0x380:
                    value = SOFT_RESET_DECODER_ODT;
                    break;
                case 0x384:
                    value = RPC1_ODT;
                    break;
                case 0x388:
                    value = RPC2_ODT;
                    break;
                case 0x38C:
                    value = RPC3_ODT;
                    break;
                case 0x390:
                    value = RPC4_ODT;
                    break;
                case 0x394:
                    value = RPC5_ODT;
                    break;
                case 0x398:
                    value = RPC6_ODT;
                    break;
                case 0x39C:
                    value = RPC7_ODT;
                    break;
                case 0x3A0:
                    value = RPC8_ODT;
                    break;
                case 0x3A4:
                    value = RPC9_ODT;
                    break;
                case 0x3A8:
                    value = RPC10_ODT;
                    break;
                case 0x3AC:
                    value = RPC11_ODT;
                    break;
                case 0x400:
                    value = SOFT_RESET_DECODER_IO;
                    break;
                case 0x404:
                    value = OVRT1;
                    break;
                case 0x408:
                    value = OVRT2;
                    break;
                case 0x40C:
                    value = OVRT3;
                    break;
                case 0x410:
                    value = OVRT4;
                    break;
                case 0x414:
                    value = OVRT5;
                    break;
                case 0x418:
                    value = OVRT6;
                    break;
                case 0x41C:
                    value = OVRT7;
                    break;
                case 0x420:
                    value = OVRT8;
                    break;
                case 0x424:
                    value = OVRT9;
                    break;
                case 0x428:
                    value = OVRT10;
                    break;
                case 0x42C:
                    value = OVRT11;
                    break;
                case 0x430:
                    value = OVRT12;
                    break;
                case 0x434:
                    value = OVRT13;
                    break;
                case 0x438:
                    value = OVRT14;
                    break;
                case 0x43C:
                    value = OVRT15;
                    break;
                case 0x440:
                    value = OVRT16;
                    break;
                case 0x444:
                    value = RPC17;
                    break;
                case 0x448:
                    value = RPC18;
                    break;
                case 0x44C:
                    value = RPC19;
                    break;
                case 0x450:
                    value = RPC20;
                    break;
                case 0x454:
                    value = RPC21;
                    break;
                case 0x458:
                    value = RPC22;
                    break;
                case 0x45C:
                    value = RPC23;
                    break;
                case 0x460:
                    value = RPC24;
                    break;
                case 0x464:
                    value = RPC25;
                    break;
                case 0x468:
                    value = RPC26;
                    break;
                case 0x46C:
                    value = RPC27;
                    break;
                case 0x470:
                    value = RPC28;
                    break;
                case 0x474:
                    value = RPC29;
                    break;
                case 0x478:
                    value = RPC30;
                    break;
                case 0x47C:
                    value = RPC31;
                    break;
                case 0x480:
                    value = RPC32;
                    break;
                case 0x484:
                    value = RPC33;
                    break;
                case 0x488:
                    value = RPC34;
                    break;
                case 0x48C:
                    value = RPC35;
                    break;
                case 0x490:
                    value = RPC36;
                    break;
                case 0x494:
                    value = RPC37;
                    break;
                case 0x498:
                    value = RPC38;
                    break;
                case 0x49C:
                    value = RPC39;
                    break;
                case 0x4A0:
                    value = RPC40;
                    break;
                case 0x4A4:
                    value = RPC41;
                    break;
                case 0x4A8:
                    value = RPC42;
                    break;
                case 0x4AC:
                    value = RPC43;
                    break;
                case 0x4B0:
                    value = RPC44;
                    break;
                case 0x4B4:
                    value = RPC45;
                    break;
                case 0x4B8:
                    value = RPC46;
                    break;
                case 0x4BC:
                    value = RPC47;
                    break;
                case 0x4C0:
                    value = RPC48;
                    break;
                case 0x4C4:
                    value = RPC49;
                    break;
                case 0x4C8:
                    value = RPC50;
                    break;
                case 0x4CC:
                    value = RPC51;
                    break;
                case 0x4D0:
                    value = RPC52;
                    break;
                case 0x4D4:
                    value = RPC53;
                    break;
                case 0x4D8:
                    value = RPC54;
                    break;
                case 0x4DC:
                    value = RPC55;
                    break;
                case 0x4E0:
                    value = RPC56;
                    break;
                case 0x4E4:
                    value = RPC57;
                    break;
                case 0x4E8:
                    value = RPC58;
                    break;
                case 0x4EC:
                    value = RPC59;
                    break;
                case 0x4F0:
                    value = RPC60;
                    break;
                case 0x4F4:
                    value = RPC61;
                    break;
                case 0x4F8:
                    value = RPC62;
                    break;
                case 0x4FC:
                    value = RPC63;
                    break;
                case 0x500:
                    value = RPC64;
                    break;
                case 0x504:
                    value = RPC65;
                    break;
                case 0x508:
                    value = RPC66;
                    break;
                case 0x50C:
                    value = RPC67;
                    break;
                case 0x510:
                    value = RPC68;
                    break;
                case 0x514:
                    value = RPC69;
                    break;
                case 0x518:
                    value = RPC70;
                    break;
                case 0x51C:
                    value = RPC71;
                    break;
                case 0x520:
                    value = RPC72;
                    break;
                case 0x524:
                    value = RPC73;
                    break;
                case 0x528:
                    value = RPC74;
                    break;
                case 0x52C:
                    value = RPC75;
                    break;
                case 0x530:
                    value = RPC76;
                    break;
                case 0x534:
                    value = RPC77;
                    break;
                case 0x538:
                    value = RPC78;
                    break;
                case 0x53C:
                    value = RPC79;
                    break;
                case 0x540:
                    value = RPC80;
                    break;
                case 0x544:
                    value = RPC81;
                    break;
                case 0x548:
                    value = RPC82;
                    break;
                case 0x54C:
                    value = RPC83;
                    break;
                case 0x550:
                    value = RPC84;
                    break;
                case 0x554:
                    value = RPC85;
                    break;
                case 0x558:
                    value = RPC86;
                    break;
                case 0x55C:
                    value = RPC87;
                    break;
                case 0x560:
                    value = RPC88;
                    break;
                case 0x564:
                    value = RPC89;
                    break;
                case 0x568:
                    value = RPC90;
                    break;
                case 0x56C:
                    value = RPC91;
                    break;
                case 0x570:
                    value = RPC92;
                    break;
                case 0x574:
                    value = RPC93;
                    break;
                case 0x578:
                    value = RPC94;
                    break;
                case 0x57C:
                    value = RPC95;
                    break;
                case 0x580:
                    value = RPC96;
                    break;
                case 0x584:
                    value = RPC97;
                    break;
                case 0x588:
                    value = RPC98;
                    break;
                case 0x58C:
                    value = RPC99;
                    break;
                case 0x590:
                    value = RPC100;
                    break;
                case 0x594:
                    value = RPC101;
                    break;
                case 0x598:
                    value = RPC102;
                    break;
                case 0x59C:
                    value = RPC103;
                    break;
                case 0x5A0:
                    value = RPC104;
                    break;
                case 0x5A4:
                    value = RPC105;
                    break;
                case 0x5A8:
                    value = RPC106;
                    break;
                case 0x5AC:
                    value = RPC107;
                    break;
                case 0x5B0:
                    value = RPC108;
                    break;
                case 0x5B4:
                    value = RPC109;
                    break;
                case 0x5B8:
                    value = RPC110;
                    break;
                case 0x5BC:
                    value = RPC111;
                    break;
                case 0x5C0:
                    value = RPC112;
                    break;
                case 0x5C4:
                    value = RPC113;
                    break;
                case 0x5C8:
                    value = RPC114;
                    break;
                case 0x5CC:
                    value = RPC115;
                    break;
                case 0x5D0:
                    value = RPC116;
                    break;
                case 0x5D4:
                    value = RPC117;
                    break;
                case 0x5D8:
                    value = RPC118;
                    break;
                case 0x5DC:
                    value = RPC119;
                    break;
                case 0x5E0:
                    value = RPC120;
                    break;
                case 0x5E4:
                    value = RPC121;
                    break;
                case 0x5E8:
                    value = RPC122;
                    break;
                case 0x5EC:
                    value = RPC123;
                    break;
                case 0x5F0:
                    value = RPC124;
                    break;
                case 0x5F4:
                    value = RPC125;
                    break;
                case 0x5F8:
                    value = RPC126;
                    break;
                case 0x5FC:
                    value = RPC127;
                    break;
                case 0x600:
                    value = RPC128;
                    break;
                case 0x604:
                    value = RPC129;
                    break;
                case 0x608:
                    value = RPC130;
                    break;
                case 0x60C:
                    value = RPC131;
                    break;
                case 0x610:
                    value = RPC132;
                    break;
                case 0x614:
                    value = RPC133;
                    break;
                case 0x618:
                    value = RPC134;
                    break;
                case 0x61C:
                    value = RPC135;
                    break;
                case 0x620:
                    value = RPC136;
                    break;
                case 0x624:
                    value = RPC137;
                    break;
                case 0x628:
                    value = RPC138;
                    break;
                case 0x62C:
                    value = RPC139;
                    break;
                case 0x630:
                    value = RPC140;
                    break;
                case 0x634:
                    value = RPC141;
                    break;
                case 0x638:
                    value = RPC142;
                    break;
                case 0x63C:
                    value = RPC143;
                    break;
                case 0x640:
                    value = RPC144;
                    break;
                case 0x644:
                    value = RPC145;
                    break;
                case 0x648:
                    value = RPC146;
                    break;
                case 0x64C:
                    value = RPC147;
                    break;
                case 0x650:
                    value = RPC148;
                    break;
                case 0x654:
                    value = RPC149;
                    break;
                case 0x658:
                    value = RPC150;
                    break;
                case 0x65C:
                    value = RPC151;
                    break;
                case 0x660:
                    value = RPC152;
                    break;
                case 0x664:
                    value = RPC153;
                    break;
                case 0x668:
                    value = RPC154;
                    break;
                case 0x66C:
                    value = RPC155;
                    break;
                case 0x670:
                    value = RPC156;
                    break;
                case 0x674:
                    value = RPC157;
                    break;
                case 0x678:
                    value = RPC158;
                    break;
                case 0x67C:
                    value = RPC159;
                    break;
                case 0x680:
                    value = RPC160;
                    break;
                case 0x684:
                    value = RPC161;
                    break;
                case 0x688:
                    value = RPC162;
                    break;
                case 0x68C:
                    value = RPC163;
                    break;
                case 0x690:
                    value = RPC164;
                    break;
                case 0x694:
                    value = RPC165;
                    break;
                case 0x698:
                    value = RPC166;
                    break;
                case 0x69C:
                    value = RPC167;
                    break;
                case 0x6A0:
                    value = RPC168;
                    break;
                case 0x6A4:
                    value = RPC169;
                    break;
                case 0x6A8:
                    value = RPC170;
                    break;
                case 0x6AC:
                    value = RPC171;
                    break;
                case 0x6B0:
                    value = RPC172;
                    break;
                case 0x6B4:
                    value = RPC173;
                    break;
                case 0x6B8:
                    value = RPC174;
                    break;
                case 0x6BC:
                    value = RPC175;
                    break;
                case 0x6C0:
                    value = RPC176;
                    break;
                case 0x6C4:
                    value = RPC177;
                    break;
                case 0x6C8:
                    value = RPC178;
                    break;
                case 0x6CC:
                    value = RPC179;
                    break;
                case 0x6D0:
                    value = RPC180;
                    break;
                case 0x6D4:
                    value = RPC181;
                    break;
                case 0x6D8:
                    value = RPC182;
                    break;
                case 0x6DC:
                    value = RPC183;
                    break;
                case 0x6E0:
                    value = RPC184;
                    break;
                case 0x6E4:
                    value = RPC185;
                    break;
                case 0x6E8:
                    value = RPC186;
                    break;
                case 0x6EC:
                    value = RPC187;
                    break;
                case 0x6F0:
                    value = RPC188;
                    break;
                case 0x6F4:
                    value = RPC189;
                    break;
                case 0x6F8:
                    value = RPC190;
                    break;
                case 0x6FC:
                    value = RPC191;
                    break;
                case 0x700:
                    value = RPC192;
                    break;
                case 0x704:
                    value = RPC193;
                    break;
                case 0x708:
                    value = RPC194;
                    break;
                case 0x70C:
                    value = RPC195;
                    break;
                case 0x710:
                    value = RPC196;
                    break;
                case 0x714:
                    value = RPC197;
                    break;
                case 0x718:
                    value = RPC198;
                    break;
                case 0x71C:
                    value = RPC199;
                    break;
                case 0x720:
                    value = RPC200;
                    break;
                case 0x724:
                    value = RPC201;
                    break;
                case 0x728:
                    value = RPC202;
                    break;
                case 0x72C:
                    value = RPC203;
                    break;
                case 0x730:
                    value = RPC204;
                    break;
                case 0x734:
                    value = RPC205;
                    break;
                case 0x738:
                    value = RPC206;
                    break;
                case 0x73C:
                    value = RPC207;
                    break;
                case 0x740:
                    value = RPC208;
                    break;
                case 0x744:
                    value = RPC209;
                    break;
                case 0x748:
                    value = RPC210;
                    break;
                case 0x74C:
                    value = RPC211;
                    break;
                case 0x750:
                    value = RPC212;
                    break;
                case 0x754:
                    value = RPC213;
                    break;
                case 0x758:
                    value = RPC214;
                    break;
                case 0x75C:
                    value = RPC215;
                    break;
                case 0x760:
                    value = RPC216;
                    break;
                case 0x764:
                    value = RPC217;
                    break;
                case 0x768:
                    value = RPC218;
                    break;
                case 0x76C:
                    value = RPC219;
                    break;
                case 0x770:
                    value = RPC220;
                    break;
                case 0x774:
                    value = RPC221;
                    break;
                case 0x778:
                    value = RPC222;
                    break;
                case 0x77C:
                    value = RPC223;
                    break;
                case 0x780:
                    value = RPC224;
                    break;
                case 0x784:
                    value = RPC225;
                    break;
                case 0x788:
                    value = RPC226;
                    break;
                case 0x78C:
                    value = RPC227;
                    break;
                case 0x790:
                    value = RPC228;
                    break;
                case 0x794:
                    value = RPC229;
                    break;
                case 0x798:
                    value = RPC230;
                    break;
                case 0x79C:
                    value = RPC231;
                    break;
                case 0x7A0:
                    value = RPC232;
                    break;
                case 0x7A4:
                    value = RPC233;
                    break;
                case 0x7A8:
                    value = RPC234;
                    break;
                case 0x7AC:
                    value = RPC235;
                    break;
                case 0x7B0:
                    value = RPC236;
                    break;
                case 0x7B4:
                    value = RPC237;
                    break;
                case 0x7B8:
                    value = RPC238;
                    break;
                case 0x7BC:
                    value = RPC239;
                    break;
                case 0x7C0:
                    value = RPC240;
                    break;
                case 0x7C4:
                    value = RPC241;
                    break;
                case 0x7C8:
                    value = RPC242;
                    break;
                case 0x7CC:
                    value = RPC243;
                    break;
                case 0x7D0:
                    value = RPC244;
                    break;
                case 0x7D4:
                    value = RPC245;
                    break;
                case 0x7D8:
                    value = RPC246;
                    break;
                case 0x7DC:
                    value = RPC247;
                    break;
                case 0x7E0:
                    value = RPC248;
                    break;
                case 0x7E4:
                    value = RPC249;
                    break;
                case 0x7E8:
                    value = RPC250;
                    break;
                case 0x7EC:
                    value = SPIO251;
                    break;
                case 0x7F0:
                    value = SPIO252;
                    break;
                case 0x7F4:
                    value = SPIO253;
                    break;
                case 0x800:
                    value = SOFT_RESET_TIP;
                    break;
                case 0x804:
                    value = RANK_SELECT;
                    break;
                case 0x808:
                    value = LANE_SELECT;
                    break;
                case 0x80C:
                    value = TRAINING_SKIP;
                    break;
                case 0x810:
                    value = TRAINING_START;
                    break;
                case 0x814:
                    value = TRAINING_STATUS;
                    break;
                case 0x818:
                    value = TRAINING_RESET;
                    break;
                case 0x81C:
                    value = GT_ERR_COMB;
                    break;
                case 0x820:
                    value = GT_CLK_SEL;
                    break;
                case 0x824:
                    value = GT_TXDLY;
                    break;
                case 0x828:
                    value = GT_STEPS_180;
                    break;
                case 0x82C:
                    value = GT_STATE;
                    break;
                case 0x830:
                    value = WL_DELAY_0;
                    break;
                case 0x834:
                    value = DQ_DQS_ERR_DONE;
                    break;
                case 0x838:
                    value = DQDQS_WINDOW;
                    break;
                case 0x83C:
                    value = DQDQS_STATE;
                    break;
                case 0x840:
                    value = DELTA0;
                    break;
                case 0x844:
                    value = DELTA1;
                    break;
                case 0x848:
                    value = DQDQS_STATUS0;
                    break;
                case 0x84C:
                    value = DQDQS_STATUS1;
                    break;
                case 0x850:
                    value = DQDQS_STATUS2;
                    break;
                case 0x854:
                    value = DQDQS_STATUS3;
                    break;
                case 0x858:
                    value = DQDQS_STATUS4;
                    break;
                case 0x85C:
                    value = DQDQS_STATUS5;
                    break;
                case 0x860:
                    value = DQDQS_STATUS6;
                    break;
                case 0x864:
                    value = ADDCMD_STATUS0;
                    break;
                case 0x868:
                    value = ADDCMD_STATUS1;
                    break;
                case 0x86C:
                    value = ADDCMD_ANSWER;
                    break;
                case 0x870:
                    value = BCLKSCLK_ANSWER;
                    break;
                case 0x874:
                    value = DQDQS_WRCALIB_OFFSET;
                    break;
                case 0x878:
                    value = EXPERT_MODE_EN;
                    break;
                case 0x87C:
                    value = EXPERT_DLYCNT_MOVE_REG0;
                    break;
                case 0x880:
                    value = EXPERT_DLYCNT_MOVE_REG1;
                    break;
                case 0x884:
                    value = EXPERT_DLYCNT_DIRECTION_REG0;
                    break;
                case 0x888:
                    value = EXPERT_DLYCNT_DIRECTION_REG1;
                    break;
                case 0x88C:
                    value = EXPERT_DLYCNT_LOAD_REG0;
                    break;
                case 0x890:
                    value = EXPERT_DLYCNT_LOAD_REG1;
                    break;
                case 0x894:
                    value = EXPERT_DLYCNT_OOR_REG0;
                    break;
                case 0x898:
                    value = EXPERT_DLYCNT_OOR_REG1;
                    break;
                case 0x89C:
                    value = EXPERT_DLYCNT_MV_RD_DLY_REG;
                    break;
                case 0x8A0:
                    value = EXPERT_DLYCNT_PAUSE;
                    break;
                case 0x8A4:
                    value = EXPERT_PLLCNT;
                    break;
                case 0x8A8:
                    value = EXPERT_DQLANE_READBACK;
                    break;
                case 0x8AC:
                    value = EXPERT_ADDCMD_LN_READBACK;
                    break;
                case 0x8B0:
                    value = EXPERT_READ_GATE_CONTROLS;
                    break;
                case 0x8B4:
                    value = EXPERT_DQ_DQS_OPTIMIZATION0;
                    break;
                case 0x8B8:
                    value = EXPERT_DQ_DQS_OPTIMIZATION1;
                    break;
                case 0x8BC:
                    value = EXPERT_WRCALIB;
                    break;
                case 0x8C0:
                    value = EXPERT_CALIF;
                    break;
                case 0x8C4:
                    value = EXPERT_CALIF_READBACK;
                    break;
                case 0x8C8:
                    value = EXPERT_CALIF_READBACK1;
                    break;
                case 0x8CC:
                    value = EXPERT_DFI_STATUS_OVERRIDE_TO_SHIM;
                    break;
                case 0x8D0:
                    value = TIP_CFG_PARAMS;
                    break;
                case 0x8D4:
                    value = TIP_VREF_PARAM;
                    break;
                case 0x8D8:
                    value = LANE_ALIGNMENT_FIFO_CONTROL;
                    break;
                case 0xC00:
                    value = SOFT_RESET_SGMII;
                    break;
                case 0xC04:
                    value = SGMII_MODE;
                    break;
                case 0xC08:
                    value = PLL_CNTL;
                    break;
                case 0xC0C:
                    value = CH0_CNTL;
                    break;
                case 0xC10:
                    value = CH1_CNTL;
                    break;
                case 0xC14:
                    value = RECAL_CNTL;
                    break;
                case 0xC18:
                    value = CLK_CNTL;
                    break;
                case 0xC1C:
                    value = DYN_CNTL;
                    break;
                case 0xC20:
                    value = PVT_STAT;
                    break;
                case 0xC24:
                    value = SPARE_CNTL;
                    break;
                case 0xC28:
                    value = SPARE_STAT;
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
                    SOFT_RESET_DDR_PHY =  value;
                    break;
                case 0x004:
                    DDRPHY_MODE =  value;
                    break;
                case 0x008:
                    DDRPHY_STARTUP =  value;
                    break;
                case 0x00C:
                    SPARE_0 =  value;
                    break;
                case 0x080:
                    SOFT_RESET_MAIN_PLL =  value;
                    break;
                case 0x084:
                    PLL_CTRL_MAIN =  value;
                    break;
                case 0x088:
                    PLL_REF_FB_MAIN =  value;
                    break;
                case 0x08C:
                    PLL_FRACN_MAIN =  value;
                    break;
                case 0x090:
                    PLL_DIV_0_1_MAIN =  value;
                    break;
                case 0x094:
                    PLL_DIV_2_3_MAIN =  value;
                    break;
                case 0x098:
                    PLL_CTRL2_MAIN =  value;
                    break;
                case 0x09C:
                    PLL_CAL_MAIN =  value;
                    break;
                case 0x0A0:
                    PLL_PHADJ_MAIN =  value;
                    break;
                case 0x0A4:
                    SSCG_REG_0_MAIN =  value;
                    break;
                case 0x0A8:
                    SSCG_REG_1_MAIN =  value;
                    break;
                case 0x0AC:
                    SSCG_REG_2_MAIN =  value;
                    break;
                case 0x0B0:
                    SSCG_REG_3_MAIN =  value;
                    break;
                case 0x0B4:
                    RPC_RESET_MAIN_PLL =  value;
                    break;
                case 0x100:
                    SOFT_RESET_IOSCB_PLL =  value;
                    break;
                case 0x104:
                    PLL_CTRL_IOSCB =  value;
                    break;
                case 0x108:
                    PLL_REF_FB_IOSCB =  value;
                    break;
                case 0x10C:
                    PLL_FRACN_IOSCB =  value;
                    break;
                case 0x110:
                    PLL_DIV_0_1_IOSCB =  value;
                    break;
                case 0x114:
                    PLL_DIV_2_3_IOSCB =  value;
                    break;
                case 0x118:
                    PLL_CTRL2_IOSCB =  value;
                    break;
                case 0x11C:
                    PLL_CAL_IOSCB =  value;
                    break;
                case 0x120:
                    PLL_PHADJ_IOSCB =  value;
                    break;
                case 0x124:
                    SSCG_REG_0_IOSCB =  value;
                    break;
                case 0x128:
                    SSCG_REG_1_IOSCB =  value;
                    break;
                case 0x12C:
                    SSCG_REG_2_IOSCB =  value;
                    break;
                case 0x130:
                    SSCG_REG_3_IOSCB =  value;
                    break;
                case 0x134:
                    RPC_RESET_IOSCB =  value;
                    break;
                case 0x180:
                    SOFT_RESET_BANK_CTRL =  value;
                    break;
                case 0x184:
                    DPC_BITS =  value;
                    break;
                case 0x188:
                    BANK_STATUS =  value;
                    break;
                case 0x18C:
                    RPC_RESET_BANK_CTRL =  value;
                    break;
                case 0x200:
                    SOFT_RESET_IOCALIB =  value;
                    break;
                case 0x204:
                    IOC_REG0 =  value;
                    break;
                case 0x208:
                    IOC_REG1 =  value;
                    break;
                case 0x20C:
                    IOC_REG2 =  value;
                    break;
                case 0x210:
                    IOC_REG3 =  value;
                    break;
                case 0x214:
                    IOC_REG4 =  value;
                    break;
                case 0x218:
                    IOC_REG5 =  value;
                    break;
                case 0x21C:
                    IOC_REG6 =  value;
                    break;
                case 0x220:
                    RPC_RESET_IOCALIB =  value;
                    break;
                case 0x224:
                    RPC_calib =  value;
                    break;
                case 0x280:
                    SOFT_RESET_CFM =  value;
                    break;
                case 0x284:
                    BCLKMUX =  value;
                    break;
                case 0x288:
                    PLL_CKMUX =  value;
                    break;
                case 0x28C:
                    MSSCLKMUX =  value;
                    break;
                case 0x290:
                    SPARE0 =  value;
                    break;
                case 0x294:
                    FMETER_ADDR =  value;
                    break;
                case 0x298:
                    FMETER_DATAW =  value;
                    break;
                case 0x29C:
                    FMETER_DATAR =  value;
                    break;
                case 0x2A0:
                    TEST_CTRL =  value;
                    break;
                case 0x2A4:
                    RPC_RESET_CFM =  value;
                    break;
                case 0x300:
                    SOFT_RESET_DECODER_DRIVER =  value;
                    break;
                case 0x304:
                    RPC1_DRV =  value;
                    break;
                case 0x308:
                    RPC2_DRV =  value;
                    break;
                case 0x30C:
                    RPC3_DRV =  value;
                    break;
                case 0x310:
                    RPC4_DRV =  value;
                    break;
                case 0x380:
                    SOFT_RESET_DECODER_ODT =  value;
                    break;
                case 0x384:
                    RPC1_ODT =  value;
                    break;
                case 0x388:
                    RPC2_ODT =  value;
                    break;
                case 0x38C:
                    RPC3_ODT =  value;
                    break;
                case 0x390:
                    RPC4_ODT =  value;
                    break;
                case 0x394:
                    RPC5_ODT =  value;
                    break;
                case 0x398:
                    RPC6_ODT =  value;
                    break;
                case 0x39C:
                    RPC7_ODT =  value;
                    break;
                case 0x3A0:
                    RPC8_ODT =  value;
                    break;
                case 0x3A4:
                    RPC9_ODT =  value;
                    break;
                case 0x3A8:
                    RPC10_ODT =  value;
                    break;
                case 0x3AC:
                    RPC11_ODT =  value;
                    break;
                case 0x400:
                    SOFT_RESET_DECODER_IO =  value;
                    break;
                case 0x404:
                    OVRT1 =  value;
                    break;
                case 0x408:
                    OVRT2 =  value;
                    break;
                case 0x40C:
                    OVRT3 =  value;
                    break;
                case 0x410:
                    OVRT4 =  value;
                    break;
                case 0x414:
                    OVRT5 =  value;
                    break;
                case 0x418:
                    OVRT6 =  value;
                    break;
                case 0x41C:
                    OVRT7 =  value;
                    break;
                case 0x420:
                    OVRT8 =  value;
                    break;
                case 0x424:
                    OVRT9 =  value;
                    break;
                case 0x428:
                    OVRT10 =  value;
                    break;
                case 0x42C:
                    OVRT11 =  value;
                    break;
                case 0x430:
                    OVRT12 =  value;
                    break;
                case 0x434:
                    OVRT13 =  value;
                    break;
                case 0x438:
                    OVRT14 =  value;
                    break;
                case 0x43C:
                    OVRT15 =  value;
                    break;
                case 0x440:
                    OVRT16 =  value;
                    break;
                case 0x444:
                    RPC17 =  value;
                    break;
                case 0x448:
                    RPC18 =  value;
                    break;
                case 0x44C:
                    RPC19 =  value;
                    break;
                case 0x450:
                    RPC20 =  value;
                    break;
                case 0x454:
                    RPC21 =  value;
                    break;
                case 0x458:
                    RPC22 =  value;
                    break;
                case 0x45C:
                    RPC23 =  value;
                    break;
                case 0x460:
                    RPC24 =  value;
                    break;
                case 0x464:
                    RPC25 =  value;
                    break;
                case 0x468:
                    RPC26 =  value;
                    break;
                case 0x46C:
                    RPC27 =  value;
                    break;
                case 0x470:
                    RPC28 =  value;
                    break;
                case 0x474:
                    RPC29 =  value;
                    break;
                case 0x478:
                    RPC30 =  value;
                    break;
                case 0x47C:
                    RPC31 =  value;
                    break;
                case 0x480:
                    RPC32 =  value;
                    break;
                case 0x484:
                    RPC33 =  value;
                    break;
                case 0x488:
                    RPC34 =  value;
                    break;
                case 0x48C:
                    RPC35 =  value;
                    break;
                case 0x490:
                    RPC36 =  value;
                    break;
                case 0x494:
                    RPC37 =  value;
                    break;
                case 0x498:
                    RPC38 =  value;
                    break;
                case 0x49C:
                    RPC39 =  value;
                    break;
                case 0x4A0:
                    RPC40 =  value;
                    break;
                case 0x4A4:
                    RPC41 =  value;
                    break;
                case 0x4A8:
                    RPC42 =  value;
                    break;
                case 0x4AC:
                    RPC43 =  value;
                    break;
                case 0x4B0:
                    RPC44 =  value;
                    break;
                case 0x4B4:
                    RPC45 =  value;
                    break;
                case 0x4B8:
                    RPC46 =  value;
                    break;
                case 0x4BC:
                    RPC47 =  value;
                    break;
                case 0x4C0:
                    RPC48 =  value;
                    break;
                case 0x4C4:
                    RPC49 =  value;
                    break;
                case 0x4C8:
                    RPC50 =  value;
                    break;
                case 0x4CC:
                    RPC51 =  value;
                    break;
                case 0x4D0:
                    RPC52 =  value;
                    break;
                case 0x4D4:
                    RPC53 =  value;
                    break;
                case 0x4D8:
                    RPC54 =  value;
                    break;
                case 0x4DC:
                    RPC55 =  value;
                    break;
                case 0x4E0:
                    RPC56 =  value;
                    break;
                case 0x4E4:
                    RPC57 =  value;
                    break;
                case 0x4E8:
                    RPC58 =  value;
                    break;
                case 0x4EC:
                    RPC59 =  value;
                    break;
                case 0x4F0:
                    RPC60 =  value;
                    break;
                case 0x4F4:
                    RPC61 =  value;
                    break;
                case 0x4F8:
                    RPC62 =  value;
                    break;
                case 0x4FC:
                    RPC63 =  value;
                    break;
                case 0x500:
                    RPC64 =  value;
                    break;
                case 0x504:
                    RPC65 =  value;
                    break;
                case 0x508:
                    RPC66 =  value;
                    break;
                case 0x50C:
                    RPC67 =  value;
                    break;
                case 0x510:
                    RPC68 =  value;
                    break;
                case 0x514:
                    RPC69 =  value;
                    break;
                case 0x518:
                    RPC70 =  value;
                    break;
                case 0x51C:
                    RPC71 =  value;
                    break;
                case 0x520:
                    RPC72 =  value;
                    break;
                case 0x524:
                    RPC73 =  value;
                    break;
                case 0x528:
                    RPC74 =  value;
                    break;
                case 0x52C:
                    RPC75 =  value;
                    break;
                case 0x530:
                    RPC76 =  value;
                    break;
                case 0x534:
                    RPC77 =  value;
                    break;
                case 0x538:
                    RPC78 =  value;
                    break;
                case 0x53C:
                    RPC79 =  value;
                    break;
                case 0x540:
                    RPC80 =  value;
                    break;
                case 0x544:
                    RPC81 =  value;
                    break;
                case 0x548:
                    RPC82 =  value;
                    break;
                case 0x54C:
                    RPC83 =  value;
                    break;
                case 0x550:
                    RPC84 =  value;
                    break;
                case 0x554:
                    RPC85 =  value;
                    break;
                case 0x558:
                    RPC86 =  value;
                    break;
                case 0x55C:
                    RPC87 =  value;
                    break;
                case 0x560:
                    RPC88 =  value;
                    break;
                case 0x564:
                    RPC89 =  value;
                    break;
                case 0x568:
                    RPC90 =  value;
                    break;
                case 0x56C:
                    RPC91 =  value;
                    break;
                case 0x570:
                    RPC92 =  value;
                    break;
                case 0x574:
                    RPC93 =  value;
                    break;
                case 0x578:
                    RPC94 =  value;
                    break;
                case 0x57C:
                    RPC95 =  value;
                    break;
                case 0x580:
                    RPC96 =  value;
                    break;
                case 0x584:
                    RPC97 =  value;
                    break;
                case 0x588:
                    RPC98 =  value;
                    break;
                case 0x58C:
                    RPC99 =  value;
                    break;
                case 0x590:
                    RPC100 =  value;
                    break;
                case 0x594:
                    RPC101 =  value;
                    break;
                case 0x598:
                    RPC102 =  value;
                    break;
                case 0x59C:
                    RPC103 =  value;
                    break;
                case 0x5A0:
                    RPC104 =  value;
                    break;
                case 0x5A4:
                    RPC105 =  value;
                    break;
                case 0x5A8:
                    RPC106 =  value;
                    break;
                case 0x5AC:
                    RPC107 =  value;
                    break;
                case 0x5B0:
                    RPC108 =  value;
                    break;
                case 0x5B4:
                    RPC109 =  value;
                    break;
                case 0x5B8:
                    RPC110 =  value;
                    break;
                case 0x5BC:
                    RPC111 =  value;
                    break;
                case 0x5C0:
                    RPC112 =  value;
                    break;
                case 0x5C4:
                    RPC113 =  value;
                    break;
                case 0x5C8:
                    RPC114 =  value;
                    break;
                case 0x5CC:
                    RPC115 =  value;
                    break;
                case 0x5D0:
                    RPC116 =  value;
                    break;
                case 0x5D4:
                    RPC117 =  value;
                    break;
                case 0x5D8:
                    RPC118 =  value;
                    break;
                case 0x5DC:
                    RPC119 =  value;
                    break;
                case 0x5E0:
                    RPC120 =  value;
                    break;
                case 0x5E4:
                    RPC121 =  value;
                    break;
                case 0x5E8:
                    RPC122 =  value;
                    break;
                case 0x5EC:
                    RPC123 =  value;
                    break;
                case 0x5F0:
                    RPC124 =  value;
                    break;
                case 0x5F4:
                    RPC125 =  value;
                    break;
                case 0x5F8:
                    RPC126 =  value;
                    break;
                case 0x5FC:
                    RPC127 =  value;
                    break;
                case 0x600:
                    RPC128 =  value;
                    break;
                case 0x604:
                    RPC129 =  value;
                    break;
                case 0x608:
                    RPC130 =  value;
                    break;
                case 0x60C:
                    RPC131 =  value;
                    break;
                case 0x610:
                    RPC132 =  value;
                    break;
                case 0x614:
                    RPC133 =  value;
                    break;
                case 0x618:
                    RPC134 =  value;
                    break;
                case 0x61C:
                    RPC135 =  value;
                    break;
                case 0x620:
                    RPC136 =  value;
                    break;
                case 0x624:
                    RPC137 =  value;
                    break;
                case 0x628:
                    RPC138 =  value;
                    break;
                case 0x62C:
                    RPC139 =  value;
                    break;
                case 0x630:
                    RPC140 =  value;
                    break;
                case 0x634:
                    RPC141 =  value;
                    break;
                case 0x638:
                    RPC142 =  value;
                    break;
                case 0x63C:
                    RPC143 =  value;
                    break;
                case 0x640:
                    RPC144 =  value;
                    break;
                case 0x644:
                    RPC145 =  value;
                    break;
                case 0x648:
                    RPC146 =  value;
                    break;
                case 0x64C:
                    RPC147 =  value;
                    break;
                case 0x650:
                    RPC148 =  value;
                    break;
                case 0x654:
                    RPC149 =  value;
                    break;
                case 0x658:
                    RPC150 =  value;
                    break;
                case 0x65C:
                    RPC151 =  value;
                    break;
                case 0x660:
                    RPC152 =  value;
                    break;
                case 0x664:
                    RPC153 =  value;
                    break;
                case 0x668:
                    RPC154 =  value;
                    break;
                case 0x66C:
                    RPC155 =  value;
                    break;
                case 0x670:
                    RPC156 =  value;
                    break;
                case 0x674:
                    RPC157 =  value;
                    break;
                case 0x678:
                    RPC158 =  value;
                    break;
                case 0x67C:
                    RPC159 =  value;
                    break;
                case 0x680:
                    RPC160 =  value;
                    break;
                case 0x684:
                    RPC161 =  value;
                    break;
                case 0x688:
                    RPC162 =  value;
                    break;
                case 0x68C:
                    RPC163 =  value;
                    break;
                case 0x690:
                    RPC164 =  value;
                    break;
                case 0x694:
                    RPC165 =  value;
                    break;
                case 0x698:
                    RPC166 =  value;
                    break;
                case 0x69C:
                    RPC167 =  value;
                    break;
                case 0x6A0:
                    RPC168 =  value;
                    break;
                case 0x6A4:
                    RPC169 =  value;
                    break;
                case 0x6A8:
                    RPC170 =  value;
                    break;
                case 0x6AC:
                    RPC171 =  value;
                    break;
                case 0x6B0:
                    RPC172 =  value;
                    break;
                case 0x6B4:
                    RPC173 =  value;
                    break;
                case 0x6B8:
                    RPC174 =  value;
                    break;
                case 0x6BC:
                    RPC175 =  value;
                    break;
                case 0x6C0:
                    RPC176 =  value;
                    break;
                case 0x6C4:
                    RPC177 =  value;
                    break;
                case 0x6C8:
                    RPC178 =  value;
                    break;
                case 0x6CC:
                    RPC179 =  value;
                    break;
                case 0x6D0:
                    RPC180 =  value;
                    break;
                case 0x6D4:
                    RPC181 =  value;
                    break;
                case 0x6D8:
                    RPC182 =  value;
                    break;
                case 0x6DC:
                    RPC183 =  value;
                    break;
                case 0x6E0:
                    RPC184 =  value;
                    break;
                case 0x6E4:
                    RPC185 =  value;
                    break;
                case 0x6E8:
                    RPC186 =  value;
                    break;
                case 0x6EC:
                    RPC187 =  value;
                    break;
                case 0x6F0:
                    RPC188 =  value;
                    break;
                case 0x6F4:
                    RPC189 =  value;
                    break;
                case 0x6F8:
                    RPC190 =  value;
                    break;
                case 0x6FC:
                    RPC191 =  value;
                    break;
                case 0x700:
                    RPC192 =  value;
                    break;
                case 0x704:
                    RPC193 =  value;
                    break;
                case 0x708:
                    RPC194 =  value;
                    break;
                case 0x70C:
                    RPC195 =  value;
                    break;
                case 0x710:
                    RPC196 =  value;
                    break;
                case 0x714:
                    RPC197 =  value;
                    break;
                case 0x718:
                    RPC198 =  value;
                    break;
                case 0x71C:
                    RPC199 =  value;
                    break;
                case 0x720:
                    RPC200 =  value;
                    break;
                case 0x724:
                    RPC201 =  value;
                    break;
                case 0x728:
                    RPC202 =  value;
                    break;
                case 0x72C:
                    RPC203 =  value;
                    break;
                case 0x730:
                    RPC204 =  value;
                    break;
                case 0x734:
                    RPC205 =  value;
                    break;
                case 0x738:
                    RPC206 =  value;
                    break;
                case 0x73C:
                    RPC207 =  value;
                    break;
                case 0x740:
                    RPC208 =  value;
                    break;
                case 0x744:
                    RPC209 =  value;
                    break;
                case 0x748:
                    RPC210 =  value;
                    break;
                case 0x74C:
                    RPC211 =  value;
                    break;
                case 0x750:
                    RPC212 =  value;
                    break;
                case 0x754:
                    RPC213 =  value;
                    break;
                case 0x758:
                    RPC214 =  value;
                    break;
                case 0x75C:
                    RPC215 =  value;
                    break;
                case 0x760:
                    RPC216 =  value;
                    break;
                case 0x764:
                    RPC217 =  value;
                    break;
                case 0x768:
                    RPC218 =  value;
                    break;
                case 0x76C:
                    RPC219 =  value;
                    break;
                case 0x770:
                    RPC220 =  value;
                    break;
                case 0x774:
                    RPC221 =  value;
                    break;
                case 0x778:
                    RPC222 =  value;
                    break;
                case 0x77C:
                    RPC223 =  value;
                    break;
                case 0x780:
                    RPC224 =  value;
                    break;
                case 0x784:
                    RPC225 =  value;
                    break;
                case 0x788:
                    RPC226 =  value;
                    break;
                case 0x78C:
                    RPC227 =  value;
                    break;
                case 0x790:
                    RPC228 =  value;
                    break;
                case 0x794:
                    RPC229 =  value;
                    break;
                case 0x798:
                    RPC230 =  value;
                    break;
                case 0x79C:
                    RPC231 =  value;
                    break;
                case 0x7A0:
                    RPC232 =  value;
                    break;
                case 0x7A4:
                    RPC233 =  value;
                    break;
                case 0x7A8:
                    RPC234 =  value;
                    break;
                case 0x7AC:
                    RPC235 =  value;
                    break;
                case 0x7B0:
                    RPC236 =  value;
                    break;
                case 0x7B4:
                    RPC237 =  value;
                    break;
                case 0x7B8:
                    RPC238 =  value;
                    break;
                case 0x7BC:
                    RPC239 =  value;
                    break;
                case 0x7C0:
                    RPC240 =  value;
                    break;
                case 0x7C4:
                    RPC241 =  value;
                    break;
                case 0x7C8:
                    RPC242 =  value;
                    break;
                case 0x7CC:
                    RPC243 =  value;
                    break;
                case 0x7D0:
                    RPC244 =  value;
                    break;
                case 0x7D4:
                    RPC245 =  value;
                    break;
                case 0x7D8:
                    RPC246 =  value;
                    break;
                case 0x7DC:
                    RPC247 =  value;
                    break;
                case 0x7E0:
                    RPC248 =  value;
                    break;
                case 0x7E4:
                    RPC249 =  value;
                    break;
                case 0x7E8:
                    RPC250 =  value;
                    break;
                case 0x7EC:
                    SPIO251 =  value;
                    break;
                case 0x7F0:
                    SPIO252 =  value;
                    break;
                case 0x7F4:
                    SPIO253 =  value;
                    break;
                case 0x800:
                    SOFT_RESET_TIP =  value;
                    break;
                case 0x804:
                    RANK_SELECT =  value;
                    break;
                case 0x808:
                    LANE_SELECT =  value;
                    break;
                case 0x80C:
                    TRAINING_SKIP =  value;
                    break;
                case 0x810:
                    TRAINING_START =  value;
                    break;
                case 0x814:
                    TRAINING_STATUS =  value;
                    break;
                case 0x818:
                    TRAINING_RESET =  value;
                    break;
                case 0x81C:
                    GT_ERR_COMB =  value;
                    break;
                case 0x820:
                    GT_CLK_SEL =  value;
                    break;
                case 0x824:
                    GT_TXDLY =  value;
                    break;
                case 0x828:
                    GT_STEPS_180 =  value;
                    break;
                case 0x82C:
                    GT_STATE =  value;
                    break;
                case 0x830:
                    WL_DELAY_0 =  value;
                    break;
                case 0x834:
                    DQ_DQS_ERR_DONE =  value;
                    break;
                case 0x838:
                    DQDQS_WINDOW =  value;
                    break;
                case 0x83C:
                    DQDQS_STATE =  value;
                    break;
                case 0x840:
                    DELTA0 =  value;
                    break;
                case 0x844:
                    DELTA1 =  value;
                    break;
                case 0x848:
                    DQDQS_STATUS0 =  value;
                    break;
                case 0x84C:
                    DQDQS_STATUS1 =  value;
                    break;
                case 0x850:
                    DQDQS_STATUS2 =  value;
                    break;
                case 0x854:
                    DQDQS_STATUS3 =  value;
                    break;
                case 0x858:
                    DQDQS_STATUS4 =  value;
                    break;
                case 0x85C:
                    DQDQS_STATUS5 =  value;
                    break;
                case 0x860:
                    DQDQS_STATUS6 =  value;
                    break;
                case 0x864:
                    ADDCMD_STATUS0 =  value;
                    break;
                case 0x868:
                    ADDCMD_STATUS1 =  value;
                    break;
                case 0x86C:
                    ADDCMD_ANSWER =  value;
                    break;
                case 0x870:
                    BCLKSCLK_ANSWER =  value;
                    break;
                case 0x874:
                    DQDQS_WRCALIB_OFFSET =  value;
                    break;
                case 0x878:
                    EXPERT_MODE_EN =  value;
                    break;
                case 0x87C:
                    EXPERT_DLYCNT_MOVE_REG0 =  value;
                    break;
                case 0x880:
                    EXPERT_DLYCNT_MOVE_REG1 =  value;
                    break;
                case 0x884:
                    EXPERT_DLYCNT_DIRECTION_REG0 =  value;
                    break;
                case 0x888:
                    EXPERT_DLYCNT_DIRECTION_REG1 =  value;
                    break;
                case 0x88C:
                    EXPERT_DLYCNT_LOAD_REG0 =  value;
                    break;
                case 0x890:
                    EXPERT_DLYCNT_LOAD_REG1 =  value;
                    break;
                case 0x894:
                    EXPERT_DLYCNT_OOR_REG0 =  value;
                    break;
                case 0x898:
                    EXPERT_DLYCNT_OOR_REG1 =  value;
                    break;
                case 0x89C:
                    EXPERT_DLYCNT_MV_RD_DLY_REG =  value;
                    break;
                case 0x8A0:
                    EXPERT_DLYCNT_PAUSE =  value;
                    break;
                case 0x8A4:
                    EXPERT_PLLCNT =  value;
                    break;
                case 0x8A8:
                    EXPERT_DQLANE_READBACK =  value;
                    break;
                case 0x8AC:
                    EXPERT_ADDCMD_LN_READBACK =  value;
                    break;
                case 0x8B0:
                    EXPERT_READ_GATE_CONTROLS =  value;
                    break;
                case 0x8B4:
                    EXPERT_DQ_DQS_OPTIMIZATION0 =  value;
                    break;
                case 0x8B8:
                    EXPERT_DQ_DQS_OPTIMIZATION1 =  value;
                    break;
                case 0x8BC:
                    EXPERT_WRCALIB =  value;
                    break;
                case 0x8C0:
                    EXPERT_CALIF =  value;
                    break;
                case 0x8C4:
                    EXPERT_CALIF_READBACK =  value;
                    break;
                case 0x8C8:
                    EXPERT_CALIF_READBACK1 =  value;
                    break;
                case 0x8CC:
                    EXPERT_DFI_STATUS_OVERRIDE_TO_SHIM =  value;
                    break;
                case 0x8D0:
                    TIP_CFG_PARAMS =  value;
                    break;
                case 0x8D4:
                    TIP_VREF_PARAM =  value;
                    break;
                case 0x8D8:
                    LANE_ALIGNMENT_FIFO_CONTROL =  value;
                    break;
                case 0xC00:
                    SOFT_RESET_SGMII =  value;
                    break;
                case 0xC04:
                    SGMII_MODE =  value;
                    break;
                case 0xC08:
                    PLL_CNTL =  value;
                    break;
                case 0xC0C:
                    CH0_CNTL =  value;
                    break;
                case 0xC10:
                    CH1_CNTL =  value;
                    break;
                case 0xC14:
                    RECAL_CNTL =  value;
                    break;
                case 0xC18:
                    CLK_CNTL =  value;
                    break;
                case 0xC1C:
                    DYN_CNTL =  value;
                    break;
                case 0xC20:
                    PVT_STAT =  value;
                    break;
                case 0xC24:
                    SPARE_CNTL =  value;
                    break;
                case 0xC28:
                    SPARE_STAT =  value;
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


