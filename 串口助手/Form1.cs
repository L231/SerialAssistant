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
using System.Management;
using System.Runtime.InteropServices;

namespace 串口助手
{
    public partial class Form1 : Form
    {
        int gTxNum = 0;
        int gRxNum = 0;
        bool gTimestampFlag = true;

        const int TimerRxAutoNewlinePeriod = 5;
        System.Timers.Timer gTimer_RxAutoNewline = new System.Timers.Timer(TimerRxAutoNewlinePeriod);

        bool gTxShowFlag = false;

        bool threadTableTx_RunFlag = false;
        Thread threadTableTx = null;

        Config gCfg = new Config();
        ContextMenu contextMenu = new ContextMenu();
        CommLog commLog = new CommLog();
        public SuperMsg SuperMsgCurrent = null;
        List<object> SuperMsgList = new List<object>();
        RealTimeCurve realTimeCurve = new RealTimeCurve();
        AutoTx AutoTx = new AutoTx();

        private void Timer_RxAutoNewline_OutHandle(object sender, EventArgs e)
        {
            ////最新行已显示了数据，则进行换行
            //if (richTextBox_Rx.Text[richTextBox_Rx.Text.Length - 1] != '\n')
            //if (!gTimestampFlag)
            //    WriteRxMsg(Color.White, System.Environment.NewLine);
            gTimestampFlag = true;
            gTimer_RxAutoNewline.Stop();
        }
        private void Timer_RxAutoNewLine_Init(int delay)
        {
            gTimer_RxAutoNewline.Interval = delay;
            gTimer_RxAutoNewline.Elapsed += new System.Timers.ElapsedEventHandler(Timer_RxAutoNewline_OutHandle);
            gTimer_RxAutoNewline.AutoReset = true;
        }

        /// <summary>
        /// tcp客户端的接收处理
        /// </summary>
        /// <param name="sender"></param>
        private void TCP_ClientRx(object sender)
        {
            Socket sockConnection = sender as Socket;
            byte[] buffMsgRec = new byte[1024 * 1024];
            int len = 0;
            sockConnection.ReceiveTimeout = 500;
            while (true)
            {
                if (gBootloaderFlag == true)
                {
                    Thread.Sleep(100);
                    continue;
                }
                try
                {
                    len = sockConnection.Receive(buffMsgRec);
                    if (数据接收_显示_解析_输出日志(sender,
                        "tcp",
                        ref buffMsgRec,
                        len) == false)
                        continue;
                }
                catch { }
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
            catch { }
            masterComm.type = "";
            toolStripButton_Master.Text = "开启";
            toolStripTextBox自动换行定时器周期.LostFocus += new EventHandler(toolStripTextBox自动换行定时器周期_LostFocusClick);

            realTimeCurve.TopLevel = false;
            realTimeCurve.Dock = DockStyle.Fill;
            tabPage5.Controls.Add(realTimeCurve);
            realTimeCurve.Show();

            加载设定();
            gCfg.TableTxCreate(tableLayoutPanel1, tableLayoutPanel2);
            splitContainer1.Size = new Size(246, (20 * gCfg.TxListNum) + 200);
            gCfg.TxListFirstLoad();
            TxListEventReg();
            加载缓存的设备();
            toolStripButton_log.Click += new System.EventHandler(commLog.Button_log_Click);
            contextMenu.ContextMenuTxListInit();
            contextMenu.ContextMenu_CreateSuperMsgClickCfg(CreateSuperMsg_Handler);
            contextMenu.TxListSimpleMenu.Opening += new CancelEventHandler(TxListSimpleMenu_Opening);
            richTextBox_Rx.ContextMenuStrip = contextMenu.RxShowMenu;
            flowLayoutPanel_SuperMsg.ContextMenuStrip = contextMenu.CreateSuperMsgMenu;

            textBoxTxListName.LostFocus += new EventHandler(textBoxTxListName_LostFocusClick);
            textBoxTxListMsg.LostFocus += new EventHandler(textBoxTxListMsg_LostFocusClick);
        }

        private void TxListEventReg()
        {
            for (int i = 0; i < gCfg.TxListNum; i++)
            {
                gCfg.TextboxTX[i].KeyUp += new KeyEventHandler(TextboxTX_KeyUp);
                gCfg.TextboxTX[i].GotFocus += new EventHandler(TextboxTX_GotFocusClick);
                //gCfg.TextboxTX[i].LostFocus += new EventHandler(TextboxTX_LostFocusClick);
                gCfg.Button[i].Click += new EventHandler(button_Click);
                gCfg.Button[i].ContextMenuStrip = contextMenu.TxListMenu;

                gCfg.Checkbox[i].MouseHover += new EventHandler(TxListHelp_MouseHover);
                gCfg.TextboxTimer[i].MouseHover += new EventHandler(TxListHelp_MouseHover);
            }
        }

        /// <summary>
        /// 获取所有的串口设备号
        /// </summary>
        /// <param name="combo"></param>
        private static void SerialPortNumberUpadta(ToolStripComboBox combo)
        {
            /* 清除当前组合框的下拉菜单内容 */
            combo.Items.Clear();
            //combo.Items.AddRange(System.IO.Ports.SerialPort.GetPortNames());
            //combo.Items.Add("TCP Client");
            //combo.Items.Add("TCP Server");
            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher
                ("select * from Win32_PnPEntity where Name like '%(COM%'"))
            {
                var hardInfos = searcher.Get();
                foreach(var hardInfo in hardInfos)
                {
                    if(hardInfo.Properties["Name"].Value != null)
                    {
                        string deviceName = hardInfo.Properties["Name"].Value.ToString();
                        combo.Items.Add(deviceName);
                    }
                }
            }
            combo.Items.Add("TCP Client");
        }

        private void TxMsg(byte[] data)
        {
            //接收区显示发送内容
            string show = "";
            DataTypeConversion Conversion = new DataTypeConversion();
            Conversion.ByteAddMsgTail(MasterMsgEnd.Text, ref data);
            if (gTxShowFlag && gBootloaderFlag == false)
            {
                show += DateTime.Now.ToString("HH:mm:ss.fff") + ">>";
                show += Conversion.ByteToString(toolStripButton_TxHEX.Text, data, data.Length);
                commLog.LogWriteMsg(show);
                SendMsgEcho(System.Environment.NewLine + show);
            }

            if (masterComm.type == "TCP Client")
                masterComm.tcp.Send(data, 0, data.Length, SocketFlags.None);
            else
            {
                masterComm.uart.Write(data, 0, data.Length);
            }

            gTxNum += data.Length;
            Label_Status.Text = "OPEN    TX:" + gTxNum + "    RX:" + gRxNum;
        }
        /// <summary>
        /// 直接发送报文，无解析动作
        /// </summary>
        /// <param name="data"></param>
        /// <param name="data_type"></param>
        private bool CommSendData(MultiCommunication_t dev, string data, string data_type)
        {
            if (data == "")
                return true;
            try
            {
                int length = 0;
                DataTypeConversion dataType = new DataTypeConversion();
                byte[] TxBuf = dataType.StringToByte(data_type, data);
                if (TxBuf == null)
                    return false;

                /* 处理报尾 */
                length = dataType.ByteAddMsgTail(dev.MsgTailType, ref TxBuf);
                //接收区显示发送内容
                string show = "";
                if (gTxShowFlag && gBootloaderFlag == false)
                {
                    if (dev.name != "S0")
                        show = "[" + dev.name + "]";
                    show += DateTime.Now.ToString("HH:mm:ss.fff") + ">>";
                    show += dataType.ByteToString(data_type, TxBuf, length);
                    commLog.LogWriteMsg(show);
                    SendMsgEcho(System.Environment.NewLine + show);
                }
                if(SuperMsgCurrent != null)
                {
                    textBox_SuperMsgRxShow.AppendText(System.Environment.NewLine + show);
                }
                //发送数据
                if (dev.type == "TCP Client")
                {
                    for(int i = 0; i < length; i += 4096)
                    {
                        if(i + 4096 > length)
                            dev.tcp.Send(TxBuf, i, length - i, SocketFlags.None);
                        else
                            dev.tcp.Send(TxBuf, i, 4096, SocketFlags.None);
                    }
                }
                else
                    dev.uart.Write(TxBuf, 0, length);
                gTxNum += length;
                Label_Status.Text = "OPEN    TX:" + gTxNum + "    RX:" + gRxNum;
                return true;
            }
            catch { }
            return false;
        }
        public void SuperMsgSendData(string data, string msgFunc)
        {
            if (toolStripButton_Master.Text == "开启")
                return;
            masterComm.MsgTailType = MasterMsgEnd.Text;
            CommSendData(masterComm, data, "HEX");
            textBox_SuperMsgRxShow.AppendText("     " + msgFunc);
        }
        private void CommSingleMsgSend(string data, string data_type)
        {
            if (data == "")
                return;
            try
            {
                string txBuf = "";
                //拆分当前报文，可能有多个设备的报文
                string[] msgAll = data.Split(new string[] { "$$" }, StringSplitOptions.RemoveEmptyEntries);
                for (int pos = 0; pos < msgAll.Length; pos++)
                {
                    string[] devData = msgAll[pos].Split('$');
                    if (devData.Length == 1)
                        txBuf = devData[0];
                    else
                        txBuf = devData[1];
                    //找出当前的发送端口，当前是主设备
                    if (devData.Length == 1 ||
                        (devData.Length == 2 && devData[0].ToUpper() == "S0"))
                    {
                        masterComm.MsgTailType = MasterMsgEnd.Text;
                        CommSendData(masterComm, txBuf, data_type);
                    }
                    else
                    {
                        devData[0] = devData[0].ToUpper();
                        foreach (MultiCommunication_t p in listMultiComm)
                        {
                            if (p.name == devData[0])
                            {
                                CommSendData(p, txBuf, p.hex);
                                break;
                            }
                        }
                    }
                }
            }
            catch { }
        }

        

        private int 串口接收数据(object sender, ref byte[] data)
        {
            try
            {
                System.IO.Ports.SerialPort uart = (System.IO.Ports.SerialPort)sender;
                int length = 0;
                while (length != uart.BytesToRead)
                {
                    length = uart.BytesToRead;
                    Delay(3);
                    if (length >= 1024)  //强制分包
                        break;
                }
                //预留一个字节，为后面解决中文乱码做准备
                data = new byte[length + 1];
                uart.Read(data, 0, length);
                return length;
            }
            catch
            { }
            return 0;
        }
        private void CommMasterButtonSend()
        {
            try
            {
                if (TextBox_Tx.Text == "")
                    return;
                masterComm.MsgTailType = MasterMsgEnd.Text;
                CommSendData(masterComm, TextBox_Tx.Text, toolStripButton_TxHEX.Text);
            }
            catch { }
            if (toolStripButton_RecClear.Enabled == false)
            {
                toolStripButton_RecClear.Enabled = true;
                toolStripButton_RecClear.BackColor = Color.Gold;
            }
        }

      
        private void toolStripButton_Master_Click(object sender, EventArgs e)
        {
            if (设备注册("S0",
                        toolStripButton_Master.Text,
                        toolStripComboBox_SerialPort.Text,
                        toolStripComboBox_BaudRate.Text,
                        toolStripTextBox_TCPPort.Text,
                        MasterMsgEnd.Text,
                        "HEX",
                        "") == false)
                return;
            if (toolStripButton_Master.Text == "开启")
            {
                foreach(MultiCommunication_t p in listMultiComm)
                {
                    if(p.name == "S0")
                    {
                        masterComm.type = p.type;
                        masterComm.name = p.name;
                        masterComm.tcp = p.tcp;
                        masterComm.uart = p.uart;
                        break;
                    }
                }
                try
                {
                    toolStripComboBox_SerialPort.Enabled = false;
                    toolStripComboBox_BaudRate.Enabled = false;
                    toolStripTextBox_TCPPort.Enabled = false;

                    toolStripButton_BootOn.Enabled = true;
                    toolStripButton_Master.BackColor = Color.Tomato;
                    toolStripButton_Master.Image = Properties.Resources.关闭;
                    toolStripButton_Master.Text = "关闭";
                    button_Tx.BackColor = Color.Lime;

                    Label_Status.Text = "OPEN";
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
                    //关闭bootloader相关的线程
                    if (threadBootloader != null)
                        threadBootloader.Abort();
                    if (threadBootloaderDownload != null)
                        threadBootloaderDownload.Abort();
                    if (threadBootloaderErase != null)
                        threadBootloaderErase.Abort();

                    //关闭发送列表的线程
                    checkBox_TimSend.Enabled = true;
                    threadTableTx_RunFlag = false;
                    if (threadTableTx != null)
                        threadTableTx.Abort();

                    masterComm.type = "";
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
                CommMasterButtonSend();
            }
            else
                toolStripButton_Master_Click(toolStripButton_Master, e);
        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            /* 选项卡0，普通的通信助手收发 */
            if (gBootloaderFlag == true)
                return;
            /* 使用了超级报文，稍微等待，尽可能确保一次收完 */
            if (SuperMsgCurrent != null &&
                (System.IO.Ports.SerialPort)sender == masterComm.uart)
                Delay(10);
            byte[] RxBuf = new byte[1] ;
            int length = 串口接收数据(sender, ref RxBuf);
            if (length == 0)
                return;
            数据接收_显示_解析_输出日志(sender, "uart", ref RxBuf, length);
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
            if (gBootloaderFlag == false && toolStripButton_Master.Text == "关闭" && TextBox_Tx.Text.Length > 0)
            {
                CommMasterButtonSend();
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
            textBox_SuperMsgRxShow.Text = "";
            toolStripButton_RecClear.BackColor = Color.Transparent;
            toolStripButton_RecClear.Enabled = false;
            gTxNum = 0;
            gRxNum = 0;
            Label_Status.Text = "OPEN    TX:" + gTxNum + "    RX:" + gRxNum;
        }
        private void toolStripTextBox自动换行定时器周期_LostFocusClick(object sender, EventArgs e)
        {
            DataTypeConversion conversion = new DataTypeConversion();
            int delay = conversion.GetStringNumber(toolStripTextBox自动换行定时器周期.Text);
            Timer_RxAutoNewLine_Init(delay);
        }




        private void toolStripButton_SaveSet_MouseDown(object sender, MouseEventArgs e)
        {
            gCfg.SysCfgFileClear("多通道配置区");
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
            gCfg.SysCfgFileWrite("基本配置", "主设备的报尾", MasterMsgEnd.Text);
            gCfg.SysCfgFileWrite("基本配置", "自动换行时间", gTimer_RxAutoNewline.Interval.ToString());

            gCfg.SysCfgFileWrite("发送区", "MasterTx", TextBox_Tx.Text);
            gCfg.SysCfgFileWrite("接收区", "RxShowTextSize", richTextBox_Rx.Font.Size.ToString());

            /* 保存多通道的信息 */
            int cnt = 0;
            if (listMultiComm.Count > 0)
            {
                foreach (MultiCommunication_t p in listMultiComm)
                {
                    if (p.name == "S0")
                        continue;
                    gCfg.SysCfgFileWrite("多通道配置区", "设备" + cnt.ToString(), p.saveInfo);
                    cnt++;
                }
                gCfg.SysCfgFileWrite("多通道配置区", "最大设备数", cnt.ToString());
            }

            if("" == gCfg.TxListPath)
            {
                MessageBox.Show("请在[设置]中'新建'或'加载'发送列表!", "注意");
                return;
            }
            /* 保存发送列表 */
            gCfg.SysCfgFileWrite("发送列表", "path", gCfg.TxListPath);
            if (toolStripTextBox_TxListNum.Text == "")
                toolStripTextBox_TxListNum.Text = "64";
            gCfg.TxListSave(toolStripTextBox_TxListNum.Text);
            /* 保存精简发送列表 */
            try
            {
                textBoxTxListName_LostFocusClick(null, null);
                textBoxTxListMsg_LostFocusClick(null, null);
                if (txListSimple_List.Count > 0)
                {
                    int tx_cnt = 0;
                    string data = "";
                    string lineStr = "";
                    gCfg.IniWrite("TxListSimple",
                            "按钮个数",
                            txListSimple_List.Count.ToString(),
                            gCfg.TxListPath);
                    foreach (TxListSimple t in txListSimple_List)
                    {
                        data = t.DataType.ToString() + '$' + t.MsgName + '$';
                        if (t.Msg != null && t.Msg.Length > 0)
                        {
                            lineStr = t.Msg[0].Replace("$", "\\\\&");
                            data += lineStr;
                            for (int lines = 1; lines < t.Msg.Length; lines++)
                            {
                                lineStr = t.Msg[lines].Replace("$", "\\\\&");
                                data += "\\n" + lineStr;
                            }
                        }
                        gCfg.IniWrite("TxListSimple",
                            "TX" + tx_cnt.ToString(),
                            data,
                            gCfg.TxListPath);
                        tx_cnt++;
                    }
                }
            }
            catch { }
            /* 保存自动下发的数据 */
            string AutoTxData = textBox_AutoTx.Text.Replace("\r\n", "\\n");
            gCfg.IniWrite("自动下发指令",
                            "规则",
                            AutoTxData,
                            gCfg.TxListPath);

            /* 保存超级报文 */
            cnt = 0;
            int[] param_cnt = new int[SuperMsgList.Count];
            foreach (object obj in SuperMsgList)
            {
                param_cnt[cnt] = 0;
                foreach (SuperMsg.ParamClass_t p in ((List<SuperMsg.ParamClass_t>)obj))
                {
                    gCfg.IniWrite("SuperMsg",
                        "指令" + cnt.ToString() + '-' + param_cnt[cnt].ToString(),
                        p.save_info,
                        gCfg.TxListPath);
                    param_cnt[cnt]++;
                }
                cnt++;
            }
            gCfg.IniWrite("SuperMsg", "指令个数", cnt.ToString(), gCfg.TxListPath);
            for(int i = 0; i < cnt; i++)
            {
                gCfg.IniWrite("SuperMsg",
                    "指令" + i.ToString(),
                    param_cnt[i].ToString(),
                    gCfg.TxListPath);
                gCfg.IniWrite("SuperMsg",
                    "指令" + i.ToString() + "报文",
                    ((List<SuperMsg.ParamClass_t>)SuperMsgList[i])[0].msg_tx,
                    gCfg.TxListPath);
            }

            MessageBox.Show("发送框保存成功");
        }

        private void 加载超级报文()
        {
            /* 清除所有超级报文 */
            flowLayoutPanel_SuperMsg.Controls.Clear();
            foreach (object obj in SuperMsgList)
            {
                ((List<SuperMsg.ParamClass_t>)obj).Clear();
            }
            SuperMsgList.Clear();

            try
            {
                int cnt = Convert.ToInt32(gCfg.IniRead("SuperMsg", "指令个数", gCfg.TxListPath));
                int param_num;
                for (int i = 0; i < cnt; i++)
                {
                    SuperMsg superMsg = new SuperMsg();
                    param_num = Convert.ToInt32(gCfg.IniRead("SuperMsg", "指令" + i.ToString(), gCfg.TxListPath));
                    for (int pos = 0; pos < param_num; pos++)
                    {
                        string save_info = gCfg.IniRead("SuperMsg",
                            "指令" + i.ToString() + '-' + pos.ToString(),
                            gCfg.TxListPath);
                        superMsg.SuperMsgListParamReg(save_info);
                    }
                    superMsg.SuperMsgCreate(this);
                    superMsg.SuperMsgTxCfg(gCfg.IniRead("SuperMsg", "指令" + i.ToString() + "报文", gCfg.TxListPath));
                    flowLayoutPanel_SuperMsg.Controls.Add(superMsg.panelMsg);
                }
            }
            catch { }
        }

        private void 加载自动下发指令的规则()
        {
            try
            {
                string data = gCfg.IniRead("自动下发指令", "规则", gCfg.TxListPath);
                textBox_AutoTx.Text = data.Replace("\\n", "\r\n");
                toolStripButton_AutoTx_Update_Click(null, null);
            }
            catch { }
        }
        private void 加载简单的发送列表()
        {
            //先清除所有
            txListSimple_List.Clear();
            buttonListSimple.Clear();
            splitContainer_TxListSimple.Panel2.Controls.Clear();
            buttonListSimpleNumber = 0;

            try
            {
                int TxSimpleNum = Convert.ToInt32(gCfg.IniRead("TxListSimple", "按钮个数", gCfg.TxListPath));
                for (int i = 0; i < TxSimpleNum; i++)
                {
                    TxListSimple txListSimple = new TxListSimple();
                    string data = gCfg.IniRead("TxListSimple", "TX" + i.ToString(), gCfg.TxListPath);
                    string[] str = data.Split('$');
                    txListSimple.DataType = Convert.ToInt32(str[0]);
                    txListSimple.MsgName = str[1];
                    str[2] = str[2].Replace("\\\\&", "$");
                    string[] msg_data = str[2].Split(new string[] { "\\n" }, StringSplitOptions.RemoveEmptyEntries);
                    txListSimple.Msg = msg_data;
                    txListSimple_List.Add(txListSimple);
                }
            }
            catch { }

            //生成按钮
            if (txListSimple_List.Count > 0)
            {
                int last = txListSimple_List.Count - 1;
                for (int i = 0; i < txListSimple_List.Count; i++)
                {
                    buttonTxListSimpleCreate(txListSimple_List[last - i].MsgName);
                }
                txListSimple_DataLoad(0);
            }
            else
            {
                TxListSimpleCreate(0);
            }
            ////当前未打开精简发送列表，则折叠Panel1
            //if (tabControl_TxList.SelectedTab == tabPage_TxList)
            //    splitContainer_TxListSimple.Panel1Collapsed = true;
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
                    splitContainer_Master.Panel2Collapsed = Convert.ToBoolean(gCfg.SysCfgFileRead("基本配置", "TableTx显隐"));
                    splitContainer_Master.SplitterDistance = Convert.ToInt32(gCfg.SysCfgFileRead("基本配置", "MasterSize"));
                    splitContainer1.SplitterDistance = Convert.ToInt32(gCfg.SysCfgFileRead("基本配置", "TableTxSize"));

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

                    MasterMsgEnd.Text = gCfg.SysCfgFileRead("基本配置", "主设备的报尾");
                    string RxAutoNewDelay = gCfg.SysCfgFileRead("基本配置", "自动换行时间");
                    if (RxAutoNewDelay == "")
                        RxAutoNewDelay = TimerRxAutoNewlinePeriod.ToString();
                    toolStripTextBox自动换行定时器周期.Text = RxAutoNewDelay;
                    Timer_RxAutoNewLine_Init(Convert.ToInt32(RxAutoNewDelay));

                    TextBox_Tx.Text = gCfg.SysCfgFileRead("发送区", "MasterTx");
                    richTextBox_Rx.Font = new Font(richTextBox_Rx.Font.FontFamily,
                        Convert.ToSingle(gCfg.SysCfgFileRead("接收区", "RxShowTextSize")),
                        richTextBox_Rx.Font.Style);

                    //加载发送列表
                    string path = gCfg.SysCfgFileRead("发送列表", "path");
                    if("" != path)
                    {
                        gCfg.TxListPath = path;
                        gCfg.TxListNum = gCfg.TxList_GetNum(path);
                    }
                    toolStripTextBox_TxListNum.Text = gCfg.TxListNum.ToString();
                    
                    加载超级报文();
                }
                catch { }
            }
            //加载精简发送列表
            加载简单的发送列表();

            加载自动下发指令的规则();
        }

        private void richTextBox_Rx_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText);
        }
        private void richTextBox_Rx_ContentsResized(object sender, ContentsResizedEventArgs e)
        {
            richTextBox_Rx.ScrollToCaret();
        }


        private void toolStripButton_HEX_Click(object sender, EventArgs e)
        {
            ToolStripButton ylbtt = (ToolStripButton)sender;
            if (ylbtt.Text == "ASCII")
            {
                ylbtt.Text = "HEX";
                ylbtt.BackColor = Color.LimeGreen;
            }
            else
            {
                ylbtt.Text = "ASCII";
                ylbtt.BackColor = Color.Transparent;
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
            HelpShow(Color.Gold, "串口助手V2.1：");
            HelpShow(Color.Lime, "公众号：碎片聚合");
            HelpShow(Color.Lime, "GitHub：https://github.com/L231");
            HelpShow(Color.Lime, "下载链接 https://pan.baidu.com/s/1uoS-Xpm8JSPdkq5KYSMFFA?pwd=g1di");
            HelpShowNewLine();
            HelpShowNewLine();

            HelpShow(Color.Gold, "超级报文：");
            HelpShowNewLine();
            HelpShow(Color.Gold, "1.概述");
            HelpShow(Color.Moccasin, "1.1 简介");
            HelpShow(Color.Moccasin, "    使用主通信端口，在HEX格式下，提取报文中的特殊参数，进行监控");
            HelpShow(Color.Moccasin, "1.2 结构");
            HelpShow(Color.Moccasin, "    左侧快速控制栏 + 顶部显示区 + 报文列表 + 右键系统");
            HelpShow(Color.Moccasin, "1.3 每条报文的结构");
            HelpShow(Color.Moccasin, "    删除键 + 命名框 + 接收解析框 + 分割线 + 发送复选框 + 发送键");
            HelpShowNewLine();
            HelpShow(Color.Gold, "2.用法");
            HelpShow(Color.Moccasin, "2.1 创建新报文");
            HelpShow(Color.Moccasin, "    右键空白区，设置发送、接收框个数后创建");
            HelpShow(Color.Moccasin, "2.2 配置发送、接收框");
            HelpShow(Color.Moccasin, "    右键文本框，按自身需求配置相关参数，最后完成配置");
            HelpShow(Color.Moccasin, "2.3 设置报文");
            HelpShow(Color.Moccasin, "    右键发送键，输入文本即可");
            HelpShow(Color.Moccasin, "2.4 发送");
            HelpShow(Color.Moccasin, "    连接主通信端口后，单击发送键，发出报文");
            HelpShowNewLine();
            HelpShowNewLine();

            HelpShow(Color.Gold, "多级发送列表：");
            HelpShowNewLine();
            HelpShow(Color.Gold, "1.结构");
            HelpShow(Color.Moccasin, "监控区：自动按钮 + 发送状态");
            HelpShow(Color.Moccasin, "发送列表：HEX复选框 + 延时时间 + 数据框 + 按钮");
            HelpShowNewLine();
            HelpShow(Color.Gold, "2.发送按钮命名");
            HelpShow(Color.Moccasin, "2.1 右键发送按钮，完成命名");
            HelpShow(Color.Moccasin, "2.2 解锁情况下，双击“数据框”，可将文本移到按钮");
            HelpShowNewLine();
            HelpShow(Color.Gold, "3.循环发送");
            HelpShow(Color.Moccasin, "“自动”键开启，未设置延时时间的，自动跳过");
            HelpShowNewLine();
            HelpShow(Color.Gold, "4.报文打包（数据框可多行编辑）");
            HelpShow(Color.Moccasin, "4.1 结构：报文行、指令行，二者要区分开");
            HelpShow(Color.Moccasin, "4.2 指令(不区分大小写)：");
            HelpShow(Color.Moccasin, "    loop ... loopXX");
            HelpShow(Color.Moccasin, "    delayXX");
            HelpShow(Color.Moccasin, "    delayXX,loopxx");
            HelpShow(Color.Moccasin, "4.3 举例，数据框写入下述内容：");
            HelpShow(Color.Gold,     "    loop");
            HelpShow(Color.Gold,     "    12 25");
            HelpShow(Color.Gold,     "    delay100");
            HelpShow(Color.Gold,     "    12 34 56 78");
            HelpShow(Color.Gold,     "    delay100,loop2");
            HelpShow(Color.Gold,     "    loop3");
            HelpShow(Color.Moccasin, "4.4 说明：");
            HelpShow(Color.Moccasin, "    delay100，表示延时100ms");
            HelpShow(Color.Moccasin, "    delay100,loop2，表示上条报文发送2次，每次延时100ms");
            HelpShow(Color.Moccasin, "    loop 与 loop3，构成一个循环体，循环3次。可嵌套循环");
            HelpShowNewLine();
            HelpShow(Color.Gold, "5.多设备通信（共享数据收发区，报文也能打包）");
            HelpShow(Color.Moccasin, "5.1 注意 HEX按钮、报文结束符的配置");
            HelpShow(Color.Moccasin, "5.2 用法：设备名$ + 报文（只需在待发送数据前加设备前缀）");
            HelpShow(Color.Moccasin, "5.3 [设备名]是唯一的，注册时用户自定义");
            HelpShow(Color.Moccasin, "5.4 举例：万用表$READ? =>获取万用表读值");
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

            HelpShowNewLine();
            HelpShowNewLine();
            HelpShow(Color.Gold, "接收显示区右键，解锁控件后输入：help，回车");
            HelpShowNewLine();
        }


        private void TextboxTX_KeyUp(object sender, KeyEventArgs e)
        {
            TextBox yltb = sender as TextBox;
            if (e.KeyCode == Keys.Enter && yltb.Lines.Length <= 2)
            {
                try
                {
                    int i = 0;
                    int val = panel3.VerticalScroll.Value;
                    for (; i < gCfg.TxListNum; i++)
                    {
                        if (yltb == gCfg.TextboxTX[i])
                            break;
                    }
                    if (i >= gCfg.TxListNum)
                        i = gCfg.TxListNum - 1;
                    yltb.LostFocus -= new EventHandler(TextboxTX_LostFocusClick);
                    //yltb.GotFocus -= new EventHandler(TextboxTX_GotFocusClick);
                    yltb.ScrollBars = ScrollBars.Vertical;
                    tableLayoutPanel1.RowStyles[i].Height = 15 * 10;
                    tableLayoutPanel1.Size = new Size(tableLayoutPanel1.Size.Width, (20 * (gCfg.TxListNum - 1)) + 15 * 10);
                    yltb.LostFocus += new EventHandler(TextboxTX_LostFocusClick);
                    panel3.VerticalScroll.Value = val;
                }
                catch { MessageBox.Show("回车异常！", "ERROR"); }
            }
        }
        private void TextboxTX_GotFocusClick(object sender, EventArgs e)
        {
            int i = 0;
            try
            {
                TextBox yltb = sender as TextBox;
                if (yltb.Lines.Length < 2)
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

                int length = 10;
                //if (length >= 10)
                //{
                int val = panel3.VerticalScroll.Value;
                yltb.ScrollBars = ScrollBars.Vertical;
                panel3.VerticalScroll.Value = val;
                //    length = 10;
                //}
                tableLayoutPanel1.RowStyles[i].Height = 15 * length;
                tableLayoutPanel1.Size = new Size(tableLayoutPanel1.Size.Width, (20 * (gCfg.TxListNum - 1)) + 15 * length);
                yltb.LostFocus += new EventHandler(TextboxTX_LostFocusClick);
            }
            catch { MessageBox.Show("进入异常！", "ERROR"); }
        }
        private void TextboxTX_LostFocusClick(object sender, EventArgs e)
        {
            int i = 0;
            try
            {
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
                tableLayoutPanel1.Size = new Size(tableLayoutPanel1.Size.Width, (20 * gCfg.TxListNum));
                yltb.GotFocus += new EventHandler(TextboxTX_GotFocusClick);
            }
            catch { MessageBox.Show("退出异常！", "ERROR"); }
        }

        private int GetTxLoopCnt(string data)
        {
            try
            {
                if (data.IndexOf("LooP", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    //遇到了循环体
                    if (data.Replace(" ", "").Length == 4)
                        return 0;
                    DataTypeConversion dataType = new DataTypeConversion();
                    return dataType.GetStringNumber(data);
                }
            }
            catch { }
            return -1;
        }

        private void Delay(int tick)
        {
            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();
            while (stopwatch.Elapsed.TotalMilliseconds < tick)
            {
                Thread.Sleep(1);
            }
            stopwatch.Stop();
        }
        private int CommMultipleMsgSend(string[] msg, int posStart, string dataType)
        {
            int posEnd = -1;
            int posLast = posStart;
            int loop = -1;
            int cnt = 0;
            for(int line = posStart; line < msg.Length; line++)
            {
                if (msg[line] == "")
                    continue;
                //循环次数用完了
                if (loop == 0)
                    return posEnd;
                //循环结束的位置
                if (posEnd == line)
                {
                    loop--;
                    line = posStart - 1;
                    continue;
                }
                //延时处理、单条报文循环
                if (msg[line].IndexOf("DelaY", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    DataTypeConversion Conversion = new DataTypeConversion();
                    int delay = Conversion.GetStringNumber(msg[line]);
                    int sLoop = 0;
                    msg[line] = msg[line].ToUpper();
                    if (msg[line].Contains("LOOP"))
                    {
                        string[] delay_loop = msg[line].Split(new string[] { "LOOP" }, StringSplitOptions.RemoveEmptyEntries);
                        delay = Conversion.GetStringNumber(delay_loop[0]);
                        if(delay_loop.Length > 1)
                            sLoop = Conversion.GetStringNumber(delay_loop[1]) - 1;
                    }
                    while(sLoop-- > 0)
                    {
                        Delay(delay);
                        CommSingleMsgSend(msg[posLast], dataType);
                    }
                    Delay(delay);
                    continue;
                }

                cnt = GetTxLoopCnt(msg[line]);
                //遇到了嵌套的循环体
                if (cnt == 0)
                {
                    line = CommMultipleMsgSend(msg, line + 1, dataType);
                    continue;
                }
                //遇到了循环体的结束语句，包含了循环次数
                else if (cnt > 0)
                {
                    //确保循环体的结束语句合法
                    if (posStart > 0 && GetTxLoopCnt(msg[posStart - 1]) == 0)
                    {
                        posEnd = line;
                        loop = cnt - 1;
                        line = posStart - 1;
                    }
                    continue;
                }
                //发送报文
                CommSingleMsgSend(msg[line], dataType);
                posLast = line;
            }
            return msg.Length;
        }

        public void buttonClick(bool flag_hex, string[] txmsg)
        {
            if (masterComm.type != "")
            {
                if (toolStripButton_RecClear.Enabled == false)
                {
                    toolStripButton_RecClear.Enabled = true;
                    toolStripButton_RecClear.BackColor = Color.Gold;
                }

                string temp = "ASCII";
                string pattern = @"[^0-9]+";
                Regex rgx = new Regex(pattern);
                /* HEX发送 */
                if (flag_hex)
                {
                    temp = "HEX";
                }
                if(txmsg.Length == 1)
                    CommSingleMsgSend(txmsg[0], temp);
                else
                {
                    CommMultipleMsgSend(txmsg, 0, temp);
                }
            }
        }
        private void TableTxSingle_Click(object pos)
        {
            bool flagHEX = false;
            string[] TxMsg = null;
            int i = (int)pos;
            if (tabControl_TxList.SelectedTab == tabPage_TxList)
            {
                flagHEX = gCfg.Checkbox[i].Checked;
                TxMsg = gCfg.TextboxTX[i].Lines;
            }
            else
            {
                if (txListSimple_List[i].DataType == 0)
                    flagHEX = true;
                TxMsg = txListSimple_List[i].Msg;
            }
            buttonClick(flagHEX, TxMsg);
            threadTableTx_RunFlag = false;
            threadTableTx.Abort();
        }
        private void button_Click(object sender, EventArgs e)
        {
            if (threadTableTx_RunFlag)
                return;
            int i = 0;
            Button ylbtt = sender as Button;
            if (tabControl_TxList.SelectedTab == tabPage_TxList)
            {
                for (; i < gCfg.TxListNum; i++)
                {
                    if (ylbtt == gCfg.Button[i])
                        break;
                }
            }
            else
            {
                //提取当前按钮的数据
                i = buttonListSimpleNumber_Get(ylbtt);
                txListSimple_DataLoad(i);
                if (txListSimple_List[i].Msg == null)
                    return;
            }
            
            threadTableTx = new Thread(TableTxSingle_Click);
            threadTableTx.IsBackground = true;
            threadTableTx_RunFlag = true;
            threadTableTx.Start(i);
        }

        private void TableTx_Click()
        {
            toolStripLabel_TableTx.Text = "空闲，未设置延时发送";
            while (true)
            {
                if (gBootloaderFlag)
                    goto THREAD_TABLE_TX_ABORT;
                for (int i = 0; i < gCfg.TxListNum; i++)
                {
                    if (gCfg.TextboxTimer[i].Text.Length == 0)
                        continue;
                    int delay = 0;
                    try
                    {
                        delay = Convert.ToInt32(gCfg.TextboxTimer[i].Text);
                    }
                    catch
                    {
                        gCfg.TextboxTimer[i].Text = "";
                        continue;
                    }
                    try
                    {
                        toolStripLabel_TableTx.Text = "延时" + delay + "ms, TX: " + gCfg.Button[i].Text;
                        Delay(delay);
                        buttonClick(gCfg.Checkbox[i].Checked, gCfg.TextboxTX[i].Lines);
                    }
                    catch
                    {
                        goto THREAD_TABLE_TX_ABORT;
                    }
                }
            }
        THREAD_TABLE_TX_ABORT:
            toolStripButton_TableTx.Text = "自动";
            toolStripButton_TableTx.BackColor = Color.Lime;
            //button_Tx.Enabled = true;
            checkBox_TimSend.Enabled = true;
            threadTableTx_RunFlag = false;
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
        private void TxListHelp_MouseHover(object sender, EventArgs e)
        {
            Point point = new Point(0, 50);
            toolTip_TxList.Show("[HEX发送]+[延时框]+[报文编辑框]",
                (IWin32Window)sender,
                point,
                800);
        }

        private void 加载发送列表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gCfg.TxListLoad(tableLayoutPanel1, tableLayoutPanel2) == 0)
                return;
            TxListEventReg();
            splitContainer1.Size = new Size(246, (20 * gCfg.TxListNum) + 200);
            toolStripTextBox_TxListNum.Text = gCfg.TxListNum.ToString();
            加载简单的发送列表();
            
            加载超级报文();
            加载自动下发指令的规则();
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

        private void toolStripComboBox_SerialPort_DropDown(object sender, EventArgs e)
        {
            SerialPortNumberUpadta(toolStripComboBox_SerialPort);
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            ChannelListCreate();
        }

        [DllImport("User32")]
        public extern static void SetCursorPos(int x, int y);
        [DllImport("User32")]
        public extern static bool GetCursorPos(ref Point point);


        /// <summary>
        /// 不同数据类型的转换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripComboBox_Convert_TextUpdate(object sender, EventArgs e)
        {
            if (toolStripComboBox_Convert.Text == "")
                return;
            int pos = toolStripComboBox_Convert.SelectionStart;
            if (toolStripComboBox_Convert.DroppedDown == false)
            {
                toolStripComboBox_Convert.Items.Clear();
                toolStripComboBox_Convert.SelectionStart = pos;
                string str = "";
                toolStripComboBox_Convert.Items.Add(str);
                toolStripComboBox_Convert.Items.Add(str);
                toolStripComboBox_Convert.Items.Add(str);
                toolStripComboBox_Convert.Items.Add(str);
                toolStripComboBox_Convert.Items.Add(str);
                toolStripComboBox_Convert.DroppedDown = true;
                this.Cursor = Cursor;
                Point point = new Point();
                GetCursorPos(ref point);
                SetCursorPos(point.X, point.Y - 35);
            }
            UInt32 u32 = 0;
            toolStripComboBox_Convert.Text = toolStripComboBox_Convert.Text.ToUpper();
            toolStripComboBox_Convert.SelectionStart = pos;
            try
            {
                if (toolStripComboBox_Convert.Text.Length == 1 &&
                    (toolStripComboBox_Convert.Text[0] == 'X' ||
                    toolStripComboBox_Convert.Text[0] == 'D' ||
                    toolStripComboBox_Convert.Text[0] == 'S'))
                    return;
                switch (toolStripComboBox_Convert.Text[0])
                {
                    case 'X': //16进制输入
                        u32 = Convert.ToUInt32(toolStripComboBox_Convert.Text.Remove(0, 1), 16);
                        break;
                    case 'S': //浮点数输入
                        float f = float.Parse(toolStripComboBox_Convert.Text.Remove(0, 1));
                        byte[] fByte = BitConverter.GetBytes(f);
                        u32 = BitConverter.ToUInt32(fByte, 0);
                        break;
                    case 'D': //整型输入
                        u32 = Convert.ToUInt32(toolStripComboBox_Convert.Text.Remove(0, 1));
                        break;
                    default: //默认整型输入
                        u32 = Convert.ToUInt32(toolStripComboBox_Convert.Text);
                        break;
                }
                string b = Convert.ToString(u32, 2).PadLeft(1);
                for (int cnt = b.Length - 4; cnt > 0; cnt -= 4)
                {
                    b = b.Insert(cnt, ",");
                }
                //显示二进制
                toolStripComboBox_Convert.Items[0] = b;
                //显示u32
                toolStripComboBox_Convert.Items[1] = u32.ToString();
                //显示int32
                toolStripComboBox_Convert.Items[2] = "[int] " + ((int)u32).ToString();
                //16进制显示
                toolStripComboBox_Convert.Items[3] = "0x" + u32.ToString("X");
                //浮点数显示
                toolStripComboBox_Convert.Items[4] = "[float] " + (BitConverter.ToSingle(BitConverter.GetBytes(u32), 0)).ToString();
            }
            catch
            {
                if(pos > 0)
                {
                    toolStripComboBox_Convert.Text = toolStripComboBox_Convert.Text.Remove(pos - 1, 1);
                    toolStripComboBox_Convert.SelectionStart = pos - 1;
                }
            }
        }


        /// <summary>
        /// 快速创建超级报文，按钮触发右键菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            contextMenu.CreateSuperMsgMenu.Show(Control.MousePosition);
        }
        private void CreateSuperMsg_Handler(int rx_textbox, int tx_textbox)
        {
            SuperMsg superMsg = new SuperMsg();
            superMsg.formMain = this;
            superMsg.SuperMsgInit(rx_textbox, tx_textbox);
            flowLayoutPanel_SuperMsg.Controls.Add(superMsg.panelMsg);
            //superMsg.
        }

        public void SuperMsgListReg(object obj)
        {
            SuperMsgList.Add(obj);
        }
        public void SuperMsgListDelete(object obj)
        {
            SuperMsgList.Remove(obj);
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            realTimeCurve.RT_Curve_Off();
            System.Environment.Exit(0);
        }

        private void toolStripButton_AutoTx_Update_Click(object sender, EventArgs e)
        {
            if (textBox_AutoTx.Text != null)
                AutoTx.CmdUpdate(textBox_AutoTx.Lines, toolStripButton_TxHEX.Text, MasterMsgEnd.Text);
        }
    }
}
