using System;
using System.Net;
using System.Threading;
using System.Net.Sockets;

using BPS.Launcher.Networking.Data.Handlers;
using BPS.Launcher.Networking.Data.Senders;
using BPS.Launcher.Networking.Data;

namespace BPS.Launcher.Networking
{
    public class Client : IDisposable
    {
        private Socket _socket;
        public string HashToken;

        //Data handlers
        private PacketHandler _packetHandler;
        private DataHandler _dataHandler;
        private NetworkSender _networkSender;
        private NetworkSendingQueue _sendingQueue;
        private NetworkSendingLoop _sendingLoop;

        protected readonly byte[] _buffer;

        private Thread _packetHandlingThread;
        private bool _isRunning;

        public Client(string ip, int port, int bufferSize)
        {
            ConnectUsingSettings(ip, port);

            _isRunning = true;
            _buffer = new byte[bufferSize];

            //Data Handlers
            _packetHandler = new PacketHandler();
            _dataHandler = new DataHandler();
            _sendingQueue = new NetworkSendingQueue();
            _networkSender = new NetworkSender(_sendingQueue);
            _sendingLoop = new NetworkSendingLoop(_sendingQueue);

            _packetHandlingThread = new Thread(PacketHandlingLoop);
            _packetHandlingThread.Start();

            BeginReceive();
        }
        private void ConnectUsingSettings(string ip, int port)
        {
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            _socket.BeginConnect(ip, port, new AsyncCallback(ConnectCallback), null);
        }
        private void ConnectCallback(IAsyncResult result)
        {
            _socket.EndConnect(result);

            if (!_socket.Connected)
            {
                _isRunning = false;
                //Could not connect to the server (error)
            }
        }

        protected void BeginReceive()
        {
            _socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), null);
        }
        private void ReceiveCallback(IAsyncResult result)
        {
            try
            {
                int readBytes = _socket.EndReceive(result);

                if (readBytes <= 0)
                {
                    //Received 0 bytes? (error)
                    CloseConnection(0);
                    return;
                }

                byte[] tempBuffer = new byte[readBytes];
                Buffer.BlockCopy(_buffer, 0, tempBuffer, 0, readBytes);

                if (readBytes > 0)
                    GetPacketOutOfStream(tempBuffer);

                BeginReceive();
            }
            catch
            {
                //Connection with the server has been forcibly closed! (error)
                CloseConnection(0);
            }
        }
        private void GetPacketOutOfStream(byte[] buffer)
        {
            int readPosition = 0;

            while (readPosition < buffer.Length)
            {
                int packetLength = BitConverter.ToInt32(buffer, readPosition) + sizeof(int);

                byte[] data = new byte[buffer.Length];
                Buffer.BlockCopy(buffer, readPosition, data, 0, data.Length);


                readPosition += data.Length;
            }
        }

        private void PacketHandlingLoop()
        {
            while (_isRunning)
            {
                if (_packetHandler.HasPackets)
                {
                    ClientNetworkPackage packet = _packetHandler.PackageQueue.Dequeue();

                    if (_dataHandler.Packets.TryGetValue((int)packet.PacketType, out DataHandler.Packet package))
                    {
                        package?.Invoke(packet);
                    }
                }
            }
        }

        protected void CloseConnection(int timeout)
        {
            _socket.Close(timeout);
        }

        public void Dispose()
        {
            _isRunning = false;
            _packetHandlingThread.Abort();

            CloseConnection(0);
        }

        public Socket Socket
        {
            get { return _socket; }
        }
    }
}
