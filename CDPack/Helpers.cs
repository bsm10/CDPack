using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDPack
{
    class Helpers
    {
        public void Str()
        {
            string number = "100";
            int fromBase = 16;
            int toBase = 10;
            string result = Convert.ToString(Convert.ToInt32(number, fromBase), toBase);
            string s = "100".DecToBin();

        }
    }

    public static class StringExtension
    {
        public static string DecToBin(this string number)
        {
            //Convert.ToString(Convert.ToInt32(number, fromBase), toBase);
            return Convert.ToString(Convert.ToInt32(number, 10), 2);
        }

        public static string DecToHex(this string number)
        {
            return Convert.ToString(Convert.ToInt32(number, 10), 16);
        }

        public static string BinToHex(this string number)
        {
            return Convert.ToString(Convert.ToInt32(number, 2), 16);
        }

        public static string BinToDec(this string number)
        {
            return Convert.ToString(Convert.ToInt32(number, 2), 10);
        }

        public static string HexToDec(this string number)
        {
            return Convert.ToString(Convert.ToInt32(number, 16), 10);
        }

        public static string HexToBin(this string number)
        {
            return Convert.ToString(Convert.ToInt32(number, 16), 2);
        }

    }


}
