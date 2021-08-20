using EvanDangol.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvanDangol.Tutorial.General
{
    public interface ITransactions
    {
        // interface members
        void showTransaction();
        double getAmount();
    }

    public class Transaction : ITransactions
    {
        private string tCode;
        private string date;
        private double amount;
        public Transaction()
        {
            tCode = " ";
            date = " ";
            amount = 0.0;
        }

        public Transaction(string c, string d, double a)
        {
            tCode = c;
            date = d;
            amount = a;
        }

        public double getAmount()
        {
            return amount;
        }

        public void showTransaction()
        {
            Console.WriteLine("Transaction: {0}", tCode);
            Console.WriteLine("Date: {0}", date);
            Console.WriteLine("Amount: {0}", getAmount());
        }
    }
    class Tester
    {
       public static void run()
        {
            Transaction t1 = new Transaction("001", "8/10/2012", 78900.00);
            Transaction t2 = new Transaction("002", "9/10/2012", 451900.00);
            t1.showTransaction();
            t2.showTransaction();
          
        }
    }

    #region old
    class MyClass : IComparable // Class implements interface.
    {
        public int TheValue;
        public int CompareTo(object obj) // Implement the method.
        {
            MyClass mc = (MyClass)obj;
            if (this.TheValue < mc.TheValue) return -1;
            if (this.TheValue > mc.TheValue) return 1;
            return 0;
        }
    }



    #endregion
    public  class Interface
    {
        static void PrintOut(string s, MyClass[] mc)
        {
            Console.Write(s);
            foreach (var m in mc)
                Console.Write("{0} ", m.TheValue);
            Console.WriteLine("");
        }
      public  static void mcmain()
        {
            var myInt = new[] { 20, 4, 16, 9, 2 };
            MyClass[] mcArr = new MyClass[5]; // Create array of MyClass objs.
            for (int i = 0; i < 5; i++) // Initialize the array.
            {
                mcArr[i] = new MyClass();
                mcArr[i].TheValue = myInt[i];
            }
            PrintOut("Initial Order: ", mcArr); // Print the initial array.
            Array.Sort(mcArr); // Sort the array.
            PrintOut("Sorted Order: ", mcArr); // Print the sorted array.
        }
  [runnable]
      public static void Entry()
      {
          Interface.mcmain();
          Tester.run();
          

      }
  }
   
}
