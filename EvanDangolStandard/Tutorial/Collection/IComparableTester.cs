using EvanDangol.Reflection;
using System;
using System.Collections;
using System.Linq;

namespace EvanDangol.Tutorial.Collection
{
    #region LastNameComparable
    class LastNameComparable : IComparable
    {

        public string lastname;       

        int IComparable.CompareTo(object obj)
        {
            LastNameComparable compareme = (LastNameComparable)obj;
            int result = this.lastname.CompareTo(compareme.lastname);
            return result;
        }

       
    }
     #endregion

    #region TheValueComparable
    //class TheValueComparable : IComparable
    //{
    //    public int thevalue;
    //    public int CompareTo(object ob)
    //    {
    //        TheValueComparable mc = (TheValueComparable)ob;
    //        if (this.thevalue < mc.thevalue) return -1;
    //        if (this.thevalue > mc.thevalue) return 1;
    //        return 0;
    //    }

    //}
    #endregion
     
   
    public class IComparableTester
    {

        [runnable]
        public static void Run()
        {

            LastNameComparable[] objarray = {  new LastNameComparable{lastname="Rana"}, new LastNameComparable{lastname="Maharjan"},
                new LastNameComparable {lastname="Thapa"},  new LastNameComparable{lastname="Shrestha"},
                new LastNameComparable{lastname="Kapali"},  new LastNameComparable {lastname="Bajracharya"},
                new LastNameComparable{lastname="Parajuli"},new LastNameComparable{lastname="Upadhyaye"},
                new LastNameComparable{lastname="Smith"}, new LastNameComparable{lastname="Dangol"}     };

            Console.WriteLine("Unsorted Names\n");
            foreach (LastNameComparable c in objarray)
            {
                Console.WriteLine(c.lastname);
            }

            Array.Sort(objarray);
            Console.WriteLine();
            Console.WriteLine("\nsorted Names\n");

            foreach (LastNameComparable c in objarray)
            {
                Console.WriteLine(c.lastname);
            }
            Console.WriteLine("\nLambada Method\n");

            string m = objarray.
                Select(a => a.lastname).
                Where(a => a.StartsWith("Da")).
                SingleOrDefault();
            Console.WriteLine(m);
            Console.WriteLine();

            Console.WriteLine("\nIenumerator.MoveNext Method\n");
            IEnumerator enumerator = objarray.GetEnumerator();
            while (enumerator.MoveNext())
            {

                LastNameComparable ob = (LastNameComparable)enumerator.Current;
                if (ob.lastname.Equals("Kapali")) return;
                Console.WriteLine(ob.lastname);
            }

        }
       

        
    }
}
