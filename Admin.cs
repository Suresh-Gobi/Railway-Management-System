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
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            try
            {
                // admin account 01
                String admin01 = "railwayadmin01";
                String pass01 = "groot123";

                // admin account 02
                String admin02 = "railwayadmin02";
                String pass02 = "railway081";

                // admin aacount 03
                String admin03 = "railwayadmin03";
                String pass03 = "government567";

                if (maskedTextBox1.Text == admin01 && maskedTextBox2.Text == pass01)
                {
                    AdminPanel log = new AdminPanel();
                    this.Hide();
                    log.Show();
                }
                else if (maskedTextBox1.Text == admin02 && maskedTextBox2.Text == pass02)
                {
                    AdminPanel log = new AdminPanel();
                    this.Hide();
                    log.Show();
                }
                else if (maskedTextBox1.Text == admin03 && maskedTextBox2.Text == pass03)
                {
                    AdminPanel log = new AdminPanel();
                    this.Hide();
                    log.Show();
                }
                else {

                    MessageBox.Show("Invalid Username & Password", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
            
            
                
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Interface log = new Interface();
            this.Hide();
            log.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
