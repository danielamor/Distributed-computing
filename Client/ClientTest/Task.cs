/****************************************************************
 * Class:         Task                                          *
 * Author:        Amor Daniel                                   *
 * Description:   Store a task and is result                    *
 * Date:          23 may 2011                                   *
****************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClientTest
{
    class Task : IComparable<Task>
    {
        public int noPacket { get; private set; }
        public byte[] data { get; private set; }
        public byte[] result { get; private set; }
        public int secondSince1970 { get; private set; }
        public int issueNumber { get; private set; }
        /// <summary>
        /// Task constructor
        /// </summary>
        /// <param name="noPacket"></param>
        /// <param name="data"></param>
        /// <param name="secondSince1970"></param>
        /// <param name="issueNumber"></param>
        public Task(int noPacket, byte[] data, int secondSince1970, int issueNumber)
        {
            this.noPacket = noPacket;
            this.data = data;
            this.secondSince1970 = secondSince1970;
            this.issueNumber = issueNumber;
        }
        /// <summary>
        /// Compare two tasks
        /// </summary>
        /// <param name="other">Task to compare</param>
        /// <returns>Comparison</returns>
        public int CompareTo(Task other)
        {
            return noPacket.CompareTo(other.noPacket);
        }
        /// <summary>
        /// Compare two noPacket from two Tasks
        /// </summary>
        public static Comparison<Task> noPacketComparaison =
        delegate(Task p1, Task p2)
        {
            return p1.noPacket.CompareTo(p2.noPacket);
        };
    }
}
