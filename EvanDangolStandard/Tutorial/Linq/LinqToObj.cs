using EvanDangol.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace EvanDangol.Tutorial.Linq
{
    class LinqToObj
    {
       static int[] intarray;
        public static int[] Getintarray()
        {
           intarray = new int[] { 21, 76, 76, 65, 3, 56, 65, 87, 45, 234, 5, 78, 54, 98, 13 };
           return intarray;
        }
        public static void displayintarray()
        {
            Console.Write(" {");
            foreach (int i in Getintarray())
            {
                if (i == Getintarray().Last())
                {
                    Console.WriteLine(i+" }");
                }else
                Console.Write(i + ", ");  
            }
        } 
        [runnable]
        public static void LinqToObjEntry()
        {
            Console.Write("The array is :");
            displayintarray();
            Console.WriteLine();
            int query = Getintarray().Min();
            Console.WriteLine("Maximum value in array is :{0}",Getintarray().Max());
            Console.WriteLine("Minimum value in array is :{0}", Getintarray().Min()); 
            Console.WriteLine("Length of array is :{0}", Getintarray().Length); 
            Console.WriteLine("First Element in array is :{0}", Getintarray().First());
            Console.WriteLine("Last Element in array is :{0}", Getintarray().Last());
            Console.WriteLine("Rank of the array is :{0}", Getintarray().Rank);
            Console.WriteLine("Sum of values in array is :{0}", Getintarray().Sum());
            Console.WriteLine("Average value in array is :{0}", Getintarray().Average());
        }
    }
     
}
