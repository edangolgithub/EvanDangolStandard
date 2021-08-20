using EvanDangol.Reflection;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvanDangol.Tutorial.Collection
{
    class Student
    {
        public int RollNumber { get; set; }
        public String Name { get; set; }

        public override string ToString()
        {
            return Name + " " + RollNumber;
        }
    }
    class StudentEnumerable : IEnumerable
    {
        public Student[] sarray { get; set; }
        public StudentEnumerable()
        {

        }
        public StudentEnumerable(Student[] sarray)
        {
            this.sarray = sarray;
        }
        public IEnumerator GetEnumerator()
        {
            return new StudentEnumerator(sarray);
        }
    }

    class StudentEnumerator : IEnumerator
    {
        Student[] studentarray;
        int index = -1;
        public StudentEnumerator(Student[] sarray)
        {
            studentarray = sarray;
        }
        public object Current
        {
            get { return studentarray[index]; }
        }

        public bool MoveNext()
        {

            index++;
            if (index < studentarray.Length)
            {
                return true;
            }
            return false;
        }

        public void Reset()
        {
            index = -1;
        }
    }
    public class Ienumerable
    {
        [runnable]
        public static void Run()
        {
            
            Student a = new Student() { Name = "ram", RollNumber = 1 };
            Student b = new Student() { Name = "shyam", RollNumber = 2 };
            Student c = new Student() { Name = "hari", RollNumber = 3 };
            Student d = new Student() { Name = "rita", RollNumber = 4 };
            Student e = new Student() { Name = "sita", RollNumber = 5 };
            Student f = new Student() { Name = "gita", RollNumber = 6 };
            StudentEnumerable s = new StudentEnumerable();

            s.sarray = new Student[6];
            s.sarray[0] = a;
            s.sarray[1] = b;
            s.sarray[2] = c;
            s.sarray[3] = d;
            s.sarray[4] = e;
            s.sarray[5] = f;
            foreach (Student item in s)
            {
                Console.WriteLine(item.Name);
            }
        }
    }


    // Simple business object.
    public class Person
    {
        public Person(string fName, string lName)
        {
            this.firstName = fName;
            this.lastName = lName;
        }

        public string firstName;
        public string lastName;
    }

    // Collection of Person objects. This class
    // implements IEnumerable so that it can be used
    // with ForEach syntax.
    public class People : IEnumerable
    {
        private Person[] _people;
        public People(Person[] pArray)
        {
            _people = new Person[pArray.Length];

            for (int i = 0; i < pArray.Length; i++)
            {
                _people[i] = pArray[i];
            }
        }

        // Implementation for the GetEnumerator method.
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        public PeopleEnum GetEnumerator()
        {
            return new PeopleEnum(_people);
        }
    }

    // When you implement IEnumerable, you must also implement IEnumerator.
    public class PeopleEnum : IEnumerator
    {
        public Person[] _people;

        // Enumerators are positioned before the first element
        // until the first MoveNext() call.
        int position = -1;

        public PeopleEnum(Person[] list)
        {
            _people = list;
        }

        public bool MoveNext()
        {
            position++;
            return (position < _people.Length);
        }

        public void Reset()
        {
            position = -1;
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public Person Current
        {
            get
            {
                try
                {
                    return _people[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }

    class App
    {
        static void Main()
        {
            Person[] peopleArray = new Person[3]
        {
            new Person("John", "Smith"),
            new Person("Jim", "Johnson"),
            new Person("Sue", "Rabon"),
        };

            People peopleList = new People(peopleArray);
            foreach (Person p in peopleList)
                Console.WriteLine(p.firstName + " " + p.lastName);

        }
    }

    /* This code produces output similar to the following:
     *
     * John Smith
     * Jim Johnson
     * Sue Rabon
     *
     */

}
