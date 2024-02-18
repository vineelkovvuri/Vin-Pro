using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
class TcpClient1
{
	static TcpClient client;
	static NetworkStream ns;
	static void Main()
	{
		Console.WriteLine("Connecting to server....");
		client = new TcpClient("127.0.0.1",8000);
		ns = client.GetStream();
		Console.WriteLine("Connection accepted...");
		byte []b = Encoding.ASCII.GetBytes("Hai My name is Vineel");
		ns.Write(b,0,b.Length);
		ns.Close();
		client.Close();
		Console.WriteLine("Connection Closed...");
				Console.ReadLine();
	}
}

			
			
