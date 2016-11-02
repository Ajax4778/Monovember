// November 2nd, 2016
// Monovember Day 2

using System;

namespace Cats
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Cat c = new Cat ("Ava", "white");
			Console.WriteLine ("{0} is a {1} cat.", c.name, c.color);
			c.speak ();
		}
	}

	class Cat
	{
		public string name { get; private set; }
		public string color { get; private set; }

		public Cat ()
		{
			this.name = "no name";
			this.color = "no color";
		}

		public Cat (string name, string color)
		{
			this.name = name;
			this.color = color;
		}

		public void speak ()
		{
			Console.WriteLine ("Meow");
		}
	}
}
