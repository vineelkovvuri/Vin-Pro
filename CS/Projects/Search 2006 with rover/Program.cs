using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Search_2006
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static string [] args;
        [STAThread]
        static void Main( String [] args )
        {
            Program.args = args;
            if ( Environment.Version.Major < 2 )
            {
                MessageBox.Show( "Please Install .NET 2.0 and then run this program","From Search 2006" );
                Environment.Exit( 1 );
            }

            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault( false );
                Application.Run( new Form1() );
            }
            catch ( Exception e )
            {
                MessageBox.Show( e.Message + "   " + e.StackTrace );
            }
        }
    }
}