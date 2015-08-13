/****************************************************************
 * Class:         Sender                                        *
 * Author:        Amor Daniel                                   *
 * Description:   Send byte[] to a remote client                *
 * Date:          23 may 2011                                   *
****************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace ClientTest
{
    class Sender
    {
        TcpClient tcpClient;
        private string ip;
        private int port;
        public IPEndPoint serverEndPoint { get; private set; }
        public Sender(string Ip, int Port)
        {
            ip = Ip;
            port = Port;
            tcpClient = new TcpClient();
            tcpClient.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            serverEndPoint  = new IPEndPoint(IPAddress.Parse(ip), port);
        }
        public bool send(byte[] data)
        {
            try
            {
                IAsyncResult result = tcpClient.BeginConnect(ip, port, null, null);
                if (result.AsyncWaitHandle.WaitOne(1000, false))
                {
                    NetworkStream clientStream = tcpClient.GetStream();
                    clientStream.Write(data, 0, data.Length);
                    clientStream.Flush();
                    clientStream.Close();
                    //tcpClient.Close();
                    return true;
                }
                else
                    return false;
            }
            catch { return false; }
        }   
    }
}
