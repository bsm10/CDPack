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
        public static string ToKsegY(this string number)
        {
            //Если число отрицательное, отбрасываем знак и конвертируем положительное число, а знак отдельным битом
            //25 бит с учётом первого бита на знак ("0"="+";"1"="-").
            //0000 1 10000001101110111001	-531385	
            //1 бит-знак, 24 бит-значение Y.
            int num = Convert.ToInt32(number, 10);
            string bin_value = Convert.ToString(Math.Abs(num), 2);
            if (num < 0)
            {
                return $"1{bin_value.PadLeft(24,'0')}";
            }
            else
                return $"0{bin_value.PadLeft(24, '0')}";
        }
        public static string ToKsegX(this string number)
        {
            //Если число отрицательное, отбрасываем знак и конвертируем положительное число, а знак отдельным битом
            //000000 100000000	256	 
            //Х последней точки файла 15 бит = 6 бит (доп-я инф.) + 9 бит (значение X).
            int num = Convert.ToInt32(number, 10);
            return $"{Convert.ToString(num, 2).PadLeft(15, '0')}";
        }
        public static string DecToBin(this string number)
        {
            //Convert.ToString(Convert.ToInt32(number, fromBase), toBase);
            return Convert.ToString(Convert.ToInt32(number, 10), 2);
        }
        public static string DecToHex(this string number)
        {
            return Convert.ToString(Convert.ToInt64(number, 10), 16);
        }
        public static string BinToHex(this string number)
        {
            return string.Format("{0:X2}", Convert.ToInt64(number, 2), 16);
        }
        public static string BinToDec(this string number)
        {
            return Convert.ToString(Convert.ToInt64(number, 2), 10);
        }
        public static string HexToDec(this string number)
        {
            return Convert.ToString(Convert.ToInt64(number, 16), 10);
        }
        public static string HexToBin(this string number)
        {
            return Convert.ToString(Convert.ToInt64(number, 16), 2);
        }
    }
}
