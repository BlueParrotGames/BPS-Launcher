using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace BPS.Launcher.Networking
{
    public class PHPClient
    {
        public static void Login(string url, string username, string password)
        {
            try
            {
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                req.Method = "POST";
                string param = "username=" + username + "&password=" + password;
                byte[] postBytes = Encoding.ASCII.GetBytes(param);

                req.ContentType = "application/x-www-form-urlencoded";
                req.ContentLength = postBytes.Length;

                Stream reqStream = req.GetRequestStream();
                reqStream.Write(postBytes, 0, postBytes.Length);
                reqStream.Close();

                HttpWebResponse response = (HttpWebResponse)req.GetResponse();
                Stream resStream = response.GetResponseStream();

                StreamReader sr = new StreamReader(response.GetResponseStream());
                string responseMSG = sr.ReadToEnd();

                Console.WriteLine(responseMSG);
            }
            catch (WebException)
            {
                Console.WriteLine("Please check your internet, or tell a programmer");
            }
        }

        public static void CloseConnection(string url)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);

            HttpWebResponse response = (HttpWebResponse)req.GetResponse();
            Stream resStream = response.GetResponseStream();
            StreamReader sr = new StreamReader(response.GetResponseStream());

            string responseMSG = sr.ReadToEnd();
            Console.WriteLine(responseMSG);
        }
    }
}