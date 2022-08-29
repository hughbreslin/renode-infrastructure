using Antmicro.Renode.Peripherals.Bus;
using Antmicro.Renode.Logging;

namespace Antmicro.Renode.Peripherals.Miscellaneous
{
    public class DDR_CSR_APB_20086000 : IDoubleWordPeripheral, IKnownSize
    {
        private ulong CFG_ERROR_GROUP_SEL = 0x00000000;
        private ulong CFG_DATA_SEL = 0x00000000;
        private ulong CFG_TRIG_MODE = 0x00000000;
        private ulong CFG_POST_TRIG_CYCS = 0x00000000;
        private ulong CFG_TRIG_MASK = 0x00000000;
        private ulong CFG_EN_MASK = 0x00000000;
        private ulong MTC_ACQ_ADDR = 0x00000000;
        private ulong MTC_ACQ_CYCS_STORED = 0x00000000;
        private ulong MTC_ACQ_TRIG_DETECT = 0x00000000;
        private ulong MTC_ACQ_MEM_TRIG_ADDR = 0x00000000;
        private ulong MTC_ACQ_MEM_LAST_ADDR = 0x00000000;
        private ulong MTC_ACK = 0x00000000;
        private ulong CFG_TRIG_MT_ADDR_0 = 0x00000000;
        private ulong CFG_TRIG_MT_ADDR_1 = 0x00000000;
        private ulong CFG_TRIG_ERR_MASK_0 = 0x00000000;
        private ulong CFG_TRIG_ERR_MASK_1 = 0x00000000;
        private ulong CFG_TRIG_ERR_MASK_2 = 0x00000000;
        private ulong CFG_TRIG_ERR_MASK_3 = 0x00000000;
        private ulong CFG_TRIG_ERR_MASK_4 = 0x00000000;
        private ulong MTC_ACQ_WR_DATA_0 = 0x00000000;
        private ulong MTC_ACQ_WR_DATA_1 = 0x00000000;
        private ulong MTC_ACQ_WR_DATA_2 = 0x00000000;
        private ulong MTC_ACQ_RD_DATA_0 = 0x00000000;
        private ulong MTC_ACQ_RD_DATA_1 = 0x00000000;
        private ulong MTC_ACQ_RD_DATA_2 = 0x00000000;
        private ulong CFG_PRE_TRIG_CYCS = 0x00000000;
        private ulong MTC_ACQ_ERROR_CNT = 0x00000000;
        private ulong MTC_ACQ_ERROR_CNT_OVFL = 0x00000000;
        private ulong CFG_DATA_SEL_FIRST_ERROR = 0x00000000;

        public uint ReadDoubleWord(long offset)
        {
            ulong value = 0x0u;
            switch(offset)
            {
                case 0x400:
                    value = CFG_ERROR_GROUP_SEL;
                    break;
                case 0x404:
                    value = CFG_DATA_SEL;
                    break;
                case 0x408:
                    value = CFG_TRIG_MODE;
                    break;
                case 0x40C:
                    value = CFG_POST_TRIG_CYCS;
                    break;
                case 0x410:
                    value = CFG_TRIG_MASK;
                    break;
                case 0x414:
                    value = CFG_EN_MASK;
                    break;
                case 0x418:
                    value = MTC_ACQ_ADDR;
                    break;
                case 0x41C:
                    value = MTC_ACQ_CYCS_STORED;
                    break;
                case 0x420:
                    value = MTC_ACQ_TRIG_DETECT;
                    break;
                case 0x424:
                    value = MTC_ACQ_MEM_TRIG_ADDR;
                    break;
                case 0x428:
                    value = MTC_ACQ_MEM_LAST_ADDR;
                    break;
                case 0x42C:
                    value = MTC_ACK;
                    break;
                case 0x430:
                    value = CFG_TRIG_MT_ADDR_0;
                    break;
                case 0x434:
                    value = CFG_TRIG_MT_ADDR_1;
                    break;
                case 0x438:
                    value = CFG_TRIG_ERR_MASK_0;
                    break;
                case 0x43C:
                    value = CFG_TRIG_ERR_MASK_1;
                    break;
                case 0x440:
                    value = CFG_TRIG_ERR_MASK_2;
                    break;
                case 0x444:
                    value = CFG_TRIG_ERR_MASK_3;
                    break;
                case 0x448:
                    value = CFG_TRIG_ERR_MASK_4;
                    break;
                case 0x44C:
                    value = MTC_ACQ_WR_DATA_0;
                    break;
                case 0x450:
                    value = MTC_ACQ_WR_DATA_1;
                    break;
                case 0x454:
                    value = MTC_ACQ_WR_DATA_2;
                    break;
                case 0x458:
                    value = MTC_ACQ_RD_DATA_0;
                    break;
                case 0x45C:
                    value = MTC_ACQ_RD_DATA_1;
                    break;
                case 0x460:
                    value = MTC_ACQ_RD_DATA_2;
                    break;
                case 0x52C:
                    value = CFG_PRE_TRIG_CYCS;
                    break;
                case 0x538:
                    value = MTC_ACQ_ERROR_CNT;
                    break;
                case 0x544:
                    value = MTC_ACQ_ERROR_CNT_OVFL;
                    break;
                case 0x550:
                    value = CFG_DATA_SEL_FIRST_ERROR;
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
                case 0x400:
                    CFG_ERROR_GROUP_SEL =  value;
                    break;
                case 0x404:
                    CFG_DATA_SEL =  value;
                    break;
                case 0x408:
                    CFG_TRIG_MODE =  value;
                    break;
                case 0x40C:
                    CFG_POST_TRIG_CYCS =  value;
                    break;
                case 0x410:
                    CFG_TRIG_MASK =  value;
                    break;
                case 0x414:
                    CFG_EN_MASK =  value;
                    break;
                case 0x418:
                    MTC_ACQ_ADDR =  value;
                    break;
                case 0x41C:
                    MTC_ACQ_CYCS_STORED =  value;
                    break;
                case 0x420:
                    MTC_ACQ_TRIG_DETECT =  value;
                    break;
                case 0x424:
                    MTC_ACQ_MEM_TRIG_ADDR =  value;
                    break;
                case 0x428:
                    MTC_ACQ_MEM_LAST_ADDR =  value;
                    break;
                case 0x42C:
                    MTC_ACK =  value;
                    break;
                case 0x430:
                    CFG_TRIG_MT_ADDR_0 =  value;
                    break;
                case 0x434:
                    CFG_TRIG_MT_ADDR_1 =  value;
                    break;
                case 0x438:
                    CFG_TRIG_ERR_MASK_0 =  value;
                    break;
                case 0x43C:
                    CFG_TRIG_ERR_MASK_1 =  value;
                    break;
                case 0x440:
                    CFG_TRIG_ERR_MASK_2 =  value;
                    break;
                case 0x444:
                    CFG_TRIG_ERR_MASK_3 =  value;
                    break;
                case 0x448:
                    CFG_TRIG_ERR_MASK_4 =  value;
                    break;
                case 0x44C:
                    MTC_ACQ_WR_DATA_0 =  value;
                    break;
                case 0x450:
                    MTC_ACQ_WR_DATA_1 =  value;
                    break;
                case 0x454:
                    MTC_ACQ_WR_DATA_2 =  value;
                    break;
                case 0x458:
                    MTC_ACQ_RD_DATA_0 =  value;
                    break;
                case 0x45C:
                    MTC_ACQ_RD_DATA_1 =  value;
                    break;
                case 0x460:
                    MTC_ACQ_RD_DATA_2 =  value;
                    break;
                case 0x52C:
                    CFG_PRE_TRIG_CYCS =  value;
                    break;
                case 0x538:
                    MTC_ACQ_ERROR_CNT =  value;
                    break;
                case 0x544:
                    MTC_ACQ_ERROR_CNT_OVFL =  value;
                    break;
                case 0x550:
                    CFG_DATA_SEL_FIRST_ERROR =  value;
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


