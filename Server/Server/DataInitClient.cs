/****************************************************************
 * Class:         DataInitClient                                *
 * Author:        Amor Daniel                                   *
 * Description:   Store data to send to first connexion with    *
 *                a client                                      *
 * Date:          23 may 2011                                   *
****************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DistributedComputing
{
    class DataInitClient
    {
        public string src { get; private set; } //Code to send
        /// <summary>
        /// DataInitClient constructor
        /// </summary>
        /// <param name="src">Code to send</param>
        public DataInitClient(string src)
        {
            this.src = src;
        }
        /// <summary>
        /// Create class from data
        /// </summary>
        /// <param name="data">Data to create class</param>
        public DataInitClient(byte[] data)
        {
            int dataLength = BitConverter.ToInt32(data, 0);
            src = Encoding.Default.GetString(data, 4, dataLength);
        }
        /// <summary>
        /// Create an byte array from this class
        /// </summary>
        /// <returns>Array with class data</returns>
        public byte[] ToByte()
        {
            List<byte> listByte = new List<byte>();
            listByte.AddRange(BitConverter.GetBytes(src.Length));
            listByte.AddRange(Encoding.Default.GetBytes(src));
            return listByte.ToArray();
        }
    }
}
