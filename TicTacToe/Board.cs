// Monovember Day 4, 5, 6, 7

using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe
{
	public class Board
	{
		public static char[] validMarks = new char[] { 'x', 'o' };

		public List<char> grid { get; private set; }

		public char winner { get; set; }

		public Board (List<char> grid = null)
		{
			if (grid != null) {
				this.grid = grid;
			} else {
				this.grid = Enumerable.Repeat (' ', 9).ToList ();
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
				List<char> row = this.row (i);
				List<char> col = this.column (i);
				List<char> dia = this.diagonal (i);

				if (this.isLineWon (row, mark) || this.isLineWon (col, mark) || this.isLineWon (dia, mark)) {
					this.winner = mark;
					return true;
				}
			}

			return false;
		}


		public bool isLineWon (List<char> line, char mark)
		{
			if (!line.Any ()) {
				return false;
			}

			return line.All (cell => cell == mark);
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

		public int[] position (int idx)
		{
			int i = idx / 3;
			int j = idx % 3;

			return new int[] { i, j };
		}

		public List<char> row (int i)
		{
			if (i < 0 || i > 2) {
				return new List<char> ();
			} else {
				i = i * 3;
				return new List<char> () { this.grid [i], this.grid [i + 1], this.grid [i + 2] };
			}
		}

		public List<char> column (int j)
		{
			if (j < 0 || j > 2) {
				return new List<char> ();
			} else {
				return new List<char> () { this.grid [j], this.grid [j + 3], this.grid [j + 6] };
			}

		}

		public List<char> diagonal (int d)
		{
			if (d == 0) {
				return new List<char> () { this.grid [0], this.grid [4], this.grid [8] };
			} else if (d == 1) {
				return new List<char> () { this.grid [2], this.grid [4], this.grid [6] };
			} else {
				return new List<char> ();
			}
		}
	}
}
