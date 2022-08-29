using Antmicro.Renode.Peripherals.Bus;
using Antmicro.Renode.Logging;

namespace Antmicro.Renode.Peripherals.Miscellaneous
{
    public class DDR_CSR_APB_2010000 : IDoubleWordPeripheral, IBytePeripheral, IKnownSize
    {
        private ulong L2_Config = 0x0000000000000000;
        private ulong L2_WayEnable = 0x000000000000000f;
        private ulong L2_ECCInjectError = 0x0000000000000000;
        private ulong L2_ECCDirFixAddr = 0x0000000000000000;
        private ulong L2_ECCDirFixCount = 0x0000000000000000;
        private ulong L2_ECCDirFailAddr = 0x0000000000000000;
        private ulong L2_ECCDirFailCount = 0x0000000000000000;
        private ulong L2_ECCDataFixAddr = 0x0000000000000000;
        private ulong L2_ECCDataFixCount = 0x0000000000000000;
        private ulong L2_ECCDataFailAddr = 0x0000000000000000;
        private ulong L2_ECCDataFailCount = 0x0000000000000000;
        private ulong L2_Flush64 = 0x0000000000000000;
        private ulong L2_Flush32 = 0x0000000000000000;
        private ulong L2_Master_0_way_mask_register = 0x0000000000000000;
        private ulong L2_Master_1_way_mask_register = 0x0000000000000000;
        private ulong L2_Master_2_way_mask_register = 0x0000000000000000;
        private ulong L2_Master_3_way_mask_register = 0x0000000000000000;
        private ulong L2_Master_4_way_mask_register = 0x0000000000000000;
        private ulong L2_Master_5_way_mask_register = 0x0000000000000000;
        private ulong L2_Master_6_way_mask_register = 0x0000000000000000;
        private ulong L2_Master_7_way_mask_register = 0x0000000000000000;
        private ulong L2_Master_8_way_mask_register = 0x0000000000000000;
        private ulong L2_Master_9_way_mask_register = 0x0000000000000000;
        private ulong L2_Master_10_way_mask_register = 0x0000000000000000;
        private ulong L2_Master_11_way_mask_register = 0x0000000000000000;
        private ulong L2_Master_12_way_mask_register = 0x0000000000000000;
        private ulong L2_Master_13_way_mask_register = 0x0000000000000000;
        private ulong L2_Master_14_way_mask_register = 0x0000000000000000;

        public uint ReadDoubleWord(long offset)
        {
            ulong value = 0x0u;
            switch(offset)
            {
                case 0x000:
                    value = L2_Config;
                    break;
                case 0x008:
                    value = L2_WayEnable;
                    break;
                case 0x040:
                    value = L2_ECCInjectError;
                    break;
                case 0x100:
                    value = L2_ECCDirFixAddr;
                    break;
                case 0x108:
                    value = L2_ECCDirFixCount;
                    break;
                case 0x120:
                    value = L2_ECCDirFailAddr;
                    break;
                case 0x128:
                    value = L2_ECCDirFailCount;
                    break;
                case 0x140:
                    value = L2_ECCDataFixAddr;
                    break;
                case 0x148:
                    value = L2_ECCDataFixCount;
                    break;
                case 0x160:
                    value = L2_ECCDataFailAddr;
                    break;
                case 0x168:
                    value = L2_ECCDataFailCount;
                    break;
                case 0x200:
                    value = L2_Flush64;
                    break;
                case 0x240:
                    value = L2_Flush32;
                    break;
                case 0x800:
                    value = L2_Master_0_way_mask_register;
                    break;
                case 0x808:
                    value = L2_Master_1_way_mask_register;
                    break;
                case 0x810:
                    value = L2_Master_2_way_mask_register;
                    break;
                case 0x818:
                    value = L2_Master_3_way_mask_register;
                    break;
                case 0x820:
                    value = L2_Master_4_way_mask_register;
                    break;
                case 0x828:
                    value = L2_Master_5_way_mask_register;
                    break;
                case 0x830:
                    value = L2_Master_6_way_mask_register;
                    break;
                case 0x838:
                    value = L2_Master_7_way_mask_register;
                    break;
                case 0x840:
                    value = L2_Master_8_way_mask_register;
                    break;
                case 0x848:
                    value = L2_Master_9_way_mask_register;
                    break;
                case 0x850:
                    value = L2_Master_10_way_mask_register;
                    break;
                case 0x858:
                    value = L2_Master_11_way_mask_register;
                    break;
                case 0x860:
                    value = L2_Master_12_way_mask_register;
                    break;
                case 0x868:
                    value = L2_Master_13_way_mask_register;
                    break;
                case 0x870:
                    value = L2_Master_14_way_mask_register;
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
                    L2_Config =  value;
                    break;
                case 0x008:
                    L2_WayEnable =  value;
                    break;
                case 0x040:
                    L2_ECCInjectError =  value;
                    break;
                case 0x100:
                    L2_ECCDirFixAddr =  value;
                    break;
                case 0x108:
                    L2_ECCDirFixCount =  value;
                    break;
                case 0x120:
                    L2_ECCDirFailAddr =  value;
                    break;
                case 0x128:
                    L2_ECCDirFailCount =  value;
                    break;
                case 0x140:
                    L2_ECCDataFixAddr =  value;
                    break;
                case 0x148:
                    L2_ECCDataFixCount =  value;
                    break;
                case 0x160:
                    L2_ECCDataFailAddr =  value;
                    break;
                case 0x168:
                    L2_ECCDataFailCount =  value;
                    break;
                case 0x200:
                    L2_Flush64 =  value;
                    break;
                case 0x240:
                    L2_Flush32 =  value;
                    break;
                case 0x800:
                    L2_Master_0_way_mask_register =  value;
                    break;
                case 0x808:
                    L2_Master_1_way_mask_register =  value;
                    break;
                case 0x810:
                    L2_Master_2_way_mask_register =  value;
                    break;
                case 0x818:
                    L2_Master_3_way_mask_register =  value;
                    break;
                case 0x820:
                    L2_Master_4_way_mask_register =  value;
                    break;
                case 0x828:
                    L2_Master_5_way_mask_register =  value;
                    break;
                case 0x830:
                    L2_Master_6_way_mask_register =  value;
                    break;
                case 0x838:
                    L2_Master_7_way_mask_register =  value;
                    break;
                case 0x840:
                    L2_Master_8_way_mask_register =  value;
                    break;
                case 0x848:
                    L2_Master_9_way_mask_register =  value;
                    break;
                case 0x850:
                    L2_Master_10_way_mask_register =  value;
                    break;
                case 0x858:
                    L2_Master_11_way_mask_register =  value;
                    break;
                case 0x860:
                    L2_Master_12_way_mask_register =  value;
                    break;
                case 0x868:
                    L2_Master_13_way_mask_register =  value;
                    break;
                case 0x870:
                    L2_Master_14_way_mask_register =  value;
                    break;
                default:
                    break;
            }
            this.Log(LogLevel.Noisy, "write word to DDR controller - offset: 0x{0:X}, value 0x{1:X}", offset, value);
        }

        public byte ReadByte(long offset)
        {
            long address = 0;
            ulong value = 0;
            byte shift = 0;
            ulong resetter = 0x0;
            ulong shifted_data = 0x0;
            long test0 = offset & 1;
            long test1 = offset & 2;
            long test2 = offset & 4;
            long test4 = offset & 8;
            if ((offset & 3)==3) {
                address = offset - 3;
                shift = 24;
                resetter = 0xff000000;
            } else if ((offset & 2)==2) {
                address = offset -  2;
                shift = 16;
                resetter = 0x00ff0000;
            } else if ((offset & 1)==1){
                address = offset -  1;
                shift = 8;
                resetter = 0x0000ff00;
            } else {
                address = offset;
                shift = 0;
                resetter = 0x000000ff;
            }

            switch(offset)
            {
                case 0x000:
                    value = L2_Config;
                    break;
                case 0x008:
                    value = L2_WayEnable;
                    break;
                case 0x040:
                    value = L2_ECCInjectError;
                    break;
                case 0x100:
                    value = L2_ECCDirFixAddr;
                    break;
                case 0x108:
                    value = L2_ECCDirFixCount;
                    break;
                case 0x120:
                    value = L2_ECCDirFailAddr;
                    break;
                case 0x128:
                    value = L2_ECCDirFailCount;
                    break;
                case 0x140:
                    value = L2_ECCDataFixAddr;
                    break;
                case 0x148:
                    value = L2_ECCDataFixCount;
                    break;
                case 0x160:
                    value = L2_ECCDataFailAddr;
                    break;
                case 0x168:
                    value = L2_ECCDataFailCount;
                    break;
                case 0x200:
                    value = L2_Flush64;
                    break;
                case 0x240:
                    value = L2_Flush32;
                    break;
                case 0x800:
                    value = L2_Master_0_way_mask_register;
                    break;
                case 0x808:
                    value = L2_Master_1_way_mask_register;
                    break;
                case 0x810:
                    value = L2_Master_2_way_mask_register;
                    break;
                case 0x818:
                    value = L2_Master_3_way_mask_register;
                    break;
                case 0x820:
                    value = L2_Master_4_way_mask_register;
                    break;
                case 0x828:
                    value = L2_Master_5_way_mask_register;
                    break;
                case 0x830:
                    value = L2_Master_6_way_mask_register;
                    break;
                case 0x838:
                    value = L2_Master_7_way_mask_register;
                    break;
                case 0x840:
                    value = L2_Master_8_way_mask_register;
                    break;
                case 0x848:
                    value = L2_Master_9_way_mask_register;
                    break;
                case 0x850:
                    value = L2_Master_10_way_mask_register;
                    break;
                case 0x858:
                    value = L2_Master_11_way_mask_register;
                    break;
                case 0x860:
                    value = L2_Master_12_way_mask_register;
                    break;
                case 0x868:
                    value = L2_Master_13_way_mask_register;
                    break;
                case 0x870:
                    value = L2_Master_14_way_mask_register;
                    break;
                default:
                    value = 0x0;
                    break;
            }
            value = value & resetter;
            shifted_data = (value >> shift);
            this.Log(LogLevel.Noisy, "Read byte from DDR controller - offset: 0x{0:X}, value 0x{1:X}", offset, shifted_data);
            return (byte)shifted_data;
        }

        public void WriteByte(long offset, byte data)
        {
            long address = 0;
            ulong value = 0;
            byte shift = 0;
            ulong resetter = 0x0;
            ulong shifted_data = 0x0;
            long test0 = offset & 1;
            long test1 = offset & 2;
            long test2 = offset & 4;
            long test4 = offset & 8;
            if ((offset & 3)==3) {
                address = offset - 3;
                shift = 24;
                resetter = 0x00ffffff;
            } else if ((offset & 2)==2) {
                address = offset -  2;
                shift = 16;
                resetter = 0xff00ffff;
            } else if ((offset & 1)==1){
                address = offset -  1;
                shift = 8;
                resetter = 0xffff00ff;
            } else {
                address = offset;
                shift = 0;
                resetter = 0xffffff00;
            }

            switch(address)
            {
                case 0x000:
                    value = L2_Config;
                    break;
                case 0x008:
                    value = L2_WayEnable;
                    break;
                case 0x040:
                    value = L2_ECCInjectError;
                    break;
                case 0x100:
                    value = L2_ECCDirFixAddr;
                    break;
                case 0x108:
                    value = L2_ECCDirFixCount;
                    break;
                case 0x120:
                    value = L2_ECCDirFailAddr;
                    break;
                case 0x128:
                    value = L2_ECCDirFailCount;
                    break;
                case 0x140:
                    value = L2_ECCDataFixAddr;
                    break;
                case 0x148:
                    value = L2_ECCDataFixCount;
                    break;
                case 0x160:
                    value = L2_ECCDataFailAddr;
                    break;
                case 0x168:
                    value = L2_ECCDataFailCount;
                    break;
                case 0x200:
                    value = L2_Flush64;
                    break;
                case 0x240:
                    value = L2_Flush32;
                    break;
                case 0x800:
                    value = L2_Master_0_way_mask_register;
                    break;
                case 0x808:
                    value = L2_Master_1_way_mask_register;
                    break;
                case 0x810:
                    value = L2_Master_2_way_mask_register;
                    break;
                case 0x818:
                    value = L2_Master_3_way_mask_register;
                    break;
                case 0x820:
                    value = L2_Master_4_way_mask_register;
                    break;
                case 0x828:
                    value = L2_Master_5_way_mask_register;
                    break;
                case 0x830:
                    value = L2_Master_6_way_mask_register;
                    break;
                case 0x838:
                    value = L2_Master_7_way_mask_register;
                    break;
                case 0x840:
                    value = L2_Master_8_way_mask_register;
                    break;
                case 0x848:
                    value = L2_Master_9_way_mask_register;
                    break;
                case 0x850:
                    value = L2_Master_10_way_mask_register;
                    break;
                case 0x858:
                    value = L2_Master_11_way_mask_register;
                    break;
                case 0x860:
                    value = L2_Master_12_way_mask_register;
                    break;
                case 0x868:
                    value = L2_Master_13_way_mask_register;
                    break;
                case 0x870:
                    value = L2_Master_14_way_mask_register;
                    break;
                default:
                    value = 0x0;
                    break;
            }
            value = value & resetter;
            shifted_data = ((ulong)data << shift);
            value = value | shifted_data;
            switch(address)
            {
                case 0x000:
                    value = L2_Config;
                    break;
                case 0x008:
                    value = L2_WayEnable;
                    break;
                case 0x040:
                    value = L2_ECCInjectError;
                    break;
                case 0x100:
                    value = L2_ECCDirFixAddr;
                    break;
                case 0x108:
                    value = L2_ECCDirFixCount;
                    break;
                case 0x120:
                    value = L2_ECCDirFailAddr;
                    break;
                case 0x128:
                    value = L2_ECCDirFailCount;
                    break;
                case 0x140:
                    value = L2_ECCDataFixAddr;
                    break;
                case 0x148:
                    value = L2_ECCDataFixCount;
                    break;
                case 0x160:
                    value = L2_ECCDataFailAddr;
                    break;
                case 0x168:
                    value = L2_ECCDataFailCount;
                    break;
                case 0x200:
                    value = L2_Flush64;
                    break;
                case 0x240:
                    value = L2_Flush32;
                    break;
                case 0x800:
                    value = L2_Master_0_way_mask_register;
                    break;
                case 0x808:
                    value = L2_Master_1_way_mask_register;
                    break;
                case 0x810:
                    value = L2_Master_2_way_mask_register;
                    break;
                case 0x818:
                    value = L2_Master_3_way_mask_register;
                    break;
                case 0x820:
                    value = L2_Master_4_way_mask_register;
                    break;
                case 0x828:
                    value = L2_Master_5_way_mask_register;
                    break;
                case 0x830:
                    value = L2_Master_6_way_mask_register;
                    break;
                case 0x838:
                    value = L2_Master_7_way_mask_register;
                    break;
                case 0x840:
                    value = L2_Master_8_way_mask_register;
                    break;
                case 0x848:
                    value = L2_Master_9_way_mask_register;
                    break;
                case 0x850:
                    value = L2_Master_10_way_mask_register;
                    break;
                case 0x858:
                    value = L2_Master_11_way_mask_register;
                    break;
                case 0x860:
                    value = L2_Master_12_way_mask_register;
                    break;
                case 0x868:
                    value = L2_Master_13_way_mask_register;
                    break;
                case 0x870:
                    value = L2_Master_14_way_mask_register;
                    break;
                default:
                    value = 0x0;
                    break;
            }
            this.Log(LogLevel.Noisy, "write byte from DDR controller - offset: 0x{0:X}, value 0x{1:X}", offset, value);
        }

        public void Reset()
        {
        }

public long Size => 0xFFF; // Size is address space on sysbus
    }
}


