using Antmicro.Renode.Peripherals.Bus;
using Antmicro.Renode.Logging;

namespace Antmicro.Renode.Peripherals.Miscellaneous
{
    public class DDR_CSR_APB_20083000 : IDoubleWordPeripheral, IKnownSize
    {
        private ulong CFG_WRITE_CRC = 0x00000000;
        private ulong CFG_MPR_READ_FORMAT = 0x00000000;
        private ulong CFG_WR_CMD_LAT_CRC_DM = 0x00000000;
        private ulong CFG_FINE_GRAN_REF_MODE = 0x00000000;
        private ulong CFG_TEMP_SENSOR_READOUT = 0x00000000;
        private ulong CFG_PER_DRAM_ADDR_EN = 0x00000000;
        private ulong CFG_GEARDOWN_MODE = 0x00000000;
        private ulong CFG_WR_PREAMBLE = 0x00000000;
        private ulong CFG_RD_PREAMBLE = 0x00000000;
        private ulong CFG_RD_PREAMB_TRN_MODE = 0x00000000;
        private ulong CFG_SR_ABORT = 0x00000000;
        private ulong CFG_CS_TO_CMDADDR_LATENCY = 0x00000000;
        private ulong CFG_INT_VREF_MON = 0x00000000;
        private ulong CFG_TEMP_CTRL_REF_MODE = 0x00000000;
        private ulong CFG_TEMP_CTRL_REF_RANGE = 0x00000000;
        private ulong CFG_MAX_PWR_DOWN_MODE = 0x00000000;
        private ulong CFG_READ_DBI = 0x00000000;
        private ulong CFG_WRITE_DBI = 0x00000000;
        private ulong CFG_DATA_MASK = 0x00000001;
        private ulong CFG_CA_PARITY_PERSIST_ERR = 0x00000000;
        private ulong CFG_RTT_PARK = 0x00000000;
        private ulong CFG_ODT_INBUF_4_PD = 0x00000000;
        private ulong CFG_CA_PARITY_ERR_STATUS = 0x00000000;
        private ulong CFG_CRC_ERROR_CLEAR = 0x00000000;
        private ulong CFG_CA_PARITY_LATENCY = 0x00000000;
        private ulong CFG_CCD_S = 0x00000000;
        private ulong CFG_CCD_L = 0x00000000;
        private ulong CFG_VREFDQ_TRN_ENABLE = 0x00000000;
        private ulong CFG_VREFDQ_TRN_RANGE = 0x00000000;
        private ulong CFG_VREFDQ_TRN_VALUE = 0x00000000;
        private ulong CFG_RRD_S = 0x00000003;
        private ulong CFG_RRD_L = 0x00000003;
        private ulong CFG_WTR_S = 0x00000002;
        private ulong CFG_WTR_L = 0x00000002;
        private ulong CFG_WTR_S_CRC_DM = 0x00000002;
        private ulong CFG_WTR_L_CRC_DM = 0x00000002;
        private ulong CFG_WR_CRC_DM = 0x00000004;
        private ulong CFG_RFC1 = 0x00000022;
        private ulong CFG_RFC2 = 0x00000022;
        private ulong CFG_RFC4 = 0x00000022;
        private ulong CFG_NIBBLE_DEVICES = 0x00000000;
        private ulong CFG_BIT_MAP_INDEX_CS0_0 = 0x00000000;
        private ulong CFG_BIT_MAP_INDEX_CS0_1 = 0x00000000;
        private ulong CFG_BIT_MAP_INDEX_CS1_0 = 0x00000000;
        private ulong CFG_BIT_MAP_INDEX_CS1_1 = 0x00000000;
        private ulong CFG_BIT_MAP_INDEX_CS2_0 = 0x00000000;
        private ulong CFG_BIT_MAP_INDEX_CS2_1 = 0x00000000;
        private ulong CFG_BIT_MAP_INDEX_CS3_0 = 0x00000000;
        private ulong CFG_BIT_MAP_INDEX_CS3_1 = 0x00000000;
        private ulong CFG_BIT_MAP_INDEX_CS4_0 = 0x00000000;
        private ulong CFG_BIT_MAP_INDEX_CS4_1 = 0x00000000;
        private ulong CFG_BIT_MAP_INDEX_CS5_0 = 0x00000000;
        private ulong CFG_BIT_MAP_INDEX_CS5_1 = 0x00000000;
        private ulong CFG_BIT_MAP_INDEX_CS6_0 = 0x00000000;
        private ulong CFG_BIT_MAP_INDEX_CS6_1 = 0x00000000;
        private ulong CFG_BIT_MAP_INDEX_CS7_0 = 0x00000000;
        private ulong CFG_BIT_MAP_INDEX_CS7_1 = 0x00000000;
        private ulong CFG_BIT_MAP_INDEX_CS8_0 = 0x00000000;
        private ulong CFG_BIT_MAP_INDEX_CS8_1 = 0x00000000;
        private ulong CFG_BIT_MAP_INDEX_CS9_0 = 0x00000000;
        private ulong CFG_BIT_MAP_INDEX_CS9_1 = 0x00000000;
        private ulong CFG_BIT_MAP_INDEX_CS10_0 = 0x00000000;
        private ulong CFG_BIT_MAP_INDEX_CS10_1 = 0x00000000;
        private ulong CFG_BIT_MAP_INDEX_CS11_0 = 0x00000000;
        private ulong CFG_BIT_MAP_INDEX_CS11_1 = 0x00000000;
        private ulong CFG_BIT_MAP_INDEX_CS12_0 = 0x00000000;
        private ulong CFG_BIT_MAP_INDEX_CS12_1 = 0x00000000;
        private ulong CFG_BIT_MAP_INDEX_CS13_0 = 0x00000000;
        private ulong CFG_BIT_MAP_INDEX_CS13_1 = 0x00000000;
        private ulong CFG_BIT_MAP_INDEX_CS14_0 = 0x00000000;
        private ulong CFG_BIT_MAP_INDEX_CS14_1 = 0x00000000;
        private ulong CFG_BIT_MAP_INDEX_CS15_0 = 0x00000000;
        private ulong CFG_BIT_MAP_INDEX_CS15_1 = 0x00000000;
        private ulong CFG_NUM_LOGICAL_RANKS_PER_3DS = 0x00000000;
        private ulong CFG_RFC_DLR1 = 0x00000048;
        private ulong CFG_RFC_DLR2 = 0x0000002C;
        private ulong CFG_RFC_DLR4 = 0x00000020;
        private ulong CFG_RRD_DLR = 0x00000004;
        private ulong CFG_FAW_DLR = 0x00000010;
        private ulong CFG_ADVANCE_ACTIVATE_READY = 0x00000000;

        public uint ReadDoubleWord(long offset)
        {
            ulong value = 0x0u;
            switch(offset)
            {
                case 0xC00:
                    value = CFG_WRITE_CRC;
                    break;
                case 0xC04:
                    value = CFG_MPR_READ_FORMAT;
                    break;
                case 0xC08:
                    value = CFG_WR_CMD_LAT_CRC_DM;
                    break;
                case 0xC0C:
                    value = CFG_FINE_GRAN_REF_MODE;
                    break;
                case 0xC10:
                    value = CFG_TEMP_SENSOR_READOUT;
                    break;
                case 0xC14:
                    value = CFG_PER_DRAM_ADDR_EN;
                    break;
                case 0xC18:
                    value = CFG_GEARDOWN_MODE;
                    break;
                case 0xC1C:
                    value = CFG_WR_PREAMBLE;
                    break;
                case 0xC20:
                    value = CFG_RD_PREAMBLE;
                    break;
                case 0xC24:
                    value = CFG_RD_PREAMB_TRN_MODE;
                    break;
                case 0xC28:
                    value = CFG_SR_ABORT;
                    break;
                case 0xC2C:
                    value = CFG_CS_TO_CMDADDR_LATENCY;
                    break;
                case 0xC30:
                    value = CFG_INT_VREF_MON;
                    break;
                case 0xC34:
                    value = CFG_TEMP_CTRL_REF_MODE;
                    break;
                case 0xC38:
                    value = CFG_TEMP_CTRL_REF_RANGE;
                    break;
                case 0xC3C:
                    value = CFG_MAX_PWR_DOWN_MODE;
                    break;
                case 0xC40:
                    value = CFG_READ_DBI;
                    break;
                case 0xC44:
                    value = CFG_WRITE_DBI;
                    break;
                case 0xC48:
                    value = CFG_DATA_MASK;
                    break;
                case 0xC4C:
                    value = CFG_CA_PARITY_PERSIST_ERR;
                    break;
                case 0xC50:
                    value = CFG_RTT_PARK;
                    break;
                case 0xC54:
                    value = CFG_ODT_INBUF_4_PD;
                    break;
                case 0xC58:
                    value = CFG_CA_PARITY_ERR_STATUS;
                    break;
                case 0xC5C:
                    value = CFG_CRC_ERROR_CLEAR;
                    break;
                case 0xC60:
                    value = CFG_CA_PARITY_LATENCY;
                    break;
                case 0xC64:
                    value = CFG_CCD_S;
                    break;
                case 0xC68:
                    value = CFG_CCD_L;
                    break;
                case 0xC6C:
                    value = CFG_VREFDQ_TRN_ENABLE;
                    break;
                case 0xC70:
                    value = CFG_VREFDQ_TRN_RANGE;
                    break;
                case 0xC74:
                    value = CFG_VREFDQ_TRN_VALUE;
                    break;
                case 0xC78:
                    value = CFG_RRD_S;
                    break;
                case 0xC7C:
                    value = CFG_RRD_L;
                    break;
                case 0xC80:
                    value = CFG_WTR_S;
                    break;
                case 0xC84:
                    value = CFG_WTR_L;
                    break;
                case 0xC88:
                    value = CFG_WTR_S_CRC_DM;
                    break;
                case 0xC8C:
                    value = CFG_WTR_L_CRC_DM;
                    break;
                case 0xC90:
                    value = CFG_WR_CRC_DM;
                    break;
                case 0xC94:
                    value = CFG_RFC1;
                    break;
                case 0xC98:
                    value = CFG_RFC2;
                    break;
                case 0xC9C:
                    value = CFG_RFC4;
                    break;
                case 0xCC4:
                    value = CFG_NIBBLE_DEVICES;
                    break;
                case 0xCE0:
                    value = CFG_BIT_MAP_INDEX_CS0_0;
                    break;
                case 0xCE4:
                    value = CFG_BIT_MAP_INDEX_CS0_1;
                    break;
                case 0xCE8:
                    value = CFG_BIT_MAP_INDEX_CS1_0;
                    break;
                case 0xCEC:
                    value = CFG_BIT_MAP_INDEX_CS1_1;
                    break;
                case 0xCF0:
                    value = CFG_BIT_MAP_INDEX_CS2_0;
                    break;
                case 0xCF4:
                    value = CFG_BIT_MAP_INDEX_CS2_1;
                    break;
                case 0xCF8:
                    value = CFG_BIT_MAP_INDEX_CS3_0;
                    break;
                case 0xCFC:
                    value = CFG_BIT_MAP_INDEX_CS3_1;
                    break;
                case 0xD00:
                    value = CFG_BIT_MAP_INDEX_CS4_0;
                    break;
                case 0xD04:
                    value = CFG_BIT_MAP_INDEX_CS4_1;
                    break;
                case 0xD08:
                    value = CFG_BIT_MAP_INDEX_CS5_0;
                    break;
                case 0xD0C:
                    value = CFG_BIT_MAP_INDEX_CS5_1;
                    break;
                case 0xD10:
                    value = CFG_BIT_MAP_INDEX_CS6_0;
                    break;
                case 0xD14:
                    value = CFG_BIT_MAP_INDEX_CS6_1;
                    break;
                case 0xD18:
                    value = CFG_BIT_MAP_INDEX_CS7_0;
                    break;
                case 0xD1C:
                    value = CFG_BIT_MAP_INDEX_CS7_1;
                    break;
                case 0xD20:
                    value = CFG_BIT_MAP_INDEX_CS8_0;
                    break;
                case 0xD24:
                    value = CFG_BIT_MAP_INDEX_CS8_1;
                    break;
                case 0xD28:
                    value = CFG_BIT_MAP_INDEX_CS9_0;
                    break;
                case 0xD2C:
                    value = CFG_BIT_MAP_INDEX_CS9_1;
                    break;
                case 0xD30:
                    value = CFG_BIT_MAP_INDEX_CS10_0;
                    break;
                case 0xD34:
                    value = CFG_BIT_MAP_INDEX_CS10_1;
                    break;
                case 0xD38:
                    value = CFG_BIT_MAP_INDEX_CS11_0;
                    break;
                case 0xD3C:
                    value = CFG_BIT_MAP_INDEX_CS11_1;
                    break;
                case 0xD40:
                    value = CFG_BIT_MAP_INDEX_CS12_0;
                    break;
                case 0xD44:
                    value = CFG_BIT_MAP_INDEX_CS12_1;
                    break;
                case 0xD48:
                    value = CFG_BIT_MAP_INDEX_CS13_0;
                    break;
                case 0xD4C:
                    value = CFG_BIT_MAP_INDEX_CS13_1;
                    break;
                case 0xD50:
                    value = CFG_BIT_MAP_INDEX_CS14_0;
                    break;
                case 0xD54:
                    value = CFG_BIT_MAP_INDEX_CS14_1;
                    break;
                case 0xD58:
                    value = CFG_BIT_MAP_INDEX_CS15_0;
                    break;
                case 0xD5C:
                    value = CFG_BIT_MAP_INDEX_CS15_1;
                    break;
                case 0xD60:
                    value = CFG_NUM_LOGICAL_RANKS_PER_3DS;
                    break;
                case 0xD64:
                    value = CFG_RFC_DLR1;
                    break;
                case 0xD68:
                    value = CFG_RFC_DLR2;
                    break;
                case 0xD6C:
                    value = CFG_RFC_DLR4;
                    break;
                case 0xD70:
                    value = CFG_RRD_DLR;
                    break;
                case 0xD74:
                    value = CFG_FAW_DLR;
                    break;
                case 0xD98:
                    value = CFG_ADVANCE_ACTIVATE_READY;
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
                case 0xC00:
                    CFG_WRITE_CRC =  value;
                    break;
                case 0xC04:
                    CFG_MPR_READ_FORMAT =  value;
                    break;
                case 0xC08:
                    CFG_WR_CMD_LAT_CRC_DM =  value;
                    break;
                case 0xC0C:
                    CFG_FINE_GRAN_REF_MODE =  value;
                    break;
                case 0xC10:
                    CFG_TEMP_SENSOR_READOUT =  value;
                    break;
                case 0xC14:
                    CFG_PER_DRAM_ADDR_EN =  value;
                    break;
                case 0xC18:
                    CFG_GEARDOWN_MODE =  value;
                    break;
                case 0xC1C:
                    CFG_WR_PREAMBLE =  value;
                    break;
                case 0xC20:
                    CFG_RD_PREAMBLE =  value;
                    break;
                case 0xC24:
                    CFG_RD_PREAMB_TRN_MODE =  value;
                    break;
                case 0xC28:
                    CFG_SR_ABORT =  value;
                    break;
                case 0xC2C:
                    CFG_CS_TO_CMDADDR_LATENCY =  value;
                    break;
                case 0xC30:
                    CFG_INT_VREF_MON =  value;
                    break;
                case 0xC34:
                    CFG_TEMP_CTRL_REF_MODE =  value;
                    break;
                case 0xC38:
                    CFG_TEMP_CTRL_REF_RANGE =  value;
                    break;
                case 0xC3C:
                    CFG_MAX_PWR_DOWN_MODE =  value;
                    break;
                case 0xC40:
                    CFG_READ_DBI =  value;
                    break;
                case 0xC44:
                    CFG_WRITE_DBI =  value;
                    break;
                case 0xC48:
                    CFG_DATA_MASK =  value;
                    break;
                case 0xC4C:
                    CFG_CA_PARITY_PERSIST_ERR =  value;
                    break;
                case 0xC50:
                    CFG_RTT_PARK =  value;
                    break;
                case 0xC54:
                    CFG_ODT_INBUF_4_PD =  value;
                    break;
                case 0xC58:
                    CFG_CA_PARITY_ERR_STATUS =  value;
                    break;
                case 0xC5C:
                    CFG_CRC_ERROR_CLEAR =  value;
                    break;
                case 0xC60:
                    CFG_CA_PARITY_LATENCY =  value;
                    break;
                case 0xC64:
                    CFG_CCD_S =  value;
                    break;
                case 0xC68:
                    CFG_CCD_L =  value;
                    break;
                case 0xC6C:
                    CFG_VREFDQ_TRN_ENABLE =  value;
                    break;
                case 0xC70:
                    CFG_VREFDQ_TRN_RANGE =  value;
                    break;
                case 0xC74:
                    CFG_VREFDQ_TRN_VALUE =  value;
                    break;
                case 0xC78:
                    CFG_RRD_S =  value;
                    break;
                case 0xC7C:
                    CFG_RRD_L =  value;
                    break;
                case 0xC80:
                    CFG_WTR_S =  value;
                    break;
                case 0xC84:
                    CFG_WTR_L =  value;
                    break;
                case 0xC88:
                    CFG_WTR_S_CRC_DM =  value;
                    break;
                case 0xC8C:
                    CFG_WTR_L_CRC_DM =  value;
                    break;
                case 0xC90:
                    CFG_WR_CRC_DM =  value;
                    break;
                case 0xC94:
                    CFG_RFC1 =  value;
                    break;
                case 0xC98:
                    CFG_RFC2 =  value;
                    break;
                case 0xC9C:
                    CFG_RFC4 =  value;
                    break;
                case 0xCC4:
                    CFG_NIBBLE_DEVICES =  value;
                    break;
                case 0xCE0:
                    CFG_BIT_MAP_INDEX_CS0_0 =  value;
                    break;
                case 0xCE4:
                    CFG_BIT_MAP_INDEX_CS0_1 =  value;
                    break;
                case 0xCE8:
                    CFG_BIT_MAP_INDEX_CS1_0 =  value;
                    break;
                case 0xCEC:
                    CFG_BIT_MAP_INDEX_CS1_1 =  value;
                    break;
                case 0xCF0:
                    CFG_BIT_MAP_INDEX_CS2_0 =  value;
                    break;
                case 0xCF4:
                    CFG_BIT_MAP_INDEX_CS2_1 =  value;
                    break;
                case 0xCF8:
                    CFG_BIT_MAP_INDEX_CS3_0 =  value;
                    break;
                case 0xCFC:
                    CFG_BIT_MAP_INDEX_CS3_1 =  value;
                    break;
                case 0xD00:
                    CFG_BIT_MAP_INDEX_CS4_0 =  value;
                    break;
                case 0xD04:
                    CFG_BIT_MAP_INDEX_CS4_1 =  value;
                    break;
                case 0xD08:
                    CFG_BIT_MAP_INDEX_CS5_0 =  value;
                    break;
                case 0xD0C:
                    CFG_BIT_MAP_INDEX_CS5_1 =  value;
                    break;
                case 0xD10:
                    CFG_BIT_MAP_INDEX_CS6_0 =  value;
                    break;
                case 0xD14:
                    CFG_BIT_MAP_INDEX_CS6_1 =  value;
                    break;
                case 0xD18:
                    CFG_BIT_MAP_INDEX_CS7_0 =  value;
                    break;
                case 0xD1C:
                    CFG_BIT_MAP_INDEX_CS7_1 =  value;
                    break;
                case 0xD20:
                    CFG_BIT_MAP_INDEX_CS8_0 =  value;
                    break;
                case 0xD24:
                    CFG_BIT_MAP_INDEX_CS8_1 =  value;
                    break;
                case 0xD28:
                    CFG_BIT_MAP_INDEX_CS9_0 =  value;
                    break;
                case 0xD2C:
                    CFG_BIT_MAP_INDEX_CS9_1 =  value;
                    break;
                case 0xD30:
                    CFG_BIT_MAP_INDEX_CS10_0 =  value;
                    break;
                case 0xD34:
                    CFG_BIT_MAP_INDEX_CS10_1 =  value;
                    break;
                case 0xD38:
                    CFG_BIT_MAP_INDEX_CS11_0 =  value;
                    break;
                case 0xD3C:
                    CFG_BIT_MAP_INDEX_CS11_1 =  value;
                    break;
                case 0xD40:
                    CFG_BIT_MAP_INDEX_CS12_0 =  value;
                    break;
                case 0xD44:
                    CFG_BIT_MAP_INDEX_CS12_1 =  value;
                    break;
                case 0xD48:
                    CFG_BIT_MAP_INDEX_CS13_0 =  value;
                    break;
                case 0xD4C:
                    CFG_BIT_MAP_INDEX_CS13_1 =  value;
                    break;
                case 0xD50:
                    CFG_BIT_MAP_INDEX_CS14_0 =  value;
                    break;
                case 0xD54:
                    CFG_BIT_MAP_INDEX_CS14_1 =  value;
                    break;
                case 0xD58:
                    CFG_BIT_MAP_INDEX_CS15_0 =  value;
                    break;
                case 0xD5C:
                    CFG_BIT_MAP_INDEX_CS15_1 =  value;
                    break;
                case 0xD60:
                    CFG_NUM_LOGICAL_RANKS_PER_3DS =  value;
                    break;
                case 0xD64:
                    CFG_RFC_DLR1 =  value;
                    break;
                case 0xD68:
                    CFG_RFC_DLR2 =  value;
                    break;
                case 0xD6C:
                    CFG_RFC_DLR4 =  value;
                    break;
                case 0xD70:
                    CFG_RRD_DLR =  value;
                    break;
                case 0xD74:
                    CFG_FAW_DLR =  value;
                    break;
                case 0xD98:
                    CFG_ADVANCE_ACTIVATE_READY =  value;
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


