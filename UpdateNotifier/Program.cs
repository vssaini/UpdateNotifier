using System;
using System.Windows.Forms;
using UpdateNotifier.Code;

namespace UpdateNotifier
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

            // Make single instance application
            (new SingleInstanceApp()).Run(Environment.GetCommandLineArgs());
        }
    }
}
