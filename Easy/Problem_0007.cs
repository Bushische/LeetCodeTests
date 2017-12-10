using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Specialized;

namespace LeetCodeTests
{
	public abstract class Problem_0007
	{
		/*
Given a 32-bit signed integer, reverse digits of an integer.

Example 1:
Input: 123
Output:  321

Example 2:
Input: -123
Output: -321

Example 3:
Input: 120
Output: 21

Note:
Assume we are dealing with an environment which could only hold integers within the 32-bit signed integer range.
For the purpose of this problem, assume that your function returns 0 when the reversed integer overflows.


		*/

		public static void Test()
		{
			Solution sol = new Solution();

			/*
			var input = new int[] { 2, 7, 11, 15 };
			Console.WriteLine($"Input array: {string.Join(", ", input)}");
			*/

			var input = 123;
			Console.WriteLine($"for input '{input}' got '{sol.Reverse(input)}' (wait 321 )");

			input = -123;
			Console.WriteLine($"for input '{input}' got '{sol.Reverse(input)}' (wait -321)");

			input = 120;
			Console.WriteLine($"for input '{input}' got '{sol.Reverse(input)}' (wait 21 )");

			input = 12345;
			Console.WriteLine($"for input '{input}' got '{sol.Reverse(input)}' (wait 21 )");

			input = int.MaxValue;
			Console.WriteLine($"for input '{input}' got '{sol.Reverse(input)}' (wait ... )");
		}

		public class Solution
		{
			public int Reverse(int x)
			{
				try
				{
					int sign = x / Math.Abs(x);
					x = Math.Abs(x);
					int res = 0;
					while (x != 0)
					{
						res = checked( res * 10 + (x % 10));
						x = x / 10;
					}
					// for save sign
					res *= sign;

					return res;
				}
				catch (ArithmeticException ex)
				{
					string sex = ex.ToString();
					return 0;
				}
				catch (Exception ex)
				{
string sex = ex.ToString();
					return 0;
				}
			}
		}
	}
}