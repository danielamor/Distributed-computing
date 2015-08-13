/****************************************************************
 * Class:         Server                                        *
 * Author:        Amor Daniel                                   *
 * Description:   Start a server and calculate packets from     *
 *                data sended by a server.                      *
 * Date:          23 may 2011                                   *
****************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace ClientTest
{
    class Server
    {
        int serverPort = 1000;
        int receiverPort = 1100;
        int broadcastReceiverPort = 1200;
        string serverIP;
        private object lockThis = new object();
        bool firstExecution = true;
        bool working = false;
        Calculation calculation;
        List<Task> listTasks = new List<Task>();
        Timer timer;
        AvgTime avgTime = new AvgTime();
        /// <summary>
        /// Server constructor and start server 
        /// </summary>
        /// <param name="serverPort">Server port</param>
        /// <param name="receiverPort">Receiver port</param>
        /// <param name="broadcastReceiverPort">BroadcastReceiverPort</param>
        /// <param name="serverIP">Server IP</param>
        public Server(int serverPort, int receiverPort, int broadcastReceiverPort,string serverIP)
        {
            this.serverPort = serverPort;
            this.receiverPort = receiverPort;
            this.broadcastReceiverPort = broadcastReceiverPort;
            this.serverIP = serverIP;
            startReceiver();
            sendInitData();
            /*Wait from server data*/
            startUdpReceiver();
        }
        /// <summary>
        /// Start server
        /// </summary>
        public void startReceiver()
        {
            Receiver r = new Receiver();
            r.OnReceived += new Receiver.received(r_OnReceived);
            r.StartReceiver(receiverPort);
        }
        /// <summary>
        /// Receive data from broadcast receiver
        /// </summary>
        /// <param name="data">data received</param>
        void broadcastReceiver_OnReceived(byte[] data)
        {
            Command cmd = (Command)BitConverter.ToInt32(data, 0);
            /*Start the data receiver and send client data*/
            if (cmd == Command.Alive)
            {
                if (firstExecution)
                {
                    startReceiver();
                    firstExecution = false;
                }
                /*Test IP adrresse*/
                PacketInfo packetInfo = new PacketInfo(data, 0);

                string[] listIP = packetInfo.ipAddress.Split(new char[] { ';' });
                for (int i = 0; i < listIP.Length; i++)
                {
                    /*Set fisrt true IP to IP of server*/
                    if (listIP[i].IsIpReachable(serverPort))
                        serverIP = listIP[i];
                }

                /*Send init data each broadcast from server*/
                sendInitData();
            }
        }
        /// <summary>
        /// Receive data from receiver
        /// </summary>
        /// <param name="ip">Remote IP</param>
        /// <param name="data">Data</param>
        void r_OnReceived(string ip, byte[] data)
        {
            lock (lockThis)
            {
                /*Disassemble data*/
                PacketDisassembler packetDisassembler = new PacketDisassembler();
                List<DataReceived> listPackets = packetDisassembler.Disassemble(data);
                /*Read each packets*/
                for (int i = 0; i < listPackets.Count; i++)
                {
                    Command cmd = listPackets[i].cmd;
                    switch (cmd)
                    {
                        /*Receive the function*/
                        case Command.ClientInit:
                            DataInitServer dic = new DataInitServer(listPackets[i].data);
                            calculation = new Calculation();
                            calculation.LoadSource(dic.src);
                            Initialized.sendInitialized(serverIP, serverPort); //Send initialized data
                            calculation.OnFinished += new Calculation.finished(calculation_OnFinished);
                            break;
                        case Command.Work:
                            if (timer == null) //Start interval timer
                            {
                                timer = new Timer();
                                timer.Enabled = true;
                                timer.Interval = 1000;
                                timer.Start();
                                timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
                            }
                            listTasks.Add(new Task(listPackets[i].noPacket, listPackets[i].data, listPackets[i].secondSince1970, listPackets[i].issueNumber)); //add a new task
                            break;
                        default:
                            break;
                    }
                }
                if (listPackets.Count > 0 && listPackets[0].cmd == Command.Work) //Start calculating of all received tasks
                {
                    working = true;
                    doWork();
                    working = false;
                }
            }
        }
        /// <summary>
        /// Send alive packets each tick
        /// </summary>
        /// <param name="sender">not used</param>
        /// <param name="e">not used</param>
        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            sendAlivePacket();
        }
        /// <summary>
        /// Send init data
        /// </summary>
        private void sendInitData()
        {
            Init init = new Init(Environment.ProcessorCount, 1, "");
            DataInit dataInit = new DataInit(serverIP, serverPort, init);
        }
        /// <summary>
        /// Receive data calculated
        /// </summary>
        /// <param name="listResults"></param>
        void calculation_OnFinished(List<Task> listResults)
        {
            sendResults(listResults);
            listTasks.Clear();
            listResults.Clear();
        }
        /// <summary>
        /// Start calculation
        /// </summary>
        private void doWork()
        {
            calculation.Calculate(listTasks);
        }
        /// <summary>
        /// Send results to server
        /// </summary>
        /// <param name="listResults">List of results to send</param>
        private void sendResults(List<Task> listResults)
        {
            lock (lockThis)
            {
                /*Set interval time*/
                if (listResults[0] != null)
                {
                    timer.Interval = avgTime.calculateNewTime(SecondSince1970.Get() - listResults[0].secondSince1970) * 1000; //Set new interval
                }

                DataResult dataResult = new DataResult(serverIP, serverPort, listResults);
                listResults.Clear();
                GC.Collect();
            }
        }
        /// <summary>
        /// Start the udp receiver
        /// </summary>
        private void startUdpReceiver()
        {
            BroadcastReceiver broadcastReceiver = new BroadcastReceiver(broadcastReceiverPort);
            broadcastReceiver.OnReceived += new BroadcastReceiver.received(broadcastReceiver_OnReceived);
        }
        /// <summary>
        /// Send alive packet
        /// </summary>
        private void sendAlivePacket()
        {
            if (working)
            {
                PacketInfo packetInfo = new PacketInfo(Command.AliveClient, 0, "", 0, (int)timer.Interval, 0);
                byte[] data = packetInfo.ToByte();
                Sender s = new Sender(serverIP, serverPort);
                s.send(data);
            }
        }
    }
}
