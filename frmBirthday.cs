using System;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;


namespace MBECSharp
{
    public partial class frmBirthday : Form
    {
        private OleDbConnection conn = new OleDbConnection();
        private int id;
        private bool rboChecked;
        private string nbrGuest;
        Package bdPack = new Package();

        public frmBirthday()
        {
            InitializeComponent();
            conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
                                    @"Data Source=\\10.0.20.15\serverfolders\IT\IT Staff\Phil Darden\MBECSharp\Events.accdb;" +
                                    @"Persist Security Info=False;";
        }

        private void BDPackages_Load(object sender, EventArgs e)
        {
            //Allocate memory to additonal items class members
            itemsArray();

            //Variable
            int iCnt = 0;
            OleDbDataReader reader;
            OleDbCommand sqlstr = new OleDbCommand();

            //Open connection
            conn.Open();

            //Pull package information for dynamic option buttons
            string sql = "SELECT Title, Cost, AddGuest FROM Packages";
            sqlstr.Connection = conn;
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
                rdo.TabIndex = 20 + iCnt;
                rdo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(colorPicker.CP[iCnt - 1, 0])))), ((int)(((byte)(colorPicker.CP[iCnt - 1, 1])))), ((int)(((byte)(colorPicker.CP[iCnt - 1, 2])))));
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

            //Add host names to dropdown
            sql = "SELECT * FROM EventHost";
            sqlstr.CommandText = sql;
            reader = sqlstr.ExecuteReader();
            while (reader.Read())
            {
                cbHost.Items.Add(reader["FName"].ToString() + " " + reader["LName"].ToString());
            }
            reader.Close();

            //Add contacts
            sql = "SELECT * FROM ContactInfo";
            sqlstr.CommandText = sql;
            reader = sqlstr.ExecuteReader();
            while (reader.Read())
            {
                if (reader["Organization"].ToString() == null)
                {
                    cbContactName.Items.Add(reader["CName"].ToString());
                }
                else
                {
                    cbContactName.Items.Add(reader["CName"].ToString() + " - " + reader["Organization"].ToString());
                }
            }
            reader.Close();
            sqlstr.Dispose();
            conn.Close();

            //Populate tab control
            updateTabs();

            //Set focus to contacts
            cbContactName.Focus();
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton btn = sender as RadioButton;
            string strName = btn.Name;
            id = Convert.ToInt32(strName.Substring(strName.Length - 1));

            if (btn.Checked == true)
            {
                //Add package information to class
                addPackage();

                //Add package costs to textboxes
                fillAmts();

                //Add information to listbox
                addText();

                //Set boolean to true
                rboChecked = true;
            }
            else
            {
                //Remove package information from listbox
                removeText();

                //set boolean to false
                rboChecked = false;
            }
        }

        private void addPackage()
        {
            //Allocate memory to class arrays
            bdPack.arrayUpdate(id);

            //Determine guest count
            gCnt();

            //Create SQL statement for package
            string sql = "SELECT * FROM Packages WHERE ID = " + id + ";";

            //Create OleDbCommand and reader
            conn.Open();
            OleDbCommand sqlstr = new OleDbCommand();
            sqlstr.Connection = conn;
            sqlstr.CommandText = sql;
            OleDbDataReader reader = sqlstr.ExecuteReader();

            //Populate class object
            while (reader.Read())
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
                  "WHERE PackageItems.PackageID = " + id + " " +
                  "ORDER By Items.SortOrder;";

            //Update sqlstr and reader
            sqlstr.CommandText = sql;
            reader = sqlstr.ExecuteReader();

            //Set item counter
            int iCnt = 0;

            //Populate items in class
            while (reader.Read())
            {
                if (iCnt < bdPack.NbrItems)
                {
                    //Populate package items
                    bdPack.PackLdesc[iCnt] = reader["InvDesc"].ToString();
                    bdPack.PackTaxable[iCnt] = reader["Tax"].ToString();
                    bdPack.PackIAG[iCnt] = reader["IncAddGuest"].ToString();

                    //Calculate number of items included and total cost
                    if (bdPack.PackIAG[iCnt] == "Y")
                    {
                        bdPack.PackNbrInc[iCnt] = bdPack.GuestCnt;
                    }
                    else
                    {
                        bdPack.PackNbrInc[iCnt] = Convert.ToInt32(reader["NbrPack"].ToString());
                    }

                    //Calculate total cost of item
                    bdPack.PackCost[iCnt] = Convert.ToDouble(reader["PackCost"].ToString());

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

        private void fillAmts()
        {
            int addGuest;

            //Update guest count
            gCnt();

            //Determine number of additional guest
            addGuest = bdPack.GuestCnt - 10;

            if (addGuest < 0)
            {
                addGuest = 0;
            }

            //Set subtotal
            bdPack.SubTotal = Math.Round(bdPack.Cost + (bdPack.AdditionalGuest * addGuest), 2);

            //Update items count and set tax
            for (int i = 0; i <= bdPack.NbrItems - 1; i++)
            {
                if (bdPack.PackIAG[i] == "Y")
                {
                    bdPack.PackNbrInc[i] = bdPack.GuestCnt;
                }
                bdPack.Tax += Math.Round(bdPack.PackTax[i] * bdPack.PackNbrInc[i], 2);
            }

            //Set service charge
            bdPack.Svc = Math.Round(bdPack.SubTotal * .15, 2);

            //Set total cost of the package
            bdPack.Ttl = Math.Round(bdPack.SubTotal, 2) + Math.Round(bdPack.Tax, 2) + Math.Round(bdPack.Svc, 2);
        }

        private void addText()
        {
            //Item cost variables
            double iCost = 0;   //Total cost of item
            double iTtl = 0;    //Total cost of all items
            int iCnt = 0;       //Item location counter

            //Add package information to listbox
            for (int i = 0; i <= bdPack.NbrItems - 1; i++)
            {
                
                //Create new list view item
                ListViewItem item1 = new ListViewItem();

                //Add row of data to list view item
                if (bdPack.PackCost[i] == 99999)
                {
                    iCnt = i;
                }
                else
                {
                    //Calculate item cost and total cost
                    iCost = bdPack.PackCost[i] * bdPack.PackNbrInc[i];
                    iTtl += iCost;

                    //Add row of data to list view item
                    item1.Text = "";
                    item1.SubItems.Add(String.Format("{0:N0}", bdPack.PackNbrInc[i]));
                    item1.SubItems.Add("");
                    item1.SubItems.Add(bdPack.PackLdesc[i]);
                    item1.SubItems.Add(String.Format("{0:N2}", iCost));

                    //Add list view item to list view
                    lvDetails.Items.AddRange(new ListViewItem[] { item1 });
                }
            }
            
            //Create new list view item
            ListViewItem item2 = new ListViewItem();

            //Calculate item cost and total cost
            iCost = bdPack.SubTotal - iTtl;

            //Add row of data to list view item
            item2.Text = "";
            item2.SubItems.Add(String.Format("{0:N0}", bdPack.PackNbrInc[iCnt]));
            item2.SubItems.Add("");
            item2.SubItems.Add(bdPack.PackLdesc[iCnt]);
            item2.SubItems.Add(String.Format("{0:N2}", iCost));

            //Add list view item to list view
            lvDetails.Items.AddRange(new ListViewItem[] { item2 });
        }

        private void removeText()
        {
            for (int i = 0; i <= bdPack.NbrItems + 1; i++)
            {
                lvDetails.Items.Clear();
            }
        }

        private void TxtGuests_Leave(object sender, EventArgs e)
        {
            //Determine number of guests and add to package class
            gCnt();

            //Determine if package items need to be recalculated
            if (rboChecked && txtGuests.Text != nbrGuest)
            {
                removeText();
                fillAmts();
                addText();
            }
        }

        private void TxtGuests_Enter(object sender, EventArgs e)
        {
            nbrGuest = txtGuests.Text;
        }

        private void gCnt()
        {
            if(txtGuests.TextLength == 0)
            {
                txtGuests.Text = "10";
            }
            if (Convert.ToInt32(txtGuests.Text) < 10)
            {
                txtGuests.Text = "10";
            }
            bdPack.GuestCnt = Convert.ToInt32(txtGuests.Text);
        }

        private void itemsArray()
        {
            //Get number of active items
            string sql = "SELECT Count(*) FROM Items WHERE Active = 'Y'";

            //Variable
            int iCnt;

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
            AdditionalItems.AlctType = new int[iCnt];
            AdditionalItems.Cost = new double[iCnt];
            AdditionalItems.Taxable = new string[iCnt];
            AdditionalItems.Tax = new double[iCnt];
            AdditionalItems.Nbr = new int[iCnt];

            //Dispose objects
            sqlstr.Dispose();
            conn.Close();
        }

        private void updateTabs()
        {
            //Create SQL statement for package
            string sql = "SELECT * FROM ItemsCat ORDER BY ID;";

            //Create OleDbCommand and reader
            conn.Open();
            OleDbCommand sqlstr = new OleDbCommand();
            sqlstr.Connection = conn;
            sqlstr.CommandText = sql;
            OleDbDataReader reader = sqlstr.ExecuteReader();

            //Populate class object
            while (reader.Read())
            {
                //Add tabs for each category except food
                if(reader["Catagory"].ToString() != "Food")
                {
                    TabPage myTabPage = new TabPage(reader["Catagory"].ToString());
                    tcAddItem.TabPages.Add(myTabPage);

                    myTabPage.Font = new Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    myTabPage.Location = new Point(4, 22);
                    myTabPage.Name = "tp" + reader["Catagory"].ToString();
                    myTabPage.Padding = new Padding(3);
                    myTabPage.Size = new Size(586, 544);
                    myTabPage.UseVisualStyleBackColor = true;
                }
            }

            //Clear reader
            reader.Close();

            
        }

        private void lvDetails_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = lvDetails.Columns[e.ColumnIndex].Width;
        }
    }
}
