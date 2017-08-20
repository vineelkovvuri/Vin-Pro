using System;
using System.IO;
using System.Net.Sockets;
using System.Threading;

public class Client
{
	static NetworkStream ns;
	static  StreamWriter sw;
	static  StreamReader sr;
	static TcpClient client;
	static void Main()
	{
		Console.WriteLine("Enter the Remote IP");
		string ip  = Console.ReadLine();
		client = new TcpClient(ip,34440);
		ns = client.GetStream();
		
		sr = new StreamReader(ns);
		
		sw = new StreamWriter(ns);
		sw.AutoFlush = true;
		
		String s="Writing";
		
		Thread read = new Thread(Read);
		read.Start();
		
		while(!s.Equals("END"))
		{
		sw.WriteLine("client:" +(s = Console.ReadLine()));
		}

if(client!=null)client.Close();//<-----client is going to be closed if client Says END
	}
	public static void Read()
	{
		String s="Reading";
		while(!s.Equals("server:END"))
		{
		Console.WriteLine(s = sr.ReadLine());
		}
if(client!=null)client.Close();//<-----client is going to be closed if server Says END
	}
}

