using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            //Распаковка справа на лево  X(15)Y(25)X(15)Y(25)
            List<string> lst = new List<string>();
            string bin = packagedString.HexToBin();
            string res = string.Empty;
            int len = bin.Length;

            //var results = bin.Select((c, i) => new { c, i })
            //.GroupBy(x => x.i / 40)
            //.Select(g => string.Join("", g.Select(y => y.c)))
            //.ToList();
            string XY = string.Empty;
            string Yi = string.Empty;
            string Xi = string.Empty;
            for (int i = 1; i < bin.Length; i++)
            {
                if(i * 40 <= len)
                {
                    XY = bin.Substring(len - i * 40, 40);
                    Yi = Sign(XY.Substring(15, 1)) + XY.Substring(16, 24).BinToDec();
                    Xi = XY.Substring(0, 15).BinToDec();
                    res = $"{Xi} {Yi}\r\n{res}";
                }
                else // добавить первый Y без X
                {
                    //0000000 1000010000001101110111001 000000100000000 1000101000011110110111100
                    XY = bin.Substring(i * 40 - len - 1, 25);
                    Yi = Sign(XY.Substring(0, 1)) + XY.Substring(1, 24).BinToDec();
                    res = $"0 {Yi}\r\n{res}";
                }

                if(i * 40 >= len) break;
            }
            return res;
        }

        private static string Sign (string bit)
        {
            if (bit == "0")
                return "";
            else
                return "-";
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
        //Перевод в байты по 8 бит слева на право!
        public static string BinToHex(this string binary)
        {
            try
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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return string.Empty;
        }
    }
}
