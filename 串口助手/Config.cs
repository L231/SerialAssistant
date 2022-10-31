using System;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Collections.Generic;

namespace IniFile
{
    class Config
    {
        [System.Runtime.InteropServices.DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string path);
        [System.Runtime.InteropServices.DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, System.Text.StringBuilder retVal, int size, string path);

        string gSysCfgInfoPath = @".\sys_config.ini";
        public string TxListPath = @".\TxList.ini";
        public int TxListNum = 64;
        public CheckBox[] Checkbox = new CheckBox[1];
        public Button[] Button = new Button[1];
        public TextBox[] TextboxTX = new TextBox[1];
        public TextBox[] TextboxTimer = new TextBox[1];

        bool TextboxTXClickBypass = false;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="section"></param>
        /// <param name="key"></param>
        /// <param name="val"></param>
        /// <param name="path"></param>
        public void IniWrite(string section, string key, string val, string path)
        {
            if (!File.Exists(path))
            {
                FileStream ini = File.Create(path);
                ini.Close();
            }
            WritePrivateProfileString(section, key, val, path);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="section"></param>
        /// <param name="key"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public string IniRead(string section, string key, string path)
        {
            System.Text.StringBuilder temp = new System.Text.StringBuilder(256);
            GetPrivateProfileString(section, key, "", temp, 256, path);
            return temp.ToString();
        }
        public void SysCfgFileWrite(string section, string key, string val)
        {
            IniWrite(section, key, val, gSysCfgInfoPath);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="section"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public string SysCfgFileRead(string section, string key)
        {
            return IniRead(section, key, gSysCfgInfoPath);
        }

        public bool SysCfgFileExists()
        {
            return File.Exists(gSysCfgInfoPath);
        }

        public int TxList_GetNum(string path)
        {
            TxListNum = 64;
            try
            {
                string num = IniRead("基本配置", "TableTxNum", path);
                if (num == "")
                    TxListNum = 64;
                else if (Convert.ToInt32(num) > 100)
                    TxListNum = 100;
                else
                    TxListNum = Convert.ToInt32(num);
            }
            catch
            { }
            return TxListNum;
        }
        public void TableTxCreate(TableLayoutPanel table1, TableLayoutPanel table2)
        {
            Checkbox = new CheckBox[TxListNum];
            Button = new Button[TxListNum];
            TextboxTX = new TextBox[TxListNum];
            TextboxTimer = new TextBox[TxListNum];
            table1.Controls.Clear();
            table2.Controls.Clear();
            table1.RowCount = TxListNum;
            table2.RowCount = TxListNum;
            table1.Size = new Size(161, (20 * TxListNum) + 2);
            table2.Size = new Size(77, (20 * TxListNum) + 2);
            //table1.Height = (20 * TxListNum) + 2;
            Color color = Color.Transparent;
            for (int i = 0; i < TxListNum; i++)
            {
                if ((i & 0x1) == 0x1)
                    color = Color.LightGray;
                else
                    color = Color.White;
                Button[i] = new Button();
                Button[i].Margin = new Padding(0, 0, 0, 0);
                Button[i].Name = "1225yl";
                Button[i].Dock = DockStyle.Fill;
                Button[i].AutoSize = true;
                Button[i].TabStop = false;

                TextboxTimer[i] = new TextBox();
                TextboxTimer[i].BackColor = color;
                TextboxTimer[i].Margin = new Padding(0, 0, 0, 0);
                TextboxTimer[i].Name = "1225";
                TextboxTimer[i].Dock = DockStyle.Fill;
                TextboxTimer[i].AutoSize = true;
                //TextboxTimer[i].Multiline = true;
                TextboxTimer[i].MaxLength = 5;
                TextboxTimer[i].TabIndex = 200 + i;

                TextboxTX[i] = new TextBox();
                TextboxTX[i].BackColor = color;
                TextboxTX[i].Margin = new Padding(0, 0, 0, 0);
                TextboxTX[i].Name = "1225yl";
                TextboxTX[i].Dock = DockStyle.Fill;
                TextboxTX[i].AutoSize = true;
                TextboxTX[i].Multiline = true;
                TextboxTX[i].WordWrap = false;
                //TextboxTX[i].AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                //TextboxTX[i].AutoCompleteSource = AutoCompleteSource.CustomSource;
                //TextboxTX[i].AutoCompleteCustomSource.AddRange(autocompsource);
                TextboxTX[i].TabIndex = TextboxTimer[i].TabIndex + TxListNum;
                TextboxTX[i].MouseDoubleClick += new MouseEventHandler(TextboxTX_MouseDoubleClick);

                Checkbox[i] = new CheckBox();
                Checkbox[i].BackColor = color;
                Checkbox[i].Margin = new Padding(1, 1, 0, 0);
                Checkbox[i].Dock = DockStyle.Fill;
                Checkbox[i].TabStop = false;
                //Checkbox[i].Checked = false;

                table1.Controls.Add(Checkbox[i], 0, i);
                table1.Controls.Add(TextboxTimer[i], 1, i);
                table1.Controls.Add(TextboxTX[i], 2, i);
                table2.Controls.Add(Button[i]);
            }
        }
        public int TxListFirstLoad()
        {
            try
            {
                string[] val = new string[4];
                for (int i = 0; i < TxListNum; i++)
                {
                    val = IniRead("发送区", "TableTx" + (i + 1).ToString(), TxListPath).Split(',');
                    Checkbox[i].Checked = Convert.ToBoolean(val[0]);
                    TextboxTimer[i].Text = val[1];
                    TextboxTX[i].Text = val[2].Replace("\\n", "\r\n");
                    TextboxTX[i].Text = TextboxTX[i].Text.Replace(";", ",");
                    Button[i].Text = val[3];
                }
                return TxListNum;
            }
            catch { }
            return TxListNum;
        }
        public int TxListLoad(TableLayoutPanel table1, TableLayoutPanel table2)
        {
            OpenFileDialog TxListFileInfo = new OpenFileDialog();
            if(TxListPath == @".\TxList.ini")
                TxListFileInfo.InitialDirectory = Directory.GetCurrentDirectory();
            else
                TxListFileInfo.InitialDirectory = Path.GetDirectoryName(TxListPath);
            TxListFileInfo.Filter = "ini|*.ini";
            if (TxListFileInfo.ShowDialog() == DialogResult.OK)
            {
                TxListPath = TxListFileInfo.FileName;
                TxList_GetNum(TxListPath);
                TableTxCreate(table1, table2);
                return TxListFirstLoad();
            }
            return 0;
        }
        public void TxListSave(string num)
        {
            IniWrite("基本配置", "TableTxNum", num, TxListPath);
            for(int i = 0; i < TxListNum; i++)
            {
                string txmsg = TextboxTX[i].Text;
                txmsg = txmsg.Replace("\r\n", "\\n");
                txmsg = txmsg.Replace(",", ";");
                string str = Checkbox[i].Checked.ToString() + "," + TextboxTimer[i].Text + "," +
                    txmsg + "," + Button[i].Text;
                IniWrite("发送区", "TableTx" + (i + 1).ToString(), str, TxListPath);
            }
        }
        public void TxListOtherSave(string num)
        {
            SaveFileDialog TxListFileInfo = new SaveFileDialog();
            if (TxListPath == @".\TxList.ini")
                TxListFileInfo.InitialDirectory = Directory.GetCurrentDirectory();
            else
                TxListFileInfo.InitialDirectory = Path.GetDirectoryName(TxListPath);
            TxListFileInfo.Filter = "ini|*.ini";
            TxListFileInfo.FileName = "TxList";
            if (TxListFileInfo.ShowDialog() == DialogResult.OK)
            {
                TxListPath = TxListFileInfo.FileName;
                TxListSave(num);
            }
        }
        public bool TxListNewCreate(TableLayoutPanel table1, TableLayoutPanel table2, string num)
        {
            SaveFileDialog TxListFileInfo = new SaveFileDialog();
            if (TxListPath == @".\TxList.ini")
                TxListFileInfo.InitialDirectory = Directory.GetCurrentDirectory();
            else
                TxListFileInfo.InitialDirectory = Path.GetDirectoryName(TxListPath);
            TxListFileInfo.Filter = "ini|*.ini";
            TxListFileInfo.FileName = "TxList";
            if (TxListFileInfo.ShowDialog() == DialogResult.OK)
            {
                TxListPath = TxListFileInfo.FileName;
                IniWrite("基本配置", "TableTxNum", num, TxListPath);
                TableTxCreate(table1, table2);
                return true;
            }
            return false;
        }


        private void TextboxTX_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (TextboxTXClickBypass)
                return;
            int i = 0;
            TextBox yltb = sender as TextBox;
            for (; i < TxListNum; i++)
            {
                if (yltb == TextboxTX[i])
                    break;
            }
            Button[i].Text = TextboxTX[i].Text;
            TextboxTX[i].Text = "";
        }

        public void TextboxTXClickBypassCfg(bool status)
        {
            TextboxTXClickBypass = status;
        }

    }
}
