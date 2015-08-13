using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Diagnostics;

namespace ClientTest
{
    public partial class Form1 : Form
    {
        int serverPort = 1000;
        int receiverPort = 1100;
        int broadcastReceiverPort = 1200;
        string serverIP;

        private object lockThis = new object();

        List<Task> listTasks = new List<Task>();
        NotifyIcon myNotifyIcon;

        Server server;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            showNotifyicon();
            /*Hide form*/
            this.Hide();
            /*Hide from taskbar*/
            this.ShowInTaskbar = false;

            serverIP = tbIpServer.Text;

            server = new Server(serverPort, receiverPort, broadcastReceiverPort, serverIP);

           
        }
        private void showNotifyicon()
        {
            /*Show notify icon*/
            myNotifyIcon = new NotifyIcon();
            myNotifyIcon.BalloonTipText = "Client still working...";
            myNotifyIcon.BalloonTipTitle = "Client grid computing";
            myNotifyIcon.BalloonTipIcon = ToolTipIcon.Info;
            myNotifyIcon.DoubleClick += new EventHandler(myNotifyIcon_DoubleClick);
            string iconPath = string.Format("{0}\\CloudApp-Icon-32x32.ico", Environment.CurrentDirectory);
            myNotifyIcon.Icon = Properties.Resources.CloudApp_Icon_32x32;
            myNotifyIcon.Visible = true;
            myNotifyIcon.ShowBalloonTip(1000);
        }
        void myNotifyIcon_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
            this.ShowInTaskbar = true;
        }
       

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            myNotifyIcon.Dispose();
        }
    }
}
