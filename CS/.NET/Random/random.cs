using System;

class test
{
	public static void Main()
	{
		Random r= new Random();
		int i=0;

		/////////////////////////////////////////////////////////////////////////////////

		while(i++<50)		// /------------------Random Value
			Console.Write("\t"+r.Next() );
		/////////////////////////////////////////////////////////////////////////////////	
		i=0;
		while(i++<50)
			Console.Write("\t"+r.Next(0,100) );
		//							    \  \  \___________MaxValue	
		//                               \  \_____________MinValue
		//                                \_______________MinValue < r.Next(0,100) < MaxValue  
		/////////////////////////////////////////////////////////////////////////////////
		i=0;
		while(i++<50)
			Console.Write("\t"+r.NextDouble() );
		//								\_________________0 <= r.NextDouble() < 1		
		/////////////////////////////////////////////////////////////////////////////////	
		byte []b = new byte[100];
		r.NextBytes(b);
		//   \____________________This will the byte array(b[]) with random numbers	
		foreach(byte bb in b)
			Console.Write(bb+"\t");
		/////////////////////////////////////////////////////////////////////////////////
	}
}

