using Antmicro.Renode.Peripherals.Bus;
using Antmicro.Renode.Logging;

namespace Antmicro.Renode.Peripherals.Miscellaneous
{
    public class DDR_CSR_APB_20002000 : IDoubleWordPeripheral, IKnownSize
    {
        private ulong TEMP0 = 0x000AC7E1;
        private ulong TEMP1 = 0x00000000;
        private ulong CLOCK_CONFIG_CR = 0x00000010;
        private ulong RTC_CLOCK_CR = 0x00010064;
        private ulong FABRIC_RESET_CR = 0x00000000;
        private ulong BOOT_FAIL_CR = 0x00000000;
        private ulong MSS_RESET_CR = 0x00000000;
        private ulong CONFIG_LOCK_CR = 0x00000000;
        private ulong RESET_SR = 0x000001FF;
        private ulong DEVICE_STATUS = 0x00000000;
        private ulong MSS_BUILD = 0x00000000;
        private ulong FAB_INTEN_U54_1 = 0x00000000;
        private ulong FAB_INTEN_U54_2 = 0x00000000;
        private ulong FAB_INTEN_U54_3 = 0x00000000;
        private ulong FAB_INTEN_U54_4 = 0x00000000;
        private ulong FAB_INTEN_MISC = 0x00000000;
        private ulong GPIO_INTERRUPT_FAB_CR = 0x00000000;
        private ulong APBBUS_CR = 0x00000000;
        private ulong SUBBLK_CLOCK_CR = 0x00000001;
        private ulong SOFT_RESET_CR = 0x3FFFFFFE;
        private ulong AHBAXI_CR = 0x0000FFFF;
        private ulong AHBAPB_CR = 0x00000000;
        private ulong DFIAPB_CR = 0x00000002;
        private ulong GPIO_CR = 0x000F0703;
        private ulong MAC0_CR = 0x00000000;
        private ulong MAC1_CR = 0x00000000;
        private ulong USB_CR = 0x00000004;
        private ulong MESH_CR = 0x0000004E;
        private ulong MESH_SEED_CR = 0xC7005EED;
        private ulong ENVM_CR = 0x4005004F;
        private ulong RESERVED_BC = 0x00000000;
        private ulong QOS_PERIPHERAL_CR = 0x00000000;
        private ulong QOS_CPLEXIO_CR = 0x00000000;
        private ulong QOS_CPLEXDDR_CR = 0x00000000;
        private ulong MPU_VIOLATION_SR = 0x00000000;
        private ulong MPU_VIOLATION_INTEN_CR = 0x00000000;
        private ulong SW_FAIL_ADDR0_CR = 0x00000000;
        private ulong SW_FAIL_ADDR1_CR = 0x00000000;
        private ulong EDAC_SR = 0x00000000;
        private ulong EDAC_INTEN_CR = 0x00000000;
        private ulong EDAC_CNT_MMC = 0x00000000;
        private ulong EDAC_CNT_DDRC = 0x00000000;
        private ulong EDAC_CNT_MAC0 = 0x00000000;
        private ulong EDAC_CNT_MAC1 = 0x00000000;
        private ulong EDAC_CNT_USB = 0x00000000;
        private ulong EDAC_CNT_CAN0 = 0x00000000;
        private ulong EDAC_CNT_CAN1 = 0x00000000;
        private ulong EDAC_INJECT_CR = 0x00000000;
        private ulong MAINTENANCE_INTEN_CR = 0x00000000;
        private ulong PLL_STATUS_INTEN_CR = 0x00000000;
        private ulong MAINTENANCE_INT_SR = 0x00000000;
        private ulong PLL_STATUS_SR = 0x00000000;
        private ulong CFM_TIMER_CR = 0x00000000;
        private ulong MISC_SR = 0x00000000;
        private ulong DLL_STATUS_CR = 0x00000000;
        private ulong DLL_STATUS_SR = 0x00000000;
        private ulong RAM_LIGHTSLEEP_CR = 0x00000000;
        private ulong RAM_DEEPSLEEP_CR = 0x00000000;
        private ulong RAM_SHUTDOWN_CR = 0x00000000;
        private ulong L2_SHUTDOWN_CR = 0x00000000;
        private ulong IOMUX0_CR = 0x00003FFF;
        private ulong IOMUX1_CR = 0xFFFFFFFF;
        private ulong IOMUX2_CR = 0x00FFFFFF;
        private ulong IOMUX3_CR = 0xFFFFFFFF;
        private ulong IOMUX4_CR = 0xFFFFFFFF;
        private ulong IOMUX5_CR = 0xFFFFFFFF;
        private ulong IOMUX6_CR = 0x00000000;
        private ulong MSSIO_BANK4_IO_CFG_0_1_CR = 0x08280828;
        private ulong MSSIO_BANK4_IO_CFG_2_3_CR = 0x08280828;
        private ulong MSSIO_BANK4_IO_CFG_4_5_CR = 0x08280828;
        private ulong MSSIO_BANK4_IO_CFG_6_7_CR = 0x08280828;
        private ulong MSSIO_BANK4_IO_CFG_8_9_CR = 0x08280828;
        private ulong MSSIO_BANK4_IO_CFG_10_11_CR = 0x08280828;
        private ulong MSSIO_BANK4_IO_CFG_12_13_CR = 0x08280828;
        private ulong MSSIO_BANK2_IO_CFG_0_1_CR = 0x08280828;
        private ulong MSSIO_BANK2_IO_CFG_2_3_CR = 0x08280828;
        private ulong MSSIO_BANK2_IO_CFG_4_5_CR = 0x08280828;
        private ulong MSSIO_BANK2_IO_CFG_6_7_CR = 0x08280828;
        private ulong MSSIO_BANK2_IO_CFG_8_9_CR = 0x08280828;
        private ulong MSSIO_BANK2_IO_CFG_10_11_CR = 0x08280828;
        private ulong MSSIO_BANK2_IO_CFG_12_13_CR = 0x08280828;
        private ulong MSSIO_BANK2_IO_CFG_14_15_CR = 0x08280828;
        private ulong MSSIO_BANK2_IO_CFG_16_17_CR = 0x08280828;
        private ulong MSSIO_BANK2_IO_CFG_18_19_CR = 0x08280828;
        private ulong MSSIO_BANK2_IO_CFG_20_21_CR = 0x08280828;
        private ulong MSSIO_BANK2_IO_CFG_22_23_CR = 0x08280828;
        private ulong MSS_SPARE0_CR = 0x00000000;
        private ulong MSS_SPARE1_CR = 0x00000000;
        private ulong MSS_SPARE0_SR = 0x00000000;
        private ulong MSS_SPARE1_SR = 0x00000000;
        private ulong MSS_SPARE2_SR = 0x00000000;
        private ulong MSS_SPARE3_SR = 0x00000000;
        private ulong MSS_SPARE4_SR = 0x00000000;
        private ulong MSS_SPARE5_SR = 0x00000000;
        private ulong SPARE_REGISTER_RW = 0x00000000;
        private ulong SPARE_REGISTER_W1P = 0x00000000;
        private ulong SPARE_REGISTER_RO = 0x00000000;
        private ulong SPARE_PERIM_RW = 0x00000000;
        private ulong SPARE_FIC = 0x00000000;

        public uint ReadDoubleWord(long offset)
        {
            ulong value = 0x0u;
            switch(offset)
            {
                case 0x000:
                    value = TEMP0;
                    break;
                case 0x004:
                    value = TEMP1;
                    break;
                case 0x008:
                    value = CLOCK_CONFIG_CR;
                    break;
                case 0x00C:
                    value = RTC_CLOCK_CR;
                    break;
                case 0x010:
                    value = FABRIC_RESET_CR;
                    break;
                case 0x014:
                    value = BOOT_FAIL_CR;
                    break;
                case 0x018:
                    value = MSS_RESET_CR;
                    break;
                case 0x01C:
                    value = CONFIG_LOCK_CR;
                    break;
                case 0x020:
                    value = RESET_SR;
                    break;
                case 0x024:
                    value = DEVICE_STATUS;
                    break;
                case 0x028:
                    value = MSS_BUILD;
                    break;
                case 0x040:
                    value = FAB_INTEN_U54_1;
                    break;
                case 0x044:
                    value = FAB_INTEN_U54_2;
                    break;
                case 0x048:
                    value = FAB_INTEN_U54_3;
                    break;
                case 0x04C:
                    value = FAB_INTEN_U54_4;
                    break;
                case 0x050:
                    value = FAB_INTEN_MISC;
                    break;
                case 0x054:
                    value = GPIO_INTERRUPT_FAB_CR;
                    break;
                case 0x080:
                    value = APBBUS_CR;
                    break;
                case 0x084:
                    value = SUBBLK_CLOCK_CR;
                    break;
                case 0x088:
                    value = SOFT_RESET_CR;
                    break;
                case 0x08C:
                    value = AHBAXI_CR;
                    break;
                case 0x090:
                    value = AHBAPB_CR;
                    break;
                case 0x098:
                    value = DFIAPB_CR;
                    break;
                case 0x09C:
                    value = GPIO_CR;
                    break;
                case 0x0A4:
                    value = MAC0_CR;
                    break;
                case 0x0A8:
                    value = MAC1_CR;
                    break;
                case 0x0AC:
                    value = USB_CR;
                    break;
                case 0x0B0:
                    value = MESH_CR;
                    break;
                case 0x0B4:
                    value = MESH_SEED_CR;
                    break;
                case 0x0B8:
                    value = ENVM_CR;
                    break;
                case 0x0BC:
                    value = RESERVED_BC;
                    break;
                case 0x0C0:
                    value = QOS_PERIPHERAL_CR;
                    break;
                case 0x0C4:
                    value = QOS_CPLEXIO_CR;
                    break;
                case 0x0C8:
                    value = QOS_CPLEXDDR_CR;
                    break;
                case 0x0F0:
                    value = MPU_VIOLATION_SR;
                    break;
                case 0x0F4:
                    value = MPU_VIOLATION_INTEN_CR;
                    break;
                case 0x0F8:
                    value = SW_FAIL_ADDR0_CR;
                    break;
                case 0x0FC:
                    value = SW_FAIL_ADDR1_CR;
                    break;
                case 0x100:
                    value = EDAC_SR;
                    break;
                case 0x104:
                    value = EDAC_INTEN_CR;
                    break;
                case 0x108:
                    value = EDAC_CNT_MMC;
                    break;
                case 0x10C:
                    value = EDAC_CNT_DDRC;
                    break;
                case 0x110:
                    value = EDAC_CNT_MAC0;
                    break;
                case 0x114:
                    value = EDAC_CNT_MAC1;
                    break;
                case 0x118:
                    value = EDAC_CNT_USB;
                    break;
                case 0x11C:
                    value = EDAC_CNT_CAN0;
                    break;
                case 0x120:
                    value = EDAC_CNT_CAN1;
                    break;
                case 0x124:
                    value = EDAC_INJECT_CR;
                    break;
                case 0x140:
                    value = MAINTENANCE_INTEN_CR;
                    break;
                case 0x144:
                    value = PLL_STATUS_INTEN_CR;
                    break;
                case 0x148:
                    value = MAINTENANCE_INT_SR;
                    break;
                case 0x14C:
                    value = PLL_STATUS_SR;
                    break;
                case 0x150:
                    value = CFM_TIMER_CR;
                    break;
                case 0x154:
                    value = MISC_SR;
                    break;
                case 0x158:
                    value = DLL_STATUS_CR;
                    break;
                case 0x15C:
                    value = DLL_STATUS_SR;
                    break;
                case 0x168:
                    value = RAM_LIGHTSLEEP_CR;
                    break;
                case 0x16C:
                    value = RAM_DEEPSLEEP_CR;
                    break;
                case 0x170:
                    value = RAM_SHUTDOWN_CR;
                    break;
                case 0x174:
                    value = L2_SHUTDOWN_CR;
                    break;
                case 0x200:
                    value = IOMUX0_CR;
                    break;
                case 0x204:
                    value = IOMUX1_CR;
                    break;
                case 0x208:
                    value = IOMUX2_CR;
                    break;
                case 0x20C:
                    value = IOMUX3_CR;
                    break;
                case 0x210:
                    value = IOMUX4_CR;
                    break;
                case 0x214:
                    value = IOMUX5_CR;
                    break;
                case 0x218:
                    value = IOMUX6_CR;
                    break;
                case 0x234:
                    value = MSSIO_BANK4_IO_CFG_0_1_CR;
                    break;
                case 0x238:
                    value = MSSIO_BANK4_IO_CFG_2_3_CR;
                    break;
                case 0x23C:
                    value = MSSIO_BANK4_IO_CFG_4_5_CR;
                    break;
                case 0x240:
                    value = MSSIO_BANK4_IO_CFG_6_7_CR;
                    break;
                case 0x244:
                    value = MSSIO_BANK4_IO_CFG_8_9_CR;
                    break;
                case 0x248:
                    value = MSSIO_BANK4_IO_CFG_10_11_CR;
                    break;
                case 0x24C:
                    value = MSSIO_BANK4_IO_CFG_12_13_CR;
                    break;
                case 0x254:
                    value = MSSIO_BANK2_IO_CFG_0_1_CR;
                    break;
                case 0x258:
                    value = MSSIO_BANK2_IO_CFG_2_3_CR;
                    break;
                case 0x25C:
                    value = MSSIO_BANK2_IO_CFG_4_5_CR;
                    break;
                case 0x260:
                    value = MSSIO_BANK2_IO_CFG_6_7_CR;
                    break;
                case 0x264:
                    value = MSSIO_BANK2_IO_CFG_8_9_CR;
                    break;
                case 0x268:
                    value = MSSIO_BANK2_IO_CFG_10_11_CR;
                    break;
                case 0x26C:
                    value = MSSIO_BANK2_IO_CFG_12_13_CR;
                    break;
                case 0x270:
                    value = MSSIO_BANK2_IO_CFG_14_15_CR;
                    break;
                case 0x274:
                    value = MSSIO_BANK2_IO_CFG_16_17_CR;
                    break;
                case 0x278:
                    value = MSSIO_BANK2_IO_CFG_18_19_CR;
                    break;
                case 0x27C:
                    value = MSSIO_BANK2_IO_CFG_20_21_CR;
                    break;
                case 0x280:
                    value = MSSIO_BANK2_IO_CFG_22_23_CR;
                    break;
                case 0x2A8:
                    value = MSS_SPARE0_CR;
                    break;
                case 0x2AC:
                    value = MSS_SPARE1_CR;
                    break;
                case 0x2B0:
                    value = MSS_SPARE0_SR;
                    break;
                case 0x2B4:
                    value = MSS_SPARE1_SR;
                    break;
                case 0x2B8:
                    value = MSS_SPARE2_SR;
                    break;
                case 0x2BC:
                    value = MSS_SPARE3_SR;
                    break;
                case 0x2C0:
                    value = MSS_SPARE4_SR;
                    break;
                case 0x2C4:
                    value = MSS_SPARE5_SR;
                    break;
                case 0x2D0:
                    value = SPARE_REGISTER_RW;
                    break;
                case 0x2D4:
                    value = SPARE_REGISTER_W1P;
                    break;
                case 0x2D8:
                    value = SPARE_REGISTER_RO;
                    break;
                case 0x2DC:
                    value = SPARE_PERIM_RW;
                    break;
                case 0x2E0:
                    value = SPARE_FIC;
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
                    TEMP0 =  value;
                    break;
                case 0x004:
                    TEMP1 =  value;
                    break;
                case 0x008:
                    CLOCK_CONFIG_CR =  value;
                    break;
                case 0x00C:
                    RTC_CLOCK_CR =  value;
                    break;
                case 0x010:
                    FABRIC_RESET_CR =  value;
                    break;
                case 0x014:
                    BOOT_FAIL_CR =  value;
                    break;
                case 0x018:
                    MSS_RESET_CR =  value;
                    break;
                case 0x01C:
                    CONFIG_LOCK_CR =  value;
                    break;
                case 0x020:
                    RESET_SR =  value;
                    break;
                case 0x024:
                    DEVICE_STATUS =  value;
                    break;
                case 0x028:
                    MSS_BUILD =  value;
                    break;
                case 0x040:
                    FAB_INTEN_U54_1 =  value;
                    break;
                case 0x044:
                    FAB_INTEN_U54_2 =  value;
                    break;
                case 0x048:
                    FAB_INTEN_U54_3 =  value;
                    break;
                case 0x04C:
                    FAB_INTEN_U54_4 =  value;
                    break;
                case 0x050:
                    FAB_INTEN_MISC =  value;
                    break;
                case 0x054:
                    GPIO_INTERRUPT_FAB_CR =  value;
                    break;
                case 0x080:
                    APBBUS_CR =  value;
                    break;
                case 0x084:
                    SUBBLK_CLOCK_CR =  value;
                    break;
                case 0x088:
                    SOFT_RESET_CR =  value;
                    break;
                case 0x08C:
                    AHBAXI_CR =  value;
                    break;
                case 0x090:
                    AHBAPB_CR =  value;
                    break;
                case 0x098:
                    DFIAPB_CR =  value;
                    break;
                case 0x09C:
                    GPIO_CR =  value;
                    break;
                case 0x0A4:
                    MAC0_CR =  value;
                    break;
                case 0x0A8:
                    MAC1_CR =  value;
                    break;
                case 0x0AC:
                    USB_CR =  value;
                    break;
                case 0x0B0:
                    MESH_CR =  value;
                    break;
                case 0x0B4:
                    MESH_SEED_CR =  value;
                    break;
                case 0x0B8:
                    ENVM_CR =  value;
                    break;
                case 0x0BC:
                    RESERVED_BC =  value;
                    break;
                case 0x0C0:
                    QOS_PERIPHERAL_CR =  value;
                    break;
                case 0x0C4:
                    QOS_CPLEXIO_CR =  value;
                    break;
                case 0x0C8:
                    QOS_CPLEXDDR_CR =  value;
                    break;
                case 0x0F0:
                    MPU_VIOLATION_SR =  value;
                    break;
                case 0x0F4:
                    MPU_VIOLATION_INTEN_CR =  value;
                    break;
                case 0x0F8:
                    SW_FAIL_ADDR0_CR =  value;
                    break;
                case 0x0FC:
                    SW_FAIL_ADDR1_CR =  value;
                    break;
                case 0x100:
                    EDAC_SR =  value;
                    break;
                case 0x104:
                    EDAC_INTEN_CR =  value;
                    break;
                case 0x108:
                    EDAC_CNT_MMC =  value;
                    break;
                case 0x10C:
                    EDAC_CNT_DDRC =  value;
                    break;
                case 0x110:
                    EDAC_CNT_MAC0 =  value;
                    break;
                case 0x114:
                    EDAC_CNT_MAC1 =  value;
                    break;
                case 0x118:
                    EDAC_CNT_USB =  value;
                    break;
                case 0x11C:
                    EDAC_CNT_CAN0 =  value;
                    break;
                case 0x120:
                    EDAC_CNT_CAN1 =  value;
                    break;
                case 0x124:
                    EDAC_INJECT_CR =  value;
                    break;
                case 0x140:
                    MAINTENANCE_INTEN_CR =  value;
                    break;
                case 0x144:
                    PLL_STATUS_INTEN_CR =  value;
                    break;
                case 0x148:
                    MAINTENANCE_INT_SR =  value;
                    break;
                case 0x14C:
                    PLL_STATUS_SR =  value;
                    break;
                case 0x150:
                    CFM_TIMER_CR =  value;
                    break;
                case 0x154:
                    MISC_SR =  value;
                    break;
                case 0x158:
                    DLL_STATUS_CR =  value;
                    break;
                case 0x15C:
                    DLL_STATUS_SR =  value;
                    break;
                case 0x168:
                    RAM_LIGHTSLEEP_CR =  value;
                    break;
                case 0x16C:
                    RAM_DEEPSLEEP_CR =  value;
                    break;
                case 0x170:
                    RAM_SHUTDOWN_CR =  value;
                    break;
                case 0x174:
                    L2_SHUTDOWN_CR =  value;
                    break;
                case 0x200:
                    IOMUX0_CR =  value;
                    break;
                case 0x204:
                    IOMUX1_CR =  value;
                    break;
                case 0x208:
                    IOMUX2_CR =  value;
                    break;
                case 0x20C:
                    IOMUX3_CR =  value;
                    break;
                case 0x210:
                    IOMUX4_CR =  value;
                    break;
                case 0x214:
                    IOMUX5_CR =  value;
                    break;
                case 0x218:
                    IOMUX6_CR =  value;
                    break;
                case 0x234:
                    MSSIO_BANK4_IO_CFG_0_1_CR =  value;
                    break;
                case 0x238:
                    MSSIO_BANK4_IO_CFG_2_3_CR =  value;
                    break;
                case 0x23C:
                    MSSIO_BANK4_IO_CFG_4_5_CR =  value;
                    break;
                case 0x240:
                    MSSIO_BANK4_IO_CFG_6_7_CR =  value;
                    break;
                case 0x244:
                    MSSIO_BANK4_IO_CFG_8_9_CR =  value;
                    break;
                case 0x248:
                    MSSIO_BANK4_IO_CFG_10_11_CR =  value;
                    break;
                case 0x24C:
                    MSSIO_BANK4_IO_CFG_12_13_CR =  value;
                    break;
                case 0x254:
                    MSSIO_BANK2_IO_CFG_0_1_CR =  value;
                    break;
                case 0x258:
                    MSSIO_BANK2_IO_CFG_2_3_CR =  value;
                    break;
                case 0x25C:
                    MSSIO_BANK2_IO_CFG_4_5_CR =  value;
                    break;
                case 0x260:
                    MSSIO_BANK2_IO_CFG_6_7_CR =  value;
                    break;
                case 0x264:
                    MSSIO_BANK2_IO_CFG_8_9_CR =  value;
                    break;
                case 0x268:
                    MSSIO_BANK2_IO_CFG_10_11_CR =  value;
                    break;
                case 0x26C:
                    MSSIO_BANK2_IO_CFG_12_13_CR =  value;
                    break;
                case 0x270:
                    MSSIO_BANK2_IO_CFG_14_15_CR =  value;
                    break;
                case 0x274:
                    MSSIO_BANK2_IO_CFG_16_17_CR =  value;
                    break;
                case 0x278:
                    MSSIO_BANK2_IO_CFG_18_19_CR =  value;
                    break;
                case 0x27C:
                    MSSIO_BANK2_IO_CFG_20_21_CR =  value;
                    break;
                case 0x280:
                    MSSIO_BANK2_IO_CFG_22_23_CR =  value;
                    break;
                case 0x2A8:
                    MSS_SPARE0_CR =  value;
                    break;
                case 0x2AC:
                    MSS_SPARE1_CR =  value;
                    break;
                case 0x2B0:
                    MSS_SPARE0_SR =  value;
                    break;
                case 0x2B4:
                    MSS_SPARE1_SR =  value;
                    break;
                case 0x2B8:
                    MSS_SPARE2_SR =  value;
                    break;
                case 0x2BC:
                    MSS_SPARE3_SR =  value;
                    break;
                case 0x2C0:
                    MSS_SPARE4_SR =  value;
                    break;
                case 0x2C4:
                    MSS_SPARE5_SR =  value;
                    break;
                case 0x2D0:
                    SPARE_REGISTER_RW =  value;
                    break;
                case 0x2D4:
                    SPARE_REGISTER_W1P =  value;
                    break;
                case 0x2D8:
                    SPARE_REGISTER_RO =  value;
                    break;
                case 0x2DC:
                    SPARE_PERIM_RW =  value;
                    break;
                case 0x2E0:
                    SPARE_FIC =  value;
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


