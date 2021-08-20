using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvanDangol.Function
{
    public static class EvanString
    {
        public static string ToTitleCase(this string inputString)
        {
            inputString = inputString.Trim();
            inputString = inputString.ToLower();

            string[] inputStringAsArray = inputString.Split(' ');
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < inputStringAsArray.Length; i++)
            {
                if (inputStringAsArray[i].Length > 0)
                {
                    sb.AppendFormat("{0}{1} ",
                    inputStringAsArray[i].Substring(0, 1).ToUpper(),
                    inputStringAsArray[i].Substring(1));
                }
            }

            return sb.ToString(0, sb.Length - 1);
        }
    }
    public static class EvanString1
    {
        public static string ToTitleCase1(this string str)
        {
            string[] sarray = str.Split(' ');
            string[] modifiedsarray = new string[sarray.Length];
            int i = 0;
            foreach (var item in sarray)
            {
                if (item == "")
                    continue;
                modifiedsarray[i] = item.Length == 1 ? item.ToUpper() :
                    item.Substring(0, 1).ToUpper() + item.Substring(1, item.Length - 1);
                i++;
            }
            var mstring = "";
            foreach (var item in modifiedsarray)
            {
                mstring += item + " ";
            }
            return mstring;
        }

    }
}
