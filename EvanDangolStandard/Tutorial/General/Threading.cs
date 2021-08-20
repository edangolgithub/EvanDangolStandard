using EvanDangol.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EvanDangol.Tutorial.General
{
    public class Threading
    {
        [runnable]
        public static void Run()
        {
           EvanAsync.threadstart();
        }
        public static void Entry()
        {
            DateTime dt = DateTime.Now;
            Console.WriteLine("Main thread starting. at " + dt.ToLongTimeString());
            // First, construct a MyThread object.
            MyThread mt = new MyThread("Child #1");
            // Next, construct a thread from that object.
            Thread newThrd = new Thread(mt.Run);
            // Finally, start execution of the thread.
            newThrd.Start();
            do
            {
                Console.Write(".");
                Thread.Sleep(10);

            } while (mt.Count != 10);
            DateTime ddd = DateTime.Now;
            Console.WriteLine("Main thread ending. at " + ddd.ToLongTimeString());
        }
    }
    class MyThread
    {
        
        public int Count;
        string thrdName;
        public MyThread(string name)
        {
            Count = 0;
            thrdName = name;
        }
        // Entry point of thread.
        public void Run()
        {
            Console.WriteLine(thrdName + " starting.");
            do
            {   DateTime dt = DateTime.Now;
                Thread.Sleep(1);
                Console.WriteLine("In " + thrdName +
                ", Count is " + Count + " at " + dt.ToLongTimeString());
                Count++;
            } while (Count < 10);
            DateTime dd = DateTime.Now;
            Console.WriteLine(thrdName + " terminating. at" + dd.ToLongTimeString());
        }
    }
  
    class EvanThreading1
    { 
        Thread t1 = new Thread(startthread1);
            Thread t2 = new Thread(startthread2);
        public void threadstart()
        {
           
            t2.Priority = ThreadPriority.AboveNormal;
          
            t1.Start(); 
            t2.Start();
              
        }
        public static void startthread1()
        {

            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("thread 1 executing : " + i);
              
            }
        }
        public static void startthread2()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("thread 2 executing : " + i);
            }
        }
    }

    class EvanThreading2
    {
        
        public void threadstart()
        {
            Thread t1 = new Thread((a)=> { Console.WriteLine(a); });
            t1.Start(5);

            
        }
    }
    class EvanAsync
    {
        public static void threadstart()
        {

            Task task = new Task(startthread2);
            task.Start();
            task.Wait();
            
        }
        public  static void startthread2()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("thread 2 executing : " + i);
            }
        }
    }
}
