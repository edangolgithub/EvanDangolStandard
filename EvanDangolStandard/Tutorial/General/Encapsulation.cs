using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvanDangol.Tutorial.General
{
    class Encapsulation
    {

        public int Rating { get; set; }
        public static void norun()
        {

        }

    }
    class Enc
    {
        public static void not()
        {
            Encapsulation en = new Encapsulation();
            en.Rating = 20;
            Console.WriteLine(en.Rating);
            WebSite site =new WebSite();
            site[0]="hotmail.com";
            string link= site[0];
           WebSite site2 = site;
           bool isSameObject = object.ReferenceEquals(site, site2);
           site.beta = 30;
           site2.beta =40;
            bool isitequeal=site.Equals(site2);
            Console.WriteLine("{0}\t{1}",isSameObject,isitequeal);
            string s1 = site.ToString();
            Console.WriteLine(s1.ToString());
        }
    }
    class WebSite
    {
        public int beta =0;
        public WebSite BetaSite { get; set; }
        const int minsize = 10;
        const int maxsize = 10;
        string[] mlinks = new string[maxsize];
        public string this[int i]
        {
            get
            {
                if (i >= minsize && i < maxsize)
                {
                    return mlinks[i];
                }
                return null;
            }
            set
            {
                if (i >= minsize && i < maxsize)
                {
                    mlinks[i] = value;
                }
            }
        }
    }
    public class EncapsulationTester
    {
        public static void Entry()
        {
            Enc.not();
        }
    }

    
}
