using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;

namespace ExtendableDesktopSearch
{
    static class Program
    {
        [DllImport("kernel32.dll")]
        static extern void AllocConsole();

        // The main entry point for the application.
        [STAThread]
        static void Main(string[] args)
        {
            // Attempt to create and take ownership of a Mutex named ExtendableDesktopSearch
            bool ownsMutex;
            using (Mutex mutex = new Mutex(true, "ExtendableDesktopSearch", out ownsMutex))
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                // If the application owns the Mutex it can continue to execute
                // otherwise, the application should exit
                if (ownsMutex)
                {
                    //Start our application
                    #region Code for starting our application
#if Log
AllocConsole();
#endif
                    if (args.Length > 0)
                    {
                        GlobalData.args = args[0].Substring(args[0].IndexOf(":") + 1);
                    }

                    Application.Run(new MainForm());
                    #endregion
                    // Release the mutex
                    mutex.ReleaseMutex();
                }
                else //Another instance of this application is running
                {
                    //so restore the already running window to the user
                    IntPtr hwnd = Win32Helper.FindWindow(null, "Extendable Desktop Search");
                    Win32Helper.ShowWindow(hwnd, 9);  //9 => SW_RESTORE
                }
            }
        }
    }
}