using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Specialized;

namespace LeetCodeTests
{
	public abstract class Problem_0063
	{
		/*
Follow up for "Unique Paths":
Now consider if some obstacles are added to the grids.How many unique paths would there be?
An obstacle and empty space is marked as 1 and 0 respectively in the grid.

For example,
There is one obstacle in the middle of a 3x3 grid as illustrated below.
[
  [0,0,0],
 [0,1,0],
 [0,0,0]
]
The total number of unique paths is 2.

Note: m and n will be at most 100.
		*/
		public static void Test()
		{
			Solution sol = new Solution();

			/*
			var input = new int[] { 2, 7, 11, 15 };
			Console.WriteLine($"Input array: {string.Join(", ", input)}");
			*/
			var input = new int[3, 3] { { 0, 0, 0 }, { 0, 1, 0 }, { 0, 0, 0 } };
			Console.WriteLine("Input array:");
			Console.WriteLine(Utils.Print2DArray(input));
			Console.WriteLine($"Unique ways: {sol.UniquePathsWithObstacles(input)}");

			input = new int[3, 7] { { 0, 0, 0,0,0,0,0 }, { 0, 1, 0,0,1,0,0 }, { 0, 0, 0,0,0,0,0 } };
			Console.WriteLine("Input array:");
			Console.WriteLine(Utils.Print2DArray(input));
			Console.WriteLine($"Unique ways: {sol.UniquePathsWithObstacles(input)}");

			/*
Submission Result: Wrong Answer
Input: [[1]]
Output:  1
Expected:0
			*/
			input = new int[1, 1] { { 1 }};
			Console.WriteLine("Input array:");
			Console.WriteLine(Utils.Print2DArray(input));
			Console.WriteLine($"Unique ways: {sol.UniquePathsWithObstacles(input)}");

			/*
Submission Result: Wrong Answer
Input:[[0,1]]
Output:1
Expected:0
			*/

			input = new int[1, 2] { { 0, 1 }};
			Console.WriteLine("Input array:");
			Console.WriteLine(Utils.Print2DArray(input));
			Console.WriteLine($"Unique ways: {sol.UniquePathsWithObstacles(input)}");

			/*
Submission Result: Wrong Answer
Input:[[0],[1]]
Output:1
Expected:0
			*/
			input = new int[2, 1] { { 0 }, {1 }};
			Console.WriteLine("Input array:");
			Console.WriteLine(Utils.Print2DArray(input));
			Console.WriteLine($"Unique ways: {sol.UniquePathsWithObstacles(input)}");
		}

		public class Solution
		{
			public int UniquePathsWithObstacles(int[,] obstacleGrid)
			{
				// all cells at first row can be achieved only by ONE path
				// all cells at first column also can be achieved only by ONE path
				// all other cells can be achieved by SUM paths of cell from left and from top
				int n = obstacleGrid.GetLength(1);
				int m = obstacleGrid.GetLength(0);

				int[] row = new int[n];
				row[0] = obstacleGrid[0, 0] == 1 ? 0 : 1;
				for (int ind = 1; ind < n; ind++)
					row[ind] = obstacleGrid[0, ind] == 1 ? 0 : row[ind - 1];

				Console.WriteLine("TEST output:");
				Console.WriteLine(Utils.PrintArray(row));
				for (int rind = 1; rind < m; rind++)
				{
					for (int col = 0; col < n; col++)
					{
						if (obstacleGrid[rind, col] == 1)
							row[col] = 0;
						else
						{
							if (col > 0)	// for col == 0 save previos value
								row[col] += row[col - 1];
						}
					}
					Console.WriteLine(Utils.PrintArray(row));
				}
				return row[n - 1];
			}
		}
	}//public abstract class Problem_
}