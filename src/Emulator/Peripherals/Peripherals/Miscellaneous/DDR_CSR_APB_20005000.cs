using Antmicro.Renode.Peripherals.Bus;
using Antmicro.Renode.Logging;

namespace Antmicro.Renode.Peripherals.Miscellaneous
{
    public class DDR_CSR_APB_20005000 : IDoubleWordPeripheral, IKnownSize
    {
        private ulong PMPCFG_FIC0_0 = 0x00000000000001FF;
        private ulong PMPCFG_FIC0_1 = 0x00000000000001FF;
        private ulong PMPCFG_FIC0_2 = 0x00000000000001FF;
        private ulong PMPCFG_FIC0_3 = 0x00000000000001FF;
        private ulong PMPCFG_FIC0_4 = 0x00000000000001FF;
        private ulong PMPCFG_FIC0_5 = 0x00000000000001FF;
        private ulong PMPCFG_FIC0_6 = 0x00000000000001FF;
        private ulong PMPCFG_FIC0_7 = 0x00000000000001FF;
        private ulong PMPCFG_FIC0_8 = 0x00000000000001FF;
        private ulong PMPCFG_FIC0_9 = 0x00000000000001FF;
        private ulong PMPCFG_FIC0_10 = 0x00000000000001FF;
        private ulong PMPCFG_FIC0_11 = 0x00000000000001FF;
        private ulong PMPCFG_FIC0_12 = 0x00000000000001FF;
        private ulong PMPCFG_FIC0_13 = 0x00000000000001FF;
        private ulong PMPCFG_FIC0_14 = 0x00000000000001FF;
        private ulong PMPCFG_FIC0_15 = 0x00000000000001FF;
        private ulong STATUS_FIC0 = 0x0000000000000000;
        private ulong PMPCFG_FIC1_0 = 0x00000000000001FF;
        private ulong PMPCFG_FIC1_1 = 0x00000000000001FF;
        private ulong PMPCFG_FIC1_2 = 0x00000000000001FF;
        private ulong PMPCFG_FIC1_3 = 0x00000000000001FF;
        private ulong PMPCFG_FIC1_4 = 0x00000000000001FF;
        private ulong PMPCFG_FIC1_5 = 0x00000000000001FF;
        private ulong PMPCFG_FIC1_6 = 0x00000000000001FF;
        private ulong PMPCFG_FIC1_7 = 0x00000000000001FF;
        private ulong PMPCFG_FIC1_8 = 0x00000000000001FF;
        private ulong PMPCFG_FIC1_9 = 0x00000000000001FF;
        private ulong PMPCFG_FIC1_10 = 0x00000000000001FF;
        private ulong PMPCFG_FIC1_11 = 0x00000000000001FF;
        private ulong PMPCFG_FIC1_12 = 0x00000000000001FF;
        private ulong PMPCFG_FIC1_13 = 0x00000000000001FF;
        private ulong PMPCFG_FIC1_14 = 0x00000000000001FF;
        private ulong PMPCFG_FIC1_15 = 0x00000000000001FF;
        private ulong STATUS_FIC1 = 0x0000000000000000;
        private ulong PMPCFG_FIC2_0 = 0x00000000000001FF;
        private ulong PMPCFG_FIC2_1 = 0x00000000000001FF;
        private ulong PMPCFG_FIC2_2 = 0x00000000000001FF;
        private ulong PMPCFG_FIC2_3 = 0x00000000000001FF;
        private ulong PMPCFG_FIC2_4 = 0x00000000000001FF;
        private ulong PMPCFG_FIC2_5 = 0x00000000000001FF;
        private ulong PMPCFG_FIC2_6 = 0x00000000000001FF;
        private ulong PMPCFG_FIC2_7 = 0x00000000000001FF;
        private ulong STATUS_FIC2 = 0x0000000000000000;
        private ulong PMPCFG_CRYPTO_0 = 0x00000000000001FF;
        private ulong PMPCFG_CRYPTO_1 = 0x00000000000001FF;
        private ulong PMPCFG_CRYPTO_2 = 0x00000000000001FF;
        private ulong PMPCFG_CRYPTO_3 = 0x00000000000001FF;
        private ulong STATUS_CRYPTO = 0x0000000000000000;
        private ulong PMPCFG_ETHERNET0_0 = 0x00000000000001FF;
        private ulong PMPCFG_ETHERNET0_1 = 0x00000000000001FF;
        private ulong PMPCFG_ETHERNET0_2 = 0x00000000000001FF;
        private ulong PMPCFG_ETHERNET0_3 = 0x00000000000001FF;
        private ulong PMPCFG_ETHERNET0_4 = 0x00000000000001FF;
        private ulong PMPCFG_ETHERNET0_5 = 0x00000000000001FF;
        private ulong PMPCFG_ETHERNET0_6 = 0x00000000000001FF;
        private ulong PMPCFG_ETHERNET0_7 = 0x00000000000001FF;
        private ulong STATUS_ETHERNET0 = 0x0000000000000000;
        private ulong PMPCFG_ETHERNET1_0 = 0x00000000000001FF;
        private ulong PMPCFG_ETHERNET1_1 = 0x00000000000001FF;
        private ulong PMPCFG_ETHERNET1_2 = 0x00000000000001FF;
        private ulong PMPCFG_ETHERNET1_3 = 0x00000000000001FF;
        private ulong PMPCFG_ETHERNET1_4 = 0x00000000000001FF;
        private ulong PMPCFG_ETHERNET1_5 = 0x00000000000001FF;
        private ulong PMPCFG_ETHERNET1_6 = 0x00000000000001FF;
        private ulong PMPCFG_ETHERNET1_7 = 0x00000000000001FF;
        private ulong STATUS_ETHERNET1 = 0x0000000000000000;
        private ulong PMPCFG_USB_0 = 0x00000000000001FF;
        private ulong PMPCFG_USB_1 = 0x00000000000001FF;
        private ulong PMPCFG_USB_2 = 0x00000000000001FF;
        private ulong PMPCFG_USB_3 = 0x00000000000001FF;
        private ulong STATUS_USB = 0x0000000000000000;
        private ulong PMPCFG_MMC_0 = 0x00000000000001FF;
        private ulong PMPCFG_MMC_1 = 0x00000000000001FF;
        private ulong PMPCFG_MMC_2 = 0x00000000000001FF;
        private ulong PMPCFG_MMC_3 = 0x00000000000001FF;
        private ulong STATUS_MMC = 0x0000000000000000;
        private ulong PMPCFG_SCB_0 = 0x00000000000001FF;
        private ulong PMPCFG_SCB_1 = 0x00000000000001FF;
        private ulong PMPCFG_SCB_2 = 0x00000000000001FF;
        private ulong PMPCFG_SCB_3 = 0x00000000000001FF;
        private ulong PMPCFG_SCB_4 = 0x00000000000001FF;
        private ulong PMPCFG_SCB_5 = 0x00000000000001FF;
        private ulong PMPCFG_SCB_6 = 0x00000000000001FF;
        private ulong PMPCFG_SCB_7 = 0x00000000000001FF;
        private ulong STATUS_SCB = 0x0000000000000000;
        private ulong PMPCFG_TRACE_0 = 0x00000000000001FF;
        private ulong PMPCFG_TRACE_1 = 0x00000000000001FF;
        private ulong STATUS_TRACE = 0x0000000000000000;
        private ulong SEG_REG0 = 0x0000000000000000;
        private ulong SEG_REG1 = 0x0000000000000000;
        private ulong SEG_REG2 = 0x0000000000000000;
        private ulong SEG_REG3 = 0x0000000000000000;
        private ulong SEG_REG4 = 0x0000000000000000;
        private ulong SEG_REG5 = 0x0000000000000000;
        private ulong SEG_REG6 = 0x0000000000000000;

        public uint ReadDoubleWord(long offset)
        {
            ulong value = 0x0u;
            switch(offset)
            {
                case 0x000:
                    value = PMPCFG_FIC0_0;
                    break;
                case 0x008:
                    value = PMPCFG_FIC0_1;
                    break;
                case 0x010:
                    value = PMPCFG_FIC0_2;
                    break;
                case 0x018:
                    value = PMPCFG_FIC0_3;
                    break;
                case 0x020:
                    value = PMPCFG_FIC0_4;
                    break;
                case 0x028:
                    value = PMPCFG_FIC0_5;
                    break;
                case 0x030:
                    value = PMPCFG_FIC0_6;
                    break;
                case 0x038:
                    value = PMPCFG_FIC0_7;
                    break;
                case 0x040:
                    value = PMPCFG_FIC0_8;
                    break;
                case 0x048:
                    value = PMPCFG_FIC0_9;
                    break;
                case 0x050:
                    value = PMPCFG_FIC0_10;
                    break;
                case 0x058:
                    value = PMPCFG_FIC0_11;
                    break;
                case 0x060:
                    value = PMPCFG_FIC0_12;
                    break;
                case 0x068:
                    value = PMPCFG_FIC0_13;
                    break;
                case 0x070:
                    value = PMPCFG_FIC0_14;
                    break;
                case 0x078:
                    value = PMPCFG_FIC0_15;
                    break;
                case 0x080:
                    value = STATUS_FIC0;
                    break;
                case 0x100:
                    value = PMPCFG_FIC1_0;
                    break;
                case 0x108:
                    value = PMPCFG_FIC1_1;
                    break;
                case 0x110:
                    value = PMPCFG_FIC1_2;
                    break;
                case 0x118:
                    value = PMPCFG_FIC1_3;
                    break;
                case 0x120:
                    value = PMPCFG_FIC1_4;
                    break;
                case 0x128:
                    value = PMPCFG_FIC1_5;
                    break;
                case 0x130:
                    value = PMPCFG_FIC1_6;
                    break;
                case 0x138:
                    value = PMPCFG_FIC1_7;
                    break;
                case 0x140:
                    value = PMPCFG_FIC1_8;
                    break;
                case 0x148:
                    value = PMPCFG_FIC1_9;
                    break;
                case 0x150:
                    value = PMPCFG_FIC1_10;
                    break;
                case 0x158:
                    value = PMPCFG_FIC1_11;
                    break;
                case 0x160:
                    value = PMPCFG_FIC1_12;
                    break;
                case 0x168:
                    value = PMPCFG_FIC1_13;
                    break;
                case 0x170:
                    value = PMPCFG_FIC1_14;
                    break;
                case 0x178:
                    value = PMPCFG_FIC1_15;
                    break;
                case 0x180:
                    value = STATUS_FIC1;
                    break;
                case 0x200:
                    value = PMPCFG_FIC2_0;
                    break;
                case 0x208:
                    value = PMPCFG_FIC2_1;
                    break;
                case 0x210:
                    value = PMPCFG_FIC2_2;
                    break;
                case 0x218:
                    value = PMPCFG_FIC2_3;
                    break;
                case 0x220:
                    value = PMPCFG_FIC2_4;
                    break;
                case 0x228:
                    value = PMPCFG_FIC2_5;
                    break;
                case 0x230:
                    value = PMPCFG_FIC2_6;
                    break;
                case 0x238:
                    value = PMPCFG_FIC2_7;
                    break;
                case 0x280:
                    value = STATUS_FIC2;
                    break;
                case 0x300:
                    value = PMPCFG_CRYPTO_0;
                    break;
                case 0x308:
                    value = PMPCFG_CRYPTO_1;
                    break;
                case 0x310:
                    value = PMPCFG_CRYPTO_2;
                    break;
                case 0x318:
                    value = PMPCFG_CRYPTO_3;
                    break;
                case 0x380:
                    value = STATUS_CRYPTO;
                    break;
                case 0x400:
                    value = PMPCFG_ETHERNET0_0;
                    break;
                case 0x408:
                    value = PMPCFG_ETHERNET0_1;
                    break;
                case 0x410:
                    value = PMPCFG_ETHERNET0_2;
                    break;
                case 0x418:
                    value = PMPCFG_ETHERNET0_3;
                    break;
                case 0x420:
                    value = PMPCFG_ETHERNET0_4;
                    break;
                case 0x428:
                    value = PMPCFG_ETHERNET0_5;
                    break;
                case 0x430:
                    value = PMPCFG_ETHERNET0_6;
                    break;
                case 0x438:
                    value = PMPCFG_ETHERNET0_7;
                    break;
                case 0x480:
                    value = STATUS_ETHERNET0;
                    break;
                case 0x500:
                    value = PMPCFG_ETHERNET1_0;
                    break;
                case 0x508:
                    value = PMPCFG_ETHERNET1_1;
                    break;
                case 0x510:
                    value = PMPCFG_ETHERNET1_2;
                    break;
                case 0x518:
                    value = PMPCFG_ETHERNET1_3;
                    break;
                case 0x520:
                    value = PMPCFG_ETHERNET1_4;
                    break;
                case 0x528:
                    value = PMPCFG_ETHERNET1_5;
                    break;
                case 0x530:
                    value = PMPCFG_ETHERNET1_6;
                    break;
                case 0x538:
                    value = PMPCFG_ETHERNET1_7;
                    break;
                case 0x580:
                    value = STATUS_ETHERNET1;
                    break;
                case 0x600:
                    value = PMPCFG_USB_0;
                    break;
                case 0x608:
                    value = PMPCFG_USB_1;
                    break;
                case 0x610:
                    value = PMPCFG_USB_2;
                    break;
                case 0x618:
                    value = PMPCFG_USB_3;
                    break;
                case 0x680:
                    value = STATUS_USB;
                    break;
                case 0x700:
                    value = PMPCFG_MMC_0;
                    break;
                case 0x708:
                    value = PMPCFG_MMC_1;
                    break;
                case 0x710:
                    value = PMPCFG_MMC_2;
                    break;
                case 0x718:
                    value = PMPCFG_MMC_3;
                    break;
                case 0x780:
                    value = STATUS_MMC;
                    break;
                case 0x800:
                    value = PMPCFG_SCB_0;
                    break;
                case 0x808:
                    value = PMPCFG_SCB_1;
                    break;
                case 0x810:
                    value = PMPCFG_SCB_2;
                    break;
                case 0x818:
                    value = PMPCFG_SCB_3;
                    break;
                case 0x820:
                    value = PMPCFG_SCB_4;
                    break;
                case 0x828:
                    value = PMPCFG_SCB_5;
                    break;
                case 0x830:
                    value = PMPCFG_SCB_6;
                    break;
                case 0x838:
                    value = PMPCFG_SCB_7;
                    break;
                case 0x880:
                    value = STATUS_SCB;
                    break;
                case 0x900:
                    value = PMPCFG_TRACE_0;
                    break;
                case 0x908:
                    value = PMPCFG_TRACE_1;
                    break;
                case 0x980:
                    value = STATUS_TRACE;
                    break;
                case 0xD00:
                    value = SEG_REG0;
                    break;
                case 0xD08:
                    value = SEG_REG1;
                    break;
                case 0xD10:
                    value = SEG_REG2;
                    break;
                case 0xD18:
                    value = SEG_REG3;
                    break;
                case 0xD20:
                    value = SEG_REG4;
                    break;
                case 0xD28:
                    value = SEG_REG5;
                    break;
                case 0xD30:
                    value = SEG_REG6;
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
                    PMPCFG_FIC0_0 =  value;
                    break;
                case 0x008:
                    PMPCFG_FIC0_1 =  value;
                    break;
                case 0x010:
                    PMPCFG_FIC0_2 =  value;
                    break;
                case 0x018:
                    PMPCFG_FIC0_3 =  value;
                    break;
                case 0x020:
                    PMPCFG_FIC0_4 =  value;
                    break;
                case 0x028:
                    PMPCFG_FIC0_5 =  value;
                    break;
                case 0x030:
                    PMPCFG_FIC0_6 =  value;
                    break;
                case 0x038:
                    PMPCFG_FIC0_7 =  value;
                    break;
                case 0x040:
                    PMPCFG_FIC0_8 =  value;
                    break;
                case 0x048:
                    PMPCFG_FIC0_9 =  value;
                    break;
                case 0x050:
                    PMPCFG_FIC0_10 =  value;
                    break;
                case 0x058:
                    PMPCFG_FIC0_11 =  value;
                    break;
                case 0x060:
                    PMPCFG_FIC0_12 =  value;
                    break;
                case 0x068:
                    PMPCFG_FIC0_13 =  value;
                    break;
                case 0x070:
                    PMPCFG_FIC0_14 =  value;
                    break;
                case 0x078:
                    PMPCFG_FIC0_15 =  value;
                    break;
                case 0x080:
                    STATUS_FIC0 =  value;
                    break;
                case 0x100:
                    PMPCFG_FIC1_0 =  value;
                    break;
                case 0x108:
                    PMPCFG_FIC1_1 =  value;
                    break;
                case 0x110:
                    PMPCFG_FIC1_2 =  value;
                    break;
                case 0x118:
                    PMPCFG_FIC1_3 =  value;
                    break;
                case 0x120:
                    PMPCFG_FIC1_4 =  value;
                    break;
                case 0x128:
                    PMPCFG_FIC1_5 =  value;
                    break;
                case 0x130:
                    PMPCFG_FIC1_6 =  value;
                    break;
                case 0x138:
                    PMPCFG_FIC1_7 =  value;
                    break;
                case 0x140:
                    PMPCFG_FIC1_8 =  value;
                    break;
                case 0x148:
                    PMPCFG_FIC1_9 =  value;
                    break;
                case 0x150:
                    PMPCFG_FIC1_10 =  value;
                    break;
                case 0x158:
                    PMPCFG_FIC1_11 =  value;
                    break;
                case 0x160:
                    PMPCFG_FIC1_12 =  value;
                    break;
                case 0x168:
                    PMPCFG_FIC1_13 =  value;
                    break;
                case 0x170:
                    PMPCFG_FIC1_14 =  value;
                    break;
                case 0x178:
                    PMPCFG_FIC1_15 =  value;
                    break;
                case 0x180:
                    STATUS_FIC1 =  value;
                    break;
                case 0x200:
                    PMPCFG_FIC2_0 =  value;
                    break;
                case 0x208:
                    PMPCFG_FIC2_1 =  value;
                    break;
                case 0x210:
                    PMPCFG_FIC2_2 =  value;
                    break;
                case 0x218:
                    PMPCFG_FIC2_3 =  value;
                    break;
                case 0x220:
                    PMPCFG_FIC2_4 =  value;
                    break;
                case 0x228:
                    PMPCFG_FIC2_5 =  value;
                    break;
                case 0x230:
                    PMPCFG_FIC2_6 =  value;
                    break;
                case 0x238:
                    PMPCFG_FIC2_7 =  value;
                    break;
                case 0x280:
                    STATUS_FIC2 =  value;
                    break;
                case 0x300:
                    PMPCFG_CRYPTO_0 =  value;
                    break;
                case 0x308:
                    PMPCFG_CRYPTO_1 =  value;
                    break;
                case 0x310:
                    PMPCFG_CRYPTO_2 =  value;
                    break;
                case 0x318:
                    PMPCFG_CRYPTO_3 =  value;
                    break;
                case 0x380:
                    STATUS_CRYPTO =  value;
                    break;
                case 0x400:
                    PMPCFG_ETHERNET0_0 =  value;
                    break;
                case 0x408:
                    PMPCFG_ETHERNET0_1 =  value;
                    break;
                case 0x410:
                    PMPCFG_ETHERNET0_2 =  value;
                    break;
                case 0x418:
                    PMPCFG_ETHERNET0_3 =  value;
                    break;
                case 0x420:
                    PMPCFG_ETHERNET0_4 =  value;
                    break;
                case 0x428:
                    PMPCFG_ETHERNET0_5 =  value;
                    break;
                case 0x430:
                    PMPCFG_ETHERNET0_6 =  value;
                    break;
                case 0x438:
                    PMPCFG_ETHERNET0_7 =  value;
                    break;
                case 0x480:
                    STATUS_ETHERNET0 =  value;
                    break;
                case 0x500:
                    PMPCFG_ETHERNET1_0 =  value;
                    break;
                case 0x508:
                    PMPCFG_ETHERNET1_1 =  value;
                    break;
                case 0x510:
                    PMPCFG_ETHERNET1_2 =  value;
                    break;
                case 0x518:
                    PMPCFG_ETHERNET1_3 =  value;
                    break;
                case 0x520:
                    PMPCFG_ETHERNET1_4 =  value;
                    break;
                case 0x528:
                    PMPCFG_ETHERNET1_5 =  value;
                    break;
                case 0x530:
                    PMPCFG_ETHERNET1_6 =  value;
                    break;
                case 0x538:
                    PMPCFG_ETHERNET1_7 =  value;
                    break;
                case 0x580:
                    STATUS_ETHERNET1 =  value;
                    break;
                case 0x600:
                    PMPCFG_USB_0 =  value;
                    break;
                case 0x608:
                    PMPCFG_USB_1 =  value;
                    break;
                case 0x610:
                    PMPCFG_USB_2 =  value;
                    break;
                case 0x618:
                    PMPCFG_USB_3 =  value;
                    break;
                case 0x680:
                    STATUS_USB =  value;
                    break;
                case 0x700:
                    PMPCFG_MMC_0 =  value;
                    break;
                case 0x708:
                    PMPCFG_MMC_1 =  value;
                    break;
                case 0x710:
                    PMPCFG_MMC_2 =  value;
                    break;
                case 0x718:
                    PMPCFG_MMC_3 =  value;
                    break;
                case 0x780:
                    STATUS_MMC =  value;
                    break;
                case 0x800:
                    PMPCFG_SCB_0 =  value;
                    break;
                case 0x808:
                    PMPCFG_SCB_1 =  value;
                    break;
                case 0x810:
                    PMPCFG_SCB_2 =  value;
                    break;
                case 0x818:
                    PMPCFG_SCB_3 =  value;
                    break;
                case 0x820:
                    PMPCFG_SCB_4 =  value;
                    break;
                case 0x828:
                    PMPCFG_SCB_5 =  value;
                    break;
                case 0x830:
                    PMPCFG_SCB_6 =  value;
                    break;
                case 0x838:
                    PMPCFG_SCB_7 =  value;
                    break;
                case 0x880:
                    STATUS_SCB =  value;
                    break;
                case 0x900:
                    PMPCFG_TRACE_0 =  value;
                    break;
                case 0x908:
                    PMPCFG_TRACE_1 =  value;
                    break;
                case 0x980:
                    STATUS_TRACE =  value;
                    break;
                case 0xD00:
                    SEG_REG0 =  value;
                    break;
                case 0xD08:
                    SEG_REG1 =  value;
                    break;
                case 0xD10:
                    SEG_REG2 =  value;
                    break;
                case 0xD18:
                    SEG_REG3 =  value;
                    break;
                case 0xD20:
                    SEG_REG4 =  value;
                    break;
                case 0xD28:
                    SEG_REG5 =  value;
                    break;
                case 0xD30:
                    SEG_REG6 =  value;
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


