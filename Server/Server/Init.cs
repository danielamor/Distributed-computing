/****************************************************************
 * Class:         Init                                          *
 * Author:        Amor Daniel                                   *
 * Description:   Store data to send at first connetion from a  *
 *                client to the server                          *
 * Date:          23 may 2011                                   *
****************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;

namespace DistributedComputing
{
    class Init
    {
        public int nbrCore { get; protected set; }
        public double memoryUsed { get; protected set; }
        public string listMethod { get; protected set; }
        /// <summary>
        /// Init constructor
        /// </summary>
        /// <param name="NbrCore">Number of core</param>
        /// <param name="memoryUsed">Memory used</param>
        /// <param name="ListMethod">Method incorporated</param>
        public Init(int NbrCore, double memoryUsed, string ListMethod)
        {
            nbrCore = NbrCore;
            this.memoryUsed = memoryUsed;
            listMethod = ListMethod;
        }
        /// <summary>
        /// Create class from data
        /// </summary>
        /// <param name="data">Data to create class</param>
        public Init(byte[] data)
        {
            //First 4 byte for nbrCore
            nbrCore = BitConverter.ToInt32(data, 0);

            //Memory used
            memoryUsed = BitConverter.ToInt32(data, 4);

            //Get the lenght of the list of methods
            int listMethodLength = BitConverter.ToInt32(data, 12);

            //Check if the list methods data is on data
            if (listMethodLength > 0)
                listMethod = Encoding.Default.GetString(data, 12, listMethodLength);
        }
        /// <summary>
        /// Create an byte array from this class
        /// </summary>
        /// <returns>Array with class data</returns>
        public byte[] ToByte()
        {
            List<byte> result = new List<byte>();
            //Convert each value on bytes
            result.AddRange(BitConverter.GetBytes(nbrCore));
            result.AddRange(BitConverter.GetBytes(memoryUsed));
            //Add list string lenght and convert it to a bytes
            if (listMethod != null)
                result.AddRange(BitConverter.GetBytes(listMethod.Length));
            else
                result.AddRange(BitConverter.GetBytes(0));

            if (listMethod != null)
                result.AddRange(Encoding.Default.GetBytes(listMethod));
            return result.ToArray();
        }
    }
}
