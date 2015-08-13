/****************************************************************
 * Class:         DataReceived                                  *
 * Author:        Amor Daniel                                   *
 * Description:   Store received data from receiver             *
 * Date:          23 may 2011                                   *
****************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DistributedComputing
{
    class DataReceived
    {
        public Command cmd { get; private set; } 
        public int noPacket { get; private set; }
        public int secondSince1970 { get; private set; }
        public int issueNumber { get; private set; }
        public string ipAddress { get; private set; }
        public byte[] data { get; private set; }
        /// <summary>
        /// DataReceived constructor
        /// </summary>
        /// <param name="cmd">Type data</param>
        /// <param name="noPacket">Number of packet</param>
        /// <param name="secondSince1970">Created time</param>
        /// <param name="issueNumber">Issu of packet</param>
        /// <param name="ipAddress">IP of sender</param>
        /// <param name="data">Data received</param>
        public DataReceived(Command cmd, int noPacket, int secondSince1970,int issueNumber, string ipAddress, byte[] data)
        {
            this.cmd = cmd;
            this.noPacket = noPacket;
            this.secondSince1970 = secondSince1970;
            this.issueNumber = issueNumber;
            this.ipAddress = ipAddress;
            this.data = data;
        }
    }
}
