using System;
namespace EvanDangol.Tutorial.General
{
    #region Myeventhandler
    delegate void MyeventHandler(object sender, EventArgs e);//declare delegate 
    class Myevent: EventArgs 
    {
        public event MyeventHandler SomeEvent;//see defeinition of 
                                               // "event"by right clicking
        // this will fire the event
        public void OnSomeEvent()
        {
            Myevent evt= new Myevent();
           if (SomeEvent != null)//make sure there is some method to execute
                SomeEvent( this ,evt);
        }
    }
    class MyeventDemo
    {
        public static void Handler(object sender,EventArgs e)// this is event handler
        {
            Console.WriteLine("Event occurred Sender is: "+sender );
        }
        public static void runMyEventDemoandMyEvent()
        {
            Myevent evnt = new Myevent();
           evnt.SomeEvent += Handler;//Adding Handler() to the event list
            evnt.OnSomeEvent();//Firing the event
        }
    }
    #endregion
    #region event
    class MyEventArgs : EventArgs
    {
        public string Mystock { get; set; }
        public int Mychange { get; set; }
        public MyEventArgs(string stock, int change)
        {
            Mystock = stock;
            Mychange = change;
        }
    }
    class Sender
    {
        public delegate void EventHandler(object sender, MyEventArgs e);
        public event EventHandler OnChange;
        public void Update(string stock, int change)
        {
            MyEventArgs e = new MyEventArgs(stock, change);
            if (OnChange != null)
                OnChange(this, e);
        }
    }
    class Receiver
    {
        public Receiver(Sender s)
        {
            s.OnChange += new Sender.EventHandler(s_OnChange);

        }

        void s_OnChange(object sender, MyEventArgs e)
        {
            string UPorDown;
            if (e.Mychange > 0)
                UPorDown = "down";
            else
                UPorDown = "up";
            int ch = Math.Abs(e.Mychange);
            Console.WriteLine("{0} {1} by {2}", e.Mystock, UPorDown, ch);
        }
    }   

    #endregion
    #region KeyEvent
    class KeyEventArgs : EventArgs
    {
        public char k;
    }
    delegate void keyHandler(object sender, KeyEventArgs e);

    class keysenders
    {
        public event keyHandler keypress;
        public void onkeypress(char key)
        {
            KeyEventArgs m = new KeyEventArgs();
            if (keypress != null)
            {
                m.k = key;
                keypress(this, m);
            }
        }
    }
    class keyreceiver
    {
        KeyEventArgs kk = new KeyEventArgs();
        public void kkk(object sender, KeyEventArgs e)
        {
            Console.WriteLine("you pressed {0}", Convert.ToChar(e.k + Convert.ToChar(1)));
        }
    }
    class keytesterEntry
    {
        public static void keyentry()
        {
            keyreceiver r = new keyreceiver();
            keysenders ss = new keysenders();
            ss.keypress += r.kkk;
            // Console.WriteLine(Convert.ToChar(65));
            ConsoleKeyInfo k;
            do
            {
                k = Console.ReadKey();
                ss.onkeypress(k.KeyChar);
            } while (k.KeyChar != 'q');
        }
    }
#endregion
    #region evennumberevent
    public delegate void EvenNumberHandler(int Number);
    class Counter
    {
        public event EvenNumberHandler EvenNumber;
        public Counter()
        {
            EvenNumber = null;
        }
        public void CountTo100()
        {
            int CurrentNumber;
            for (CurrentNumber = 0; CurrentNumber <= 10; CurrentNumber++)
            {
                if (CurrentNumber % 2 == 0)
                {
                    if (EvenNumber != null)
                    {
                        EvenNumber(CurrentNumber);
                    }
                }
            }
        }
    }
    class EvenNumberHandlerClass
    {
        public void EvenNumberFound(int EvenNumber)
        {
            Console.WriteLine(EvenNumber);
        }
    }
    class EvenNumberTester
    {
        public static void EvenNumberTesterEntry()
        {
            EvenNumberHandlerClass ehc = new EvenNumberHandlerClass();
            Counter counter = new Counter();
            counter.EvenNumber += new EvenNumberHandler(ehc.EvenNumberFound);
            counter.CountTo100();
        }


    }
    #endregion
    # region evanevent
    delegate void EvanEventHandler(object sender, EvanEventArgs Ee);
    class EvanEventArgs : EventArgs
    {
        int i;
        public EvanEventArgs(int i)
        {
            this.i = i;
        }
        public int I
        {
            get
            {
                return i;
            }
        }
    }
    class EventSender
    {
        public event EvanEventHandler evanEvent;
        public void OnevanEvent(int i)
        {

            EvanEventArgs Ae = new EvanEventArgs(i);
            if (evanEvent != null)
            {
                evanEvent(this, Ae);
            }
        }
        public override string ToString()
        {
            return "EventSender";
        }
    }
    class EventReceiver
    {
        int count;
        public void EventCount(object sender, EvanEventArgs Ae)
        {
            while (Ae.I != count)
            {
                count++;

                Console.WriteLine("sender : {0} has called this Function {1} Times", sender, count);

            }
        }
    }
    class EvanEventTester
    {
        public static void EvanEventEntry()
        {

            EventSender se = new EventSender();
            EventReceiver rs = new EventReceiver();
            se.evanEvent += rs.EventCount;
            se.OnevanEvent(32);
        }
    }

    #endregion
    #region TimeEvent
    public class TimeInfoEventArgs : EventArgs
    {
        public TimeInfoEventArgs(int hour, int minute, int second)
        {
            this.hour = hour;
            this.minute = minute;
            this.second = second;
        }
        public readonly int hour;
        public readonly int minute;
        public readonly int second;
    }
    public class Clock
    {
        public delegate void SecondChangeHandler(object clock, TimeInfoEventArgs timeInformation);
        public SecondChangeHandler onSecondChange;
        public void Run()
        {
            for (; ; )
            {
                System.Threading.Thread.Sleep(10);
                DateTime dt = System.DateTime.Now;
                if (dt.Second != second)
                {
                    TimeInfoEventArgs timeinformation =
                        new TimeInfoEventArgs(dt.Hour, dt.Minute, dt.Second);
                    if (onSecondChange != null)
                    {
                        onSecondChange(this, timeinformation);
                    }
                }
                this.second = dt.Second;
                this.minute = dt.Minute;
                this.hour = dt.Hour;
            }
        }
        private int hour;
        private int minute;
        private int second;
    }
    public class DisplayClock
    {
        public void Subscribe(Clock theclock)
        {
         
            theclock.onSecondChange += new Clock.SecondChangeHandler(TimeHasChanged);
        }
        public void TimeHasChanged(object theclock, TimeInfoEventArgs ti)
        {
            Console.WriteLine("Current Time:{0}:{1}:{2}",
                ti.hour.ToString(),
                ti.minute.ToString(),
                ti.second.ToString());
        }
    }
     class TimeEventTester
    {
        public static void TimeEventTesterEntry()
        {
            Clock theclock = new Clock();
            DisplayClock dc = new DisplayClock();
            dc.Subscribe(theclock);
            theclock.Run();
        }
    }
    #endregion

     public class FiveSecondEventArgs : EventArgs
     {
         public DateTime date { get; set; }
     }
     public class FiveSecondPublisher
     {
         public delegate void SecondChangeHandler(object clock, FiveSecondEventArgs timeInformation);
         public event SecondChangeHandler onFiveSecond;
         public DateTime dt1 { get; set; }
         public FiveSecondPublisher()
         {
             dt1 = DateTime.Now.AddSeconds(5);
         }
         public void Run()
         {
             for (; ; )
             {

                 DateTime dt = System.DateTime.Now;
                 if (dt.Second == dt1.Second)
                 {
                     FiveSecondEventArgs timeinformation = new FiveSecondEventArgs();
                     timeinformation.date = dt;
                     if (onFiveSecond != null)
                     {
                         onFiveSecond(this, timeinformation);
                         dt1 = dt.AddSeconds(5);
                     }
                 }
                 //this.second = dt.Second;

             }
         }

         public void c_onSecondChange(object clock, FiveSecondEventArgs timeInformation)
         {
             Console.WriteLine(timeInformation.date.ToLocalTime());
         }
     }



  public  class EventHandlerTester
    {
        public static void EventTesterEntry()
        {
            Sender s = new Sender();
            Receiver r = new Receiver(s);
            Console.WriteLine("2010 Sales Rate:");
            s.Update("\tC# Books:", -20);
            s.Update("\tC++ Books:", 11);
            s.Update("\tVB .NET Books:", -15);
            s.Update("\tScience Fiction Books:", 120);
            EvenNumberTester.EvenNumberTesterEntry();
            EvanEventTester.EvanEventEntry();
            //TimeEventTester.TimeEventTesterEntry();
        }
    }

  
}
