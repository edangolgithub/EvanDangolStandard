using EvanDangol.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvanDangol.Tutorial.General
{
    public class Attributes
    {
        [runnable]
        public static void Run()
        {
            evan e = new evan();
            
        }
    }
    [System.AttributeUsage(System.AttributeTargets.Class|System.AttributeTargets.Struct)]
    public class Author : System.Attribute
    {
        private string name;
        public double version;

        public Author(string name)
        {
            this.name = name;
            version = 1.0;
        }
    }
    [Author("evan")]
    public class evan
    {

    }
}
