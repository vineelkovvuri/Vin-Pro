using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
namespace Open
{
    struct Entry
    {
        public string Name , Path;
    }

    static class Program
    {

        static int noOfEntries;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main( string[] args )
        {
            //bool Processfound
            if ( args.Length == 0 ) {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault( false );
                Application.Run( new OpenX() );
            }
            else {
                if ( File.Exists( "openx.dat" ) ) {
                    //Reading Names and Path to structure
                    Entry[] entries = new Entry[100];
                    CreateEntries( ref entries );
                    for ( int i = 0; i < noOfEntries; i++ ) {
                        Entry e = entries[i];
                        if ( e.Name.ToLower().Trim() == args[0].ToLower().Trim() ) {
                            //System Namespaces...............
                            if ( !File.Exists( e.Path ) && !Directory.Exists( e.Path ) ) {
                                try {
                                    Process.Start( "explorer.exe" , e.Path );
                                    return;
                                }
                                catch ( Exception ) { }
                            }
                            else {
                                try {
                                    Process.Start( "rundll32.exe" , " SHELL32.DLL,ShellExec_RunDLL " + e.Path );
                                    return;
                                }
                                catch ( Exception ) { }
                            }
                        }
                    }
                    //If no directories has been opened by this tool control comes here :)
                    try {
                        Process.Start( "rundll32.exe" , " SHELL32.DLL,ShellExec_RunDLL " + args[0] );
                    }
                    catch { }
                }

            }
        }

        private static void CreateEntries( ref Entry[] e )
        {
            int i = 0;

            if ( File.Exists( "openx.dat" ) ) {

                StreamReader sr = new StreamReader( "openx.dat" );
                string s;
                while ( ( s = sr.ReadLine() ) != null ) {
                    e[i].Name = s;
                    e[i].Path = sr.ReadLine();
                    i++;
                }
                noOfEntries = i;
                sr.Close();
            }
        }
    }
}