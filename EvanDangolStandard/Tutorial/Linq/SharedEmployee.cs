using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace EvanDangol.Tutorial.Linq
{
    class SharedEmployee
    {
        public int id;
        public string firstName;
        public string lastName;
        public static ArrayList GetEmployeesArrayList()
        {
            ArrayList al = new ArrayList(){
            new SharedEmployee{ id = 1, firstName = "Joe", lastName = "Rattz" },
            new SharedEmployee { id = 2, firstName = "William", lastName = "Gates" },
            new SharedEmployee { id = 3, firstName = "Anders", lastName = "Hejlsberg" },
            new SharedEmployee { id = 4, firstName = "David", lastName = "Lightman" },
            new SharedEmployee { id = 101, firstName = "Kevin", lastName = "Flynn" }};
            return (al);
        }
        public static SharedEmployee[] GetEmployesArray()
        {
            return ((SharedEmployee[])GetEmployeesArrayList().ToArray());
        }
        public static void SharedEmployeeFunction()
        {
            IEnumerable s = SharedEmployee.GetEmployeesArrayList();
            foreach (SharedEmployee vv in s)
            {
                Console.WriteLine(vv.firstName);
            }
            IEnumerable<SharedEmployee> s1 = Getemployee().Where(p => p.id == 12);
            foreach (var b in s1)
            {
                Console.WriteLine(b.lastName);
            }
        }
        public static List<SharedEmployee> Getemployee()
        {
            List<SharedEmployee> list = new List<SharedEmployee>{
                new SharedEmployee{id=12,firstName="evan",lastName="dangol"},
                new SharedEmployee{id=13,firstName="ram",lastName="sharma"}
            };
            return list;
        }
    }
    public class SharedEmployeeTester
    {
        public static void Entry()
        {
            SharedEmployee.SharedEmployeeFunction();
        }
    }
}
