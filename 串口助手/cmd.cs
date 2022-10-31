using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 串口助手
{
    public partial class Form1
    {
        [System.Runtime.InteropServices.DllImport("msvcrt.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern int memcmp(byte[] b1, byte[] b2, long count);

        struct pos_t
        {
            public bool msb_flag;
            public int head;
            public int length;
        };
        struct CfgMsg16To10_t
        {
            public int min_length;
            public int param_num;
            public byte[] cmd;
            public pos_t[] pos;
        };

        List<CfgMsg16To10_t> gCfgMsg16To10_List = new List<CfgMsg16To10_t>();



        private void 指令规则清空ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gCfgMsg16To10_List.Clear();
            指令规则清空ToolStripMenuItem.Text = "指令规则已清空";
        }

        private void 接收区解锁ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (接收区解锁ToolStripMenuItem.Text == "接收区解锁")
            {
                richTextBox_Rx.ReadOnly = false;
                Help();
                接收区解锁ToolStripMenuItem.Text = "接收区上锁";
            }
            else
            {
                richTextBox_Rx.ReadOnly = true;
                接收区解锁ToolStripMenuItem.Text = "接收区解锁";
            }
        }

        private void richTextBox_Rx_KeyDown(object sender, KeyEventArgs e)
        {
            if (richTextBox_Rx.ReadOnly == true)
                return;
            if (e.KeyCode != Keys.Enter)
                return;
            try
            {
                int CurrentIndex = richTextBox_Rx.SelectionStart;
                string s = richTextBox_Rx.Text;
                //int index = richTextBox_Rx.GetFirstCharIndexOfCurrentLine();
                int last = richTextBox_Rx.GetFirstCharIndexOfCurrentLine();
                for(; last > 1; )
                {
                    if (s[last - 1] == '\n')
                    {
                        break;
                    }
                    richTextBox_Rx.SelectionStart = last - 1;
                    last = richTextBox_Rx.GetFirstCharIndexOfCurrentLine();
                }
                richTextBox_Rx.SelectionStart = CurrentIndex;
                s = s.Substring(last, CurrentIndex - last);
                //int line = richTextBox_Rx.Lines.Length - 1;
                //int line = richTextBox_Rx.GetLineFromCharIndex(index);
                string[] val = s.Split(',');
                richTextBox_Rx.Font = new System.Drawing.Font(richTextBox_Rx.Font, System.Drawing.FontStyle.Regular);
                switch (val[0].ToUpper())
                {
                    case "MSG":
                        Cfg16To10Rule(val);
                        break;
                    case "CFG":
                        break;
                    case "GET":
                        GetCMD(val);
                        break;
                    case "TO":
                        ASCII与HEX互转(val);
                        break;
                    case "CALC":
                        CalcCheckSum(val);
                        break;
                    case "C":
                        Calculator(val);
                        break;
                    case "HELP":
                        Help();
                        break;
                }
                richTextBox_Rx.Font = new System.Drawing.Font(richTextBox_Rx.Font, System.Drawing.FontStyle.Bold);
                toolStripButton_RecClear.Enabled = true;
                toolStripButton_RecClear.BackColor = Color.Gold;
            }
            catch { }
        }

        private void Help()
        {
            richTextBox_Rx.Font = new System.Drawing.Font(richTextBox_Rx.Font, System.Drawing.FontStyle.Regular);
            richTextBox_Rx.AppendText(System.Environment.NewLine +
                "指令   用法举例             输出结果\r\n" +
                "------------------------------------------------------\r\n" +
                " HELP  HELP                 打印指令表\r\n" +
                " GET   GeT,C运算符          打印C运算符表\r\n" +
                " GET   GeT,ASCII            打印ASCII表\r\n" +
                " TO    TO,HEX,12            ==>31 32\r\n" +
                " TO    TO,ASCII,3132        ==>12\r\n" +
                " CALC  CALC,CS,A05A         ==>CheckSum = 0x5\r\n" +
                " C     C,120*xA+25          ==>1225, 0x4C9\r\n" +
                " MSG   msg,12,H-1-3,L-3-5   H:高字节在前，D1<<8|D2\r\n" +
                "当串口收到：12 04 C9 04 C9 自动转 ==>12 [1225] [51460]\r\n");
            richTextBox_Rx.Font = new System.Drawing.Font(richTextBox_Rx.Font, System.Drawing.FontStyle.Bold);
            toolStripButton_RecClear.Enabled = true;
            toolStripButton_RecClear.BackColor = Color.Gold;
        }
        /// <summary>
        /// 按照已添加的指令码规则，进行解码16转10进制
        /// </summary>
        /// <param name="rx_buf"></param>
        /// <param name="len"></param>
        /// <param name="time"></param>
        private void MsgLookup_16To10(byte[] rx_buf, int len, string time)
        {
            foreach(CfgMsg16To10_t p in gCfgMsg16To10_List)
            {
                if (rx_buf[0] == p.cmd[0] && len >= p.min_length)
                {
                    byte[] t = rx_buf.Skip(0).Take(p.cmd.Length).ToArray();
                    //CfgMsg16To10_t p = gCfgMsg16To10_List[cmd_pos];
                    if (memcmp(t, p.cmd, p.cmd.Length) != 0)
                        continue;
                    string msg16to10 = time + BitConverter.ToString(t).Replace("-", " ");
                    int last_tail = p.cmd.Length, length = p.cmd.Length;
                    for (int param_num = 0; param_num < p.param_num; param_num++)
                    {
                        ulong val = 0;
                        int head_pos = p.pos[param_num].head;
                        length = p.pos[param_num].length;
                        //解决第一个参数前面的字节
                        if (head_pos > last_tail)
                        {
                            t = rx_buf.Skip(last_tail).Take(head_pos - last_tail).ToArray();
                            msg16to10 += " " + BitConverter.ToString(t).Replace("-", " ");
                        }
                        last_tail = head_pos + length;
                        t = rx_buf.Skip(head_pos).Take(length).ToArray();
                        if (p.pos[param_num].msb_flag)
                        {
                            foreach(byte b in t)
                            {
                                val <<= 8;
                                val |= b;
                            }
                        }
                        else
                        {
                            for (int pos = length; pos > 0; pos--)
                            {
                                val <<= 8;
                                val |= t[pos - 1];
                            }
                        }
                        msg16to10 += (" [" + val.ToString() + "]");
                    }
                    if(len > length)
                    {
                        byte[] LastByte = rx_buf.Skip(last_tail).Take(len - last_tail).ToArray();
                        msg16to10 += " " + BitConverter.ToString(LastByte).Replace("-", " ");
                    }
                    richTextBox_Rx.AppendText(System.Environment.NewLine + msg16to10);
                    return;
                }
            }
        }
        /// <summary>
        /// 配置指令码解析的规则
        /// </summary>
        /// <param name="val">详细的规则</param>
        private void Cfg16To10Rule(string [] val)
        {
            if (val.Length < 2)
                return;
            //if (val[1].Length > 2)   //不是指令码，0x00 ~ 0xFF
            //    goto CfgMsg16To10_ERROR;
            try
            {
                byte[] cmd = StringToByte("HEX", val[1]);
                for (int pos = 0; pos < gCfgMsg16To10_List.Count(); pos++)
                {
                    if (gCfgMsg16To10_List[pos].cmd.Length == cmd.Length && 
                        memcmp(gCfgMsg16To10_List[pos].cmd, cmd, cmd.Length) == 0)
                    {
                        //先删除相同的指令码
                        gCfgMsg16To10_List.RemoveAt(pos);
                    }
                }
                if (val.Length < 3)
                    return;

                CfgMsg16To10_t p = new CfgMsg16To10_t();
                p.cmd = cmd;
                p.pos = new pos_t[val.Length - 2];
                for (int i = 2; i < val.Length; i++)
                {
                    string[] pos = val[i].Split('-');
                    if (pos[0] == "h" || pos[0] == "H")
                        p.pos[i - 2].msb_flag = true;
                    else
                        p.pos[i - 2].msb_flag = false;
                    p.pos[i - 2].head = Convert.ToInt32(pos[1]);
                    p.pos[i - 2].length = Convert.ToInt32(pos[2]);
                    if (p.pos[i - 2].length > 8 || p.pos[i - 2].length < 1 || pos.Length < 3)
                        goto CfgMsg16To10_ERROR;
                    p.param_num++;
                }
                p.min_length = p.pos[p.param_num - 1].head + p.pos[p.param_num - 1].length;
                gCfgMsg16To10_List.Add(p);
                指令规则清空ToolStripMenuItem.Text = "清空指令规则";
                return;
            }
            catch
            {
            }
        CfgMsg16To10_ERROR:
            richTextBox_Rx.AppendText(System.Environment.NewLine);
            richTextBox_Rx.AppendText("错误，参考：cfg,12,h-2-4");
            richTextBox_Rx.AppendText(System.Environment.NewLine);
            richTextBox_Rx.AppendText("表示匹配0x12，从第2个字节开始，连续4个字节，高字节在前合成10进制数");
        }

        /// <summary>
        /// 16进制计算器
        /// </summary>
        /// <param name="val"></param>
        private void Calculator(string [] val)
        {
            int pos = 0;
            string cacl = "";
            try
            {
                string[] number = val[1].ToUpper().Split('+', '-', '*', '/');
                for (int i = 0; i < number.Length; i++)
                {
                    if (number[i][0] == 'X')
                    {
                        cacl += Convert.ToUInt64(number[i].Substring(1), 16).ToString();
                    }
                    else
                        cacl += number[i];
                    pos += number[i].Length;
                    if (pos < val[1].Length)
                    {
                        cacl += val[1][pos++];
                    }
                }
                var test = new System.Data.DataTable().Compute(cacl, "");
                int temp = Convert.ToInt32(Math.Floor(Convert.ToDouble(test)));
                richTextBox_Rx.SelectionColor = Color.Gold;
                richTextBox_Rx.AppendText(" = " + test.ToString() + ", 0x" + temp.ToString("X"));
                richTextBox_Rx.SelectionColor = Color.White;
            }
            catch
            { }
        }

        /// <summary>
        /// 计算校验和，累加取反
        /// </summary>
        /// <param name="val"></param>
        private void CalcCheckSum(string []val)
        {
            try
            {
                if (val[1].ToUpper() != "CS")
                    return;
                byte[] data = StringToByte("HEX", val[2]);
                if (data == null)
                    return;
                int cs = 0;
                foreach(byte p in data)
                {
                    cs += p;
                }
                cs = (~cs) & 0xFF;
                richTextBox_Rx.AppendText(System.Environment.NewLine + "CheckSum = 0x" + cs.ToString("X"));
            }
            catch { }
        }

        /// <summary>
        /// 默认转换成ASCII
        /// </summary>
        /// <param name="val"></param>
        private void ASCII与HEX互转(string[] val)
        {
            try
            {
                string data_type = "HEX";
                string new_type = "ASCII";
                if (val[1].ToUpper() == "HEX")
                {
                    data_type = "ASCII";
                    new_type = "HEX";
                }
                byte[] t = StringToByte(data_type, val[2]);
                if (t == null)
                    return;
                string str = ByteToString(new_type, t, t.Length);
                richTextBox_Rx.AppendText(System.Environment.NewLine + str);
            }
            catch { }
        }

        /// <summary>
        /// 获取系统资料的操作
        /// </summary>
        /// <param name="val"></param>
        private void GetCMD(string [] val)
        {
            if (val.Length < 2)
                return;
            switch(val[1].ToUpper())
            {
                case "C运算符":
                    ShowC运算符();
                    break;
                case "ASCII":
                    ShowASCII();
                    break;
            }
        }

        private void ShowC运算符()
        {
            richTextBox_Rx.AppendText(System.Environment.NewLine +
                "优先级  运算符    含义                运算类型  结合性\r\n" +
                "  ----------------------------------------------------\r\n" +
                "  1     ()        圆括号、函数参数表  单目      左向右\r\n" +
                "        []        数组元素下标        双目            \r\n" +
                "        ->        指向结构体成员                      \r\n" +
                "        .         引用结构体成员                      \r\n" +
                "  ----------------------------------------------------\r\n" +
                "  2     !         逻辑非              单目      右向左\r\n" +
                "        ~         按位取反                            \r\n" +
                "        ++、--    增1、减1                            \r\n" +
                "        -         取负                                \r\n" +
                "        *         指针取值                            \r\n" +
                "        &         取地址                              \r\n" +
                "        (类型)    强制类型转换                        \r\n" +
                "        sizeof    取占用内存的大小                    \r\n" +
                "  ----------------------------------------------------\r\n" +
                "  3     *、/、%   乘、除、整数取余    双目      左向右\r\n" +
                "  ----------------------------------------------------\r\n" +
                "  4     +、-      加、减              双目      左向右\r\n" +
                "  ----------------------------------------------------\r\n" +
                "  5     <<、>>    左移、右移          双目      左向右\r\n" +
                "  ----------------------------------------------------\r\n" +
                "  6     <、<=     小于、小于等于      双目      左向右\r\n" +
                "        >、>=     大于、大于等于                      \r\n" +
                "  ----------------------------------------------------\r\n" +
                "  7     ==、!=    等于、不等于        双目      左向右\r\n" +
                "  ----------------------------------------------------\r\n" +
                "  8     &         按位与              双目      左向右\r\n" +
                "  ----------------------------------------------------\r\n" +
                "  9     ^         按位异或            双目      左向右\r\n" +
                "  ----------------------------------------------------\r\n" +
                "  10    |         按位或              双目      左向右\r\n" +
                "  ----------------------------------------------------\r\n" +
                "  11    &&        逻辑与              双目      左向右\r\n" +
                "  ----------------------------------------------------\r\n" +
                "  12    ||        逻辑或              双目      左向右\r\n" +
                "  ----------------------------------------------------\r\n" +
                "  13    ?:        条件                三目      右向左\r\n" +
                "  ----------------------------------------------------\r\n" +
                "  14    =         赋值                双目      右向左\r\n" +
                "        +=、-=    加后、减后赋值                      \r\n" +
                "        *=、/=    乘后、除后赋值                      \r\n" +
                "        %=        取模后赋值                          \r\n" +
                "        &=        按位与后                            \r\n" +
                "        |=        按位或后赋值                        \r\n" +
                "        ^=        按位异或后赋值                      \r\n" +
                "        <<=、>>=  左移、右移后赋值                    \r\n" +
                "  ----------------------------------------------------\r\n" +
                "  15    ,         逗号                -         左向右\r\n");
        }
        private void ShowASCII()
        {
            richTextBox_Rx.AppendText(System.Environment.NewLine +
                "DEC HEX 字符  DEC HEX 字符  DEC HEX 字符  DEC HEX 字符\r\n" +
                " -----------------------------------------------------\r\n" +
                "  0   0  \\0    32  20        64  40   @    96  60   `  \r\n" +
                "  1   1  SOH   33  21   !    65  41   A    97  61   a  \r\n" +
                "  2   2  STX   34  22   \"    66  42   B    98  62   b  \r\n" +
                "  3   3  ETX   35  23   #    67  43   C    99  63   c  \r\n" +
                "  4   4  EOT   36  24   $    68  44   D   100  64   d  \r\n" +
                "  5   5  ENQ   37  25   %    69  45   E   101  65   e  \r\n" +
                "  6   6  ACK   38  26   &    70  46   F   102  66   f  \r\n" +
                "  7   7  \\a    39  27   '    71  47   G   103  67   g  \r\n" +
                "  8   8  \\b    40  28   (    72  48   H   104  68   h  \r\n" +
                "  9   9  \\t    41  29   )    73  49   I   105  69   i  \r\n" +
                " 10   A  \\n    42  2A   *    74  4A   J   106  6A   j  \r\n" +
                " 11   B  \\v    43  2B   +    75  4B   K   107  6B   k  \r\n" +
                " 12   C  \\f    44  2C   ,    76  4C   L   108  6C   l  \r\n" +
                " 13   D  \\r    45  2D   -    77  4D   M   109  6D   m  \r\n" +
                " 14   E  SO    46  2E   .    78  4E   N   110  6E   n  \r\n" +
                " 15   F  SI    47  2F   /    79  4F   O   111  6F   o  \r\n" +
                " 16  10  DLE   48  30   0    80  50   P   112  70   p  \r\n" +
                " 17  11  DC1   49  31   1    81  51   Q   113  71   q  \r\n" +
                " 18  12  DC2   50  32   2    82  52   R   114  72   r  \r\n" +
                " 19  13  DC3   51  33   3    83  53   S   115  73   s  \r\n" +
                " 20  14  DC4   52  34   4    84  54   T   116  74   t  \r\n" +
                " 21  15  NAK   53  35   5    85  55   U   117  75   u  \r\n" +
                " 22  16  SYN   54  36   6    86  56   V   118  76   v  \r\n" +
                " 23  17  ETB   55  37   7    87  57   W   119  77   w  \r\n" +
                " 24  18  CAN   56  38   8    88  58   X   120  78   x  \r\n" +
                " 25  19  EM    57  39   9    89  59   Y   121  79   y  \r\n" +
                " 26  1A  SUB   58  3A   :    90  5A   Z   122  7A   z  \r\n" +
                " 27  1B  \\e    59  3B   ;    91  5B   [   123  7B   {  \r\n" +
                " 28  1C  FS    60  3C   <    92  5C   \\   124  7C   |  \r\n" +
                " 29  1D  GS    61  3D   =    93  5D   ]   125  7D   }  \r\n" +
                " 30  1E  RS    62  3E   >    94  5E   ^   126  7E   ~  \r\n" +
                " 31  1F  US    63  3F   ?    95  5F   _   127  7F   DEL\r\n");
        }


        private byte[] StringToByte(string data_type, string data)
        {
            try
            {
                byte[] buf;
                if (data_type == "ASCII")
                {
                    buf = Encoding.Default.GetBytes(data);
                }
                else
                {
                    int i = 0, length, len;
                    //string pattern = @"\s";
                    string replacement = "";
                    Regex rgx = new Regex(@"\s");
                    string str = rgx.Replace(data, replacement);

                    length = (str.Length - str.Length % 2) / 2;
                    len = length;
                    if (str.Length % 2 != 0)
                        len++;
                    buf = new byte[len];
                    //逐个字符变为16进制字节数据
                    for (i = 0; i < length; i++)
                    {
                        buf[i] = Convert.ToByte(str.Substring(i * 2, 2), 16);
                    }
                    if (str.Length % 2 != 0)
                    {
                        buf[i] = Convert.ToByte(str.Substring(i * 2, 1), 16);
                        length++;
                    }
                }
                return buf;
            }
            catch { }
            return null;
        }

        private string ByteToString(string data_type, byte[] data, int length)
        {
            try
            {
                string s = "";
                if (data_type == "ASCII")
                {
                    s = Encoding.Default.GetString(data, 0, length);
                }
                else
                {
                    s = BitConverter.ToString(data.Skip(0).Take(length).ToArray()).Replace("-", " ");
                }
                return s;
            }
            catch { }
            return "";
        }
    }
}

