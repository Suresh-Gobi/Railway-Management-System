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
    public partial class Forgot : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\SURESH GOBI\Documents\Railway Management System\Railway Management System\Railway Management System\RW_account.mdf;Integrated Security=True");
        public Forgot()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                 con.Open();
                string query_updatesql = "UPDATE Account SET Password = '" + maskedTextBox2.Text + "' where NIC_No ='" + maskedTextBox1.Text + "'";
                SqlCommand cmnd = new SqlCommand(query_updatesql, con);
                SqlDataReader r = cmnd.ExecuteReader();

                while (r.Read())
                {
                    maskedTextBox2.Text = r[1].ToString();
                    maskedTextBox1.Text = r[2].ToString();
                }

                if (maskedTextBox2.Text == maskedTextBox3.Text)
                {
                    MessageBox.Show("New Password Created");

                    Interface log = new Interface();
                    this.Hide();
                    log.Show();
                }

                else
                {
                    MessageBox.Show("Password not match");
                }



                con.Close();
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Forgot_Load(object sender, EventArgs e)
        {

        }
    }
}
