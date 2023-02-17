using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace 串口助手
{
    public class RealTimeCurve_Channel
    {
        [System.Runtime.InteropServices.DllImport("msvcrt.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern int memcmp(byte[] b1, byte[] b2, long count);


        public class MsgDecode
        {
            /// <summary>
            /// 0：整型，1：浮点数，2：字符串
            /// </summary>
            public int data_type = 0;
            /// <summary>
            /// 高位在前的标志
            /// </summary>
            public bool flag_msb = false;
            /// <summary>
            /// 数据在报文中的偏移量
            /// </summary>
            public int in_msg_pos = 1;
            /// <summary>
            /// 数据的字节数
            /// </summary>
            public int byte_num = 4;
            /// <summary>
            /// 报头
            /// </summary>
            public byte[] head;
        };
        public class Channel
        {
            /// <summary>
            /// 报文解析规则
            /// </summary>
            public MsgDecode msgDecode = new MsgDecode();
            /// <summary>
            /// 曲线使能
            /// </summary>
            public bool enable = true;
            /// <summary>
            /// 曲线幅值的放大倍率
            /// </summary>
            public float gain = 1;
            public Series series = new Series();
        };


        private double seriesY;
        private Series Series1 = new Series();
        private Thread threadSeriesWrite;
        private AutoResetEvent threadSeriesWrite_Supend = new AutoResetEvent(false);


        public Channel Create(string name, byte[] mask)
        {
            Channel channel = new Channel();
            channel.msgDecode.head = mask;
            channel.enable = true;
            channel.series.Name = name;
            channel.series.MarkerStyle = MarkerStyle.Circle;
            channel.series.ChartType = SeriesChartType.Spline;
            return channel;
        }



        private void SeriesWriteData_Thread()
        {
            while (true)
            {
                if (Series1.Points.Count > 400)
                    Series1.Points.RemoveAt(0);
                try
                {
                    //过大的数值，会导致窗体崩溃
                    Series1.Points.AddY(seriesY);
                }
                catch { }
                threadSeriesWrite_Supend.Reset();
                threadSeriesWrite_Supend.WaitOne();
            }
        }

        public void SeriesWriteData(Channel ch, double yValue)
        {
            seriesY = yValue;
            Series1 = ch.series;
            threadSeriesWrite_Supend.Set();
        }
        /// <summary>
        /// 通过报文绘制曲线
        /// </summary>
        /// <param name="ch"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool SeriesWriteData(Channel ch, byte[] data, int length)
        {
            if (ch.msgDecode.head == null)
                return false;
            if (memcmp(data, ch.msgDecode.head, ch.msgDecode.head.Length) == 0)
            {
                if (ch.enable)
                {
                    seriesY = ch.gain * MsgDecode_GetPointY(ch.msgDecode, data, length);
                    Series1 = ch.series;
                    threadSeriesWrite_Supend.Set();
                }
                return true;
            }
            return false;
        }

        private double MsgDecode_GetPointY(MsgDecode decode, byte[] data, int length)
        {
            byte[] buf;
            double yValue = 0;
            switch (decode.data_type)
            {
                //整型
                case 0:
                    if (length <= decode.in_msg_pos + decode.byte_num)
                        goto MSG_LENGTH_ERR;
                    buf = data.Skip(decode.in_msg_pos).Take(decode.byte_num).ToArray();
                    if (true == decode.flag_msb)
                    {
                        for (int i = 0; i < decode.byte_num; i++)
                            yValue = (yValue * 256) + buf[i];
                    }
                    else
                    {
                        for (int i = decode.byte_num - 1; i > 0; i--)
                            yValue = (yValue * 256) + buf[i];
                    }
                    break;
                    //浮点数
                case 1:
                    if (length <= decode.in_msg_pos + 4)
                        goto MSG_LENGTH_ERR;
                    byte[] single = data.Skip(decode.in_msg_pos).Take(4).ToArray();
                    if (decode.flag_msb)
                        Array.Reverse(single);
                    yValue = BitConverter.ToSingle(single, 0);
                    break;
                    //字符串
                case 2:
                    if (length <= decode.in_msg_pos)
                        goto MSG_LENGTH_ERR;
                    string s = Encoding.Default.GetString(data, 0, length);
                    s = s.Substring(decode.in_msg_pos);
                    DataTypeConversion dataType = new DataTypeConversion();
                    float value = 0;
                    if(false == dataType.GetStringSingle(s, ref value))
                        goto MSG_LENGTH_ERR;
                    yValue = value;
                    break;
            }
            return yValue;
            MSG_LENGTH_ERR :
            return seriesY;
        }


        public void SeriesThreadCreate(Channel ch)
        {
            Series1 = ch.series;
            threadSeriesWrite_Supend.Reset();
            threadSeriesWrite = new Thread(SeriesWriteData_Thread);
            threadSeriesWrite.Start();
        }

        public void SeriesThreadRelease()
        {
            threadSeriesWrite.Abort();
        }


        public void SeriesClear(Channel ch)
        {
            ch.series.Points.Clear();
        }

    }
}
