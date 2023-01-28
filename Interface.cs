using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Railway_Management_System
{
    public partial class Interface : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\SURESH GOBI\Documents\Railway Management System\Railway Management System\Railway Management System\RW_account.mdf;Integrated Security=True");
        SqlCommand cmnd;
        SqlDataReader dr;
        public Interface()
        {
            InitializeComponent();
        }

        private void Interface_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {




                Create log = new Create();
                this.Hide();
                log.Show();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {

                // Login 
                string nic = maskedTextBox1.Text;
                string pass = maskedTextBox2.Text;
                cmnd = new SqlCommand();
                con.Open();
                cmnd.Connection = con;
                cmnd.CommandText = "SELECT * FROM Account where NIC_No='" + maskedTextBox1.Text + "' AND Password='" + maskedTextBox2.Text + "'";
                dr = cmnd.ExecuteReader();
                if (dr.Read())
                {
                    
                }
                else
                {
                    MessageBox.Show("Invalid Login please check username and password");
                }

                 UserPanel log = new UserPanel();
                 this.Hide();
                 log.Show();

                con.Close();


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Forgot log = new Forgot();
                this.Hide();
                log.Show();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Admin log = new Admin();
            this.Hide();
            log.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
