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
    public partial class BDPackages : Form
    {
        private OleDbConnection conn = new OleDbConnection();

        Package curPackage = new Package();

        public BDPackages()
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

        private void RbBasic_CheckedChanged(object sender, EventArgs e)
        {
            if(rbBasic.Checked == true)
            {
                lbBDPack.Items.Insert(0, "  TSGS Birthday T-Shirt for Guest of Honor");
                lbBDPack.Items.Insert(0, "  Drinks");
                lbBDPack.Items.Insert(0, "  2 One-Topping Pizzas");
                lbBDPack.Items.Insert(0, "  50 Point Arcade Play Card for Guest of Honor");
                lbBDPack.Items.Insert(0, "  Party Room for 1 Hour");
                lbBDPack.Items.Insert(0, "Basic Package");
                fillAmts(1);

            }
            else
            {
                lbBDPack.Items.RemoveAt(0);
                lbBDPack.Items.RemoveAt(0);
                lbBDPack.Items.RemoveAt(0);
                lbBDPack.Items.RemoveAt(0);
                lbBDPack.Items.RemoveAt(0);
                lbBDPack.Items.RemoveAt(0);
            }
        }

        private void RbMovie_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMovie.Checked == true)
            {
                lbBDPack.Items.Insert(0, "  TSGS Birthday T-Shirt for Guest of Honor");
                lbBDPack.Items.Insert(0, "  Snack Packs");
                lbBDPack.Items.Insert(0, "  50 Point Arcade Play Card for Guest of Honor");
                lbBDPack.Items.Insert(0, "  Matinee Movie Tickets");
                lbBDPack.Items.Insert(0, "  Party Room for 1 Hour");
                lbBDPack.Items.Insert(0, "Movie Package");
                fillAmts(2);
            }
            else
            {
                lbBDPack.Items.RemoveAt(0);
                lbBDPack.Items.RemoveAt(0);
                lbBDPack.Items.RemoveAt(0);
                lbBDPack.Items.RemoveAt(0);
                lbBDPack.Items.RemoveAt(0);
                lbBDPack.Items.RemoveAt(0);
            }
        }

        private void fillAmts(int iPkg)
        {
            conn.Open();

            string sql = "SELECT Packages.ID, Packages.Cost, (Items.PackCost*Items.NbrPack) AS Amt, AlctType.Tax " +
                         "FROM((Packages INNER JOIN PackageItems ON Packages.ID = PackageItems.PackageID) INNER JOIN Items ON PackageItems.ItemID = Items.ID) INNER JOIN AlctType ON Items.AlctTypeID = AlctType.ID " +
                         "WHERE Packages.ID = " + iPkg + ";";

            OleDbCommand sqlstr = new OleDbCommand();
            sqlstr.Connection = conn;
            sqlstr.CommandText = sql;
            OleDbDataReader reader = sqlstr.ExecuteReader();
            double dbSub = 0;
            double dbTax = 0;
            double dbSvc;
            double dbTtlPrice;
            double dbDepDue;
            double dbDepPaid;
            double dbTtlPaid;
            double dbTtlDue;

            while (reader.Read())
            {

                if(reader["Tax"].ToString() == "Y")
                    dbTax += (Convert.ToDouble(reader["Amt"].ToString())*.0825);

                dbSub = Convert.ToDouble(reader["Cost"].ToString());
            }

            reader.Close();
            sqlstr.Dispose();
            conn.Close();

            dbSvc = dbSub * .15;
            dbTtlPrice = dbSub + Math.Round(dbTax,2) + Math.Round(dbSvc,2);
            dbDepDue = dbTtlPrice / 2;

            if (txtDepPaid.TextLength > 0)
            {
                dbDepPaid = Convert.ToDouble(txtDepPaid.Text.Substring(1));
            }
            else
            {
                dbDepPaid = 0;
            }
            if(txtTtlPaid.TextLength > 0)
            {
                dbTtlPaid = Convert.ToDouble(txtTtlPaid.Text.Substring(1));
            }
            else
            {
                dbTtlPaid = 0;
            }

            dbTtlDue = dbTtlPrice - dbDepPaid - dbTtlPaid;

            txtSub.Text = String.Format("{0:C2}", dbSub);
            txtTax.Text = String.Format("{0:C2}", dbTax);
            txtSvcChg.Text = String.Format("{0:C2}", dbSvc);
            txtTtlPrice.Text = String.Format("{0:C2}", dbTtlPrice);
            txtDepDue.Text = String.Format("{0:C2}", dbDepDue);
            txtDepPaid.Text = String.Format("{0:C2}", dbDepPaid);
            txtTtlDue.Text = String.Format("{0:C2}", dbTtlDue);
            txtTtlPaid.Text = String.Format("{0:C2}", dbTtlPaid);
        }

        private void RbArcade_CheckedChanged(object sender, EventArgs e)
        {
            if (rbArcade.Checked == true)
            {
                lbBDPack.Items.Insert(0, "  TSGS Birthday T-Shirt for Guest of Honor");
                lbBDPack.Items.Insert(0, "  Drinks");
                lbBDPack.Items.Insert(0, "  2 Large One-Topping Pizzas");
                lbBDPack.Items.Insert(0, "  50 Point Arcade Play Card for Guest of Honor");
                lbBDPack.Items.Insert(0, "  50 Point Arcade Play Cards for Guests");
                lbBDPack.Items.Insert(0, "  Party Room for 1 Hour");
                lbBDPack.Items.Insert(0, "Arcade Package");
                fillAmts(3);
            }
            else
            {
                lbBDPack.Items.RemoveAt(0);
                lbBDPack.Items.RemoveAt(0);
                lbBDPack.Items.RemoveAt(0);
                lbBDPack.Items.RemoveAt(0);
                lbBDPack.Items.RemoveAt(0);
                lbBDPack.Items.RemoveAt(0);
                lbBDPack.Items.RemoveAt(0);
            }
        }

        private void RbBowling_CheckedChanged(object sender, EventArgs e)
        {
            if (rbArcade.Checked == true)
            {
                lbBDPack.Items.Insert(0, "  TSGS Birthday T-Shirt for Guest of Honor");
                lbBDPack.Items.Insert(0, "  Drinks");
                lbBDPack.Items.Insert(0, "  2 Large One-Topping Pizzas");
                lbBDPack.Items.Insert(0, "  50 Point Arcade Play Card for Guest of Honor");
                lbBDPack.Items.Insert(0, "  1 Hour of Bowling");
                lbBDPack.Items.Insert(0, "  Bowling Shoes");
                lbBDPack.Items.Insert(0, "  Party Room for 1 Hour");
                lbBDPack.Items.Insert(0, "Arcade Package");
                fillAmts(4);
            }
            else
            {
                lbBDPack.Items.RemoveAt(0);
                lbBDPack.Items.RemoveAt(0);
                lbBDPack.Items.RemoveAt(0);
                lbBDPack.Items.RemoveAt(0);
                lbBDPack.Items.RemoveAt(0);
                lbBDPack.Items.RemoveAt(0);
                lbBDPack.Items.RemoveAt(0);
                lbBDPack.Items.RemoveAt(0);
            }
        }

        private void RbAction_CheckedChanged(object sender, EventArgs e)
        {

            if (rbArcade.Checked == true)
            {
                lbBDPack.Items.Insert(0, "  TSGS Birthday T-Shirt for Guest of Honor");
                lbBDPack.Items.Insert(0, "  Drinks");
                lbBDPack.Items.Insert(0, "  2 Large One-Topping Pizzas");
                lbBDPack.Items.Insert(0, "  50 Point Arcade Play Card for Guest of Honor");
                lbBDPack.Items.Insert(0, "  Activity Play Cards with 2 Activities (Laser Tag, HoloGate, and/or Rope Course)");
                lbBDPack.Items.Insert(0, "  Party Room for 1 Hour");
                lbBDPack.Items.Insert(0, curPackage.Name + " Package");
                fillAmts(4);
            }
            else
            {
                lbBDPack.Items.RemoveAt(0);
                lbBDPack.Items.RemoveAt(0);
                lbBDPack.Items.RemoveAt(0);
                lbBDPack.Items.RemoveAt(0);
                lbBDPack.Items.RemoveAt(0);
                lbBDPack.Items.RemoveAt(0);
                lbBDPack.Items.RemoveAt(0);
            }
        }
    }
}
