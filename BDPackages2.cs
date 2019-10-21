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
    public partial class BDPackages2 : Form
    {
        public BDPackages2()
        {
            InitializeComponent();
        }

        private void BnFood_Click(object sender, EventArgs e)
        {
            new Food().Show();
        }

        private void BnMovie_Click(object sender, EventArgs e)
        {
            new Movie().Show();
        }

        private void BnBowl_Click(object sender, EventArgs e)
        {
            new Bowling().Show();
        }

        private void BnArcade_Click(object sender, EventArgs e)
        {
            new Arcade().Show();
        }

        private void BnAct_Click(object sender, EventArgs e)
        {
            new Activities().Show();
        }

        private void BnPartyArea_Click(object sender, EventArgs e)
        {
            new Area().Show();
        }

        private void BnMisc_Click(object sender, EventArgs e)
        {
            new Misc().Show();
        }
    }
}
