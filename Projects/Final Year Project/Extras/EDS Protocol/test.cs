using System;
using System.Collections.Generic;
using System.Text;

namespace Alert1
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Alert.exe invoked with the following parameters.\r\n");
      Console.WriteLine("Raw command-line: \n\t" + Environment.CommandLine);

      Console.WriteLine("\n\nArguments:\n");
      foreach (string s in args)
      {
        Console.WriteLine("\t" +s);
      }
      Console.WriteLine("\nPress any key to continue...");
      Console.ReadKey();
    }
  }
}

