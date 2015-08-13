/****************************************************************
 * Class:         Command                                       *
 * Author:        Amor Daniel                                   *
 * Description:   Commands for communication between client     *
 *                an server application                         *
 * Date:          23 may 2011                                   *
****************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DistributedComputing
{
    /// <summary>
    /// Commands for communication between client an server application
    /// </summary>
    enum Command
    {
        Init,   //Initialisation
        Initialized, //Confirm the initilisation of client
        State,  //When a client want to send an indication status to server
        ClientInit, //Create an client
        Result, //Send result
        Work,   //Packet with data to calculate
        Alive,  //Send when server started
        AliveClient, //Send when client started
        Interval, //Send interval time of client
        CorrectIP, //Verification of an IP address
        None
    }
}
