
namespace 串口助手
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Label_Status = new System.Windows.Forms.Label();
            this.timer_Send = new System.Windows.Forms.Timer(this.components);
            this.toolStrip_LeftTop = new System.Windows.Forms.ToolStrip();
            this.toolStripComboBox_SerialPort = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripComboBox_BaudRate = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripTextBox_TCPPort = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButton_Master = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_RecClear = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_SaveSet = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownButton_Set = new System.Windows.Forms.ToolStripDropDownButton();
            this.指令规则清空ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox自动换行定时器周期 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.加载发送列表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新建ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.另存为ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox_TxListNum = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.MasterMsgEnd = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripComboBox_Convert = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripButton_help = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_OnTop = new System.Windows.Forms.ToolStripButton();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.BottomToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.TopToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.RightToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.LeftToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.ContentPanel = new System.Windows.Forms.ToolStripContentPanel();
            this.toolStrip_Left = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton_TxHEX = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton_RxHEX = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_RxAutoNewline = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Timestamp = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_log = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_Fold = new System.Windows.Forms.ToolStripButton();
            this.splitContainer_Master = new System.Windows.Forms.SplitContainer();
            this.TextBox_Tx = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_Tx = new System.Windows.Forms.Button();
            this.checkBox_TimSend = new System.Windows.Forms.CheckBox();
            this.NumUpDown_TimSend = new System.Windows.Forms.NumericUpDown();
            this.richTextBox_Rx = new System.Windows.Forms.RichTextBox();
            this.tabControl_TxList = new System.Windows.Forms.TabControl();
            this.tabPage_TxList = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tabPage_TxListSimple = new System.Windows.Forms.TabPage();
            this.splitContainer_TxListSimple = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxTxListName = new System.Windows.Forms.TextBox();
            this.comboBoxTxListASCII = new System.Windows.Forms.ComboBox();
            this.textBoxTxListMsg = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonTxListInsert = new System.Windows.Forms.Button();
            this.buttonTxListNew = new System.Windows.Forms.Button();
            this.buttonTxListDel = new System.Windows.Forms.Button();
            this.toolStrip_TableTX = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_TableTx = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel_TableTx = new System.Windows.Forms.ToolStripLabel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.textBox_SuperMsgRxShow = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel_SuperMsg = new System.Windows.Forms.FlowLayoutPanel();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown_Read = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_Write = new System.Windows.Forms.NumericUpDown();
            this.progressBar_Firmware = new System.Windows.Forms.ProgressBar();
            this.richTextBox_HexShow = new System.Windows.Forms.RichTextBox();
            this.button_Erase = new System.Windows.Forms.Button();
            this.button_Run = new System.Windows.Forms.Button();
            this.button_Uploading = new System.Windows.Forms.Button();
            this.button_Download = new System.Windows.Forms.Button();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripComboBox_LoaderFile = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripButton_OpenFile = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripComboBox_MCU = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripButton_BootOn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel_BootLinkStatus = new System.Windows.Forms.ToolStripLabel();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel_Channel = new System.Windows.Forms.FlowLayoutPanel();
            this.ChannelList_toolStrip0 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.openFileDialog_Download = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog_Firmware = new System.Windows.Forms.SaveFileDialog();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.toolTip_TxList = new System.Windows.Forms.ToolTip(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolStrip_LeftTop.SuspendLayout();
            this.toolStrip_Left.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_Master)).BeginInit();
            this.splitContainer_Master.Panel1.SuspendLayout();
            this.splitContainer_Master.Panel2.SuspendLayout();
            this.splitContainer_Master.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumUpDown_TimSend)).BeginInit();
            this.tabControl_TxList.SuspendLayout();
            this.tabPage_TxList.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabPage_TxListSimple.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_TxListSimple)).BeginInit();
            this.splitContainer_TxListSimple.Panel1.SuspendLayout();
            this.splitContainer_TxListSimple.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.toolStrip_TableTX.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.toolStrip3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Read)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Write)).BeginInit();
            this.toolStrip2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.ChannelList_toolStrip0.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // Label_Status
            // 
            this.Label_Status.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Label_Status.AutoSize = true;
            this.Label_Status.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Label_Status.Location = new System.Drawing.Point(3, 399);
            this.Label_Status.Name = "Label_Status";
            this.Label_Status.Size = new System.Drawing.Size(46, 17);
            this.Label_Status.TabIndex = 16;
            this.Label_Status.Text = "CLOSE";
            // 
            // timer_Send
            // 
            this.timer_Send.Tick += new System.EventHandler(this.timer_Send_Tick);
            // 
            // toolStrip_LeftTop
            // 
            this.toolStrip_LeftTop.AllowItemReorder = true;
            this.toolStrip_LeftTop.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip_LeftTop.ImageScalingSize = new System.Drawing.Size(21, 21);
            this.toolStrip_LeftTop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripComboBox_SerialPort,
            this.toolStripComboBox_BaudRate,
            this.toolStripTextBox_TCPPort,
            this.toolStripButton_Master,
            this.toolStripButton_RecClear,
            this.toolStripSeparator4,
            this.toolStripButton_SaveSet,
            this.toolStripDropDownButton_Set,
            this.toolStripComboBox_Convert,
            this.toolStripButton_help,
            this.toolStripButton_OnTop});
            this.toolStrip_LeftTop.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip_LeftTop.Location = new System.Drawing.Point(0, 0);
            this.toolStrip_LeftTop.Name = "toolStrip_LeftTop";
            this.toolStrip_LeftTop.Size = new System.Drawing.Size(764, 28);
            this.toolStrip_LeftTop.TabIndex = 25;
            this.toolStrip_LeftTop.Text = "toolStrip1";
            // 
            // toolStripComboBox_SerialPort
            // 
            this.toolStripComboBox_SerialPort.DropDownWidth = 300;
            this.toolStripComboBox_SerialPort.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.toolStripComboBox_SerialPort.Name = "toolStripComboBox_SerialPort";
            this.toolStripComboBox_SerialPort.Size = new System.Drawing.Size(80, 28);
            this.toolStripComboBox_SerialPort.DropDown += new System.EventHandler(this.toolStripComboBox_SerialPort_DropDown);
            // 
            // toolStripComboBox_BaudRate
            // 
            this.toolStripComboBox_BaudRate.DropDownWidth = 75;
            this.toolStripComboBox_BaudRate.IntegralHeight = false;
            this.toolStripComboBox_BaudRate.Items.AddRange(new object[] {
            "1200",
            "4800",
            "9600",
            "14400",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.toolStripComboBox_BaudRate.Name = "toolStripComboBox_BaudRate";
            this.toolStripComboBox_BaudRate.Size = new System.Drawing.Size(110, 28);
            this.toolStripComboBox_BaudRate.ToolTipText = "波特率 / IP地址，可自由输入";
            // 
            // toolStripTextBox_TCPPort
            // 
            this.toolStripTextBox_TCPPort.Name = "toolStripTextBox_TCPPort";
            this.toolStripTextBox_TCPPort.Size = new System.Drawing.Size(35, 28);
            this.toolStripTextBox_TCPPort.ToolTipText = "TCP端口号";
            // 
            // toolStripButton_Master
            // 
            this.toolStripButton_Master.BackColor = System.Drawing.Color.LimeGreen;
            this.toolStripButton_Master.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Master.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_Master.Image")));
            this.toolStripButton_Master.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Master.Name = "toolStripButton_Master";
            this.toolStripButton_Master.Size = new System.Drawing.Size(25, 25);
            this.toolStripButton_Master.Text = "开启";
            this.toolStripButton_Master.Click += new System.EventHandler(this.toolStripButton_Master_Click);
            // 
            // toolStripButton_RecClear
            // 
            this.toolStripButton_RecClear.BackColor = System.Drawing.Color.Transparent;
            this.toolStripButton_RecClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_RecClear.Enabled = false;
            this.toolStripButton_RecClear.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_RecClear.Image")));
            this.toolStripButton_RecClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_RecClear.Name = "toolStripButton_RecClear";
            this.toolStripButton_RecClear.Size = new System.Drawing.Size(25, 25);
            this.toolStripButton_RecClear.Text = "清除";
            this.toolStripButton_RecClear.Click += new System.EventHandler(this.toolStripButton_RecClear_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.AutoSize = false;
            this.toolStripSeparator4.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(10, 28);
            // 
            // toolStripButton_SaveSet
            // 
            this.toolStripButton_SaveSet.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_SaveSet.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_SaveSet.Image")));
            this.toolStripButton_SaveSet.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_SaveSet.Margin = new System.Windows.Forms.Padding(1, 1, 1, 2);
            this.toolStripButton_SaveSet.Name = "toolStripButton_SaveSet";
            this.toolStripButton_SaveSet.Size = new System.Drawing.Size(25, 25);
            this.toolStripButton_SaveSet.Text = "保存发送框";
            this.toolStripButton_SaveSet.ToolTipText = "保存所有配置";
            this.toolStripButton_SaveSet.MouseDown += new System.Windows.Forms.MouseEventHandler(this.toolStripButton_SaveSet_MouseDown);
            // 
            // toolStripDropDownButton_Set
            // 
            this.toolStripDropDownButton_Set.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton_Set.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.指令规则清空ToolStripMenuItem,
            this.toolStripTextBox自动换行定时器周期,
            this.toolStripSeparator6,
            this.加载发送列表ToolStripMenuItem,
            this.新建ToolStripMenuItem,
            this.另存为ToolStripMenuItem,
            this.toolStripTextBox_TxListNum,
            this.toolStripSeparator5,
            this.MasterMsgEnd});
            this.toolStripDropDownButton_Set.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton_Set.Image")));
            this.toolStripDropDownButton_Set.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton_Set.Name = "toolStripDropDownButton_Set";
            this.toolStripDropDownButton_Set.Size = new System.Drawing.Size(34, 25);
            this.toolStripDropDownButton_Set.Text = "设置";
            this.toolStripDropDownButton_Set.ToolTipText = "系统设置";
            // 
            // 指令规则清空ToolStripMenuItem
            // 
            this.指令规则清空ToolStripMenuItem.Name = "指令规则清空ToolStripMenuItem";
            this.指令规则清空ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.指令规则清空ToolStripMenuItem.Text = "清空指令规则";
            this.指令规则清空ToolStripMenuItem.Click += new System.EventHandler(this.指令规则清空ToolStripMenuItem_Click);
            // 
            // toolStripTextBox自动换行定时器周期
            // 
            this.toolStripTextBox自动换行定时器周期.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toolStripTextBox自动换行定时器周期.MaxLength = 3;
            this.toolStripTextBox自动换行定时器周期.Name = "toolStripTextBox自动换行定时器周期";
            this.toolStripTextBox自动换行定时器周期.Size = new System.Drawing.Size(50, 23);
            this.toolStripTextBox自动换行定时器周期.ToolTipText = "收到数据后，自动换行的时间";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(145, 6);
            // 
            // 加载发送列表ToolStripMenuItem
            // 
            this.加载发送列表ToolStripMenuItem.Name = "加载发送列表ToolStripMenuItem";
            this.加载发送列表ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.加载发送列表ToolStripMenuItem.Text = "加载发送列表";
            this.加载发送列表ToolStripMenuItem.Click += new System.EventHandler(this.加载发送列表ToolStripMenuItem_Click);
            // 
            // 新建ToolStripMenuItem
            // 
            this.新建ToolStripMenuItem.Name = "新建ToolStripMenuItem";
            this.新建ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.新建ToolStripMenuItem.Text = "新建";
            this.新建ToolStripMenuItem.ToolTipText = "新建发送列表";
            this.新建ToolStripMenuItem.Click += new System.EventHandler(this.新建ToolStripMenuItem_Click);
            // 
            // 另存为ToolStripMenuItem
            // 
            this.另存为ToolStripMenuItem.Name = "另存为ToolStripMenuItem";
            this.另存为ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.另存为ToolStripMenuItem.Text = "另存为";
            this.另存为ToolStripMenuItem.ToolTipText = "发送列表另存为";
            this.另存为ToolStripMenuItem.Click += new System.EventHandler(this.另存为ToolStripMenuItem_Click);
            // 
            // toolStripTextBox_TxListNum
            // 
            this.toolStripTextBox_TxListNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toolStripTextBox_TxListNum.MaxLength = 3;
            this.toolStripTextBox_TxListNum.Name = "toolStripTextBox_TxListNum";
            this.toolStripTextBox_TxListNum.Size = new System.Drawing.Size(50, 23);
            this.toolStripTextBox_TxListNum.ToolTipText = "发送列表个数，最大100";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(145, 6);
            // 
            // MasterMsgEnd
            // 
            this.MasterMsgEnd.AutoSize = false;
            this.MasterMsgEnd.DropDownWidth = 50;
            this.MasterMsgEnd.Items.AddRange(new object[] {
            "无",
            "CS",
            "0A",
            "0A0D",
            "0D",
            "0D0A"});
            this.MasterMsgEnd.Name = "MasterMsgEnd";
            this.MasterMsgEnd.Size = new System.Drawing.Size(55, 25);
            this.MasterMsgEnd.Text = "无";
            this.MasterMsgEnd.ToolTipText = "主设备的报尾";
            // 
            // toolStripComboBox_Convert
            // 
            this.toolStripComboBox_Convert.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.toolStripComboBox_Convert.DropDownWidth = 250;
            this.toolStripComboBox_Convert.Name = "toolStripComboBox_Convert";
            this.toolStripComboBox_Convert.Size = new System.Drawing.Size(100, 28);
            this.toolStripComboBox_Convert.ToolTipText = "[类型转换]，前缀：S 浮点数，X 16进制";
            this.toolStripComboBox_Convert.TextUpdate += new System.EventHandler(this.toolStripComboBox_Convert_TextUpdate);
            // 
            // toolStripButton_help
            // 
            this.toolStripButton_help.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_help.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_help.Image")));
            this.toolStripButton_help.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_help.Margin = new System.Windows.Forms.Padding(1, 1, 1, 2);
            this.toolStripButton_help.Name = "toolStripButton_help";
            this.toolStripButton_help.Size = new System.Drawing.Size(25, 25);
            this.toolStripButton_help.Text = "help";
            this.toolStripButton_help.MouseDown += new System.Windows.Forms.MouseEventHandler(this.toolStripButton_help_MouseDown);
            // 
            // toolStripButton_OnTop
            // 
            this.toolStripButton_OnTop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_OnTop.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_OnTop.Image")));
            this.toolStripButton_OnTop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_OnTop.Name = "toolStripButton_OnTop";
            this.toolStripButton_OnTop.Size = new System.Drawing.Size(25, 25);
            this.toolStripButton_OnTop.Text = "置顶";
            this.toolStripButton_OnTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.toolStripButton_OnTop_MouseDown);
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.DropDownWidth = 75;
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(75, 25);
            // 
            // BottomToolStripPanel
            // 
            this.BottomToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.BottomToolStripPanel.Name = "BottomToolStripPanel";
            this.BottomToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.BottomToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.BottomToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // TopToolStripPanel
            // 
            this.TopToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.TopToolStripPanel.Name = "TopToolStripPanel";
            this.TopToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.TopToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.TopToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // RightToolStripPanel
            // 
            this.RightToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.RightToolStripPanel.Name = "RightToolStripPanel";
            this.RightToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.RightToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.RightToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // LeftToolStripPanel
            // 
            this.LeftToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftToolStripPanel.Name = "LeftToolStripPanel";
            this.LeftToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.LeftToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.LeftToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // ContentPanel
            // 
            this.ContentPanel.Size = new System.Drawing.Size(775, 445);
            // 
            // toolStrip_Left
            // 
            this.toolStrip_Left.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolStrip_Left.ImageScalingSize = new System.Drawing.Size(27, 27);
            this.toolStrip_Left.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripButton_TxHEX,
            this.toolStripSeparator1,
            this.toolStripLabel2,
            this.toolStripButton_RxHEX,
            this.toolStripButton_RxAutoNewline,
            this.toolStripButton_Timestamp,
            this.toolStripButton_log,
            this.toolStripSeparator7,
            this.toolStripButton_Fold});
            this.toolStrip_Left.Location = new System.Drawing.Point(3, 3);
            this.toolStrip_Left.Name = "toolStrip_Left";
            this.toolStrip_Left.Size = new System.Drawing.Size(32, 424);
            this.toolStrip_Left.TabIndex = 0;
            this.toolStrip_Left.Text = "toolStrip2";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.BackColor = System.Drawing.Color.Transparent;
            this.toolStripLabel1.Font = new System.Drawing.Font("Courier New", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.ForeColor = System.Drawing.Color.Black;
            this.toolStripLabel1.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(29, 16);
            this.toolStripLabel1.Text = "Tx";
            this.toolStripLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripLabel1.ToolTipText = "单击显示发送";
            this.toolStripLabel1.Click += new System.EventHandler(this.toolStripLabel1_Click);
            // 
            // toolStripButton_TxHEX
            // 
            this.toolStripButton_TxHEX.AutoSize = false;
            this.toolStripButton_TxHEX.BackColor = System.Drawing.Color.Transparent;
            this.toolStripButton_TxHEX.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_TxHEX.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_TxHEX.Image")));
            this.toolStripButton_TxHEX.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_TxHEX.Name = "toolStripButton_TxHEX";
            this.toolStripButton_TxHEX.Size = new System.Drawing.Size(30, 30);
            this.toolStripButton_TxHEX.Text = "ASCII";
            this.toolStripButton_TxHEX.Click += new System.EventHandler(this.toolStripButton_HEX_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Margin = new System.Windows.Forms.Padding(0, 2, 0, 5);
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(29, 6);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Font = new System.Drawing.Font("Courier New", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel2.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(29, 16);
            this.toolStripLabel2.Text = "Rx";
            this.toolStripLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripButton_RxHEX
            // 
            this.toolStripButton_RxHEX.AutoSize = false;
            this.toolStripButton_RxHEX.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_RxHEX.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_RxHEX.Image")));
            this.toolStripButton_RxHEX.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_RxHEX.Name = "toolStripButton_RxHEX";
            this.toolStripButton_RxHEX.Size = new System.Drawing.Size(30, 30);
            this.toolStripButton_RxHEX.Text = "ASCII";
            this.toolStripButton_RxHEX.Click += new System.EventHandler(this.toolStripButton_HEX_Click);
            // 
            // toolStripButton_RxAutoNewline
            // 
            this.toolStripButton_RxAutoNewline.AutoSize = false;
            this.toolStripButton_RxAutoNewline.BackColor = System.Drawing.Color.Transparent;
            this.toolStripButton_RxAutoNewline.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_RxAutoNewline.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_RxAutoNewline.Image")));
            this.toolStripButton_RxAutoNewline.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_RxAutoNewline.Name = "toolStripButton_RxAutoNewline";
            this.toolStripButton_RxAutoNewline.Size = new System.Drawing.Size(30, 30);
            this.toolStripButton_RxAutoNewline.Text = "OFF";
            this.toolStripButton_RxAutoNewline.MouseDown += new System.Windows.Forms.MouseEventHandler(this.toolStripButton_RxAutoNewline_MouseDown);
            // 
            // toolStripButton_Timestamp
            // 
            this.toolStripButton_Timestamp.AutoSize = false;
            this.toolStripButton_Timestamp.BackColor = System.Drawing.Color.Transparent;
            this.toolStripButton_Timestamp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Timestamp.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_Timestamp.Image")));
            this.toolStripButton_Timestamp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Timestamp.Name = "toolStripButton_Timestamp";
            this.toolStripButton_Timestamp.Size = new System.Drawing.Size(30, 30);
            this.toolStripButton_Timestamp.Text = "OFF";
            this.toolStripButton_Timestamp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.toolStripButton_Timestamp_MouseDown);
            // 
            // toolStripButton_log
            // 
            this.toolStripButton_log.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_log.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_log.Image")));
            this.toolStripButton_log.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_log.Name = "toolStripButton_log";
            this.toolStripButton_log.Size = new System.Drawing.Size(29, 31);
            this.toolStripButton_log.Text = "记录log";
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(29, 6);
            // 
            // toolStripButton_Fold
            // 
            this.toolStripButton_Fold.AutoSize = false;
            this.toolStripButton_Fold.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Fold.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_Fold.Image")));
            this.toolStripButton_Fold.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Fold.Name = "toolStripButton_Fold";
            this.toolStripButton_Fold.Size = new System.Drawing.Size(30, 30);
            this.toolStripButton_Fold.Text = "发送列表显隐";
            this.toolStripButton_Fold.MouseDown += new System.Windows.Forms.MouseEventHandler(this.toolStripButton_Fold_MouseDown);
            // 
            // splitContainer_Master
            // 
            this.splitContainer_Master.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer_Master.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer_Master.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer_Master.Location = new System.Drawing.Point(36, 0);
            this.splitContainer_Master.Name = "splitContainer_Master";
            // 
            // splitContainer_Master.Panel1
            // 
            this.splitContainer_Master.Panel1.Controls.Add(this.TextBox_Tx);
            this.splitContainer_Master.Panel1.Controls.Add(this.panel1);
            this.splitContainer_Master.Panel1.Controls.Add(this.richTextBox_Rx);
            this.splitContainer_Master.Panel1.Controls.Add(this.Label_Status);
            // 
            // splitContainer_Master.Panel2
            // 
            this.splitContainer_Master.Panel2.AutoScroll = true;
            this.splitContainer_Master.Panel2.Controls.Add(this.tabControl_TxList);
            this.splitContainer_Master.Panel2.Controls.Add(this.toolStrip_TableTX);
            this.splitContainer_Master.Size = new System.Drawing.Size(720, 427);
            this.splitContainer_Master.SplitterDistance = 451;
            this.splitContainer_Master.SplitterIncrement = 4;
            this.splitContainer_Master.TabIndex = 29;
            this.splitContainer_Master.TabStop = false;
            // 
            // TextBox_Tx
            // 
            this.TextBox_Tx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox_Tx.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.TextBox_Tx.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TextBox_Tx.Font = new System.Drawing.Font("Courier New", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBox_Tx.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.TextBox_Tx.Location = new System.Drawing.Point(3, 344);
            this.TextBox_Tx.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.TextBox_Tx.MaxLength = 2147483647;
            this.TextBox_Tx.Multiline = true;
            this.TextBox_Tx.Name = "TextBox_Tx";
            this.TextBox_Tx.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TextBox_Tx.Size = new System.Drawing.Size(439, 52);
            this.TextBox_Tx.TabIndex = 23;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.button_Tx);
            this.panel1.Controls.Add(this.checkBox_TimSend);
            this.panel1.Controls.Add(this.NumUpDown_TimSend);
            this.panel1.Location = new System.Drawing.Point(241, 397);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(180, 27);
            this.panel1.TabIndex = 27;
            // 
            // button_Tx
            // 
            this.button_Tx.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.button_Tx.Location = new System.Drawing.Point(97, 1);
            this.button_Tx.Name = "button_Tx";
            this.button_Tx.Size = new System.Drawing.Size(80, 23);
            this.button_Tx.TabIndex = 26;
            this.button_Tx.Text = "发送";
            this.button_Tx.UseVisualStyleBackColor = false;
            this.button_Tx.Click += new System.EventHandler(this.button_Tx_Click);
            // 
            // checkBox_TimSend
            // 
            this.checkBox_TimSend.AutoSize = true;
            this.checkBox_TimSend.BackColor = System.Drawing.Color.Transparent;
            this.checkBox_TimSend.ForeColor = System.Drawing.SystemColors.ControlText;
            this.checkBox_TimSend.Location = new System.Drawing.Point(68, 5);
            this.checkBox_TimSend.Name = "checkBox_TimSend";
            this.checkBox_TimSend.Size = new System.Drawing.Size(36, 16);
            this.checkBox_TimSend.TabIndex = 25;
            this.checkBox_TimSend.Text = "ms";
            this.checkBox_TimSend.UseVisualStyleBackColor = false;
            this.checkBox_TimSend.CheckedChanged += new System.EventHandler(this.checkBox_TimSend_CheckedChanged);
            // 
            // NumUpDown_TimSend
            // 
            this.NumUpDown_TimSend.BackColor = System.Drawing.SystemColors.Window;
            this.NumUpDown_TimSend.Location = new System.Drawing.Point(1, 2);
            this.NumUpDown_TimSend.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.NumUpDown_TimSend.Name = "NumUpDown_TimSend";
            this.NumUpDown_TimSend.Size = new System.Drawing.Size(64, 21);
            this.NumUpDown_TimSend.TabIndex = 24;
            this.NumUpDown_TimSend.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.NumUpDown_TimSend.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // richTextBox_Rx
            // 
            this.richTextBox_Rx.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox_Rx.BackColor = System.Drawing.Color.DarkCyan;
            this.richTextBox_Rx.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox_Rx.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox_Rx.ForeColor = System.Drawing.Color.White;
            this.richTextBox_Rx.Location = new System.Drawing.Point(3, 3);
            this.richTextBox_Rx.Margin = new System.Windows.Forms.Padding(3, 3, 3, 1);
            this.richTextBox_Rx.Name = "richTextBox_Rx";
            this.richTextBox_Rx.ReadOnly = true;
            this.richTextBox_Rx.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.richTextBox_Rx.Size = new System.Drawing.Size(439, 340);
            this.richTextBox_Rx.TabIndex = 22;
            this.richTextBox_Rx.Text = "";
            this.richTextBox_Rx.ContentsResized += new System.Windows.Forms.ContentsResizedEventHandler(this.richTextBox_Rx_ContentsResized);
            this.richTextBox_Rx.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.richTextBox_Rx_LinkClicked);
            this.richTextBox_Rx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.richTextBox_Rx_KeyDown);
            // 
            // tabControl_TxList
            // 
            this.tabControl_TxList.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControl_TxList.Controls.Add(this.tabPage_TxList);
            this.tabControl_TxList.Controls.Add(this.tabPage_TxListSimple);
            this.tabControl_TxList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_TxList.Location = new System.Drawing.Point(0, 26);
            this.tabControl_TxList.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl_TxList.Name = "tabControl_TxList";
            this.tabControl_TxList.SelectedIndex = 0;
            this.tabControl_TxList.Size = new System.Drawing.Size(263, 399);
            this.tabControl_TxList.TabIndex = 2;
            this.tabControl_TxList.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl_TxList_Selected);
            // 
            // tabPage_TxList
            // 
            this.tabPage_TxList.Controls.Add(this.panel3);
            this.tabPage_TxList.Location = new System.Drawing.Point(4, 4);
            this.tabPage_TxList.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage_TxList.Name = "tabPage_TxList";
            this.tabPage_TxList.Size = new System.Drawing.Size(255, 373);
            this.tabPage_TxList.TabIndex = 0;
            this.tabPage_TxList.Text = "列表模式";
            this.tabPage_TxList.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.AutoScroll = true;
            this.panel3.Controls.Add(this.splitContainer1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(255, 373);
            this.panel3.TabIndex = 2;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel2);
            this.splitContainer1.Size = new System.Drawing.Size(238, 1351);
            this.splitContainer1.SplitterDistance = 97;
            this.splitContainer1.SplitterIncrement = 4;
            this.splitContainer1.SplitterWidth = 8;
            this.splitContainer1.TabIndex = 0;
            this.splitContainer1.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 100;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(97, 1320);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 100;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(133, 1320);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // tabPage_TxListSimple
            // 
            this.tabPage_TxListSimple.Controls.Add(this.splitContainer_TxListSimple);
            this.tabPage_TxListSimple.Location = new System.Drawing.Point(4, 4);
            this.tabPage_TxListSimple.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage_TxListSimple.Name = "tabPage_TxListSimple";
            this.tabPage_TxListSimple.Size = new System.Drawing.Size(255, 373);
            this.tabPage_TxListSimple.TabIndex = 1;
            this.tabPage_TxListSimple.Text = "精简模式";
            this.tabPage_TxListSimple.UseVisualStyleBackColor = true;
            // 
            // splitContainer_TxListSimple
            // 
            this.splitContainer_TxListSimple.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer_TxListSimple.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_TxListSimple.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer_TxListSimple.Location = new System.Drawing.Point(0, 0);
            this.splitContainer_TxListSimple.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer_TxListSimple.Name = "splitContainer_TxListSimple";
            // 
            // splitContainer_TxListSimple.Panel1
            // 
            this.splitContainer_TxListSimple.Panel1.Controls.Add(this.tableLayoutPanel3);
            // 
            // splitContainer_TxListSimple.Panel2
            // 
            this.splitContainer_TxListSimple.Panel2.AutoScroll = true;
            this.splitContainer_TxListSimple.Panel2.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer_TxListSimple.Size = new System.Drawing.Size(255, 373);
            this.splitContainer_TxListSimple.SplitterDistance = 158;
            this.splitContainer_TxListSimple.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.textBoxTxListMsg, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel5, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(156, 371);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.textBoxTxListName, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.comboBoxTxListASCII, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 21);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(156, 21);
            this.tableLayoutPanel4.TabIndex = 3;
            // 
            // textBoxTxListName
            // 
            this.textBoxTxListName.BackColor = System.Drawing.Color.Coral;
            this.textBoxTxListName.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxTxListName.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxTxListName.Location = new System.Drawing.Point(52, 0);
            this.textBoxTxListName.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxTxListName.Name = "textBoxTxListName";
            this.textBoxTxListName.Size = new System.Drawing.Size(104, 21);
            this.textBoxTxListName.TabIndex = 1;
            this.textBoxTxListName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip_TxList.SetToolTip(this.textBoxTxListName, "编辑按钮名");
            // 
            // comboBoxTxListASCII
            // 
            this.comboBoxTxListASCII.BackColor = System.Drawing.SystemColors.Window;
            this.comboBoxTxListASCII.DisplayMember = "0";
            this.comboBoxTxListASCII.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxTxListASCII.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTxListASCII.FormattingEnabled = true;
            this.comboBoxTxListASCII.Items.AddRange(new object[] {
            "HEX",
            "ASCII"});
            this.comboBoxTxListASCII.Location = new System.Drawing.Point(0, 0);
            this.comboBoxTxListASCII.Margin = new System.Windows.Forms.Padding(0);
            this.comboBoxTxListASCII.Name = "comboBoxTxListASCII";
            this.comboBoxTxListASCII.Size = new System.Drawing.Size(52, 20);
            this.comboBoxTxListASCII.TabIndex = 2;
            this.toolTip_TxList.SetToolTip(this.comboBoxTxListASCII, "数据类型");
            this.comboBoxTxListASCII.SelectedIndexChanged += new System.EventHandler(this.comboBoxTxListASCII_SelectedIndexChanged);
            // 
            // textBoxTxListMsg
            // 
            this.textBoxTxListMsg.BackColor = System.Drawing.Color.LightGray;
            this.textBoxTxListMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxTxListMsg.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTxListMsg.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textBoxTxListMsg.Location = new System.Drawing.Point(0, 42);
            this.textBoxTxListMsg.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxTxListMsg.Multiline = true;
            this.textBoxTxListMsg.Name = "textBoxTxListMsg";
            this.textBoxTxListMsg.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxTxListMsg.Size = new System.Drawing.Size(156, 329);
            this.textBoxTxListMsg.TabIndex = 4;
            this.toolTip_TxList.SetToolTip(this.textBoxTxListMsg, "报文编辑框");
            this.textBoxTxListMsg.WordWrap = false;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 3;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel5.Controls.Add(this.buttonTxListInsert, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.buttonTxListNew, 2, 0);
            this.tableLayoutPanel5.Controls.Add(this.buttonTxListDel, 0, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(156, 21);
            this.tableLayoutPanel5.TabIndex = 5;
            // 
            // buttonTxListInsert
            // 
            this.buttonTxListInsert.BackColor = System.Drawing.Color.Lime;
            this.buttonTxListInsert.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonTxListInsert.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.buttonTxListInsert.Location = new System.Drawing.Point(52, 0);
            this.buttonTxListInsert.Margin = new System.Windows.Forms.Padding(0);
            this.buttonTxListInsert.Name = "buttonTxListInsert";
            this.buttonTxListInsert.Size = new System.Drawing.Size(52, 21);
            this.buttonTxListInsert.TabIndex = 0;
            this.buttonTxListInsert.Text = "插入";
            this.buttonTxListInsert.UseVisualStyleBackColor = false;
            this.buttonTxListInsert.Click += new System.EventHandler(this.buttonTxListInsert_Click);
            // 
            // buttonTxListNew
            // 
            this.buttonTxListNew.BackColor = System.Drawing.Color.Lime;
            this.buttonTxListNew.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonTxListNew.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.buttonTxListNew.Location = new System.Drawing.Point(104, 0);
            this.buttonTxListNew.Margin = new System.Windows.Forms.Padding(0);
            this.buttonTxListNew.Name = "buttonTxListNew";
            this.buttonTxListNew.Size = new System.Drawing.Size(52, 21);
            this.buttonTxListNew.TabIndex = 1;
            this.buttonTxListNew.Text = "新增";
            this.buttonTxListNew.UseVisualStyleBackColor = false;
            this.buttonTxListNew.Click += new System.EventHandler(this.buttonTxListNew_Click);
            // 
            // buttonTxListDel
            // 
            this.buttonTxListDel.BackColor = System.Drawing.Color.OrangeRed;
            this.buttonTxListDel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonTxListDel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonTxListDel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonTxListDel.Location = new System.Drawing.Point(0, 0);
            this.buttonTxListDel.Margin = new System.Windows.Forms.Padding(0);
            this.buttonTxListDel.Name = "buttonTxListDel";
            this.buttonTxListDel.Size = new System.Drawing.Size(52, 21);
            this.buttonTxListDel.TabIndex = 2;
            this.buttonTxListDel.Text = "删除";
            this.buttonTxListDel.UseVisualStyleBackColor = false;
            this.buttonTxListDel.Click += new System.EventHandler(this.buttonTxListDel_Click);
            // 
            // toolStrip_TableTX
            // 
            this.toolStrip_TableTX.BackColor = System.Drawing.Color.RoyalBlue;
            this.toolStrip_TableTX.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip_TableTX.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_TableTx,
            this.toolStripLabel_TableTx});
            this.toolStrip_TableTX.Location = new System.Drawing.Point(0, 0);
            this.toolStrip_TableTX.Name = "toolStrip_TableTX";
            this.toolStrip_TableTX.Padding = new System.Windows.Forms.Padding(0);
            this.toolStrip_TableTX.Size = new System.Drawing.Size(263, 26);
            this.toolStrip_TableTX.TabIndex = 1;
            this.toolStrip_TableTX.Text = "发送列表的按键已上锁";
            this.toolStrip_TableTX.DoubleClick += new System.EventHandler(this.toolStrip_TableTX_DoubleClick);
            // 
            // toolStripButton_TableTx
            // 
            this.toolStripButton_TableTx.BackColor = System.Drawing.Color.Lime;
            this.toolStripButton_TableTx.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton_TableTx.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.toolStripButton_TableTx.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_TableTx.Image")));
            this.toolStripButton_TableTx.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_TableTx.Margin = new System.Windows.Forms.Padding(2, 2, 2, 3);
            this.toolStripButton_TableTx.Name = "toolStripButton_TableTx";
            this.toolStripButton_TableTx.Size = new System.Drawing.Size(36, 21);
            this.toolStripButton_TableTx.Text = "自动";
            this.toolStripButton_TableTx.ToolTipText = "循环发送，未设置延时时间的，自动跳过";
            this.toolStripButton_TableTx.Click += new System.EventHandler(this.toolStripButton_TableTx_Click);
            // 
            // toolStripLabel_TableTx
            // 
            this.toolStripLabel_TableTx.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStripLabel_TableTx.ForeColor = System.Drawing.Color.White;
            this.toolStripLabel_TableTx.Name = "toolStripLabel_TableTx";
            this.toolStripLabel_TableTx.Size = new System.Drawing.Size(32, 23);
            this.toolStripLabel_TableTx.Text = "状态";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(0, 28);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(764, 456);
            this.tabControl1.TabIndex = 31;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.toolStrip_Left);
            this.tabPage1.Controls.Add(this.splitContainer_Master);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(756, 430);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "通信助手";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.splitContainer2);
            this.tabPage4.Controls.Add(this.toolStrip3);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(756, 430);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "超级报文";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(30, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.textBox_SuperMsgRxShow);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.flowLayoutPanel_SuperMsg);
            this.splitContainer2.Size = new System.Drawing.Size(726, 430);
            this.splitContainer2.SplitterDistance = 75;
            this.splitContainer2.TabIndex = 2;
            // 
            // textBox_SuperMsgRxShow
            // 
            this.textBox_SuperMsgRxShow.BackColor = System.Drawing.Color.DarkCyan;
            this.textBox_SuperMsgRxShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_SuperMsgRxShow.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold);
            this.textBox_SuperMsgRxShow.ForeColor = System.Drawing.Color.White;
            this.textBox_SuperMsgRxShow.Location = new System.Drawing.Point(0, 0);
            this.textBox_SuperMsgRxShow.Multiline = true;
            this.textBox_SuperMsgRxShow.Name = "textBox_SuperMsgRxShow";
            this.textBox_SuperMsgRxShow.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_SuperMsgRxShow.Size = new System.Drawing.Size(726, 75);
            this.textBox_SuperMsgRxShow.TabIndex = 0;
            // 
            // flowLayoutPanel_SuperMsg
            // 
            this.flowLayoutPanel_SuperMsg.AutoScroll = true;
            this.flowLayoutPanel_SuperMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel_SuperMsg.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel_SuperMsg.Name = "flowLayoutPanel_SuperMsg";
            this.flowLayoutPanel_SuperMsg.Size = new System.Drawing.Size(726, 351);
            this.flowLayoutPanel_SuperMsg.TabIndex = 1;
            // 
            // toolStrip3
            // 
            this.toolStrip3.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolStrip3.ImageScalingSize = new System.Drawing.Size(27, 27);
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton2});
            this.toolStrip3.Location = new System.Drawing.Point(0, 0);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(30, 430);
            this.toolStrip3.TabIndex = 0;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.AutoSize = false;
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = global::串口助手.Properties.Resources.新建;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(29, 29);
            this.toolStripButton2.Text = "toolStripButton2";
            this.toolStripButton2.ToolTipText = "快速创建";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Controls.Add(this.toolStrip2);
            this.tabPage2.Controls.Add(this.toolStrip1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(756, 430);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "烧录";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.progressBar_Firmware);
            this.panel2.Controls.Add(this.richTextBox_HexShow);
            this.panel2.Controls.Add(this.button_Erase);
            this.panel2.Controls.Add(this.button_Run);
            this.panel2.Controls.Add(this.button_Uploading);
            this.panel2.Controls.Add(this.button_Download);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 53);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(750, 374);
            this.panel2.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.numericUpDown_Read);
            this.groupBox1.Controls.Add(this.numericUpDown_Write);
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(17, 114);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(112, 67);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "延时";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "W      R";
            // 
            // numericUpDown_Read
            // 
            this.numericUpDown_Read.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.numericUpDown_Read.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDown_Read.Location = new System.Drawing.Point(58, 40);
            this.numericUpDown_Read.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numericUpDown_Read.Name = "numericUpDown_Read";
            this.numericUpDown_Read.Size = new System.Drawing.Size(43, 21);
            this.numericUpDown_Read.TabIndex = 8;
            this.numericUpDown_Read.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // numericUpDown_Write
            // 
            this.numericUpDown_Write.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.numericUpDown_Write.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDown_Write.Location = new System.Drawing.Point(10, 40);
            this.numericUpDown_Write.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numericUpDown_Write.Name = "numericUpDown_Write";
            this.numericUpDown_Write.Size = new System.Drawing.Size(43, 21);
            this.numericUpDown_Write.TabIndex = 7;
            this.numericUpDown_Write.TabStop = false;
            this.numericUpDown_Write.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // progressBar_Firmware
            // 
            this.progressBar_Firmware.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar_Firmware.Location = new System.Drawing.Point(153, 357);
            this.progressBar_Firmware.Name = "progressBar_Firmware";
            this.progressBar_Firmware.Size = new System.Drawing.Size(596, 10);
            this.progressBar_Firmware.TabIndex = 6;
            // 
            // richTextBox_HexShow
            // 
            this.richTextBox_HexShow.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox_HexShow.BackColor = System.Drawing.Color.DarkCyan;
            this.richTextBox_HexShow.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox_HexShow.ForeColor = System.Drawing.Color.White;
            this.richTextBox_HexShow.Location = new System.Drawing.Point(153, 2);
            this.richTextBox_HexShow.Margin = new System.Windows.Forms.Padding(0);
            this.richTextBox_HexShow.Name = "richTextBox_HexShow";
            this.richTextBox_HexShow.Size = new System.Drawing.Size(596, 349);
            this.richTextBox_HexShow.TabIndex = 4;
            this.richTextBox_HexShow.Text = "";
            this.richTextBox_HexShow.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.richTextBox_Rx_LinkClicked);
            // 
            // button_Erase
            // 
            this.button_Erase.BackColor = System.Drawing.Color.Tomato;
            this.button_Erase.Enabled = false;
            this.button_Erase.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_Erase.Location = new System.Drawing.Point(17, 60);
            this.button_Erase.Name = "button_Erase";
            this.button_Erase.Size = new System.Drawing.Size(55, 35);
            this.button_Erase.TabIndex = 3;
            this.button_Erase.Text = "全擦";
            this.button_Erase.UseVisualStyleBackColor = false;
            this.button_Erase.Click += new System.EventHandler(this.button_Erase_Click);
            // 
            // button_Run
            // 
            this.button_Run.BackColor = System.Drawing.Color.Lime;
            this.button_Run.Enabled = false;
            this.button_Run.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_Run.Location = new System.Drawing.Point(77, 60);
            this.button_Run.Name = "button_Run";
            this.button_Run.Size = new System.Drawing.Size(55, 35);
            this.button_Run.TabIndex = 2;
            this.button_Run.Text = "运行";
            this.button_Run.UseVisualStyleBackColor = false;
            this.button_Run.Click += new System.EventHandler(this.button_Run_Click);
            // 
            // button_Uploading
            // 
            this.button_Uploading.Enabled = false;
            this.button_Uploading.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Uploading.Location = new System.Drawing.Point(77, 20);
            this.button_Uploading.Name = "button_Uploading";
            this.button_Uploading.Size = new System.Drawing.Size(55, 35);
            this.button_Uploading.TabIndex = 1;
            this.button_Uploading.Text = "读取";
            this.button_Uploading.UseVisualStyleBackColor = true;
            this.button_Uploading.Click += new System.EventHandler(this.button_Uploading_Click);
            // 
            // button_Download
            // 
            this.button_Download.BackColor = System.Drawing.Color.Orange;
            this.button_Download.Enabled = false;
            this.button_Download.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_Download.Location = new System.Drawing.Point(17, 20);
            this.button_Download.Name = "button_Download";
            this.button_Download.Size = new System.Drawing.Size(55, 35);
            this.button_Download.TabIndex = 0;
            this.button_Download.Text = "烧录";
            this.button_Download.UseVisualStyleBackColor = false;
            this.button_Download.Click += new System.EventHandler(this.button_Download_Click);
            // 
            // toolStrip2
            // 
            this.toolStrip2.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripComboBox_LoaderFile,
            this.toolStripButton_OpenFile,
            this.toolStripSeparator2,
            this.toolStripButton1});
            this.toolStrip2.Location = new System.Drawing.Point(3, 28);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(750, 25);
            this.toolStrip2.TabIndex = 1;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripComboBox_LoaderFile
            // 
            this.toolStripComboBox_LoaderFile.Name = "toolStripComboBox_LoaderFile";
            this.toolStripComboBox_LoaderFile.Size = new System.Drawing.Size(400, 25);
            this.toolStripComboBox_LoaderFile.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBox_LoaderFile_SelectedIndexChanged);
            // 
            // toolStripButton_OpenFile
            // 
            this.toolStripButton_OpenFile.BackColor = System.Drawing.Color.DarkOrange;
            this.toolStripButton_OpenFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton_OpenFile.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStripButton_OpenFile.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_OpenFile.Image")));
            this.toolStripButton_OpenFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_OpenFile.Name = "toolStripButton_OpenFile";
            this.toolStripButton_OpenFile.Size = new System.Drawing.Size(60, 22);
            this.toolStripButton_OpenFile.Text = "加载文件";
            this.toolStripButton_OpenFile.Click += new System.EventHandler(this.toolStripButton_OpenFile_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.BackColor = System.Drawing.Color.MediumTurquoise;
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(60, 22);
            this.toolStripButton1.Text = "输出数组";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel3,
            this.toolStripComboBox_MCU,
            this.toolStripButton_BootOn,
            this.toolStripSeparator3,
            this.toolStripLabel_BootLinkStatus});
            this.toolStrip1.Location = new System.Drawing.Point(3, 3);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(750, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(37, 22);
            this.toolStripLabel3.Text = "MCU";
            // 
            // toolStripComboBox_MCU
            // 
            this.toolStripComboBox_MCU.AutoSize = false;
            this.toolStripComboBox_MCU.BackColor = System.Drawing.Color.Yellow;
            this.toolStripComboBox_MCU.DropDownWidth = 40;
            this.toolStripComboBox_MCU.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStripComboBox_MCU.ForeColor = System.Drawing.Color.Red;
            this.toolStripComboBox_MCU.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.toolStripComboBox_MCU.Name = "toolStripComboBox_MCU";
            this.toolStripComboBox_MCU.Size = new System.Drawing.Size(40, 25);
            this.toolStripComboBox_MCU.Text = "1";
            this.toolStripComboBox_MCU.ToolTipText = "MCU编号";
            // 
            // toolStripButton_BootOn
            // 
            this.toolStripButton_BootOn.AutoSize = false;
            this.toolStripButton_BootOn.BackColor = System.Drawing.Color.Lime;
            this.toolStripButton_BootOn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton_BootOn.Enabled = false;
            this.toolStripButton_BootOn.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStripButton_BootOn.ForeColor = System.Drawing.Color.Black;
            this.toolStripButton_BootOn.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_BootOn.Image")));
            this.toolStripButton_BootOn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_BootOn.Name = "toolStripButton_BootOn";
            this.toolStripButton_BootOn.Size = new System.Drawing.Size(85, 22);
            this.toolStripButton_BootOn.Text = "GOTO_BOOT";
            this.toolStripButton_BootOn.ToolTipText = "跳转进入BootLoader";
            this.toolStripButton_BootOn.Click += new System.EventHandler(this.toolStripButton_BootOn_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel_BootLinkStatus
            // 
            this.toolStripLabel_BootLinkStatus.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStripLabel_BootLinkStatus.ForeColor = System.Drawing.Color.OrangeRed;
            this.toolStripLabel_BootLinkStatus.Name = "toolStripLabel_BootLinkStatus";
            this.toolStripLabel_BootLinkStatus.Size = new System.Drawing.Size(0, 22);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.flowLayoutPanel_Channel);
            this.tabPage3.Controls.Add(this.ChannelList_toolStrip0);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(756, 430);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "多通道配置";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel_Channel
            // 
            this.flowLayoutPanel_Channel.AutoScroll = true;
            this.flowLayoutPanel_Channel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel_Channel.Location = new System.Drawing.Point(31, 0);
            this.flowLayoutPanel_Channel.Name = "flowLayoutPanel_Channel";
            this.flowLayoutPanel_Channel.Size = new System.Drawing.Size(725, 430);
            this.flowLayoutPanel_Channel.TabIndex = 2;
            // 
            // ChannelList_toolStrip0
            // 
            this.ChannelList_toolStrip0.Dock = System.Windows.Forms.DockStyle.Left;
            this.ChannelList_toolStrip0.ImageScalingSize = new System.Drawing.Size(27, 27);
            this.ChannelList_toolStrip0.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton4});
            this.ChannelList_toolStrip0.Location = new System.Drawing.Point(0, 0);
            this.ChannelList_toolStrip0.Name = "ChannelList_toolStrip0";
            this.ChannelList_toolStrip0.Size = new System.Drawing.Size(31, 430);
            this.ChannelList_toolStrip0.TabIndex = 1;
            this.ChannelList_toolStrip0.Text = "toolStrip4";
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.AutoSize = false;
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = global::串口助手.Properties.Resources.新建;
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(30, 30);
            this.toolStripButton4.Text = "新建通道";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // tabPage5
            // 
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(756, 430);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "动态曲线";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // openFileDialog_Download
            // 
            this.openFileDialog_Download.Filter = "hex文件(*.hex)|*.hex|bin文件(*.bin)|*.bin|所有文件|*.*";
            this.openFileDialog_Download.RestoreDirectory = true;
            // 
            // saveFileDialog_Firmware
            // 
            this.saveFileDialog_Firmware.FileName = "Firmware.c";
            this.saveFileDialog_Firmware.Filter = "C文件|*.c|文本|*.txt";
            this.saveFileDialog_Firmware.RestoreDirectory = true;
            // 
            // trackBar1
            // 
            this.trackBar1.AutoSize = false;
            this.trackBar1.Location = new System.Drawing.Point(526, 5);
            this.trackBar1.Maximum = 90;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(20, 23);
            this.trackBar1.TabIndex = 28;
            this.trackBar1.TabStop = false;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            this.trackBar1.MouseLeave += new System.EventHandler(this.trackBar1_MouseLeave);
            this.trackBar1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.trackBar1_MouseMove);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(764, 481);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.toolStrip_LeftTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.toolStrip_LeftTop.ResumeLayout(false);
            this.toolStrip_LeftTop.PerformLayout();
            this.toolStrip_Left.ResumeLayout(false);
            this.toolStrip_Left.PerformLayout();
            this.splitContainer_Master.Panel1.ResumeLayout(false);
            this.splitContainer_Master.Panel1.PerformLayout();
            this.splitContainer_Master.Panel2.ResumeLayout(false);
            this.splitContainer_Master.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_Master)).EndInit();
            this.splitContainer_Master.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumUpDown_TimSend)).EndInit();
            this.tabControl_TxList.ResumeLayout(false);
            this.tabPage_TxList.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabPage_TxListSimple.ResumeLayout(false);
            this.splitContainer_TxListSimple.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_TxListSimple)).EndInit();
            this.splitContainer_TxListSimple.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.toolStrip_TableTX.ResumeLayout(false);
            this.toolStrip_TableTX.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Read)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Write)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ChannelList_toolStrip0.ResumeLayout(false);
            this.ChannelList_toolStrip0.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label Label_Status;
        private System.Windows.Forms.Timer timer_Send;
        private System.Windows.Forms.ToolStrip toolStrip_LeftTop;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox_SerialPort;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox_BaudRate;
        private System.Windows.Forms.ToolStripButton toolStripButton_Master;
        private System.Windows.Forms.ToolStripButton toolStripButton_RecClear;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
        private System.Windows.Forms.ToolStrip toolStrip_Left;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton toolStripButton_TxHEX;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripButton toolStripButton_RxHEX;
        private System.Windows.Forms.ToolStripButton toolStripButton_RxAutoNewline;
        private System.Windows.Forms.ToolStripButton toolStripButton_Timestamp;
        private System.Windows.Forms.SplitContainer splitContainer_Master;
        private System.Windows.Forms.CheckBox checkBox_TimSend;
        private System.Windows.Forms.NumericUpDown NumUpDown_TimSend;
        private System.Windows.Forms.Button button_Tx;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox_TCPPort;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox_LoaderFile;
        private System.Windows.Forms.ToolStripButton toolStripButton_OpenFile;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripButton toolStripButton_BootOn;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RichTextBox richTextBox_HexShow;
        private System.Windows.Forms.OpenFileDialog openFileDialog_Download;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog_Firmware;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_BootLinkStatus;
        private System.Windows.Forms.ProgressBar progressBar_Firmware;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox_MCU;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton toolStripButton_Fold;
        private System.Windows.Forms.ToolStripButton toolStripButton_help;
        private System.Windows.Forms.ToolStripButton toolStripButton_OnTop;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.ToolStrip toolStrip_TableTX;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_TableTx;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown_Read;
        private System.Windows.Forms.NumericUpDown numericUpDown_Write;
        private System.Windows.Forms.Button button_Erase;
        private System.Windows.Forms.Button button_Run;
        private System.Windows.Forms.Button button_Uploading;
        private System.Windows.Forms.Button button_Download;
        private System.Windows.Forms.ToolStripButton toolStripButton_log;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton_Set;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem 指令规则清空ToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton_TableTx;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox_TxListNum;
        private System.Windows.Forms.ToolStripButton toolStripButton_SaveSet;
        private System.Windows.Forms.ToolStripMenuItem 加载发送列表ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 另存为ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 新建ToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ToolStrip ChannelList_toolStrip0;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_Channel;
        private System.Windows.Forms.TextBox TextBox_Tx;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox_Convert;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripComboBox MasterMsgEnd;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        public System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_SuperMsg;
        private System.Windows.Forms.SplitContainer splitContainer2;
        public System.Windows.Forms.TextBox textBox_SuperMsgRxShow;
        private System.Windows.Forms.ToolTip toolTip_TxList;
        private System.Windows.Forms.TabControl tabControl_TxList;
        private System.Windows.Forms.TabPage tabPage_TxList;
        private System.Windows.Forms.TabPage tabPage_TxListSimple;
        public System.Windows.Forms.RichTextBox richTextBox_Rx;
        private System.Windows.Forms.SplitContainer splitContainer_TxListSimple;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TextBox textBoxTxListName;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.ComboBox comboBoxTxListASCII;
        private System.Windows.Forms.TextBox textBoxTxListMsg;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Button buttonTxListInsert;
        private System.Windows.Forms.Button buttonTxListNew;
        private System.Windows.Forms.Button buttonTxListDel;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox自动换行定时器周期;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripPanel BottomToolStripPanel;
        private System.Windows.Forms.ToolStripPanel TopToolStripPanel;
        private System.Windows.Forms.ToolStripPanel RightToolStripPanel;
        private System.Windows.Forms.ToolStripPanel LeftToolStripPanel;
        private System.Windows.Forms.ToolStripContentPanel ContentPanel;
    }
}

