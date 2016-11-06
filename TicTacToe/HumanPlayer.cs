// Monovember Day 5

using System;

namespace TicTacToe
{
	public class HumanPlayer
	{
		public string name { get; private set; }

		public HumanPlayer (string name)
		{
			this.name = name;
		}

		public int[] getMove ()
		{
			Console.WriteLine ("What is your move, {0}?", this.name);

			string moveStr = Console.ReadLine ();
			string[] moveChars = moveStr.Split (',');
	
			return Array.ConvertAll (moveChars, Convert.ToInt32);
		}
	}
}

