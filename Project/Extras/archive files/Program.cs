using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICSharpCode.SharpZipLib.Zip;


namespace TestTagLib
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ZipFile zf = new ZipFile(@"d:\java-pro.zip"))
            {
                foreach(ZipEntry ze in zf)
                    if(ze.IsFile)Console.WriteLine(ze.Name);
            }
        }
    }
}

