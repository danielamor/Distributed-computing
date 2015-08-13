using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;

namespace ClientTest
{
    class Sender
    {
        private Socket _clientSocket;
        private string ip;
        private int port;
        public Sender(string Ip, int Port)
        {
            ip = Ip;
            port = Port;
        }
        public void send(byte[] data)
        {
            try
            {
                _clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                _clientSocket.NoDelay = true;
                IPAddress ipAddress = IPAddress.Parse(ip);
                //Server is listening on port 1000
                IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, 1000);

                //Connect to the server
                _clientSocket.Connect(ipEndPoint);
                _clientSocket.BeginSend(data, 0, data.Length, SocketFlags.None, new AsyncCallback(OnSend), null);
            }
            catch { }
        }
        private void OnSend(IAsyncResult ar)
        {
            try
            {
                _clientSocket.EndSend(ar);
                _clientSocket.Close();
            }
            catch { }
        }
    }
}
