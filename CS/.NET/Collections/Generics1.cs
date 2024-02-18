using System;
namespace MyConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Sort<int>(10, 20);
            Sort<float>(123.90f, 12.23f);
        }
        public static void Sort<T>(T x, T y) 
        {
            T temp;
            temp = x;
            x = y;
            y = temp;
            Console.WriteLine(x + "  " + y);
        }
    }
}

