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
    class ContextMenu
    {
        public ContextMenuStrip TxListMenu = new ContextMenuStrip();
        public ContextMenuStrip RxShowMenu = new ContextMenuStrip();
        public ContextMenuStrip CreateSuperMsgMenu = new ContextMenuStrip();
        public ContextMenuStrip TxListSimpleMenu = new ContextMenuStrip();


        public delegate void CreateSuperMsgHandler(int rx_textbox, int tx_textbox);
        CreateSuperMsgHandler createSuperMsgHandler;

        ToolStripComboBox 字体大小 = new ToolStripComboBox();

        ToolStripTextBox 接收文本框 = new ToolStripTextBox();
        ToolStripTextBox 发送文本框 = new ToolStripTextBox();

        public void ContextMenuTxListInit()
        {
            TxListMenu.Name = "发送列表的右键菜单";
            ToolStripTextBox 发送按钮文本输入框 = new ToolStripTextBox();
            发送按钮文本输入框.BackColor = System.Drawing.Color.Coral;
            发送按钮文本输入框.Size = new System.Drawing.Size(150, 25);
            发送按钮文本输入框.ToolTipText = "给按钮命名";
            发送按钮文本输入框.LostFocus += new EventHandler(发送按钮文本输入框_LostFocusClick);
            TxListMenu.Items.AddRange(new ToolStripItem[]
            {
                发送按钮文本输入框,
            });

            TxListSimpleMenu.Name = "发送列表简洁模式的右键菜单";

            RxShowMenu.Name = "接收显示区的右键菜单";
            ToolStripSeparator 分割线 = new ToolStripSeparator();
            ToolStripMenuItem 复制 = new ToolStripMenuItem();
            ToolStripMenuItem 粘贴 = new ToolStripMenuItem();
            ToolStripMenuItem 全选 = new ToolStripMenuItem();
            ToolStripMenuItem 清空 = new ToolStripMenuItem();
            ToolStripMenuItem 接收区解锁 = new ToolStripMenuItem();
            复制.Text = "复制";
            粘贴.Text = "粘贴";
            全选.Text = "全选";
            清空.Text = "清空";
            接收区解锁.Text = "接收区解锁";
            粘贴.BackColor = System.Drawing.Color.Gainsboro;
            清空.BackColor = System.Drawing.Color.Gainsboro;
            字体大小.MaxLength = 4;
            字体大小.Size = new System.Drawing.Size(60, 25);
            字体大小.ToolTipText = "接收显示区的字体大小";
            字体大小.DropDownStyle = ComboBoxStyle.DropDown;
            字体大小.Items.AddRange(new object[]
            {
                "9",
                "10.5",
                "12",
                "14",
                "16",
                "18",
                "21",
                "28",
            });
            RxShowMenu.Items.AddRange(new ToolStripItem[]
            {
                复制,
                粘贴,
                全选,
                清空,
                分割线,
                接收区解锁,
                字体大小,
            });

            TxListMenu.Opening += new CancelEventHandler(发送列表右键菜单_Opening);
            RxShowMenu.Opening += new CancelEventHandler(接收显示区右键菜单_Opening);
            复制.Click += new EventHandler(复制ToolStripMenuItem_Click);
            粘贴.Click += new EventHandler(粘贴ToolStripMenuItem_Click);
            全选.Click += new EventHandler(全选ToolStripMenuItem_Click);
            清空.Click += new EventHandler(清空ToolStripMenuItem_Click);
            接收区解锁.Click += new EventHandler(接收区解锁_Click);
            字体大小.TextUpdate += new EventHandler(接收显示区字体大小_Click);
            字体大小.SelectedIndexChanged += new EventHandler(接收显示区字体大小_Click);

            ContextMenu_CreateSuperMsgInit();
        }
        private void ContextMenu_CreateSuperMsgInit()
        {
            CreateSuperMsgMenu.Name = "新增超级报文";
            ToolStripSeparator 分割线 = new ToolStripSeparator();
            ToolStripMenuItem 超级报文创建按钮 = new ToolStripMenuItem();
            发送文本框.Size = new Size(120, 27);
            发送文本框.Text = "发送文本框个数：";
            发送文本框.ToolTipText = "发送文本框的个数";
            接收文本框.Size = new Size(120, 27);
            接收文本框.Text = "接收文本框个数：";
            接收文本框.ToolTipText = "接收文本框的个数";
            超级报文创建按钮.Text = "创建";
            超级报文创建按钮.BackColor = Color.Coral;
            超级报文创建按钮.Click += new EventHandler(超级报文创建按钮ToolStripMenuItem_Click);
            CreateSuperMsgMenu.Items.AddRange(new ToolStripItem[]
            {
                接收文本框,
                发送文本框,
                分割线,
                超级报文创建按钮,
            });
        }
        public void ContextMenu_CreateSuperMsgClickCfg(CreateSuperMsgHandler eventHandler)
        {
            createSuperMsgHandler = eventHandler;
        }


        private void 超级报文创建按钮ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DataTypeConversion dataType = new DataTypeConversion();
                createSuperMsgHandler(dataType.GetStringNumber(接收文本框.Text),
                    dataType.GetStringNumber(发送文本框.Text));
            }
            catch { }
        }

        private void 全选ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Control c = RxShowMenu.SourceControl;
            if (c.GetType().Name == "RichTextBox")
            {
                RichTextBox r = (RichTextBox)c;
                r.SelectAll();
            }
        }

        private void 复制ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Control c = RxShowMenu.SourceControl;
            if (c.GetType().Name == "RichTextBox")
            {
                RichTextBox r = (RichTextBox)c;
                r.Copy();
            }
        }

        private void 粘贴ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Control c = RxShowMenu.SourceControl;
            if (c.GetType().Name == "RichTextBox")
            {
                RichTextBox r = (RichTextBox)c;
                r.Paste();
            }
        }

        private void 清空ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Control c = RxShowMenu.SourceControl;
            if (c.GetType().Name == "RichTextBox")
            {
                RichTextBox r = (RichTextBox)c;
                r.Clear();
            }
        }
        private void 发送按钮文本输入框_LostFocusClick(object sender, EventArgs e)
        {
            Control c = TxListMenu.SourceControl;
            if (c.GetType().Name == "Button")
            {
                ((Button)c).Text = TxListMenu.Items[0].Text;
            }
        }
        private void 发送列表右键菜单_Opening(object sender, CancelEventArgs e)
        {
            Control c = TxListMenu.SourceControl;
            if (c.GetType().Name == "Button")
            {
                Button r = (Button)c;
                TxListMenu.Items[0].Text = r.Text;
            }
        }

        private void 接收显示区右键菜单_Opening(object sender, CancelEventArgs e)
        {
            Control c = RxShowMenu.SourceControl;
            if (c.GetType().Name == "RichTextBox")
            {
                RichTextBox r = (RichTextBox)c;
                字体大小.Text = r.Font.Size.ToString();
            }
        }
        private void 接收显示区字体大小_Click(object sender, EventArgs e)
        {
            Control c = RxShowMenu.SourceControl;
            if (c.GetType().Name == "RichTextBox")
            {
                RichTextBox r = (RichTextBox)c;
                try
                {
                    r.Font = new Font(r.Font.FontFamily,
                            Convert.ToSingle(((ToolStripComboBox)sender).Text),
                            r.Font.Style);
                }
                catch
                {
                    ((ToolStripComboBox)sender).Text = "";
                }
            }
        }

        private void 接收区解锁_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
            Control c = RxShowMenu.SourceControl;
            if (c.GetType().Name == "RichTextBox")
            {
                RichTextBox r = (RichTextBox)c;
                if (menuItem.Text == "接收区解锁")
                {
                    r.ReadOnly = false;
                    menuItem.Text = "接收区上锁";
                }
                else
                {
                    r.ReadOnly = true;
                    menuItem.Text = "接收区解锁";
                }
            }
        }
    }
}
