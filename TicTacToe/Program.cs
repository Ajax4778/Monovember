// Monovember Day 4, 5, 6, 7, 9

using System;
using System.Collections.Generic;

namespace TicTacToe
{
	class Game
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("What is your name?");
			string playerName = Console.ReadLine ();
			Game game = new Game (playerName);
			game.run ();
		}

		public Board board { get; private set; }

		public HumanPlayer player { get; private set; }

		public ComputerPlayer npc { get; private set; }

		public Game (string playerName)
		{
			this.board = new Board ();
			this.npc = new ComputerPlayer ("Bernie", this.board);
			this.player = new HumanPlayer (playerName);
		}

		public void run ()
		{
			this.player.mark = 'x';
			this.npc.mark = 'o';
			int[] move;
			bool valid = true;

			while (!this.isOver ()) {
				this.display ();

				if (!valid) {
					Console.WriteLine ("Invalid move.");
				}

				move = this.player.getMove ();
				valid = this.playMove (move, 'x');
				if (!valid) {
					continue;
				}

				if (this.isOver () || this.board.isWinner ('x')) {
					break;
				}

				move = this.npc.getMove ();
				this.playMove (move, 'o');
				if (this.isOver () || this.board.isWinner ('o')) {
					break;
				}
			}

			this.display ();
			Console.WriteLine ("Winner: {0}", this.board.winner);
			Console.WriteLine ("Game over.");
		}

		public void display ()
		{
			Console.Clear ();
			this.board.display ();
		}

		public bool playMove (int[] move, char mark)
		{
			if (this.board.isCellEmpty (move)) {
				this.board.placeMark (move, mark);
				return true;
			} else {
				Console.WriteLine ("Invalid move.");
				return false;
			}

		}

		public bool isOver ()
		{
			return this.board.isFull ();
		}
	}
}
