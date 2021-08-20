using EvanDangol.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvanDangol.Tutorial.Collection
{
    public class StudentComparable
    {
        [runnable]
        public static void Run()
        {
            StudentDerived a = new StudentDerived() { Name = "ram", RollNumber = 1 };
            StudentDerived b = new StudentDerived() { Name = "shyam", RollNumber = 7 };
            StudentDerived c = new StudentDerived() { Name = "hari", RollNumber = 3 };
            StudentDerived d = new StudentDerived() { Name = "rita", RollNumber = 2};
            StudentDerived e = new StudentDerived() { Name = "sita", RollNumber = 5 };
            StudentDerived f = new StudentDerived() { Name = "gita", RollNumber = 6 };
            StudentEnumerable s = new StudentEnumerable();
            List<StudentDerived> st = new List<StudentDerived>();
            st.Add(a); st.Add(b); st.Add(c); st.Add(d); st.Add(e); st.Add(f);
            st.Sort();
            st.Sort(new StudentRollComparer());
            foreach (var item in st)
            {
                Console.WriteLine(item);
            }
        }
    }
    class StudentDerived : Student, IComparable
    {
        public int CompareTo(object obj)
        {
            Student s = obj as Student;
            return this.Name.CompareTo(s.Name);
        }
        public override string ToString()
        {
            return this.Name + " " + RollNumber;
        }
    }

    class StudentRollComparer : IComparer<StudentDerived>
    {
        public int Compare(StudentDerived x, StudentDerived y)
        {
            if(x.RollNumber>y.RollNumber)
            {
                return 1;
            }
            else if(x.RollNumber<y.RollNumber)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }

}
