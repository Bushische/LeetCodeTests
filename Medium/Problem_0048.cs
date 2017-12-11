using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Specialized;

namespace LeetCodeTests
{
	public abstract class Problem_0048
	{
		/*
You are given an n x n 2D matrix representing an image.

Rotate the image by 90 degrees (clockwise).

Note:
You have to rotate the image in-place, which means you have to modify the input 2D matrix directly.DO NOT allocate another 2D matrix and do the rotation.

Example 1:

Given input matrix =
[
  [1, 2, 3],
  [4,5,6],
  [7,8,9]
],

rotate the input matrix in-place such that it becomes:
[
  [7,4,1],
  [8,5,2],
  [9,6,3]
]
Example 2:

Given input matrix =
[
  [ 5, 1, 9,11],
  [ 2, 4, 8,10],
  [13, 3, 6, 7],
  [15,14,12,16]
], 

rotate the input matrix in-place such that it becomes:
[
  [15,13, 2, 5],   	(0,1) -> (1, N) -> (N, N-1) -> (N-1, 0)
  [14, 3, 4, 1],	(r,c) -> (c, N-r) -> (N-r, N-c) -> (N-c, r)
  [12, 6, 8, 9],
  [16, 7,10,11]
]
		*/
		public static void Test()
		{
			Solution sol = new Solution();

			/*
			var input = new int[] { 2, 7, 11, 15 };
			Console.WriteLine($"Input array: {string.Join(", ", input)}");
			*/
			var input = new int[3, 3] {{ 1,2,3},{ 4, 5, 6},{ 7, 8, 9} };
			Console.WriteLine($"for input:");
			Console.WriteLine(Utils.PrintArray(input));
			sol.Rotate(input);
			Console.WriteLine($"output:");
			Console.WriteLine(Utils.PrintArray(input));

			input = new int[4, 4] {{ 5,1,9,11},{2,4,8,10},{13,3,6,7},{15,14,12,16} };
			Console.WriteLine($"for input:");
			Console.WriteLine(Utils.PrintArray(input));
			sol.Rotate(input);
			Console.WriteLine($"output:");
			Console.WriteLine(Utils.PrintArray(input));

		}

		public class Solution
		{
			public void Rotate(int[,] matrix)
			{
				int N = matrix.GetLength(0);
				int tmp;
				for (int row = 0; row < N / 2; row++)
				{
					for (int col = row; col < N - row-1; col++)
					{
						tmp = matrix[row, col];
						matrix[row    , col] = matrix[N - col-1, row];
						matrix[N - col-1, row] = matrix[N - row-1, N - col-1];
						matrix[N - row-1, N - col-1] = matrix[col, N - row-1];
						matrix[col, N - row-1] = tmp;
					} //(0,2) <- (1,0) <- (3,1) <- (2, 3)
				}
			}
		}// solution
	}//public abstract class Problem_
}