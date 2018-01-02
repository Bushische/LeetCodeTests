using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Specialized;

namespace LeetCodeTests
{
	public abstract class Problem_0089
	{
		/*
89. Gray Code

The gray code is a binary numeral system where two successive values differ in only one bit.

Given a non-negative integer n representing the total number of bits in the code, print the sequence of gray code.A gray code sequence must begin with 0.

For example, given n = 2, return [0,1,3,2]. Its gray code sequence is:

00 - 0
01 - 1
11 - 3
10 - 2
Note:
For a given n, a gray code sequence is not uniquely defined.

For example, [0, 2, 3, 1] is also a valid gray code sequence according to the above definition.

   For now, the judge is able to judge based on one instance of gray code sequence.Sorry about that.
		*/
		public static void Test()
		{
			Solution sol = new Solution();

			/*
			var input = new int[] { 2, 7, 11, 15 };
			Console.WriteLine($"Input array: {string.Join(", ", input)}");
			*/
			var n = 4;
			var resList = sol.GrayCode(n);
			Console.WriteLine($"Gray codes for n={n}: {Utils.PrintArray(resList)}");
			Console.WriteLine($"In bit view:");

			for (int i = 0; i < resList.Count; i++)
			{
				int num = resList[i];
				Console.WriteLine($"{i}: {num} -> {Utils.GetBitView(num, n)}");
			}
		}

		public class Solution
		{
			public IList<int> GrayCode(int n)
			{
				// Gray code can be calculated by formula:
				// i-indexed code is I xor (I >> 1)

				List<int> resList = new List<int>();
				for (int i = 0; i < (1 << n); i++)
				{
					resList.Add(i ^ (i >> 1));
				}
				return resList;
			}
		}
	}//public abstract class Problem_
}