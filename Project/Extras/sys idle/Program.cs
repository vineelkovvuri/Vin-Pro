using System;
using System.Diagnostics;
using System.Threading;
using System.Runtime.InteropServices;
namespace TestTagLib
{
    class Program
    {
        static void Main(string[] args)
        {
            PerformanceCounter pc = new PerformanceCounter("Processor", "% Idle Time","_Total",true);
            LASTINPUTINFO info = new LASTINPUTINFO();
            info.cbSize = Marshal.SizeOf(typeof(LASTINPUTINFO));
            int i = 0;
            while (i < 100)
            {
                if (GetLastInputInfo(ref info))
                {
                    Console.WriteLine((Environment.TickCount - info.dwTime)/1000 + "  " + pc.NextValue());
                }
                Thread.Sleep(1000);
                i++;
            }

        }
        [DllImport("user32.dll")]
        public static extern bool GetLastInputInfo(ref LASTINPUTINFO info);
       
    }
    struct LASTINPUTINFO
    {
        public int cbSize;
        public uint dwTime;
    }
}



