using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace CANFI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            /*
            if (Environment.OSVersion.Platform == PlatformID.Win32Windows || Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                var process = Process.GetCurrentProcess();
                process.PriorityBoostEnabled = true;
                process.PriorityClass = ProcessPriorityClass.High;
            }
            */
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }
            catch (Exception e1)
            {
                MessageBox.Show("Exception: " + e1.Message+"\nInner:"+e1.InnerException.Message,"Program.cs");
            }

        }
    }
}
