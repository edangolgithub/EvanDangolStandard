using System.Collections.Generic;
using System.Collections;
using System;
namespace EvanDangol.Tutorial
{
    class Duck : IComparable<Duck>
    {
        //-----------------------------------------------------------------------------------------------------
        public enum KindOfDuck
        {
            Mallard, Muscovy, Decoy
        }
        public int Size;
        public KindOfDuck Kind;
        //-----------------------------------------------------------------------------------------------------
        public int CompareTo(Duck duckToCompare)
        {
            if (this.Kind > duckToCompare.Kind)
                return 1;
            else if (this.Kind < duckToCompare.Kind)
                return -1;
            else
                return 0;
        }
        //-----------------------------------------------------------------------------------------------------
        public class DuckComparer_bySize : IComparer<Duck>
        {
            //-----------------------------------------------------------------------------------------------------
            public int Compare(Duck x, Duck y)
            {
                if (x.Size < y.Size)
                    return -1;
                if (x.Size > y.Size)
                    return 1;
                return 0;
            }
        }
        //-----------------------------------------------------------------------------------------------------
        public static void runlist()
        {

            List<Duck> ducks = new List<Duck>()
{
new Duck() { Kind = KindOfDuck.Mallard, Size = 17 },
new Duck() { Kind = KindOfDuck.Muscovy, Size = 18 },
new Duck() { Kind = KindOfDuck.Decoy, Size = 14 },
new Duck() { Kind = KindOfDuck.Muscovy, Size = 11 },
new Duck() { Kind = KindOfDuck.Mallard, Size = 14 },
new Duck() { Kind = KindOfDuck.Decoy, Size = 13 },
}
            ;
            ducks.Sort();
            Console.WriteLine("sorting by duck kind\n");
            foreach (var duck in ducks)
                Console.WriteLine("{0}, {1}", duck.Kind.ToString(), duck.Size.ToString());
            Console.WriteLine("\nSorting by duck size\n");
            DuckComparer_bySize dc = new DuckComparer_bySize();
            ducks.Sort(dc);
            foreach (var item in ducks)
            {
                Console.WriteLine("{0}, {1}", item.Kind.ToString(), item.Size.ToString());

            }
        }
    }
    //-----------------------------------------------------------------------------------------------------
    public class GenericListTester
    {
        //-----------------------------------------------------------------------------------------------------
        public static void Entry()
        {
            Duck.runlist();
        }
    }

}


