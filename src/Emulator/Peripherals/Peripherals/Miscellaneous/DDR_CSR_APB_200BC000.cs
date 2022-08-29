using Antmicro.Renode.Peripherals.Bus;
using Antmicro.Renode.Logging;

namespace Antmicro.Renode.Peripherals.Miscellaneous
{
    public class DDR_CSR_APB_200BC000 : IDoubleWordPeripheral, IKnownSize
    {
        private ulong PHY_RESET_CONTROL = 0x0000000D;
        private ulong PHY_PC_RANK = 0x00000000;
        private ulong PHY_RANKS_TO_TRAIN = 0x00000000;
        private ulong PHY_WRITE_REQUEST = 0x00000000;
        private ulong PHY_WRITE_REQUEST_DONE = 0x00000000;
        private ulong PHY_READ_REQUEST = 0x00000000;
        private ulong PHY_READ_REQUEST_DONE = 0x00000000;
        private ulong PHY_WRITE_LEVEL_DELAY = 0x00000000;
        private ulong PHY_GATE_TRAIN_DELAY = 0x00000000;
        private ulong PHY_EYE_TRAIN_DELAY = 0x00000000;
        private ulong PHY_EYE_PAT = 0x00000000;
        private ulong PHY_START_RECAL = 0x00000000;
        private ulong PHY_CLR_DFI_LVL_PERIODIC = 0x00000000;
        private ulong PHY_TRAIN_STEP_ENABLE = 0x00000000;
        private ulong PHY_LPDDR_DQ_CAL_PAT = 0x00000000;
        private ulong PHY_INDPNDT_TRAINING = 0x00000000;
        private ulong PHY_ENCODED_QUAD_CS = 0x00000000;
        private ulong PHY_HALF_CLK_DLY_ENABLE = 0x00000000;

        public uint ReadDoubleWord(long offset)
        {
            ulong value = 0x0u;
            switch(offset)
            {
                case 0x000:
                    value = PHY_RESET_CONTROL;
                    break;
                case 0x004:
                    value = PHY_PC_RANK;
                    break;
                case 0x008:
                    value = PHY_RANKS_TO_TRAIN;
                    break;
                case 0x00C:
                    value = PHY_WRITE_REQUEST;
                    break;
                case 0x010:
                    value = PHY_WRITE_REQUEST_DONE;
                    break;
                case 0x014:
                    value = PHY_READ_REQUEST;
                    break;
                case 0x018:
                    value = PHY_READ_REQUEST_DONE;
                    break;
                case 0x01C:
                    value = PHY_WRITE_LEVEL_DELAY;
                    break;
                case 0x020:
                    value = PHY_GATE_TRAIN_DELAY;
                    break;
                case 0x024:
                    value = PHY_EYE_TRAIN_DELAY;
                    break;
                case 0x028:
                    value = PHY_EYE_PAT;
                    break;
                case 0x02C:
                    value = PHY_START_RECAL;
                    break;
                case 0x030:
                    value = PHY_CLR_DFI_LVL_PERIODIC;
                    break;
                case 0x034:
                    value = PHY_TRAIN_STEP_ENABLE;
                    break;
                case 0x038:
                    value = PHY_LPDDR_DQ_CAL_PAT;
                    break;
                case 0x03C:
                    value = PHY_INDPNDT_TRAINING;
                    break;
                case 0x040:
                    value = PHY_ENCODED_QUAD_CS;
                    break;
                case 0x044:
                    value = PHY_HALF_CLK_DLY_ENABLE;
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
                    PHY_RESET_CONTROL =  value;
                    break;
                case 0x004:
                    PHY_PC_RANK =  value;
                    break;
                case 0x008:
                    PHY_RANKS_TO_TRAIN =  value;
                    break;
                case 0x00C:
                    PHY_WRITE_REQUEST =  value;
                    break;
                case 0x010:
                    PHY_WRITE_REQUEST_DONE =  value;
                    break;
                case 0x014:
                    PHY_READ_REQUEST =  value;
                    break;
                case 0x018:
                    PHY_READ_REQUEST_DONE =  value;
                    break;
                case 0x01C:
                    PHY_WRITE_LEVEL_DELAY =  value;
                    break;
                case 0x020:
                    PHY_GATE_TRAIN_DELAY =  value;
                    break;
                case 0x024:
                    PHY_EYE_TRAIN_DELAY =  value;
                    break;
                case 0x028:
                    PHY_EYE_PAT =  value;
                    break;
                case 0x02C:
                    PHY_START_RECAL =  value;
                    break;
                case 0x030:
                    PHY_CLR_DFI_LVL_PERIODIC =  value;
                    break;
                case 0x034:
                    PHY_TRAIN_STEP_ENABLE =  value;
                    break;
                case 0x038:
                    PHY_LPDDR_DQ_CAL_PAT =  value;
                    break;
                case 0x03C:
                    PHY_INDPNDT_TRAINING =  value;
                    break;
                case 0x040:
                    PHY_ENCODED_QUAD_CS =  value;
                    break;
                case 0x044:
                    PHY_HALF_CLK_DLY_ENABLE =  value;
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


