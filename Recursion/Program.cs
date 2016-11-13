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

			List<int> list = new List<int> (new int[] { 0, 1, 2, 4, 6, 7, 9 });
			Console.WriteLine (binarySearch (list, 7)); // => 5
			Console.WriteLine (binarySearch (list, 8)); // => -1
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

		public static int  binarySearch (List<int> list, int target)
		{
			int count = list.Count;
			if (count == 0) {
				return -1;
			} else if (count == 1) {
				return (list [0] == target ? 0 : -1);
			}

			int mid = count / 2;
			List<int> left = list.GetRange (0, mid);
			List<int> right = list.GetRange (mid, count - mid);

			if (list [mid] == target) {
				return mid;
			} else if (target < list [mid]) {
				return binarySearch (left, target);
			} else {
				int rightSearch = binarySearch (right, target);
				return (rightSearch == -1 ? -1 : mid + rightSearch);
			}
		}
	}
}
