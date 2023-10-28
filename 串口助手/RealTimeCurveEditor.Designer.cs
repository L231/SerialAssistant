
namespace 串口助手
{
    partial class RealTimeCurveEditor
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.曲线设置 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.toolStrip6 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel6 = new System.Windows.Forms.ToolStripLabel();
            this.CurveName = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel7 = new System.Windows.Forms.ToolStripLabel();
            this.CurveGain = new System.Windows.Forms.ToolStripComboBox();
            this.解析规则 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.ComboBox_MsgDataType = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MsgFlagMSB = new System.Windows.Forms.ToolStripButton();
            this.toolStrip4 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.MsgParamOffset = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.MsgParamByteNum = new System.Windows.Forms.ToolStripComboBox();
            this.toolStrip5 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel5 = new System.Windows.Forms.ToolStripLabel();
            this.MsgHead = new System.Windows.Forms.ToolStripTextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.ComboBox_Channel = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripButton_绘制曲线 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_删除曲线 = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1.SuspendLayout();
            this.曲线设置.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.toolStrip6.SuspendLayout();
            this.解析规则.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.toolStrip3.SuspendLayout();
            this.toolStrip4.SuspendLayout();
            this.toolStrip5.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.曲线设置);
            this.tabControl1.Controls.Add(this.解析规则);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(349, 263);
            this.tabControl1.TabIndex = 4;
            // 
            // 曲线设置
            // 
            this.曲线设置.Controls.Add(this.tableLayoutPanel2);
            this.曲线设置.Location = new System.Drawing.Point(4, 22);
            this.曲线设置.Name = "曲线设置";
            this.曲线设置.Padding = new System.Windows.Forms.Padding(3);
            this.曲线设置.Size = new System.Drawing.Size(341, 237);
            this.曲线设置.TabIndex = 0;
            this.曲线设置.Text = "曲线设置";
            this.曲线设置.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.toolStrip6, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(335, 231);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // toolStrip6
            // 
            this.toolStrip6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip6.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip6.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel6,
            this.CurveName,
            this.toolStripSeparator4,
            this.toolStripLabel7,
            this.CurveGain});
            this.toolStrip6.Location = new System.Drawing.Point(0, 52);
            this.toolStrip6.Name = "toolStrip6";
            this.toolStrip6.Size = new System.Drawing.Size(335, 25);
            this.toolStrip6.TabIndex = 1;
            this.toolStrip6.Text = "toolStrip6";
            // 
            // toolStripLabel6
            // 
            this.toolStripLabel6.Name = "toolStripLabel6";
            this.toolStripLabel6.Size = new System.Drawing.Size(44, 22);
            this.toolStripLabel6.Text = "曲线名";
            // 
            // CurveName
            // 
            this.CurveName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CurveName.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.CurveName.MaxLength = 10;
            this.CurveName.Name = "CurveName";
            this.CurveName.Size = new System.Drawing.Size(80, 25);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel7
            // 
            this.toolStripLabel7.Name = "toolStripLabel7";
            this.toolStripLabel7.Size = new System.Drawing.Size(56, 22);
            this.toolStripLabel7.Text = "放大倍率";
            // 
            // CurveGain
            // 
            this.CurveGain.AutoSize = false;
            this.CurveGain.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CurveGain.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.CurveGain.Items.AddRange(new object[] {
            "×10",
            "×8",
            "×4",
            "×2",
            "×1",
            "÷2",
            "÷4",
            "÷8",
            "÷10"});
            this.CurveGain.Name = "CurveGain";
            this.CurveGain.Size = new System.Drawing.Size(50, 25);
            this.CurveGain.SelectedIndexChanged += new System.EventHandler(this.CurveGain_SelectedIndexChanged);
            // 
            // 解析规则
            // 
            this.解析规则.Controls.Add(this.tableLayoutPanel1);
            this.解析规则.Location = new System.Drawing.Point(4, 22);
            this.解析规则.Name = "解析规则";
            this.解析规则.Padding = new System.Windows.Forms.Padding(3);
            this.解析规则.Size = new System.Drawing.Size(341, 237);
            this.解析规则.TabIndex = 1;
            this.解析规则.Text = "解析规则";
            this.解析规则.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.toolStrip3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.toolStrip4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.toolStrip5, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(335, 231);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // toolStrip3
            // 
            this.toolStrip3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip3.ImageScalingSize = new System.Drawing.Size(27, 27);
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2,
            this.ComboBox_MsgDataType,
            this.toolStripSeparator1,
            this.MsgFlagMSB});
            this.toolStrip3.Location = new System.Drawing.Point(0, 50);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(335, 30);
            this.toolStrip3.TabIndex = 0;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(56, 27);
            this.toolStripLabel2.Text = "数据类型";
            // 
            // ComboBox_MsgDataType
            // 
            this.ComboBox_MsgDataType.AutoSize = false;
            this.ComboBox_MsgDataType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox_MsgDataType.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.ComboBox_MsgDataType.Items.AddRange(new object[] {
            "整型",
            "浮点数",
            "字符串"});
            this.ComboBox_MsgDataType.Name = "ComboBox_MsgDataType";
            this.ComboBox_MsgDataType.Size = new System.Drawing.Size(60, 25);
            this.ComboBox_MsgDataType.ToolTipText = "HEX：整型、浮点数。ASCII：字符串";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 30);
            // 
            // MsgFlagMSB
            // 
            this.MsgFlagMSB.AutoSize = false;
            this.MsgFlagMSB.BackColor = System.Drawing.Color.Transparent;
            this.MsgFlagMSB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MsgFlagMSB.Image = global::串口助手.Properties.Resources.MSB;
            this.MsgFlagMSB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MsgFlagMSB.Margin = new System.Windows.Forms.Padding(0);
            this.MsgFlagMSB.Name = "MsgFlagMSB";
            this.MsgFlagMSB.Size = new System.Drawing.Size(30, 30);
            this.MsgFlagMSB.Text = "MSB";
            this.MsgFlagMSB.ToolTipText = "低位在前";
            this.MsgFlagMSB.Click += new System.EventHandler(this.MsgFlagMSB_Click);
            // 
            // toolStrip4
            // 
            this.toolStrip4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip4.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel3,
            this.MsgParamOffset,
            this.toolStripSeparator2,
            this.toolStripLabel4,
            this.MsgParamByteNum});
            this.toolStrip4.Location = new System.Drawing.Point(0, 95);
            this.toolStrip4.Name = "toolStrip4";
            this.toolStrip4.Size = new System.Drawing.Size(335, 25);
            this.toolStrip4.TabIndex = 1;
            this.toolStrip4.Text = "toolStrip4";
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(56, 22);
            this.toolStripLabel3.Text = "报文位置";
            // 
            // MsgParamOffset
            // 
            this.MsgParamOffset.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MsgParamOffset.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.MsgParamOffset.MaxLength = 2;
            this.MsgParamOffset.Name = "MsgParamOffset";
            this.MsgParamOffset.Size = new System.Drawing.Size(25, 25);
            this.MsgParamOffset.Text = "0";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Margin = new System.Windows.Forms.Padding(25, 0, 2, 0);
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(44, 22);
            this.toolStripLabel4.Text = "字节数";
            // 
            // MsgParamByteNum
            // 
            this.MsgParamByteNum.AutoSize = false;
            this.MsgParamByteNum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MsgParamByteNum.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.MsgParamByteNum.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.MsgParamByteNum.Name = "MsgParamByteNum";
            this.MsgParamByteNum.Size = new System.Drawing.Size(40, 25);
            this.MsgParamByteNum.ToolTipText = "仅供HEX数据使用";
            // 
            // toolStrip5
            // 
            this.toolStrip5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip5.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip5.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel5,
            this.MsgHead});
            this.toolStrip5.Location = new System.Drawing.Point(0, 15);
            this.toolStrip5.Name = "toolStrip5";
            this.toolStrip5.Size = new System.Drawing.Size(335, 25);
            this.toolStrip5.TabIndex = 2;
            this.toolStrip5.Text = "toolStrip5";
            // 
            // toolStripLabel5
            // 
            this.toolStripLabel5.Name = "toolStripLabel5";
            this.toolStripLabel5.Size = new System.Drawing.Size(32, 22);
            this.toolStripLabel5.Text = "报头";
            // 
            // MsgHead
            // 
            this.MsgHead.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MsgHead.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.MsgHead.MaxLength = 20;
            this.MsgHead.Name = "MsgHead";
            this.MsgHead.Size = new System.Drawing.Size(100, 25);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(23, 23);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.ComboBox_Channel,
            this.toolStripButton_绘制曲线,
            this.toolStripSeparator3,
            this.toolStripButton_删除曲线});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Margin = new System.Windows.Forms.Padding(3);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(349, 30);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(32, 27);
            this.toolStripLabel1.Text = "曲线";
            // 
            // ComboBox_Channel
            // 
            this.ComboBox_Channel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox_Channel.DropDownWidth = 150;
            this.ComboBox_Channel.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.ComboBox_Channel.Name = "ComboBox_Channel";
            this.ComboBox_Channel.Size = new System.Drawing.Size(80, 30);
            this.ComboBox_Channel.SelectedIndexChanged += new System.EventHandler(this.ComboBox_Channel_SelectedIndexChanged);
            // 
            // toolStripButton_绘制曲线
            // 
            this.toolStripButton_绘制曲线.BackColor = System.Drawing.Color.Tomato;
            this.toolStripButton_绘制曲线.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_绘制曲线.Image = global::串口助手.Properties.Resources.关闭;
            this.toolStripButton_绘制曲线.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_绘制曲线.Name = "toolStripButton_绘制曲线";
            this.toolStripButton_绘制曲线.Size = new System.Drawing.Size(27, 27);
            this.toolStripButton_绘制曲线.Text = "toolStripButton2";
            this.toolStripButton_绘制曲线.ToolTipText = "启动/暂停绘制当前曲线";
            this.toolStripButton_绘制曲线.Click += new System.EventHandler(this.toolStripButton_绘制曲线_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 30);
            // 
            // toolStripButton_删除曲线
            // 
            this.toolStripButton_删除曲线.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_删除曲线.Image = global::串口助手.Properties.Resources.删除;
            this.toolStripButton_删除曲线.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_删除曲线.Name = "toolStripButton_删除曲线";
            this.toolStripButton_删除曲线.Size = new System.Drawing.Size(27, 27);
            this.toolStripButton_删除曲线.Text = "toolStripButton3";
            this.toolStripButton_删除曲线.ToolTipText = "删除当前曲线";
            this.toolStripButton_删除曲线.Click += new System.EventHandler(this.toolStripButton_删除曲线_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 30);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(349, 263);
            this.panel1.TabIndex = 7;
            // 
            // RealTimeCurveEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 293);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "RealTimeCurveEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "RealTimeCurveEditor";
            this.TopMost = true;
            this.tabControl1.ResumeLayout(false);
            this.曲线设置.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.toolStrip6.ResumeLayout(false);
            this.toolStrip6.PerformLayout();
            this.解析规则.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.toolStrip4.ResumeLayout(false);
            this.toolStrip4.PerformLayout();
            this.toolStrip5.ResumeLayout(false);
            this.toolStrip5.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage 曲线设置;
        private System.Windows.Forms.TabPage 解析规则;
        private System.Windows.Forms.ToolStrip toolStrip4;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripTextBox MsgParamOffset;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripComboBox MsgParamByteNum;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripComboBox ComboBox_MsgDataType;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton MsgFlagMSB;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox ComboBox_Channel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStrip toolStrip5;
        private System.Windows.Forms.ToolStripLabel toolStripLabel5;
        private System.Windows.Forms.ToolStripTextBox MsgHead;
        private System.Windows.Forms.ToolStrip toolStrip6;
        private System.Windows.Forms.ToolStripLabel toolStripLabel6;
        private System.Windows.Forms.ToolStripTextBox CurveName;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripLabel toolStripLabel7;
        private System.Windows.Forms.ToolStripComboBox CurveGain;
        private System.Windows.Forms.ToolStripButton toolStripButton_绘制曲线;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripButton_删除曲线;
    }
}