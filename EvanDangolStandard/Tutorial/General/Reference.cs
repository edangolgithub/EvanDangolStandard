using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace EvanDangol.Tutorial.General
{
   class Reference
    {
       public static void Add(ref int x,ref int y,out int ans )
        {
           ans = x + y;
        }
   }
  
    class ReturnTerneryResult
    {
       public  static int Ternery(ref int q, ref int r)
        {
        return((q > r) ? q : r);
        }
    }
  public  class ReferenceTester
    {
       public static void Entry()
        {
       int firstnumber, secondnumber;
        int  sum;               
            Console.WriteLine("the first integer:20 ");
            firstnumber = 20;
            Console.WriteLine("\nthe second integer:30 ");
            secondnumber = 30;
            Reference.Add(ref firstnumber,ref secondnumber,out sum);        
            Console.WriteLine(
                "public static void Add(ref int x,ref int y,out int ans )"+
        "{"+
           "ans = x + y;"+
       " }");
            Console.WriteLine(sum);
        }
    }

}