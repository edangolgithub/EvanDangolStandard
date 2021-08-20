using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvanDangol.Tutorial.General
{
    class stack
    {
        char[] stck;
        int tos;
        public stack(int size)
        {
            stck = new char[size];// allocate memory for stack
            tos = 0;
        }
        public void Push(char ch)
        {
            if (tos == stck.Length)
            {
                Console.WriteLine(" -- stack is full.");
                return;
            }
            stck[tos] = ch;
            tos++;
        }
        public char Pop()
        {
            if (tos == 0)
            {
                Console.WriteLine(" -- stack is full.");
                return (char)0;
            }
            tos--;
            return stck[tos];
        }
        public bool IsFull()
        {
            return tos == stck.Length;
        }
        // Return true if the stack is empty.
        public bool IsEmpty()
        {
            return tos == 0;
        }
        // Return total capacity of the stack.
        public int Capacity()
        {
            return stck.Length;
        }
        // Return number of objects currently on the stack.
        public int GetNum()
        {
            return tos;
        }

    }
   public class StackTester
    {
       public static void stackmain()
        {
            stack stk1 = new stack(10);
            stack stk2 = new stack(10);
            stack stk3 = new stack(10);
            char ch;
            int i;
            // Put some characters into stk1.
            Console.WriteLine("Push A through J onto stk1.");
            for (i = 0; !stk1.IsFull(); i++)
                stk1.Push((char)('A' + i));
            if (stk1.IsFull()) Console.WriteLine("stk1 is full.");
            // Display the contents of stk1.
            Console.Write("Contents of stk1: ");
            while (!stk1.IsEmpty())
            {
                ch = stk1.Pop();
                Console.Write(ch);
            }
            Console.WriteLine();
            if (stk1.IsEmpty()) Console.WriteLine("stk1 is empty.\n");
            // Put more characters into stk1.
            Console.WriteLine("Again push A through J onto stk1.");
            for (i = 0; !stk1.IsFull(); i++)
                stk1.Push((char)('A' + i));
            // This causes stk2 to hold the elements in reverse order.
            Console.WriteLine("Now, pop chars from stk1 and push " +
            "them onto stk2.");
            while (!stk1.IsEmpty())
            {
                ch = stk1.Pop();
                stk2.Push(ch);
            }
            Console.Write("Contents of stk2: ");
            while (!stk2.IsEmpty())
            {
                ch = stk2.Pop();
                Console.Write(ch);
            }
            Console.WriteLine("\n");
            // Put 5 characters into stack.
            Console.WriteLine("Put 5 characters on stk3.");
            for (i = 0; i < 5; i++)
                stk3.Push((char)('A' + i));
            Console.WriteLine("Capacity of stk3: " + stk3.Capacity());
            Console.WriteLine("Number of objects in stk3: " +
            stk3.GetNum());
        }
        // Now, pop from stk1 and push the element in stk2
    }
}
