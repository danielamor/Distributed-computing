/****************************************************************
 * Class:         SHAHash                                       *
 * Author:        Amor Daniel                                   *
 * Description:   Create and verifiy a hash code                *
 * Date:          23 may 2011                                   *
****************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace DistributedComputing
{
    static class SHAHash
    {
        /// <summary>
        /// Calculate a hash
        /// </summary>
        /// <param name="key">key</param>
        /// <returns>hash</returns>
        public static byte[] calculate(long key)
        {
            SHA1 sha = new SHA1CryptoServiceProvider();
            byte[] data = BitConverter.GetBytes(key);
            return sha.ComputeHash(data);     
        }
        /// <summary>
        /// Verifiy two hash
        /// </summary>
        /// <param name="data">Input hash</param>
        /// <param name="hash">Compare hash</param>
        /// <returns>Equals?</returns>
        public static bool verifiy(byte[] data, byte[] hash)
        {
            if (data.Length == hash.Length)
            {
                for (int i = 0; i < data.Length; i++)//Compare each of the two array
                {
                    if (data[i] != hash[i]) //Not the same?
                        return false; 
                }
                return true;
            }
            return false;
        }
    }
}
