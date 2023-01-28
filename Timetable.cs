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

    public partial class Timetable : Form
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
        public Timetable()
        {
            
            this.MouseDown += new MouseEventHandler(move_window);

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string query_insert = "INSERT INTO Time_Table VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "')";
                SqlCommand cmnd = new SqlCommand(query_insert, con);
                cmnd.ExecuteNonQuery();
                con.Close();

                string message = "Data Added";
                string title = "Succesful";
                MessageBox.Show(message, title);

                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                textBox7.Clear();



            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string Id = textBox1.Text;
                string query_search = "SELECT * FROM Time_Table WHERE Train_No = '" + textBox1.Text + "'";
                SqlCommand cmnd = new SqlCommand(query_search, con);
                SqlDataReader r = cmnd.ExecuteReader();

                while (r.Read())
                {
                    textBox2.Text = r[1].ToString();
                    textBox3.Text = r[2].ToString();
                    textBox5.Text = r[3].ToString();
                    textBox4.Text = r[4].ToString();
                    textBox7.Text = r[5].ToString();
                }

                con.Close();



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

                con.Open();
                string query_updatesql = "UPDATE Time_Table set Depart = '" + textBox5.Text + "',Arrive = '" + textBox4.Text + "',Frm = '" + textBox2.Text + "',Too = '" + textBox3.Text + "',Fare = '" + textBox7.Text + "' where Train_No ='" + textBox1.Text + "'";
                SqlCommand cmnd = new SqlCommand(query_updatesql, con);
                SqlDataReader r = cmnd.ExecuteReader();

                while (r.Read())
                {
                    textBox5.Text = r[1].ToString();
                    textBox4.Text = r[2].ToString();
                    textBox2.Text = r[3].ToString();
                    textBox3.Text = r[4].ToString();
                    textBox7.Text = r[5].ToString();
                }

                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                textBox7.Clear();

                MessageBox.Show("Updated");

                con.Close();


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {

                con.Open();

                string query_delete = "DELETE FROM Time_Table WHERE Train_No = '" + textBox1.Text + "'";
                SqlCommand cmnd = new SqlCommand(query_delete, con);
                SqlDataReader r = cmnd.ExecuteReader();

                while (r.Read())
                {
                    textBox2.Text = r[1].ToString();
                    textBox3.Text = r[2].ToString();
                    textBox4.Text = r[2].ToString();
                    textBox5.Text = r[2].ToString();
                    textBox6.Text = r[2].ToString();
                    textBox7.Text = r[2].ToString();
                }

                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                textBox7.Clear();

                MessageBox.Show("Deleted");
                con.Close();



            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {

                con.Open();

                SqlDataAdapter data = new SqlDataAdapter(@"SELECT * FROM 

                   Time_Table", con);

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

        private void Timetable_Load(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            AdminPanel log = new AdminPanel();
            this.Hide();
            log.Show();
        }
    }
}
