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
using System.Runtime.InteropServices;

namespace Railway_Management_System
{
    public partial class AdminBooking : Form
    {

        // code for form moving without title bar!! from (https://codingvision.net/c-moving-form-without-border-title-bar)

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int LPAR);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        const int WM_NCLBUTTONDOWN = 0xA1;
        const int HT_CAPTION = 0x2;

        private void move_window(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }


        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\SURESH GOBI\Documents\Railway Management System\Railway Management System\Railway Management System\RW_account.mdf;Integrated Security=True");
        public AdminBooking()
        {
            this.MouseDown += new MouseEventHandler(move_window);

            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void AdminBooking_Load(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                 con.Open();

                SqlDataAdapter data = new SqlDataAdapter(@"SELECT * FROM Booking ",con);


                DataTable t = new DataTable();

                dataGridView1.DataSource = t;
                
                data.Fill(t);
                con.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                string query_delete = "SELCET * FROM Booking WHERE NIC_No = '" + textBox1.Text + "'";
                SqlCommand cmnd = new SqlCommand(query_delete, con);
                SqlDataReader r = cmnd.ExecuteReader();

                while (r.Read())
                {
                    textBox1.Text = r[1].ToString();

                }


                con.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                string query_delete = "DELETE FROM Booking WHERE NIC_No = '" + textBox1.Text + "'";
                SqlCommand cmnd = new SqlCommand(query_delete, con);
                SqlDataReader r = cmnd.ExecuteReader();

                while (r.Read())
                {
                    textBox1.Text = r[1].ToString();
                    
                }

                
                con.Close();



            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            AdminPanel log = new AdminPanel();
            this.Hide();
            log.Show();
        }
    }
}
