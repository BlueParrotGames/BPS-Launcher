using System;
using System.Collections.Generic;

using BPS.Launcher.Networking.Utility;

namespace BPS.Launcher.Networking.Data.Handlers
{
    public class DataHandler
    {
        public delegate void Packet(ClientNetworkPackage package);

        private Dictionary<int, Packet> _packets;
        public Dictionary<int, Packet> Packets{ get => _packets; }

        private ByteBuffer _buffer;

        public DataHandler()
        {
            _packets = new Dictionary<int, Packet>();
            _buffer = new ByteBuffer();

            SetupNetworkPackets();
        }
        private void SetupNetworkPackets()
        {
            _packets.Add((int)PacketType.FriendListRequest, HandleFriendListRequest);
        }

        private void HandleFriendListRequest(ClientNetworkPackage package)
        {
            _buffer.Clear();
            _buffer.WriteBytes(package.Data);

            //Check if the verification Token is correct
            if(_buffer.ReadString() == NetworkManager.GetClient(package.Socket).HashToken)
            {

            }
        }
    }
}
