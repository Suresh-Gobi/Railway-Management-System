using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Runtime.InteropServices;

namespace Railway_Management_System
{
    public partial class Ticket : Form
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

        public Ticket()
        {
            this.MouseDown += new MouseEventHandler(move_window);

            InitializeComponent();
        }

        private void Ticket_Load(object sender, EventArgs e)
        {
            label10.Text = Booking.SetValueForText1;
            label11.Text = Booking.SetValueForText2;
            label12.Text = Booking.SetValueForText3;
            label13.Text = Booking.SetValueForText4;
            label14.Text = Booking.SetValueForText5;
            label15.Text = Booking.SetValueForText6;
            label16.Text = Booking.SetValueForText7;
            label17.Text = Booking.SetValueForText8;
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bitmap, 0, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // source code from https://www.c-sharpcorner.com/article/print-dialog-and-print-preview-tools-using-entire-windows-form-to-print2/

            try
            {

                Panel panel = new Panel();
                this.Controls.Add(panel);
                Graphics grp = panel.CreateGraphics();
                Size formSize = this.ClientSize;
                bitmap = new Bitmap(formSize.Width, formSize.Height, grp);
                grp = Graphics.FromImage(bitmap);
                Point panelLocation = PointToScreen(panel.Location);
                grp.CopyFromScreen(panelLocation.X, panelLocation.Y, 0, 0, formSize);
                printPreviewDialog1.Document = printDocument1;
                printPreviewDialog1.PrintPreviewControl.Zoom = 1;
                printPreviewDialog1.ShowDialog();
            }
                
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        Bitmap bitmap;
        private void CaptureScreen()
        {
            Graphics myGraphics = this.CreateGraphics();
            Size s = this.Size;
            bitmap = new Bitmap(s.Width, s.Height, myGraphics);
            Graphics memoryGraphics = Graphics.FromImage(bitmap);
            memoryGraphics.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, s);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }  
    }
}
