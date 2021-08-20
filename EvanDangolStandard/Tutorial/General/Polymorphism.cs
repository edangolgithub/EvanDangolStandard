//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace EvanDangol.Tutorial.General
//{
//  abstract class Polymorphism
//    {
//        protected string shapeName;
//        public Polymorphism()
//        {
//            shapeName = "no name";
//        }
//        public Polymorphism(string s1)
//        {
//            shapeName = s1;
//        }
//        //a virtual method
//        public virtual void Draw()
//        {
//            Console.WriteLine("i am inside shape.draw");
//            //throw new System.NotImplementedException();
//        }
//        public string petname
//        {
//            get { return shapeName; }
//            set { shapeName = value; }
//        }
//    }
//    // circle cant over ride
//   class Circle : Polymorphism
//    {
//        public Circle() { }
//        public Circle(string name) : base(name) { }
//    }
//    // hex does over ride
//   class Hexagon : Polymorphism
//    {
//        public Hexagon() { }
//        public Hexagon(string name) : base(name) { }
//        public override void Draw()
//        {
//            Console.WriteLine("Drawing {0} the Hexagon", shapeName);
//        }
//    }
//   class Controls
//    {
//        protected int Top { get; set; }
//        protected int Left { get; set; }
//        public Controls(int top, int left)
//        {
//            this.Top = left;
//            this.Left = left;
//        }
//        public virtual void DrawWindow()
//        {
//            Console.WriteLine("Control: draw Control at {0},{1}", Top, Left);
//        }
//    }
//    class ListBox : Controls
//    {
//        private string listBoxContents;
//        public ListBox(int thetop, int theleft, string contents) :
//            base(thetop, theleft)
//        {
//            listBoxContents = contents;
//        }
//        public override void DrawWindow()
//        {
//            base.DrawWindow();
//            Console.WriteLine("writing string to the list box:{0}",
//                listBoxContents);
//        }
//    }
//    class Button : Controls
//    {
//        public Button(int top, int left) :
//            base(top, left)
//        {
//        }
//        public override void DrawWindow()
//        {
//            Console.WriteLine("drawing a button at{0},{1}\n",
//                Top, Left);
//        }
//    }
//    public class PolymorphismTester
//    {
//        public static void Entry()
//        {
//            Console.WriteLine("***** Fun with Polymorphism *****\n");
//            Hexagon hex = new Hexagon("Beth");
//            hex.Draw();
//            Circle cir = new Circle("Cindy");
//            // Calls base class implementation!
//            cir.Draw();
//            Console.ReadLine();
//            Polymorphism myshape = new Hexagon("dff");
//            myshape.Draw();
//            PolymorphismTester entry = new PolymorphismTester();
//            entry.callPolymorphism();
           
//        }
       
//        public void callPolymorphism()
//        {
//            Controls win = new Controls(1, 2);
//            ListBox lb = new ListBox(3, 4, "Stand alone list box");
//            Button b = new Button(5, 6);
//            win.DrawWindow();
//            lb.DrawWindow();
//            b.DrawWindow();
//            Controls[] winArray = new Controls[3];
//            winArray[0] = new Controls(1, 2);
//            winArray[1] = new ListBox(3, 4, "List box in array");
//            winArray[2] = new Button(5, 6);
//            for (int i = 0; i < 3; i++)
//            {
//                winArray[i].DrawWindow();
//            }
//        }
//    }
//}