using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using EvanDangol.Reflection;

namespace EvanDangol.Tutorial.General
{
    class ArrayListclass 
    {
        public static void displaylistcollection()
        {

            ArrayList list = new ArrayList();
            list.Add(44);
            list.Add("mystring"); //this will create runtime error int vs string
            Console.WriteLine(" result of nongeneric displaylistcollection()");
            try
                { 
            foreach (int i in list)
            {
               
                    Console.WriteLine("Non Generic ArrayList {0}", i);
                }
               
            }
            catch (Exception)
                {
                    Console.WriteLine("Error because  \"mystring\" is array and 44 is int cant add both to same array");
                }
        }
        public static  void displaylistcollection1()
        {
            List<int> list = new List<int>();
            list.Add(44);
            //list.Add("mystring"); // compile time error
            Console.WriteLine();
            Console.WriteLine(" result of Generic displaylistcollection1()");
            foreach (int i in list)
            {
                Console.WriteLine("Generic List {0}",i); 
            }
            
        }
    }
    public class ArrayListClass
    {
        [runnable]
        public static void Run()
        {
            ArrayListclass.displaylistcollection();
            ArrayListclass.displaylistcollection1();
        }
    }
}