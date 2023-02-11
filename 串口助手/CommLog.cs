using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 串口助手
{
    class CommLog
    {
        private string gLogFileName = null;
        public void Button_log_Click(object sender, EventArgs e)
        {
            ToolStripButton button = sender as ToolStripButton;
            if (button.ToolTipText == "记录log")
            {
                SaveFileDialog log = new SaveFileDialog();
                //log.InitialDirectory = "D:\\"; //默认路径
                log.Filter = "log|*.log|文本|*.txt";
                log.FileName = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-s");
                if (log.ShowDialog() == DialogResult.OK)
                {
                    button.ToolTipText = "关闭log";
                    button.BackColor = Color.LimeGreen;
                    gLogFileName = log.FileName;
                    StreamWriter stream = new StreamWriter(gLogFileName);
                    stream.WriteLine("串口助手LOG");
                    stream.WriteLine(DateTime.Now.ToString("yyyy-MM-dd-HH-mm-s"));
                    stream.WriteLine("******************************");
                    stream.Flush();
                    stream.Close();
                }
            }
            else
            {
                button.ToolTipText = "记录log";
                button.BackColor = Color.Transparent;
                gLogFileName = null;
            }
        }

        public void LogWriteMsg(string msg)
        {
            if (gLogFileName == null)
                return;
            StreamWriter stream = new StreamWriter(gLogFileName, true);
            stream.WriteLine(msg);
            stream.Flush();
            stream.Close();
        }

    }
}
