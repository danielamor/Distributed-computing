/****************************************************************
 * Class:         MyIPAddress                                   *
 * Author:        Amor Daniel                                   *
 * Description:   Send all detected IP adress of current computer
 *                to own                                        *
 * Date:          23 may 2011                                   *
****************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading;

namespace DistributedComputing
{
    class MyIPAddress
    {
        /// <summary>
        /// Test own IP addresses on own computer
        /// </summary>
        /// <param name="port">Port to send</param>
        /// <returns>Finish?</returns>
        public bool GetIPAddress(int port)
        {
            List<IPAddressInformation> listInfo = new List<IPAddressInformation>();
            foreach (NetworkInterface netif in NetworkInterface.GetAllNetworkInterfaces()) //Each network interface
            {
                IPInterfaceProperties properties = netif.GetIPProperties();
                foreach (IPAddressInformation unicast in properties.UnicastAddresses) //Each ip adress
                {
                    if (unicast.Address != IPAddress.Loopback) //No local host
                    {
                        Sender sender = new Sender(unicast.Address.ToString(), port); //Start tcp sender
                        PacketInfo packetInfo = new PacketInfo(Command.CorrectIP, 0, "",0,0,0);
                        sender.send(packetInfo.ToByte()); //Send own
                    }
                }
            }
            Thread.Sleep(100);
            return true;
        }
    }
}
