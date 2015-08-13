/****************************************************************
 * Class:         SecondSince1970                               *
 * Author:        Amor Daniel                                   *
 * Description:   Get second since 1-1-1970(Unix Time)          *
 * Date:          23 may 2011                                   *
****************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DistributedComputing
{
    static class SecondSince1970
    {
        /// <summary>
        /// Get second since 1970
        /// </summary>
        /// <returns>second since 1970</returns>
        public static int Get()
        {
            DateTime origine = new DateTime(1970, 1, 1); //Unix time
            TimeSpan span = DateTime.Now - origine; //Current time - unix time
            return (int)span.TotalSeconds; //Return the seconds
        }
    }
}
