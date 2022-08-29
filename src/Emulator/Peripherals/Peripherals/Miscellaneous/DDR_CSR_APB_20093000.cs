using Antmicro.Renode.Peripherals.Bus;
using Antmicro.Renode.Logging;

namespace Antmicro.Renode.Peripherals.Miscellaneous
{
    public class DDR_CSR_APB_20093000 : IDoubleWordPeripheral, IKnownSize
    {
        private ulong CFG_MEM_START_ADDRESS_AXI1_0 = 0x00000000;
        private ulong CFG_MEM_START_ADDRESS_AXI1_1 = 0x00000000;
        private ulong CFG_MEM_START_ADDRESS_AXI2_0 = 0x00000000;
        private ulong CFG_MEM_START_ADDRESS_AXI2_1 = 0x00000000;
        private ulong CFG_ENABLE_BUS_HOLD_AXI1 = 0x00000000;
        private ulong CFG_ENABLE_BUS_HOLD_AXI2 = 0x00000000;
        private ulong CFG_AXI_AUTO_PCH = 0x00000000;

        public uint ReadDoubleWord(long offset)
        {
            ulong value = 0x0u;
            switch(offset)
            {
                case 0x218:
                    value = CFG_MEM_START_ADDRESS_AXI1_0;
                    break;
                case 0x21C:
                    value = CFG_MEM_START_ADDRESS_AXI1_1;
                    break;
                case 0x220:
                    value = CFG_MEM_START_ADDRESS_AXI2_0;
                    break;
                case 0x224:
                    value = CFG_MEM_START_ADDRESS_AXI2_1;
                    break;
                case 0x514:
                    value = CFG_ENABLE_BUS_HOLD_AXI1;
                    break;
                case 0x518:
                    value = CFG_ENABLE_BUS_HOLD_AXI2;
                    break;
                case 0x690:
                    value = CFG_AXI_AUTO_PCH;
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
                case 0x218:
                    CFG_MEM_START_ADDRESS_AXI1_0 =  value;
                    break;
                case 0x21C:
                    CFG_MEM_START_ADDRESS_AXI1_1 =  value;
                    break;
                case 0x220:
                    CFG_MEM_START_ADDRESS_AXI2_0 =  value;
                    break;
                case 0x224:
                    CFG_MEM_START_ADDRESS_AXI2_1 =  value;
                    break;
                case 0x514:
                    CFG_ENABLE_BUS_HOLD_AXI1 =  value;
                    break;
                case 0x518:
                    CFG_ENABLE_BUS_HOLD_AXI2 =  value;
                    break;
                case 0x690:
                    CFG_AXI_AUTO_PCH =  value;
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


