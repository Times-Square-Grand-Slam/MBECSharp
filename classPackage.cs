using System;
using System.Data.OleDb;

namespace MBECSharp
{
    class Package
    {
        //Create class members
        public string Name;             //Package Name
        public double Cost;             //Total cost of package
        public double AdditionalGuest;  //Cost for each additional guest over 10
        public int NbrItems;            //Number of items included with the package
        public string[] PackLdesc;      //Description of each item
        public string[] PackTaxable;    //Flag if the item is taxable
        public int[] PackNbrInc;        //Number of this item that is included with the package
        public double[] PackCost;       //Total cost of the item
        public double[] PackTax;        //Amount of tax for this item
        public string[] PackIAG;        //Flag to include additional guests
        public string[] PackAC;         //Flag to indicate if item's cost is the remaining subtotal after other item's cost
        public double SubTotal;         //Cost of the package without taxes
        public double Tax;              //Total amount of taxes for the package
        public double Svc;              //Service/Gratuity charge for the package
        public double Dis;              //Amount of discount
        public double Ttl;              //Total cost of package
        public int MinGuest;            //Minimum number of guests
        public int GuestCnt;            //Total number of guests

        public void arrayUpdate(int ID)
        {
            //Connection variable
            OleDbConnection packConn = new OleDbConnection();

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
            PackAC = new string[NbrItems];

            //Close objects
            comsql.Dispose();
            packConn.Close();
        }
    }
}