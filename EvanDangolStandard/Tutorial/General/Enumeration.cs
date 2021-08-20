using System;

namespace EvanDangol.Tutorial.General
{
   class Enumeration
    {
        public enum Temp
        {
            WickedCold = 0,
            FreezingPoint = 32,
            LightJacketWeather = 60,
            SwimmingWeather = 72,
            BoilingPoint = 212,
        }
        public static void temp()
        {
            Console.WriteLine("temp()");
            System.Console.WriteLine("Freezing point of water: {0}",
              (int)Enumeration.Temp.FreezingPoint);
            System.Console.WriteLine("Boiling point of water: {0}",
            (int)Enumeration.Temp.BoilingPoint);
        }
        enum Party
        {
            Democrat,
            ConservativeRepublican,
            Republican,
            Libertarian,
            Liberal,
            Progressive,
        };

       public  static void enu()
        {
            Party myChoice = Party.Libertarian;
            switch (myChoice)
            {
                case Party.Democrat:
                    Console.WriteLine("You voted Democratic.\n");
                    break;
                case Party.ConservativeRepublican: // fall through
                //Console.WriteLine(
                //"Conservative Republicans are voting Republican\n");
                case Party.Republican:
                    Console.WriteLine("You voted Republican.\n");
                    break;
                case Party.Liberal:
                    Console.WriteLine(" Liberal is now Progressive");
                    goto case Party.Progressive;
                case Party.Progressive:
                    Console.WriteLine("You voted Progressive.\n");
                    break;
                case Party.Libertarian:
                    Console.WriteLine("Libertarians are voting Democratic");
                    goto case Party.Democrat;
                default:
                    Console.WriteLine("You did not pick a valid choice.\n");
                    break;
            }
            Console.WriteLine("Thank you for voting.");
        }
    }
   public class EnumerationTester
   {
       public static void Entry()
       {
           Enumeration.temp();
           Enumeration.enu();
       }
   }

}
