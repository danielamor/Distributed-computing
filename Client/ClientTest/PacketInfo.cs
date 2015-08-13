/****************************************************************
 * Class:         PacketInfo                                    *
 * Author:        Amor Daniel                                   *
 * Description:   Packet sended before data to say what type of *
 *                packet is comming                             *
 * Date:          23 may 2011                                   *
****************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClientTest
{
    class PacketInfo
    {
        public Command cmd { get; private set; }
        public int noPacket { get; private set; }
        public string ipAddress { get; private set; }
        public int dataLength { get; private set; }
        public int secondSince1970 { get; private set; }
        public int issueNumber { get; private set; }
        private byte[] hash = SHAHash.calculate(1687933897132637812);
        public byte[] Hash
        {
            get { return hash; }
        }


        /// <summary>
        /// PacketInfo constructor from parameters
        /// </summary>
        /// <param name="cmd">Type data</param>
        /// <param name="noPacket">Number of packet</param>
        /// <param name="ipAddress">IP</param>
        /// <param name="packetLength">Data lenght</param>
        public PacketInfo(Command cmd, int noPacket, string ipAddress, int packetLength, int secondSince1970, int issueNumber)
        {
            this.cmd = cmd;
            this.noPacket = noPacket;
            this.ipAddress = ipAddress;
            this.dataLength = packetLength;
            this.secondSince1970 = secondSince1970;
            this.issueNumber = issueNumber;
        }
        /// <summary>
        /// PacketInfo constructor from data
        /// </summary>
        /// <param name="data">Data to create class</param>
        /// <param name="offset">Position in data</param>
        public PacketInfo(byte[] data, int offset)
        {
            try
            {
                int currentPosition = 0 + offset;
                cmd = (Command)BitConverter.ToInt32(data, 0 + offset);
                currentPosition += 4;
                noPacket = BitConverter.ToInt32(data, currentPosition);
                currentPosition += 4;
                int ipAddressLength = BitConverter.ToInt32(data, currentPosition);
                currentPosition += 4;
                ipAddress = Encoding.Default.GetString(data, currentPosition, ipAddressLength);
                currentPosition += ipAddressLength;
                dataLength = BitConverter.ToInt32(data, currentPosition);
                currentPosition += 4;
                secondSince1970 = BitConverter.ToInt32(data, currentPosition);
                currentPosition += 4;
                issueNumber = BitConverter.ToInt32(data, currentPosition);
                currentPosition += 4;
                int hashLength = BitConverter.ToInt32(data, currentPosition);
                currentPosition += 4;
                hash = new byte[hashLength];
                int index = 0;
                for (int i = currentPosition; i < hashLength + currentPosition; i++)
                {
                    hash[index++] = data[i];
                }
            }
            catch { }
        }
        /// <summary>
        /// Create an byte array from this class
        /// </summary>
        /// <returns>Array with class data</returns>
        public byte[] ToByte()
        {
            List<byte> listByte = new List<byte>();
            listByte.AddRange(BitConverter.GetBytes((int)cmd));
            listByte.AddRange(BitConverter.GetBytes(noPacket));
            listByte.AddRange(BitConverter.GetBytes(ipAddress.Length));
            listByte.AddRange(Encoding.Default.GetBytes(ipAddress));
            listByte.AddRange(BitConverter.GetBytes(dataLength));
            listByte.AddRange(BitConverter.GetBytes(secondSince1970));
            listByte.AddRange(BitConverter.GetBytes(issueNumber));
            listByte.AddRange(BitConverter.GetBytes(hash.Length));
            listByte.AddRange(hash);
            return listByte.ToArray();
        }
    }
}
