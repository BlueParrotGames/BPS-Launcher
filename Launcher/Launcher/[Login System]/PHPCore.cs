using System;
using System.Text;
using System.IO;
using System.Net;

namespace BPS.Launcher.Networking
{
    public static class PHPCore
    {
        private static HttpWebRequest req;
        private static Stream reqStream;
        private static HttpWebResponse response;
        private static StreamReader reader;

        public static void Initiate(string url)
        {
            try
            {
                req = (HttpWebRequest)WebRequest.Create(url);
                req.Method = "POST";
                req.ContentType = "application/x-www-form-urlencoded";
                
                response = (HttpWebResponse)req.GetResponse();
                reader = new StreamReader(response.GetResponseStream());

                Console.WriteLine(reader.ReadToEnd());

                reader.Close();
            }
            catch (WebException)
            {
                Console.WriteLine("Please check your internet, or tell a programmer");
            }
        }

        public static void Write(string message)
        {
            req.CookieContainer = new CookieContainer();
            req.CookieContainer.Add(response.Cookies);

            byte[] postBytes = Encoding.ASCII.GetBytes(message);

            req.ContentLength = postBytes.Length;

            reqStream = req.GetRequestStream();
            reqStream.Write(postBytes, 0, postBytes.Length);
            reqStream.Close();

            Console.WriteLine(reader.ReadToEnd());
        }
    }
}
