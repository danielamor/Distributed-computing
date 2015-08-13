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

namespace ClientTest
{
    class ThreadData
    {
        public int noPacket { get; private set; }
        public byte[] data { get; set; }
        public byte[] result { get;set; }
        public int secondSince1970 { get; set; }
        public int issueNumber { get; private set; }
        public ThreadData(int nbrPacket, byte[] data, byte[] result, int secondSince1970,int issueNumber)
        {
            this.noPacket = nbrPacket;
            this.data = data;
            this.result = result;
            this.secondSince1970 = secondSince1970;
            this.issueNumber = issueNumber;
        }
    }
}
