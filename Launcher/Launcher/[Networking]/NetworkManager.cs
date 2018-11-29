using System.Net.Sockets;
using System.Collections.Generic;

using BPS.Launcher.Networking.Utility.Security;

namespace BPS.Launcher.Networking
{
    public class NetworkManager
    {
        private Dictionary<Socket, Client> _onlineClients;
        private VerificationLogic _verificationLogic;

        private static NetworkManager _instance;

        NetworkManager()
        {
            _onlineClients = new Dictionary<Socket, Client>();
            _verificationLogic = new VerificationLogic();
        }

        public static void ConnectClient(string ip, int port, int bufferSize)
        {
            Client client = new Client(ip, port, bufferSize);
            Instance._verificationLogic.SetClientHash(client);

            Instance._onlineClients.Add(client.Socket, client);
        }
        public static Client GetClient(Socket socket)
        {
            if(Instance._onlineClients.TryGetValue(socket, out Client client))
            {
                return client;
            }

            return null;
        }

        private static NetworkManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new NetworkManager();

                return _instance;
            }
        }
    }
}
