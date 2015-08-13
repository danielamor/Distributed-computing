/****************************************************************
 * Class:         Initialized                                          *
 * Author:        Amor Daniel                                   *
 * Description:   Send a confirmation to server when            *
 *                client has been correctly initialized         *
 * Date:          23 may 2011                                   *
****************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClientTest
{
    static class Initialized
    {
        /// <summary>
        /// Send initialized data
        /// </summary>
        /// <param name="ip">Server IP</param>
        /// <param name="port">Server port</param>
        public static void sendInitialized(string ip, int port)
        {
            /*Connect to client*/
            Sender s = new Sender(ip, Convert.ToInt32(port));

            /*Add info of data*/
            PacketInfo packetInfo = new PacketInfo(Command.Initialized, 0, "", 0,0,0);

            /*Send data to client*/
            s.send(packetInfo.ToByte());
        }
    }
}
