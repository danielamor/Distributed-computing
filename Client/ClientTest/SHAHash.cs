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

namespace ClientTest
{
    static class SHAHash
    {
        public static byte[] calculate(long key)
        {
            SHA1 sha = new SHA1CryptoServiceProvider();
            byte[] data = BitConverter.GetBytes(key);
            return sha.ComputeHash(data);     
        }
        public static byte[] calculate(byte[] data)
        {
            SHA1 sha = new SHA1CryptoServiceProvider();
            return sha.ComputeHash(data);
        }
        public static bool verifiy(byte[] data, byte[] hash)
        {
            if (data.Length == hash.Length)
            {
                for (int i = 0; i < data.Length; i++)
                {
                    if (data[i] != hash[i])
                        return false;
                }
                return true;
            }
            return false;
        }
    }
}
