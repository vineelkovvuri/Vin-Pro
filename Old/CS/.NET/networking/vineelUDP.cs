using System;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Threading;
class vineelUDP
{
	static UdpClient localclient;
	static IPEndPoint localendpoint,remoteendpoint;
	static 	byte [] datareceived;
	static 	byte [] datasent ;
	static bool continue_ = true;
	static void Main()
	{
		try{
			string 	localIP,remoteIP;

//			Console.WriteLine("Enter your IP address...:");
//			localIP = Console.ReadLine();
		localendpoint = new IPEndPoint(IPAddress.Parse(Dns.GetHostEntry("").AddressList[0].ToString()),8291);


			Console.WriteLine("Enter the  remote IP address...:");
			remoteIP = Console.ReadLine();
			remoteendpoint = new IPEndPoint(IPAddress.Parse(remoteIP),8192);

			localclient = new UdpClient(localendpoint);
		}catch(Exception e)
		{
			Console.WriteLine("Remote Host not available...");
			Console.WriteLine("This Client is Disconnecting... press any key");
			Console.ReadLine();
			Environment.Exit(1);
		}

		Console.WriteLine("Session Started ..... Hit q to EXIT");
		Thread t = new Thread(Read);
		t.Start();	
		do
		{
			datasent = Encoding.ASCII.GetBytes(Console.ReadLine());
			localclient.Send(datasent,datasent.Length,remoteendpoint);
            
		}while(Encoding.ASCII.GetString(datasent) != "q"&&continue_);
		continue_ = false;
		localclient.Close();
		t.Abort();
		Console.WriteLine("Session Ended... Hit Enter");
		Console.ReadLine();
	}
	public static void Read()
	{
		try{
			do{
				datareceived = localclient.Receive(ref remoteendpoint);
				Console.Write("Harsha:");
				Console.WriteLine(Encoding.ASCII.GetString(datareceived));
			}while(Encoding.ASCII.GetString(datareceived)!="q"&&continue_);
		}catch{
		}
		continue_= false;
	}

}

