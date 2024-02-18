using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;

namespace ExtendableDesktopSearch
{
    static class Settings
    {
        internal static bool IndexingOnAppStart = false;

        static Settings()
        {
        }
        internal static void LoadSettings()
        {
            RegistryKey rk = Registry.CurrentUser.CreateSubKey(@"software\EDS");

            //load the indexing status
            if (rk.GetValue("IndexingCompleted") != null)
                GlobalData.IndexingCompleted = (int)rk.GetValue("IndexingCompleted") == 1;

            //load the monitor status
            if (rk.GetValue("RunMonitor") != null)
                GlobalData.RunMonitor = (int)rk.GetValue("RunMonitor") == 1;

            //load the email indexer status
            if (rk.GetValue("EmailIndexer") != null)
                GlobalData.RunEmailIndexer= (int)rk.GetValue("EmailIndexer") == 1;

            rk.Close();

        }

        internal static void SaveSettings()
        {
            RegistryKey rk = Registry.CurrentUser.CreateSubKey(@"software\EDS");

            //save the indexing status
            rk.SetValue("IndexingCompleted", GlobalData.IndexingCompleted ? 1 : 0);

            //save the indexing status
            rk.SetValue("RunMonitor", GlobalData.RunMonitor ? 1 : 0);

            //load the email indexer status
            rk.SetValue("EmailIndexer", GlobalData.RunEmailIndexer ? 1 : 0);

            rk.Close();
        }
    }
}
