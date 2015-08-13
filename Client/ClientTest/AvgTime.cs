/****************************************************************
 * Class:         AvgTime                                       *
 * Author:        Amor Daniel                                   *
 * Description:   Get an average time from a lot a times        *
 * Date:          23 may 2011                                   *
****************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClientTest
{
    class AvgTime
    {
        private int sumTimes;
        private int nbrTimesAdded;
        /// <summary>
        /// AvgTime constructor
        /// </summary>
        public AvgTime() { }
        /// <summary>
        /// Calcul (new) average time
        /// </summary>
        /// <param name="newTime">New time</param>
        /// <returns>Average time</returns>
        public int calculateNewTime(int newTime)
        {
            nbrTimesAdded++; 
            sumTimes += newTime;
            int averageTime = sumTimes / nbrTimesAdded; //Return average time
            if(averageTime <= 0) //No value under 0
               averageTime = 1;
            return averageTime;
        }
    }
}
