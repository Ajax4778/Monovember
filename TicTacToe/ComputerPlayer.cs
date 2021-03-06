﻿// Monovember Day 6, 7, 8, 9

using System;
using System.Collections.Generic;

namespace TicTacToe
{
	public class ComputerPlayer
	{
		public static Random rnd = new Random ();

		public string name { get; private set; }

		public char mark { get; set; }

		public Board board { get; private set; }

		public ComputerPlayer (string name, Board board)
		{
			this.name = name;
			this.board = board;
		}

		public int[] getMove ()
		{
			int[] winningMove = this.findWinningMove ();
			if (winningMove != null) {
				return winningMove;
			}

			int[] blockingMove = this.findBlockingMove ();
			if (blockingMove != null) {
				return blockingMove;
			}

			return this.getRandomMove ();
		}

		public int[] findWinningMove ()
		{
			return this.nextWinningMove (this.mark);
		}

		public int[] findBlockingMove ()
		{
			char opposingMark = this.mark == 'o' ? 'x' : 'o';
			return this.nextWinningMove (opposingMark);
		}

		public int[] getRandomMove ()
		{
			List<int[]> moves = new List<int[]> ();

			for (int idx = 0; idx < 9; idx++) {
				int[] pos = this.board.position (idx);
				if (this.board.isCellEmpty (pos)) {
					moves.Add (pos);
				}
			}

			int r = rnd.Next (moves.Count);
			return moves [r];
		}

		private int[] nextWinningMove (char mark)
		{
			for (int idx = 0; idx < 9; idx++) {
				int[] pos = this.board.position (idx);
				if (this.board.isCellEmpty (pos)) {
					List<char> dupGrid = new List<char> (this.board.grid);
					Board dupBoard = new Board (dupGrid);

					dupBoard.placeMark (pos, mark);
					if (dupBoard.isWinner (mark)) {
						return pos;
					}
				}
			}

			return null;
		}
	}
}

