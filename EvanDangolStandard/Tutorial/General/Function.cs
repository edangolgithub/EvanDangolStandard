using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvanDangol.Tutorial.General
{
    static class function1
    {
      public static  void ints(params int[] intval)
        {
            if (intval != null || intval.Length != 0)
            {
                for (int i = 0; i < intval.Length; i++)
                {

                   Console.WriteLine(" indexes are {0}", intval[i] = i + 1);
                 }

            }
            Console.WriteLine("\n");
        }
       public static void function()
        {
            int[] intsf = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            
          function1.ints(intsf);
        }
       public static void function2()
       {
           int first = 1;
           int second = 3;
           int third = 5;
           function1.ints(first, second, third);
       }
    }
       public class FunctionTester
       {
           public static void Entry()
           {
               function1.function();
               function1.function2();
           }
       }
   
}
