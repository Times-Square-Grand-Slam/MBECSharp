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
    public partial class Form1 : Form
    {
        public Form1()
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
    }
}
