using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Specialized;

namespace LeetCodeTests
{
	public abstract class Problem_0073
	{
		/*
Given a m x n matrix, if an element is 0, set its entire row and column to 0. Do it in place.

Follow up:
Did you use extra space?
A straight forward solution using O(mn) space is probably a bad idea.
A simple improvement uses O(m + n) space, but still not the best solution.
Could you devise a constant space solution?
		*/
		public static void Test()
		{
			Solution sol = new Solution();

			/*
			var input = new int[] { 2, 7, 11, 15 };
			Console.WriteLine($"Input array: {string.Join(", ", input)}");
			*/
			var input = new int[4, 5]{
				{1,2,0,4,3},
				{0,3,2,1,5},
				{1,2,3,4,5},
				{1,2,3,4,0}};
			Console.WriteLine($"For input matrix:\n{Utils.Print2DArray(input)}");
			sol.SetZeroes(input);
			Console.WriteLine($"Output matrix:\n{Utils.Print2DArray(input)}\n");

			input = new int[4, 5]{
				{1,2,3,4,3},
				{1,3,2,1,5},
				{1,2,3,4,5},
				{1,2,3,4,0}};
			Console.WriteLine($"For input matrix:\n{Utils.Print2DArray(input)}");
			sol.SetZeroes(input);
			Console.WriteLine($"Output matrix:\n{Utils.Print2DArray(input)}\n");

			input = new int[4, 5]{
				{0,2,3,4,3},
				{1,3,2,1,5},
				{1,2,3,4,5},
				{1,2,3,4,0}};
			Console.WriteLine($"For input matrix:\n{Utils.Print2DArray(input)}");
			sol.SetZeroes(input);
			Console.WriteLine($"Output matrix:\n{Utils.Print2DArray(input)}\n");

			/*
Submission Result: Wrong Answer 
Input:[[-4,-2147483648,6,-7,0],[-8,6,-8,-6,0],[2147483647,2,-9,-6,-10]]
Output: [[0,0,0,0,0],[0,0,0,0,0],[0,2,-9,-6,0]]
Expected: [[0,0,0,0,0],[0,0,0,0,0],[2147483647,2,-9,-6,0]]
			*/
			input = new int[3, 5]{
				{-4,-2147483648,6,-7,0},
				{-8,6,-8,-6,0},
				{2147483647,2,-9,-6,-10}};
			Console.WriteLine($"For input matrix:\n{Utils.Print2DArray(input)}");
			sol.SetZeroes(input);
			Console.WriteLine($"Output matrix:\n{Utils.Print2DArray(input)}\n");
		}

		public class Solution
		{
			public void SetZeroes(int[,] matrix)
			{
				int m = matrix.GetLength(0);
				int n = matrix.GetLength(1);

				bool Col0 = false;
				// use first element in row to say - all row should be 0
				// add variable Col0 to indicate that all First column should be 0
				for (int i = 0; i < m; i++)
				{
					Col0 |= (matrix[i, 0] == 0);
					for (int j = 1; j < n; j++)
						if (matrix[i, j] == 0)
						{
							matrix[i, 0] = 0;
							matrix[0, j] = 0;
						}
				}
				// fill
				for (int i = m - 1; i >= 0; i--)
					for (int j = n - 1; j >= 0; j--)
						if ((matrix[i, 0] == 0) || ((matrix[0, j] == 0) && (j != 0)) || ((j == 0) && Col0))
							matrix[i, j] = 0;
			}
		}

		/// <summary>
		/// passed solution
		/// </summary>
		public class Solution_no_bad
		{
			public void SetZeroes(int[,] matrix)
			{
				int m = matrix.GetLength(0);
				int n = matrix.GetLength(1);
				// idea:
				// if row contains 0, first element will be 0, so, use first element to indicate ROW should be 0
				// if col contains 0, col element in first row will be 0, so use first row as indicator COL should be 0
				// need only two flag ZeroRow and ZeroCol for check if Fist row or First col contains 0
				bool ZeroRow = false;
				bool ZeroCol = false;
				for (int i = 0; i < m; i++)
				{
					for (int j = 0; j < n; j++)
					{
						if (matrix[i, j] == 0)
						{
							ZeroRow |= (i == 0);
							ZeroCol |= (j == 0);
							matrix[0, j] = 0;
							matrix[i, 0] = 0;
						}
					}
				}
				for (int i = 1; i < m; i++)
				{
					if (matrix[i, 0] == 0)
						for (int j = 1; j < n; j++)
							matrix[i, j] = 0;
				}
				for (int j = 1; j < n; j++)
				{
					if (matrix[0, j] == 0)
						for (int i = 1; i < m; i++)
							matrix[i, j] = 0;
				}
				if (ZeroRow)
					for (int j = 0; j<n; j++)
						matrix[0, j] = 0;
				if (ZeroCol)
					for (int i = 0; i < m; i++)
						matrix[i, 0] = 0;
			}
		}
	}//public abstract class Problem_
}