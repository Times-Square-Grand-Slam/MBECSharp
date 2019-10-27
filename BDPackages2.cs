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

                double dbPrice = 0;
                double dbAG = 0;
                string strPackage = "";
                OleDbCommand sqlstr = new OleDbCommand();
                sqlstr.Connection = conn;
                sqlstr.CommandText = sql;
                OleDbDataReader reader = sqlstr.ExecuteReader();
                while (reader.Read())
                {
                    strPackage = reader["Title"].ToString();
                    dbPrice = Convert.ToDouble(reader["Cost"].ToString());
                    dbAG = Convert.ToDouble(reader["AddGuest"].ToString());
                    if (strPackage == "Basic")
                    {
                        txtBasicPr.Text = String.Format("{0:C2}", dbPrice);
                        txtBasicAG.Text = String.Format("{0:C2}", dbAG);
                    }
                    else if (strPackage == "Movie")
                    {
                        txtMoviePr.Text = String.Format("{0:C2}", dbPrice);
                        txtMovieAG.Text = String.Format("{0:C2}", dbAG);
                    }
                    else if (strPackage == "Arcade")
                    {
                        txtArcadePr.Text = String.Format("{0:C2}", dbPrice);
                        txtArcadeAG.Text = String.Format("{0:C2}", dbAG);
                    }
                    else if (strPackage == "Bowling")
                    {
                        txtBowlPr.Text = String.Format("{0:C2}", dbPrice);
                        txtBowlAG.Text = String.Format("{0:C2}", dbAG);
                    }
                    else if (strPackage == "Action")
                    {
                        txtActionPr.Text = String.Format("{0:C2}", dbPrice);
                        txtActionAG.Text = String.Format("{0:C2}", dbAG);
                    }
                    else if (strPackage == "Custom")
                    {
                        txtCustomPr.Text = String.Format("{0:C2}", dbPrice);
                        txtCustomAG.Text = String.Format("{0:C2}", dbAG);
                    }
                }
                reader.Close();

                sql = "SELECT * FROM EventHost";
                sqlstr.CommandText = sql;
                reader = sqlstr.ExecuteReader();
                while (reader.Read())
                {
                    cbHost.Items.Add(reader["FName"].ToString() + " " + reader["LName"].ToString());
                }
                reader.Close();
                sqlstr.Dispose();
                conn.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
        }
    }
}
