using System.Net.Sockets;

using BPS.Launcher.Networking.Utility;

namespace BPS.Launcher.Networking.Data.Senders
{
    public class NetworkSender
    {
        private static NetworkSendingQueue _queue;

        public NetworkSender(NetworkSendingQueue queue)
        {
            _queue = queue;
        }

        public static void SendPacket(ByteBuffer buffer, Socket socket)
        {
            _queue.QueuePackage(buffer.ToArray(), socket);
        }
        public static void SendPacket(byte[] data, Socket socket)
        {
            _queue.QueuePackage(data, socket);
        }
    }
}
