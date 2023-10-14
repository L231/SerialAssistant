using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace 串口助手
{
    class DataTypeConversion
    {
        public int GetStringNumber(string str)
        {
            try
            {
                string pattern = @"[^0-9]+";
                Regex rgx = new Regex(pattern);
                return Convert.ToInt32(rgx.Replace(str, ""));
            }
            catch { }
            return 0;
        }
        public bool GetStringSingle(string str, ref float value)
        {
            //str = Regex.Replace(str, @"[^\d.\d]", " ");
            Regex r = new Regex(@"\d*\.\d*|0\.\d*[1-9]\d*$");
            string[] s = new string[] { r.Match(str).Value, r.Replace(str, "") };
            if(s[0] != "" && s[0] != ".")
            {
                value = Convert.ToSingle(s[0]);
                return true;
            }
            else if(s.Length > 1 && s[1] != "")
            {
                Regex regex = new Regex("[0-9]+", RegexOptions.IgnoreCase | RegexOptions.Singleline, TimeSpan.FromSeconds(2));
                MatchCollection mc = regex.Matches(s[1]);
                if(mc.Count > 0)
                {
                    value = Convert.ToSingle(mc[0].Groups[0].Value);
                    return true;
                }
            }
            return false;
        }

        public byte GetByteCheckSum(byte[] data, int length)
        {
            byte cs = 0;
            for (int i = 0; i < length; i++)
            {
                cs += data[i];
            }
            return (byte)(~cs);
        }

        public UInt16 GetModBusCRC16(byte[] data, int length)
        {
            int temp;
            UInt16 pos, bit;
            UInt16 crc = 0xFFFF;
            for(pos = 0; pos < length; pos++)
            {
                crc = (UInt16)(data[pos] ^ crc);
                for(bit = 0; bit < 8; bit++)
                {
                    temp = crc & 0x1;
                    crc >>= 1;
                    if (temp == 1)
                        crc ^= 0xA001;
                }
            }
            return crc;
        }



        public int ByteAddMsgTail(string MsgTailType, ref byte[] msg)
        {
            byte[] check;
            switch (MsgTailType)
            {
                case "无":
                    check = null;
                    break;
                case "CS":
                    check = new byte[1];
                    check[0] = GetByteCheckSum(msg, msg.Length);
                    break;
                case "ModBus":
                    UInt16 crc;
                    crc = GetModBusCRC16(msg, msg.Length);
                    check = new byte[2];
                    check[0] = (byte)(crc);
                    check[1] = (byte)(crc >> 8);
                    break;
                default:
                    check = StringToByte("HEX", MsgTailType);
                    break;
            }
            if (check != null)
            {
                int TxBufLen = msg.Length;
                Array.Resize<byte>(ref msg, TxBufLen + check.Length);
                Array.Copy(check, 0, msg, TxBufLen, check.Length);
            }
            return msg.Length;
        }

        /// <summary>
        /// 字符串转字节数组
        /// </summary>
        /// <param name="data_type">ASCII、HEX</param>
        /// <param name="data"></param>
        /// <returns></returns>
        public byte[] StringToByte(string data_type, string data)
        {
            try
            {
                byte[] buf;
                if (data_type == "ASCII")
                {
                    buf = Encoding.Default.GetBytes(data);
                }
                else
                {
                    int i = 0, length, len;
                    //string pattern = @"\s";
                    string replacement = "";
                    Regex rgx = new Regex(@"\s");
                    string str = rgx.Replace(data, replacement);

                    length = (str.Length - str.Length % 2) / 2;
                    len = length;
                    if (str.Length % 2 != 0)
                        len++;
                    buf = new byte[len];
                    //逐个字符变为16进制字节数据
                    for (i = 0; i < length; i++)
                    {
                        buf[i] = Convert.ToByte(str.Substring(i * 2, 2), 16);
                    }
                    if (str.Length % 2 != 0)
                    {
                        buf[i] = Convert.ToByte(str.Substring(i * 2, 1), 16);
                        length++;
                    }
                }
                return buf;
            }
            catch { }
            return null;
        }

        /// <summary>
        /// 字节数组转字符串
        /// </summary>
        /// <param name="data_type">ASCII、HEX</param>
        /// <param name="data"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public string ByteToString(string data_type, byte[] data, int length)
        {
            try
            {
                string s = "";
                if (data_type == "ASCII")
                {
                    s = Encoding.Default.GetString(data, 0, length);
                }
                else
                {
                    s = BitConverter.ToString(data.Skip(0).Take(length).ToArray()).Replace("-", " ");
                }
                return s;
            }
            catch
            {

            }
            return "";
        }
    }
}
