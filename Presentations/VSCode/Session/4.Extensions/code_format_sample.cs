using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;

namespace ExtendableDesktopSearch
{
    static class Program
    {
        static void Main(string[] args)
        {
        //Start our application
        #region Code for starting our application

        if (args.Length > 0)
        {
            GlobalData.args = args[0].Substring(args[0].IndexOf(":") + 1);
        }

        }
    }
}