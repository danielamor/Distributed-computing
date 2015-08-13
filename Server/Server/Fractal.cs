/****************************************************************
 * Class:         Fractal                                      *
 * Author:        Amor Daniel                                   *
 * Description:   Create a fractale from a byte[]               *
 * Date:          23 may 2011                                   *
****************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace DistributedComputing
{
    class Fractal
    {
        private Bitmap bmp = new Bitmap(2000, 1980);
        /// <summary>
        /// Create a fractal from a byte[] 
        /// </summary>
        /// <param name="noPacket">Packet number</param>
        /// <param name="data">Data</param>
        /// <param name="nbrPackets">Number of max packets</param>
        /// <returns></returns>
        public Bitmap createFractale(int noPacket,byte[] data,int nbrPackets)
        {
            int heightEachPackage = (int)Math.Truncate((float)bmp.Height / nbrPackets); //Get height each package
            int y = 0;
            if(noPacket != 1) //Not first packet?
                y = heightEachPackage * (noPacket-1); //Get Y position
            int maxY = y+heightEachPackage;
            if (maxY > bmp.Height || noPacket == nbrPackets) //No more pixel? || Maximum of packets?
            {
                maxY = bmp.Height; //Set the max value
                heightEachPackage = bmp.Height - ((nbrPackets-1) * heightEachPackage); //Set height of last packet
                y = bmp.Height - heightEachPackage;
            }

            int index = 0;
            for (; y < maxY; y++) //Each Y
            {
                for (int x = 0; x < bmp.Width; x++) //Each X
                {
                    double module = BitConverter.ToDouble(data, index); //Get module
                    if (module > 2) //No in the mandelbrot set?
                    {
                        int nbIteration = BitConverter.ToInt32(data, index + 8); //get number of iteration
                        Color color;
                        int red = (int)((double)nbIteration / 100 * 100); //Calculate percentage
                        if (red >= 100)
                            color = Color.Red;
                        else
                            if (red >= 80)
                                color = Color.Yellow;
                            else
                                if (red >= 50)
                                    color = Color.Green;
                                else
                                    if (red >= 20)
                                        color = Color.Pink;
                                    else
                                        color = Color.Purple;


                        // return Color.FromArgb(red, 0, 0);
                        bmp.SetPixel(x, y, color);
                        index += 12;
                    }
                    else //In the mandelbrot set?
                    {
                        bmp.SetPixel(x, y, Color.Black);
                        index += 8;
                    }
                }
            }
            return bmp.Clone(new Rectangle(0,0,bmp.Width,bmp.Height),System.Drawing.Imaging.PixelFormat.Format24bppRgb); //Return a copy of image 
        }
    }
}
