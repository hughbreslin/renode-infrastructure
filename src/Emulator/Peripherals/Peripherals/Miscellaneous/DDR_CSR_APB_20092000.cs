using Antmicro.Renode.Peripherals.Bus;
using Antmicro.Renode.Logging;

namespace Antmicro.Renode.Peripherals.Miscellaneous
{
    public class DDR_CSR_APB_20092000 : IDoubleWordPeripheral, IKnownSize
    {
        private ulong CFG_AXI_START_ADDRESS_AXI1_0 = 0x00000000;
        private ulong CFG_AXI_START_ADDRESS_AXI1_1 = 0x00000000;
        private ulong CFG_AXI_START_ADDRESS_AXI2_0 = 0x00000000;
        private ulong CFG_AXI_START_ADDRESS_AXI2_1 = 0x00000000;
        private ulong CFG_AXI_END_ADDRESS_AXI1_0 = 0xFFFFFFFF;
        private ulong CFG_AXI_END_ADDRESS_AXI1_1 = 0x00000003;
        private ulong CFG_AXI_END_ADDRESS_AXI2_0 = 0xFFFFFFFF;
        private ulong CFG_AXI_END_ADDRESS_AXI2_1 = 0x00000003;

        public uint ReadDoubleWord(long offset)
        {
            ulong value = 0x0u;
            switch(offset)
            {
                case 0xC18:
                    value = CFG_AXI_START_ADDRESS_AXI1_0;
                    break;
                case 0xC1C:
                    value = CFG_AXI_START_ADDRESS_AXI1_1;
                    break;
                case 0xC20:
                    value = CFG_AXI_START_ADDRESS_AXI2_0;
                    break;
                case 0xC24:
                    value = CFG_AXI_START_ADDRESS_AXI2_1;
                    break;
                case 0xF18:
                    value = CFG_AXI_END_ADDRESS_AXI1_0;
                    break;
                case 0xF1C:
                    value = CFG_AXI_END_ADDRESS_AXI1_1;
                    break;
                case 0xF20:
                    value = CFG_AXI_END_ADDRESS_AXI2_0;
                    break;
                case 0xF24:
                    value = CFG_AXI_END_ADDRESS_AXI2_1;
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
                case 0xC18:
                    CFG_AXI_START_ADDRESS_AXI1_0 =  value;
                    break;
                case 0xC1C:
                    CFG_AXI_START_ADDRESS_AXI1_1 =  value;
                    break;
                case 0xC20:
                    CFG_AXI_START_ADDRESS_AXI2_0 =  value;
                    break;
                case 0xC24:
                    CFG_AXI_START_ADDRESS_AXI2_1 =  value;
                    break;
                case 0xF18:
                    CFG_AXI_END_ADDRESS_AXI1_0 =  value;
                    break;
                case 0xF1C:
                    CFG_AXI_END_ADDRESS_AXI1_1 =  value;
                    break;
                case 0xF20:
                    CFG_AXI_END_ADDRESS_AXI2_0 =  value;
                    break;
                case 0xF24:
                    CFG_AXI_END_ADDRESS_AXI2_1 =  value;
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


