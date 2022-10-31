using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.IO;
using System.Threading;
using IniFile;

namespace 串口助手
{
    public partial class Form1 : Form
    {
        int gTxNum = 0;
        int gRxNum = 0;
        bool gTimestampFlag = true;
        System.Timers.Timer gTimer_RxAutoNewline = new System.Timers.Timer(100);



        private Socket server;
        Thread threadServer;

        string gComMode;
        Config gCfg = new Config();



        private void Timer_RxAutoNewline_OutHandle(object sender, EventArgs e)
        {
            gTimestampFlag = true;
            richTextBox_Rx.AppendText(System.Environment.NewLine);
            gTimer_RxAutoNewline.Stop();
        }
        private void Timer_RxAutoNewLine_Init()
        {
            ///* 如果波特率>10000, t(5byte)<5ms */
            //if (serialPort1.BaudRate > 10000)
            gTimer_RxAutoNewline = new System.Timers.Timer(30);
            //else
            //    gTimer_RxAutoNewline = new System.Timers.Timer(150000 / serialPort1.BaudRate);
            gTimer_RxAutoNewline.Elapsed += new System.Timers.ElapsedEventHandler(Timer_RxAutoNewline_OutHandle);
            gTimer_RxAutoNewline.AutoReset = true;
        }

        private void TCP_ClientRx(object sockConnectionparn)
        {
            Socket sockConnection = sockConnectionparn as Socket;
            byte[] buffMsgRec = new byte[1024 * 1024];
            int len = 0;
            string time = "";
            while (true)
            {
                if (gBootloaderFlag == false)
                {
                    try
                    {
                        sockConnection.ReceiveTimeout = 100;
                        len = sockConnection.Receive(buffMsgRec);
                        if (len > 0)
                        {
                            /* 自动换行开启了，需要先关闭自动换行的定时器 */
                            if (toolStripButton_RxAutoNewline.Text == "ON" && gTimer_RxAutoNewline.Enabled)
                            {
                                gTimer_RxAutoNewline.Stop();
                            }
                            /* 时间戳开启了，同时强制打开换行 */
                            if (toolStripButton_Timestamp.Text == "ON")
                            {
                                if (gTimestampFlag)
                                {
                                    gTimestampFlag = false;
                                    richTextBox_Rx.SelectionColor = Color.Gold;
                                    time = DateTime.Now.ToString("HH:mm:ss.fff") + "<<";
                                    richTextBox_Rx.AppendText(time);
                                    richTextBox_Rx.SelectionColor = Color.White;
                                }
                            }
                            string str = ByteToString(toolStripButton_RxHEX.Text, buffMsgRec, len);
                            richTextBox_Rx.AppendText(str);
                            LogWriteMsg(time + str);
                            if (toolStripButton_RxHEX.Text != "ASCII")
                            {
                                MsgLookup_16To10(buffMsgRec, len, time);
                            }
                            /* 自动换行打开了，此时开启它的定时器 */
                            if (toolStripButton_RxAutoNewline.Text == "ON")
                            {
                                gTimer_RxAutoNewline.Stop();
                                gTimer_RxAutoNewline.Start();
                            }

                            if (toolStripButton_RecClear.Enabled == false)
                            {
                                toolStripButton_RecClear.Enabled = true;
                                toolStripButton_RecClear.BackColor = Color.Gold;
                            }
                            gRxNum += len;
                            Label_Status.Text = "OPEN    TX:" + gTxNum + "    RX:" + gRxNum;
                        }
                    }
                    catch
                    {
                        continue;
                    }
                }
                else
                    Thread.Sleep(100);
            }
        }
        public Form1()
        {
            InitializeComponent();
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                SerialPortNumberUpadta(toolStripComboBox_SerialPort);
                toolStripComboBox_SerialPort.Text = System.IO.Ports.SerialPort.GetPortNames()[0];
            }
            catch
            {

            }
            gComMode = "";
            toolStripButton_TxHEX.Text = "ASCII";
            toolStripButton_RxHEX.Text = "ASCII";
            toolStripButton_Master.Text = "开启";
            toolStripButton_Timestamp.Text = "OFF";
            toolStripButton_RxAutoNewline.Text = "OFF";

            加载设定();
            gCfg.TableTxCreate(tableLayoutPanel1, tableLayoutPanel2);
            splitContainer1.Size = new Size(246, (20 * gCfg.TxListNum) + 200);
            gCfg.TxListFirstLoad();
            TxListEventReg();
        }

        private void TxListEventReg()
        {
            for (int i = 0; i < gCfg.TxListNum; i++)
            {
                gCfg.TextboxTX[i].KeyUp += new KeyEventHandler(TextboxTX_KeyUp);
                gCfg.TextboxTX[i].GotFocus += new EventHandler(TextboxTX_GotFocusClick);
                //gCfg.TextboxTX[i].LostFocus += new EventHandler(TextboxTX_LostFocusClick);
                gCfg.Button[i].Click += new EventHandler(button_Click);
            }
        }

        private static void SerialPortNumberUpadta(ToolStripComboBox combo)
        {
            /* 清除当前组合框的下拉菜单内容 */
            combo.Items.Clear();
            combo.Items.AddRange(System.IO.Ports.SerialPort.GetPortNames());
            combo.Items.Add("TCP Client");
            //combo.Items.Add("TCP Server");
        }
        
        private void ComTx(string data, string data_type)
        {
            try
            {
                int length = 0;
                byte[] TxBuf = StringToByte(data_type, data);
                if (TxBuf == null)
                    return;
                length = TxBuf.Length;
                string time = "";
                if (gTxShowFlag && gBootloaderFlag == false)
                {
                    richTextBox_Rx.SelectionColor = Color.Gold;
                    time = DateTime.Now.ToString("HH:mm:ss.fff") + ">>";
                    richTextBox_Rx.AppendText(time);
                    //richTextBox_Rx.SelectionColor = Color.White;
                    string str = ByteToString(data_type, TxBuf, length);
                    richTextBox_Rx.AppendText(str);
                    LogWriteMsg(time + str);
                    richTextBox_Rx.AppendText(System.Environment.NewLine);
                }
                if (gComMode == "TCP Client")
                    server.Send(TxBuf, 0, length, SocketFlags.None);
                else
                {
                    serialPort1.Write(TxBuf, 0, length);
                }
                gTxNum += length;
                Label_Status.Text = "OPEN    TX:" + gTxNum + "    RX:" + gRxNum;
            }
            catch
            {

            }
        }

        private int ComRx(byte[] buf)
        {
            try
            {
                int length = 0;
                if (gComMode == "TCP Client")
                {
                    server.ReceiveTimeout = 1000;
                    length = server.Receive(buf);
                }
                else
                {
                    length = serialPort1.Read(buf, 0, buf.Length);
                }
                return length;
                //gRxNum += length;
                //Label_Status.Text = "OPEN    TX:" + gTxNum + "    RX:" + gRxNum;
            }
            catch
            { }
            return 0;
        }
        private void ComRx(byte[] buf, int length)
        {
            try
            {
                if (gComMode == "TCP Client")
                {
                    server.ReceiveTimeout = 1000;
                    server.Receive(buf);
                }
                else
                {
                    serialPort1.Read(buf, 0, length);
                }
                gRxNum += length;
                Label_Status.Text = "OPEN    TX:" + gTxNum + "    RX:" + gRxNum;
            }
            catch
            { }
        }
        private void SerialPortTx()
        {
            try
            {
                ComTx(richTextBox_Tx.Text, toolStripButton_TxHEX.Text);
            }
            catch
            {

            }
            if (toolStripButton_RecClear.Enabled == false)
            {
                toolStripButton_RecClear.Enabled = true;
                toolStripButton_RecClear.BackColor = Color.Gold;
            }
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            SerialPortNumberUpadta(toolStripComboBox_SerialPort);
        }

        private void toolStripButton_Master_Click(object sender, EventArgs e)
        {
            if (toolStripButton_Master.Text == "开启")
            {
                gComMode = toolStripComboBox_SerialPort.Text;
                try
                {
                    if (gComMode == "TCP Client")
                    {
                        IPAddress addr = IPAddress.Parse(toolStripComboBox_BaudRate.Text);
                        IPEndPoint endPoint = new IPEndPoint(addr, int.Parse(toolStripTextBox_TCPPort.Text));
                        server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                        server.Connect(endPoint);
                        server.ReceiveTimeout = 500;
                        threadServer = new Thread(TCP_ClientRx);
                        threadServer.IsBackground = true;
                        threadServer.Start(server);
                    }
                    else
                    {
                        serialPort1.PortName = toolStripComboBox_SerialPort.Text;
                        serialPort1.BaudRate = Convert.ToInt32(toolStripComboBox_BaudRate.Text);
                        serialPort1.ReadTimeout = 500;
                        serialPort1.Open();
                    }
                    toolStripComboBox_SerialPort.Enabled = false;
                    toolStripComboBox_BaudRate.Enabled = false;
                    toolStripTextBox_TCPPort.Enabled = false;

                    toolStripButton_BootOn.Enabled = true;
                    toolStripButton_Master.BackColor = Color.Tomato;
                    toolStripButton_Master.Image = Properties.Resources.关闭;
                    toolStripButton_Master.Text = "关闭";
                    button_Tx.BackColor = Color.Lime;

                    Label_Status.Text = "OPEN";
                    Timer_RxAutoNewLine_Init();
                    timer1.Stop();
                }
                catch
                {
                    MessageBox.Show("端口打开失败，请检查！", "ERROR");
                }
            }
            else
            {
                try
                {
                    if (gComMode == "TCP Client")
                    {
                        threadServer.Abort();
                        server.Close();
                    }
                    else
                        serialPort1.Close();

                    if (threadBootloader != null)
                        threadBootloader.Abort();
                    if (threadBootloaderDownload != null)
                        threadBootloaderDownload.Abort();
                    if (threadBootloaderErase != null)
                        threadBootloaderErase.Abort();
                    gComMode = "";
                    toolStripComboBox_SerialPort.Enabled = true;
                    toolStripComboBox_BaudRate.Enabled = true;
                    toolStripTextBox_TCPPort.Enabled = true;

                    toolStripButton_BootOn.Enabled = false;
                    toolStripButton_Master.BackColor = Color.LimeGreen;
                    toolStripButton_Master.Image = Properties.Resources.开启;
                    toolStripButton_Master.Text = "开启";
                    button_Tx.BackColor = Color.DeepSkyBlue;

                    Label_Status.Text = "CLOSE";
                    timer_Send.Enabled = false;
                    gTimer_RxAutoNewline.Stop();
                    timer1.Start();
                }
                catch
                {
                    MessageBox.Show("端口关闭异常！", "ERROR");
                }
            }
        }

        private void button_Tx_Click(object sender, EventArgs e)
        {
            if (toolStripButton_Master.Text == "关闭")
            {
                SerialPortTx();
            }
            else
                toolStripButton_Master_Click(toolStripButton_Master, e);
        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            /* 选项卡0，普通的通信助手收发 */
            if (gBootloaderFlag == false)
            {
                string time = "";
                /* 自动换行开启了，需要先关闭自动换行的定时器 */
                if (toolStripButton_RxAutoNewline.Text == "ON" && gTimer_RxAutoNewline.Enabled)
                {
                    gTimer_RxAutoNewline.Stop();
                }
                /* 时间戳开启了，同时强制打开换行 */
                if (toolStripButton_Timestamp.Text == "ON")
                {
                    if (gTimestampFlag)
                    {
                        gTimestampFlag = false;
                        richTextBox_Rx.SelectionColor = Color.Gold;
                        time = DateTime.Now.ToString("HH:mm:ss.fff") + "<<";
                        richTextBox_Rx.AppendText(time);
                        richTextBox_Rx.SelectionColor = Color.White;
                    }
                }
                try
                {
                    int len = serialPort1.BytesToRead;
                    byte[] RxBuf = new byte[len];
                    ComRx(RxBuf, len);
                    string str = ByteToString(toolStripButton_RxHEX.Text, RxBuf, len);
                    richTextBox_Rx.AppendText(str);
                    LogWriteMsg(time + str);
                    if (toolStripButton_RxHEX.Text != "ASCII")
                    {
                        MsgLookup_16To10(RxBuf, len, time);
                    }
                    richTextBox_Rx.Focus();
                    //int cycle = len / 512;
                    //if (toolStripButton_RxHEX.Text == "ASCII")
                    //{
                    //    byte[] RxBuf = new byte[len];
                    //    ComRx(RxBuf, len);
                    //    string str = Encoding.Default.GetString(RxBuf);
                    //    richTextBox_Rx.AppendText(str);
                    //    richTextBox_Rx.Focus();
                    //    LogWriteMsg(time + str);
                    //}
                    //else
                    //{
                    //    byte[] RxBuf = new byte[512];
                    //    string s;
                    //    for (int cnt = 0; cnt < cycle; cnt++)
                    //    {
                    //        ComRx(RxBuf, 512);
                    //        s = BitConverter.ToString(RxBuf.Skip(0).Take(512).ToArray()).Replace("-", " ") + " ";
                    //        richTextBox_Rx.AppendText(s);
                    //    }
                    //    ComRx(RxBuf, len % 512);
                    //    s = BitConverter.ToString(RxBuf.Skip(0).Take(len % 512).ToArray()).Replace("-", " ") + " ";
                    //    richTextBox_Rx.AppendText(s);
                    //    MsgLookup_16To10(RxBuf, len % 512, time);
                    //    richTextBox_Rx.Focus();
                    //    LogWriteMsg(time + s);
                    //    richTextBox_Rx.Focus();
                    //    LogWriteMsg(time + s);
                    //}
                }
                catch
                {
                }
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
            }
        }

        private void checkBox_TimSend_CheckedChanged(object sender, EventArgs e)
        {
            /* 未开启自动循环发送，参数已配置好，且已连接通信端口 */
            if (checkBox_TimSend.Checked && NumUpDown_TimSend.Value > 0 && toolStripButton_Master.Text == "关闭")
            {
                if (NumUpDown_TimSend.Value < 10)
                    NumUpDown_TimSend.Value = 10;
                timer_Send.Interval = (int)NumUpDown_TimSend.Value;
                NumUpDown_TimSend.Enabled = false;
                timer_Send.Enabled = true;
            }
            else
            {
                checkBox_TimSend.Checked = false;
                timer_Send.Enabled = false;
                NumUpDown_TimSend.Enabled = true;
            }
        }

        private void timer_Send_Tick(object sender, EventArgs e)
        {
            if (gBootloaderFlag == false && toolStripButton_Master.Text == "关闭" && richTextBox_Tx.Text.Length > 0)
            {
                SerialPortTx();
            }
            else if (gBootloaderFlag)
            {
                timer_Send.Enabled = false;
                NumUpDown_TimSend.Enabled = true;
            }
        }

        private void toolStripButton_RecClear_Click(object sender, EventArgs e)
        {
            richTextBox_Rx.Text = "";
            toolStripButton_RecClear.BackColor = Color.Transparent;
            toolStripButton_RecClear.Enabled = false;
            gTxNum = 0;
            gRxNum = 0;
            Label_Status.Text = "OPEN    TX:" + gTxNum + "    RX:" + gRxNum;
        }





        private void toolStripButton_SaveSet_MouseDown(object sender, MouseEventArgs e)
        {
            gCfg.SysCfgFileWrite("基本配置", "端口", toolStripComboBox_SerialPort.Text);
            gCfg.SysCfgFileWrite("基本配置", "波特率/IP", toolStripComboBox_BaudRate.Text);
            gCfg.SysCfgFileWrite("基本配置", "TCP端口", toolStripTextBox_TCPPort.Text);
            gCfg.SysCfgFileWrite("基本配置", "Form1Size", this.Size.Width.ToString() + "," + this.Size.Height.ToString());
            gCfg.SysCfgFileWrite("基本配置", "MasterSize", splitContainer_Master.SplitterDistance.ToString());
            gCfg.SysCfgFileWrite("基本配置", "TableTxSize", splitContainer1.SplitterDistance.ToString());
            gCfg.SysCfgFileWrite("基本配置", "ButtonTxHEX", toolStripButton_TxHEX.Text + "," + toolStripButton_TxHEX.BackColor.Name);
            gCfg.SysCfgFileWrite("基本配置", "ButtonRxHEX", toolStripButton_RxHEX.Text + "," + toolStripButton_RxHEX.BackColor.Name);
            gCfg.SysCfgFileWrite("基本配置", "ButtonRxAutoNewline", toolStripButton_RxAutoNewline.Text + "," + toolStripButton_RxAutoNewline.BackColor.Name);
            gCfg.SysCfgFileWrite("基本配置", "ButtonTimestamp", toolStripButton_Timestamp.Text + "," + toolStripButton_Timestamp.BackColor.Name);
            gCfg.SysCfgFileWrite("基本配置", "TableTx显隐", splitContainer_Master.Panel2Collapsed.ToString());
            gCfg.SysCfgFileWrite("基本配置", "Tx回显", toolStripLabel1.ForeColor.Name);

            gCfg.SysCfgFileWrite("发送区", "MasterTx", richTextBox_Tx.Text);

            gCfg.SysCfgFileWrite("发送列表", "path", gCfg.TxListPath);
            if (toolStripTextBox_TxListNum.Text == "")
                toolStripTextBox_TxListNum.Text = "64";
            gCfg.TxListSave(toolStripTextBox_TxListNum.Text);
            MessageBox.Show("发送框保存成功");
        }

        private void 加载设定()
        {
            if (gCfg.SysCfgFileExists())
            {
                string[] val = new string[2];
                try
                {
                    toolStripComboBox_SerialPort.Text = gCfg.SysCfgFileRead("基本配置", "端口");
                    toolStripComboBox_BaudRate.Text = gCfg.SysCfgFileRead("基本配置", "波特率/IP");
                    toolStripTextBox_TCPPort.Text = gCfg.SysCfgFileRead("基本配置", "TCP端口");
                    string[] size = gCfg.SysCfgFileRead("基本配置", "Form1Size").Split(',');
                    this.Size = new Size(Convert.ToInt32(size[0]), Convert.ToInt32(size[1]));
                    splitContainer_Master.SplitterDistance = Convert.ToInt32(gCfg.SysCfgFileRead("基本配置", "MasterSize"));
                    splitContainer1.SplitterDistance = Convert.ToInt32(gCfg.SysCfgFileRead("基本配置", "TableTxSize"));
                    splitContainer_Master.Panel2Collapsed = Convert.ToBoolean(gCfg.SysCfgFileRead("基本配置", "TableTx显隐"));

                    val = gCfg.SysCfgFileRead("基本配置", "ButtonTxHEX").Split(',');
                    toolStripButton_TxHEX.Text = val[0];
                    toolStripButton_TxHEX.BackColor = Color.FromName(val[1]);
                    val = gCfg.SysCfgFileRead("基本配置", "ButtonRxHEX").Split(',');
                    toolStripButton_RxHEX.Text = val[0];
                    toolStripButton_RxHEX.BackColor = Color.FromName(val[1]);
                    val = gCfg.SysCfgFileRead("基本配置", "ButtonRxAutoNewline").Split(',');
                    toolStripButton_RxAutoNewline.Text = val[0];
                    toolStripButton_RxAutoNewline.BackColor = Color.FromName(val[1]);
                    val = gCfg.SysCfgFileRead("基本配置", "ButtonTimestamp").Split(',');
                    toolStripButton_Timestamp.Text = val[0];
                    toolStripButton_Timestamp.BackColor = Color.FromName(val[1]);

                    toolStripLabel1.ForeColor = Color.FromName(gCfg.SysCfgFileRead("基本配置", "Tx回显"));
                    if (toolStripLabel1.ForeColor == Color.Red)
                        gTxShowFlag = true;

                    richTextBox_Tx.Text = gCfg.SysCfgFileRead("发送区", "MasterTx");

                    string path = gCfg.SysCfgFileRead("发送列表", "path");
                    gCfg.TxListPath = path;
                    gCfg.TxListNum = gCfg.TxList_GetNum(path);
                    toolStripTextBox_TxListNum.Text = gCfg.TxListNum.ToString();
                }
                catch { }
            }
        }

        private void richTextBox_Rx_ContentsResized(object sender, ContentsResizedEventArgs e)
        {
            richTextBox_Rx.ScrollToCaret();
        }

        private void toolStripComboBox_LoaderFile_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (toolStripComboBox_LoaderFile.Enabled)
            {
                toolStripComboBox_LoaderFile.Enabled = false;
                threadBootloaderFile = new Thread(FirmwareFileRead);
                threadBootloaderFile.IsBackground = true;
                threadBootloaderFile.Start();
            }
        }

        private void BootloaderStatusShow(string text)
        {
            richTextBox_HexShow.AppendText(text + System.Environment.NewLine);
            richTextBox_HexShow.ScrollToCaret();
        }

        private void toolStripButton_TxHEX_MouseDown(object sender, MouseEventArgs e)
        {
            if (toolStripButton_TxHEX.Text == "ASCII")
            {
                toolStripButton_TxHEX.Text = "HEX";
                toolStripButton_TxHEX.BackColor = Color.LimeGreen;
            }
            else
            {
                toolStripButton_TxHEX.Text = "ASCII";
                toolStripButton_TxHEX.BackColor = Color.Transparent;
            }
        }

        private void toolStripButton_RxHEX_MouseDown(object sender, MouseEventArgs e)
        {
            if (toolStripButton_RxHEX.Text == "ASCII")
            {
                toolStripButton_RxHEX.Text = "HEX";
                toolStripButton_RxHEX.BackColor = Color.LimeGreen;
            }
            else
            {
                toolStripButton_RxHEX.Text = "ASCII";
                toolStripButton_RxHEX.BackColor = Color.Transparent;
            }
        }

        private void toolStripButton_RxAutoNewline_MouseDown(object sender, MouseEventArgs e)
        {
            if (toolStripButton_RxAutoNewline.Text == "OFF")
            {
                toolStripButton_RxAutoNewline.Text = "ON";
                toolStripButton_RxAutoNewline.BackColor = Color.LimeGreen;
            }
            else
            {
                toolStripButton_RxAutoNewline.Text = "OFF";
                toolStripButton_RxAutoNewline.BackColor = Color.Transparent;
            }
        }

        private void toolStripButton_Timestamp_MouseDown(object sender, MouseEventArgs e)
        {
            if (toolStripButton_Timestamp.Text == "OFF")
            {
                toolStripButton_Timestamp.Text = "ON";
                toolStripButton_Timestamp.BackColor = Color.LimeGreen;
                /* 同时开启自动换行 */
                toolStripButton_RxAutoNewline.Text = "ON";
                toolStripButton_RxAutoNewline.BackColor = Color.LimeGreen;
                toolStripButton_RxAutoNewline.Enabled = false;
            }
            else
            {
                toolStripButton_Timestamp.Text = "OFF";
                toolStripButton_Timestamp.BackColor = Color.Transparent;
                /* 同时关闭自动换行 */
                toolStripButton_RxAutoNewline.Text = "OFF";
                toolStripButton_RxAutoNewline.BackColor = Color.Transparent;
                toolStripButton_RxAutoNewline.Enabled = true;
            }
        }

        private void toolStripButton_Fold_MouseDown(object sender, MouseEventArgs e)
        {
            if (splitContainer_Master.Panel2Collapsed == true)
                splitContainer_Master.Panel2Collapsed = false;
            else
                splitContainer_Master.Panel2Collapsed = true;
        }

        private void toolStripButton_OnTop_MouseDown(object sender, MouseEventArgs e)
        {
            if (toolStripButton_OnTop.Text == "置顶")
            {
                toolStripButton_OnTop.BackColor = Color.Tomato;
                toolStripButton_OnTop.Text = "取消置顶";
                this.TopMost = true;
            }
            else
            {
                toolStripButton_OnTop.BackColor = Color.Transparent;
                toolStripButton_OnTop.Text = "置顶";
                this.TopMost = false;
            }
        }

        private void HelpShow(Color c, string text)
        {
            richTextBox_Rx.AppendText(System.Environment.NewLine);
            richTextBox_Rx.SelectionColor = c;
            richTextBox_Rx.AppendText(text);
            richTextBox_HexShow.AppendText(System.Environment.NewLine);
            richTextBox_HexShow.SelectionColor = c;
            richTextBox_HexShow.AppendText(text);
        }
        private void HelpShowNewLine()
        {
            richTextBox_Rx.AppendText(System.Environment.NewLine);
            richTextBox_HexShow.AppendText(System.Environment.NewLine);
        }
        private void toolStripButton_help_MouseDown(object sender, MouseEventArgs e)
        {
            richTextBox_Rx.Text = "";
            richTextBox_HexShow.Text = "";
            HelpShow(Color.Gold, "串口助手V1.0(完全开源)：");
            HelpShow(Color.Lime, "打包下载链接 https://pan.baidu.com/s/1uoS-Xpm8JSPdkq5KYSMFFA 提取码:g1di");
            HelpShowNewLine();
            HelpShowNewLine();

            HelpShow(Color.Gold, "多级发送列表：");
            HelpShowNewLine();
            HelpShow(Color.Gold, "1.结构");
            HelpShow(Color.Moccasin, "监控区 + HEX复选框 + 延时发送设置框 + 发送数据框 + 发送键");
            HelpShowNewLine();
            HelpShow(Color.Gold, "2.用法");
            HelpShow(Color.Moccasin, "双击“发送数据框”，可将文本添加到“发送键”");
            HelpShow(Color.Moccasin, "监控区的“自动”键，用于开启/关闭循环发送，未设置延时发送的，自动跳过");
            HelpShowNewLine();
            HelpShowNewLine();

            HelpShow(Color.Gold, "bootloader：");
            HelpShowNewLine();
            HelpShow(Color.Gold, "1.bootloader报文结构");
            HelpShow(Color.Moccasin, "采用checksum，报文所有字节相加，取反做报尾cs");
            HelpShow(Color.Orange, "[cmd] ..... [cs]");
            HelpShowNewLine();
            HelpShow(Color.Gold, "2.协议定义");
            HelpShow(Color.Gold, "2.1 进入bootloader");
            HelpShow(Color.Orange, "-> 5B AB [mcu] [BRG] [cs]");
            HelpShow(Color.Orange, "<- 无应答");
            HelpShow(Color.Moccasin, "[mcu]指示下位机中哪个mcu进入(可不使用)。");
            HelpShow(Color.Moccasin, "[BRG]配置主控MCU与[mcu]的通信速率(可不使用)。");
            HelpShowNewLine();

            HelpShow(Color.Gold, "2.2 波特率自动检测帧");
            HelpShow(Color.Orange, "-> 55");
            HelpShow(Color.Moccasin, "PC发送“进入bootloader”指令后，自动下发");
            HelpShowNewLine();

            HelpShow(Color.Gold, "2.3 跳转APP");
            HelpShow(Color.Orange, "-> 5A 5A A5 A6");
            HelpShow(Color.Orange, "<- 无应答");
            HelpShowNewLine();

            HelpShow(Color.Gold, "2.4 建立连接");
            HelpShow(Color.Orange, "-> AA [cs]");
            HelpShow(Color.Orange, "<- AA 00 00 00 00 [sizeH] [sizeL] [packH] [packL] [mcu] [bit] [cs]");
            HelpShow(Color.Moccasin, "[size]MCU剩余的APP区域大小(KB)。");
            HelpShow(Color.Moccasin, "[pack]MCU的Flash页大小(字节)。");
            HelpShow(Color.Moccasin, "[mcu]MCU编号。");
            HelpShow(Color.Moccasin, "[bit]MCU位数，0：8bit，1：16bit，2：32bit.");
            HelpShowNewLine();

            HelpShow(Color.Gold, "2.5 烧录Flash");
            HelpShow(Color.Orange, "-> A1 [addrHH] [addrHL] [addrLH] [addrLL] [lenH] [lenL] [D0] ... [Dx] [cs]");
            HelpShow(Color.Orange, "<- A1 [status] [cs]");
            HelpShow(Color.Moccasin, "[addr]4字节的烧录地址。");
            HelpShow(Color.Moccasin, "[len]烧录数据的长度，固定为[pack]字节。");
            HelpShow(Color.Moccasin, "[D]烧录数据。");
            HelpShow(Color.Moccasin, "[status]状态，00：成功，非零：异常");
            HelpShowNewLine();

            HelpShow(Color.Gold, "2.6 校验");
            HelpShow(Color.Orange, "-> A2 [addrHH] [addrHL] [addrLH] [addrLL] [lenH] [lenL] [cs]");
            HelpShow(Color.Orange, "<- A2 [status] [D0] ... [Dx] [cs]");
            HelpShow(Color.Moccasin, "[addr]4字节的烧录地址。");
            HelpShow(Color.Moccasin, "[len]烧录数据的长度，固定为[pack]字节。");
            HelpShow(Color.Moccasin, "[status]状态，00：正常，非零：地址、cs校验异常");
            HelpShow(Color.Moccasin, "[D]从Flash读出的数据，个数为[pack]字节。");
            HelpShowNewLine();

            HelpShow(Color.Gold, "2.7 全擦");
            HelpShow(Color.Orange, "-> A3 00 00 00 00 [cs]");
            HelpShow(Color.Orange, "<- A3 [status] [cs]");
            HelpShow(Color.Moccasin, "[status]状态，00：正常，非零：擦除失败");
            HelpShowNewLine();
            toolStripButton_RecClear.Enabled = true;
            toolStripButton_RecClear.BackColor = Color.Gold;
        }


        private void toolStripTextBox_Hradix_TextChanged(object sender, EventArgs e)
        {
            int pos = toolStripTextBox_Hradix.SelectionStart;
            try
            {
                if (toolStripTextBox_Hradix.Text != "")
                {
                    toolStripTextBox_Dradix.Text = Convert.ToUInt64(toolStripTextBox_Hradix.Text, 16).ToString();
                    toolStripTextBox_Dradix.SelectionStart = toolStripTextBox_Dradix.Text.Length;
                    toolStripTextBox_Hradix.Focus();
                }
            }
            catch
            {
                if (toolStripTextBox_Dradix.Text == "")
                {
                    toolStripTextBox_Hradix.Text = "";
                    return;
                }
                pos--;
                toolStripTextBox_Hradix.Text = Convert.ToUInt64(toolStripTextBox_Dradix.Text).ToString("X");
            }
            toolStripTextBox_Hradix.SelectionStart = pos;
        }

        private void toolStripTextBox_Dradix_TextChanged(object sender, EventArgs e)
        {
            int pos = toolStripTextBox_Dradix.SelectionStart;
            try
            {
                if (toolStripTextBox_Dradix.Text != "")
                {
                    toolStripTextBox_Hradix.Text = Convert.ToUInt64(toolStripTextBox_Dradix.Text).ToString("X");
                    toolStripTextBox_Hradix.SelectionStart = toolStripTextBox_Hradix.Text.Length;
                    toolStripTextBox_Dradix.Focus();
                }
            }
            catch
            {
                if (toolStripTextBox_Hradix.Text == "")
                {
                    toolStripTextBox_Dradix.Text = "";
                    return;
                }
                pos--;
                toolStripTextBox_Dradix.Text = Convert.ToUInt64(toolStripTextBox_Hradix.Text, 16).ToString();
            }
            toolStripTextBox_Dradix.SelectionStart = pos;
        }

        public void buttonClick(CheckBox cb, TextBox tb)
        {
            if (gComMode != "")
            {
                string temp = "ASCII";
                string pattern = @"[^0-9]+";
                Regex rgx = new Regex(pattern);
                /* HEX发送 */
                if (cb.Checked)
                {
                    temp = "HEX";
                }
                if(tb.Lines.Length == 1)
                    ComTx(tb.Lines[0], temp);
                else
                {
                    for (int line = 0; line < tb.Lines.Length; line++)
                    {
                        int loop = 1;
                        string delay = "100";
                        //当前行是延时处理，紧跟指令行的延时，在发送指令后已处理
                        if (tb.Lines[line].IndexOf("DelaY", StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            //上一行也是延时处理，则当前行的延时要处理了
                            if (line > 0 && tb.Lines[line - 1].IndexOf("DelaY", StringComparison.OrdinalIgnoreCase) >= 0)
                            {
                                Thread.Sleep(Convert.ToInt32(rgx.Replace(tb.Lines[line], "")));
                            }
                            continue;
                        }
                        if (tb.Lines[line] == "")
                            continue;
                        if (line + 1 < tb.Lines.Length)
                        {
                            if (tb.Lines[line + 1].IndexOf("DelaY", StringComparison.OrdinalIgnoreCase) >= 0)
                            {
                                delay = tb.Lines[line + 1];
                                if (delay.Length > 5)
                                {
                                    delay = delay.Substring(5, delay.Length - 5).ToUpper();
                                    if (delay.IndexOf("LooP", StringComparison.OrdinalIgnoreCase) >= 0)
                                    {
                                        int pos = 1;
                                        string[] delay_loop = delay.Split(new string[] { "LOOP" }, StringSplitOptions.RemoveEmptyEntries);
                                        delay = delay_loop[0];
                                        if (delay_loop.Length == 1)
                                        {
                                            delay = "100";
                                            pos = 0;
                                        }
                                        if (delay_loop[pos].Length > 0)
                                        {
                                            loop = Convert.ToInt32(rgx.Replace(delay_loop[pos], ""));
                                        }
                                        if (loop < 1)
                                            loop = 1;
                                    }
                                }
                                delay = rgx.Replace(delay, "");
                                if (delay == "")
                                    delay = "100";
                            }
                        }

                        while (loop-- > 0)
                        {
                            ComTx(tb.Lines[line], temp);
                            //发送完指令后，取下一行的延时时间，进行延时
                            Thread.Sleep(Convert.ToInt32(delay));
                        }
                    }
                }
                if (toolStripButton_RecClear.Enabled == false)
                {
                    toolStripButton_RecClear.Enabled = true;
                    toolStripButton_RecClear.BackColor = Color.Gold;
                }
            }
        }
        private void TextboxTX_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TextBox yltb = sender as TextBox;
                if (yltb.Lines.Length > 10)
                    return;
                int i = 0;
                for (; i < gCfg.TxListNum; i++)
                {
                    if (yltb == gCfg.TextboxTX[i])
                        break;
                }
                if (i >= gCfg.TxListNum)
                    i = gCfg.TxListNum - 1;
                yltb.LostFocus -= new EventHandler(TextboxTX_LostFocusClick);
                //yltb.GotFocus -= new EventHandler(TextboxTX_GotFocusClick);
                if (yltb.Lines.Length == 10)
                    yltb.ScrollBars = ScrollBars.Vertical;
                tableLayoutPanel1.RowStyles[i].Height = 15 * (yltb.Lines.Length);
                tableLayoutPanel1.Size = new Size(tableLayoutPanel1.Size.Width, (20 * gCfg.TxListNum) + 20 * (yltb.Lines.Length) + 2);
                yltb.LostFocus += new EventHandler(TextboxTX_LostFocusClick);
            }
        }
        private void TextboxTX_GotFocusClick(object sender, EventArgs e)
        {
            int i = 0;
            TextBox yltb = sender as TextBox;
            if (yltb.Lines.Length <= 1)
                return;
            for (; i < gCfg.TxListNum; i++)
            {
                if (yltb == gCfg.TextboxTX[i])
                    break;
            }
            if (i >= gCfg.TxListNum)
                i = gCfg.TxListNum - 1;
            //yltb.LostFocus -= new EventHandler(TextboxTX_LostFocusClick);
            yltb.GotFocus -= new EventHandler(TextboxTX_GotFocusClick);
            
            int length = yltb.Lines.Length;
            if (length >= 10)
            {
                yltb.ScrollBars = ScrollBars.Vertical;
                length = 10;
            }
            tableLayoutPanel1.RowStyles[i].Height = 15 * length;
            tableLayoutPanel1.Size = new Size(tableLayoutPanel1.Size.Width, (20 * gCfg.TxListNum) + 15 * length);
            yltb.LostFocus += new EventHandler(TextboxTX_LostFocusClick);
        }
        private void TextboxTX_LostFocusClick(object sender, EventArgs e)
        {
            int i = 0;
            TextBox yltb = sender as TextBox;
            for (; i < gCfg.TxListNum; i++)
            {
                if (yltb == gCfg.TextboxTX[i])
                    break;
            }
            if (i >= gCfg.TxListNum)
                i = gCfg.TxListNum - 1;
            if (tableLayoutPanel1.RowStyles[i].Height == 20)
                return;
            yltb.LostFocus -= new EventHandler(TextboxTX_LostFocusClick);
            yltb.ScrollBars = ScrollBars.None;
            tableLayoutPanel1.RowStyles[i].Height = 20;
            tableLayoutPanel1.Size = new Size(tableLayoutPanel1.Size.Width, (20 * gCfg.TxListNum) + 2);
            yltb.GotFocus += new EventHandler(TextboxTX_GotFocusClick);
        }
        private void TableTxSingle_Click(object pos)
        {
            int i = (int)pos;
            buttonClick(gCfg.Checkbox[i], gCfg.TextboxTX[i]);
            threadTableTx_RunFlag = false;
            threadTableTx.Abort();
        }
        private void button_Click(object sender, EventArgs e)
        {
            if (threadTableTx_RunFlag)
                return;
            int i = 0;
            Button ylbtt = sender as Button;
            for (; i < gCfg.TxListNum; i++)
            {
                if (ylbtt == gCfg.Button[i])
                    break;
            }
            threadTableTx = new Thread(TableTxSingle_Click);
            threadTableTx.IsBackground = true;
            threadTableTx_RunFlag = true;
            threadTableTx.Start(i);
        }

        bool threadTableTx_RunFlag = false;
        Thread threadTableTx = null;
        private void TableTx_Click()
        {
            toolStripLabel_TableTx.Text = "空闲，未设置延时发送";
            while (true)
            {
                for (int i = 0; i < gCfg.TxListNum; i++)
                {
                    if (gBootloaderFlag)
                        goto THREAD_TABLE_TX_ABORT;
                    string time = gCfg.TextboxTimer[i].Text;
                    if (time != "")
                    {
                        int delay = 0;
                        try
                        {
                            delay = Convert.ToInt32(time);
                        }
                        catch
                        {
                            gCfg.TextboxTimer[i].Text = "";
                            continue;
                        }
                        try
                        {
                            toolStripLabel_TableTx.Text = "延时" + delay + "ms, TX: " + gCfg.Button[i].Text;
                            Thread.Sleep(delay);
                            buttonClick(gCfg.Checkbox[i], gCfg.TextboxTX[i]);
                        }
                        catch
                        {
                            goto THREAD_TABLE_TX_ABORT;
                        }
                    }
                }
            }
        THREAD_TABLE_TX_ABORT:
            toolStripButton_TableTx.Text = "自动";
            toolStripButton_TableTx.BackColor = Color.Lime;
            //button_Tx.Enabled = true;
            checkBox_TimSend.Enabled = true;
            threadTableTx.Abort();
        }
        private void toolStripButton_TableTx_Click(object sender, EventArgs e)
        {
            /* 未开启自动循环发送，且已连接通信端口 */
            if (toolStripButton_TableTx.Text == "自动" && toolStripButton_Master.Text == "关闭" && gBootloaderFlag == false)
            {
                if (threadTableTx_RunFlag)
                    return;
                timer_Send.Stop();
                checkBox_TimSend.Checked = false;
                checkBox_TimSend.Enabled = false;
                //button_Tx.Enabled = false;
                toolStripButton_TableTx.Text = "关闭";
                toolStripButton_TableTx.BackColor = Color.Tomato;
                threadTableTx = new Thread(TableTx_Click);
                threadTableTx.IsBackground = true;
                threadTableTx_RunFlag = true;
                threadTableTx.Start();
            }
            else if (toolStripButton_TableTx.Text == "关闭")
            {
                toolStripLabel_TableTx.Text = "空闲";
                toolStripButton_TableTx.Text = "自动";
                toolStripButton_TableTx.BackColor = Color.Lime;
                //button_Tx.Enabled = true;
                checkBox_TimSend.Enabled = true;
                threadTableTx_RunFlag = false;
                threadTableTx.Abort();
            }
        }

        private void trackBar1_MouseMove(object sender, MouseEventArgs e)
        {
            trackBar1.Size = new Size(100, 23);
        }

        private void trackBar1_MouseLeave(object sender, EventArgs e)
        {
            trackBar1.Size = new Size(20, 23);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            this.Opacity = (100 - trackBar1.Value) / 100.0;
        }

        bool gTxShowFlag = false;
        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            gTxShowFlag = !gTxShowFlag;
            if (gTxShowFlag)
            {
                object obj = null;
                MouseEventArgs me = null;
                toolStripButton_Timestamp.Text = "OFF";
                toolStripButton_Timestamp_MouseDown(obj, me);
                toolStripLabel1.ForeColor = Color.Red;
            }
            else
                toolStripLabel1.ForeColor = Color.Black;
        }

        private void toolStrip_TableTX_DoubleClick(object sender, EventArgs e)
        {
            if (toolStrip_TableTX.Text == "发送列表的按键可编辑")
            {
                gCfg.TextboxTXClickBypassCfg(true);
                toolStrip_TableTX.Text = "发送列表的按键已上锁";
            }
            else
            {
                gCfg.TextboxTXClickBypassCfg(false);
                toolStrip_TableTX.Text = "发送列表的按键可编辑";
            }

            richTextBox_Rx.SelectionColor = Color.Gold;
            richTextBox_Rx.AppendText(toolStrip_TableTX.Text + "!!!");
            richTextBox_Rx.SelectionColor = Color.White;
            richTextBox_Rx.AppendText(System.Environment.NewLine);
        }
        string gLogFileName = null;
        private void toolStripButton_log_Click(object sender, EventArgs e)
        {
            if (toolStripButton_log.ToolTipText == "记录log")
            {
                SaveFileDialog log = new SaveFileDialog();
                //log.InitialDirectory = "D:\\"; //默认路径
                log.Filter = "log|*.log|文本|*.txt";
                log.FileName = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-s");
                if (log.ShowDialog() == DialogResult.OK)
                {
                    toolStripButton_log.ToolTipText = "关闭log";
                    toolStripButton_log.BackColor = Color.LimeGreen;
                    gLogFileName = log.FileName;
                    StreamWriter stream = new StreamWriter(gLogFileName);
                    stream.WriteLine("串口助手LOG");
                    stream.WriteLine(DateTime.Now.ToString("yyyy-MM-dd-HH-mm-s"));
                    stream.WriteLine("******************************");
                    stream.Flush();
                    stream.Close();
                }
            }
            else
            {
                toolStripButton_log.ToolTipText = "记录log";
                toolStripButton_log.BackColor = Color.Transparent;
                gLogFileName = null;
            }
        }

        public void LogWriteMsg(string msg)
        {
            if (gLogFileName == null)
                return;
            StreamWriter stream = new StreamWriter(gLogFileName, true);
            stream.WriteLine(msg);
            stream.Flush();
            stream.Close();
        }

        private void 加载发送列表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gCfg.TxListLoad(tableLayoutPanel1, tableLayoutPanel2) == 0)
                return;
            TxListEventReg();
            splitContainer1.Size = new Size(246, (20 * gCfg.TxListNum) + 200);
            toolStripTextBox_TxListNum.Text = gCfg.TxListNum.ToString();
            //gCfg.TxListFirstLoad();
        }

        private void 另存为ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gCfg.TxListOtherSave(toolStripTextBox_TxListNum.Text);
        }

        private void 新建ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(gCfg.TxListNewCreate(tableLayoutPanel1, tableLayoutPanel2, toolStripTextBox_TxListNum.Text))
            {
                TxListEventReg();
                splitContainer1.Size = new Size(246, (20 * gCfg.TxListNum) + 200);
            }
        }
    }
}
