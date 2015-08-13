/****************************************************************
 * Class:         DataResult                                    *
 * Author:        Amor Daniel                                   *
 * Description:   Send a list of byte[] to the server           *
 * Date:          23 may 2011                                   *
****************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClientTest
{
    class DataResult
    {
        /// <summary>
        /// Send a list of results to server
        /// </summary>
        /// <param name="ip">Server IP</param>
        /// <param name="port">Server Port</param>
        /// <param name="listResults">List of results to send</param>
        public DataResult(string ip, int port, List<Task> listResults)
        {
            List<byte[]> listWorksToSend = new List<byte[]>();
            listResults.Sort();
            /*Connect to client*/
            Sender s = new Sender(ip, Convert.ToInt32(port));
            foreach (Task item in listResults)
            {
                /*Add info of data*/
                if (item.data != null)
                {
                    PacketInfo packetInfo = new PacketInfo(Command.Result, item.noPacket, "", item.data.Length,item.secondSince1970,item.issueNumber);
                    listWorksToSend.Add(packetInfo.ToByte());
                    /*Add data*/
                    listWorksToSend.Add(item.data);
                }
            }                      
            /*Assembly the packets*/
            PacketAssembler packetAssembler = new PacketAssembler();
            byte[] dataToSend = packetAssembler.Assemble(listWorksToSend);
            listResults.Clear();

            /*Send data to client*/
            s.send(dataToSend);
        }
    }
}
