using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string []s = new string[]{"doco.pdf","c1.pdf","c2.pdf","c3.pdf","c4.pdf","c5.pdf","c6.pdf","c7.pdf","c8.pdf",
                "c9.pdf","c10.pdf","c11.pdf","c12.pdf","c13.pdf","c14.pdf","c15.pdf","c16.pdf","c17.pdf","c18.pdf","c19.pdf",
                "c20.pdf","c21.pdf","c22.pdf","c23.pdf","c24.pdf","c25.pdf","c26.pdf","c27.pdf",
                "c28.pdf","c29.pdf","c30.pdf","c31.pdf"};
           // string[] s = new string[] { "c1.mp3", "c2.mp3" };
            int t;
            FileStream fs1;
            FileStream fs2  = new FileStream(@"D:\ebooks\ebooks\c++\cpp(high level)\a1.mp3", FileMode.Create, FileAccess.Write);
            //foreach (string s1 in s)
            {
                fs1= new FileStream(@"D:\ebooks\ebooks\c++\cpp(high level)\" + s[1], FileMode.Open, FileAccess.Read);
                fs2.WriteByte((byte)13);
                t = fs1.ReadByte();
                while (t != -1)
                {
                 //   fs2.WriteByte((byte)t);
                    Console.Write("  "+(byte)t);
                    t = fs1.ReadByte();
                }
                fs1.Close();
                
            }
            fs2.Close();
            Console.Read();
            
        }
    }
}

