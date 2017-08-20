using System;
using System.Collections;
namespace MyConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue q = new Queue();
            q.Enqueue("Suneeta");
            q.Enqueue("Vineel");
            q.Enqueue("Satya Veni");
            q.Enqueue("Rammohan Reddy");
            Console.WriteLine((string)q.Dequeue());
            Console.WriteLine((string)q.Dequeue());
            Console.WriteLine((string)q.Dequeue());
            Console.WriteLine((string)q.Dequeue());
            /*
             * To traverse entire Queue using foreach we should
             * use GetEnumerator() method
			 * When you use q.Dequeue() it removes the object from 
			 * Queue and returns that object 
			 * But to simply get the object with out removing from the
			 * Queue we should use q.Peek(); 
             */
        }
    }
}

