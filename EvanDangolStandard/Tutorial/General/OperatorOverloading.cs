using System;
namespace EvanDangol.Tutorial.General
{
    class Addclass
    {
        public int a;
        public static Addclass operator +(Addclass obj1, Addclass obj2)
        {
            Addclass result = new Addclass();
            result.a = obj1.a + obj2.a;
            return result;
        }
    }
     class operatoroverloading
    {
        string n = null;
        public int s = 2;


        public static operatoroverloading operator -(operatoroverloading q, operatoroverloading r)
        {
            operatoroverloading w = (operatoroverloading)q;
            w.s = 455;
            w.n = "evan";
            return w;
        }
        public static operatoroverloading operator -(operatoroverloading q)
        {
            operatoroverloading w = new operatoroverloading();
            w.n = "hello";
            return w;
        }


        public static void result()
        {
            operatoroverloading c = new operatoroverloading();
            operatoroverloading d = new operatoroverloading();
            operatoroverloading e = new operatoroverloading();
            e = d - c;
            Console.WriteLine(e.s + e.n);
            e = -c;
            Console.WriteLine(e.n);
        }

    }


    public class OperatorOverloadingTester
    {
        public static void Entry()
        {
            Addclass obj1 = new Addclass();
            Addclass obj2 = new Addclass();
            obj1.a = 10;
            obj2.a = 20;
            Addclass obj3 = new Addclass();
            obj3 = obj1 + obj2;
            Console.WriteLine(obj3.a);
            operatoroverloading.result();
        }
    }
}



