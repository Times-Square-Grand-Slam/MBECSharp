using System;
using System.Windows.Forms;

namespace MBECSharp
{
    public partial class MainScreen : Form
    {
        public MainScreen()
        {
            InitializeComponent();
        }

        private void btBDPack_Click(object sender, EventArgs e)
        {
            //Form fmBD = Application.OpenForms["BDPackages"];
            Form fmBD = Application.OpenForms["frmBirthday"];
            if (fmBD != null)
            {
                if (fmBD.WindowState == FormWindowState.Minimized)
                    fmBD.WindowState = FormWindowState.Maximized;

                fmBD.BringToFront();
            }
            else
            {
                new frmBirthday().Show();
            }
        }

        private void btCalendarView_Click(object sender, EventArgs e)
        {
            Form fmCnd = Application.OpenForms["CalendarView"];
            if (fmCnd != null)
            {
                if (fmCnd.WindowState == FormWindowState.Minimized)
                    fmCnd.WindowState = FormWindowState.Normal;

                fmCnd.BringToFront();
            }
            else
            {
                new CalendarView().Show();
            }
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
