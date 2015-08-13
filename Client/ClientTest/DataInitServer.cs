/****************************************************************
 * Class:         DataInitServer                                *
 * Author:        Amor Daniel                                   *
 * Description:   Store first data from the server              *
 *                an server application                         *
 * Date:          23 may 2011                                   *
****************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClientTest
{
    class DataInitServer
    {
        public string src { get; private set; }
        /// <summary>
        /// DataInitServer constructor from parameters
        /// </summary>
        /// <param name="src"></param>
        public DataInitServer(string src)
        {
            this.src = src;
        }
        /// <summary>
        /// DataInitServer constructor from data
        /// </summary>
        /// <param name="data">Data</param>
        public DataInitServer(byte[] data)
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
