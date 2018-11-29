using System;
using System.Threading;
using System.Net.Sockets;

namespace BPS.Launcher.Networking.Data.Senders
{
    public class NetworkSendingLoop : IDisposable
    {
        private readonly NetworkSendingQueue _sendingQueue;
        private bool _isSending;

        private Thread _sendingThreadOne;

        public NetworkSendingLoop(NetworkSendingQueue sendingQueue)
        {
            _sendingQueue = sendingQueue;

            _isSending = true;
            _sendingThreadOne = new Thread(CoreLoop);
            _sendingThreadOne.Start();
        }

        private void CoreLoop()
        {
            while (_isSending)
            {
                if (_sendingQueue.HasPackets)
                {
                    SendingData sendingData = _sendingQueue.SendingQueue.Dequeue();
                    sendingData.Socket.BeginSend(sendingData.Buffer.ToArray(), 0, sendingData.Buffer.Count(), SocketFlags.None, new AsyncCallback(SendCallback), null);
                }
            }
        }
        private void SendCallback(IAsyncResult result)
        {

        }

        public void Dispose()
        {
            _sendingThreadOne.Abort();
            _sendingQueue.Dispose();
        }
    }
}
