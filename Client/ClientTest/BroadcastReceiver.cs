/****************************************************************
 * Class:         BroadcastReceiver                             *
 * Author:        Amor Daniel                                   *
 * Description:   Receive a UDP broadcast                       *
 * Date:          23 may 2011                                   *
****************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace ClientTest
{
    class BroadcastReceiver
    {
        /*Event when a data is received*/
        public delegate void received(byte[] data);
        public event received OnReceived;
        int port = 0;
        /// <summary>
        /// Start UDP receiver
        /// </summary>
        /// <param name="port">Receiver port</param>
        public BroadcastReceiver(int port)
        {
            this.port = port;
            Thread t = new Thread(new ThreadStart(startReceiver));
            t.IsBackground = true;
            t.Start(); //Start listening in a thread
        }
        /// <summary>
        /// Start listen network
        /// </summary>
        private void startReceiver()
        {
            UdpClient udpCLient = new UdpClient(port);
            IPEndPoint groupEP = new IPEndPoint(IPAddress.Any, port);
            while (true)
            {
                try
                {
                    /*Waiting for broadcast"*/
                    byte[] bytes = udpCLient.Receive(ref groupEP); //Get data from remote client
                    if (OnReceived != null)
                        OnReceived(bytes);
                }

                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
                finally
                {
                }
            }
        }
    }
}
            
       