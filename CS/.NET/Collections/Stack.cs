using System;
using System.Collections;
namespace MyConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack s = new Stack();
            s.Push("Suneeta");
            s.Push("Vineel");
            s.Push("Satya Veni");
            s.Push("Rammohan Reddy");

            //s.Peek() just returns the top most object with out removing
            Console.WriteLine((string)s.Peek());

            //s.Pop() even remove the object from the stack
            Console.WriteLine((string)s.Pop());
            Console.WriteLine((string)s.Pop());
        }
    }
}

