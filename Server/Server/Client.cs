/****************************************************************
 * Class:         Client                                        *
 * Author:        Amor Daniel                                   *
 * Description:   Store data from a remote client               *
 *                on the fly                                    *
 * Date:          23 may 2011                                   *
****************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;

namespace DistributedComputing
{
    class Client : Init
    {
        public List<int> currentWork { get; set; }
        public bool initialised { get; set; }
        public string ip { get; private set; }
        public int interval { get; set; }
        /// <summary>
        /// Client constructor
        /// </summary>
        /// <param name="Ip">IP of client</param>
        /// <param name="NbrCore">Number of core of client</param>
        /// <param name="memoryUsed">Memory used of client</param>
        /// <param name="ListMethod">List of methods of client</param>
        /// <param name="Initialised">Client class sended correctly compiled?</param>
        /// <param name="CurrentWork">Client package being calculated</param>
        /// <param name="interval">Interval of client send alive</param>
        public Client(string Ip, int NbrCore, double memoryUsed, string ListMethod, bool Initialised, List<int> CurrentWork, int interval)
            : base(NbrCore,memoryUsed, ListMethod)
        {
            ip = Ip;
            nbrCore = NbrCore;
            this.memoryUsed = memoryUsed;
            initialised = Initialised;
            currentWork = CurrentWork;
            this.interval = interval;
        }
    }
}
