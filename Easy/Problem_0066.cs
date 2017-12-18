using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Specialized;

namespace LeetCodeTests
{
	public abstract class Problem_0066
	{
		/*
Given a non-negative integer represented as a non-empty array of digits, plus one to the integer.

You may assume the integer do not contain any leading zero, except the number 0 itself.

The digits are stored such that the most significant digit is at the head of the list.
		*/
		public static void Test()
		{
			Solution sol = new Solution();

			/*
			var input = new int[] { 2, 7, 11, 15 };
			Console.WriteLine($"Input array: {string.Join(", ", input)}");
			*/
			var input = new int[] { 1, 2, 3, 4, 5, 6, 7 };
			Console.WriteLine($"For input '{Utils.PrintArray(input)}' -> '{Utils.PrintArray(sol.PlusOne(input))}'");

			input = new int[] { 0};
			Console.WriteLine($"For input '{Utils.PrintArray(input)}' -> '{Utils.PrintArray(sol.PlusOne(input))}'");

			input = new int[] { 9,9,9};
			Console.WriteLine($"For input '{Utils.PrintArray(input)}' -> '{Utils.PrintArray(sol.PlusOne(input))}'");
		}

		public class Solution
		{
			public int[] PlusOne(int[] digits)
			{
				int[] retValue = digits;
				int remainder = 1;
				for (int i = digits.Length-1; i >= 0; i--)
				{
					digits[i] += remainder;
					remainder = digits[i] / 10;
					digits[i] = digits[i] % 10;
				}
				if (remainder > 0)
				{
					retValue = new int[digits.Length + 1];
					retValue[0] = remainder;
					for (int i = 1; i < retValue.Length; i++)
						retValue[i] = digits[i - 1];
				}

				return retValue;
			}
		}
	}//public abstract class Problem_
}