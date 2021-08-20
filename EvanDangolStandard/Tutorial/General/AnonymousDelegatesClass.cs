using EvanDangol.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvanDangol.Tutorial.General
{
    class AnonymousDelegatesClass
    {
        delegate string DelegateTest(string val);
        [runnable]
        public static void Run()
        {
            string mid = ",middle part,";
            DelegateTest anondel = delegate(string param)
            {
                param += mid;
                param += " and this was added to the string.";
                return param;
            };
            Console.WriteLine();
            Console.WriteLine("AnonymousDelegate");
            Console.WriteLine(anondel("start of string."));
        }
    }
   
}
