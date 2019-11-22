using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBECSharp
{
    static class AdditionalItems
    {
        public static string[] Item;
        public static string[] Descr;
        public static int[] id;
        public static int[] addItemID;
        public static int[] AlctType;
        public static double[] Cost;
        public static string[] Taxable;
        public static double[] Tax;
        public static int[] Nbr;
    }

    static class colorPicker
    {
        public static int[,] CP = new int[12, 3]
        {
            {
                192, 192, 255
            },
            {
                192, 255, 192
            },
            {
                192, 255, 255
            },
            {
                255, 192, 192
            },
            {
                255, 192, 255
            },
            {
                255, 255, 192
            },
            {
                128, 128, 255
            },
            {
                128, 255, 128
            },
            {
                128, 255, 255
            },
            {
                255, 128, 128
            },
            {
                255, 128, 255
            },
            {
                255, 255, 128
            }
        };
    }
}
