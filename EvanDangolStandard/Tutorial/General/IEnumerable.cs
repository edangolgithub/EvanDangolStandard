using System.Collections;
using System;
namespace EvanDangol.Tutorial.General
{
    #region old
    class enumarator : IEnumerator
    {
        string[] Colors;
        int Position = -1;
        public enumarator(string[] theColors)
        {
            Colors = new string[theColors.Length];
            for (int i = 0; i < Colors.Length; i++)
                Colors[i] = theColors[i];
        }
        public object Current
        {
            get { return Colors[Position]; }
        }
        public bool MoveNext()
        {
            if (Position < Colors.Length - 1)
            {
                Position++;
                return true;
            }
            else
                return false;
        }
        public void Reset()
        {
            Position = -1;
        }
    }
        class enumeratortester :IEnumerable 
        {
            static string[] colors = { "Red", "Blue", "Green" };
            public IEnumerator GetEnumerator()
            {
                return colors.GetEnumerator();
            }
            public static void tester()
            {
                enumeratortester enumtest = new enumeratortester();
                foreach (string color in enumtest)
                    Console.WriteLine(color);
            }

            
        }
        class nonenumerator
        {
            public  string name ;
            public nonenumerator(string Name)
            {
                name = Name;
            }
        }
      class intenumarator
        {
            static string[] stringarray = { "jdskfhj", "jhfsg", "hdfghjsg" };
            static int[] intarray = { 12, 24, 234, 13, 2154, 1, 8 };
            static nonenumerator[] nonarray = {new nonenumerator("hello"),new nonenumerator ("svsgh"),new nonenumerator("bhf")};
            public static void tester()
            {
                foreach (int item in intarray)
                    Console.WriteLine(item);
                foreach (string sitem in stringarray)
                    Console.WriteLine(sitem);
                foreach (nonenumerator n in nonarray)
                    Console.WriteLine(n.name);
            }
        }
      public class IEnumerableTester
      {
          public static void Entry()
          {
              enumeratortester.tester();
              intenumarator.tester();
          }
      }
#endregion

#region StudentEnumaration
      public partial class Student
      {
          public Student(string fName, string lName)
          {
              this.firstName = fName;
              this.lastName = lName;
          }

          public string firstName;
          public string lastName;
      }
    public class StudentCollection:IEnumerable
    {
        Student[] studentarray = new Student[3]
        {
            new Student("John", "Smith"),
            new Student("Jim", "Johnson"),
            new Student("Sue", "Rabon"),
        };

        public void tryf()
        {
           
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new StudentsEnumarator(studentarray);
        }
    }
    public class StudentsEnumarator : IEnumerator
    {
        public StudentsEnumarator(Student[] students)
        {
            this.students = students;
        }
        public Student[] students;
        public int Curposition = -1;
        public object Current
        {
            get { return students[Curposition]; }
        }

        public bool MoveNext()
        {
            Curposition++;
            if(Curposition<this.students.Length)
            {
                return true;
            }
            return false;
        }

        public void Reset()
        {
            Curposition = -1;
        }
    }
    public class StudentEnumarationTester
    {
        public static void tryf()
    {
        foreach (Student item in new  StudentCollection())
        {
            Console.WriteLine(item.firstName);
        }
    }
    }
#endregion
       
    
}
    