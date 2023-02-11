using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Drawing;
using System.Windows.Forms;
using System.Net.Sockets;

namespace 串口助手
{
    public partial class Form1
    {
        bool gBootloaderFlag = false;
        Thread threadBootloaderFile = null;
        Thread threadBootloader = null;
        Thread threadBootloaderDownload = null;
        Thread threadBootloaderErase = null;


        byte[] FirmwareBuf = new byte[1024 * 1024 * 2];
        uint FirmwareStartAddr = 0;
        int FirmwareSize = 0;
        int MCUAppSize = 0;
        int FirmwarePackSize = 0;
        int MCUbit = 2;


        private void BootloaderTx(byte[] data, int length)
        {
            if (masterComm.type == "TCP Client")
                masterComm.tcp.Send(data, 0, length, SocketFlags.None);
            else
            {
                masterComm.uart.Write(data, 0, length);
            }
        }
        private void ComClearRx()
        {
            byte[] buf = new byte[4096];
            try
            {
                if (masterComm.type == "TCP Client")
                {
                    masterComm.tcp.ReceiveTimeout = 1;
                    masterComm.tcp.Receive(buf);
                }
                else
                {
                    buf = new byte[masterComm.uart.BytesToRead];
                    masterComm.uart.ReadTimeout = 1;
                    masterComm.uart.Read(buf, 0, buf.Length);
                }
            }
            catch
            { }
        }
        private int BootloaderRx(byte[] buf)
        {
            try
            {
                int length = 0;
                if (masterComm.type == "TCP Client")
                {
                    masterComm.tcp.ReceiveTimeout = 1000;
                    length = masterComm.tcp.Receive(buf);
                }
                else
                {
                    length = masterComm.uart.BytesToRead;
                    masterComm.uart.Read(buf, 0, length);
                }
                return length;
            }
            catch
            { }
            return 0;
        }

        private void BootloaderStatusShow(string text)
        {
            richTextBox_HexShow.AppendText(DateTime.Now.ToString("HH:mm:ss.fff") + ">>" + text + System.Environment.NewLine);
            richTextBox_HexShow.ScrollToCaret();
        }

        public void FirmwareFileRead()
        {
            #region Firmware文件解析
            bool fwStartAddrFlag = false;
            string szLine;
            uint startAddr = 0;   //指示新行数据的首地址
            uint endAddr = 0;     //记录上次读取到的位置
            uint lineLen;
            string DataType;

            toolStripComboBox_LoaderFile.Enabled = false;
            toolStripButton_OpenFile.Enabled = false;
            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();
            richTextBox_HexShow.Text = "";
            FirmwareSize = 0;
            if (toolStripComboBox_LoaderFile.Text == "")
                return;
            FileStream fsRead = new FileStream(toolStripComboBox_LoaderFile.Text, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader HexRead = new StreamReader(fsRead);
            while (true)
            {
                szLine = HexRead.ReadLine();
                if (szLine == null)
                    break;
                if (szLine.Substring(0, 1) == ":")
                {
                    if (szLine.Substring(1, 8) == "00000001")
                        break;
                    if (szLine.Substring(1, 8) == "02000004")
                    {
                        startAddr &= 0xFFFF;
                        startAddr |= (Convert.ToUInt32(szLine.Substring(9, 4), 16) << 16);
                        if (endAddr == 0)
                        {
                            endAddr = startAddr;
                        }
                    }
                    DataType = szLine.Substring(8, 1);
                    if ((DataType == "0") || (DataType == "1"))
                    {
                        lineLen = Convert.ToUInt32(szLine.Substring(1, 2), 16);
                        startAddr &= 0xFFFF0000;
                        startAddr |= Convert.ToUInt32(szLine.Substring(3, 4), 16);
                        if (fwStartAddrFlag == false)
                        {
                            FirmwareStartAddr = startAddr;
                            fwStartAddrFlag = true;
                        }
                        /* 补全地址的数据（新行数据的首地址 > 上次读完的地址） */
                        switch (MCUbit)
                        {
                            case 0:
                                /* 8位单片机 */
                                for (uint i = 0; i < startAddr - endAddr; i++)
                                {
                                    if ((i & 0x01) == 1)
                                    {
                                        FirmwareBuf[FirmwareSize++] = 0x3F;
                                    }
                                    else
                                        FirmwareBuf[FirmwareSize++] = 0xFF;
                                }
                                break;
                            case 1:
                                /* 16位单片机 */
                                for (uint i = 0, cnt = 1; i < startAddr - endAddr; i++, cnt++)
                                {
                                    if ((cnt & 0x03) == 0)
                                    {
                                        FirmwareBuf[FirmwareSize++] = 0;
                                    }
                                    else
                                        FirmwareBuf[FirmwareSize++] = 0xFF;
                                }
                                break;
                            default:
                                /* 32位单片机 */
                                for (uint i = 0; i < startAddr - endAddr; i++)
                                {
                                    FirmwareBuf[FirmwareSize++] = 0xFF;
                                }
                                break;
                        }
                        for (int i = 0; i < lineLen; i++)
                        {
                            FirmwareBuf[FirmwareSize++] = Convert.ToByte(szLine.Substring((i << 1) + 9, 2), 16);
                        }
                        endAddr = startAddr + lineLen;
                    }
                }
            }
            for (int pack = 0; pack < FirmwareSize; pack += 16384)
            {
                int pos = pack + 16384;
                if (pos > FirmwareSize)
                    pos = FirmwareSize;
                string s = "";
                for (int i = pack; i < pos; i += 16)
                {
                    s += (("[" + (FirmwareStartAddr + i).ToString("X8") + "]  ")
                        + (BitConverter.ToString((FirmwareBuf.Skip(i).Take(8).ToArray())).Replace("-", " ") + "  ")
                        + BitConverter.ToString((FirmwareBuf.Skip(i + 8).Take(8).ToArray())).Replace("-", " ")
                        + System.Environment.NewLine);
                }
                richTextBox_HexShow.AppendText(s);
                richTextBox_HexShow.ScrollToCaret();
            }
            fsRead.Flush();
            fsRead.Close();
            HexRead.Close();
            stopwatch.Stop();
            TimeSpan timeSpan = stopwatch.Elapsed;
            if ((FirmwareSize / 1024) > MCUAppSize)
            {
                button_Download.Enabled = false;
                button_Erase.Enabled = false;
                button_Uploading.Enabled = false;
                BootloaderStatusShow("固件过大，Size = " + (FirmwareSize / 1024.0).ToString("f3") + "KB");
            }
            else
            {
                BootloaderStatusShow("已加载，Size = " + (FirmwareSize / 1024.0).ToString("f3") + "KB");
            }
            BootloaderStatusShow("总用时：" + timeSpan.TotalSeconds.ToString("f3") + System.Environment.NewLine);
            toolStripButton_OpenFile.Enabled = true;
            toolStripComboBox_LoaderFile.Enabled = true;
            threadBootloaderFile.Abort();
            #endregion
        }

        private void toolStripComboBox_LoaderFile_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (toolStripComboBox_LoaderFile.Enabled)
            {
                toolStripComboBox_LoaderFile.Enabled = false;
                threadBootloaderFile = new Thread(FirmwareFileRead);
                threadBootloaderFile.IsBackground = true;
                threadBootloaderFile.Start();
            }
        }

        private void toolStripButton_OpenFile_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog_Download.ShowDialog() == DialogResult.OK)
            {
                toolStripComboBox_LoaderFile.Enabled = false;
                toolStripComboBox_LoaderFile.Text = "";
                toolStripComboBox_LoaderFile.Text = this.openFileDialog_Download.FileName;
                if (toolStripComboBox_LoaderFile.Items.Contains(toolStripComboBox_LoaderFile.Text) == false)
                    toolStripComboBox_LoaderFile.Items.Add(toolStripComboBox_LoaderFile.Text);
                threadBootloaderFile = new Thread(FirmwareFileRead);
                threadBootloaderFile.IsBackground = true;
                threadBootloaderFile.Start();
            }
        }

        private void FirmwareToArraySave(string path)
        {
            int temp = FirmwareSize - (FirmwareSize % 16);
            string s = System.Environment.NewLine + "uint8_t gFirmware[" + FirmwareSize + "] = {";
            s += (System.Environment.NewLine);
            int startpos = s.Length;
            s += ("  0x" + BitConverter.ToString(FirmwareBuf.Skip(0).Take(FirmwareSize).ToArray()).Replace("-", ", 0x"));
            for (int pos = startpos + 97; pos < s.Length; pos += (99))
                s = s.Insert(pos, System.Environment.NewLine + " ");
            s += (System.Environment.NewLine + "}" + System.Environment.NewLine + System.Environment.NewLine);
            StreamWriter stream = new StreamWriter(path);
            stream.Write(s);
            stream.Flush();
            stream.Close();

        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (saveFileDialog_Firmware.ShowDialog() == DialogResult.OK)
            {
                FirmwareToArraySave(saveFileDialog_Firmware.FileName);
            }
        }
        private byte CheckSum(byte[] cmd, int len)
        {
            int cs = 0;
            for (int i = 0; i < len; i++)
                cs += cmd[i];
            byte c = (byte)(0xFF - (cs & 0xFF));
            return c;
        }
        private void BootloaderOn()
        {
            byte[] bootin = { 0x5B, 0xAB, 0x01, 0x01, 0x0A };
            byte[] auto_baudrate = { 0x55 };
            byte[] connect = { 0xAA, 0x0A };
            byte[] ack = new byte[12];
            ack[0] = 0xFF;
            int errCnt = 0;
            while (true)
            {
                if (toolStripButton_BootOn.Text == "GOTO_BOOT")
                {
                    threadBootloader.Abort();
                    return;
                }
                /* 进入Bootloader */
                bootin[2] = Convert.ToByte(toolStripComboBox_MCU.Text);
                bootin[bootin.Length - 1] = CheckSum(bootin, bootin.Length - 1);
                BootloaderTx(bootin, bootin.Length);
                Thread.Sleep(100);
                if (errCnt++ > 50)
                    Thread.Sleep(1000);
                /* 发送自动波特率检测帧 */
                BootloaderTx(auto_baudrate, 1);
                Thread.Sleep(50);
                ComClearRx();

                connect[connect.Length - 1] = CheckSum(connect, connect.Length - 1);
                BootloaderTx(connect, connect.Length);
                Thread.Sleep(100);
                //收到的回复，长度不对、报头不对、校验不通过
                if (BootloaderRx(ack) != ack.Length || 
                    ack[0] != 0xAA || 
                    ack[ack.Length - 1] != CheckSum(ack, ack.Length - 1))
                    continue;

                MCUAppSize = (int)ack[5] << 8 | ack[6];
                FirmwarePackSize = (int)ack[7] << 8 | ack[8];
                if (MCUAppSize == 0 || FirmwarePackSize == 0)
                    continue;
                button_Download.Enabled = true;
                button_Erase.Enabled = true;
                button_Uploading.Enabled = true;
                button_Run.Enabled = true;
                toolStripButton_BootOn.BackColor = Color.Lime;
                //toolStripButton_BootOn.Text = "运行";
                toolStripButton_BootOn.Text = "GOTO_BOOT";
                toolStripLabel_BootLinkStatus.BackColor = Color.LimeGreen;
                if (ack[9] != bootin[2])
                    toolStripLabel_BootLinkStatus.Text = (8 << ack[10]) + "位,MCU" + ack[9] + "进入BootLoader！" + "FlashPage:" + FirmwarePackSize;
                else
                    toolStripLabel_BootLinkStatus.Text = (8 << ack[10]) + "位,MCU" + ack[9] + ", FlashPage:" + FirmwarePackSize;
                /* 已加载文件，但不是采用当前MCU位数去解析 */
                if (MCUbit != ack[10] && toolStripComboBox_LoaderFile.Text != "")
                {
                    MCUbit = ack[10];
                    threadBootloaderFile = new Thread(FirmwareFileRead);
                    threadBootloaderFile.IsBackground = true;
                    threadBootloaderFile.Start();
                }
                MCUbit = ack[10];
                gBootloaderFlag = false;
                switch (MCUbit)
                {
                    case 0:
                        numericUpDown_Write.Value = 30;
                        numericUpDown_Read.Value = 30;
                        break;
                    case 1:
                        numericUpDown_Write.Value = 90;
                        numericUpDown_Read.Value = 400;
                        break;
                    case 2:
                        numericUpDown_Write.Value = 90;
                        numericUpDown_Read.Value = 400;
                        break;
                }

                threadBootloader.Abort();
            }
        }
        private void toolStripButton_BootOn_Click(object sender, EventArgs e)
        {
            if (toolStripButton_BootOn.Text == "GOTO_BOOT")
            {
                gBootloaderFlag = true;
                toolStripLabel_BootLinkStatus.Text = "";
                toolStripButton_BootOn.Text = "停止";
                toolStripButton_BootOn.BackColor = Color.Tomato;
                toolStripLabel_BootLinkStatus.Text = "连接中...";
                threadBootloader = new Thread(BootloaderOn);
                threadBootloader.IsBackground = true;
                threadBootloader.Start();
            }
            else if (toolStripButton_BootOn.Text == "停止")
            {
                gBootloaderFlag = false;
                toolStripLabel_BootLinkStatus.Text = "GOTO_BOOT ERROR";
                toolStripButton_BootOn.BackColor = Color.Lime;
                toolStripButton_BootOn.Text = "GOTO_BOOT";
                //threadBootloader.Abort();
            }
            //else if(toolStripButton_BootOn.Text == "运行")
            //{
            //    button_Run_Click(sender, e);
            //}
        }

        private void button_Run_Click(object sender, EventArgs e)
        {
            //int cnt = 5;
            byte[] cmd = { 0x5A, 0x5A, 0xA5, 0xA6 };
            progressBar_Firmware.Value = 0;
            ///* 连发几次，确保跳转 */
            //while (cnt-- > 0)
            //{
            //    BootloaderTx(cmd, cmd.Length);
            //    Thread.Sleep(50);
            //}
            BootloaderTx(cmd, cmd.Length);
            button_Download.Enabled = false;
            button_Erase.Enabled = false;
            button_Uploading.Enabled = false;
            toolStripButton_BootOn.Text = "GOTO_BOOT";
            toolStripLabel_BootLinkStatus.BackColor = Color.OrangeRed;
            toolStripLabel_BootLinkStatus.Text = "跳转APP";
            BootloaderStatusShow("跳转APP" + System.Environment.NewLine);
        }

        private void BootloaderCheck()
        {
            int ErrCnt = 0, AckLen = 0;
            byte[] ack = new byte[FirmwarePackSize + 3];
            byte[] cmd = { 0xA2, 0, 0, 0, 0, 0, 0, 0 };

            int delay = Convert.ToInt32(numericUpDown_Read.Value);
            BootloaderStatusShow("校验进行中...");
            progressBar_Firmware.Value = 0;
            progressBar_Firmware.Maximum = FirmwareSize;
            for (uint pack = 0; pack < FirmwareSize;)
            {
                /* 设置读取地址 */
                uint a = pack + FirmwareStartAddr;
                cmd[1] = (byte)(a >> 24);
                cmd[2] = (byte)(a >> 16);
                cmd[3] = (byte)(a >> 8);
                cmd[4] = (byte)(a >> 0);
                cmd[5] = (byte)(FirmwarePackSize >> 8);
                cmd[6] = (byte)(FirmwarePackSize >> 0);
                cmd[cmd.Length - 1] = CheckSum(cmd, cmd.Length - 1);
                ComClearRx();
                BootloaderTx(cmd, cmd.Length);
                //if(gComMode != "TCP Client")
                //    Thread.Sleep(450);
                //else
                Thread.Sleep(delay);
                AckLen = BootloaderRx(ack);

                int len = FirmwarePackSize;
                /* 最后一包数据 */
                if (pack + (uint)FirmwarePackSize > (uint)FirmwareSize)
                {
                    len = FirmwareSize - (int)pack;
                }
                string ackStr = Encoding.Default.GetString(ack, 2, len);
                string fwStr = Encoding.Default.GetString(FirmwareBuf, (int)pack, len);
                if (ackStr == fwStr)
                {
                    ErrCnt = 0;
                    pack += (uint)FirmwarePackSize;
                }
                else
                {
                    //delay += 50;
                    if (++ErrCnt >= 5)
                    {
                        BootloaderStatusShow("0x" + (a.ToString("X8")) + ":L" + (AckLen - 3) + System.Environment.NewLine);
                        //toolStripTextBox_BootReadDelay.Text = delay.ToString();
                        return;
                    }
                    continue;
                }
                if (progressBar_Firmware.Value + FirmwarePackSize > FirmwareSize)
                    progressBar_Firmware.Value = FirmwareSize;
                else
                {
                    progressBar_Firmware.Value += FirmwarePackSize;
                }
            }
            //toolStripTextBox_BootReadDelay.Text = delay.ToString();
            toolStripLabel_BootLinkStatus.Text = "烧录成功";
            BootloaderStatusShow("校验成功");
        }
        private void BootladerDownload()
        {
            int ErrCnt = 0, len = 3;
            uint packEnd = 7 + (uint)FirmwarePackSize;
            byte[] cmd = new byte[FirmwarePackSize + 8];

            int delay = Convert.ToInt32(numericUpDown_Write.Value);
            BootloaderStatusShow("烧录中，Size = " + (FirmwareSize / 1024.0).ToString("f3") + "KB");
            progressBar_Firmware.Value = 0;
            progressBar_Firmware.Maximum = FirmwareSize;
            while (true)
            {
                cmd[0] = 0xA1;
                for (uint pack = 0; pack < FirmwareSize;)
                {
                    /* 设置烧录地址 */
                    uint a = pack + FirmwareStartAddr;
                    cmd[1] = (byte)(a >> 24);
                    cmd[2] = (byte)(a >> 16);
                    cmd[3] = (byte)(a >> 8);
                    cmd[4] = (byte)(a >> 0);
                    cmd[5] = (byte)(FirmwarePackSize >> 8);
                    cmd[6] = (byte)(FirmwarePackSize >> 0);
                    /* 提取烧录数据 */
                    for (uint i = 7, addr = pack; i < packEnd; i++, addr++)
                    {
                        if (addr >= FirmwareSize)
                            FirmwareBuf[addr] = 0xFF;
                        cmd[i] = FirmwareBuf[addr];
                    }
                    cmd[cmd.Length - 1] = CheckSum(cmd, cmd.Length - 1);
                    ComClearRx();
                    BootloaderTx(cmd, cmd.Length);
                    Thread.Sleep(delay);
                    if (masterComm.type != "TCP Client")
                    {
                        len = masterComm.uart.BytesToRead;
                    }
                    byte[] ack = new byte[len];
                    if (len < 3)
                    {
                        if (++ErrCnt >= 5)
                        {
                            BootloaderStatusShow("0x" + (a.ToString("X8")) + ":应答异常" + System.Environment.NewLine);
                            goto THREAD_BOOTLOADER_DOWNLOAD_OFF;
                        }
                        continue;
                    }
                    ack[1] = 1;
                    BootloaderRx(ack);
                    if (ack[1] != 0 || ack[0] != 0xA1 || ack[2] != 0x5E)
                    {
                        //delay += 50;
                        if (++ErrCnt >= 5)
                        {
                            BootloaderStatusShow("0x" + (a.ToString("X8")) + ":Err" + ack[1] + System.Environment.NewLine);
                            goto THREAD_BOOTLOADER_DOWNLOAD_OFF;
                        }
                        continue;
                    }
                    else
                    {
                        ErrCnt = 0;
                        pack += (uint)FirmwarePackSize;
                    }
                    if (progressBar_Firmware.Value + FirmwarePackSize > FirmwareSize)
                        progressBar_Firmware.Value = FirmwareSize;
                    else
                    {
                        progressBar_Firmware.Value += FirmwarePackSize;
                    }
                }
                BootloaderStatusShow("烧录完毕");
                /* 上位机自动开启校验 */
                BootloaderCheck();
                break;
            }
        /* 关闭线程 */
        THREAD_BOOTLOADER_DOWNLOAD_OFF:
            //toolStripTextBox_BootWriteDelay.Text = delay.ToString();
            button_Download.Enabled = true;
            button_Run.Enabled = true;
            button_Run.BackColor = Color.Lime;
            gBootloaderFlag = false;
            threadBootloaderDownload.Abort();
        }
        private void button_Download_Click(object sender, EventArgs e)
        {
            gBootloaderFlag = true;
            button_Download.Enabled = false;
            button_Run.Enabled = false;
            button_Run.BackColor = Color.White;
            threadBootloaderDownload = new Thread(BootladerDownload);
            threadBootloaderDownload.IsBackground = true;
            threadBootloaderDownload.Start();
        }

        private void button_Uploading_Click(object sender, EventArgs e)
        {

        }
        private void BootloaderErase()
        {
            int time = 0;
            int len = 3;
            byte[] cmd = { 0xA3, 0, 0, 0, 0, 0 };
            BootloaderStatusShow("擦除中...");
            progressBar_Firmware.Value = 0;
            progressBar_Firmware.Maximum = FirmwareSize;

            cmd[cmd.Length - 1] = CheckSum(cmd, cmd.Length - 1);
            BootloaderTx(cmd, cmd.Length);
            while (true)
            {
                if (button_Erase.Text == "全擦")
                {
                    threadBootloaderErase.Abort();
                    return;
                }
                if (++time >= 2)
                {
                    time = 0;
                    BootloaderTx(cmd, cmd.Length);
                }
                Thread.Sleep(500);
                if (masterComm.type != "TCP Client")
                {
                    len = masterComm.uart.BytesToRead;
                    if (len == 0)
                    {
                        continue;
                    }
                }
                byte[] ack = new byte[len];
                ack[1] = 1;
                BootloaderRx(ack);
                if (ack[0] == 0xA3 && ack[1] == 0 && ack[2] == 0x5C)
                {
                    progressBar_Firmware.Value = FirmwareSize;
                    BootloaderStatusShow("擦除完毕");
                    gBootloaderFlag = false;
                    threadBootloaderErase.Abort();
                }
            }
        }
        private void button_Erase_Click(object sender, EventArgs e)
        {
            if (button_Erase.Text == "全擦")
            {
                gBootloaderFlag = true;
                button_Erase.Text = "停止";
                threadBootloaderErase = new Thread(BootloaderErase);
                threadBootloaderErase.IsBackground = true;
                threadBootloaderErase.Start();
            }
            else if (button_Erase.Text == "停止")
            {
                gBootloaderFlag = false;
                //threadBootloaderErase.Abort();
                button_Erase.Text = "全擦";
                BootloaderStatusShow("擦除异常！");
            }
        }

    }
}
