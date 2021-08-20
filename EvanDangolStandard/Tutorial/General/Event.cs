using System;
using System.Timers;
using System.Threading;

namespace EvanDangol.Tutorial.General
{
    #region OnOneSecond
    delegate void eventhandler();
     class MyTimerClass
    {
        public event EventHandler Elapsed; // Declare the event.
        private void OnOneSecond(object source, EventArgs args)
        {
            if (Elapsed != null) // Make sure there are methods to execute.
                Elapsed(source, args);
        }
        //Raise the event.
        // The following code makes sure that method OnOneSecond is called every
        // 1,000 milliseconds.
        private System.Timers.Timer MyPrivateTimer; // Private timer
        public MyTimerClass() // Constructor
        {
            MyPrivateTimer = new System.Timers.Timer(); // Create the private timer.

            // The following statement sets our OnOneSecond method above as an event
            // handler to the Elapsed event of class Timer. It is completely
            // unrelated to our event Elapsed, declared above.
            MyPrivateTimer.Elapsed += OnOneSecond; // Attach our event handler.

            // Property Interval is of type double, and specifies the number of
            // milliseconds between when its event is raised.
            MyPrivateTimer.Interval = 100; // 1 second interval.actually value should be 1000 not 100

            // Property Enabled is of type bool, and turns the timer on and off.
            MyPrivateTimer.Enabled = true; // Start the timer.
        }
    }
    class ClassA
    {
        public void TimerHandlerA(object obj, EventArgs e) // Event handler
        {
            Console.WriteLine("Class A handler called");
        }
    }
    class ClassB
    {
        public static void TimerHandlerB(object obj, EventArgs e) // Static
        {
            Console.WriteLine("Class B handler called");
        }
    }
   class Display
    {
        public void DisplayMessage(string message)
        {
            Console.WriteLine("Message arrived: {0}", message);
        }
    }

    class eventclass2
    {
        public event eventhandler events;
        public void onevent()
        {
            if (events != null)
                events();
        }
    }
    class classa
    {
        public static void handler()
        {
            Console.WriteLine("class a called");
        }
    }
    class classb
    {
        public void handler1()
        {
            Console.WriteLine("class b called");
        }
    }
    class classc
    {
        public static void handler2()
        {
            Console.WriteLine("class c called");
        }
    }
    public class EventTester
    {
        public static void Entry()
        {
            ClassA ca = new ClassA(); // Create the class object.
            MyTimerClass m1c = new MyTimerClass(); // Create the timer object.
            m1c.Elapsed += ca.TimerHandlerA; // Add handler A -- instance.
            m1c.Elapsed += ClassB.TimerHandlerB; // Add handler B -- static.
            Thread.Sleep(10);

            eventclass2 mc = new eventclass2();
            classb b = new classb();

            mc.events += classa.handler;
            mc.events += b.handler1;
            mc.events += classc.handler2;
            mc.onevent();
        }
    }
    #endregion
   
}
