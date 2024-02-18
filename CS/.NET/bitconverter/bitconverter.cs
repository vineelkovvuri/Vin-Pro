using System;


class test
{
	static void Main()
	{
		int i=100;
		Console.WriteLine(BitConverter.ToString(BitConverter.GetBytes(i)));
	}
}
		
