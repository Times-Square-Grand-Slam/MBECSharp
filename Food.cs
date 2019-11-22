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
    public partial class Food : Form
    {
        private OleDbConnection connFood = new OleDbConnection();

        public Food()
        {
            InitializeComponent();
            connFood.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
                                    @"Data Source=\\TSSERVER\serverfolders\IT\IT Staff\Phil Darden\MBECSharp\Events.accdb;" +
                                    @"Persist Security Info=False;";
        }

        private void Food_Load(object sender, EventArgs e)
        {
            //Get number of active items
            string sql = "SELECT * FROM PizzaTopping ORDER By ID";

            //Variable
            OleDbDataReader reader;

            //Open connection
            connFood.Open();

            //Create and exacute DbCommand object
            OleDbCommand cmdFood = new OleDbCommand();
            cmdFood.Connection = connFood;
            cmdFood.CommandText = sql;
            reader = cmdFood.ExecuteReader();

            //Loop through packages
            while (reader.Read())
            {
                clb1.Items.Add(reader["Topping"].ToString());
            }
        }

    }
}
