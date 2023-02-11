using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 串口助手
{
    class SocketClient
    {
        private ManualResetEvent timeoutObject = new ManualResetEvent(false);

        public bool Connect(Socket Client, IPEndPoint iPEndPoint, int timeout)
        {
            timeoutObject.Reset();
            //Client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Client.BeginConnect(iPEndPoint, new AsyncCallback(CallBackMethod), Client);
            if (timeoutObject.WaitOne(timeout, false))
                return true;
            Client.Close();
            return false;
        }

        private void CallBackMethod(IAsyncResult asyncResult)
        {
            Socket Client = (Socket)asyncResult.AsyncState;
            try
            {
                Client.EndConnect(asyncResult);
                timeoutObject.Set();
            }
            catch { }
        }
    }
}
