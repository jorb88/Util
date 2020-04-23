using System;
using Util;

namespace VisibleTests
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("The largest text number is " + long.MaxValue + "\n");
			Console.WriteLine(long.MaxValue.ToText() + "\n");
			Console.Write("Don't forget to run the unit tests. Depress return to exit.");
			Console.ReadKey();
		}
	}
}
