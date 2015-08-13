/****************************************************************
 * Class:         BroadcastSender                               *
 * Author:        Amor Daniel                                   *
 * Description:   Send a UDP broadcast                          *
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
    static class BroadcastSender
    {
        /// <summary>
        /// Send a UDP broadcast
        /// </summary>
        /// <param name="data">Data to send</param>
        /// <param name="port">Port to send</param>
        public static void sendBroadcast(byte[] data ,int port)
        {
            try
            {
                UdpClient udpCLient = new UdpClient();
                IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Parse("255.255.255.255"), port);
                udpCLient.EnableBroadcast = true;
                udpCLient.Send(data, data.Length, ipEndPoint); //Send the broadcast
                udpCLient = null;
            }
            catch { }
        }
    }
}
