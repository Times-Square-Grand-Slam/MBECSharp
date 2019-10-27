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
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void lklbGithub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Specify that the link was visited.
            this.lklbGithub.LinkVisited = true;

            // Navigate to a URL
            System.Diagnostics.Process.Start("https://github.com/Times-Square-Grand-Slam/MBECSharp");
        }

        private void lklbReleaseNotes_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Specify that the link was visited.
            this.lklbReleaseNotes.LinkVisited = true;

            // Navigate to a URL
            System.Diagnostics.Process.Start("https://github.com/Times-Square-Grand-Slam/MBECSharp/wiki");
        }
    }
}
