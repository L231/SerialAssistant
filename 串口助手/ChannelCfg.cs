using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 串口助手
{
    public partial class Form1
    {
        struct MultiCommunication_t
        {
            public string name;
            public string type;
            public string hex;
            public string MsgTailType;
            public SerialPort uart;
            public Socket tcp;
            public Thread threadTcp;
            public string saveInfo;
        };
        /// <summary>
        /// 通信通道的链表
        /// </summary>
        List<MultiCommunication_t> listMultiComm = new List<MultiCommunication_t>();

        MultiCommunication_t masterComm;
        MultiCommunication_t multi;

        public bool 设备注册(string name,
                            string open, 
                            string com, 
                            string br_or_ip, 
                            string tcpport,
                            string msgtail,
                            string hex, 
                            string saveInfo)
        {
            if(open == "开启")
            {
                try
                {
                    foreach(MultiCommunication_t p in listMultiComm)
                    {
                        if(p.name == name)
                        {
                            MessageBox.Show("设备名重复，请更改！", "ERROR");
                            return false;
                        }
                    }
                    //处理报尾
                    multi.MsgTailType = msgtail;
                    multi.name = name;
                    multi.hex = hex;
                    if (com == "TCP Client")
                    {
                        multi.type = com;
                        IPAddress addr = IPAddress.Parse(br_or_ip);
                        IPEndPoint endPoint = new IPEndPoint(addr, int.Parse(tcpport));
                        multi.tcp = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                        multi.tcp.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, 5000);
                        //multi.tcp.Connect(endPoint);
                        SocketClient socketClient = new SocketClient();
                        if (!socketClient.Connect(multi.tcp, endPoint, 1000))
                            goto CONNECT_ERR;
                        multi.tcp.ReceiveTimeout = 500;
                        multi.threadTcp = new Thread(TCP_ClientRx);
                        multi.threadTcp.IsBackground = true;
                        multi.threadTcp.Start(multi.tcp);
                    }
                    else
                    {
                        multi.type = "uart";
                        multi.uart = new SerialPort();
                        string[] str = com.Split(new char[2] { '(', ')' });
                        multi.uart.PortName = str[1];
                        multi.uart.BaudRate = Convert.ToInt32(br_or_ip);
                        multi.uart.ReadTimeout = 500;
                        multi.uart.Open();
                        multi.uart.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
                    }
                    multi.saveInfo = saveInfo;
                    listMultiComm.Add(multi);
                    return true;
                }
                catch
                {
                }
                CONNECT_ERR:
                MessageBox.Show("端口打开失败，请检查！", "ERROR");
            }
            else
            {
                try
                {
                    for (int pos = 0; pos < listMultiComm.Count(); pos++)
                    {
                        if (listMultiComm[pos].name == name)
                        {
                            if (listMultiComm[pos].type == "TCP Client")
                            {
                                listMultiComm[pos].threadTcp.Abort();
                                listMultiComm[pos].tcp.Shutdown(SocketShutdown.Both);
                                listMultiComm[pos].tcp.Close();
                            }
                            else
                                listMultiComm[pos].uart.Close();
                            //删除该设备
                            listMultiComm.RemoveAt(pos);
                            return true;
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("端口关闭异常！", "ERROR");
                }
            }
            return false;
        }


        private void 加载缓存的设备()
        {
            ChannelForm formCH;
            try
            {
                int max = Convert.ToInt32(gCfg.SysCfgFileRead("多通道配置区", "最大设备数"));
                for (int cnt = 0; cnt < max; cnt++)
                {
                    string saveInfo = gCfg.SysCfgFileRead("多通道配置区", "设备" + cnt.ToString());

                    formCH = new ChannelForm();
                    formCH.TopLevel = false;
                    formCH.formMain = this;
                    //formCH.MdiParent = this;
                    flowLayoutPanel_Channel.Controls.Add(formCH);
                    formCH.Dock = DockStyle.Top;
                    formCH.Show();
                    formCH.setChannelFormParam(saveInfo);
                }
            }
            catch { }
        }
        private void ChannelListCreate()
        {
            ChannelForm formCH = new ChannelForm();
            formCH.TopLevel = false;
            formCH.formMain = this;
            //formCH.MdiParent = this;
            flowLayoutPanel_Channel.Controls.Add(formCH);
            formCH.Dock = DockStyle.Top;
            formCH.Show();
        }

        public void ChannelListDelete(Control control)
        {
            flowLayoutPanel_Channel.Controls.Remove(control);
        }
    }
}
