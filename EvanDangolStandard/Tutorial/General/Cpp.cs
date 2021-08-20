using EvanDangol.Reflection;
using System;

namespace EvanDangol.Tutorial.General
{
    //-----------------------------------------------------------------------------------------------------
    public class Greatest
    {

        //-----------------------------------------------------------------------------------------------------
        public static void greatestEntry()
        {
            Random r = new Random();
            int x, y, z;
            x = r.Next(80);
            y = r.Next(80);
            z = r.Next(80);

            try
            {
                Console.WriteLine();
                Console.WriteLine("greater()");

                Console.WriteLine("Please enter first number: {0}", x);

                Console.WriteLine("Please enter second number: {0}", y);

                Console.WriteLine("Please enter third number: {0}", z);

                if (x > y)
                    if (x > z)
                    {
                        Console.WriteLine("The Greatest Of Three numbers are:" + x);
                    }
                    else
                    {
                        Console.WriteLine("The Greatest Of Three numbers are:" + z);
                    }
                else
                    if (y > z)
                    {
                        Console.WriteLine("The Greatest Of Three numbers are:" + y);
                    }
                    else
                    {
                        Console.WriteLine("The Greatest Of Three numbers are:" + z);
                    }

            }

            catch (Exception yy)
            {
                Console.WriteLine(yy.ToString());

            }
        }
    }
    //-----------------------------------------------------------------------------------------------------
    public class Cpp
    {
        //-----------------------------------------------------------------------------------------------------
        [runnable]
        public static void Run()
        {
            Greatest.greatestEntry();
        }
    }
}


