using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvanDangol.Tutorial.General
{
    
       public class Circles
        {
            private int x, y;
            private double radius;
            public Circles()
            {
            }
            public Circles(int xValue, int yValue, double radiusValue)
            {
                X = xValue;
                Y = yValue;
                Radius = radiusValue;
            }
            public int X
            {
                get
                {
                    return x;
                }
                set
                {
                    x = value;
                }
            }
            public int Y
            {
                get
                {
                    return y;
                }
                set
                {
                    y = value;
                }
            }
            public double Radius
            {
                get
                {
                    return radius;
                }
                set
                {
                    if (value >= 0)
                        radius = value;
                }
            }
            public double Diameter()
            {
                return radius * 2;
            }
            public double cicumference()
            {
                return Math.PI * (radius + radius);
            }
            public double Area()
            {
                return Math.PI * (radius * radius);
                //return Math.PI*Math.Pow(radius,2);
            }
            public override string ToString()
            {
                return "Area= " + Area() + " circumference= " + cicumference() + " diameter= " + Diameter();
            }
        }
       public class People
        {
            public virtual string Name { get; set; }
            public string Email { get; set; }
            public string Address { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public string Zip { get; set; }
            protected string FullAddress()
            {
                return Name + Environment.NewLine + Address + '\n' + City + Environment.NewLine + State + Environment.NewLine + Zip;
            }

        }
        class Customers : People
        {
            public override string Name
            {
                get
                {
                    return base.Name;
                }
                set
                {
                    base.Name = value;
                }

            }

            public string Gender { get; set; }
            public decimal Income { get; set; }
            public string GenerateReport()
            {

                string fullAddress = FullAddress();
                return fullAddress;
            }
        }
       public partial class Student : People
        {
            public override string Name
            {
                get
                {
                    return base.Name;
                }
                set
                {
                    base.Name = value;
                }

            }
            public string GenerateReport()
            {
                string a = FullAddress();
                return Name;
            }

        }
       //public static void PeopleEntry()
       //     {
       //         Customers cust = new Customers();
       //         cust.Name = "evan dangol";
       //         cust.Address = "khusibu";
       //         cust.City = "Kathmandu";
       //         cust.Email = "dangolevan@hotmail.com";
       //         cust.Income = 10000;
       //         cust.State = "Nepal";
       //         cust.Zip = "q23 3df";
       //         ConsoleApplication.WriteLine(cust.GenerateReport());
       //         student stu = new student();
       //         stu.GenerateReport();
       //         ConsoleApplication.WriteLine(stu.GenerateReport());
       //     }
              
        class Employee
        {

            // Field data.

            private string empName;
            private int empID;
            private float currPay;
            private int empAge;
            private string empSSN;
            private static string companyName;



            public string SocialSecurityNumber
            {
                get { return empSSN; }
                set { empSSN = value; }
            }
            public int Age
            {
                get { return empAge; }
                set { empAge = value; }
            }
            public string Name
            {
                get { return empName; }
                set { empName = value; }
            }
            public int ID
            {
                get { return empID; }
                set { empID = value; }
            }
            public float pay
            {
                get { return currPay; }
                set { currPay = value; }
            }


            public Employee() { }

            public Employee(string name, int age, int id, float pay, string ssn)
            {
                empName = name;
                empID = id;
                empAge = age;
                currPay = pay;
                empSSN = ssn;
            }


            public void GiveBonus(float amount)
            {
                currPay += amount;
            }
            public void displaystat()
            {

                companyName = "Evan Company";
                Console.WriteLine("Company Name: {0}", companyName);
                Console.WriteLine("Name: {0}", empName);
                Console.WriteLine("ID: {0}", empID);
                Console.WriteLine("Pay: {0}", currPay);
                Console.WriteLine("Age: {0}", empAge);
                Console.WriteLine("SSN: {0}", empSSN);


            }
    
        }
        class Manager : Employee
        {
            private int numbersofoptions;

            public int stockoptions
            {
                get
                {
                    return numbersofoptions;
                }
                set
                {
                    numbersofoptions = value;
                }
            }
        }
        class SalesPerson : Employee
        {
            private int numberOfSales;
            public int SalesNumber
            {
                get { return numberOfSales; }
                set { numberOfSales = value; }
            }

            public SalesPerson() { }
            public SalesPerson(string fullName, int ag, int empID, float Pay, string ssn, int numbOfSales)
                : base(fullName, ag, empID, Pay, ssn)
            {
                numberOfSales = SalesNumber;
            }


        }
        class EmployeeTester
        {
            public static void EmployeeEntry()
            {
            lo:
                try
                {

                    Console.WriteLine("***** The Employee Class Hierarchy *****\n");
                    SalesPerson danny = new SalesPerson();
                    Console.WriteLine("Enter the name of the person");
                    danny.Name = "Evan Dangol";
                    Console.WriteLine("enter the age ");
                    danny.Age = 31;
                    Console.WriteLine("Enter number of sales");
                    danny.SalesNumber = 10000;
                    Console.WriteLine("Enter the pay amount");
                    danny.pay = 32000;
                    Console.WriteLine("Enter ID");
                    danny.ID = 1;
                    Console.WriteLine("Enter the Social security number");
                    danny.SocialSecurityNumber = "aqwerty";
                    Console.WriteLine("Here is the detail of the sales person");
                    danny.GiveBonus(45.76f);
                    danny.displaystat();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message + "\nage,sales ,id, social security numbers, pay all must be in number you stupid");
                    Console.ReadLine();
                    goto lo;
                }
            }
        }

                 
  
    public class InheritanceTester
    {
        public static void Entry()
        {
            Circles circle = new Circles(10, 5, 12);
            Console.WriteLine(" Arguments given :Circle with X=10,Y=5 and Radius=15");
            Console.WriteLine("To the constructor of Circle class as : Inheritance.Circle(10, 5, 12)");
            Console.WriteLine("Result is :");
            Console.WriteLine(circle.ToString());
            //Inheritance.PeopleEntry();
            //Inheritance.EmployeeEntry();
        }
    }
}
