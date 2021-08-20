using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;

namespace EvanDangol.Tutorial.Linq
{
    class SimpleLinqToObjects
    {

        public static void SimpleLinqToObjectsFunction()
        {
            List<int> list = new List<int> { 1, 2, 3, 4, 5 };
            IEnumerable<int> result = from f in list
                                      where f < 4
                                      select f;
            foreach (var v in result)
            {
                Console.Write(v + "\t");
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("The next Method produces same result");
            // Create some test data.

            List<int>.Enumerator e = list.GetEnumerator();
            while (e.MoveNext())
            {
                while (e.Current < 4)
                {
                    Console.Write(e.Current + "\t");
                    break;
                }

            }
            Console.WriteLine();

        }
        class Customer
        {
            public string CustomerID { get; set; }
            public string ContactName { get; set; }
            public string City { get; set; }
        }
        private static List<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer {ContactName="Evan Dangol",City="Kathmandu"},
                new Customer{ContactName="Ram Krishna",City="London"}
            };
            /* Above code is same as :
             Customer customer1 = new Customer();
             customer1.ContactName = "Evan Dangol";
             customer1.City = "Kathmandu";
             return new List<Customer> { customer1 };
             c#2.0 syntax*/
        }
        public static void CustomerFunction()
        {
            Console.WriteLine("Object Initializer\n");
            var query = from f in GetCustomers()
                        where f.City == "Kathmandu"
                        select new { f.ContactName, f.City };
            foreach (var v in query)
            {
                Console.WriteLine("Name of the Customer: {0} and City: {1}\n", v.ContactName, v.City);
            }
        }
        public static void PresidentFunction()
        {
            string[] presidents = {
"Adams", "Arthur", "Buchanan", "Bush", "Carter", "Cleveland",
"Clinton", "Coolidge", "Eisenhower", "Fillmore", "Ford", "Garfield",
"Grant", "Harding", "Harrison", "Hayes", "Hoover", "Jackson",
"Jefferson", "Johnson", "Kennedy", "Lincoln", "Madison", "McKinley",
"Monroe", "Nixon", "Pierce", "Polk", "Reagan", "Roosevelt", "Taft",
"Taylor", "Truman", "Tyler", "Van Buren", "Washington", "Wilson"};
            IEnumerable<string> presidemt = presidents.Where(s => s.Contains("a") || s.Equals("Polk") || s.EndsWith("y") || s.Length > 5);
            foreach (string a in presidemt)
            {
                Console.WriteLine(a);
            }
            var objs = presidents.Select(p => new { LastName = p, Length = p.Length });
            foreach (var b in objs)
            {
                Console.WriteLine("{0} is {1} characters long.", b.LastName, b.Length);
            }
        }
        public static void IntArray()
        {
            int[] ints = new int[101];

            for (int i = 0; i <= 100; i++)
            {
                ints[i] = i;
            }
            IEnumerable<int> intquery = ints.Where(s => s <= 10);
            foreach (int intanswer in intquery)
            {
                Console.WriteLine(intanswer);
            }
        }
    }
    public class SimpleLinqToObjectsTester
    {
        public static void Entry()
        {
            SimpleLinqToObjects.SimpleLinqToObjectsFunction();
            SimpleLinqToObjects.IntArray();
        }
    }
}
