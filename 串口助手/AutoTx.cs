using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace 串口助手
{
    class AutoTx
    {
        [System.Runtime.InteropServices.DllImport("msvcrt.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern int memcmp(byte[] b1, byte[] b2, long count);


        public class AutoTxClass_t
        {
            public byte[] rx;
            public byte[] tx;
        };

        private List<AutoTxClass_t> ListAutoTx = new List<AutoTxClass_t>();


        public void CmdUpdate(string[] cmd, string DataType, string MsgTailType)
        {
            DataTypeConversion dataType = new DataTypeConversion();
            ListAutoTx.Clear();
            foreach(string p in cmd)
            {
                if (p == "")
                    continue;
                if (!p.Contains('$'))
                    continue;
                string[] temp = p.Split('$');
                if (temp[0] == "" || temp[1] == "")
                {
                    MessageBox.Show("请检查：" + p + "！", "自动下发的规则异常");
                    return;
                }
                AutoTxClass_t class_T = new AutoTxClass_t();
                class_T.rx = dataType.StringToByte(DataType, temp[0]);
                class_T.tx = dataType.StringToByte(DataType, temp[1]);
                if (class_T.rx == null || class_T.tx == null)
                {
                    MessageBox.Show("请检查：" + p + "！", "自动下发的规则异常");
                    return;
                }
                dataType.ByteAddMsgTail(MsgTailType, ref class_T.rx);
                ListAutoTx.Add(class_T);
            }
        }

        public byte[] GetTxMsg(byte[] rx, int length)
        {
            foreach(AutoTxClass_t p in ListAutoTx)
            {
                if (p.rx.Length != length)
                    continue;
                if (memcmp(p.rx, rx, p.rx.Length) == 0)
                    return p.tx;
            }
            return null;
        }
    }
}
