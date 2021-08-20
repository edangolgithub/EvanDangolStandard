using EvanDangol.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;


namespace EvanDangol.Function
{
    public enum EvanBaseNumber : byte { Binary = 2, Octal = 8, Hexadecimal = 16 };
  
    public static class EvanFunction
    {
        public static void Print(this object AnyObject)
        {
            Console.WriteLine(AnyObject);
        }
        //public static void RunWindowsForm(this Form form)
        //{
            
        //    Application.EnableVisualStyles();
           
        //    //Application.SetCompatibleTextRenderingDefault(true);            
        //    Application.Run(form);
        //}
        public static string GetBinaryValue(this string s)
        {
            StringBuilder sb = new StringBuilder();
            string ss = s.GetAsciiValue();
            string[] sa = ss.Trim().Split(' ');

            int[] temp = new int[sa.Length];

            for (int i = 0; i < sa.Length; i++)
            {
                temp[i] = Convert.ToInt32(sa[i]);
            }
            foreach (int intt in temp)
            {

                sb.Append(intt.ConvertToBase(EvanBaseNumber.Binary) + " ");
            }
            return sb.ToString();
        }
        public static int GetAsciiValue(this char c)
        {
            int i = (int)c;

            return i;
        }
        public static string GetAsciiValue(this string c)
        {
            StringBuilder sb = new StringBuilder();
            int[] ii = new int[c.Length];
            string[] ss = new string[c.Length];
            char[] ch = c.Trim().ToCharArray();
            for (int i = 0; i < ch.Length; i++)
            {
                ii[i] = (int)ch[i];
            }

            foreach (int intt in ii)
            {
                sb.Append(intt + " ");
            }
            string s = sb.ToString();
            return s;

        }
        public static string GetHexaDecimalValue(this string c)
        {
            StringBuilder sb = new StringBuilder();
            int[] ii = new int[c.Length];
            string[] ss = new string[c.Length];
            char[] ch = c.Trim().ToCharArray();
            for (int i = 0; i < ch.Length; i++)
            {
                ii[i] = (int)ch[i];
            }
            for (int i = 0; i < ch.Length; i++)
            {
                ss[i] = string.Format("{0:X} ", ii[i]);

            }
            foreach (string intt in ss)
            {
                sb.Append(intt + " ");
            }
            string s = sb.ToString();
            return s;

        }
        /// <summary>
        /// This Function can convert integer number to any of 3 base numbers
        /// </summary>
        /// <param name="DecimalNumber">The Number You Like Toconvert</param>
        /// <param name="baseToConvertTo">Base Like "Binary" or "Hexadecimal" etc</param>
        /// <returns>This Function Returns String Repesentation of BaseNumber</returns>
        public static string ConvertToBase(this int DecimalNumber, EvanBaseNumber baseToConvertTo)
        {
            int a = (byte)baseToConvertTo;
            return ConvertToBase(DecimalNumber, a);
        }
        /// <summary>
        /// This Function can convert integer number to any base number
        /// </summary>
        /// <param name="DecimalNumber">number to convert</param>
        /// <param name="BaseNumber">base number </param>
        /// <returns> string</returns>      
        public static string ConvertToBase(this int DecimalNumber, int BaseNumber)
        {

            int result = 0;
            int iteration = 0;
            if (BaseNumber != 16)
            {
                do
                {
                    int nextDigit = DecimalNumber % BaseNumber;
                    result += nextDigit * (int)Math.Pow(10, iteration);
                    iteration++;
                    DecimalNumber /= BaseNumber;
                }
                while (DecimalNumber != 0); return result.ToString();
            }
            else
            {
                string result1 = string.Format("{0:X}", DecimalNumber);
                return string.Format("0X{0}", result1);
            }
        }
        /// <summary>
        /// this function converts integer to any of 3 base number
        /// </summary>
        /// <param name="DecimalNumber">any integer number</param>
        /// <param name="EvanBaseNumber">
        /// string representation of base number binary or hexadecimal or octal
        /// also you can give "b","o","hex" or "h" or "bin",or "oct" but not "bi", "he",or "oc"
        /// </param>
        /// <returns>string</returns>
        public static string ConvertToBase(this int DecimalNumber, string EvanBaseNumber)
        {
            string result = null;

            if (EvanBaseNumber.StartsWith("hex") || EvanBaseNumber == "h")
            {
                EvanBaseNumber = "hexadecimal";
            }
            else if (
                EvanBaseNumber.StartsWith("oct") || EvanBaseNumber == "o")
            {
                EvanBaseNumber = "octal";
            }

            else if (
                EvanBaseNumber.StartsWith("bin") || EvanBaseNumber == "b")
            {
                EvanBaseNumber = "binary";
            }
            try
            {
                result = DecimalNumber.ConvertToBase((EvanBaseNumber)TypeDescriptor.GetConverter(typeof(EvanBaseNumber)).ConvertFrom(EvanBaseNumber));
            }
            catch (Exception)
            {
                throw new EvanException(" \"" + EvanBaseNumber + "\"  is not valid format");
            }
            return result;
        }

        public static void swap(ref object a, ref object b)
        {
            object temp = a;
            a = b;
            b = temp;

        }
        public static void swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;

        }
  
        public static string ToBinary(this int number)
        {

            string s = "";
            for (int t = 16384; t > 0; t = t / 2)
            {
                if ((t & number) != 0)
                {
                    s += "1";
                }
                else
                {
                    s += "0";
                }
            }
#pragma warning disable
            for (int i = 0; i < s.Length; i++)
            {
                if (s.StartsWith("1"))
                    return s;
                else
                {
                    return s.TrimStart('0');
                }
            }
#pragma warning restored
            return s;
        }
    }
}
