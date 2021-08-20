using System;
using System.Linq;
using System.Text;
using System.Threading;

using System.Drawing;
using System.ComponentModel;
using System.Reflection;
using System.IO;
using System.Diagnostics;

namespace EvanDangol.Core
{
    public delegate void CallMe(string text);

    public enum EvanDataProvider { SqlExpress,SqlServer,SqlClient, OleDb,Access12, Odbc, SqlServerCe,MySql, None }
     
    public enum EvanMonth : byte { January = 1, February, March, April, May, June, July, August, September, October, November, December };
   #pragma warning disable 168



    [Serializable]
    public class EvanException : Exception
    {
        public EvanException() { }
        public EvanException(string message) : base(message) { }
        public EvanException(string message, Exception inner) : base(message, inner) { }
        protected EvanException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }

  
    #region MouseMove
    //public static class LocationMove
    //{
    //    public static void Randomize(this Control c)
    //    {
    //        Random random = new Random();
    //        int p = random.Next(0, c.Parent.ClientRectangle.Width);
    //        int p1 = random.Next(0, c.Parent.ClientRectangle.Height);
    //        c.Location = new Point(p, p1);
    //    }
    //}
    #endregion
}