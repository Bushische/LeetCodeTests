using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Specialized;

namespace LeetCodeTests
{
	public abstract class Problem_0062
	{
		/*
A robot is located at the top-left corner of a m x n grid(marked 'Start' in the diagram below).
The robot can only move either down or right at any point in time.The robot is trying to reach the bottom-right corner of the grid(marked 'Finish' in the diagram below).
How many possible unique paths are there?

Above is a 3 x 7 grid.How many possible unique paths are there?
Note: m and n will be at most 100.
		*/
		public static void Test()
		{
			Solution sol = new Solution();

			/*
			var input = new int[] { 2, 7, 11, 15 };
			Console.WriteLine($"Input array: {string.Join(", ", input)}");
			*/
			int m = 3;
			int n = 7;
			Console.WriteLine($"For m={m} and n={n} -> {sol.UniquePaths(m, n)} unique paths (wait 28)");

			m = 1;
			n = 7;
			Console.WriteLine($"For m={m} and n={n} -> {sol.UniquePaths(m, n)} unique paths (wait 1)");

			m = 7;
			n = 1;
			Console.WriteLine($"For m={m} and n={n} -> {sol.UniquePaths(m, n)} unique paths (wait 1)");

			m = 7;
			n = 2;
			Console.WriteLine($"For m={m} and n={n} -> {sol.UniquePaths(m, n)} unique paths (wait 7)");

			m = 2;
			n = 100;
			Console.WriteLine($"For m={m} and n={n} -> {sol.UniquePaths(m, n)} unique paths (wait 7)");
		}

		public class Solution
		{
			public int UniquePaths_find(int m, int n)
			{
				// all cells at first row can be achieved only by ONE path
				// all cells at first column also can be achieved only by ONE path
				// all other cells can be achieved by SUM paths of cell from left and from top
				int[] row = new int[n];
				for (int ind = 0; ind < n; ind++)
					row[ind] = 1;
				for (int rind = 1; rind < m; rind++)
				{
					for (int col = 1; col < n; col++)
						row[col] += row[col - 1];
				}
				return row[n - 1];
			}

			// Through Permutation formula
			public int UniquePaths(int m, int n)
			{
				if ((m == 1) || (n == 1))
					return 1;
				// need make m-1 + n-1 steps
				// just calculat Permutations by formula
				m = m - 1;
				n = n - 1;
				// need m < n
				if (m > n)
				{
					int tmp = m;
					m = n;
					n = tmp;
				}
				// calculate (m+n)! / (m!*n!)
				long result = 1;
				int j = 1;
				long resj = 1;
				for (int i = m + 1; i <= m + n; i++, j++)
				{
					result *= i;
					result /= j;
					resj *= j;
				}
				//result = result / resj;
				return (int) result;
			}
		}
	}//public abstract class Problem_
}