// November 3rd, 2016
// Monovember Day 3

using System;
using System.Collections.Generic;

namespace Hanoi
{
	class Game
	{
		public static void Main (string[] args)
		{
			Game game = new Game ();

			Console.WriteLine ("Welcome to Towers of Hanoi.");
			game.runGame ();
		}

		public static Tower[] newGame = { new Tower (starting: true), new Tower (), new Tower () };
		public Tower[] towers;

		public Game()
		{
			this.towers = newGame;
		}

		public void runGame ()
		{
			while (!this.gameOver ()) {
				this.display ();
				int[] playerMove = this.getMove ();
				if (playerMove.Length != 2) {
					Console.Clear ();
					Console.WriteLine ("Invalid move!");
					continue;
				}

				if (this.isValidMove (playerMove)) {
					this.makeMove (playerMove);
					Console.Clear ();
					continue;
				} else {
					Console.Clear ();
					Console.WriteLine ("{0} to {1} is an invalid move!", playerMove [0], playerMove [1]);
				}
			}

			this.display ();
			Console.WriteLine ("Game over!");
		}

		private void display ()
		{
			Console.WriteLine (" | <-- | <-- | <-- | ");
			Console.Write (" | ");
			foreach (Tower t in this.towers) {
				t.display ();
				Console.Write (" | ");
			}
		}

		private Tower getTower (int idx)
		{
			return this.towers [idx];
		}

		private int[] getMove ()
		{
			Console.WriteLine ("What is your move?");

			string move = Console.ReadLine ();
			string[] moveChars = move.Split (',');
			return Array.ConvertAll (moveChars, Convert.ToInt32);
		}

		private bool isValidMove (int[] move)
		{
			if (move [0] >= 3 || move [1] >= 3) {
				return false;
			} else {
				Tower fromTower = this.getTower (move [0]);
				Tower toTower = this.getTower (move [1]);

				return fromTower.topDisc () < toTower.topDisc ();
			}
		}

		private void makeMove (int[] move)
		{
			Tower fromTower = this.getTower (move[0]);
			Tower toTower = this.getTower (move[1]);

			int disc = fromTower.remove ();
			toTower.add (disc);
		}

		private bool gameOver ()
		{
			return this.getTower (1).isFull () || this.getTower (2).isFull ();
		}

	}

	class Tower
	{
		public static int[] startingTower = { 1, 2, 3 };
		public List<int> discs = new List<int> ();

		public Tower (bool starting = false)
		{
			if (starting) {
				this.discs.AddRange (Tower.startingTower);
			}
		}

		public void display ()
		{
			if (this.isEmpty ()) {
				Console.Write ("---");
			} else {
				// Pad tower with dashes if discs.count < 3.
				if (this.discs.Count == 2) {
					Console.Write("-");
				} else if (this.discs.Count == 1) {
					Console.Write("--");
				}

				this.discs.ForEach (Console.Write);
			}
		}

		public int topDisc ()
		{
			if (this.isEmpty()) {
				return 999;
			} else {
				return this.discs [0];
			}
		}

		public int remove ()
		{
			if (this.isEmpty ()) {
				return -1;
			} else {
				int disc = this.topDisc();
				this.discs.RemoveAt (0);
				return disc;
			}
		}

		public void add (int disc)
		{
			if (this.isValid(disc)) {
				this.discs.Insert (0, disc);
			}
		}

		public bool isFull ()
		{
			return this.discs.Count == 3;
		}

		private bool isEmpty ()
		{
			return this.discs.Count == 0;
		}

		private bool isValid (int disc)
		{
			return (this.isEmpty () || this.topDisc() > disc);
		}
	}
}
