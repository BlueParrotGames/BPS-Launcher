using System.Net.Sockets;
using System.Collections.Generic;

using BPS.Launcher.Networking.Utility;

namespace BPS.Launcher.Networking.Data.Handlers
{
    public class PacketHandler
    {
        private ByteBuffer _buffer;
        public Queue<ClientNetworkPackage> PackageQueue;

        public PacketHandler()
        {
            PackageQueue = new Queue<ClientNetworkPackage>();
            _buffer = new ByteBuffer();
        }

        public void QueuePackage(byte[] data, Socket socket)
        {
            _buffer.Clear();
            _buffer.WriteBytes(data);

            int packetSize = _buffer.ReadInt();
            int packetType = _buffer.ReadInt();

            PackageQueue.Enqueue(NetworkPacketPool.GetInstance().GetPacket((PacketType)packetType, socket, _buffer.ReadBytes(_buffer.Length())));
        }

        public bool HasPackets
        {
            get { return PackageQueue.Count > 0; }
        }
    }
}
