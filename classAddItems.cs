namespace MBECSharp
{
    static class AdditionalItems
    {
        public static string[] Item;        //Short description
        public static string[] Descr;       //Long description
        public static int[] id;             //Item ID
        public static int[] AlctType;       //Allication ID
        public static double[] Cost;        //Cost of item
        public static string[] Taxable;     //If item is taxable
        public static double[] Tax;         //Amount of tax on item
        public static int[] Nbr;            //Number of items
        public static string[] Food;        //Food items
        public static int aiCnt;            //Number of additional items selected
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
