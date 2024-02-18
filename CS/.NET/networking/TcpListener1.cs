using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
class TcpListener1
{
	static TcpListener server;
	static NetworkStream ns;
	static TcpClient remoteclient;
	static void Main()
	{
		server = new TcpListener(IPAddress.Parse("127.0.0.1"),8000);
		server.Start();
		Console.WriteLine("Server started and Listening to incoming Connections....");
		remoteclient =  server.AcceptTcpClient();
		Console.WriteLine("Connection accepted.....");
		ns = remoteclient.GetStream();
		byte []b = new byte[100];
		ns.Read(b,0,b.Length);
		string s = Encoding.ASCII.GetString(b);
		Console.WriteLine(s);
		ns.Close();
		server.Stop();
		Console.WriteLine("Server Stopped....");
		Console.ReadLine();
	}
}
