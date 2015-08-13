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
using System.Net.Sockets;
using System.Net;

namespace DistributedComputing
{
    class Sender
    {
        TcpClient tcpClient;
        private string ip;
        private int port;
        IPEndPoint serverEndPoint;
        /// <summary>
        /// Sender constructor
        /// </summary>
        /// <param name="Ip">IP of server</param>
        /// <param name="Port">Port of server</param>
        public Sender(string Ip, int Port)
        {
            ip = Ip;
            port = Port;
            tcpClient = new TcpClient();
            serverEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);
        }
        /// <summary>
        /// Send data
        /// </summary>
        /// <param name="data">Data to send</param>
        public bool send(byte[] data)
        {
            try
            {
                /*Try to establish a connection 1 seconde*/
                IAsyncResult result = tcpClient.BeginConnect(ip, port, null, null); 
                if (result.AsyncWaitHandle.WaitOne(1000, false))
                {
                    NetworkStream clientStream = tcpClient.GetStream();
                    clientStream.Write(data, 0, data.Length);
                    clientStream.Flush();
                    clientStream.Close();
                    return true;
                }
                else
                    return false;
            }
            catch { return false; }
        }
        /// <summary>
        /// Test the connexion
        /// </summary>
        /// <returns>connexion state</returns>
        public bool testConnexion()
        {
            /*Try to establish a connection 1 seconde*/
            IAsyncResult result = tcpClient.BeginConnect(ip, port, null, null);
            if (result.AsyncWaitHandle.WaitOne(1000, false))
            {
                return true;
            }
            return false;
        }
    }
}
