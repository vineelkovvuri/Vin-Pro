using System;

class test
{
	static void Main()
	{
		int []x = new int []{1,2,3,7,4,5,56,8};

		foreach (int i in x)
			Console.Write(i+"  ");
		Console.Write("\n");

		Array.Reverse(x);
		foreach (int i in x)
			Console.Write(i+"  ");
		Console.Write("\n");

		Array.Sort(x);
		foreach (int i in x)
			Console.Write(i+"  ");
		Console.Write("\n");

		int t = Array.BinarySearch(x,56);
			Console.Write(t);
		Console.Write("\n");
		
		Array.Clear(x,0,x.Length);
		foreach (int i in x)
			Console.Write(i+"  ");
	}
}
