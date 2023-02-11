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

        public byte GetByteCheckSum(byte[] data, int length)
        {
            byte cs = 0;
            for (int i = 0; i < length; i++)
            {
                cs += data[i];
            }
            return (byte)(~cs);
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
