using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace Railway_Management_System
{
    public partial class RailMap : Form
    {
        public RailMap()
        {
            InitializeComponent();
        }

        private void RailMap_Load(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://www.google.com/maps/d/u/0/embed?mid=1MWgzBW7Lpk_TT8gNhq1qCmYzeBg&ll=7.482788226536202%2C82.14008051122175&z=8");
        }
    }
}
