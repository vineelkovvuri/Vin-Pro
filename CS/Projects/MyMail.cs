using System;
using System.Net.Mail;


//Install YPOPs before  doing this
class MyMail
{
	static void Main()
  	{
		try {
			MailMessage m = new MailMessage( "vineel567@yahoo.co.in" , "teja_ephraim@yahoo.com" );
			m.Body = "Mail from Vineel.  " + DateTime.Today;
			m.Subject = "Mail from vineel";
			SmtpClient sc = new SmtpClient( "localhost" );
			sc.Send( m );
			Console.WriteLine( "Mail Sucessed" );
		}
		catch {
			Console.WriteLine( "Mail Failed" );
		}
	}
}

