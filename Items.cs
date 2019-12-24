using System;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;

namespace MBECSharp
{
    public partial class Items : Form
    {
        private OleDbConnection connItems = new OleDbConnection();
        private string strName;
        public static Color hdrColor = new Color();
        public static Color hdrFont = new Color();

        public Items(string iname)
        {
            strName = iname;
            InitializeComponent();
            connItems.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
                                    @"Data Source=\\10.0.20.15\serverfolders\IT\IT Staff\Phil Darden\MBECSharp\Events.accdb;" +
                                    @"Persist Security Info=False;";



        }

        private void Items_Load(object sender, EventArgs e)
        {
            //Populate label text


            //Variable
            OleDbDataReader reader;
            int iCnt = 0;

            //Get number of active items
            string sql = "SELECT Items.ID, Items.Item, Items.AlctTypeID, Items.AddCost, Items.InvDesc, AlctType.Tax " +
                         "FROM(Items INNER JOIN ItemsCat ON Items.AddItem = ItemsCat.ID) INNER JOIN AlctType ON Items.AlctTypeID = AlctType.ID " +
                         "WHERE (ItemsCat.Catagory = '" + strName + "') AND (Items.Active = 'Y')" +
                         "ORDER BY SORTORDER";

            //Open connection
            connItems.Open();

            //Create and exacute DbCommand object
            OleDbCommand cmdItems = new OleDbCommand();
            cmdItems.Connection = connItems;
            cmdItems.CommandText = sql;
            reader = cmdItems.ExecuteReader();

            //Loop through packages
            while (reader.Read())
            {
                //Increment counter
                iCnt++;

                //Increase the size of the form
                this.Size = new Size(250, 85 + (55 * iCnt));

                //Create button
                Button btn = new Button();
                btn.Name = "bn" + iCnt;
                btn.Text = reader["Item"].ToString();
                btn.Font = new Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                btn.Location = new Point(0, 45 + (55 * (iCnt - 1)));
                btn.Size = new Size(250, 50);
                btn.TabIndex = iCnt;
                btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(colorPicker.CP[iCnt - 1, 0])))), ((int)(((byte)(colorPicker.CP[iCnt - 1, 1])))), ((int)(((byte)(colorPicker.CP[iCnt - 1, 2])))));

                //Add button to form
                this.Controls.Add(btn);
            }

            //Close reader, cmdItems, and connItems
            reader.Close();

            //Increase the size of the form
            this.Size = new Size(250, 85 + (55 * (iCnt) + 10));

            //Create button
            Button btn2 = new Button();
            btn2.Name = "bnExit";
            btn2.Text = "Exit";
            btn2.Font = new Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btn2.Location = new Point(0, 45 + (55 * iCnt));
            btn2.Size = new Size(250, 50);
            btn2.TabIndex = iCnt + 1;
            btn2.Click += Button_Exit;

            //Add button to form
            this.Controls.Add(btn2);

        }

        private void Button_Exit(object sender, EventArgs e)
        {
            Close();
        }

    }
}
