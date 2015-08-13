namespace DistributedComputing
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageServer = new System.Windows.Forms.TabPage();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.listBoxWorkInfo = new System.Windows.Forms.ListBox();
            this.btLoadTask = new System.Windows.Forms.Button();
            this.btStartWork = new System.Windows.Forms.Button();
            this.groupBoxServerOptions = new System.Windows.Forms.GroupBox();
            this.numericUpDownNbrPacketsToSend = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownSendBroadcastPort = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDownNbrPackets = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownSendPort = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDownListenPort = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btStartServer = new System.Windows.Forms.Button();
            this.tabPageFractal = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pictureBoxResult1Computer = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBoxResultNComputer = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btDisplayFractale = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fichierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aPropoDeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPageServer.SuspendLayout();
            this.groupBoxServerOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNbrPacketsToSend)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSendBroadcastPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNbrPackets)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSendPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownListenPort)).BeginInit();
            this.tabPageFractal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxResult1Computer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxResultNComputer)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPageServer);
            this.tabControl1.Controls.Add(this.tabPageFractal);
            this.tabControl1.Location = new System.Drawing.Point(12, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1298, 758);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageServer
            // 
            this.tabPageServer.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageServer.Controls.Add(this.treeView1);
            this.tabPageServer.Controls.Add(this.listBoxWorkInfo);
            this.tabPageServer.Controls.Add(this.btLoadTask);
            this.tabPageServer.Controls.Add(this.btStartWork);
            this.tabPageServer.Controls.Add(this.groupBoxServerOptions);
            this.tabPageServer.Controls.Add(this.btStartServer);
            this.tabPageServer.Location = new System.Drawing.Point(4, 22);
            this.tabPageServer.Name = "tabPageServer";
            this.tabPageServer.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageServer.Size = new System.Drawing.Size(1290, 732);
            this.tabPageServer.TabIndex = 0;
            this.tabPageServer.Text = "Serveur";
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView1.Location = new System.Drawing.Point(1061, 285);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(220, 441);
            this.treeView1.TabIndex = 10;
            // 
            // listBoxWorkInfo
            // 
            this.listBoxWorkInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.listBoxWorkInfo.FormattingEnabled = true;
            this.listBoxWorkInfo.Location = new System.Drawing.Point(6, 7);
            this.listBoxWorkInfo.Name = "listBoxWorkInfo";
            this.listBoxWorkInfo.Size = new System.Drawing.Size(302, 719);
            this.listBoxWorkInfo.TabIndex = 7;
            // 
            // btLoadTask
            // 
            this.btLoadTask.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btLoadTask.Location = new System.Drawing.Point(1160, 198);
            this.btLoadTask.Name = "btLoadTask";
            this.btLoadTask.Size = new System.Drawing.Size(118, 23);
            this.btLoadTask.TabIndex = 6;
            this.btLoadTask.Text = "Charger une tâche...";
            this.btLoadTask.UseVisualStyleBackColor = true;
            this.btLoadTask.Click += new System.EventHandler(this.btLoadTask_Click);
            // 
            // btStartWork
            // 
            this.btStartWork.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btStartWork.Enabled = false;
            this.btStartWork.Location = new System.Drawing.Point(1160, 256);
            this.btStartWork.Name = "btStartWork";
            this.btStartWork.Size = new System.Drawing.Size(118, 23);
            this.btStartWork.TabIndex = 5;
            this.btStartWork.Text = "Démarrer le calcul";
            this.btStartWork.UseVisualStyleBackColor = true;
            this.btStartWork.Click += new System.EventHandler(this.btStartWork_Click);
            // 
            // groupBoxServerOptions
            // 
            this.groupBoxServerOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxServerOptions.Controls.Add(this.numericUpDownNbrPacketsToSend);
            this.groupBoxServerOptions.Controls.Add(this.numericUpDownSendBroadcastPort);
            this.groupBoxServerOptions.Controls.Add(this.label5);
            this.groupBoxServerOptions.Controls.Add(this.label4);
            this.groupBoxServerOptions.Controls.Add(this.numericUpDownNbrPackets);
            this.groupBoxServerOptions.Controls.Add(this.numericUpDownSendPort);
            this.groupBoxServerOptions.Controls.Add(this.label3);
            this.groupBoxServerOptions.Controls.Add(this.numericUpDownListenPort);
            this.groupBoxServerOptions.Controls.Add(this.label2);
            this.groupBoxServerOptions.Controls.Add(this.label1);
            this.groupBoxServerOptions.Location = new System.Drawing.Point(1043, 6);
            this.groupBoxServerOptions.Name = "groupBoxServerOptions";
            this.groupBoxServerOptions.Size = new System.Drawing.Size(241, 150);
            this.groupBoxServerOptions.TabIndex = 4;
            this.groupBoxServerOptions.TabStop = false;
            this.groupBoxServerOptions.Text = "Options:";
            // 
            // numericUpDownNbrPacketsToSend
            // 
            this.numericUpDownNbrPacketsToSend.Location = new System.Drawing.Point(135, 118);
            this.numericUpDownNbrPacketsToSend.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDownNbrPacketsToSend.Name = "numericUpDownNbrPacketsToSend";
            this.numericUpDownNbrPacketsToSend.Size = new System.Drawing.Size(100, 20);
            this.numericUpDownNbrPacketsToSend.TabIndex = 12;
            this.numericUpDownNbrPacketsToSend.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownNbrPacketsToSend.ValueChanged += new System.EventHandler(this.numericUpDown_ValueChanged);
            // 
            // numericUpDownSendBroadcastPort
            // 
            this.numericUpDownSendBroadcastPort.Location = new System.Drawing.Point(135, 70);
            this.numericUpDownSendBroadcastPort.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDownSendBroadcastPort.Name = "numericUpDownSendBroadcastPort";
            this.numericUpDownSendBroadcastPort.Size = new System.Drawing.Size(100, 20);
            this.numericUpDownSendBroadcastPort.TabIndex = 12;
            this.numericUpDownSendBroadcastPort.Value = new decimal(new int[] {
            1200,
            0,
            0,
            0});
            this.numericUpDownSendBroadcastPort.ValueChanged += new System.EventHandler(this.numericUpDown_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Nbr paquets a envoyer:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Port envoi broadcast:";
            // 
            // numericUpDownNbrPackets
            // 
            this.numericUpDownNbrPackets.Location = new System.Drawing.Point(135, 95);
            this.numericUpDownNbrPackets.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDownNbrPackets.Name = "numericUpDownNbrPackets";
            this.numericUpDownNbrPackets.Size = new System.Drawing.Size(100, 20);
            this.numericUpDownNbrPackets.TabIndex = 10;
            this.numericUpDownNbrPackets.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDownNbrPackets.ValueChanged += new System.EventHandler(this.numericUpDown_ValueChanged);
            // 
            // numericUpDownSendPort
            // 
            this.numericUpDownSendPort.Location = new System.Drawing.Point(135, 45);
            this.numericUpDownSendPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numericUpDownSendPort.Name = "numericUpDownSendPort";
            this.numericUpDownSendPort.Size = new System.Drawing.Size(100, 20);
            this.numericUpDownSendPort.TabIndex = 9;
            this.numericUpDownSendPort.Value = new decimal(new int[] {
            1100,
            0,
            0,
            0});
            this.numericUpDownSendPort.ValueChanged += new System.EventHandler(this.numericUpDown_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Port d\'envoi client:";
            // 
            // numericUpDownListenPort
            // 
            this.numericUpDownListenPort.Location = new System.Drawing.Point(135, 19);
            this.numericUpDownListenPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numericUpDownListenPort.Name = "numericUpDownListenPort";
            this.numericUpDownListenPort.Size = new System.Drawing.Size(100, 20);
            this.numericUpDownListenPort.TabIndex = 7;
            this.numericUpDownListenPort.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownListenPort.ValueChanged += new System.EventHandler(this.numericUpDown_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nbr paquets:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Port d\'écoute:";
            // 
            // btStartServer
            // 
            this.btStartServer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btStartServer.Enabled = false;
            this.btStartServer.Location = new System.Drawing.Point(1160, 227);
            this.btStartServer.Name = "btStartServer";
            this.btStartServer.Size = new System.Drawing.Size(118, 23);
            this.btStartServer.TabIndex = 3;
            this.btStartServer.Text = "Démarrer serveur";
            this.btStartServer.UseVisualStyleBackColor = true;
            this.btStartServer.Click += new System.EventHandler(this.btStartServer_Click);
            // 
            // tabPageFractal
            // 
            this.tabPageFractal.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageFractal.Controls.Add(this.splitContainer1);
            this.tabPageFractal.Controls.Add(this.btDisplayFractale);
            this.tabPageFractal.Location = new System.Drawing.Point(4, 22);
            this.tabPageFractal.Name = "tabPageFractal";
            this.tabPageFractal.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageFractal.Size = new System.Drawing.Size(1290, 732);
            this.tabPageFractal.TabIndex = 1;
            this.tabPageFractal.Text = "Fractale";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(3, 35);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pictureBoxResult1Computer);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pictureBoxResultNComputer);
            this.splitContainer1.Panel2.Controls.Add(this.label7);
            this.splitContainer1.Size = new System.Drawing.Size(1281, 691);
            this.splitContainer1.SplitterDistance = 639;
            this.splitContainer1.TabIndex = 6;
            // 
            // pictureBoxResult1Computer
            // 
            this.pictureBoxResult1Computer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxResult1Computer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxResult1Computer.Location = new System.Drawing.Point(3, 58);
            this.pictureBoxResult1Computer.Name = "pictureBoxResult1Computer";
            this.pictureBoxResult1Computer.Size = new System.Drawing.Size(633, 470);
            this.pictureBoxResult1Computer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxResult1Computer.TabIndex = 2;
            this.pictureBoxResult1Computer.TabStop = false;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "1 machine";
            // 
            // pictureBoxResultNComputer
            // 
            this.pictureBoxResultNComputer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxResultNComputer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxResultNComputer.Location = new System.Drawing.Point(3, 58);
            this.pictureBoxResultNComputer.Name = "pictureBoxResultNComputer";
            this.pictureBoxResultNComputer.Size = new System.Drawing.Size(632, 470);
            this.pictureBoxResultNComputer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxResultNComputer.TabIndex = 3;
            this.pictureBoxResultNComputer.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "N machine";
            // 
            // btDisplayFractale
            // 
            this.btDisplayFractale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btDisplayFractale.Enabled = false;
            this.btDisplayFractale.Location = new System.Drawing.Point(1169, 6);
            this.btDisplayFractale.Name = "btDisplayFractale";
            this.btDisplayFractale.Size = new System.Drawing.Size(115, 23);
            this.btDisplayFractale.TabIndex = 1;
            this.btDisplayFractale.Text = "Afficher fractale";
            this.btDisplayFractale.UseVisualStyleBackColor = true;
            this.btDisplayFractale.Click += new System.EventHandler(this.btDisplayFractale_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fichierToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1322, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fichierToolStripMenuItem
            // 
            this.fichierToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fichierToolStripMenuItem.Name = "fichierToolStripMenuItem";
            this.fichierToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.fichierToolStripMenuItem.Text = "Fichier";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aPropoDeToolStripMenuItem});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(24, 20);
            this.aboutToolStripMenuItem.Text = "?";
            // 
            // aPropoDeToolStripMenuItem
            // 
            this.aPropoDeToolStripMenuItem.Name = "aPropoDeToolStripMenuItem";
            this.aPropoDeToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.aPropoDeToolStripMenuItem.Text = "À propo de...";
            this.aPropoDeToolStripMenuItem.Click += new System.EventHandler(this.aPropoDeToolStripMenuItem_Click);
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(12, 787);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(1298, 23);
            this.progressBar.TabIndex = 2;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1322, 814);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(800, 700);
            this.Name = "Form1";
            this.Text = "Serveur";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPageServer.ResumeLayout(false);
            this.groupBoxServerOptions.ResumeLayout(false);
            this.groupBoxServerOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNbrPacketsToSend)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSendBroadcastPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNbrPackets)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSendPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownListenPort)).EndInit();
            this.tabPageFractal.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxResult1Computer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxResultNComputer)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageServer;
        private System.Windows.Forms.TabPage tabPageFractal;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fichierToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btStartWork;
        private System.Windows.Forms.GroupBox groupBoxServerOptions;
        private System.Windows.Forms.Button btStartServer;
        private System.Windows.Forms.Button btLoadTask;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDownListenPort;
        private System.Windows.Forms.NumericUpDown numericUpDownNbrPackets;
        private System.Windows.Forms.NumericUpDown numericUpDownSendPort;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDownSendBroadcastPort;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDownNbrPacketsToSend;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox listBoxWorkInfo;
        private System.Windows.Forms.Button btDisplayFractale;
        private System.Windows.Forms.PictureBox pictureBoxResult1Computer;
        private System.Windows.Forms.PictureBox pictureBoxResultNComputer;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aPropoDeToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
    }
}

