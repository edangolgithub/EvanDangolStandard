using EvanDangol.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvanDangol.Tutorial.General
{
    public class DelegateFunc
    {
        [runnable]
        public static void Run()
        {
            Action1.Run();
        }
    }
    public class DelegateExample
    {
        public static void AnonymousFuncT()
        {
            Func<int> f0 = () => 3 + 1;
            Console.WriteLine(f0());

            Func<int, int> f1 = (x) => x + 1;
            Console.WriteLine(f1(1));

            Func<int, int, int> f2 = (x, y) => x + y;
            Console.WriteLine(f2(1, 2));

            Func<int, int, int, int> f3 = (x, y, g) => x + y + g;
            Console.WriteLine(f3(1, 2, 3));

            Func<int, int, int, int, int> f = (x, y, g, h) => x + y + g + h;
            Console.WriteLine(f(1, 2, 3, 4));
        }
        public static void AnonymousPredicateT()
        {
            Predicate<int> istrue = a => a.Equals(3);
            Console.WriteLine(istrue(3));
        }
        public static void AnonymousFuncT1()
        {
            // Declare a Func variable and assign a lambda expression to the  
            // variable. The method takes a string and converts it to uppercase.
            Func<string, string> selector = str => str.ToUpper();

            // Create an array of strings.
            string[] words = { "orange", "apple", "Article", "elephant" };
            // Query the array and select strings according to the selector method.
            IEnumerable<String> aWords = words.Select(selector);

            // Output the results to the console.
            foreach (String word in aWords)
                Console.WriteLine(word);
        }

        public static void DelegateFunc()
        {
            Func<int> f0 = delegate() { return 5; };
            Console.WriteLine(f0());

            Func<int, int> f1 = delegate(int x) { return x + 1; };
            Console.WriteLine(f1(1));

            Func<int, int, int> f2 = delegate(int x, int y) {return x + y; };
            Console.WriteLine(f2(1, 2));

            Func<int, int, int, int> f3 = (x, y, g) => x + y + g;
            Console.WriteLine(f3(1, 2, 3));

            Func<int, int, int, int, int> f4 = (x, y, g, h) => x + y + g + h;
            Console.WriteLine(f4(1, 2, 3, 4));

           
        }

        public static void ActionFunc()
        {
            Action<int> f0 = delegate(int x) { Console.WriteLine(x); };
          

           
        }

        

    }
    public class Action1
    {
        public static void Run()
        {
           
            DoAction(DoInt);
        }

        

        

      
       
        public static void DoAction(Action<int> obj)
        {
            obj(6);
        }

       
    

        public static void DoInt(int a)
        {
            Console.WriteLine(a + a);
        }
    }
}
