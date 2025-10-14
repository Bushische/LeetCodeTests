using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Specialized;

namespace LeetCodeTests
{
	public abstract class Problem_0043
	{
		/*
Given two non-negative integers num1 and num2 represented as strings, return the product of num1 and num2.

Note:

The length of both num1 and num2 is < 110.
Both num1 and num2 contains only digits 0-9.
Both num1 and num2 does not contain any leading zero.
You must not use any built-in BigInteger library or convert the inputs to integer directly.

		*/
		public static void Test()
		{
			Solution sol = new Solution();

			/*
			var input = new int[] { 2, 7, 11, 15 };
			Console.WriteLine($"Input array: {string.Join(", ", input)}");
			*/
			decimal num1 = 12345;
			decimal num2 = 39559234;
			Console.WriteLine($"'{num1}' x '{num2}' = '{sol.Multiply(num1.ToString(), num2.ToString())}' wait {num1*num2}");

			num1 = 123456789;
			num2 = 9876543210;
			Console.WriteLine($"'{num1}' x '{num2}' = '{sol.Multiply(num1.ToString(), num2.ToString())}' wait {num1*num2}");

			/*
Submission Result: Wrong Answer
Input:  "0"  "0"
Output:  ""
Expected:"0"
			*/
			num1 = 0;
			num2 = 0;
			Console.WriteLine($"'{num1}' x '{num2}' = '{sol.Multiply(num1.ToString(), num2.ToString())}' wait {num1*num2}");
		}

		public class Solution
		{
			public string Multiply(string num1, string num2)
			{
				List<string> partSums = new List<string>();	// at 0 pos - right char of num2 multiplied to num1
				// calculate multiplication of each digit in num2 to num1
				for (int ind = num2.Length - 1; ind >= 0; ind--)
				{
					partSums.Add(MultStrDig(num1, num2[ind]));
				}
				// collect all numbers
				int targetLength = 0;
				for (int num = 0; num < partSums.Count; num++)
				{
					if ((partSums[num].Length + num) > targetLength)
						targetLength = (partSums[num].Length + num);
				}
		//		foreach (string ms in partSums)
		//			Console.WriteLine(ms);

				string resString  = "";
				string additional = "";
				for (int ind = 0; ind <= targetLength; ind++)
				{
					for (int num = 0; num < partSums.Count; num++)
					{
						additional = AddDigit(additional, GetDigit(partSums[num], ind - num));
					}
					if (string.IsNullOrEmpty(additional))
						additional = "0";
					resString = additional[additional.Length - 1] + resString;
					additional = additional.Substring(0, additional.Length - 1);
				}
				resString = additional + resString;
				while (!string.IsNullOrEmpty(resString) && (resString[0] == '0'))
					resString = resString.Substring(1);
				if (string.IsNullOrEmpty(resString))
					resString = "0";
				return resString;
			}

			private string MultStrDig(string num1, char dig)
			{
				string resStr = "";
				int additional = 0;
				int mult = dig - '0';
				for (int ind = num1.Length - 1; ind >= 0; ind--)
				{
					int pm = ((int)(num1[ind] - '0')) * mult + additional;
					additional = pm / 10;
					resStr = (pm % 10).ToString() + resStr;
				}//for
				if (additional > 0)
					resStr = additional.ToString() + resStr;
				return resStr;
			}

			private char GetDigit(string str, int ind)
			{
				if ( (ind < 0) || string.IsNullOrEmpty(str) || (str.Length <= ind))
						return '0';
					return str[str.Length - 1 - ind];
			}

			private string AddDigit(string str, char dig)
			{
				int tt = 0;
				if (!int.TryParse(str, out tt))
				{
					tt = 0;
				}
				tt += dig - '0';
				str = tt.ToString();
				return str;
			}
		}
	}//public abstract class Problem_
}