using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 串口助手
{
    public class SuperMsg
    {
        public Form1 formMain;

        public class ParamClass_t
        {
            public bool flag_valid;
            public bool flag_rx_param;
            public string name;
            public string data_type;
            public bool flag_msb;
            public int in_msg_pos;
            public int byte_num;
            public byte[] status_num;
            public string[] status;
            public string status_text;
            public TextBox rx_textbox;
            public ComboBox tx_combobox;
            public int box_width;
            public string save_info;
            public string msg_tx;
        };

        //做成一个类，供主窗口创建。在这里处理所有逻辑，然后传递报文给主窗口处理
        //传递报文的同时，主窗口记录这个对象
        //接下来收到完整的应答后，主窗口传递数据给这个对象，完成数据的解析

        public FlowLayoutPanel panelMsg = new FlowLayoutPanel();
        /// <summary>
        /// 文本框的链表
        /// </summary>
        public List<ParamClass_t> listParam = new List<ParamClass_t>();

        private ContextMenuStrip menuTxMsgWrite = new ContextMenuStrip();
        private ContextMenuStrip menuParamCfg = new ContextMenuStrip();

        private const int 状态列表_DefHight = 40;

        private ToolStripTextBox 参数名称 = new ToolStripTextBox();
        private ToolStripTextBox 文本框长度 = new ToolStripTextBox();
        private ToolStripComboBox 数据类型 = new ToolStripComboBox();
        private ToolStripComboBox 高位在前 = new ToolStripComboBox();
        private ToolStripTextBox 字节数 = new ToolStripTextBox();
        private ToolStripTextBox 在报文中的位置 = new ToolStripTextBox();
        private ToolStripTextBox 状态列表 = new ToolStripTextBox();
        private ToolStripMenuItem 确定按钮 = new ToolStripMenuItem();

        private TextBox msgFunc = new TextBox();
        private Button 发送按钮 = new Button();
        private ToolTip tooltipHelp = new ToolTip();

        public void SuperMsgInit(int rx_textbox, int tx_textbox)
        {
            for (int p = 0; p < rx_textbox; p++)
            {
                ParamClass_t Param = new ParamClass_t();
                Param.flag_valid = false;
                Param.flag_rx_param = true;
                Param.name = "RX参数" + p.ToString();
                listParam.Add(Param);
                Param.rx_textbox = new TextBox();
                Param.rx_textbox.Width = 50;
                Param.rx_textbox.ContextMenuStrip = menuParamCfg;
                Param.rx_textbox.ReadOnly = true;
                Param.box_width = Param.rx_textbox.Width;
            }
            for (int p = 0; p < tx_textbox; p++)
            {
                ParamClass_t Param = new ParamClass_t();
                Param.flag_valid = false;
                Param.flag_rx_param = false;
                Param.name = "TX参数" + p.ToString();
                listParam.Add(Param);
                Param.tx_combobox = new ComboBox();
                Param.tx_combobox.Width = 80;
                Param.tx_combobox.ContextMenuStrip = menuParamCfg;
                Param.box_width = Param.tx_combobox.Width;
            }
            生成一条控件();
            msgFunc.Text = "SuperMsg";
        }
        public void SuperMsgCreate(Control control)
        {
            foreach (ParamClass_t p in listParam)
            {
                if (p.flag_rx_param)
                {
                    p.rx_textbox = new TextBox();
                    p.rx_textbox.Width = p.box_width;
                    p.rx_textbox.ReadOnly = true;
                    p.rx_textbox.ContextMenuStrip = menuParamCfg;
                }
                else
                {
                    p.tx_combobox = new ComboBox();
                    p.tx_combobox.Width = p.box_width;
                    p.tx_combobox.ContextMenuStrip = menuParamCfg;
                    if (p.data_type == "枚举类")
                    {
                        p.tx_combobox.DropDownStyle = ComboBoxStyle.DropDownList;
                        p.tx_combobox.Items.AddRange(p.status);
                    }
                    else
                        p.tx_combobox.DropDownStyle = ComboBoxStyle.Simple;
                }
            }
            formMain = (Form1)control;
            生成一条控件();
        }
        public void SuperMsgTxCfg(string msg_tx)
        {
            listParam[0].msg_tx = msg_tx;
            menuTxMsgWrite.Items[0].Text = listParam[0].msg_tx;
        }
        public void SuperMsgListParamReg(string save_info)
        {
            string[] info = save_info.Split('$');
            ParamClass_t p = new ParamClass_t();
            p.save_info = save_info;

            msgFunc.Text = info[0];
            p.flag_valid = Convert.ToBoolean(info[1]);
            p.flag_rx_param = Convert.ToBoolean(info[2]);
            p.name = info[3];
            p.data_type = info[4];
            p.flag_msb = Convert.ToBoolean(info[5]);
            p.in_msg_pos = Convert.ToInt32(info[6]);
            p.byte_num = Convert.ToInt32(info[7]);
            p.box_width = Convert.ToInt32(info[8]);
            if (p.data_type == "枚举类")
            {
                p.status_text = info[9].Replace("\\n", "\r\n");
                GetStatusList(p, p.status_text);
            }
            listParam.Add(p);
        }

        private void 生成一条控件()
        {
            ContextMenu_TxMsgWriteInit();
            ContextMenu_ParamCfgInit();

            Button Delete = new Button();
            TextBox 分割线 = new TextBox();

            Delete.Size = new System.Drawing.Size(25, 25);
            Delete.Margin = new Padding(0, 1, 0, 0);
            Delete.BackColor = System.Drawing.Color.Red;
            Delete.Image = global::串口助手.Properties.Resources.删除;
            Delete.Click += new EventHandler(Delete_Click);

            msgFunc.Width = 100;
            msgFunc.TextAlign = HorizontalAlignment.Right;
            msgFunc.KeyUp += new KeyEventHandler(msgFunc_KeyUpClick);
            msgFunc.LostFocus += new EventHandler(msgFunc_LostFocusClick);
            msgFunc.MouseHover += new EventHandler(tooltipmsgFunc_MouseHover);
            
            发送按钮.Width = 50;
            发送按钮.Margin = new Padding(0, 2, 0, 0);
            发送按钮.ContextMenuStrip = menuTxMsgWrite;
            发送按钮.BackColor = System.Drawing.Color.Coral;
            发送按钮.Click += new EventHandler(发送按钮_Click);
            发送按钮.MouseHover += new EventHandler(tooltip发送按钮_MouseHover);
            
            分割线.Width = 2;
            分割线.BorderStyle = BorderStyle.FixedSingle;
            分割线.BackColor = System.Drawing.Color.Black;
            分割线.Enabled = false;

            //panelMsg.AutoSize = true;
            panelMsg.Margin = new Padding(0, 0, 0, 0);
            panelMsg.Size = new System.Drawing.Size(650, 25);
            panelMsg.Controls.Add(Delete);
            panelMsg.Controls.Add(msgFunc);
            foreach (ParamClass_t p in listParam)
            {
                if (p.flag_rx_param)
                {
                    p.rx_textbox.MouseHover += new EventHandler(tooltipParam_MouseHover);
                    panelMsg.Controls.Add(p.rx_textbox);
                }
            }
            panelMsg.Controls.Add(分割线);
            foreach (ParamClass_t p in listParam)
            {
                if (!p.flag_rx_param)
                {
                    p.tx_combobox.MouseHover += new EventHandler(tooltipParam_MouseHover);
                    panelMsg.Controls.Add(p.tx_combobox);
                }
            }
            panelMsg.Controls.Add(发送按钮);
            formMain.SuperMsgListReg(listParam);
        }
        private void ContextMenu_TxMsgWriteInit()
        {
            menuTxMsgWrite.Name = "编辑发送报文的右键菜单";
            ToolStripTextBox 报文输入框 = new ToolStripTextBox();
            报文输入框.BackColor = System.Drawing.Color.Coral;
            报文输入框.Size = new System.Drawing.Size(300, 27);
            报文输入框.ToolTipText = "请编辑报文，系统设置可配置报尾";
            报文输入框.LostFocus += new EventHandler(menuTxMsgWrite_LostFocusClick);
            menuTxMsgWrite.Items.AddRange(new ToolStripItem[]
            {
                报文输入框,
            });
        }
        private void ContextMenu_ParamCfgInit()
        {
            menuParamCfg.Name = "接收框右键菜单";
            参数名称.BackColor = System.Drawing.Color.Coral;
            参数名称.Size = new System.Drawing.Size(150, 25);
            参数名称.Text = "参数名称";
            参数名称.ToolTipText = "请填写参数名称";

            文本框长度.Size = new System.Drawing.Size(130, 25);
            文本框长度.Text = "文本框长度：";
            文本框长度.ToolTipText = "用于设置文本框长度";
            数据类型.Size = new System.Drawing.Size(130, 25);
            数据类型.Items.Add("10进制");
            数据类型.Items.Add("16进制");
            数据类型.Items.Add("枚举类");
            数据类型.DropDownStyle = ComboBoxStyle.DropDownList;
            数据类型.FlatStyle = FlatStyle.Standard;
            数据类型.Text = "10进制";
            数据类型.ToolTipText = "参数类型";
            高位在前.Size = new System.Drawing.Size(130, 25);
            高位在前.Items.Add("高字节在前");
            高位在前.Items.Add("低字节在前");
            高位在前.DropDownStyle = ComboBoxStyle.DropDownList;
            高位在前.FlatStyle = FlatStyle.Standard;
            高位在前.Text = "高字节在前";
            高位在前.ToolTipText = "参数解析的方向，供10进制参数使用";

            字节数.Size = new System.Drawing.Size(130, 25);
            字节数.Text = "字节数：";
            字节数.ToolTipText = "该参数占用字节数，枚举类参数可忽略";
            在报文中的位置.Size = new System.Drawing.Size(130, 25);
            在报文中的位置.Text = "报文中的位置：";
            在报文中的位置.ToolTipText = "该参数在报文中的位置";

            状态列表.AutoSize = false;
            状态列表.WordWrap = false;
            状态列表.Multiline = true;
            状态列表.Size = new System.Drawing.Size(150, 状态列表_DefHight);
            状态列表.BackColor = System.Drawing.Color.LightGray;
            状态列表.ToolTipText = "枚举类的列表，格式（0x12：状态1），一行一个状态";

            确定按钮.Text = "完成配置";
            确定按钮.BackColor = System.Drawing.Color.Coral;
            确定按钮.Click += new EventHandler(确定按钮ToolStripMenuItem_Click);
            menuParamCfg.Items.AddRange(new ToolStripItem[]
            {
                参数名称,
                文本框长度,
                数据类型,
                高位在前,
                在报文中的位置,
                字节数,
                状态列表,
                确定按钮,
            });
            menuParamCfg.Opening += new CancelEventHandler(menuParamCfg_Opening);
        }

        private void tooltipParam_MouseHover(object sender, EventArgs e)
        {
            string ParamName = "";
            Control c = (Control)sender;
            bool flag_textbox = false;
            if (c.GetType().Name == "TextBox")
                flag_textbox = true;
            try
            {
                foreach (ParamClass_t p in listParam)
                {
                    if ((flag_textbox && p.rx_textbox == (TextBox)c) ||
                        (!flag_textbox && p.tx_combobox == (ComboBox)c))
                    {
                        ParamName = '[' + p.name + ']';
                        break;
                    }
                }
            }
            catch { }
            Point point = new Point(0, 50);
            tooltipHelp.Show(ParamName + " 右键配置",
                (IWin32Window)sender,
                point,
                350);
        }
        private void tooltipmsgFunc_MouseHover(object sender, EventArgs e)
        {
            Point point = new Point(0, 50);
            tooltipHelp.Show("功能描述",
                (IWin32Window)sender,
                point,
                350);
        }
        private void tooltip发送按钮_MouseHover(object sender, EventArgs e)
        {
            string HelpShow = "";
            if (menuTxMsgWrite.Items[0].Text == "")
                HelpShow = "右键添加报文，系统设置可配置报尾";
            else
                HelpShow = '[' + menuTxMsgWrite.Items[0].Text + ']' + " 右键修改";

            Point point = new Point(0, 50);
            tooltipHelp.Show(HelpShow, (IWin32Window)sender, point, 800);
        }
        private void msgFunc_KeyUpClick(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                msgFunc_LostFocusClick(sender, e);
            }
        }
        private void msgFunc_LostFocusClick(object sender, EventArgs e)
        {
            foreach(ParamClass_t p in listParam)
            {
                p.save_info = GetListParamSaveInfo(p);
            }
        }
        private void 发送按钮_Click(object sender, EventArgs e)
        {
            try
            {
                formMain.SuperMsgCurrent = this;
                formMain.SuperMsgSendData(TxMsg_Handler(), msgFunc.Text);
            }
            catch { }
        }
        private void Delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (formMain.SuperMsgCurrent == this)
                    formMain.SuperMsgCurrent = null;
                formMain.flowLayoutPanel_SuperMsg.Controls.Remove(panelMsg);
                formMain.SuperMsgListDelete(listParam);
                listParam.Clear();
                menuTxMsgWrite = null;
                menuParamCfg = null;
            }
            catch { }
        }

        public void RxMsg_Handler(byte[] rx_msg)
        {
            foreach (ParamClass_t p in listParam)
            {
                if (true == p.flag_rx_param && true == p.flag_valid)
                {
                    switch (p.data_type)
                    {
                        case "10进制":
                            int val = 0;
                            int end_pos = p.in_msg_pos + p.byte_num;
                            if (true == p.flag_msb)
                            {
                                for (int i = p.in_msg_pos; i < end_pos; i++)
                                    val = (val << 8) | rx_msg[i];
                            }
                            else
                            {
                                for (int i = end_pos - 1; i > p.in_msg_pos - 1; i--)
                                    val = (val << 8) | rx_msg[i];
                            }
                            p.rx_textbox.Text = val.ToString();
                            break;
                        case "16进制":
                            DataTypeConversion dataType = new DataTypeConversion();
                            string str = dataType.ByteToString("HEX",
                                rx_msg.Skip(p.in_msg_pos).Take(p.byte_num).ToArray(),
                                p.byte_num);
                            p.rx_textbox.Text = str;
                            break;
                        case "枚举类":
                            for (int i = 0; i < p.status_num.Length; i++)
                            {
                                if (rx_msg[p.in_msg_pos] == p.status_num[i])
                                {
                                    p.rx_textbox.Text = p.status[i];
                                    break;
                                }
                            }
                            break;
                    }
                }
            }
        }

        private string TxMsg_Handler()
        {
            DataTypeConversion dataType = new DataTypeConversion();
            string tx_data = menuTxMsgWrite.Items[0].Text;
            if (tx_data == "")
            {
                tx_data = listParam[0].msg_tx;
                menuTxMsgWrite.Items[0].Text = tx_data;
            }
            else
                listParam[0].msg_tx = tx_data;
            byte[] msg = dataType.StringToByte("HEX", tx_data);
            foreach (ParamClass_t p in listParam)
            {
                if (false == p.flag_rx_param && true == p.flag_valid)
                {
                    switch (p.data_type)
                    {
                        case "10进制":
                            uint val = 0;
                            int end_pos = p.in_msg_pos + p.byte_num;
                            val = (uint)dataType.GetStringNumber(p.tx_combobox.Text);
                            if (true == p.flag_msb)
                            {
                                for (int i = p.in_msg_pos, offset = p.byte_num - 1;
                                    i < end_pos;
                                    i++, offset--)
                                    msg[i] = (byte)(val >> (8 * offset));
                            }
                            else
                            {
                                for (int i = p.in_msg_pos, offset = 0;
                                    i < end_pos;
                                    i++, offset++)
                                    msg[i] = (byte)(val >> (8 * offset));
                            }
                            break;
                        case "16进制":
                            byte[] data = dataType.StringToByte("HEX", p.tx_combobox.Text);
                            for(int i = 0; i < p.byte_num; i++)
                            {
                                msg[i + p.in_msg_pos] = data[i];
                            }
                            break;
                        case "枚举类":
                            for (int i = 0; i < p.status.Length; i++)
                            {
                                if (p.tx_combobox.Text == p.status[i])
                                {
                                    msg[p.in_msg_pos] = p.status_num[i];
                                    break;
                                }
                            }
                            break;
                    }
                }
            }
            return BitConverter.ToString(msg).Replace("-", " ");
        }

        private void GetStatusList(ParamClass_t p, string status_text)
        {
            string[] list = status_text.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            int StatusNum = 0;
            int pos = 0;

            //去除多余的空行
            p.status_text = "";
            foreach (string s in list)
            {
                if (s != "")
                {
                    StatusNum++;
                    p.status_text += s + "\r\n";
                }
            }
            p.status_text = p.status_text.Substring(0, p.status_text.Length - 2);

            //解析全部状态，并缓存到ParamClass_t类中
            p.status_num = new byte[StatusNum];
            p.status = new string[StatusNum];
            string[] status;
            foreach (string s in list)
            {
                if (s == "")
                    continue;
                status = s.Split(':', '：');
                p.status_num[pos] = GetStringHEX(status[0]);
                p.status[pos] = status[1];
                pos++;
            }
        }
        private void 确定按钮ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Control c = menuParamCfg.SourceControl;
            bool flag_textbox = false;
            if (c.GetType().Name == "TextBox")
                flag_textbox = true;
            try
            {
                foreach (ParamClass_t p in listParam)
                {
                    if ((flag_textbox && p.rx_textbox == (TextBox)c) ||
                        (!flag_textbox && p.tx_combobox == (ComboBox)c))
                    {
                        DataTypeConversion dataType = new DataTypeConversion();
                        p.name = 参数名称.Text;
                        if ("高字节在前" == 高位在前.Text)
                            p.flag_msb = true;
                        else
                            p.flag_msb = false;
                        p.in_msg_pos = dataType.GetStringNumber(在报文中的位置.Text);
                        p.data_type = 数据类型.Text;
                        if ("枚举类" == p.data_type)
                        {
                            if (!flag_textbox)
                                p.tx_combobox.DropDownStyle = ComboBoxStyle.DropDownList;
                            p.status_text = 状态列表.Text;
                            GetStatusList(p, p.status_text);
                            if (flag_textbox == false)
                            {
                                p.tx_combobox.Items.Clear();
                                p.tx_combobox.Items.AddRange(p.status);
                            }
                        }
                        //测试类一定要获取字节数
                        else
                        {
                            if (!flag_textbox)
                            {
                                p.tx_combobox.Items.Clear();
                                p.tx_combobox.DropDownStyle = ComboBoxStyle.Simple;
                            }
                            p.status_text = "";
                            状态列表.Text = "";
                            p.byte_num = dataType.GetStringNumber(字节数.Text);
                        }
                        p.flag_valid = true;
                        p.box_width = dataType.GetStringNumber(文本框长度.Text);
                        if (flag_textbox)
                            p.rx_textbox.Width = p.box_width;
                        else
                            p.tx_combobox.Width = p.box_width;
                        p.save_info = GetListParamSaveInfo(p);
                        return;
                    }
                }
            }
            catch { }
            MessageBox.Show("配置参数有误，请检查！", "ERROR");
        }

        private void menuTxMsgWrite_LostFocusClick(object sender, EventArgs e)
        {
            listParam[0].msg_tx = menuTxMsgWrite.Items[0].Text;
        }
        private void menuParamCfg_Opening(object sender, CancelEventArgs e)
        {
            ParamClass_t param = null;
            Control c = menuParamCfg.SourceControl;
            if(c.GetType().Name == "TextBox")
            {
                foreach(ParamClass_t p in listParam)
                {
                    if(p.rx_textbox == (TextBox)c)
                    {
                        param = p;
                        break;
                    }
                }
            }
            else if(c.GetType().Name == "ComboBox")
            {
                foreach (ParamClass_t p in listParam)
                {
                    if (p.tx_combobox == (ComboBox)c)
                    {
                        param = p;
                        break;
                    }
                }
            }
            参数名称.Text = param.name;
            文本框长度.Text = "文本框长度：" + param.box_width.ToString();
            字节数.Text = "字节数：" + param.byte_num.ToString();
            在报文中的位置.Text = "报文中的位置：" + param.in_msg_pos.ToString();

            if(param.flag_valid)
            {
                数据类型.Text = param.data_type;
                if (param.flag_msb)
                    高位在前.Text = "高字节在前";
                else
                    高位在前.Text = "低字节在前";

                if(数据类型.Text == "枚举类")
                {
                    if (param.status_text == "")
                        return;
                    状态列表.Text = param.status_text;
                    int height = 25 * param.status.Length;
                    if (height > 375)
                        height = 375;
                    状态列表.Height = height;
                    //状态列表.Size = new System.Drawing.Size(100, 25 * i);
                }
                else
                {
                    状态列表.Text = "";
                    状态列表.Height = 状态列表_DefHight;
                }
            }
            else
            {
                高位在前.Text = "高字节在前";
                状态列表.Text = "";
                状态列表.Height = 状态列表_DefHight;
            }
        }

        private string GetListParamSaveInfo(ParamClass_t p)
        {
            string save_info = msgFunc.Text;
            save_info += ('$' + p.flag_valid.ToString() + '$' +
                p.flag_rx_param.ToString() + '$' +
                p.name + '$' +
                p.data_type + '$' +
                p.flag_msb.ToString() + '$' +
                p.in_msg_pos.ToString() + '$' +
                p.byte_num.ToString() + '$' +
                p.box_width.ToString());
            if (p.data_type == "枚举类")
            {
                save_info += ('$' + p.status_text.Replace("\r\n", "\\n"));
            }
            return save_info;
        }
        private byte GetStringHEX(string text)
        {
            int pos = 0, val = 0;
            int end = text.Length - 1;
            string str = text.ToUpper();
            if (str[0] == '0' && str[1] == 'X')
            {
                pos = 2;
            }
            if (str[pos] >= 'A' && str[pos] <= 'F')
                val = str[pos] + 10 - 'A';
            else
                val = str[pos] - '0';
            if(pos < end)
            {
                val <<= 4;
                if (str[pos + 1] >= 'A' && str[pos + 1] <= 'F')
                    val |= str[pos + 1] + 10 - 'A';
                else
                    val |= str[pos + 1] - '0';
            }
            return (byte)val;
        }
    }
}
