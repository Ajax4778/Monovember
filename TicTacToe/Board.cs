// Monovember Day 4, 5

using System;
using System.Linq;

namespace TicTacToe
{
	public class Board
	{
		// TODO: refactor marks to use char instead of string.
		// TODO refactor grid to use List<int> instead of int[].

		public static string[] validMarks = new string[] { "x", "o" };

		public string[] grid { get; private set; }

		public string winner { get; set; }

		public Board (string[] grid = null)
		{
			if (grid != null) {
				this.grid = grid;
			} else {
				this.grid = Enumerable.Repeat (" ", 9).ToArray ();
			}
		}

		public void display ()
		{
			Console.WriteLine ("{0} | {1} | {2}", this.grid [0], this.grid [1], this.grid [2]);
			Console.WriteLine ("–   –   –");
			Console.WriteLine ("{0} | {1} | {2}", this.grid [3], this.grid [4], this.grid [5]);
			Console.WriteLine ("–   –   –");
			Console.WriteLine ("{0} | {1} | {2}", this.grid [6], this.grid [7], this.grid [8]);
		}

		public void placeMark (int[] pos, string mark)
		{
			int markingIdx = this.index (pos);
			this.grid [markingIdx] = mark;
		}

		public bool isCellEmpty (int[] pos)
		{
			int cellIdx = this.index (pos);
			return this.grid [cellIdx] == " ";
		}

		public bool isWinner (string mark)
		{
			if (!String.IsNullOrWhiteSpace (this.winner)) {
				return this.winner == mark;
			}

			foreach (int i in new int[] { 0, 1, 2}) {
				string[] row = this.row (i);
				string[] col = this.column (i);
				string[] dia = this.diagonal (i);

				if (this.isLineWon (row, mark) || this.isLineWon (col, mark) || this.isLineWon (dia, mark)) {
					this.winner = mark;
					return true;
				}
			}

			return false;
		}


		public bool isLineWon (string[] line, string mark)
		{
			if (line.Length == 0 || line [0] != mark) {
				return false;
			}

			return (line [0] != " " && line.Distinct ().ToArray ().Length == 1);
		}

		public bool isFull ()
		{
			foreach (string cell in this.grid) {
				if (cell == " ") {
					return false;
				}
			}

			return true;
		}

		public int index (int[] pos)
		{
			int i = pos [0];
			int j = pos [1];

			return (i * 3) + j;
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
