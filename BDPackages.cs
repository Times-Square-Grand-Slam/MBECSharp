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
using System.Diagnostics;


namespace MBECSharp
{
    public partial class BDPackages : Form
    {
        private OleDbConnection conn = new OleDbConnection();
        private int id;
        private bool rboChecked;
        private string nbrGuest;
        Package bdPack = new Package();

        public BDPackages()
        {
            InitializeComponent();
            conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
                                    @"Data Source=\\TSSERVER\serverfolders\IT\IT Staff\Phil Darden\MBECSharp\Events.accdb;" +
                                    @"Persist Security Info=False;";
        }

        private void BnFood_Click(object sender, EventArgs e)
        {
            new Food(id).Show();
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

        private void BDPackages_Load(object sender, EventArgs e)
        {
            //Get number of active items
            string sql = "SELECT Count(*) FROM Items WHERE Active = 'Y'";

            //Variable
            int iCnt = 0;
            OleDbDataReader reader;

            //Open connection
            conn.Open();

            //Create and exacute DbCommand object
            OleDbCommand sqlstr = new OleDbCommand();
            sqlstr.Connection = conn;
            sqlstr.CommandText = sql;
            iCnt = Convert.ToInt32(sqlstr.ExecuteScalar());

            //Allocate memory to additonal items class members
            AdditionalItems.Item = new string[iCnt];
            AdditionalItems.Descr = new string[iCnt];
            AdditionalItems.id = new int[iCnt];
            AdditionalItems.addItemID = new int[iCnt];
            AdditionalItems.AlctType = new int[iCnt];
            AdditionalItems.Cost = new double[iCnt];
            AdditionalItems.Taxable = new string[iCnt];
            AdditionalItems.Tax = new double[iCnt];
            AdditionalItems.Nbr = new int[iCnt];

            //Pull package information for dynamic option buttons
            sql = "SELECT Title, Cost, AddGuest FROM Packages";
            sqlstr.CommandText = sql;
            reader = sqlstr.ExecuteReader();

            //Reset counter
            iCnt = 0;

            //Loop through packages
            while (reader.Read())
            {
                //Increment counter
                iCnt++;

                //Increase the size of the box
                pnPack.Size = new Size(315, 70 + (28 * iCnt));

                //Add radio button
                RadioButton rdo = new RadioButton();
                rdo.Name = "rb" + iCnt;
                rdo.Text = reader["Title"].ToString();
                rdo.Location = new Point(11, 40 + (28 * iCnt));
                rdo.Size = new Size(79, 22);
                rdo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
                rdo.CheckedChanged += radioButton_CheckedChanged;

                //Add textbox for package price
                TextBox txt1 = new TextBox();
                txt1.Name = "txtPr" + iCnt;
                txt1.Text = String.Format("{0:C2}", Convert.ToDouble(reader["Cost"].ToString()));
                txt1.Location = new Point(96, 42 + (28 * iCnt));
                txt1.Size = new Size(100, 20);
                txt1.ReadOnly = true;
                txt1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;

                //Add textbox for additional guest price
                TextBox txt2 = new TextBox();
                txt2.Name = "txtAG" + iCnt;
                txt2.Text = String.Format("{0:C2}", Convert.ToDouble(reader["AddGuest"].ToString()));
                txt2.Location = new Point(202, 42 + (28 * iCnt));
                txt2.Size = new Size(100, 20);
                txt2.ReadOnly = true;
                txt2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;

                //Add controls to panel
                pnPack.Controls.Add(rdo);
                pnPack.Controls.Add(txt1);
                pnPack.Controls.Add(txt2);
            }
            reader.Close();

            //Add host/hostest names to dropdown
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

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton btn = sender as RadioButton;
            string strName = btn.Name;
            id = Convert.ToInt32(strName.Substring(strName.Length - 1));

            if (btn.Checked == true)
            {
                //Add package information to class
                addPackage(id);

                //Add package costs to textboxes
                fillAmts();

                //Add information to listbox
                addText();

                //Set boolean to true
                rboChecked = true;
            }
            else
            {
                //Remove package cost from textboxes
                removeAmts();

                //Remove package information from listbox
                removeText();

                //set boolean to false
                rboChecked = false;
            }
        }

        private void addText()
        {
            for (int i = 0; i <= bdPack.NbrItems - 1; i++)
            {
                if (Convert.ToInt32(txtGuests.Text) > 10 && bdPack.PackIAG[i] == "Y")
                {
                    lbBDPack.Items.Insert(0, "   " + Convert.ToInt32(txtGuests.Text) + "   " + bdPack.PackLdesc[i]);
                }
                else if (bdPack.PackNbrInc[i] < 10)
                {
                    lbBDPack.Items.Insert(0, "     " + bdPack.PackNbrInc[i] + "  " + bdPack.PackLdesc[i]);
                }
                else
                {
                    lbBDPack.Items.Insert(0, "   " + bdPack.PackNbrInc[i] + "   " + bdPack.PackLdesc[i]);
                }
            }

            lbBDPack.Items.Insert(0, bdPack.Name + " Package");
        }

        private void removeText()
        {
            for (int i = 0; i <= bdPack.NbrItems; i++)
            {
                lbBDPack.Items.RemoveAt(0);
            }
        }

        private void fillAmts()
        {
            int cntGuest;
            int addGuest;
            double dbSub;
            double dbTax = 0;
            double dbSvc;
            double dbTtlPrice;
            double dbDepDue;
            double dbDepPaid;
            double dbTtlPaid;
            double dbTtlDue;
            double dbPerGuest;

            //Gets number of guests if available or sets it to 10 if nothing is entered.
            if (txtGuests.TextLength > 0)
            {
                cntGuest = Convert.ToInt32(txtGuests.Text);
            }
            else
            {
                txtGuests.Text = "10";
                cntGuest = 10;
            }

            addGuest = cntGuest - 10;

            if (addGuest < 0)
            {
                addGuest = 0;
            }

            //Set subtotal
            if (txtSub.TextLength > 0)
            {
                dbSub = Math.Round(Convert.ToDouble(txtSub.Text) + bdPack.Cost + (bdPack.AdditionalGuest * addGuest), 2);
            }
            else
            {
                dbSub = Math.Round(bdPack.Cost + (bdPack.AdditionalGuest * addGuest), 2);
            }

            //Set Tax
            for (int i = 0; i <= bdPack.NbrItems - 1; i++)
            {
                if (bdPack.PackIAG[i] == "Y")
                {
                    dbTax += bdPack.PackTax[i] * addGuest;
                }
                dbTax += bdPack.PackTax[i] * bdPack.PackNbrInc[i];
            }
            if (txtTax.TextLength > 0)
            {
                dbTax = Convert.ToDouble(txtTax.Text) + dbTax;
            }

            dbTax = Math.Round(dbTax, 2);

            //Set service charge
            dbSvc = Math.Round(dbSub * .15, 2);
            if (txtSvcChg.TextLength > 0)
            {
                dbSvc += Math.Round(Convert.ToDouble(txtSvcChg.Text), 2);
            }

            //Set cost of the package
            dbTtlPrice = Math.Round(dbSub, 2) + Math.Round(dbTax, 2) + Math.Round(dbSvc, 2);

            //Set deposit due
            dbDepDue = Math.Round(dbTtlPrice / 2, 2);

            //Get amount of deposit that was paid
            if (txtDepPaid.TextLength > 0)
            {
                dbDepPaid = Math.Round(Convert.ToDouble(txtDepPaid.Text), 2);
            }
            else
            {
                dbDepPaid = 0;
            }

            //Get amount paid
            if (txtTtlPaid.TextLength > 0)
            {
                dbTtlPaid = Math.Round(Convert.ToDouble(txtTtlPaid.Text), 2);
            }
            else
            {
                dbTtlPaid = 0;
            }

            //Set total still due
            dbTtlDue = dbTtlPrice - dbDepPaid - dbTtlPaid;

            //Set amount per guest
            dbPerGuest = Math.Round(dbTtlPrice / cntGuest, 2);

            //Update class
            bdPack.SubTotal = dbSub;
            bdPack.Tax = dbTax;
            bdPack.GuestCnt = cntGuest;

            //Update textboxes
            txtSub.Text = String.Format("{0:N2}", dbSub);
            txtTax.Text = String.Format("{0:N2}", dbTax);
            txtSvcChg.Text = String.Format("{0:N2}", dbSvc);
            txtTtlPrice.Text = String.Format("{0:N2}", dbTtlPrice);
            txtDepDue.Text = String.Format("{0:N2}", dbDepDue);
            txtDepPaid.Text = String.Format("{0:N2}", dbDepPaid);
            txtTtlDue.Text = String.Format("{0:N2}", dbTtlDue);
            txtTtlPaid.Text = String.Format("{0:N2}", dbTtlPaid);
            txtPerGuest.Text = String.Format("{0:N2}", dbPerGuest);
        }

        private void removeAmts()
        {
            int cntGuest = bdPack.GuestCnt;
            double dbSub = bdPack.SubTotal;
            double dbTax = bdPack.Tax;
            double dbSvc;
            double dbTtlPrice;
            double dbDepDue;
            double dbDepPaid;
            double dbTtlPaid;
            double dbTtlDue;
            double dbPerGuest;

            //Update subtotal textbox
            if (txtSub.TextLength > 0)
            {
                txtSub.Text = Math.Round(Convert.ToDouble(txtSub.Text) - dbSub, 2).ToString();
            }
            if (Convert.ToDouble(txtSub.Text) < 0)
            {
                txtSub.Text = "0";
            }

            //Update tax textbox
            if (txtTax.TextLength > 0)
            {
                txtTax.Text = Math.Round(Convert.ToDouble(txtTax.Text) - dbTax, 2).ToString();
            }
            if (Convert.ToDouble(txtTax.Text) < 0)
            {
                txtTax.Text = "0";
            }

            //Set service charge
            dbSvc = Math.Round(Convert.ToDouble(txtSub.Text) * .15, 2);

            //Set cost of the package
            dbTtlPrice = Math.Round(Convert.ToDouble(txtSub.Text), 2) + Math.Round(Convert.ToDouble(txtTax.Text), 2) + Math.Round(dbSvc, 2);

            //Set deposit due and amount per guest
            if (dbTtlPrice > 0)
            {
                dbDepDue = Math.Round(dbTtlPrice / 2, 2);
                dbPerGuest = Math.Round(dbTtlPrice / Convert.ToInt32(txtGuests.Text), 2);
            }
            else
            {
                dbDepDue = 0;
                dbPerGuest = 0;
            }

            //Get amount of deposit that was paid
            if (txtDepPaid.TextLength > 0)
            {
                dbDepPaid = Convert.ToDouble(txtDepPaid.Text);
            }
            else
            {
                dbDepPaid = 0;
            }

            //Get amount paid
            if (txtTtlPaid.TextLength > 0)
            {
                dbTtlPaid = Convert.ToDouble(txtTtlPaid.Text.Substring(1));
            }
            else
            {
                dbTtlPaid = 0;
            }

            //Set total still due
            dbTtlDue = dbTtlPrice - dbDepPaid - dbTtlPaid;

            //Update textboxes
            txtSvcChg.Text = String.Format("{0:N2}", dbSvc);
            txtTtlPrice.Text = String.Format("{0:N2}", dbTtlPrice);
            txtDepDue.Text = String.Format("{0:N2}", dbDepDue);
            txtDepPaid.Text = String.Format("{0:N2}", dbDepPaid);
            txtTtlDue.Text = String.Format("{0:N2}", dbTtlDue);
            txtTtlPaid.Text = String.Format("{0:N2}", dbTtlPaid);
            txtPerGuest.Text = String.Format("{0:N2}", dbPerGuest);
        }

        private void TxtGuests_Leave(object sender, EventArgs e)
        {
            if (rboChecked && txtGuests.Text != nbrGuest)
            {
                removeAmts();
                removeText();
                fillAmts();
                addText();
            }
        }

        private void TxtGuests_Enter(object sender, EventArgs e)
        {
            nbrGuest = txtGuests.Text;
        }

        private void addPackage(int i)
        {
            //Allocate memory to class arrays
            bdPack.arrayUpdate(i);

            //Create SQL statement for package
            string sql = "SELECT * FROM Packages WHERE ID = " + i + ";";

            //Create sqlstr and reader
            conn.Open();
            OleDbCommand sqlstr = new OleDbCommand();
            sqlstr.Connection = conn;
            sqlstr.CommandText = sql;
            OleDbDataReader reader = sqlstr.ExecuteReader();
            while(reader.Read())
            {
                //Populate package class
                bdPack.Name = reader["Title"].ToString();
                bdPack.Cost = Convert.ToDouble(reader["Cost"].ToString());
                bdPack.AdditionalGuest = Convert.ToDouble(reader["AddGuest"].ToString());
            }

            //Close reader for later use
            reader.Close();

            //Repopulate SQL statement
            sql = "SELECT Items.InvDesc, Items.PackCost, Items.NbrPack, Items.IncAddGuest, AlctType.Tax " +
                  "FROM (PackageItems INNER JOIN Items ON PackageItems.ItemID = Items.ID) INNER JOIN AlctType ON Items.AlctTypeID = AlctType.ID " +
                  "WHERE PackageItems.PackageID = " + i +" " +
                  "ORDER By Items.SortOrder DESC;";

            //Update sqlstr and reader
            sqlstr.CommandText = sql;
            reader = sqlstr.ExecuteReader();

            //Reset item counter
            int iCnt = 0;

            //Populate items in class
            while (reader.Read())
            {
                if (iCnt < bdPack.NbrItems)
                {
                    //Populate package items
                    bdPack.PackLdesc[iCnt] = reader["InvDesc"].ToString();
                    bdPack.PackCost[iCnt] = Convert.ToDouble(reader["PackCost"].ToString());
                    bdPack.PackNbrInc[iCnt] = Convert.ToInt32(reader["NbrPack"].ToString());
                    bdPack.PackTaxable[iCnt] = reader["Tax"].ToString();
                    bdPack.PackIAG[iCnt] = reader["IncAddGuest"].ToString();

                    //Determine if tax should be calculated
                    if (bdPack.PackTaxable[iCnt] == "Y")
                    {
                        //Calculate tax if needed
                        bdPack.PackTax[iCnt] = bdPack.PackCost[iCnt] * .0825;
                    }
                    else
                    {
                        //Assign 0 to tax if not needed
                        bdPack.PackTax[iCnt] = 0;
                    }

                }
                //increase item counter
                iCnt++;
            }

            //Close reader
            reader.Close();
            sqlstr.Dispose();
            conn.Close();
        }
    }
}
