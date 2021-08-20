using EvanDangol.Reflection;
using System;
using System.Diagnostics;
namespace EvanDangol.Tutorial.General
{
    class DelegateClass
    {
        delegate double MyDel(int par);

        //-----------------------------------------------------------------------------------------------------
        public static void runDelegateClass()
        {
            MyDel del = delegate(int x) { return x + 20; }; // Anonymous method notice semicolon at end
            MyDel le1 = (int x) => { return x + 20; }; //a: **Lambda expression
            MyDel le2 = (x) => { return x + 20; };
            MyDel le3 = x => { return x + 20; };
            MyDel le4 = x => x + 20;// ** statement shortens to this declaration same as a:
            Console.WriteLine("Normal Delegates");
            Console.WriteLine("Anonymous method  {0}", del(5));
            Console.WriteLine("Lambada Expression {0}", le1(5));
            Console.WriteLine("Short Lambada Expression {0}", le2(5));
            Console.WriteLine("Shorter Lambada Expression {0}", le3(5));
            Console.WriteLine("Shortest Lambada Expression {0}", le4(5));

        }

    }
    //-----------------------------------------------------------------------------------------------------
    #region delegatestring
    //-----------------------------------------------------------------------------------------------------
    delegate string mystringdelegate(string s);
    class delegatestring
    {
        //-----------------------------------------------------------------------------------------------------
        public static string ReplaceSpace(string s)
        {
            return s.Replace(' ', '_');

        }
        //-----------------------------------------------------------------------------------------------------
        public static string RemoveSpace(string s)
        {
            string temp = "";
            int count;
            for (count = 0; count < s.Length; count++)
            {
                if (s[count] != ' ')
                {
                    temp += s[count];
                }
            }
            return temp;
        }
        //-----------------------------------------------------------------------------------------------------
        public static string ReverseString(string s)
        {
            int j, i;
            string temp = "";
            for (i = 0, j = s.Length - 1; j >= 0; j--, i++)

                temp += s[j];
            return temp;

        }
    }
    //-----------------------------------------------------------------------------------------------------
    #endregion
    //-----------------------------------------------------------------------------------------------------
    class AnotherDelegateClass
    {
        //-----------------------------------------------------------------------------------------------------
        public static int Add(int x)
        {
            return x + 20;
        }
        delegate int otherdelegate(int par1);
        //-----------------------------------------------------------------------------------------------------
        public static void runAnotherDelegateClass()
        {
            otherdelegate del = Add;// non anonymous
            Console.WriteLine();
            Console.WriteLine("Non Anonymous");
            Console.WriteLine(del(5));
            Console.WriteLine();
        }
    }
    class AnonymousClass
    {
        delegate int Otherdelegate(int par1);
        //-----------------------------------------------------------------------------------------------------
        public static void runAnonymousClass()
        {
            Otherdelegate del = delegate(int x)//AnonymousClass class
            {
                return x + 20;
            };
            Console.WriteLine("Anonymous class");
            Console.WriteLine(del(5));
            Console.WriteLine();
        }
    }
    public delegate bool Comparasion(object x, object y);
    //-----------------------------------------------------------------------------------------------------
    #region SimpleDelegate
    //-----------------------------------------------------------------------------------------------------
    class SimpleDelegate
    {
        private delegate string Getstring();
        //-----------------------------------------------------------------------------------------------------
        public static void SimpleDelegateEntry()
        {
            Console.WriteLine("delegate Example");
            int a = 20;
            Getstring gs = a.ToString;
            Console.WriteLine(gs());// Console.WriteLine(x.ToString());

        }
    }
    //-----------------------------------------------------------------------------------------------------
    #endregion
    //-----------------------------------------------------------------------------------------------------

    //-----------------------------------------------------------------------------------------------------
    #region delegatebubblesort
    //-----------------------------------------------------------------------------------------------------

    //-----------------------------------------------------------------------------------------------------
    public class DelegateBubblesorter
    {
        //here function "comparesalary" is passed as parameter  to delegate
        //remember  "public  delegate bool Comparasion(object x, object y);"
        //so can be passed the function comparesalary(object x,object y);
        //-----------------------------------------------------------------------------------------------------
        public static void Sort(object[] sortArray, Comparasion comparasion)
        {
            for (int i = 0; i < sortArray.Length; i++)
            {
                for (int j = i + 1; j < sortArray.Length; j++)
                {
                    if (comparasion(sortArray[j], sortArray[i]))//need it to compare different
                    {                                          //  types other than integer etc
                        object temp = sortArray[i];
                        sortArray[i] = sortArray[j];
                        sortArray[j] = temp;
                    }
                }
            }
        }
    }
    //-----------------------------------------------------------------------------------------------------
    public class Staff
    {
        string name;
        decimal salary;
        //-----------------------------------------------------------------------------------------------------
        public Staff(string name, decimal salary)
        {
            this.name = name;
            this.salary = salary;
        }
        //-----------------------------------------------------------------------------------------------------
        public override string ToString()
        {
            return string.Format("Name : {0}, salary : {1:c}", name, salary);
        }
        //-----------------------------------------------------------------------------------------------------
        public static bool CompareSalary(object x, object y)
        {
            Staff s1 = (Staff)x;
            Staff s2 = (Staff)y;
            return (s1.salary < s2.salary);
        }
    }
    class DelegateBubbleSorterTester
    {
        //-----------------------------------------------------------------------------------------------------
        public static void DelegateBubbleSorterTesterEntry()
        {
            Staff[] staffs =
{
new Staff("Evan Dangol",10000),
new Staff("Sunil Kapali",70000),
new Staff("Anil Shrestha",60000),
new Staff("Pawan Thapa",30000),
new Staff("Krishna Gurung",79000),
new Staff("Sanjay Tamang",75000)
};
            Console.WriteLine("\tDelegateBubblesorter");
            Console.WriteLine();
            Console.WriteLine("Unsorted Staffs");
            Console.WriteLine();
            foreach (var staff in staffs)
            {
                Console.WriteLine(staff);
            }
            Console.WriteLine();
            DelegateBubblesorter.Sort(staffs, Staff.CompareSalary);
            Console.WriteLine("Sorting staffs according to the salary");
            Console.WriteLine();
            foreach (var staff in staffs)
            {
                Console.WriteLine(staff);
            }
        }
    }
    //-----------------------------------------------------------------------------------------------------
    #endregion
    //-----------------------------------------------------------------------------------------------------

    //-----------------------------------------------------------------------------------------------------
    #region LambadaDelegate
    //-----------------------------------------------------------------------------------------------------
    class LambadaDelegate
    {

        delegate string DelegateTest(string val);
        //-----------------------------------------------------------------------------------------------------
        public static void LambadaDelegateEntry()
        {
            DateTime dt = DateTime.Now; TimeSpan dt1 = new TimeSpan();
            foreach (var item in Process.GetProcesses())
            {
                Console.WriteLine(item.ProcessName);
            }
            string mid = ",middle part,";
            DelegateTest lamdel = param => param += mid + " and this was added to the string.";
            //{
            //    param += mid;
            //    param += " and this was added to the string.";
            //    return param;
            //};
            Console.WriteLine(lamdel("start of string"));

            Console.WriteLine(Process.GetCurrentProcess().Threads[0].UserProcessorTime.Subtract(dt1).TotalMilliseconds);
        }
        //-----------------------------------------------------------------------------------------------------
        public static void Lambada()
        {

            Func<int, int, int> mydel = (a, b) => (a + b);
            /* similar to
            * public static int add(int a, int b)
            {
            return a + b;
            }
            Func<int, int, int> mydel =add;
            */
            Console.WriteLine(mydel(2, 6));
            Action display = () => Console.WriteLine("uhuygyu");
            display();
        }
    }
    //-----------------------------------------------------------------------------------------------------
    #endregion
    //-----------------------------------------------------------------------------------------------------

    //-----------------------------------------------------------------------------------------------------
    public class Delegate
    {

        //-----------------------------------------------------------------------------------------------------


        [runnable]
        public static void Run()
        {
            Entry();
            dtest.PrimeNumberFound += dtest.PrimeFoundMessage;
            dtest.primes();
        }
        
        public static void Entry()
        {
            DelegateClass.runDelegateClass();
            AnotherDelegateClass.runAnotherDelegateClass();
            AnonymousClass.runAnonymousClass();
            SimpleDelegate.SimpleDelegateEntry();
            DelegateBubbleSorterTester.DelegateBubbleSorterTesterEntry();
            LambadaDelegate.LambadaDelegateEntry();
            delstring();

        }
        //-----------------------------------------------------------------------------------------------------
        private static void delstring()
        {
            string s = "This is Test For Delegate Function";
            mystringdelegate delobj = delegatestring.ReverseString;
            Console.WriteLine("Invoking First delegate :" + Environment.NewLine + "delobj = delegatestring.ReverseString;");

            Console.WriteLine("Normal String :{0}", s);
            delegatestring.ReverseString(s);
            Console.WriteLine("Reversed String :{0}", delobj(s));
            Console.WriteLine();
            delobj = delegatestring.RemoveSpace;
            Console.WriteLine("Invoking Second delegate :" + Environment.NewLine + "delobj = delegatestring.RemoveSpace;");

            Console.WriteLine("Normal String :{0}", s);
            delegatestring.ReverseString(s);
            Console.WriteLine("Modified String :{0}", delobj(s));
            Console.WriteLine();
            delobj = delegatestring.ReplaceSpace;
            Console.WriteLine("Invoking Third delegate :" + Environment.NewLine + "delobj = delegatestring.ReplaceSpace;");

            Console.WriteLine("Normal String :{0}", s);
            delegatestring.ReverseString(s);
            Console.WriteLine("Modified String :{0}", delobj(s));
            Console.WriteLine();

            Console.WriteLine("calling DelegateClass.runDelegateClass();");
            DelegateClass.runDelegateClass();
            Console.WriteLine();
            Console.WriteLine("calling AnotherDelegateClass.runAnotherDelegateClass();");

            AnotherDelegateClass.runAnotherDelegateClass();
            Console.WriteLine();
            Console.WriteLine("calling AnonymousClass.runAnonymousClass();");

            AnonymousClass.runAnonymousClass();
            Console.WriteLine();

          
        }
     
    }
    public class PrimeNumberEventArgs:EventArgs
    {
        public int PrimeNumber { get; set; }
    }
    public delegate void PrimeNumberFoundDelegate(PrimeNumberEventArgs e);
  public  class dtest
    {
      public static event PrimeNumberFoundDelegate PrimeNumberFound;

      public static void PrimeNumberIsFound(int number)
      {
          PrimeNumberFoundDelegate handler = PrimeNumberFound;
          PrimeNumberEventArgs arg = new PrimeNumberEventArgs();
          arg.PrimeNumber = number;
          if(handler!=null)
          {
              handler(arg);
          }
      }
        public static void primes()
        {
            
            for (int i = 1; i < 101; i++)
            {
              if(checkprime(i))
              {
                  PrimeNumberIsFound(i);
                  
              }
              //System.Threading.Thread.Sleep(10);
            }
        }
      public static void PrimeFoundMessage(PrimeNumberEventArgs e)
        {
            Console.WriteLine("Prime Number Found, "+e.PrimeNumber);
        }

        private static bool checkprime(int i)
        {
            for (int j = 2; j < i - 1; j++)
            {
                if (i % j == 0)
                {
                    return false;
                    
                }
               

            }
            return true;
        }
    }
}


