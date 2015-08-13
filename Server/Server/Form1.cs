using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Threading;

namespace DistributedComputing
{
    public partial class Form1 : Form
    {
        Thread thread;

        int sendPort;
        int nbrPacketToSend;
        int nbrPacket;
        int listenPort;
        int sendBroadcastPort;

        Server server;
        string cuttingClass;
        string calculatorClass;

        bool savePacketsToFile = false;
        private object lockThis = new object();
        /*Send message from the thread to the form*/
        delegate void StringParameterDelegate();
        delegate void StringParameter(string message);

        /*Send message from the thread to the form*/
        delegate void StringParameter2(int progress);
        private delegate void UpdateListbox(Client msg);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.CloudApp_Icon_32x32; //Get icon from ressources
            getNumericUpDownValues();
        }
        void UpdateClient(Client client)
        {
            if (InvokeRequired)
            {
                // We're not in the UI thread, so we need to call BeginInvoke
                BeginInvoke(new UpdateListbox(UpdateClient),new object[]{client});
                return;
            }
            // Must be on the UI thread if we've got this far
            lock (lockThis)
            {
                bool doesNodeAlreadyExist = false;
                foreach (TreeNode node in treeView1.Nodes)
                {
                    if (node.Text == client.ip)
                    {
                        doesNodeAlreadyExist = true;
                        break;
                    }
                }
                if (!doesNodeAlreadyExist)
                {
                    /*Display a new client*/
                    TreeNode treeNode;
                    treeNode = treeView1.Nodes.Add(client.ip);
                    treeNode.Nodes.Add(string.Format("{0} core", client.nbrCore));
                    //listBoxWorkInfo.Items.Add(string.Format("{0} interval", client.interval));  
                }
            }
        }

        void UpdateWorkInfo(string message)
        {
            if (InvokeRequired)
            {
                // We're not in the UI thread, so we need to call BeginInvoke
                BeginInvoke(new StringParameter(UpdateWorkInfo), new object[] { message });
                return;
            }
            // Must be on the UI thread if we've got this far
            lock (lockThis)
            {
                listBoxWorkInfo.Items.Add(message);
            }
        }

        void UpdateResult(int progress)
        {
            if (InvokeRequired)
            {
                // We're not in the UI thread, so we need to call BeginInvoke
                BeginInvoke(new StringParameter2(UpdateResult), new object[] { progress });
                return;
            }
            // Must be on the UI thread if we've got this far
            lock (lockThis)
            {
                /*Set progress bar value*/
                progressBar.Value = progress;
                progressBar.Refresh();               
            }
        }
        private void btStartServer_Click(object sender, EventArgs e)
        {
            if(server==null)
                server = new Server(listenPort, sendPort, nbrPacketToSend, nbrPacket, sendBroadcastPort, calculatorClass, cuttingClass);
            server.startServer();
            server.OnUpdateClient += new Server.UpdateClient(server_OnUpdateClient);
            server.OnDisplayFractal += new Server.displayFractal(server_OnDisplayFractal);
            server.OnUpdateResult += new Server.UpdateResult(server_OnUpdateResult);
            server.OnUpdateWorkInfo += new Server.UpdateWorkInfo(server_OnUpdateWorkInfo);
        }

        void server_OnUpdateWorkInfo(string message)
        {
            UpdateWorkInfo(message);
        }

        void server_OnUpdateResult(int progress)
        {
            UpdateResult(progress);
        }

        void server_OnDisplayFractal(Bitmap bmp)
        {
            displayFractaleNComputer(bmp);
        }

        void server_OnUpdateClient(Client client)
        {
            UpdateClient(client);
        }

        private void btLoadTask_Click(object sender, EventArgs e)
        {
           ///*Load and test cutting class*/
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Ajouter fichier découpeur";
            ofd.Filter = "Class files (.cs)|*.cs";
            ofd.InitialDirectory = Environment.CurrentDirectory;
            OpenFileDialog ofd2 = new OpenFileDialog();
            ofd2.Title = "Ajouter fichier de calcul";
            ofd2.Filter = "Class files (.cs)|*.cs";
            ofd2.InitialDirectory = Environment.CurrentDirectory;
            if (ofd.ShowDialog() == DialogResult.OK) //File selected?
            {
                string tmpCuttingClass = ofd.FileName;
                if (ofd2.ShowDialog() == DialogResult.OK) //File selected?
                {
                    string tmpCalculatorClass = ofd2.FileName;
                    Cutting c = new Cutting();
                    Calculation calc = new Calculation();
                    
                    bool cuttingClassCompilable = c.LoadSource(File.ReadAllText(tmpCuttingClass)); 
                    bool calculateClassCompilable = calc.LoadSource(File.ReadAllText(tmpCalculatorClass));
                    if (cuttingClassCompilable) //Compilable class?
                    {
                        if (calculateClassCompilable) //Compilable class?
                        {
                            cuttingClass = tmpCuttingClass; 
                            calculatorClass = tmpCalculatorClass;
                            enableButtons(); //Enable all buttons
                        }
                        else
                            listBoxWorkInfo.Items.Add(string.Format("La classe {0} ne respecte pas les conditions requises", ofd2.SafeFileName));
                    }
                    else
                        listBoxWorkInfo.Items.Add(string.Format("La classe {0} ne respecte pas les conditions requises", ofd.SafeFileName));
                }
                else
                {
                    listBoxWorkInfo.Items.Add("Please load a calcul file");
                }
            }
            else
            {
                listBoxWorkInfo.Items.Add("Please load a cutting file");
            }
        }


        private void btStartWork_Click(object sender, EventArgs e)
        {
            if (btStartWork.Text == "Démarrer le calcul")
            {
                if (server != null)
                {
                    listBoxWorkInfo.Items.Clear();
                    savePacketsToFile = true;
                    server.initDistributedWork(savePacketsToFile);
                }
                btStartWork.Text = "Stopper le calcul";
            }
            else
            {
                if(server!=null)
                    server.stopDistributing();
                btStartWork.Text = "Démarrer le calcul";
            }
        }
        
       
        private void initWork()
        {
            /*Stop thread already lauch*/
            if (thread != null)
                thread.Abort();

            /*Launch calculation with this computer*/
            thread = new Thread(new ThreadStart(doWork));
            thread.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            //if (timeRemaining > 0)
            //    timeRemaining--;
        }
        private void doWork()
        {
            CuttingTask cuttingTask = new CuttingTask();
            ClassCalculator c = new ClassCalculator();
            Fractal f = new Fractal();
            byte[][] data = cuttingTask.CutTask(nbrPacket);
           
            for (int i = 0; i < data.Length; i++)
			{
                byte[] result = c.Calculate(data[i]);
                displayFractale1Computer(f.createFractale(i + 1, result, nbrPacket));
			}
        }

        private void btDisplayFractale_Click(object sender, EventArgs e)
        {
            savePacketsToFile = false;
            server.initDistributedWork(savePacketsToFile);
            initWork();
        }
        private void displayFractaleNComputer(Bitmap bmp)
        {
            try
            {
                pictureBoxResultNComputer.Image = bmp;
            }
            catch { }
        }
        private void displayFractale1Computer(Bitmap bmp)
        {
            try
            {
                pictureBoxResult1Computer.Image = bmp;
            }
            catch { }
        }

        private void numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            getNumericUpDownValues();
        }
        private void getNumericUpDownValues()
        {
            sendPort = Convert.ToInt32(numericUpDownSendPort.Value);
            nbrPacket = Convert.ToInt32(numericUpDownNbrPackets.Value);
            listenPort = Convert.ToInt32(numericUpDownListenPort.Value);
            nbrPacketToSend = Convert.ToInt32(numericUpDownNbrPacketsToSend.Value);
            sendBroadcastPort = Convert.ToInt32(numericUpDownSendBroadcastPort.Value);
        }
        private void enableButtons()
        {
            btStartServer.Enabled = true;
            btStartWork.Enabled = true;
            btDisplayFractale.Enabled = true;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aPropoDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.Show();
        }    
    }
}
