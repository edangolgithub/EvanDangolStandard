using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvanDangol.Tutorial.General
{
    public class StaticTester
    {
        public static void staticmain()
        {
            Console.WriteLine(Feeling());
        }
        public static string Feeling()
        {
            string[] messaeges ={"I Love You", "I Hate You",
             "I'm too tired.....", "I feel good", "You are sooooooooooo Wrong!"};
            return messaeges[GetRandomNumber(5)];
        }
        public static Random r = new Random();
        public static int GetRandomNumber(short upperLimit)
        {
            return r.Next(upperLimit);
        }
    }
}
           