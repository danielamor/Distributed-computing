/****************************************************************
 * Class:         PacketDisassembler                            *
 * Author:        Amor Daniel                                   *
 * Description:   Disassemble a network packet(byte[]) to a     *
 *                list of DataReceived                          *
 * Date:          23 may 2011                                   *
****************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClientTest
{
    class PacketDisassembler
    {
        const int SIZEPACKETINFO = 28;
        public PacketDisassembler(){}
        public List<DataReceived> Disassemble(byte[] data)
        {
            byte[] hash = SHAHash.calculate(1687933897132637812);
            List<byte> listByte = data.ToList();
            List<DataReceived> listDataReveived = new List<DataReceived>();
            Command cmd;
            int noPacket;
            string ipAddress;
            int sizeData;
            int currentPosition = 0;
            int previousPosition = 0;
            /*Read each packet into data array*/
            while (currentPosition + SIZEPACKETINFO <= data.Length)
            {
                previousPosition = currentPosition;
                /*Test if next data is a real data*/

                /*Get packet info*/
                PacketInfo packetInfo = new PacketInfo(data, previousPosition);
                cmd = packetInfo.cmd;
                if (SHAHash.verifiy(packetInfo.Hash, hash) && (cmd == Command.ClientInit || cmd == Command.Work)) //Correct command?
                {
                    noPacket = packetInfo.noPacket;
                    ipAddress = packetInfo.ipAddress;

                    /*Get size of packet data*/
                    sizeData = packetInfo.dataLength;
                    /*First data position*/
                    currentPosition += SIZEPACKETINFO + ipAddress.Length + packetInfo.Hash.Length;
                    List<byte> tempListByte = new List<byte>();
                    int i = currentPosition;
                    /*Get data from previous position to the current position and data lenght*/
                    for (; i < (currentPosition + sizeData); i++)
                    {
                        tempListByte.Add(listByte[i]);
                    }
                    currentPosition = i;
                    DataReceived dataReceived = new DataReceived(cmd, noPacket,packetInfo.secondSince1970,packetInfo.issueNumber, ipAddress, tempListByte.ToArray());
                    listDataReveived.Add(dataReceived);
                }
                else
                    break;
            }
            return listDataReveived;
        }
    }
}
