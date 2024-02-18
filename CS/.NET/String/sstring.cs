using System;

class test
{
	static void Main()
	{
		string s1 = "K.Vineel:Kumar:Reddy:";
		string s2 = "K.Suneeta Devi:";
		Console.WriteLine(s1.Length);
		Console.WriteLine(s1[9]);
		//					\_______equalent to charAt in JAVA
		Console.WriteLine(String.Compare(s1,s2));
		//							\_____ < 0  if  s1<s1 
		//							|_____ = 0  if  s1=s2				
		//							|_____ > 0  if  s1>s2		
		Console.WriteLine(String.Compare(s1,s2,true));
		//										 \____case sensitive if false
		//										 |____case insensitive if true
		Console.WriteLine(String.Concat(s1,s2));
		Console.WriteLine(s1.Contains("ine"));
		//						\_________ checks whether the given string is in s1
		Console.WriteLine(s1.EndsWith("ddy:"));
		//						\__________checks whether s1 ends with the given string	
		Console.WriteLine(s1.IndexOf('d'));
		//						\__________returns  the index of first occurance of d	
		Console.WriteLine(s1.IndexOfAny(new char[]{'u','a','d'}));
		//						\_____returns the index of first occurance of any character in the given array
		Console.WriteLine(s1.LastIndexOf('d'));
		//						\__________returns  the index of last occurance of d	
		Console.WriteLine(s1.LastIndexOfAny(new char[]{'u','a','d'}));
		//						\_____returns the index of last occurance of any character in the given array

		Console.WriteLine(s1.Insert(10,"abcd"));
		//					|	\____K.Vineel Kabcdumar Reddy:
		//					|	                \____10th position
		//					\_____________ THIS METHOD IS USEFULL IN REGEX PATTERNS	  
        Console.WriteLine(String.Join(",",new string[]{s1,s2}));
		//						   \________K.Vineel Kumar Reddy:,K.Suneeta Devi	
		//														 |____","

		Console.WriteLine(s1.Remove(5,4));
		//							 \ \___count
		//							  \____starting index
		Console.WriteLine(s1.Replace("i","u"));
		//							\  \   \____new string 			
		//							 \	\_______old string
		//							  \_________replaces all occurances of old string with the new ones	
            foreach(string s in s1.Split(new char[]{':',' '}))
				Console.WriteLine(s);
		Console.WriteLine(s1.Substring(2,5));		
		//                              \ \___count
		//							     \____starting index
		Console.WriteLine(s1.Trim(new char[]{':'}));
		
	}		
}
