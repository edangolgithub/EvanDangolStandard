using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using EvanDangol.Reflection;

namespace EvanDangol.Tutorial.General
{
    #region Anonymoustype
    class AnonymoustypeClass
    {
        [runnable]
        public static void Run()
        {
            //no need to declare class
            var m = new
            {
                name = "evan",
                address = "thamel"
            };
            Console.WriteLine("Hash code is {0}", m.GetType().GetHashCode());
            Console.WriteLine("Name is {0}\n and address is {1}", m.name, m.address);
        }
    }
    #endregion

}
