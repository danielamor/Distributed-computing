/****************************************************************
 * Class:         PacketAssembler                               *
 * Author:        Amor Daniel                                   *
 * Description:   Assemble a list of byte[] to one byte[]       *
 * Date:          23 may 2011                                   *
****************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DistributedComputing
{
    static class PacketAssembler
    {
        /// <summary>
        /// Assemble a list of array of byte on a byte array
        /// </summary>
        /// <param name="listByte">List of array of byte</param>
        /// <returns></returns>
        public static byte[] Assemble(List<byte[]> listByte)
        {
            List<byte> temp = new List<byte>();
            for (int i = 0; i < listByte.Count ; i++)
			{
                temp.AddRange(listByte[i]);
			}
            return temp.ToArray();
        }
    }
}
