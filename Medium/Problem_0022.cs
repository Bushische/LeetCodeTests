using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Specialized;

namespace LeetCodeTests
{
	public abstract class Problem_0022
	{
		/*
Given n pairs of parentheses, write a function to generate all combinations of well-formed parentheses.

For example, given n = 3, a solution set is:

[
  "((()))",
  "(()())",
  "(())()",
  "()(())",
  "()()()"
]
		*/
		public static void Test()
		{
			Solution sol = new Solution();

			/*
			var input = new int[] { 2, 7, 11, 15 };
			Console.WriteLine($"Input array: {string.Join(", ", input)}");
			*/
			var input = 3;
			Console.WriteLine($"for input '{input}' -> '{Utils.PrintArray(sol.GenerateParenthesis(input))}'");
		}

		public class Solution
		{
			public IList<string> GenerateParenthesis(int n)
			{
				List<string> resList = new List<string>();
				prvGenerate("", n, 0, resList);
				return resList;
			}

			private void prvGenerate(string inAcc, int openN, int closeN, IList<string> resList)
			{
				if ((openN == 0) && (closeN == 0))
					resList.Add(inAcc);
				if (openN > 0)
					prvGenerate(inAcc + "(", openN - 1, closeN + 1, resList);
				if (closeN > 0)
					prvGenerate(inAcc + ")", openN, closeN - 1, resList);
			}
		}
	}//public abstract class Problem_
}