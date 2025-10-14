using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Specialized;

namespace LeetCodeTests
{
	public abstract class Problem_0054
	{
		/*
Given a matrix of m x n elements(m rows, n columns), return all elements of the matrix in spiral order.

For example,
Given the following matrix:
[
 [ 1, 2, 3 ],
[ 4, 5, 6 ],
[ 7, 8, 9 ]
]
You should return [1,2,3,6,9,8,7,4,5].
		*/
		public static void Test()
		{
			Solution sol = new Solution();

			/*
			var input = new int[] { 2, 7, 11, 15 };
			Console.WriteLine($"Input array: {string.Join(", ", input)}");
			*/
			int[,] input = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
			Console.WriteLine($"For input: '{Utils.PrintArray(input)}' -> output: '{Utils.PrintArray(sol.SpiralOrder(input))}'");
			Console.WriteLine("\t waits [1,2,3,6,9,8,7,4,5]");

			input = new int[,] { { 1, 2, 3, 4}, {  5, 6, 7, 8 } };
			Console.WriteLine($"For input: '{Utils.PrintArray(input)}' -> output: '{Utils.PrintArray(sol.SpiralOrder(input))}'");
			Console.WriteLine("\t waits [1,2,3,4,8,7,6,5]");

			input = new int[,] { { 1, 2, 3, 4}};
			Console.WriteLine($"For input: '{Utils.PrintArray(input)}' -> output: '{Utils.PrintArray(sol.SpiralOrder(input))}'");
			Console.WriteLine("\t waits [1,2,3,4,8,7,6,5]");

			input = new int[,] { { 1 }, { 2 }, { 3 }, { 4 } };
			Console.WriteLine($"For input: '{Utils.PrintArray(input)}' -> output: '{Utils.PrintArray(sol.SpiralOrder(input))}'");
			Console.WriteLine("\t waits [1,2,3,4]");

			input = new int[,] { { 1, 2 }, { 3, 4 }, { 5, 6 } };
			Console.WriteLine($"For input: '{Utils.PrintArray(input)}' -> output: '{Utils.PrintArray(sol.SpiralOrder(input))}'");
			Console.WriteLine("\t waits [1,2,4,6,5,3]");
		}

		public class Solution
		{
			public IList<int> SpiralOrder(int[,] matrix)
			{
				List<int> resList = new List<int>();

				if (matrix == null)
					return resList;

				// boarders index
				int left = 0;
				int right = matrix.GetLength(1)-1;
				int top = 0;
				int bottom = matrix.GetLength(0)-1;

				// point 
				int row = 0;
				int col = 0;

				// dxs
				int cdx = 1;	// 1 - move to right, -1 - move to left
				int rdx = 0;    // 1 - move to bottom, -1 - move to up

				// pass step by step
				while ((col >= left) && (col <= right) && (row >= top) && (row <= bottom))
				{
					resList.Add(matrix[row, col]);
					row += rdx;
					col += cdx;

					#region change directions
					// to right, change on to bottom
					if (col > right)
					{
						col -= cdx;
						cdx = 0; rdx = 1;
						row += rdx;
						top++;
					}
					// to bottom, change on to left
					else if (row > bottom)
					{
						row -= rdx;
						cdx = -1; rdx = 0;
						col += cdx;
						right--;
					}
					// to left, change on to top
					else if (col < left)
					{
						col -= cdx;
						cdx = 0; rdx = -1;
						row += rdx;
						bottom--;
					}// to top, change on to right
					else if (row < top)
					{
						row -= rdx;
						cdx = 1; rdx = 0;
						col += cdx;
						left++;
					}
					#endregion
				}
				return resList;
			}
		}
	}//public abstract class Problem_
}