using System;
using System.Collections;
namespace MyConsole
{
    class Program
    {
        /*
         * SortedList sorts the list based on the key values 
         * even though we have added the largest key first
         */
        static void Main(string[] args)
        {
            SortedList sl = new SortedList();
            sl.Add("45", "Rammohan Reddy");
            sl.Add("20", "Vineel");
            sl.Add("19", "Suneeta");
            sl.Add("34", "Satya Veni");
            foreach (string s in sl.Keys)
                Console.WriteLine(sl[s]);
        }
    }
}

