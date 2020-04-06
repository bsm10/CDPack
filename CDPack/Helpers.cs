using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDPack
{
    class Helpers
    {
        public static string PackKSeg(string filePath)
        {
            string[] strings = File.ReadAllLines(filePath);
            List<string[]> list = new List<string[]>();
            string result = string.Empty;
            foreach (string line in strings)
            {
                string[] point = new string[2];
                point = line.Split(' ');
                if (point[0] != "0")
                    result += point[0].ToKsegX() + point[1].ToKsegY();
                else
                    result += point[1].ToKsegY();
            }
            return result;
        }

        public static string UnPackKSeg(string packagedString)
        {
            return packagedString.HexToBin();
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
            return Convert.ToString(Convert.ToInt64(number, 10), 2);
        }
        public static string DecToHex(this string number)
        {
            return Convert.ToString(Convert.ToInt64(number, 10), 16);
        }
        //public static string BinToHex(this string number)
        //{

        //    //return string.Format("{0:X2}", Convert.To(number, 2), 16);
        //    return string.Format("{0:X2}", Convert.ToInt64(number, 2), 16);
        //}
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
            //return Convert.ToString(Convert.ToInt64(number, 16), 2);
            return string.Join("", Enumerable.Range(0, number.Length / 2).Select(i =>
                Convert.ToString(Convert.ToInt64(number.Substring(i * 2, 2), 16), 2).PadLeft(8, '0')));
        }

        //00000010 00000001 00010100 00111101 10111100 00000001 11100001 00010100 00100110 00110100
        //02 01 14 3D BC 01 E1 14 26 34

        //00000001 00001000 00011011 10111001 00000010 00000001 00010100 00111101 10111100
        //01 08 1B B9 02 01 14 3D BC
        public static string BinToHex(this string binary)
        {
            int strlen = binary.Length;
            int lastBit = strlen % 8;
            string str = string.Empty;
            if (lastBit != 0)
                str = binary.PadLeft(strlen + 8 - lastBit, '0');
            else
                str = binary;
            return string.Join("", Enumerable.Range(0, str.Length / 8).Select(i =>
                Convert.ToByte(str.Substring(i * 8, 8), 2).ToString("X2")));
        }

    }
}
