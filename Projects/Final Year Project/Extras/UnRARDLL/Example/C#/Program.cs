using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Enumerates the files present in a give rar file

namespace TestUnrar
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Schematrix.Unrar ur = new Schematrix.Unrar(@"d:\Java-pro.rar");
                ur.Open();
                foreach(string s in ur.ListFiles())
                    Console.WriteLine(s);
                ur.Close();
                
            }
            catch(Exception e) { Console.WriteLine(e); }
        }
    }
}


