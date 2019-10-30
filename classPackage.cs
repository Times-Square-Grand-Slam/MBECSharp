using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBECSharp
{
    public class Package
    {
        public int ID;
        public string Name;
        public double Cost;
        public double AdditionalGuest;
        public int NbrItems;
    }

    public class PackageItems
    {
        public string LDescr
        {
            get;
            set;
        }
        public int NbrInc
        {
            get;
            set;
        }
        public double Cost
        {
            get;
            set;
        }
        public string Taxable
        {
            get;
            set;
        }
        public double Tax
        {
            return Cost * .0825;
        }
    }
}
