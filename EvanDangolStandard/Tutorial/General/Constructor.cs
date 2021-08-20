using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvanDangol.Tutorial.General
{
     public class Time
    {
         int Year, Month, Date, Hour, Minute, Second;
         public void DisplayCurrentTime()
         {
             Console.WriteLine("{0}/{1}/{2}  {3}:{4}:{5}",Month,Date,Year,Hour,Minute,Second);
         }
         public Time(System.DateTime dt)
         {
             Year=dt.Year;
             Month = dt.Month;
             Date = dt.Day;
             Hour = dt.Hour;
             Minute = dt.Minute;
             Second = dt.Second;
         }
         public Time(int Year, int Month, int Date, int Hour, int Minute)
         {
             this.Year = Year;
             this.Month = Month;
             this.Date = Date;
             this.Hour = Hour;
             this.Minute = Minute;
         }
         public static void timemain()
         {
             Time t = new Time(1,2,3,4,5);
             Console.WriteLine("timemain()");
             t.DisplayCurrentTime();
         }

     }
     class Motorcycle
     {
         public int driverIntensity;
         public string driverName;
         public void setDriverName(string name)
         {
             this.driverName = name;
         }
         public void Popwheely()
         {
             for (int i = 1; i <= driverIntensity; i++)
                 Console.WriteLine("yyyeeehhhhwww");
         }
         public Motorcycle() { }
         public Motorcycle(int intensity)
         {
             setIntensity(intensity);
         }

         public void setIntensity(int intensity)
         {
             if (intensity > 10)
             {
                 intensity = 10;
             }
             driverIntensity = intensity;
         }

         public Motorcycle(int intensity, string name)
         {
             if (intensity > 10)
             {
                 intensity = 10;
             }
             driverIntensity = intensity;
             driverName = name;
             Console.WriteLine("{0}", driverIntensity);
             
         }
         public void display()
         {
             Console.WriteLine();
             Console.WriteLine("Driver name: {0}",driverName);
             Console.WriteLine("Drive Intensity: {0}",driverIntensity);
             Popwheely();
         }
     }
     public class ConstructorTester
     {
         public static void Entry()
         {
             Time.timemain();
             Motorcycle motor = new Motorcycle();
             Motorcycle motor1 = new Motorcycle(1);
             Motorcycle motor2 = new Motorcycle(2,"EvanDangol");
             Console.WriteLine();
             motor.display();
             motor1.display();
             motor2.display();
         }
     }
}
   
    

