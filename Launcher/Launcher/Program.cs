using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BPS.Launcher.Networking;

namespace Launcher
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            PHPClient.Login("http://localhost/ext_connect_sql/requestlogin.php", "test1", "test1");

            Application.Run(new Form1());

            PHPClient.CloseConnection("http://localhost/ext_connect_sql/closeconnection.php");
        }
    }
}