using System.Net.Sockets;
using System.Collections.Generic;

namespace BPS.Launcher.Networking.Data
{
    public class NetworkPacketPool
    {
        private static NetworkPacketPool _instance;
        private Stack<ClientNetworkPackage> _packageQueue;

        NetworkPacketPool()
        {
            _packageQueue = new Stack<ClientNetworkPackage>();
        }

        public ClientNetworkPackage GetPacket()
        {
            if (_packageQueue.Count <= 0)
                CreatePacket();

            return _packageQueue.Pop();
        }
        public ClientNetworkPackage GetPacket(PacketType packetType, Socket socket, byte[] data)
        {
            if (_packageQueue.Count <= 0)
                CreatePacket();

            ClientNetworkPackage packet = _packageQueue.Pop();
            packet.SetValues(packetType, socket, data);

            return packet;
        }
        public void AddPacket(ClientNetworkPackage packet)
        {
            _packageQueue.Push(packet);
        }

        private void CreatePacket()
        {
            _packageQueue.Push(new ClientNetworkPackage(GetInstance()));
        }

        public static NetworkPacketPool GetInstance()
        {
            if (_instance == null)
                _instance = new NetworkPacketPool();

            return _instance;
        }
    }
}
