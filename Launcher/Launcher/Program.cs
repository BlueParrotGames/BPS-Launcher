using System;
using System.Threading;
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
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Initialize phpCore
            Thread phpCoreThread = new Thread(unused => PHPCore.Initiate("http://blueparrotgames.com/Core/NetCore.php"));
            phpCoreThread.Start();


            Application.Run(new Form1());
        }
    }
}