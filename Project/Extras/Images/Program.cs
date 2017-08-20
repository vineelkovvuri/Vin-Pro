//
//
//How to: Read Image Metadata
//http://msdn2.microsoft.com/en-us/library/xddt0dz7.aspx
//bobpowell.net
using System;
using System.Drawing;
namespace TestTagLib
{
    class Program
    {
        static void Main(string[] args)
        {
            Image m = Bitmap.FromFile(@"d:\2007-12-11_015524.bmp");
            Console.WriteLine(m.Width + " " + m.Height);
        }
    }
}



