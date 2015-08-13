/****************************************************************
 * ExtendedClass: IsIpReachable                                 *
 * Author:        Amor Daniel                                   *
 * Description:   Verify if a adress IP is reachable            *
 * Date:          23 may 2011                                   *
****************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;

namespace ClientTest
{
    public static class Extension
    {
        /// <summary>
        /// Verify if a adress IP is reachable
        /// </summary>
        /// <param name="ipAddress">IP to test</param>
        /// <param name="port">port to send</param>
        /// <returns>Is reachable</returns>
        public static bool IsIpReachable(this string ipAddress, int port)
        {
            if (ipAddress != "")
            {
                Sender sender = new Sender(ipAddress, port);
                return sender.send(new byte[1]); //Send without data
            }
            else
                return false;
        }
    }
}
