using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 串口助手
{
    public partial class ChannelForm : Form
    {
        public Form1 formMain;




        public ChannelForm()
        {
            InitializeComponent();
        }

        public string getChannelFormParam()
        {
            return Channel_Name.Text + "$" + 
                Channel_COM.Text + "$" +
                Channel_BaudRate_or_IP.Text + "$" + 
                Channel_TCPPort.Text + "$" +
                Channel_Hex.Text + "$" + 
                Channel_MsgEnd.Text;
        }
        public void setChannelFormParam(string info)
        {
            string[] val = info.Split('$');
            Channel_Name.Text = val[0];
            Channel_COM.Text = val[1];
            Channel_BaudRate_or_IP.Text = val[2];
            Channel_TCPPort.Text = val[3];
            Channel_Hex.Text = val[4];
            Channel_MsgEnd.Text = val[5];
            if (Channel_Hex.Text == "HEX")
                Channel_Hex.BackColor = Color.LimeGreen;
        }

        private void Channel_Button1_Click(object sender, EventArgs e)
        {
            if(Channel_Name.Text == "")
            {
                MessageBox.Show("请填写设备名！", "ERROR");
                return;
            }
            if (formMain.设备注册(Channel_Name.Text, 
                                    Channel_Connect.Text, Channel_COM.Text,
                                    Channel_BaudRate_or_IP.Text,
                                    Channel_TCPPort.Text, Channel_MsgEnd.Text, 
                                    Channel_Hex.Text, 
                                    getChannelFormParam()) == false)
                return;
            if (Channel_Connect.Text == "开启")
            {
                try
                {
                    //设备注册情况
                    formMain.richTextBox_Rx.AppendText(Channel_Name.Text + "  " + Channel_COM.Text + " 注册成功！"+ System.Environment.NewLine);

                    Channel_Name.Enabled = false;
                    Channel_COM.Enabled = false;
                    Channel_BaudRate_or_IP.Enabled = false;
                    Channel_TCPPort.Enabled = false;
                    Channel_Hex.Enabled = false;
                    Channel_MsgEnd.Enabled = false;

                    Channel_Connect.BackColor = Color.Tomato;
                    Channel_Connect.Image = Properties.Resources.关闭;
                    Channel_Connect.Text = "关闭";
                }
                catch { }
            }
            else
            {
                Channel_Connect.BackColor = Color.LimeGreen;
                Channel_Connect.Image = Properties.Resources.开启;
                Channel_Connect.Text = "开启";
                Channel_Name.Enabled = true;
                Channel_COM.Enabled = true;
                Channel_BaudRate_or_IP.Enabled = true;
                Channel_TCPPort.Enabled = true;
                Channel_Hex.Enabled = true;
                Channel_MsgEnd.Enabled = true;
            }
        }
        /// <summary>
        /// 扫描可用的通信端口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Channel_COM_DropDown(object sender, EventArgs e)
        {
            /* 清除当前组合框的下拉菜单内容 */
            Channel_COM.Items.Clear();
            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher
                ("select * from Win32_PnPEntity where Name like '%(COM%'"))
            {
                var hardInfos = searcher.Get();
                foreach (var hardInfo in hardInfos)
                {
                    if (hardInfo.Properties["Name"].Value != null)
                    {
                        string deviceName = hardInfo.Properties["Name"].Value.ToString();
                        Channel_COM.Items.Add(deviceName);
                    }
                }
            }
            Channel_COM.Items.Add("TCP Client");
        }

        private void Channel_Hex_Click(object sender, EventArgs e)
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

        private void Channel_Delete_Click(object sender, EventArgs e)
        {
            formMain.设备注册(Channel_Name.Text, 
                                "关闭",
                                Channel_COM.Text,
                                Channel_BaudRate_or_IP.Text,
                                Channel_TCPPort.Text,
                                Channel_MsgEnd.Text,
                                Channel_Hex.Text,
                                "");
            this.Close();
            formMain.ChannelListDelete(this);
        }
    }
}
