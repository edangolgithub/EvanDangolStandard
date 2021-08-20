using EvanDangol.Reflection;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvanDangol.Tutorial.Collection
{
  public  class StudentIList
    {
        [runnable]
        public static void Run()
        {
            StudentYeidEnumerator sr = new StudentYeidEnumerator();
            foreach (var item in sr)
            {
                Console.WriteLine(item)
;
            }
        }
    }

    class StudentICollection : ICollection
    {
        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        public int Count
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsSynchronized
        {
            get { throw new NotImplementedException(); }
        }

        public object SyncRoot
        {
            get { throw new NotImplementedException(); }
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    class StudentYeidEnumerator : IEnumerable
    {
        Student[] sarray;
        public StudentYeidEnumerator()
        {
             sarray = new Student[]{ new Student() { Name = "ram", RollNumber = 1 },
            new Student() { Name = "shyam", RollNumber = 2 },
            new Student() { Name = "hari", RollNumber = 3 },
            new Student() { Name = "rita", RollNumber = 4 },
             new Student() { Name = "sita", RollNumber = 5 },
            new Student() { Name = "gita", RollNumber = 6 }
            };
           
        }
        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i <sarray.Length ; i++)
            {
                yield return sarray[i];
            }
        }
    }

    


}
