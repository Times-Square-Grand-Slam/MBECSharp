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
    public partial class Food : Form
    {
        int PID;

        public Food(int id)
        {
            InitializeComponent();
            PID = id;
        }

        private void Food_Load(object sender, EventArgs e)
        {

        }
    }
}
