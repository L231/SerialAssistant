using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace 串口助手
{
    public partial class Form1
    {
        //System.Timers.Timer timer刷新接收区 = new System.Timers.Timer(20);

        //struct RxShow_t
        //{
        //    public Color color;
        //    public string data;
        //};
        ///// <summary>
        ///// 
        ///// </summary>
        //List<RxShow_t> msgRx = new List<RxShow_t>();

        private void RxShowInit()
        {
            //timer刷新接收区.Elapsed += new System.Timers.ElapsedEventHandler(RxShow);
            //timer刷新接收区.AutoReset = true;
        }
        private void RxShow(object sender, EventArgs e)
        {
            ////if (msgWrite - msgRead == -1 || msgWrite - msgRead == 1)
            //if(msgRx.Count == 0)
            //{
            //    timer刷新接收区.Stop();
            //    return;
            //}
            //richTextBox_Rx.SelectionColor = msgRx[0].color;
            //richTextBox_Rx.AppendText(msgRx[0].data);
            //msgRx.RemoveAt(0);
        }

        private void SendMsgEcho(string data)
        {
            richTextBox_Rx.SelectionColor = Color.Gold;
            richTextBox_Rx.AppendText(data);
            gTimestampFlag = true;
        }
        private void WriteRxMsg(string data)
        {
            richTextBox_Rx.SelectionColor = Color.White;
            richTextBox_Rx.AppendText(data);
            gTimestampFlag = false;
        }

        private int 处理中文断帧乱码问题(MultiCommunication_t dev, ref byte[] data, int length)
        {
            int cnt = 0;
            for (int pos = 0; pos < length; pos++)
            {
                if (data[pos] > 0x80)
                    cnt++;
            }
            if (cnt % 2 == 1)
            {
                try
                {
                    if (dev.type == "uart")
                    {
                        if(dev.uart.BytesToRead > 0)
                            length += dev.uart.Read(data, length, 1);
                    }
                    else
                    {
                        SocketFlags flags = SocketFlags.None;
                        length += dev.tcp.Receive(data, length, 1, flags);
                    }
                }
                catch { }
            }
            return length;
        }

        /// <summary>
        /// 通信的接收处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private bool 数据接收_显示_解析_输出日志(object sender, string type, byte[] rx_buf, int length)
        {
            if (length == 0)
                return false;
            string MsgHead = "";
            string LogMsgHead = "";
            MultiCommunication_t Dev = new MultiCommunication_t();
            //找出当前的设备名
            try
            {
                if (type == "uart")
                {
                    System.IO.Ports.SerialPort uart = (System.IO.Ports.SerialPort)sender;
                    foreach (MultiCommunication_t p in listMultiComm)
                    {
                        if (p.uart == uart)
                        {
                            Dev = p;
                            break;
                        }
                    }
                }
                else
                {
                    Socket tcp = sender as Socket;
                    foreach (MultiCommunication_t p in listMultiComm)
                    {
                        if (p.tcp == tcp)
                        {
                            Dev = p;
                            break;
                        }
                    }
                }
                if (Dev.name != "S0")
                    LogMsgHead += "[" + Dev.name + "]";
                else
                    Dev.hex = toolStripButton_RxHEX.Text;
            }
            catch { }

            /* 自动换行开启了，需要先关闭自动换行的定时器 */
            if (toolStripButton_RxAutoNewline.Text == "ON")
            {
                gTimer_RxAutoNewline.Stop();
            }

            try
            {
                if (Dev.hex == "ASCII")
                    length = 处理中文断帧乱码问题(Dev, ref rx_buf, length);
                DataTypeConversion dataType = new DataTypeConversion();
                string str = dataType.ByteToString(Dev.hex, rx_buf, length);
                if (Dev.hex != "ASCII")
                    str += " ";
                /* 处理时间戳 */
                if (toolStripButton_Timestamp.Text == "ON")
                {
                    LogMsgHead += DateTime.Now.ToString("HH:mm:ss.fff") + "<<";
                }
                if (gTimestampFlag)
                {
                    MsgHead = System.Environment.NewLine + LogMsgHead;
                }
                //显示接收的数据
                WriteRxMsg(MsgHead + str);
                commLog.LogWriteMsg(LogMsgHead + str);
                if (Dev.hex != "ASCII")
                {
                    MsgLookup_16To10(rx_buf, length, MsgHead);
                }
                if(SuperMsgCurrent != null && Dev.name == "S0")
                {
                    textBox_SuperMsgRxShow.AppendText(MsgHead + str);
                    SuperMsgCurrent.RxMsg_Handler(rx_buf);
                    SuperMsgCurrent = null;
                }
            }
            catch { }
            gRxNum += length;
            Label_Status.Text = "OPEN    TX:" + gTxNum + "    RX:" + gRxNum;

            /* 自动换行打开了，此时开启它的定时器 */
            if (toolStripButton_RxAutoNewline.Text == "ON")
            {
                gTimer_RxAutoNewline.Start();
            }
            if (toolStripButton_RecClear.Enabled == false)
            {
                toolStripButton_RecClear.Enabled = true;
                toolStripButton_RecClear.BackColor = Color.Gold;
            }
            return true;
        }
    }
}
