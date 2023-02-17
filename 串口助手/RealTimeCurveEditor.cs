using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace 串口助手
{
    public partial class RealTimeCurveEditor : Form
    {
        public delegate void rtCurveCtr(Series series);
        public rtCurveCtr rtCurveChannelDelete;

        /// <summary>
        /// 通道列表
        /// </summary>
        public List<RealTimeCurve_Channel.Channel> rtCurveChannels = new List<RealTimeCurve_Channel.Channel>();

        public RealTimeCurveEditor()
        {
            InitializeComponent();
            CurveGain.SelectedIndex = 4;
        }

        public bool rtCurveChannelCheck(string channel)
        {
            if (ComboBox_Channel.Items.IndexOf(channel) != -1)
                return true;
            return false;
        }
        public bool rtCurveChannelsNameReg(string channel)
        {
            if (channel == "")
                return false;
            foreach(string str in ComboBox_Channel.Items)
            {
                if (str == channel)
                {
                    return false;
                }
            }
            ComboBox_Channel.Items.Add(channel);
            ComboBox_Channel.SelectedIndex = ComboBox_Channel.Items.Count - 1;
            return true;
        }

        public bool MsgDecodeCfg()
        {
            foreach(RealTimeCurve_Channel.Channel ch in rtCurveChannels)
            {
                if(ch.series.Name == ComboBox_Channel.Text)
                {
                    //加载曲线的参数
                    if (CurveName.Text != ch.series.Name)
                    {
                        if (-1 == ComboBox_Channel.Items.IndexOf(CurveName.Text))
                        {
                            ComboBox_Channel.Items[ComboBox_Channel.SelectedIndex] = CurveName.Text;
                            ch.series.Name = CurveName.Text;
                        }
                        else
                            CurveName.Text = ch.series.Name;
                    }

                    ch.msgDecode.data_type = ComboBox_MsgDataType.SelectedIndex;
                    if(MsgFlagMSB.Text == "MSB")
                        ch.msgDecode.flag_msb = true;
                    else
                        ch.msgDecode.flag_msb = false;
                    ch.msgDecode.in_msg_pos = Convert.ToInt32(MsgParamOffset.Text);
                    ch.msgDecode.byte_num = Convert.ToInt32(MsgParamByteNum.Text);

                    if (MsgHead.Text == "")
                    {
                        MessageBox.Show("请填写解析规则的报头！", "ERROR");
                        return false;
                    }
                    DataTypeConversion dataType = new DataTypeConversion();
                    string temp = "HEX";
                    if (ch.msgDecode.data_type == 2)
                        temp = "ASCII";
                    ch.msgDecode.head = dataType.StringToByte(temp, MsgHead.Text);
                    if(ch.msgDecode.head == null)
                    {
                        MessageBox.Show("解析规则的报头应是HEX格式！", "ERROR");
                        return false;
                    }
                    return true;
                }
            }
            return true;
        }


        private void ComboBox_Channel_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (RealTimeCurve_Channel.Channel ch in rtCurveChannels)
            {
                if (ch.series.Name == ComboBox_Channel.Text)
                {
                    float[] gain = { 10, 8, 4, 2, 1, 0.5f, 0.25f, 0.125f, 0.1f };
                    //加载曲线的参数
                    CurveName.Text = ComboBox_Channel.Text;
                    CurveGain.SelectedIndex = Array.IndexOf(gain, ch.gain);

                    //加载解析规则
                    ComboBox_MsgDataType.SelectedIndex = ch.msgDecode.data_type;
                    if (ch.msgDecode.flag_msb)
                        MsgFlagMSB.Text = "LSB";
                    else
                        MsgFlagMSB.Text = "MSB";
                    MsgFlagMSB_Click(null, null);

                    MsgParamOffset.Text = ch.msgDecode.in_msg_pos.ToString();
                    MsgParamByteNum.Text = ch.msgDecode.byte_num.ToString();

                    if (ch.msgDecode.head == null)
                    {
                        MsgHead.Text = "";
                        return;
                    }
                    DataTypeConversion dataType = new DataTypeConversion();
                    string temp = "HEX";
                    if (ch.msgDecode.data_type == 2)
                        temp = "ASCII";
                    MsgHead.Text = dataType.ByteToString(temp, ch.msgDecode.head, ch.msgDecode.head.Length);
                    return;
                }
            }
        }

        private void MsgFlagMSB_Click(object sender, EventArgs e)
        {
            if (MsgFlagMSB.Text == "MSB")
            {
                MsgFlagMSB.BackColor = Color.Transparent;
                MsgFlagMSB.ToolTipText = "低位在前";
                MsgFlagMSB.Text = "LSB";
            }
            else
            {
                MsgFlagMSB.BackColor = Color.LimeGreen;
                MsgFlagMSB.ToolTipText = "高位在前";
                MsgFlagMSB.Text = "MSB";
            }
        }

        private void toolStripButton_绘制曲线_Click(object sender, EventArgs e)
        {
            if (ComboBox_Channel.Text == "")
                return;
            if(rtCurveChannels[ComboBox_Channel.SelectedIndex].enable)
            {
                rtCurveChannels[ComboBox_Channel.SelectedIndex].enable = false;
                toolStripButton_绘制曲线.BackColor = Color.LimeGreen;
                toolStripButton_绘制曲线.Image = Properties.Resources.开启;
            }
            else
            {
                rtCurveChannels[ComboBox_Channel.SelectedIndex].enable = true;
                toolStripButton_绘制曲线.BackColor = Color.Tomato;
                toolStripButton_绘制曲线.Image = Properties.Resources.关闭;
            }
        }

        private void toolStripButton_删除曲线_Click(object sender, EventArgs e)
        {
            if (rtCurveChannels.Count < 2)
                return;
            int channel = ComboBox_Channel.SelectedIndex;
            rtCurveChannelDelete(rtCurveChannels[channel].series);
            rtCurveChannels.RemoveAt(channel);
            ComboBox_Channel.Items.RemoveAt(channel);
            if (ComboBox_Channel.Items.Count > channel)
                ComboBox_Channel.SelectedIndex = channel;
            else
                ComboBox_Channel.SelectedIndex = channel - 1;
        }

        private void CurveGain_SelectedIndexChanged(object sender, EventArgs e)
        {

            float[] gain = { 10, 8, 4, 2, 1, 0.5f, 0.25f, 0.125f, 0.1f };
            //加载曲线的参数
            foreach (RealTimeCurve_Channel.Channel ch in rtCurveChannels)
            {
                if (ch.series.Name == ComboBox_Channel.Text)
                {
                    ch.gain = gain[CurveGain.SelectedIndex];
                    return;
                }
            }
                    
        }
    }
}
