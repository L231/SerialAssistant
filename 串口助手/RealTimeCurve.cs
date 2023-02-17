using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace 串口助手
{
    public partial class RealTimeCurve : Form
    {
        
        private bool rtCurve_Enable = true;

        RealTimeCurveEditor EditorForm = new RealTimeCurveEditor();

        RealTimeCurve_Channel rtCurve_Channel = new RealTimeCurve_Channel();

        public RealTimeCurve()
        {
            InitializeComponent();

            RealTimeCurve_Channel.Channel rtCurveChannel = new RealTimeCurve_Channel.Channel();
            rtCurveChannel = rtCurve_Channel.Create("电压", new Byte[] { 0x12, 0x25 });
            EditorForm.rtCurveChannels.Add(rtCurveChannel);
            chart1.Series.Add(rtCurveChannel.series);

            EditorForm.rtCurveChannelsNameReg("电压");
            EditorForm.rtCurveChannelDelete = rtCurveChannelDelete;
            EditorForm.FormClosing += new FormClosingEventHandler(EditorForm_FormClosing);
        }

        public void rtCurveChannelDelete(Series series)
        {
            chart1.Series.Remove(series);
        }


        public void RT_Curve_WriteData(int channel, double yValue)
        {
            if (!rtCurve_Enable)
                return;
            if (channel > EditorForm.rtCurveChannels.Count - 1)
                return;
            rtCurve_Channel.SeriesWriteData(EditorForm.rtCurveChannels[channel], yValue);
        }

        public void RT_Curve_WriteData(byte[] data, int length)
        {
            if (!rtCurve_Enable)
                return;
            foreach (RealTimeCurve_Channel.Channel ch in EditorForm.rtCurveChannels)
            {
                if (rtCurve_Channel.SeriesWriteData(ch, data, length))
                    return;
            }
        }

        private void toolStripButton_RT_Curve_Cmd_Click(object sender, EventArgs e)
        {
            if (toolStripButton_RT_Curve_Cmd.Text == "启动")
            {
                toolStripButton_RT_Curve_Cmd.BackColor = Color.Tomato;
                toolStripButton_RT_Curve_Cmd.Image = Properties.Resources.关闭;
                toolStripButton_RT_Curve_Cmd.Text = "停止";
                //先清除旧波形
                foreach (RealTimeCurve_Channel.Channel ch in EditorForm.rtCurveChannels)
                {
                    rtCurve_Channel.SeriesClear(ch);
                }
                rtCurve_Channel.SeriesThreadCreate(EditorForm.rtCurveChannels[0]);
                rtCurve_Enable = true;
            }
            else
            {
                toolStripButton_RT_Curve_Cmd.BackColor = Color.LimeGreen;
                toolStripButton_RT_Curve_Cmd.Image = Properties.Resources.开启;
                toolStripButton_RT_Curve_Cmd.Text = "启动";
                rtCurve_Channel.SeriesThreadRelease();
                rtCurve_Enable = false;
            }
        }

        /// <summary>
        /// 新建曲线，这里通过触发右键菜单，进行创建曲线
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton_新建_Click(object sender, EventArgs e)
        {
            contextMenuStrip_创建.Show(Control.MousePosition);
        }

        /// <summary>
        /// 关闭编辑器时，把各个参数写入曲线的参数列表中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            EditorForm.MsgDecodeCfg();
            EditorForm.Hide();
            e.Cancel = true;
        }

        /// <summary>
        /// 打开曲线的参数编辑器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton_设置_Click(object sender, EventArgs e)
        {
            Point point = Control.MousePosition;
            point.X -= EditorForm.Width;
            EditorForm.Location = point;
            EditorForm.Show();
        }

        /// <summary>
        /// 右键新建一条曲线，连贯打开曲线参数编辑器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string name = toolStripTextBox_CurveName.Text;
            if (name == "" || EditorForm.rtCurveChannelCheck(name))
                return;
            RealTimeCurve_Channel.Channel rtCurveChannel = new RealTimeCurve_Channel.Channel();
            rtCurveChannel = rtCurve_Channel.Create(name, null);
            EditorForm.rtCurveChannels.Add(rtCurveChannel);
            chart1.Series.Add(rtCurveChannel.series);
            EditorForm.rtCurveChannelsNameReg(name);
            toolStripButton_设置_Click(null, null);
        }
    }
}
