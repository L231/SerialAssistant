
namespace 串口助手
{
    partial class ChannelForm
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
            this.ChannelList_toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.Channel_Delete = new System.Windows.Forms.ToolStripButton();
            this.Channel_Name = new System.Windows.Forms.ToolStripTextBox();
            this.Channel_COM = new System.Windows.Forms.ToolStripComboBox();
            this.Channel_BaudRate_or_IP = new System.Windows.Forms.ToolStripComboBox();
            this.Channel_TCPPort = new System.Windows.Forms.ToolStripTextBox();
            this.Channel_Connect = new System.Windows.Forms.ToolStripButton();
            this.Channel_Hex = new System.Windows.Forms.ToolStripButton();
            this.Channel_MsgEnd = new System.Windows.Forms.ToolStripComboBox();
            this.ChannelList_toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ChannelList_toolStrip1
            // 
            this.ChannelList_toolStrip1.AllowItemReorder = true;
            this.ChannelList_toolStrip1.ImageScalingSize = new System.Drawing.Size(21, 21);
            this.ChannelList_toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Channel_Delete,
            this.Channel_Name,
            this.Channel_COM,
            this.Channel_BaudRate_or_IP,
            this.Channel_TCPPort,
            this.Channel_Connect,
            this.Channel_Hex,
            this.Channel_MsgEnd});
            this.ChannelList_toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.ChannelList_toolStrip1.Name = "ChannelList_toolStrip1";
            this.ChannelList_toolStrip1.Size = new System.Drawing.Size(800, 28);
            this.ChannelList_toolStrip1.TabIndex = 1;
            // 
            // Channel_Delete
            // 
            this.Channel_Delete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Channel_Delete.Image = global::串口助手.Properties.Resources.删除;
            this.Channel_Delete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Channel_Delete.Name = "Channel_Delete";
            this.Channel_Delete.Size = new System.Drawing.Size(25, 25);
            this.Channel_Delete.Text = "toolStripButton2";
            this.Channel_Delete.ToolTipText = "删除通道";
            this.Channel_Delete.Click += new System.EventHandler(this.Channel_Delete_Click);
            // 
            // Channel_Name
            // 
            this.Channel_Name.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Channel_Name.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.Channel_Name.Name = "Channel_Name";
            this.Channel_Name.Size = new System.Drawing.Size(50, 28);
            this.Channel_Name.ToolTipText = "通道名字，通信时用来片选";
            // 
            // Channel_COM
            // 
            this.Channel_COM.DropDownWidth = 300;
            this.Channel_COM.Name = "Channel_COM";
            this.Channel_COM.Size = new System.Drawing.Size(200, 28);
            this.Channel_COM.ToolTipText = "设备端口号";
            this.Channel_COM.DropDown += new System.EventHandler(this.Channel_COM_DropDown);
            // 
            // Channel_BaudRate_or_IP
            // 
            this.Channel_BaudRate_or_IP.Items.AddRange(new object[] {
            "1200",
            "4800",
            "9600",
            "14400",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.Channel_BaudRate_or_IP.Name = "Channel_BaudRate_or_IP";
            this.Channel_BaudRate_or_IP.Size = new System.Drawing.Size(110, 28);
            this.Channel_BaudRate_or_IP.ToolTipText = "波特率 / IP地址";
            // 
            // Channel_TCPPort
            // 
            this.Channel_TCPPort.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.Channel_TCPPort.Name = "Channel_TCPPort";
            this.Channel_TCPPort.Size = new System.Drawing.Size(35, 28);
            this.Channel_TCPPort.ToolTipText = "TCP端口号";
            // 
            // Channel_Connect
            // 
            this.Channel_Connect.BackColor = System.Drawing.Color.LimeGreen;
            this.Channel_Connect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Channel_Connect.Image = global::串口助手.Properties.Resources.开启;
            this.Channel_Connect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Channel_Connect.Margin = new System.Windows.Forms.Padding(1, 1, 1, 2);
            this.Channel_Connect.Name = "Channel_Connect";
            this.Channel_Connect.Size = new System.Drawing.Size(25, 25);
            this.Channel_Connect.Text = "开启";
            this.Channel_Connect.ToolTipText = "开启或关闭通道";
            this.Channel_Connect.Click += new System.EventHandler(this.Channel_Button1_Click);
            // 
            // Channel_Hex
            // 
            this.Channel_Hex.BackColor = System.Drawing.Color.Transparent;
            this.Channel_Hex.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Channel_Hex.Image = global::串口助手.Properties.Resources.hex;
            this.Channel_Hex.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Channel_Hex.Margin = new System.Windows.Forms.Padding(1, 1, 1, 2);
            this.Channel_Hex.Name = "Channel_Hex";
            this.Channel_Hex.Size = new System.Drawing.Size(25, 25);
            this.Channel_Hex.Text = "ASCII";
            this.Channel_Hex.ToolTipText = "设备通信格式是否为HEX";
            this.Channel_Hex.Click += new System.EventHandler(this.Channel_Hex_Click);
            // 
            // Channel_MsgEnd
            // 
            this.Channel_MsgEnd.AutoSize = false;
            this.Channel_MsgEnd.DropDownWidth = 80;
            this.Channel_MsgEnd.Items.AddRange(new object[] {
            "无",
            "0A",
            "0A0D",
            "0D",
            "0D0A",
            "CS",
            "ModBus"});
            this.Channel_MsgEnd.Name = "Channel_MsgEnd";
            this.Channel_MsgEnd.Size = new System.Drawing.Size(75, 25);
            this.Channel_MsgEnd.Text = "0A";
            this.Channel_MsgEnd.ToolTipText = "报文的结束符";
            // 
            // ChannelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 28);
            this.Controls.Add(this.ChannelList_toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ChannelForm";
            this.Text = "ChannelForm1";
            this.ChannelList_toolStrip1.ResumeLayout(false);
            this.ChannelList_toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip ChannelList_toolStrip1;
        private System.Windows.Forms.ToolStripButton Channel_Delete;
        private System.Windows.Forms.ToolStripComboBox Channel_COM;
        private System.Windows.Forms.ToolStripComboBox Channel_BaudRate_or_IP;
        private System.Windows.Forms.ToolStripTextBox Channel_TCPPort;
        private System.Windows.Forms.ToolStripButton Channel_Connect;
        private System.Windows.Forms.ToolStripTextBox Channel_Name;
        private System.Windows.Forms.ToolStripButton Channel_Hex;
        private System.Windows.Forms.ToolStripComboBox Channel_MsgEnd;
    }
}