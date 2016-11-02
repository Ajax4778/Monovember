// November 1st, 2016
// Monovember Day 1

using System;

namespace HelloWorld
{
	class HelloWorld
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Hello World!");

			string answer;
			do {
				Console.WriteLine ("Password?");
				answer = Console.ReadLine ();
			} while (!answer.Equals ("password"));

			Console.WriteLine ("----------");
			Console.WriteLine ("What is your name?");
			string name = Console.ReadLine ();

			Console.WriteLine ("Hello, {0}!", name);

		}
	}
}
