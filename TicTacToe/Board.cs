// Monovember Day 4

using System;
using System.Linq;

namespace TicTacToe
{
	class Board
	{
		public string[] grid { get; private set; }

		public Board ()
		{
			this.grid = Enumerable.Repeat (" ", 9).ToArray ();
		}

		public void display ()
		{
			Console.WriteLine ("{0} | {1} | {2}", this.grid [0], this.grid [1], this.grid [2]);
			Console.WriteLine ("–   –   –");
			Console.WriteLine ("{0} | {1} | {2}", this.grid [3], this.grid [4], this.grid [5]);
			Console.WriteLine ("–   –   –");
			Console.WriteLine ("{0} | {1} | {2}", this.grid [6], this.grid [7], this.grid [8]);
		}

		public bool isLineWon (string[] line)
		{
			return (line [0] != " " && line.Distinct ().ToArray ().Length == 1);
		}

		public string[] row (int i)
		{
			if (i < 0 || i > 2) {
				return new string[0];
			} else {
				i = i * 3;
				return new string[] { this.grid [i], this.grid [i + 1], this.grid [i + 2] };
			}
		}

		public string[] column (int j)
		{
			if (j < 0 || j > 2) {
				return new string[0];
			} else {
				return new string[] { this.grid [j], this.grid [j + 3], this.grid [j + 6] };
			}

		}

		public string[] diagonal (int d)
		{
			if (d == 0) {
				return new string[] { this.grid [0], this.grid [4], this.grid [8] };
			} else if (d == 1) {
				return new string[] { this.grid [2], this.grid [4], this.grid [6] };
			} else {
				return new string[0];
			}
		}
	}
}
