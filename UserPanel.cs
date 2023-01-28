using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;


namespace Railway_Management_System
{
    public partial class UserPanel : Form
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

        public UserPanel()
        {
            this.MouseDown += new MouseEventHandler(move_window);

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserTimetable log = new UserTimetable();
            this.Hide();
            log.Show();
        }

        private void UserPanel_Load(object sender, EventArgs e)
        {

        }

        private void rectangleShape1_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Interface log = new Interface();
            this.Hide();
            log.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Booking log = new Booking();
            this.Hide();
            log.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RailMap log = new RailMap();
            this.Hide();
            log.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void developerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Developer log = new Developer();
            log.Show();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
          
        }

        private void eSOFTMetroCampusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.esoft.lk");
        }

        private void ovalShape1_Click(object sender, EventArgs e)
        {

        }

        private void ovalShape2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Infor log = new Infor();
            log.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            UserTimetable log = new UserTimetable();
            this.Hide();
            log.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Booking log = new Booking();
            this.Hide();
            log.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            RailMap log = new RailMap();
            
            log.Show();
        }

        private void contactUsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void facebookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com/search/top?q=esoft%20metro%20campus%20-%20kandy");
        }

        private void instagramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.instagram.com/esoft_metro_campus_kandy/");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"img/User Guide for Railway Management System.pdf");
        }
    }
}
