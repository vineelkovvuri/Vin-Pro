using System;
using System.Collections.Generic;/*System.Collections is not requried 
                                  * as we are using generic types
                                  */
namespace MyConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> q = new Queue<string>();

            q.Enqueue("Suneeta");
            q.Enqueue("Vineel");
            q.Enqueue("Satya Veni");
            q.Enqueue("Rammohan Reddy");
            //q.Enqueue(125);   error : because q is supposed enqueue strings
    
            Console.WriteLine(q.Dequeue());
            Console.WriteLine(q.Dequeue());
            Console.WriteLine(q.Dequeue());
            Console.WriteLine(q.Dequeue());
			
			/*In Non Generic Queue Class q.Enqueue(125) is valid 
			 * and look at the imported namespaces System.Collections is not requried 
			 */
		}
    }
}


