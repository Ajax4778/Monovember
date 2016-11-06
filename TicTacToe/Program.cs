// Monovember Day 4, 5

using System;
using System.Collections.Generic;

namespace TicTacToe
{
	class Program
	{
		public static void Main (string[] args)
		{
			Board b = new Board ();
			b.display ();

			HumanPlayer p = new HumanPlayer ("Ajax");
			p.getMove ();
		}
	}
}
