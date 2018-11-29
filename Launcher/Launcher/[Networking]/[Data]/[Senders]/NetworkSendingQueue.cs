using System;
using System.Net.Sockets;
using System.Collections.Generic;

using BPS.Launcher.Networking.Utility;

namespace BPS.Launcher.Networking.Data.Senders
{
    public class NetworkSendingQueue : IDisposable
    {
        public Queue<SendingData> SendingQueue;

        public NetworkSendingQueue()
        {
            SendingQueue = new Queue<SendingData>();
        }

        public void QueuePackage(byte[] data, Socket socket)
        {
            ByteBuffer buffer = new ByteBuffer();
            buffer.WriteInt(data.Length);
            buffer.WriteBytes(data);

            SendingData sendData = new SendingData
            {
                Buffer = buffer,
                Socket = socket,
                ByteLength = data.Length
            };

            SendingQueue.Enqueue(sendData);
        }

        public void Dispose()
        {
            SendingQueue.Clear();
        }

        public bool HasPackets
        {
            get { return SendingQueue.Count > 0; }
        }
    }

    public struct SendingData
    {
        public ByteBuffer Buffer;
        public Socket Socket;
        public int ByteLength;
    }
}
