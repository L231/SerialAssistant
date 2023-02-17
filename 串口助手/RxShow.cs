using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 串口助手
{
    public partial class Form1
    {
        private int rxDataLength;
        private byte[] rxData;
        private MultiCommunication_t CurrentDevice = new MultiCommunication_t();
        private Thread threadRxDataHandle;
        private AutoResetEvent threadRxDataHandle_Supend = new AutoResetEvent(false);


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
                            CurrentDevice = p;
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
                            CurrentDevice = p;
                            break;
                        }
                    }
                }
                if (CurrentDevice.name == "S0")
                    CurrentDevice.hex = toolStripButton_RxHEX.Text;
            }
            catch { }

            /* 自动换行开启了，需要先关闭自动换行的定时器 */
            if (toolStripButton_RxAutoNewline.Text == "ON")
            {
                gTimer_RxAutoNewline.Stop();
            }

            try
            {
                if (CurrentDevice.hex == "ASCII")
                    length = 处理中文断帧乱码问题(CurrentDevice, ref rx_buf, length);
                rxData = rx_buf;
                rxDataLength = length;
                if(threadRxDataHandle == null)
                {
                    threadRxDataHandle = new Thread(RxDataHandle_Thread);
                    threadRxDataHandle.Start(CurrentDevice);
                }
                threadRxDataHandle_Supend.Set();
            }
            catch { }
            return true;
        }

        private void RxDataHandle_Thread(object dev)
        {
            while(true)
            {
                string MsgHead = "";
                string LogMsgHead = "";
                if (CurrentDevice.name != "S0")
                    LogMsgHead = "[" + CurrentDevice.name + "]";
                try
                {
                    DataTypeConversion dataType = new DataTypeConversion();
                    string str = dataType.ByteToString(CurrentDevice.hex, rxData, rxDataLength);
                    if (CurrentDevice.hex != "ASCII")
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
                    if (CurrentDevice.hex != "ASCII")
                    {
                        realTimeCurve.RT_Curve_WriteData(rxData, rxDataLength);
                        MsgLookup_16To10(rxData, rxDataLength, MsgHead);
                    }
                    if (SuperMsgCurrent != null && CurrentDevice.name == "S0")
                    {
                        textBox_SuperMsgRxShow.AppendText(MsgHead + str);
                        SuperMsgCurrent.RxMsg_Handler(rxData);
                        SuperMsgCurrent = null;
                    }
                }
                catch { }
                gRxNum += rxDataLength;
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
                threadRxDataHandle_Supend.Reset();
                threadRxDataHandle_Supend.WaitOne();
            }
        }
    }
}
