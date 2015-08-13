/****************************************************************
 * Class:         DataInit                                      *
 * Author:        Amor Daniel                                   *
 * Description:   Data send for the first connetion from the    *
 *                client to the server                          *
 * Date:          23 may 2011                                   *
****************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClientTest
{
    class DataInit
    {
        /// <summary>
        /// Send data init to server
        /// </summary>
        /// <param name="ip">IP of server</param>
        /// <param name="port">Listen port of server</param>
        /// <param name="init">Packet Init</param>
        public DataInit(string ip, int port, Init init)
        {
            try
            {
                List<byte[]> listPacketInit = new List<byte[]>();
                /*Connect to client*/
                Sender s = new Sender(ip, Convert.ToInt32(port));

                byte[] dataToSend = init.ToByte();
                /*Add info of data*/
                PacketInfo packetInfo = new PacketInfo(Command.Init, 0, "", dataToSend.Length,0,0);
                listPacketInit.Add(packetInfo.ToByte());
                /*Add data*/
                listPacketInit.Add(dataToSend);
                /*Assembly the packets*/
                PacketAssembler packetAssembler = new PacketAssembler();
                dataToSend = packetAssembler.Assemble(listPacketInit);

                /*Send data to client*/
                s.send(dataToSend);
            }
            catch { }
        }
    }
}
