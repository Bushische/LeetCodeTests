using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Specialized;

namespace LeetCodeTests
{
	public abstract class Problem_0069
	{
		/*
Implement int sqrt(int x).

Compute and return the square root of x.

x is guaranteed to be a non-negative integer.


Example 1:

Input: 4
Output: 2
Example 2:

Input: 8
Output: 2
Explanation: The square root of 8 is 2.82842..., and since we want to return an integer, the decimal part will be truncated.

		*/
		public static void Test()
		{
			Solution sol = new Solution();

			/*
			var input = new int[] { 2, 7, 11, 15 };
			Console.WriteLine($"Input array: {string.Join(", ", input)}");
			*/
			var input = 2;
			Console.WriteLine($"sqrt'{input}' => '{sol.MySqrt(input)}' (waits {(int)Math.Sqrt(input)}))");

			for (int i = 3; i <= 17; i++)
			{
				input = i * 2;
				Console.WriteLine($"sqrt'{input}' => '{sol.MySqrt(input)}' (waits {(int)Math.Sqrt(input)}))");
			}

			input = 64;
			Console.WriteLine($"sqrt'{input}' => '{sol.MySqrt(input)}' (waits {(int)Math.Sqrt(input)}))");
			input = 63;
			Console.WriteLine($"sqrt'{input}' => '{sol.MySqrt(input)}' (waits {(int)Math.Sqrt(input)}))");
			input = 66;
			Console.WriteLine($"sqrt'{input}' => '{sol.MySqrt(input)}' (waits {(int)Math.Sqrt(input)}))");

			/*
Submission Result: Runtime Error
Last executed input: 2147395599
			*/
			input = 2147395599;
			Console.WriteLine($"sqrt'{input}' => '{sol.MySqrt(input)}' (waits {(int)Math.Sqrt(input)}))");

			/*
Submission Result: Wrong Answer
Input:0
Output:1
Expected:0
			*/
			input = 0;
			Console.WriteLine($"sqrt'{input}' => '{sol.MySqrt(input)}' (waits {(int)Math.Sqrt(input)}))");

			input = 1;
			Console.WriteLine($"sqrt'{input}' => '{sol.MySqrt(input)}' (waits {(int)Math.Sqrt(input)}))");
		}

		public class Solution
		{
			public int MySqrt(int x)
			{
				if (x <= 0)
					return 0;
				return Find(x, 1, x);
			}

			private int Find(int x, int left, int right)
			{
				//int mid = (left + right) / 2;
				int mid = left + (right-left) / 2;
				try
				{
					if (mid == left) return left;
					int qrt = checked(mid * mid);
					if (qrt == x)
						return mid;
					if (qrt < x)
						return Find(x, mid, right);
					else
						return Find(x, left, mid);
				}
				catch (OverflowException)
				{
					return Find(x, left, mid);	// in left
				}
			}
		}
	}//public abstract class Problem_
}