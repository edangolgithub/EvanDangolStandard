using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using EvanDangol.Reflection;

namespace EvanDangol.Tutorial
{
    class generic<T>
    {
        T ob;
        public generic(T o)
        {
            ob = o;
        }
        public T getob()
        {
            return ob;
        }
        public void showtype()
        {
            Console.WriteLine("The type of T is {0}\n", typeof(T));
        }
        public static void genericmain()
        {
            generic<int> intobject = new generic<int>(20);
            int i = intobject.getob();
            Console.WriteLine(i);
            intobject.showtype();
            generic<string> stringobject = new generic<string>("evan");
            string s = stringobject.getob();
            Console.WriteLine(s);
            stringobject.showtype();
            generic<object> obobject = new generic<object>("4.3");
            object o = obobject.getob();
            Console.WriteLine(o);
            obobject.showtype();
            generic<decimal> duckobject = new generic<decimal>(3456);
            decimal d = duckobject.getob();
            Console.WriteLine(d);
            duckobject.showtype();
        }
    }
    class mystack<T>
    {
        int stackpointer = 0;
        T[] stackarray;
        public void push(T x)
        {
            if (!isStackEmpty)
                stackarray[stackpointer++] = x;
        }
        public T pop()
        {
            return (!isStackEmpty) ? stackarray[--stackpointer]
                : stackarray[0];
        }
        const int MaxStack = 10;
        bool isStackFull { get { return stackpointer >= MaxStack; } }
        bool isStackEmpty { get { return stackpointer <= 0; } }
        public mystack()
        {
            stackarray = new T[MaxStack];
        }
        public void Print()
        {
            for (int i = stackpointer - 1; i >= 0; i--)
                Console.WriteLine(" Value: {0}", stackarray[i]);
        }
    }
    class stackmainclass
    {
        public static void stackmain()
        {
            mystack<int> stackInt = new mystack<int>();
            var stackString = new mystack<string>();
            stackInt.push(3); stackInt.push(5); stackInt.push(7);
            stackInt.Print();
            stackString.push("Generics are great!");
            stackString.push("Hi there! ");
            stackString.Print();
        }
    }
    class MyClass2
    {

    }
    // Construct a default value of T.
    class Test<T>
    {
        public T obj;
        public Test()
        {
            // The following statement would work only for reference types.
            // obj = null; // can’t use
            // The following statement will work only for numeric value types.
            // obj = 0; // can’t use
            // This statement works for both reference and value types.
            obj = default(T); // Works!
        }
    }
 
  class Generic
  {
      [runnable]
      public static void Run()
      {
generic<int>.genericmain();
            // Construct Test using a reference type.
            Test<MyClass2> x = new Test<MyClass2>();
            if (x.obj == null)
                Console.WriteLine("x.obj is null.");
            // Construct Test using a value type.
            Test<int> y = new Test<int>();
            if (y.obj == 0)
                Console.WriteLine("y.obj is 0.");
            stackmainclass.stackmain();
      }
      
  }
}