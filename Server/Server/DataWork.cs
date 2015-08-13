/****************************************************************
 * Class:         DataWork                                      *
 * Author:        Amor Daniel                                   *
 * Description:   Distribute a work to remote clients           *
 * Date:          23 may 2011                                   *
****************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DistributedComputing
{
    class DataWork
    {
        public SortedList<int,byte[]> tasks; //List of tasks
        private int nbrTask;
        /// <summary>
        /// DataWork constructor
        /// Load a array of array of byte on a list of tasks
        /// </summary>
        /// <param name="cuttedTask">Array to load</param>
        public DataWork(byte[][] cuttedTask)
        {
            nbrTask = cuttedTask.Length;
            tasks = new SortedList<int,byte[]>();
            /*Load stack */
            for (int i = 0; i < cuttedTask.Length; i++)
            {
                tasks.Add(i+1,cuttedTask[i]);
            }
        }
        /// <summary>
        /// Send a work to a client
        /// </summary>
        /// <param name="listClient">List of clients</param>
        /// <param name="listPacketSended">Packet already sended</param>
        /// <param name="ipAddress">Ip address of a client</param>
        /// <param name="port">Port of a client</param>
        /// <param name="nbrPackets">Number packet to send</param>
        /// <param name="issueNumber">Issu number</param>
        public void sendWork(ref SortedList<string, Client> listClient, ref SortedList<int, PacketInfo>listPacketSended, string ipAddress, int port, int nbrPackets,int issueNumber)
        {
            List<byte[]> listWorksToSend = new List<byte[]>();
            /*Connect to client*/
            Sender s = new Sender(ipAddress, Convert.ToInt32(port)); 
            SortedList<int,byte[]> tempListTasks = new SortedList<int,byte[]>(tasks);
            for (int i = 0; i < nbrPackets; i++)
            {
                if (tempListTasks.Count > 0)  //More tasks?
                {
                    int firstKey = tempListTasks.Keys[0];
                    byte[] data = tempListTasks[firstKey];
                    tempListTasks.Remove(firstKey); //remove temporary data, if the sender doesn't work        
                    /*Add info of data*/
                    PacketInfo packetInfo = new PacketInfo(Command.Work, firstKey, "", data.Length, SecondSince1970.Get(),issueNumber);
                    if(!listPacketSended.ContainsKey(firstKey))
                        listPacketSended.Add(firstKey, packetInfo);
                    listWorksToSend.Add(packetInfo.ToByte());
                    /*Add data*/
                    listWorksToSend.Add(data);
                    listClient[ipAddress].currentWork.Add(firstKey); //Add to current client work
                }
                else
                    break;
            }

            /*Assembly the packets*/
            byte[] dataToSend = PacketAssembler.Assemble(listWorksToSend);
             /*Send data to client*/
            s.send(dataToSend);
            int nbrPaquetsToRemove = nbrPackets;
            if (nbrPackets > tasks.Count) //More packet to remove than number of task?
                nbrPaquetsToRemove = tasks.Count;
            for (int i = 0; i < nbrPaquetsToRemove; i++) //Remove real data
            {
                tasks.RemoveAt(0);
            }
        }
    }
}
