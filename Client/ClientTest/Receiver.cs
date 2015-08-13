/****************************************************************
 * Class:         Receiver                                      *
 * Author:        Amor Daniel                                   *
 * Description:   Receive data form multiple clients            *
 * Date:          23 may 2011                                   *
****************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace ClientTest
{
    class Receiver
    {
        /*Event when a data is received*/
        public delegate void received(string clientIP, byte[] data);
        public event received OnReceived;
        string clientIP;
        TcpListener tcpListener;
        public void StartReceiver(int listenPort)
        {
            IPAddress ipAddress = IPAddress.Any;
            tcpListener = new TcpListener(ipAddress, listenPort);
            /*Option to be able to use two listener at same time*/
            tcpListener.Server.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            Thread listenThread = new Thread(new ThreadStart(ListenForClients));
            listenThread.IsBackground = true;
            listenThread.Start();
        }
        private void ListenForClients()
        {
            this.tcpListener.Start();
            while (true)
            {
                //blocks until a client has connected to the server
                TcpClient client = this.tcpListener.AcceptTcpClient();

                //create a thread to handle communication with connected client
                Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClientComm));
                clientThread.IsBackground = true;
                clientThread.Start(client);
            }
        }
        private void HandleClientComm(object client)
        {
            int packetSize = 4096;
            TcpClient tcpClient = (TcpClient)client;
            clientIP = (((IPEndPoint)tcpClient.Client.RemoteEndPoint).Address.ToString());
            NetworkStream clientStream = tcpClient.GetStream();
            List<byte> listByte = new List<byte>();
            byte[] byteData = new byte[packetSize];
            int bytesRead;
            while (true)
            {
                bytesRead = 0;

                try
                {
                    //blocks until a client sends a message
                    bytesRead = clientStream.Read(byteData, 0, packetSize);
                    byte[] byteReceived = new byte[bytesRead];
                    for (int i = 0; i < bytesRead; i++)
                    {
                        byteReceived[i] = byteData[i];
                    }
                    listByte.AddRange(byteReceived);
                }
                catch
                {
                    //a socket error has occured
                    break;
                }

                if (bytesRead == 0)
                {
                    //the client has disconnected from the server
                    break;
                }
                //else
                //{
                //    /*Create a big byte array*/
                //    listByte.AddRange(byteData);
                //    byteData = new byte[packetSize];
                //}

            }
            //tcpClient.Close();
            //clientStream.Close();
            if (OnReceived != null)
            {
                //OnReceived(listByte.ToArray());
                OnReceived(clientIP, listByte.ToArray());
            }
        }
    }
}
