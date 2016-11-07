// Monovember Day 4, 5, 6

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

//			b.placeMark (new int[] { 0, 0 }, 'x');
//			b.placeMark (new int[] { 0, 1 }, 'x');
//			b.placeMark (new int[] { 0, 2 }, 'x');
//			b.placeMark (new int[] { 1, 2 }, 'o');
//			b.placeMark (new int[] { 2, 2 }, 'o');
//			b.display ();
//
//			Console.WriteLine (b.isLineWon (b.row (0), 'x')); // True
//
//			Console.WriteLine (b.isWinner ('x')); // True
//			Console.WriteLine (b.isWinner ('o')); // False

			HumanPlayer p = new HumanPlayer ("Ajax");
			p.getMove ();
		}
	}
}
