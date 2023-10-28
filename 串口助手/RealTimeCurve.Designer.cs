
namespace 串口助手
{
    partial class RealTimeCurve
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_新建 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_RT_Curve_Cmd = new System.Windows.Forms.ToolStripButton();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.toolStripButton_设置 = new System.Windows.Forms.ToolStripButton();
            this.contextMenuStrip_创建 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripTextBox_CurveName = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.contextMenuStrip_创建.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AllowItemReorder = true;
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Right;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(21, 21);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_新建,
            this.toolStripSeparator1,
            this.toolStripButton_RT_Curve_Cmd,
            this.toolStripButton_设置});
            this.toolStrip1.Location = new System.Drawing.Point(428, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(28, 290);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton_新建
            // 
            this.toolStripButton_新建.AutoSize = false;
            this.toolStripButton_新建.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_新建.Image = global::串口助手.Properties.Resources.新建;
            this.toolStripButton_新建.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_新建.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.toolStripButton_新建.Name = "toolStripButton_新建";
            this.toolStripButton_新建.Size = new System.Drawing.Size(25, 25);
            this.toolStripButton_新建.Text = "toolStripButton1";
            this.toolStripButton_新建.ToolTipText = "新建一条曲线";
            this.toolStripButton_新建.Click += new System.EventHandler(this.toolStripButton_新建_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(26, 6);
            // 
            // toolStripButton_RT_Curve_Cmd
            // 
            this.toolStripButton_RT_Curve_Cmd.AutoSize = false;
            this.toolStripButton_RT_Curve_Cmd.BackColor = System.Drawing.Color.LimeGreen;
            this.toolStripButton_RT_Curve_Cmd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_RT_Curve_Cmd.Image = global::串口助手.Properties.Resources.开启;
            this.toolStripButton_RT_Curve_Cmd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_RT_Curve_Cmd.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.toolStripButton_RT_Curve_Cmd.Name = "toolStripButton_RT_Curve_Cmd";
            this.toolStripButton_RT_Curve_Cmd.Size = new System.Drawing.Size(25, 25);
            this.toolStripButton_RT_Curve_Cmd.Text = "启动";
            this.toolStripButton_RT_Curve_Cmd.Click += new System.EventHandler(this.toolStripButton_RT_Curve_Cmd_Click);
            // 
            // chart1
            // 
            chartArea1.AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea1.AxisX.MajorTickMark.TickMarkStyle = System.Windows.Forms.DataVisualization.Charting.TickMarkStyle.None;
            chartArea1.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea1.AxisY.MajorTickMark.TickMarkStyle = System.Windows.Forms.DataVisualization.Charting.TickMarkStyle.None;
            chartArea1.CursorX.IsUserEnabled = true;
            chartArea1.CursorX.IsUserSelectionEnabled = true;
            chartArea1.CursorY.IsUserEnabled = true;
            chartArea1.CursorY.IsUserSelectionEnabled = true;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(0, 0);
            this.chart1.Margin = new System.Windows.Forms.Padding(0);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(428, 290);
            this.chart1.TabIndex = 1;
            this.chart1.Text = "chart1";
            // 
            // toolStripButton_设置
            // 
            this.toolStripButton_设置.AutoSize = false;
            this.toolStripButton_设置.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_设置.Image = global::串口助手.Properties.Resources.设置;
            this.toolStripButton_设置.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_设置.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.toolStripButton_设置.Name = "toolStripButton_设置";
            this.toolStripButton_设置.Size = new System.Drawing.Size(25, 25);
            this.toolStripButton_设置.Text = "toolStripButton1";
            this.toolStripButton_设置.Click += new System.EventHandler(this.toolStripButton_设置_Click);
            // 
            // contextMenuStrip_创建
            // 
            this.contextMenuStrip_创建.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox_CurveName,
            this.toolStripMenuItem1});
            this.contextMenuStrip_创建.Name = "contextMenuStrip_创建";
            this.contextMenuStrip_创建.Size = new System.Drawing.Size(181, 73);
            // 
            // toolStripTextBox_CurveName
            // 
            this.toolStripTextBox_CurveName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toolStripTextBox_CurveName.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.toolStripTextBox_CurveName.MaxLength = 10;
            this.toolStripTextBox_CurveName.Name = "toolStripTextBox_CurveName";
            this.toolStripTextBox_CurveName.Size = new System.Drawing.Size(80, 23);
            this.toolStripTextBox_CurveName.ToolTipText = "请输入曲线名称";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem1.Text = "创建新曲线";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // RealTimeCurve
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(456, 290);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RealTimeCurve";
            this.Text = "RealTimeCurve";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.contextMenuStrip_创建.ResumeLayout(false);
            this.contextMenuStrip_创建.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.ToolStripButton toolStripButton_RT_Curve_Cmd;
        private System.Windows.Forms.ToolStripButton toolStripButton_新建;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton_设置;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_创建;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox_CurveName;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    }
}