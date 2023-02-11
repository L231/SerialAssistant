using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 串口助手
{
    public partial class Form1
    {
        List<TxListSimple> txListSimple_List = new List<TxListSimple>();
        List<Button> buttonListSimple = new List<Button>();
        int buttonListSimpleNumber = 0;  //参数列表与按钮列表的下标刚好反向

        private int splitContainer_TxListSimple_size = -1;


        private void CurrentButtonListSimple_BackColorCfg(Color color)
        {
            int ButtonPos = buttonListSimple.Count - 1 - buttonListSimpleNumber;
            buttonListSimple[ButtonPos].BackColor = color;
        }

        /// <summary>
        /// 获取当前节点在精简发送列表的位置
        /// </summary>
        /// <param name="btn"></param>
        /// <returns></returns>
        private int buttonListSimpleNumber_Get(Button btn)
        {
            int last = buttonListSimple.Count - 1;
            return last - buttonListSimple.IndexOf(btn);
        }

        /// <summary>
        /// 打开或关闭精简发送列表的编辑器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxListSimpleMenu_Opening(object sender, CancelEventArgs e)
        {
            int CurrentButton = 0;
            //获取当前按钮的位置
            Control c = contextMenu.TxListSimpleMenu.SourceControl;
            if (c.GetType().Name == "Button")
            {
                int last = buttonListSimple.Count - 1;
                CurrentButton = buttonListSimpleNumber_Get((Button)c);
            }
            //配置框已开启，同时是当前按钮开启的，则关闭配置框
            if (buttonListSimpleNumber == CurrentButton &&
                !splitContainer_TxListSimple.Panel1Collapsed)
            {
                splitContainer_TxListSimple_size = splitContainer_TxListSimple.SplitterDistance;
                splitContainer_TxListSimple.Panel1Collapsed = true;
                splitContainer_Master.SplitterDistance += splitContainer_TxListSimple_size;
            }
            else
            {
                if (splitContainer_TxListSimple.Panel1Collapsed)
                {
                    //配置框处于关闭状态，先开启配置框
                    splitContainer_TxListSimple.Panel1Collapsed = false;
                    splitContainer_Master.SplitterDistance -= splitContainer_TxListSimple_size;
                    splitContainer_TxListSimple.SplitterDistance = splitContainer_TxListSimple_size;
                }
                else
                {
                    //配置框处于开启状态，缓存上一个按钮的配置
                    textBoxTxListName_LostFocusClick(null, null);
                    comboBoxTxListASCII_SelectedIndexChanged(null, null);
                    textBoxTxListMsg_LostFocusClick(null, null);
                }
                //加载新按钮的数据
                txListSimple_DataLoad(CurrentButton);
            }
        }

        /// <summary>
        /// 精简发送列表的节点数据，加载到编辑器中
        /// </summary>
        /// <param name="index"></param>
        private void txListSimple_DataLoad(int index)
        {
            //先清掉上一个按钮的颜色
            CurrentButtonListSimple_BackColorCfg(Color.Transparent);
            if (index < 0)
            {
                textBoxTxListName.Text = "";
                comboBoxTxListASCII.SelectedIndex = 0;
                textBoxTxListMsg.Text = "";
                CurrentButtonListSimple_BackColorCfg(Color.Coral);
                return;
            }
            buttonListSimpleNumber = index;
            //设置当前按钮的颜色
            CurrentButtonListSimple_BackColorCfg(Color.Coral);
            //加载当前按钮的数据
            textBoxTxListName.Text = txListSimple_List[index].MsgName;
            comboBoxTxListASCII.SelectedIndex = txListSimple_List[index].DataType;
            textBoxTxListMsg.Lines = txListSimple_List[index].Msg;
        }

        /// <summary>
        /// 创建一个精简发送列表的发送按钮
        /// </summary>
        /// <param name="btnName"></param>
        private void buttonTxListSimpleCreate(string btnName)
        {
            Button buttonSend = new Button();
            buttonSend.Dock = DockStyle.Top;
            //buttonSend.BackColor = Color.Coral;
            buttonSend.Text = btnName;
            buttonSend.Click += new EventHandler(button_Click);
            buttonSend.ContextMenuStrip = contextMenu.TxListSimpleMenu;
            buttonListSimple.Add(buttonSend);
            splitContainer_TxListSimple.Panel2.Controls.Add(buttonSend);
        }

        /// <summary>
        /// 创建一个精简发送列表的节点
        /// </summary>
        /// <param name="index"></param>
        private void TxListSimpleCreate(int index)
        {
            TxListSimple txListSimple = new TxListSimple();
            buttonTxListSimpleCreate("");
            txListSimple_List.Insert(index, txListSimple);

            txListSimple_DataLoad(-1);
            //更新按钮名称
            int last = buttonListSimple.Count - 1;
            for (int i = 0; i < buttonListSimple.Count; i++)
            {
                buttonListSimple[i].Text = txListSimple_List[last - i].MsgName;
            }
        }

        private void buttonTxListNew_Click(object sender, EventArgs e)
        {
            CurrentButtonListSimple_BackColorCfg(Color.Transparent);
            buttonListSimpleNumber = buttonListSimple.Count;
            TxListSimpleCreate(buttonListSimpleNumber);
        }

        private void buttonTxListInsert_Click(object sender, EventArgs e)
        {
            CurrentButtonListSimple_BackColorCfg(Color.Transparent);
            TxListSimpleCreate(buttonListSimpleNumber);
        }

        private void buttonTxListDel_Click(object sender, EventArgs e)
        {
            //只有一个按钮不给删除
            if (buttonListSimple.Count == 1)
                return;
            int ButtonPos = buttonListSimple.Count - 1 - buttonListSimpleNumber;
            txListSimple_List.RemoveAt(buttonListSimpleNumber);
            buttonListSimple.RemoveAt(ButtonPos);
            splitContainer_TxListSimple.Panel2.Controls.RemoveAt(ButtonPos);

            //int tempNumber = buttonListSimpleNumber;
            if (buttonListSimpleNumber > 0) //删除按钮后，优先加载上一个按钮
                buttonListSimpleNumber--;
            txListSimple_DataLoad(buttonListSimpleNumber);
        }

        private void textBoxTxListName_LostFocusClick(object sender, EventArgs e)
        {
            int ButtonPos = buttonListSimple.Count - 1 - buttonListSimpleNumber;
            buttonListSimple[ButtonPos].Text = textBoxTxListName.Text;
            txListSimple_List[buttonListSimpleNumber].MsgName = textBoxTxListName.Text;
        }
        private void textBoxTxListMsg_LostFocusClick(object sender, EventArgs e)
        {
            txListSimple_List[buttonListSimpleNumber].Msg = textBoxTxListMsg.Lines;
        }

        private void comboBoxTxListASCII_SelectedIndexChanged(object sender, EventArgs e)
        {
            txListSimple_List[buttonListSimpleNumber].DataType = comboBoxTxListASCII.SelectedIndex;
        }

        /// <summary>
        /// 处理精简发送列表的窗体大小
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabControl_TxList_Selected(object sender, TabControlEventArgs e)
        {
            try
            {
                if(splitContainer_TxListSimple_size < 0)
                {
                    splitContainer_TxListSimple_size = splitContainer1.SplitterDistance;
                }
                if (tabControl_TxList.SelectedTab == tabPage_TxList)
                {
                    if (splitContainer_TxListSimple.Panel1Collapsed)
                    {
                        //精简发送列表的配置框处于关闭状态，此时要恢复主接收区的大小
                        splitContainer_Master.SplitterDistance -= splitContainer_TxListSimple_size;
                    }
                    toolStripButton_TableTx.Enabled = true;
                }
                else
                {
                    if (splitContainer_TxListSimple.Panel1Collapsed)
                    {
                        //精简发送列表的配置框处于关闭状态，此时要恢复主接收区的大小
                        splitContainer_Master.SplitterDistance += splitContainer_TxListSimple_size;
                    }
                    toolStripButton_TableTx.Enabled = false;
                }
            }
            catch { }
        }
    }
}
