using System;
using System.Text;
using System.Net.Sockets;
using System.Net;

class UdpClient1
{
	static UdpClient localclient;
	static IPEndPoint localendpoint,remoteendpoint;
	static void Main()
	{
		
		localendpoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"),8000);
		remoteendpoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"),8010);
		localclient = new UdpClient(localendpoint);
		byte [] datareceived ;
		datareceived = localclient.Receive(ref remoteendpoint);
		Console.WriteLine(Encoding.ASCII.GetString(datareceived));
		localclient.Close();
		Console.ReadLine();
	}
}
