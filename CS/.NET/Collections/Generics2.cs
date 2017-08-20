using System;
namespace MyConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Sort<int>(10, 20);
            Sort<float>(123.90f, 12.23f);
            //Sort<string>("Vineel", "VIneell");       <---------------\
        }														//     | 	
        public static void Sort<T>(T x, T y) where T:struct		//     | 	
        {														//     | 	
            T temp;												//     | 			
            temp = x;											//     | 
            x = y;												//     | 		
            y = temp;											//     | 
            Console.WriteLine(x + "  " + y);                    //     | 
        }														//     |			
		/*															   | 	
		 * where T:struct tells that T must be a value type            |
		 * so //Sort<string>("Vineel", "VIneell"); statement        ---|  
		 * leeds to compiler error as we are passing refernce types ---/
		 */

		/*
		 *where T:struct
		 *Indicates that T must be a value type (except Nullable).
		 
		 *where T:class
		 *Indicates that T must be a reference type, including any class, delegate, or
		 *interface.
		
	 	 *where T:new()
		 *Indicates that T must implement a default constructor. The new() constraint 
		 *must be specified last if it is used with multiple constraints on the same type.
 
		 *where T: (base class)
		 *Indicates that T must either be or derive from the base class indicated.
 
		 *where T: (interface)
		 *Indicates that T must either be or implement the interface indicated.
 		 */
    }
}

