// Monovember Day 4, 5

using System;
using System.Linq;

namespace TicTacToe
{
	public class Board
	{
		// TODO: refactor grid to use List<char> instead of char[].

		public static char[] validMarks = new char[] { 'x', 'o' };

		public char[] grid { get; private set; }

		public char winner { get; set; }

		public Board (char[] grid = null)
		{
			if (grid != null) {
				this.grid = grid;
			} else {
				this.grid = Enumerable.Repeat (' ', 9).ToArray ();
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

		public void placeMark (int[] pos, char mark)
		{
			int markingIdx = this.index (pos);
			this.grid [markingIdx] = mark;
		}

		public bool isCellEmpty (int[] pos)
		{
			int cellIdx = this.index (pos);
			return this.grid [cellIdx] == ' ';
		}

		public bool isWinner (char mark)
		{
			if (Board.validMarks.Contains (this.winner)) {
				return this.winner == mark;
			}

			foreach (int i in new int[] { 0, 1, 2}) {
				char[] row = this.row (i);
				char[] col = this.column (i);
				char[] dia = this.diagonal (i);

				if (this.isLineWon (row, mark) || this.isLineWon (col, mark) || this.isLineWon (dia, mark)) {
					this.winner = mark;
					return true;
				}
			}

			return false;
		}


		public bool isLineWon (char[] line, char mark)
		{
			if (line.Length == 0 || line [0] != mark) {
				return false;
			}

			return (line [0] != ' ' && line.Distinct ().ToArray ().Length == 1);
		}

		public bool isFull ()
		{
			foreach (char cell in this.grid) {
				if (cell == ' ') {
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

		public char[] row (int i)
		{
			if (i < 0 || i > 2) {
				return new char[0];
			} else {
				i = i * 3;
				return new char[] { this.grid [i], this.grid [i + 1], this.grid [i + 2] };
			}
		}

		public char[] column (int j)
		{
			if (j < 0 || j > 2) {
				return new char[0];
			} else {
				return new char[] { this.grid [j], this.grid [j + 3], this.grid [j + 6] };
			}

		}

		public char[] diagonal (int d)
		{
			if (d == 0) {
				return new char[] { this.grid [0], this.grid [4], this.grid [8] };
			} else if (d == 1) {
				return new char[] { this.grid [2], this.grid [4], this.grid [6] };
			} else {
				return new char[0];
			}
		}
	}
}
