using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DistributedComputing
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void About_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.CloudApp_Icon_512x512;
            this.Icon = Properties.Resources.CloudApp_Icon_32x32;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
