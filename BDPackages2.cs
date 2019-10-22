using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace MBECSharp
{
    public partial class BDPackages2 : Form
    {
        private OleDbConnection conn = new OleDbConnection();
        public BDPackages2()
        {
            InitializeComponent();
            conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
                                    @"Data Source=\\TSSERVER\serverfolders\IT\IT Staff\Phil Darden\MBECSharp\Events.accdb;" +
                                    @"Persist Security Info=False;";
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

        private void BDPackages2_Load(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM Packages";

            try
            {
                conn.Open();

                string strPackage = "";
                OleDbCommand sqlstr = new OleDbCommand();
                sqlstr.Connection = conn;
                sqlstr.CommandText = sql;
                OleDbDataReader reader = sqlstr.ExecuteReader();
                while (reader.Read())
                {
                    strPackage = reader["Title"].ToString();

                    if (strPackage == "Basic")
                    {
                        txtBasicPr.Text = String.Format("{0:C}", reader["Cost"].ToString());
                        txtBasicAG.Text = String.Format("{0:C}", reader["AddGuest"].ToString());
                    }
                    else if (strPackage == "Movie")
                    {
                        txtMoviePr.Text = String.Format("{0:C}", reader["Cost"].ToString());
                        txtMovieAG.Text = String.Format("{0:C}", reader["AddGuest"].ToString());
                    }
                    else if (strPackage == "Arcade")
                    {
                        txtArcadePr.Text = String.Format("{0:C}", reader["Cost"].ToString());
                        txtArcadeAG.Text = String.Format("{0:C}", reader["AddGuest"].ToString());
                    }
                    else if (strPackage == "Bowling")
                    {
                        txtBowlPr.Text = String.Format("{0:C}", reader["Cost"].ToString());
                        txtBowlAG.Text = String.Format("{0:C}", reader["AddGuest"].ToString());
                    }
                    else if (strPackage == "Action")
                    {
                        txtActionPr.Text = String.Format("{0:C}", reader["Cost"].ToString());
                        txtActionAG.Text = String.Format("{0:C}", reader["AddGuest"].ToString());
                    }
                    else if (strPackage == "Custom")
                    {
                        txtCustomPr.Text = String.Format("{0:C}", reader["Cost"].ToString());
                        txtCustomAG.Text = String.Format("{0:C}", reader["AddGuest"].ToString());
                    }
                }

                conn.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
        }

        private void tsmiFileExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
