using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Specialized;

namespace LeetCodeTests
{
	public abstract class Problem_0058
	{
		/*
Given a string s consists of upper/lower-case alphabets and empty space characters ' ', return the length of last word in the string.

If the last word does not exist, return 0.

Note: A word is defined as a character sequence consists of non-space characters only.

Example:

Input: "Hello World"
Output: 5
		*/
		public static void Test()
		{
			Solution sol = new Solution();

			/*
			var input = new int[] { 2, 7, 11, 15 };
			Console.WriteLine($"Input array: {string.Join(", ", input)}");
			*/

			string input = "hello world";
			Console.WriteLine($"for input '{input}' -> {sol.LengthOfLastWord(input)}");

			input = "hello world      ";
			Console.WriteLine($"for input '{input}' -> {sol.LengthOfLastWord(input)}");

			input = "hello world    a";
			Console.WriteLine($"for input '{input}' -> {sol.LengthOfLastWord(input)}");
		}

		/// <summary>
		/// O(n) CPU
		/// O(1) memmory
		/// </summary>
		public class Solution
		{
			public int LengthOfLastWord(string s)
			{
				if (string.IsNullOrEmpty(s)) return 0;
				int lastWorldLength = 0;
				bool afterSpaces = false;
				for (int i = 0; i < s.Length; i++)
				{
					if (s[i] == ' ')
						afterSpaces = true;
					else if (afterSpaces)
					{
						lastWorldLength = 1;
						afterSpaces = false;
					}
					else
						lastWorldLength++;
				}

				return lastWorldLength;
			}
		}
	}//public abstract class Problem_
}