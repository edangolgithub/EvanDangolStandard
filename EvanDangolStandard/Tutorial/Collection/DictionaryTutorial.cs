using EvanDangol.Reflection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EvanDangol.Tutorial.Collection
{
    public class PangramChecker
    {

        private static int NO_OF_LETTERS_OF_ALPHABET = 26;




        public static bool isPangram(String sentence)
        {

            if (sentence.Length < NO_OF_LETTERS_OF_ALPHABET)
            {
                return false;
            }

            for (char ch = 'A'; ch <= 'Z'; ch++)
            {
                if (sentence.IndexOf(ch) < 0 && sentence.IndexOf((char)(ch + 32)) < 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
    public class DictionaryTutorial
    {
        [runnable]
        public static void Run()
        {
            Console.WriteLine(CheckPanagram("freIght to me sixty dozen quart jars and twelve black pans."));
            Console.WriteLine(CheckPanagram("The quick brown fox jumps over the lazy dog"));
        }

        public static bool CheckPanagram(string s)
        {
            s = s.ToLower();
            for (char i = 'a'; i <= 'z'; i++)
            {
                foreach (var item in s.ToCharArray())
                {
                    if(!s.Contains(i))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
        public static void translate(string s)
        {
            List<char> ch = new List<char>();
            for (int i = 0; i < s.Length; i++)
            {
                switch (s[i])
                {
                    case 'a':
                    case 'e':
                    case 'i':
                    case 'o':
                    case 'u':

                        ch.Add(s[i]);
                        break;
                    case ' ':
                        ch.Add(' ');
                        break;
                    default:
                        ch.Add(s[i]);
                        ch.Add('o');
                        ch.Add(s[i]);
                        break;

                }
            }
            string ss = new string(ch.ToArray());
            Console.WriteLine(ss);
        }



        public static string[] ss()
        {
            string s = "audino bagon baltoy banette bidoof braviary bronzor carracosta charmeleon " +
 "cresselia croagunk darmanitan deino emboar emolga exeggcute gabite " +
 "girafarig gulpin haxorus heatmor heatran ivysaur jellicent jumpluff kangaskhan " +
 "kricketune landorus ledyba loudred lumineon lunatone machamp magnezone mamoswine " +
 "nosepass petilil pidgeotto pikachu pinsir poliwrath poochyena porygon2 " +
 "porygonz registeel relicanth remoraid rufflet sableye scolipede scrafty seaking " +
 "sealeo silcoon simisear snivy snorlax spoink starly tirtouga trapinch treecko " +
 "tyrogue vigoroth vulpix wailord wartortle whismur wingull yamask";
            return s.Split(' ');
        }
        public static bool isAnagram(String s, String t)
        {
            if (s.Length != t.Length)
                return false;

            for (int i = 0; i < t.Length; i++)
            {
                var n = s.IndexOf(t[i]);
                if (n < 0)
                    return false;
                s = s.Remove(n, 1);
            }
            return String.IsNullOrEmpty(s);
        }

        public static void hgf()
        {
            WebClient client = new WebClient();
            string downloadString = client.DownloadString(@"http://www.puzzlers.org/pub/wordlists/unixdict.txt");
            StreamWriter sw = new StreamWriter("a.txt");
            string s = downloadString.Replace('\n', ' ');
            sw.Write(s);
            sw.Close();
        }
    }
    public class Dictionarycol
    {
        Dictionary<string, string> myCol = new Dictionary<string, string>();
        public Dictionarycol()
        {
            myCol.Add("red", "rojo");
            myCol.Add("green", "verde");
            myCol.Add("blue", "azul");
        }
        public void display()
        {


            foreach (var item in myCol)
            {
                Console.WriteLine(item.Key);
            }

        }
        public void displayvalue(string s)
        {

            if (myCol.ContainsKey(s))
            {
                Console.WriteLine(myCol[s]);
            }

        }
    }
}
