using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvanDangol.Tutorial.General
{
    class Indexer 
    {
        public string LastName; // Call this field 0.
        public string FirstName; // Call this field 1.
        public string CityOfBirth; // Call this field 2.
        public string this[int index] // Indexer declaration
        {
            set // Set accessor declaration
            {
                switch (index)
                {
                    case 0: LastName = value;
                        break;
                    case 1: FirstName = value;
                        break;
                    case 2: CityOfBirth = value;
                        break;
                    default: // (Exceptions in Ch. 11)
                        throw new ArgumentOutOfRangeException("index");
                       
                }
            }
            get // Get accessor declaration
            {
                switch (index)
                {
                    case 0: return LastName;
                    case 1: return FirstName;
                    case 2: return CityOfBirth;
                    default: // (Exceptions in Ch. 11)
                        throw new ArgumentOutOfRangeException("index");
                        
                }
            }
        }
      public  static void IndexerEntry()
        {
            Indexer c1 = new Indexer();
            c1.LastName = "dangol";
            c1.FirstName = "Evan";
            c1.CityOfBirth = "Kathmandu";
            c1[0] = "ee";
            c1[1] = "bb";
            c1[2] = "cc";
            Console.WriteLine("{0}\t{1}", c1[0],c1.LastName);
            Console.WriteLine("{0}\t{1}", c1[1],c1.FirstName);
            Console.WriteLine("{0}\t{1}", c1[2],c1.CityOfBirth);
        }

    }
    class Indexer2
    {
        int Temp0; // Private field
        int Temp1; // Private field
        public int this[int index] // The indexer
        {
            get
            {
                return (0 == index) // Return value of either Temp0 or Temp1
                ? Temp0
                : Temp1;
            }
            set
            {
                if (0 == index)
                    Temp0 = value; // Note the implicit variable "value".
                else
                    Temp1 = value; // Note the implicit variable "value".
            }
        }
    }
   public class IndexerTester
    {
       public  static void Entry()
        {
            Indexer.IndexerEntry();
            Indexer2 a = new Indexer2();
            Console.WriteLine("Values -- T0: {0}, T1: {1}", a[0], a[1]);
            a[0] = 15;
            a[1] = 20;
            Console.WriteLine("Values -- T0: {0}, T1: {1}", a[0], a[1]);
        }
    }
}
