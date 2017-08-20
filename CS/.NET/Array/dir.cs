using System;
using System.IO;

class dir
{
	static short k=0;
	static void Main(String []args)
	{
	//	k=Convert.ToInt16(args[1]);
		create(args[0]);
		
	}
	static int i;
	static void create(String path)
	{
			
try{
	
				Directory.CreateDirectory(path);
				i++;
		Directory.SetCurrentDirectory(path);
 	create(path);
	}
	catch{
		Console.WriteLine("==============::"+i);
	}
	}
}
