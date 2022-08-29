using Antmicro.Renode.Peripherals.Bus;
using Antmicro.Renode.Logging;

namespace Antmicro.Renode.Peripherals.Miscellaneous
{
    public class DDR_CSR_APB_20088000 : IDoubleWordPeripheral, IKnownSize
    {
        private ulong STAT_CA_PARITY_ERROR = 0x00000000;
        private ulong INIT_CA_PARITY_ERROR_GEN_REQ = 0x00000000;
        private ulong INIT_CA_PARITY_ERROR_GEN_CMD = 0x00000000;
        private ulong INIT_CA_PARITY_ERROR_GEN_ACK = 0x00000000;

        public uint ReadDoubleWord(long offset)
        {
            ulong value = 0x0u;
            switch(offset)
            {
                case 0x000:
                    value = STAT_CA_PARITY_ERROR;
                    break;
                case 0x00C:
                    value = INIT_CA_PARITY_ERROR_GEN_REQ;
                    break;
                case 0x010:
                    value = INIT_CA_PARITY_ERROR_GEN_CMD;
                    break;
                case 0x014:
                    value = INIT_CA_PARITY_ERROR_GEN_ACK;
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
                    STAT_CA_PARITY_ERROR =  value;
                    break;
                case 0x00C:
                    INIT_CA_PARITY_ERROR_GEN_REQ =  value;
                    break;
                case 0x010:
                    INIT_CA_PARITY_ERROR_GEN_CMD =  value;
                    break;
                case 0x014:
                    INIT_CA_PARITY_ERROR_GEN_ACK =  value;
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


