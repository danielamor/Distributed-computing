/****************************************************************
 * Class:         InitClient                                    *
 * Author:        Amor Daniel                                   *
 * Description:   Send first initilisation to remote client     *
 * Date:          23 may 2011                                   *
****************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DistributedComputing
{
    static class InitClient
    {
        /// <summary>
        /// Send init data to client
        /// </summary>
        /// <param name="client">Client</param>
        /// <param name="port">Client port</param>
        /// <param name="src">Code to send</param>
        public static void initClient(Client client,int port, string src)
        {
            /*Send initilisation packet*/
            if (!client.initialised)
            {
                /*Connect to client*/
                Sender s = new Sender(client.ip, Convert.ToInt32(port));
                
                /*Create init packet*/
                DataInitClient dic = new DataInitClient(src);
                byte[] dicData = dic.ToByte();

                /*Create packet info data*/
                PacketInfo packetInfo = new PacketInfo(Command.ClientInit,0,"", dicData.Length,0,0);
                byte[] packetInfoData = packetInfo.ToByte();

                /*Assembly the packets*/
                List<byte[]> listPacket = new List<byte[]>();
                
                listPacket.Add(packetInfoData);
                listPacket.Add(dicData);
                
                /*Send all packet*/
                byte[] dataToSend = PacketAssembler.Assemble(listPacket);
                s.send(dataToSend);
            }
        }
    }
}
