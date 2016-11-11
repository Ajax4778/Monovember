// Monovember Day 10

using System;
using System.Collections.Generic;
using System.Linq;

namespace Recursion
{
	class Recursion
	{
		public static void Main (string[] args)
		{
			fibonacci (11).ForEach (Console.WriteLine);
		}

		public static List<int> fibonacci (int n)
		{
			if (n == 0) {
				return new List<int> ();
			} else if (n == 1) {
				return new List<int> (new int[] { 0 });
			} else if (n == 2) {
				return new List<int> (new int[] { 0, 1 });
			}

			List<int> prev = fibonacci (n - 1);
			int prevCount = prev.Count;
			prev.Add (prev [prevCount - 1] + prev [prevCount - 2]);

			return prev;
		}
	}
}
