using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Railway_Management_System
{
    public partial class StartUp : Form
    {
        public StartUp()
        {
            InitializeComponent();
        }

        private void StartUp_Load(object sender, EventArgs e)
        {
            // Progress Bar code from www.c-sharpecorner.com 
            timer1.Start();
        }

        int startpoint = 30;
        private void timer1_Tick(object sender, EventArgs e)
        {
            // track progress bar by timer
            startpoint += 1;
            progressBar1.Value = startpoint;
            if (progressBar1.Value == 100)
            {
                progressBar1.Value = 0;
                timer1.Stop();
                Interface log = new Interface();
                this.Hide();
                log.Show();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
