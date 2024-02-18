using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class UdpClient2
{
	static UdpClient localclient;
	static IPEndPoint remoteendpoint,localendpoint;
	
	static void Main()
	{
		localendpoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"),8010);
		localclient = new UdpClient(localendpoint);
		remoteendpoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"),8000);
		
		byte []datatobesend = Encoding.ASCII.GetBytes("Hai my name is Vineel");
		localclient.Send(datatobesend,datatobesend.Length,remoteendpoint);
		localclient.Close();
		Console.ReadLine();
	}
}



