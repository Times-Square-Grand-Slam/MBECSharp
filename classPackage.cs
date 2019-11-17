using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace MBECSharp
{
    class Package
    {
        //Create class members
        public string Name;
        public double Cost;
        public double AdditionalGuest;
        public int NbrItems;
        public string[] PackLdesc;
        public string[] PackTaxable;
        public int[] PackNbrInc;
        public double[] PackCost;
        public double[] PackTax;
        public string[] PackIAG;
        public double SubTotal;
        public double Tax;
        public int GuestCnt;

        private OleDbConnection packConn = new OleDbConnection();

        public void arrayUpdate(int ID)
        {
            //Create connection to database
            packConn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
                                    @"Data Source=\\TSSERVER\serverfolders\IT\IT Staff\Phil Darden\MBECSharp\Events.accdb;" +
                                    @"Persist Security Info=False;";

            //Create SQL statement
            string sqlPack = "SELECT Count(*) FROM PackageItems Where PackageID = " + ID;

            //Open connection
            packConn.Open();

            //Create DbCommand to populate number of items
            OleDbCommand comsql = new OleDbCommand();
            comsql.Connection = packConn;
            comsql.CommandText = sqlPack;
            NbrItems = Convert.ToInt32(comsql.ExecuteScalar());
            
            //Allocate memory to the arrays
            PackLdesc = new string[NbrItems];
            PackTaxable = new string[NbrItems];
            PackNbrInc = new int[NbrItems];
            PackCost = new double[NbrItems];
            PackTax = new double[NbrItems];
            PackIAG = new string[NbrItems];

            //Close objects
            comsql.Dispose();
            packConn.Close();
        }
    }
}