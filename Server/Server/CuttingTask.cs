/****************************************************************
 * Class:         CuttingTask                                   *
 * Author:        Amor Daniel                                   *
 * Description:   Cut a task                                    *
 * Date:          23 may 2011                                   *
****************************************************************/
using System;
using System.Collections.Generic;

namespace DistributedComputing
{
    class CuttingTask
    {
        /// <summary>
        /// CuttingTask constructor
        /// </summary>
        public CuttingTask()
        {
        }
        /// <summary>
        /// Cut a task 
        /// </summary>
        /// <param name="nbrPackets">Number of packets</param>
        /// <returns>Packets byte[][]</returns>
        public byte[][] CutTask(int nbrPackets)
        {
            byte[][] array = new byte[nbrPackets][];
            int nbrIteration = 500;
            const double MinX = -0.240706903927625;
            const double MaxX = -0.888706161296681;
            const double MinY = -0.240706903927625;
            const double MaxY = -0.888706161296681;

            int width = 2000;
            int height = 1980;
            double stepX = (MaxX - MinX) / width;
            double stepY = (MaxY - MinY) / height;
            int heightEachPackage = (int)Math.Truncate((float)height / nbrPackets);
            double currentHeight = heightEachPackage;
            double currentY = MinY;
            double nextY = MinY;
            int i = 0;
            for (int y = 0; y < nbrPackets; y++) //Each packets
            {
                if (y + 1 >= nbrPackets) //next is last packet?
                {
                    nextY = MaxY; //Set the max value
                    heightEachPackage = height - (y * heightEachPackage);
                }
                else
                    nextY += stepY * heightEachPackage; 
                List<byte> listByte = new List<byte>();
                /*No packet*/
                listByte.AddRange(BitConverter.GetBytes(i));
                /*Lenght of end data 6*double(8octet)+3*int(4octet)*/
                listByte.AddRange(BitConverter.GetBytes(6 * 8 + 3 * 4));
                listByte.AddRange(BitConverter.GetBytes(MinX));
                listByte.AddRange(BitConverter.GetBytes(MaxX));
                listByte.AddRange(BitConverter.GetBytes(currentY));
                listByte.AddRange(BitConverter.GetBytes(nextY));
                listByte.AddRange(BitConverter.GetBytes(stepX));
                listByte.AddRange(BitConverter.GetBytes(stepY));
                listByte.AddRange(BitConverter.GetBytes(nbrIteration));
                listByte.AddRange(BitConverter.GetBytes(heightEachPackage+1));
                listByte.AddRange(BitConverter.GetBytes(width));
                currentY = nextY;
                array[i++] = listByte.ToArray();
            } 
            return array;
        }
    }
}
