using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;


namespace EvanDangol.Tutorial.General
{
    class collectionstack
    {
        public static void stack()
        {
            Stack stringStack = new Stack();
            stringStack.Push("one");
            stringStack.Push("two");
            stringStack.Push("three");
            // stringStack.Push("hello");
            Console.WriteLine("Top item is: {0}", stringStack.Peek());
            Console.WriteLine("Popped off {0}", stringStack.Pop());
            Console.WriteLine("Top item is: {0}", stringStack.Peek());
            Console.WriteLine("Popped off {0}", stringStack.Pop());
            Console.WriteLine("Top item is: {0}", stringStack.Peek());
            Console.WriteLine("Popped off {0}", stringStack.Pop());
            try
            {
                Console.WriteLine("Top item is: {0}", stringStack.Peek());
                Console.WriteLine("Popped off {0}", stringStack.Pop());
                Console.WriteLine("Top item is: {0}", stringStack.Peek());
                Console.WriteLine("Popped off {0}", stringStack.Pop());
            }
            catch (Exception e)
            { Console.WriteLine("Error!! {0}", e.Message + e.ToString()); }

        }
       
    }
    public class Collection_StackTester
    {
        public static void Entry()
        {
            collectionstack.stack();
        }
    }
}
   