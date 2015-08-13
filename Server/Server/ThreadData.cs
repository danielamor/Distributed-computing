/****************************************************************
 * Class:         ThreadData                                    *
 * Author:        Amor Daniel                                   *
 * Description:   Data used by threads                          *
 * Date:          23 may 2011                                   *
****************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DistributedComputing
{
    class ThreadData
    {
        public int noPacket { get; private set; }
        public byte[] data { get; set; }
        public byte[] result { get;set; }
        /// <summary>
        /// ThreadData constructor
        /// </summary>
        /// <param name="noPacket">Packet number</param>
        /// <param name="data">Data to calculate</param>
        /// <param name="result">Result of data</param>
        public ThreadData(int noPacket, byte[] data, byte[] result)
        {
            this.noPacket = noPacket;
            this.data = data;
            this.result = result;
        }
    }
}
