using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EvanDangol.NetWorking
{
   public static class EvanNetWork
    {
        public static Stream GetHttpResponseStream(string url)
        {
           
            // First, create a WebRequest to a URI.
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            // Next, send that request and return the response.
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            // From the response, obtain an input stream.
            Stream istrm = resp.GetResponseStream();
            /* Now, read and display the html present at
               the specified URI. So you can see what is
               being displayed, the data is shown
               400 characters at a time. After each 400
               characters are displayed, you must press
               ENTER to get the next 400. */
            resp.Close();
            return istrm;
        }
    }
}
