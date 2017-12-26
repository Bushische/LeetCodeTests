using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Specialized;

namespace LeetCodeTests
{
	public abstract class Problem_0067
	{
		/*
Given two binary strings, return their sum(also a binary string).

For example,
a = "11"
b = "1"
Return "100".
		*/
		public static void Test()
		{
			Solution sol = new Solution();

			/*
			var input = new int[] { 2, 7, 11, 15 };
			Console.WriteLine($"Input array: {string.Join(", ", input)}");
			*/
			string a = "11";
			string b = "1";
			Console.WriteLine($"'{a}' + '{b}' = '{sol.AddBinary(a, b)}'");

			a = "1111111111";
			b = "1";
			Console.WriteLine($"'{a}' + '{b}' = '{sol.AddBinary(a, b)}'");

			a = "1111101111";
			b = "10";
			Console.WriteLine($"'{a}' + '{b}' = '{sol.AddBinary(a, b)}'");
		}

		/// <summary>
		/// Based on the one of discussion post
		/// </summary>
		public class Solution
		{
			public string AddBinary(string a, string b)
			{
				#region initial checks
				if (string.IsNullOrEmpty(a))
					return b;
				if (string.IsNullOrEmpty(b))
					return a;
				#endregion

				string result = "";
				int acc = 0;
				int indA = a.Length - 1;
				int indB = b.Length - 1;
				while ((indA >= 0) || (indB >= 0) || (acc > 0))
				{
					acc += (indA >= 0) ? (a[indA] - '0') : 0;
					acc += (indB >= 0) ? (b[indB] - '0') : 0;
					result = (char)((acc % 2) + '0') + result;
					acc = acc / 2;
					indA--;
					indB--;
				}
				return result;
			}
		}

		/// <summary>
		/// to long solution
		/// </summary>
		public class Solution_passed
		{
			public string AddBinary(string a, string b)
			{
				if (string.IsNullOrEmpty(a))
					return b;
				if (string.IsNullOrEmpty(b))
					return a;
				
				Func<string, int, int> getAtPosition = (str, ind) =>
				{
					if ((string.IsNullOrEmpty(str)) || (str.Length <= ind))
						return 0;
					return (int)(str[str.Length - ind-1]-'0');
				};
				string result = "";
				int additional = 0;
				for (int ind = 0; ind < Math.Max(a.Length, b.Length); ind++)
				{
					int acc = getAtPosition(a, ind) + getAtPosition(b, ind) + additional;
					additional = acc / 2;
					result = (acc % 2).ToString() + result;
				}
				if (additional > 0)
					result = additional.ToString() + result;
				return result;
			}
		}
	}//public abstract class Problem_
}