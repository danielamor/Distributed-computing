/****************************************************************
 * Class:         Server                                        *
 * Author:        Amor Daniel                                   *
 * Description:   Start a server and management remote client to*
 *                distribute a task to all clients              *
 * Date:          23 may 2011                                   *
****************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Resources;
using System.Reflection;

namespace DistributedComputing
{
    class Server
    {
        private bool serverStarted = false;
        private object lockThis = new object();
        //List of clients
        SortedList<string, Client> listClient = new SortedList<string, Client>();
        List<int> listResults = new List<int>();
        SortedList<int, PacketInfo> listPacketSended = new SortedList<int, PacketInfo>();
        DataWork dataWork;
        string serverIPs = string.Empty;
        Timer timer = new Timer();
        int sendPort;
        int nbrPacketToSend;
        int nbrPacket;
        int listenPort;
        int sendBroadcastPort;
        int issueNumber;
        int avgCalculationTime;
        int timeRemaining;
        bool savePacketsToFile;
        string calculatorClass;
        string cuttingClass;
        byte[][] cuttedTask;
        AvgTime avgTime = new AvgTime();
        Fractal fractale;
        const string FILE_EXTENTION = ".ext";

        /*Event when a fractale update is required*/
        public delegate void displayFractal(Bitmap bmp);
        public event displayFractal OnDisplayFractal;

        /*Event when a update of work state is required*/
        public delegate void UpdateWorkInfo(string message);
        public event UpdateWorkInfo OnUpdateWorkInfo;

        /*Event when a update of work progress is required*/
        public delegate void UpdateResult(int progress);
        public event UpdateResult OnUpdateResult;

        /*Event when a update of client state is required*/
        public delegate void UpdateClient(Client client);
        public event UpdateClient OnUpdateClient;
        
        /// <summary>
        /// Server constructor
        /// </summary>
        /// <param name="listenPort"></param>
        /// <param name="sendPort"></param>
        /// <param name="nbrPacketToSend"></param>
        /// <param name="nbrPacket"></param>
        /// <param name="sendBroadcastPort"></param>
        /// <param name="calculatorClass"></param>
        /// <param name="cuttingClass"></param>
        /// <param name="savePacketsToFile"></param>
        public Server(int listenPort, int sendPort, int nbrPacketToSend, int nbrPacket, int sendBroadcastPort, string calculatorClass, string cuttingClass)
        {
            issueNumber = getIssueNumberFromFile();
            this.listenPort = listenPort;
            this.sendPort = sendPort;
            this.nbrPacketToSend = nbrPacketToSend;
            this.nbrPacket = nbrPacket;
            this.sendBroadcastPort = sendBroadcastPort;
            this.calculatorClass = calculatorClass;
            this.cuttingClass = cuttingClass;
        }
        /// <summary>
        /// Start the server
        /// </summary>
        public void startServer()
        {
            if (!serverStarted) //Start fisrt time
            {
                Receiver receiver = new Receiver();
                //Event on data reveived
                receiver.OnReceived += new Receiver.received(r_OnReceived);
                receiver.StartReceiver(listenPort);

                /*Get IP Address*/
                MyIPAddress myIPAddress = new MyIPAddress();
                if (myIPAddress.GetIPAddress(listenPort))
                    /*Send the broadcast with all IP of server*/
                    sendBroadcast(serverIPs);
                serverStarted = true;
            }
            else //Send only a broadcast
                sendBroadcast(serverIPs);
        }
        /// <summary>
        /// Event when as sended a data
        /// </summary>
        /// <param name="clientIP">Client IP address</param>
        /// <param name="data">Data received</param>
        private void r_OnReceived(string clientIP, byte[] data)
        {
            lock (lockThis)
            {
                /*Disassemble data*/
                List<DataReceived> listPackets = PacketDisassembler.Disassemble(data);
                /*Read each packets*/
                for (int i = 0; i < listPackets.Count; i++)
                {
                    DataReceived packet = listPackets[i];
                    Command cmd = (Command)BitConverter.ToInt32(data, 0);
                    switch (cmd)
                    {
                        case Command.Init:
                            Init dataInit = new Init(packet.data);
                            Client client = new Client(clientIP, dataInit.nbrCore, dataInit.memoryUsed, dataInit.listMethod, false, new List<int>(), 7000); //Create the client with her sended data
                            /*Init client*/
                            InitClient.initClient(client, sendPort, File.ReadAllText(calculatorClass));
                            if (!listClient.ContainsKey(clientIP)) //Client exist?
                            {
                                listClient.Add(client.ip, client);
                                if(OnUpdateClient!=null)
                                    OnUpdateClient(client); //Display client
                            }
                            else //Client already exist and not detected deconnexion
                            {
                                List<int> tmpCurrentWork = new List<int>(listClient[clientIP].currentWork);
                                foreach (int value in tmpCurrentWork)
                                {
                                    if (!dataWork.tasks.ContainsKey(value)) //Load packet non calculated
                                    {
                                        dataWork.tasks.Add(value, cuttedTask[value - 1]);
                                        listClient[clientIP].currentWork.Remove(value);
                                    }
                                }
                            }
                            break;
                        case Command.Result:
                            if (issueNumber == packet.issueNumber) //Working? Old sended packet?
                            {
                                if (!listResults.Contains(packet.noPacket)) //Task already calculated?
                                {
                                    listResults.Add(packet.noPacket);
                                }
                                if (listResults.Count == nbrPacket)
                                    timer.Stop();
                                listClient[clientIP].currentWork.Remove(packet.noPacket);
                                listClient[clientIP].interval = 7000;
                                int secondToCalculate = SecondSince1970.Get() - listPacketSended[packet.noPacket].secondSince1970;

                                if(OnUpdateWorkInfo!=null)
                                    OnUpdateWorkInfo(string.Format("{0} send result no {1}", clientIP, packet.noPacket));
                                OnUpdateResult((int)(((float)listResults.Count / cuttedTask.Length) * 100)); //Display numbre results

                                //Next works
                                if (listClient[clientIP].currentWork.Count == 0) //All the work has been done?
                                {
                                    if (dataWork != null && dataWork.tasks.Count != 0) //No more work?
                                    {
                                        avgCalculationTime = avgTime.calculateNewTime(SecondSince1970.Get() - listPacketSended[packet.noPacket].secondSince1970);  //Calculate average time from current time and sended packet
                                        timeRemaining = avgCalculationTime * (nbrPacket - listPacketSended.Count); //Calculate the time to remaining calculation
                                        dataWork.sendWork(ref listClient, ref listPacketSended, clientIP, sendPort, nbrPacketToSend, issueNumber);
                                    }
                                }
                                if (savePacketsToFile) //Save to file? or display fractale?
                                {
                                    string path = string.Format("{0}\\tmp\\result", Environment.CurrentDirectory); //Path of file data for this noPacket
                                    SaveToFile.save(path, FILE_EXTENTION, packet.noPacket.ToString(), packet.data);
                                }
                                else
                                {
                                    if(OnDisplayFractal!=null)
                                        OnDisplayFractal(fractale.createFractale(packet.noPacket, packet.data, nbrPacket));
                                }
                            }
                            break;
                        case Command.State:
                            break;
                        case Command.Initialized:
                            listClient[clientIP].initialised = true;
                            if (dataWork != null && dataWork.tasks.Count != 0) //No more work?
                                dataWork.sendWork(ref listClient, ref listPacketSended, clientIP, sendPort, nbrPacketToSend, issueNumber);
                            break;
                        case Command.CorrectIP:
                            if (clientIP != "127.0.0.1") //No local host
                                serverIPs += clientIP.ToString() + ";";
                            break;
                        //case Command.AliveClient:
                            //if (listClient != null && listClient.ContainsKey(clientIP))
                            //    listClient[clientIP].interval = packet.secondSince1970 * 7;
                            //break;
                    }
                }
                GC.Collect();
            }
        }
        /// <summary>
        /// Start the distribution of the task
        /// </summary>
        public void initDistributedWork(bool savePacketsToFile)
        {
            this.savePacketsToFile = savePacketsToFile; 
            if (issueNumber < int.MaxValue) //Max?
                issueNumber++;
            else
            {
                issueNumber = 0;
            }
            addIssueNumberToFile();
            /*Launch timer to display time remaining*/
            timer = new System.Windows.Forms.Timer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = 1000;
            timer.Start();

            /*New scan of clients*/
            //startServer();
            //listClient.Clear();

            SortedList<string, Client> tmpListClient = new SortedList<string, Client>(listClient);
            foreach (string item in tmpListClient.Keys)
	        {
                listClient[item].currentWork.Clear();
                listClient[item].interval = 7000;
	        }
            
            RemoveFilesFromFolder.Remove(Environment.CurrentDirectory + "\\" + "tmp"); //Remove previous temporary data   
            listResults.Clear();
            /*Create a task cut with class file*/
            Cutting cutting = new Cutting();
            cutting.LoadSource(File.ReadAllText(cuttingClass));
            /*Cut task on x packets*/
            cuttedTask = cutting.CuttingTask(nbrPacket);
            dataWork = new DataWork(cuttedTask);
            listClient = new SortedList<string, Client>(sendFirstWorkAllClient(listClient));
            fractale = new Fractal();
        }
        /// <summary>
        /// Send work to all clients
        /// </summary>
        /// <param name="list">List of clients</param>
        /// <returns>New list of client if someone offline </returns>
        private SortedList<string, Client> sendFirstWorkAllClient(SortedList<string, Client> list)
        {
            /*Send work work to all connected clients*/
            SortedList<string, Client> tmpListClient = new SortedList<string, Client>(list);
            foreach (string item in listClient.Keys)
            {
                Sender s = new Sender(listClient[item].ip, sendPort);
                if (!s.testConnexion())
                {
                    tmpListClient.Remove(item);
                    continue;
                }
                if (dataWork != null && listClient[item].initialised == true && dataWork.tasks.Count != 0 && listClient[item].currentWork.Count == 0) //No more work?
                    dataWork.sendWork(ref listClient, ref listPacketSended, listClient[item].ip, sendPort, nbrPacketToSend, issueNumber);
            }
            return tmpListClient;
        }
        /// <summary>
        /// Send a broadcast 
        /// </summary>
        /// <param name="ip">IP of server</param>
        private void sendBroadcast(string ip)
        {
            /*Send clients the server is alive*/
            int packetInfoLenght = 28;
            PacketInfo packetInfo = new PacketInfo(Command.Alive, 0, ip, packetInfoLenght, 0, 0);
            BroadcastSender.sendBroadcast(packetInfo.ToByte(), sendBroadcastPort);
        }
        /// <summary>
        /// Test the response time of each client and if exceeded -> each work assigment go too the stack
        /// </summary>
        /// <param name="sender">not used</param>
        /// <param name="e">not used</param>
        private void timer_Tick(object sender, EventArgs e)
        {
            lock (lockThis)
            {
                if (listClient != null && listClient.Count > 0)
                {
                    foreach (string s in listClient.Keys) //Each client
                    {
                        if (listClient[s].interval <= 0 && listClient[s].currentWork.Count != 0) //Response time exceeded?
                        {
                            List<int> tmpListCurrentWork = new List<int>(listClient[s].currentWork);
                            foreach (int value in tmpListCurrentWork) //Each work assignment
                            {
                                if (!dataWork.tasks.ContainsKey(value)) //Task already on the Stack?
                                {
                                    dataWork.tasks.Add(value, cuttedTask[value - 1]);
                                    listClient[s].currentWork.Remove(value); //Remove works asseignment
                                }
                            }
                            if (OnUpdateWorkInfo != null)
                                OnUpdateWorkInfo(string.Format("{0} disconnected", s));
                            sendFirstWorkAllClient(listClient); //Send work to all clients
                        }
                        else
                            listClient[s].interval -= 1000; //Remove one second
                    }
                }
            }
        }
        /// <summary>
        /// Stop the distribution of task
        /// </summary>
        public void stopDistributing()
        {
            dataWork = null;
        }
        private void addIssueNumberToFile()
        {
            SaveToFile.save(Environment.CurrentDirectory,".dat","saveIssueNumer",BitConverter.GetBytes(issueNumber));
        }
        private int getIssueNumberFromFile()
        {
            byte[] data = File.ReadAllBytes(string.Format("{0}saveIssueNumer.dat", Environment.CurrentDirectory));
            int value = BitConverter.ToInt32(data, 0);
            if (value >= 0 && value < Int32.MaxValue)
                return value;
            else
                return 0;
        }
    }
}
