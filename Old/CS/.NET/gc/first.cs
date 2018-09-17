using System;

class test
{
	static void Main()
	{
		Console.WriteLine(GC.MaxGeneration);// /-------------ForceFul collection(true)
		Console.WriteLine(GC.GetTotalMemory(true));
			Console.WriteLine(GC.CollectionCount(2));
			//									  \______Generation Number	
	}
}
