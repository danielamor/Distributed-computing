/****************************************************************
 * Class:         SaveToFile                                    *
 * Author:        Amor Daniel                                   *
 * Description:   Save a byte[] to a file                       *
 * Date:          23 may 2011                                   *
****************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace DistributedComputing
{
    static class SaveToFile
    {
        /// <summary>
        /// Save a byte[] to a file
        /// </summary>
        /// <param name="path">Directory</param>
        /// <param name="extension">Extension of file</param>
        /// <param name="name">Packet number</param>
        /// <param name="data">Packet data</param>
        /// <returns></returns>
        public static bool save(string path,string extension, string name, byte[]data)
        {
            try
            {
                using (Stream s = File.Create(path + name + extension)) //Create the file 
                {
                    s.Write(data, 0, data.Length); //Write packet data to file
                }
                return true;
            }
            catch { return false; }
        }
    }
}
