using System;
using System.Threading;
class test
{
	static void Main()
	{
//		Console.BackgroundColor = ConsoleColor.Black;
//		Console.ForegroundColor = ConsoleColor.Blue;
//		Console.ResetColor();
//		Console.WriteLine(Console.BufferHeight);

//		Console.CursorLeft = 40;  // goto(x);     0,0  at the top left         
//      Console.CursorTop = 20;  // goto(y);		
//      Console.SetCursorPosition(40,20);  //goto(x,y);
//		Console.CursorSize=100; //0<=x<=100
/*		Console.Title ="K.Vineel Kumar Reddy";
		Thread.Sleep(3000);			     //Sets the Title of the window
*/
//		Console.WindowHeight = 30;//30 < current maximium size ,sets the Window Height
//		Console.WindowWidth = 80;//30 < current maximium size ,sets the Window Width
//		Console.WindowLeft = 3;//sets the Window Left
//		Console.WindowTop = 3;//sets the Window Top		
//		Console.Beep(15550,500);
//		               \    \________milliseconds
//						\___________frequency(37<x<32767)				
// 		Console.Clear();  
//		Console.SetWindowPosition(40,40);

		Console.CancelKeyPress  += new ConsoleCancelEventHandler(handle);
//		Console.TreatControlCAsInput = true;
		Console.Read();
				Console.Read();
						Console.Read();
		
	}
	public static void handle(object o,ConsoleCancelEventArgs a)
	{
		Console.WriteLine("CTRL+C");
		a.Cancel = true;//this should be set ???? if not this method will be called 
						//after CTRL+C is pressed and the Program Terminates
	}
}
