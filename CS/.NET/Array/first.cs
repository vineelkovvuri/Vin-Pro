using System;
using System.Collections;
class test
{
	static void Main()
	{
		Array a = new int []{4,3,2,1};
		Console.WriteLine(a.IsFixedSize);  //true
		Console.WriteLine(a.IsSynchronized);//false		
		Console.WriteLine(a.Length);		//4
		Console.WriteLine(a.Rank);		//1 Dimensional
		Console.WriteLine(Array.BinarySearch(a,3));//index of 3 is 2
    //////////////////////////////////////////////
	//	Array.Clear(a,0,2);	//clears the array from 0 to two elements
	//	foreach(int i in a)
	//		Console.WriteLine(i);
	//////////////////////////////////////////////	
		com c = new com();
		Array.Sort(a,c);
		foreach(int i in a)
		Console.WriteLine(i);
		
	
	}
}
class com :IComparer
{
	public int Compare(object x,object y)
	{
		return-((int)x-(int)y);
	}
}
