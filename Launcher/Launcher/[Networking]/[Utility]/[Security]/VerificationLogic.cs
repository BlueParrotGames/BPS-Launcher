using System;

using BPS.Launcher.Networking.Data;
using BPS.Launcher.Networking.Data.Senders;

namespace BPS.Launcher.Networking.Utility.Security
{
    class VerificationLogic
    {
        public void SetClientHash(Client client)
        {
            ByteBuffer buffer = new ByteBuffer();

            buffer.WriteInt((int)PacketType.HashVerification);
            string time = DateTime.UtcNow.Millisecond.ToString();
            string hash = CreateHash(time);
            buffer.WriteString(hash);

            client.HashToken = hash;

            NetworkSender.SendPacket(buffer, client.Socket);
        }

        private string CreateHash(string input)
        {
            string salt = input = input + "243s";
            string hashCode = string.Format("{0:X}", input.GetHashCode());

            return hashCode;
        }
    }
}
