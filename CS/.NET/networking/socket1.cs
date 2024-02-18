using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
class Socket1
{
	static void Main()
	{
		IPEndPoint ipe  = new IPEndPoint(IPAddress.Any,8080);
		Socket s = new Socket(AddressFamily.InterNetwork,
				SocketType.Stream, ProtocolType.Tcp);
		
		s.Bind(ipe);
		s.Listen(10);
		Socket client =	s.Accept();
				IPEndPoint clientep = (IPEndPoint)client.RemoteEndPoint;	
		Console.WriteLine("Connection aceppted from address:{0},port:{1}",clientep.Address,clientep.Port);
		byte []b = Encoding.ASCII.GetBytes("Hai Welcome Networking in C#....");
		client.Send(b);
		while(true)
		{
			if(client.Receive(b) == 0)break;
			Console.WriteLine(b);
		}
		client.Close();
		s.Close();	

	}
}
