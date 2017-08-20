using System;
using System.Collections;
namespace MyConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Hashtable ht = new Hashtable();
            ht.Add("1", "Suneeta");
            ht.Add("2", "Vineel");
            ht.Add("3", "Satya Veni");
            ht.Add("4", "Rammohan Reddy");
            foreach(string s in ht.Keys)
                Console.WriteLine(ht[s]);

        }
    }
}
