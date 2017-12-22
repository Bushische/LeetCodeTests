using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Specialized;

namespace LeetCodeTests
{
	public abstract class Problem_0074
	{
		/*
Write an efficient algorithm that searches for a value in an m x n matrix.This matrix has the following properties:

Integers in each row are sorted from left to right.
The first integer of each row is greater than the last integer of the previous row.
For example,

Consider the following matrix:

[
  [1,   3,  5,  7],
  [10, 11, 16, 20],
  [23, 30, 34, 50]
]
Given target = 3, return true.


		*/
		public static void Test()
		{
			Solution sol = new Solution();

			/*
			var input = new int[] { 2, 7, 11, 15 };
			Console.WriteLine($"Input array: {string.Join(", ", input)}");
			*/

			var input = new int[3, 4]
			{
				{1,3,5,7},
				{10,11,16,20},
				{23,30,34,50}
			};
			int target = 3;
			Console.WriteLine($"For input matrix: \n{Utils.Print2DArray(input)}");
			Console.WriteLine($"Try search {target} -> {sol.SearchMatrix(input, target)} (waits true)");

			target = 6;
			Console.WriteLine($"Try search {target} -> {sol.SearchMatrix(input, target)} (waits false)");

			target = 15;
			Console.WriteLine($"Try search {target} -> {sol.SearchMatrix(input, target)} (waits false)");

			target = 10;
			Console.WriteLine($"Try search {target} -> {sol.SearchMatrix(input, target)} (waits true)");

			input = new int[7, 1]
			{
				{1},{3},{5},{7},{9},{11},{13}
			};
			Console.WriteLine($"For input matrix: \n{Utils.Print2DArray(input)}");
			target = 10;
			Console.WriteLine($"Try search {target} -> {sol.SearchMatrix(input, target)} (waits false)");

			target = 0;
			Console.WriteLine($"Try search {target} -> {sol.SearchMatrix(input, target)} (waits false)");

			target = 15;
			Console.WriteLine($"Try search {target} -> {sol.SearchMatrix(input, target)} (waits false)");

			target = 5;
			Console.WriteLine($"Try search {target} -> {sol.SearchMatrix(input, target)} (waits true)");

			target = 13;
			Console.WriteLine($"Try search {target} -> {sol.SearchMatrix(input, target)} (waits true)");


			/*
Submission Result: Runtime Error
Runtime Error Message: Line 18: System.IndexOutOfRangeException: Index was outside the bounds of the array.
Last executed input: [] 0
			*/

			input = new int[0, 0];
			Console.WriteLine($"For input matrix: \n{Utils.Print2DArray(input)}");
			target = 0;
			Console.WriteLine($"Try search {target} -> {sol.SearchMatrix(input, target)} (waits false)");

			/*
Submission Result: Wrong Answer
Input: [[1,3]] 3
Output:  false
Expected:true
			*/
			input = new int[1, 2]
			{
				{1, 3}
			};
			Console.WriteLine($"For input matrix: \n{Utils.Print2DArray(input)}");
			target = 3;
			Console.WriteLine($"Try search {target} -> {sol.SearchMatrix(input, target)} (waits true)");

		}

		public class Solution
		{
			public bool SearchMatrix(int[,] matrix, int target)
			{
				if (matrix == null) return false;
				int m = matrix.GetLength(0);
				int n = matrix.GetLength(1);
				if ((m == 0) || (n == 0))
					return false;
				int row = SearchRow(matrix, target, 0, m-1);
			/*	while (row < m)
				{
					if (matrix[row, 0] > target)
						break;
					row++;
				}
			*/
				//if (row == 0) return false;     // first element in matrix > target => will not found
				//row--;
				if (matrix[row, n - 1] < target)
					return false;                   // elements in next row > target, in current < target
				return SearchInRow(matrix, row, target, 0, n - 1);
			}

			/// <summary>
			/// Searchs the row with max first element which <  target
			/// </summary>
			/// <returns>The row.</returns>
			/// <param name="matrix">Matrix.</param>
			/// <param name="target">Target.</param>
			/// <param name="down">Row with smaller number (0).</param>
			/// <param name="up">Row with bigger number (n).</param>
			private int SearchRow(int[,] matrix, int target, int down, int up)
			{
				if (down == up) return down;
				int mid = down + (up - down) / 2;
				if (mid == down)
					if (matrix[up, 0] <= target)
						return up;
					else
						return mid;
				if (matrix[mid, 0] == target)
					return mid;
				else if (matrix[mid, 0] > target)
					return SearchRow(matrix, target, down, mid);
				else
					return SearchRow(matrix, target, mid, up);
			}

			/// <summary>
			/// Search with binary search
			/// </summary>
			/// <returns><c>true</c>, if in row was searched, <c>false</c> otherwise.</returns>
			/// <param name="matrix">Matrix.</param>
			/// <param name="target">Target.</param>
			/// <param name="row">Row.</param>
			/// <param name="left">Left.</param>
			/// <param name="right">Right.</param>
			private bool SearchInRow(int[,] matrix, int row, int target, int left, int right)
			{
				if ((matrix[row, left] == target) || (matrix[row, right] == target))
					return true;
				int mid = left + (right - left) / 2;
				if (mid == left)
					return matrix[row, left] == target;
				if (matrix[row, mid] == target)
					return true;
				else if (matrix[row, mid] > target)
					return SearchInRow(matrix, row, target, left, mid);
				else
					return SearchInRow(matrix, row, target, mid, right);
			}

		}//
	}//public abstract class Problem_
}

/*
COOL SOLUTION:
public boolean searchMatrix(int[][] matrix, int target)
{
	int i = 0, j = matrix[0].length - 1;
	while (i < matrix.length && j >= 0)
	{
		if (matrix[i][j] == target)
		{
			return true;
		}
		else if (matrix[i][j] > target)
		{
			j--;
		}
		else
		{
			i++;
		}
	}

	return false;
}
*/