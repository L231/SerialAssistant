using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 串口助手
{
    class TxListSimple
    {
        //删除该按钮，在创建报文时，先随便创建一个按钮，
        //再创建一个TxListSimple类，映射到按钮，同时放置链表中，
        //接着，若需要新建报文，该类需要重新映射。
        public string[] Msg = null;
        public string MsgName = "";
        public int DataType = 0;
        //public int DelayMs = 0;


    }
}
