using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace BPS.Launcher.Networking.LoginSystem
{
    public class LoginManager
    {
        /// <summary>
        /// Attempt to login with the given credentials to the given server
        /// </summary>
        /// <param name="url">The url to the php server that will handle your login request</param>
        /// <param name="email">The E-mail of the account you want to login with</param>
        /// <param name="password">The password of the account you want to login with</param>
        public static string Login(string url, string email, string password)
        {
            try
            {
                //Create the request
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";

                //Prepare and encode the command
                string args = "username=" + email + "&password=" + password;
                byte[] postBytes = Encoding.ASCII.GetBytes(args);

                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = postBytes.Length;

                //Write the request to the stream
                using (Stream requestStream = request.GetRequestStream())
                    requestStream.Write(postBytes, 0, postBytes.Length);

                //Get the response
                return GetResponse(request);
            }
            catch
            {
                MessageBox.Show("Connection to the login server failed. Please check you internet connection, or contact us", "Connection Error");

                return "null";
            }
        }
        /// <summary>
        /// Attempt to login with the given credentails to the default login server (BlueParrotGames.com)
        /// </summary>
        /// <param name="email">The E-mail of the account you want to login with</param>
        /// <param name="password">The password of the account you want to login with</param>
        /// <returns></returns>
        public static string Login(string email, string password)
        {
            return Login("http://blueparrotgames.com/ext_connect_sql/requestlogin.php", email, password);
        }

        /// <summary>
        /// Close the connection to the default server (BlueParrotGames.com)
        /// </summary>
        /// <returns>test</returns>
        public static string CloseConnection()
        {
            return CloseConnection("http://blueparrotgames.com/ext_connect_sql/closeconnection.php");
        }
        /// <summary>
        /// Close connection with the given server
        /// </summary>
        /// <param name="url">The url of the php server</param>
        /// <returns></returns>
        public static string CloseConnection(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            return GetResponse(request);
        }

        /// <summary>
        /// Get the response from the request
        /// </summary>
        /// <param name="request"> test </param>
        /// <returns></returns>
        private static string GetResponse(HttpWebRequest request)
        {
            //Get and stream the HttpWebResponse, after that return the response
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
