using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace EvanDangol.Tutorial.General
{
    class EvanReflectionClass
    {
        public static void showassembly()
        {
            Assembly asembly = Assembly.LoadFrom("Evancsharp.exe");
            Type[] t = asembly.GetTypes().OrderBy(a => a.FullName).Where(a => a.IsClass && !a.IsGenericType&&!a.IsSealed).ToArray();
            foreach (Type tt in t)
            {
                Console.WriteLine("class Name   : {0}", tt.Name);
                foreach (var mi in tt.GetMethods(
                    BindingFlags.DeclaredOnly |
                    BindingFlags.Public |
                    BindingFlags.NonPublic |
                    BindingFlags.Static)
                    .OrderByDescending(a => a.Name))
                {
                    var a = mi.GetParameters().Select(aa => aa.ParameterType);
                    Console.WriteLine("Function name :{0}()", mi.Name);
                    Console.WriteLine("Return Type    :{0}", mi.ReturnType.Name);
                    //foreach (var b in a)
                    //{

                    //    Console.WriteLine("Parameters    :{0} ", b.Name);
                    //}
                    // Display parameters.
                    Console.WriteLine("method signature :-");
              
                    ParameterInfo[] pi = mi.GetParameters();
                    Console.Write(" " + mi.ReturnType.Name +
" " + mi.Name + "(");
                    for (int i = 0; i < pi.Length; i++)
                    {
                        Console.Write(pi[i].ParameterType.Name +
                        " " + pi[i].Name);
                        if (i + 1 < pi.Length) Console.Write(", ");
                    }
                    Console.WriteLine(")");
                    Console.WriteLine();
                }

                Console.WriteLine();
            }
        }


    }
    public class ReflectionTester
    {
        public static void Entry()
        {
            EvanReflectionClass.showassembly();
        }
    }
}
