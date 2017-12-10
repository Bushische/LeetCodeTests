using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Specialized;

namespace LeetCodeTests
{
	public abstract class Problem_0017
	{
/* https://leetcode.com/problems/letter-combinations-of-a-phone-number/description/

Given a digit string, return all possible letter combinations that the number could represent.
A mapping of digit to letters(just like on the telephone buttons) is given below.

Input:Digit string "23"
Output: ["ad", "ae", "af", "bd", "be", "bf", "cd", "ce", "cf"].
Note:
Although the above answer is in lexicographical order, your answer could be in any order you want.
		*/
		public static void Test()
		{
			Solution sol = new Solution();

			/*
			var input = new int[] { 2, 7, 11, 15 };
			Console.WriteLine($"Input array: {string.Join(", ", input)}");
			*/
			var input = "23";
			Console.WriteLine($"For input '{input}': {Utils.PrintArray(sol.LetterCombinations(input))}");

			/*Wrong Answer
				Input:""
				Output:[""]
				Expected:[]			*/
			input = "";
			Console.WriteLine($"For input '{input}': {Utils.PrintArray(sol.LetterCombinations(input))}");
		}

		public class Solution
		{
			Dictionary<char, string> Buttons = new Dictionary<char, string>()
			{ {'2', "abc"}, {'3', "def"}, {'4', "ghi"}, {'5', "jkl"}, {'6', "mno"}, {'7', "pqrs"}, {'8', "tuv"}, {'9', "wxyz"}, {'0', " "}};

			public IList<string> LetterCombinations(string digits)
			{
				List<string> resList = new List<string>();
				GetCombination(digits, 0, "", resList);
				return resList;
			}
			private void GetCombination(string inNumber, int inIndex, string inAcc, List<string> resList)
			{
				if (inIndex == inNumber.Length)
				{
					if (!string.IsNullOrEmpty(inAcc))
						resList.Add(inAcc);
				}
				else
				{
					if (Buttons.ContainsKey(inNumber[inIndex]))
					{
						var curDigVars = Buttons[inNumber[inIndex]].ToCharArray();
						foreach (char nch in curDigVars)
						{
							GetCombination(inNumber, inIndex + 1, inAcc + nch, resList);
						}
					}
				}
			}
		}
	}//public abstract class Problem_
}