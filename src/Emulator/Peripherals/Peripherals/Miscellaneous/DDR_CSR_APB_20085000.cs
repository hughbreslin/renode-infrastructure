using Antmicro.Renode.Peripherals.Bus;
using Antmicro.Renode.Logging;

namespace Antmicro.Renode.Peripherals.Miscellaneous
{
    public class DDR_CSR_APB_20085000 : IDoubleWordPeripheral, IKnownSize
    {
        private ulong CFG_REORDER_EN = 0x00000001;
        private ulong CFG_REORDER_QUEUE_EN = 0x00000001;
        private ulong CFG_INTRAPORT_REORDER_EN = 0x00000001;
        private ulong CFG_MAINTAIN_COHERENCY = 0x00000001;
        private ulong CFG_Q_AGE_LIMIT = 0x000000FF;
        private ulong CFG_RO_CLOSED_PAGE_POLICY = 0x00000000;
        private ulong CFG_REORDER_RW_ONLY = 0x00000000;
        private ulong CFG_RO_PRIORITY_EN = 0x00000000;
        private ulong CFG_DM_EN = 0x00000001;
        private ulong CFG_RMW_EN = 0x00000001;
        private ulong CFG_ECC_CORRECTION_EN = 0x00000001;
        private ulong CFG_ECC_BYPASS = 0x00000000;
        private ulong INIT_WRITE_DATA_1B_ECC_ERROR_GEN = 0x00000000;
        private ulong INIT_WRITE_DATA_2B_ECC_ERROR_GEN = 0x00000000;
        private ulong CFG_ECC_1BIT_INT_THRESH = 0x00000000;
        private ulong STAT_INT_ECC_1BIT_THRESH = 0x00000000;
        private ulong INIT_READ_CAPTURE_ADDR = 0x00000000;
        private ulong INIT_READ_CAPTURE_DATA_0 = 0x00000000;
        private ulong INIT_READ_CAPTURE_DATA_1 = 0x00000000;
        private ulong INIT_READ_CAPTURE_DATA_2 = 0x00000000;
        private ulong INIT_READ_CAPTURE_DATA_3 = 0x00000000;
        private ulong INIT_READ_CAPTURE_DATA_4 = 0x00000000;

        public uint ReadDoubleWord(long offset)
        {
            ulong value = 0x0u;
            switch(offset)
            {
                case 0x000:
                    value = CFG_REORDER_EN;
                    break;
                case 0x004:
                    value = CFG_REORDER_QUEUE_EN;
                    break;
                case 0x008:
                    value = CFG_INTRAPORT_REORDER_EN;
                    break;
                case 0x00C:
                    value = CFG_MAINTAIN_COHERENCY;
                    break;
                case 0x010:
                    value = CFG_Q_AGE_LIMIT;
                    break;
                case 0x018:
                    value = CFG_RO_CLOSED_PAGE_POLICY;
                    break;
                case 0x01C:
                    value = CFG_REORDER_RW_ONLY;
                    break;
                case 0x020:
                    value = CFG_RO_PRIORITY_EN;
                    break;
                case 0x400:
                    value = CFG_DM_EN;
                    break;
                case 0x404:
                    value = CFG_RMW_EN;
                    break;
                case 0x800:
                    value = CFG_ECC_CORRECTION_EN;
                    break;
                case 0x840:
                    value = CFG_ECC_BYPASS;
                    break;
                case 0x844:
                    value = INIT_WRITE_DATA_1B_ECC_ERROR_GEN;
                    break;
                case 0x848:
                    value = INIT_WRITE_DATA_2B_ECC_ERROR_GEN;
                    break;
                case 0x85C:
                    value = CFG_ECC_1BIT_INT_THRESH;
                    break;
                case 0x860:
                    value = STAT_INT_ECC_1BIT_THRESH;
                    break;
                case 0xC00:
                    value = INIT_READ_CAPTURE_ADDR;
                    break;
                case 0xC04:
                    value = INIT_READ_CAPTURE_DATA_0;
                    break;
                case 0xC08:
                    value = INIT_READ_CAPTURE_DATA_1;
                    break;
                case 0xC0C:
                    value = INIT_READ_CAPTURE_DATA_2;
                    break;
                case 0xC10:
                    value = INIT_READ_CAPTURE_DATA_3;
                    break;
                case 0xC14:
                    value = INIT_READ_CAPTURE_DATA_4;
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
                case 0x000:
                    CFG_REORDER_EN =  value;
                    break;
                case 0x004:
                    CFG_REORDER_QUEUE_EN =  value;
                    break;
                case 0x008:
                    CFG_INTRAPORT_REORDER_EN =  value;
                    break;
                case 0x00C:
                    CFG_MAINTAIN_COHERENCY =  value;
                    break;
                case 0x010:
                    CFG_Q_AGE_LIMIT =  value;
                    break;
                case 0x018:
                    CFG_RO_CLOSED_PAGE_POLICY =  value;
                    break;
                case 0x01C:
                    CFG_REORDER_RW_ONLY =  value;
                    break;
                case 0x020:
                    CFG_RO_PRIORITY_EN =  value;
                    break;
                case 0x400:
                    CFG_DM_EN =  value;
                    break;
                case 0x404:
                    CFG_RMW_EN =  value;
                    break;
                case 0x800:
                    CFG_ECC_CORRECTION_EN =  value;
                    break;
                case 0x840:
                    CFG_ECC_BYPASS =  value;
                    break;
                case 0x844:
                    INIT_WRITE_DATA_1B_ECC_ERROR_GEN =  value;
                    break;
                case 0x848:
                    INIT_WRITE_DATA_2B_ECC_ERROR_GEN =  value;
                    break;
                case 0x85C:
                    CFG_ECC_1BIT_INT_THRESH =  value;
                    break;
                case 0x860:
                    STAT_INT_ECC_1BIT_THRESH =  value;
                    break;
                case 0xC00:
                    INIT_READ_CAPTURE_ADDR =  value;
                    break;
                case 0xC04:
                    INIT_READ_CAPTURE_DATA_0 =  value;
                    break;
                case 0xC08:
                    INIT_READ_CAPTURE_DATA_1 =  value;
                    break;
                case 0xC0C:
                    INIT_READ_CAPTURE_DATA_2 =  value;
                    break;
                case 0xC10:
                    INIT_READ_CAPTURE_DATA_3 =  value;
                    break;
                case 0xC14:
                    INIT_READ_CAPTURE_DATA_4 =  value;
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


