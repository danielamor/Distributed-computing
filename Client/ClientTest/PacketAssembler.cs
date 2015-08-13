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

namespace ClientTest
{
    class PacketAssembler
    {
        public PacketAssembler() { }
        public byte[] Assemble(List<byte[]> listByte)
        {
            List<byte> temp = new List<byte>();
            for (int i = 0; i < listByte.Count; i++)
            {
                temp.AddRange(listByte[i]);
            }
            return temp.ToArray();
        }
    }
}
