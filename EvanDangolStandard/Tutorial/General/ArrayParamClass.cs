using EvanDangol.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvanDangol.Tutorial.General
{
    class ArrayParam
    {
        public static string[] GetStringArray()
        {
            string[] theStrings = { "Hello", "from", "GetStringArray" };
            return theStrings;
        }
        public static void arrayparam(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
              Console.WriteLine("the value of index {0} is {1}", i, array[i]);
            }
	    }
      
    }
   
    public class ArrayParamClass
    {
        [runnable]
        public static void Run()
        {
            Console.WriteLine("GetStringArray()");
            string[] ss = ArrayParam.GetStringArray();

            foreach (string  s in ss)
            {
                Console.WriteLine(s);  
            }
            Console.WriteLine();
            Console.WriteLine("arrayparam(int[] array)");
            int[] i= {1,2,3,4,5,6,7,8,9};
            ArrayParam.arrayparam(i);
        }
    }



}
    

