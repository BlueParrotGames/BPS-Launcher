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

            PHPCore.Initiate("http://localhost/Core/NetCore.php");
            PHPCore.Write("action=Login&username=test1&password=test1");

            Application.Run(new Form1());
        }
    }
}