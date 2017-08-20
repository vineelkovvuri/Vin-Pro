
//This is auto generated C# template by vim 
//To move to ClassName field press CTRL+j

using System;
using System.Runtime.InteropServices;

class Program
{
	[DllImport("pdf.dll")]
	public static extern int ProcessPdf(string src,string des);
	static void Main(string []args)
	{
		ProcessPdf(args[0],args[1]);
	}
}


