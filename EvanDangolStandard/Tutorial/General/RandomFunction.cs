using EvanDangol.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvanDangol.Tutorial.General
{
   class RandomFunction
    {
       [runnable]
       public static void random()
       {
        double big;
        double bigger;
        double raw;
        Random r = new Random();
        raw = r.NextDouble();
        big = raw * 6;
        bigger = (int)big + 1;
        Console.WriteLine(" Random value was {0}/ however integer is {1}",big, bigger);
           Console.WriteLine();    
      }
    }
   class Menumaker
   {
       public Random Randomizer = new Random();
       string[] Meats = { "Ranga Ko Masu", "Kukhura Ko Masu", "Khasi Ko Masu", "Syaa Bhaley", "Mriga Ko Masu" };
       string[] Condiments = { "Bhuteko", "Tareko",
                            "Piro Masala Rakheko", "Kabab Banayeko", "Roast Gareko", "Golbheda ko Achar" };
       string[] Breads = { "Chiura", "Bhat", "Roti", "Burgur",
                        "italian bread", "Naan" };
       public string GetMenuItem()
       {
           string randomMeat = Meats[Randomizer.Next(Meats.Length)];
           string randomCondiment = Condiments[Randomizer.Next(Condiments.Length)];
           string randomBread = Breads[Randomizer.Next(Breads.Length)];
           return randomMeat+" " + randomCondiment +" " + randomBread+ " Sanga. ";
       }
       public static void menumakerMain()
       {
           Menumaker m = new Menumaker();
           Console.WriteLine();
           for (int i = 0; i < 10; i++)
           {               
               Console.WriteLine(m.GetMenuItem() + Environment.NewLine);
           }
       }
   }
   public class RandomFunctionTester
   {
       public static void Entry()
       {
           RandomFunction.random();
           Menumaker.menumakerMain();
       }
   }
}
