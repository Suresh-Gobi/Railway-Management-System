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
    public partial class Booking : Form
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
        public static string SetValueForText1 = "";
        public static string SetValueForText2 = "";
        public static string SetValueForText3 = "";
        public static string SetValueForText4 = "";
        public static string SetValueForText5 = "";
        public static string SetValueForText6 = "";
        public static string SetValueForText7 = "";
        public static string SetValueForText8 = "";
        
        public Booking()
        {
            this.MouseDown += new MouseEventHandler(move_window);

            InitializeComponent();
        }

        private void rectangleShape1_Click(object sender, EventArgs e)
        {

        }

        private void Booking_Load(object sender, EventArgs e)
        {
            
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                SqlDataAdapter data = new SqlDataAdapter(@"SELECT * FROM Time_Table WHERE Frm = '" + textBox3.Text + "' AND Too ='"+textBox4.Text+"'",con);


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

        private void textBox6_TextChanged_1(object sender, EventArgs e)
        {
            textBox9.Text = Convert.ToString(Convert.ToInt32(textBox6.Text));  
            con.Open();
            string Id = textBox6.Text;
            string query_search = "SELECT Fare FROM Time_Table WHERE Train_No = '" + textBox6.Text + "'";
            SqlCommand cmnd = new SqlCommand(query_search, con);
            SqlDataReader r = cmnd.ExecuteReader();

            while (r.Read())
            {
                
                textBox11.Text = Convert.ToString(r[0].ToString());

            }

            con.Close();

            
            
            

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            // source code from https://www.c-sharpcorner.com/blogs/add-and-multiply-the-two-textbox-values-and-automaticallydisplay-the-third-textbox-in-c-sharp
            textBox10.Text = Convert.ToString(Convert.ToInt32(textBox5.Text));
            textBox12.Text = Convert.ToString(Convert.ToInt32(textBox11.Text) * Convert.ToInt32(textBox5.Text)); 
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox4_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            
        }

        private void label4_Click_1(object sender, EventArgs e)
        {

        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
            string query_insert = "INSERT INTO booking VALUES('" + textBox1.Text + "','" + textBox7.Text + "','" + textBox2.Text + "','" + textBox8.Text + "','" + textBox13.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox6.Text + "','" + textBox5.Text + "','" + comboBox1.Text + "','" + dateTimePicker1.Text + "','" + textBox12.Text + "')";
            SqlCommand cmnd = new SqlCommand(query_insert,con);
            cmnd.ExecuteNonQuery();
            con.Close();

            SetValueForText1 = textBox6.Text;
            SetValueForText2 = textBox12.Text;
            SetValueForText3 = textBox3.Text;
            SetValueForText4 = textBox4.Text;
            SetValueForText5 = dateTimePicker1.Text;
            SetValueForText6 = textBox5.Text;
            SetValueForText7 = textBox2.Text;
            SetValueForText8 = textBox8.Text;
             
            Ticket log = new Ticket();
            log.Show();

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox7.Clear();
           
            }


            
            catch (Exception ex)
            {

               MessageBox.Show(ex.Message);


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UserPanel log = new UserPanel();
            this.Close();
            log.Show();
        }
    }
}
