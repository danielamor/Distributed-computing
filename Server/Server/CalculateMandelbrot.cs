/****************************************************************
 * Class:         ClassCalculator                               *
 * Author:        Amor Daniel                                   *
 * Description:   Calculate a mandelbrot set from a byte[]      *
 * Date:          23 may 2011                                   *
****************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DistributedComputing
{
    class ClassCalculator
    {
        /// <summary>
        /// ClassCalculator constructor
        /// </summary>
        public ClassCalculator() { }
        /// <summary>
        /// Calculate a task from byte array
        /// </summary>
        /// <param name="data">Data to calculte</param>
        /// <returns>Result</returns>
        public byte[] Calculate(byte[] data)
        {
            List<byte> listDouble = new List<byte>();
            /*Load data*/
            int noPacket = BitConverter.ToInt32(data, 0);
            int lengthData = BitConverter.ToInt32(data, 4);
            double MinX = BitConverter.ToDouble(data, 8);
            double MaxX = BitConverter.ToDouble(data, 16);
            double currentY = BitConverter.ToDouble(data, 24);
            double nextY = BitConverter.ToDouble(data, 32);
            double stepX = BitConverter.ToDouble(data, 40);
            double stepY = BitConverter.ToDouble(data, 48);
            int nbrIteration = BitConverter.ToInt32(data, 56);
            int heightEachPacket = BitConverter.ToInt32(data, 60);
            int width = BitConverter.ToInt32(data, 64);
            double module = 0;
            double trueValueOfY = currentY; //Set first Y value
            for (int y = 0; y < heightEachPacket; trueValueOfY += stepY,y++) //Each Y step
            {
                double trueValueOfX = MinX; //Set first X value
                for (int x = 0; x < width; trueValueOfX += stepX,x++) //Each X
                {
                    double realPart = 0;
                    double imaginaryPart = 0;
                    int i = 0;
                    while (i++ < nbrIteration) //Nbr iteration each pixel
                    {
                        double x2 = (realPart * realPart);
                        double y2 = (imaginaryPart * imaginaryPart);
                        double xy2 = 2 * realPart * imaginaryPart;
                        realPart = x2 - y2 + trueValueOfX; //New real part
                        imaginaryPart = xy2 + trueValueOfY; //New imaginary part
                        module = Math.Sqrt(realPart * realPart + imaginaryPart * imaginaryPart); //calulate the module value
                        if (module > 2) //No in the mandelbrot set?
                        {
                            listDouble.AddRange(BitConverter.GetBytes(module)); //Add result
                            listDouble.AddRange(BitConverter.GetBytes(i)); //Add nbr iteration to find that result
                            break; 
                        }
                    }
                    if (module <= 2) //In mandelbrot set?
                    {
                        listDouble.AddRange(BitConverter.GetBytes(module)); //Add result
                    }
                }
            }
            return listDouble.ToArray(); //Return the byte array of results
        }
    }
}
