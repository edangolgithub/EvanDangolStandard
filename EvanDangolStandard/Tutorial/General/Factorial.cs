using EvanDangol.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvanDangol.Tutorial.General
{
    // A simple example of recursion.
    class Factorial
    {
        // This is a recursive method.
    public  int FactR(int n)
        {
            int result;
            if (n == 1) return 1;
            result = FactR(n - 1) * n;
            return result;
        }
        // This is an iterative equivalent.
     public  int FactI(int n)
        {
            int t, result;
            result = 1;
            for (t = 1; t <= n; t++) result *= t;
            return result;
        }
    }
   public class Recursion
    {
       public  static void recmain()
        {
            Factorial f = new Factorial();
            Console.WriteLine("Factorials using recursive method.");
            Console.WriteLine("Factorial of 3 is " + f.FactR(3));
            Console.WriteLine("Factorial of 4 is " + f.FactR(4));
            Console.WriteLine("Factorial of 5 is " + f.FactR(5));
            Console.WriteLine();
            Console.WriteLine("Factorials using iterative method.");
            Console.WriteLine("Factorial of 3 is " + f.FactI(3));
            Console.WriteLine("Factorial of 4 is " + f.FactI(4));
            Console.WriteLine("Factorial of 5 is " + f.FactI(5));
            Console.WriteLine(); 
            Console.WriteLine("Recursion.fibonacci(20);");
           Console.WriteLine( Recursion.fibonacci(20));
        }
       public static long fibonacci(long n)
       {
           long i, sum = 0, f0 = 0, f1 = 1;
           for (i = 0; i <=n - 1;i++)
           {
               sum = f0 + f1;
               f0 = f1;
               f1 = sum;
               Console.WriteLine("sequence={0} add {1}  to make {2}", f0, f1, sum+f0);
           }
           if (n > 1)
               return sum+f0;
           else
               return n;
       }
    }
    [runnable]
  public class FactorialTester
   {
        [runnable]
       public static void Entry()
       {
           Recursion.recmain();
       }
   }
}