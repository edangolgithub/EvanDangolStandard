using EvanDangol.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvanDangol.Tutorial.Generics
{
   public class PredicateTutorial
    {
       [runnable]
       public static void Run()
       {
           Predicate1.Test1();
       }
    }

   public class Predicate1
   {
       public static void Test1()
       {
           Predicate<HockeyTeam> ptest = IsNameStartsWithS;
           List<HockeyTeam> teams = new List<HockeyTeam>();
           teams.AddRange(new HockeyTeam[] { new HockeyTeam("Detroit Red Wings", 1926), 
                                         new HockeyTeam("Shicago Blackhawks", 1926),
                                         new HockeyTeam("San Jose Sharks", 1991),
                                         new HockeyTeam("Montreal Canadiens", 1909),
                                         new HockeyTeam("St. Louis Blues", 1967) });

           foreach (var item in teams.FindAll(ptest))
           {
               Console.WriteLine(item);
           }
       }
       private static bool IsNameStartsWithS(HockeyTeam obj)
       {
           return obj.Name.StartsWith("S");
       }
   }

   public class HockeyTeam
   {
       private string _name;
       private int _founded;

       public HockeyTeam(string name, int year)
       {
           _name = name;
           _founded = year;
       }

       public string Name
       {
           get { return _name; }
       }

       public int Founded
       {
           get { return _founded; }
       }
       public override string ToString()
       {
           return this.Name +" "+ this.Founded;
       }
   }

}
