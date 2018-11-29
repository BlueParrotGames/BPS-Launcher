using System;
using System.Net.Sockets;

namespace BPS.Launcher.Networking.Data
{
    public interface INetworkPacket : IDisposable
    {
        void SetValues(PacketType packeType, Socket socket, byte[] data);
        void ReturnToPool();
    }
    public struct ClientNetworkPackage : INetworkPacket
    {
        public PacketType PacketType { get; internal set; }
        public Socket Socket { get; internal set; }
        public byte[] Data { get; internal set; }

        private NetworkPacketPool _packetPool;

        public ClientNetworkPackage(NetworkPacketPool packetPool)
        {
            PacketType = 0;
            Socket = null;
            Data = null;

            _packetPool = packetPool;
        }

        public void SetValues(PacketType packetType, Socket socket, byte[] data)
        {
            PacketType = packetType;
            Socket = socket;
            Data = data;
        }
        public void ReturnToPool()
        {
            _packetPool.AddPacket(this);
            Dispose();
        }

        public void Dispose()
        {
            Socket.Dispose();
            Data = null;
        }
    }
}
