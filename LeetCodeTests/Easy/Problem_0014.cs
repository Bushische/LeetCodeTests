using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Specialized;

namespace LeetCodeTests
{
	public abstract class Problem_0014
	{
		/*
Write a function to find the longest common prefix string amongst an array of strings.
		*/
		public static void Test()
		{
			Solution sol = new Solution();

			/*
			var input = new int[] { 2, 7, 11, 15 };
			Console.WriteLine($"Input array: {string.Join(", ", input)}");
			*/
			var input = new string[] { "abcd", "abcdef", "abc2rwe" };
			Console.WriteLine($"wait for 'abc': '{sol.LongestCommonPrefix(input)}'");

			input = new string[] { };
			Console.WriteLine($"wait for '<empty>': '{sol.LongestCommonPrefix(input)}'");

			input = new string[] { "aewd", "abd", "a" };
			Console.WriteLine($"wait for 'a': '{sol.LongestCommonPrefix(input)}'");
		}

		public class Solution
		{
			public string LongestCommonPrefix(string[] strs)
			{
				if ((strs == null) || (strs.Length == 0))
					return "";
				if (strs.Length == 1)
					return strs[0];
				string prefix = strs[0];
				for (int ind = 1; ind < strs.Length; ind++)
				{
					prefix = GetCommonPrefix(prefix, strs[ind]);
				}
				return prefix;
			}

			private string GetCommonPrefix(string instr1, string instr2)
			{
				int index = 0;
				if (string.IsNullOrEmpty(instr1) || string.IsNullOrEmpty(instr2))
					return "";
				while ((index < instr2.Length) && (index < instr1.Length) && (instr1[index] == instr2[index]))
					index++;
				if (index > 0)
					return instr1.Substring(0, index);
				return "";
			}
		}
	}//public abstract class Problem_
}