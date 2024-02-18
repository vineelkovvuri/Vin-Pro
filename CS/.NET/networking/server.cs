using System;
using System.IO;
using System.Net.Sockets;
using System.Threading;

public class server
{
	static StreamReader sr;
	static StreamWriter sw;
	static NetworkStream ns;
	static Socket soc;
	static void Main()
	{
		TcpListener tcpl = new TcpListener(34440);
		tcpl.Start();
		soc = tcpl.AcceptSocket();
		ns = new NetworkStream(soc);	
		
		sr = new StreamReader(ns);
		
		sw = new StreamWriter(ns);
		sw.AutoFlush = true;

		string s="writing";

		Thread read = new Thread(Read);
		read.Start();
		
		while(!s.Equals("END"))
		{
		sw.WriteLine("server:" +(s = Console.ReadLine()));
		}
	    soc.Close();//<-----server is going to be closed if server Says END
	}
	public static void Read()
	{
		String s="Reading";
		while(!s.Equals("client:END"))
		{
		Console.WriteLine(s = sr.ReadLine());
		}
		
    soc.Close();//<----server is going to be closed if client Says END
	}
}

