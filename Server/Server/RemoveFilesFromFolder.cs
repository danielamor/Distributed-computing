/****************************************************************
 * Class:         RemoveFilesFromFolder                         *
 * Author:        Amor Daniel                                   *
 * Description:   Remove files from a folder                    *
 * Date:          23 may 2011                                   *
****************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace DistributedComputing
{
    static class RemoveFilesFromFolder
    {
        /// <summary>
        /// Remove files from a folder
        /// </summary>
        /// <param name="folderPath">Folder to remove files</param>
        /// <returns>Removed?</returns>
        public static bool Remove(string folderPath)
        {
            try
            {
                foreach (string filePath in Directory.GetFiles(folderPath))
                {
                    File.Delete(filePath);
                }
                return true;
            }
            catch { return false; }
        }
    }
}
