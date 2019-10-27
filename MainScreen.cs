using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MBECSharp
{
    public partial class MainScreen : Form
    {
        public MainScreen()
        {
            InitializeComponent();
        }

        private void BtBDPack_Click(object sender, EventArgs e)
        {
            new BDPackages().Show();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            new BDPackages2().Show();
        }

        private void btCalendarView_Click(object sender, EventArgs e)
        {
            new CalendarView().Show();
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btCorpPack_Click(object sender, EventArgs e)
        {
            
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new About().Show();
        }
    }
}
