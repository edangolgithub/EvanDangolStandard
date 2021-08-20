using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;
using System.Data.Linq;

namespace EvanDangol.Tutorial.Linq
{
    [Table]
    public class Ash
    {
        [Column(IsPrimaryKey = true)]
        public string firstname;
        [Column]
        public string lastname;
        [Column]
        public string roll;
        [Column]
        public string Class;
        public override string ToString()
        {
         return    string.Format(" name= {0,9} {1}class={2}  roll={3} ",firstname, lastname, Class.Trim(), roll.Trim());
           
        }
    }
    class ltosql
    {
        const string cnstr= @"Data Source=.\sqlexpress;AttachDBFileName=|DataDirectory|\data\ASH.mdf;Integrated Security=true;user Instance=true";
          
        public static void ltosqlmain()
        {
            DataContext db = new DataContext(cnstr);
            Table<Ash> ash = db.GetTable<Ash>(); 
            try
            {
                foreach (var students in from s in ash where s.roll=="2" orderby s.Class select s)
                    Console.WriteLine(students.ToString());
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
    public class LinqToSQLTester
    {
        public static void Entry()
        {
            ltosql.ltosqlmain();
        }
    }
}



   