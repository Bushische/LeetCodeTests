using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Specialized;

namespace LeetCodeTests
{
	public abstract class Problem_0020
	{
		/*
Given a string containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.
The brackets must close in the correct order, "()" and "()[]{}" are all valid but "(]" and "([)]" are not.
		*/
		public static void Test()
		{
			Solution sol = new Solution();

			/*
			var input = new int[] { 2, 7, 11, 15 };
			Console.WriteLine($"Input array: {string.Join(", ", input)}");
			*/

			var input = "()";
			Console.WriteLine($"for input '{input}' output '{sol.IsValid(input)}' (waits TRUE)");

			input = "[]";
			Console.WriteLine($"for input '{input}' output '{sol.IsValid(input)}' (waits TRUE)");

			input = "{}";
			Console.WriteLine($"for input '{input}' output '{sol.IsValid(input)}' (waits TRUE)");

			input = "()[]{}";
			Console.WriteLine($"for input '{input}' output '{sol.IsValid(input)}' (waits TRUE)");

			input = "(]";
			Console.WriteLine($"for input '{input}' output '{sol.IsValid(input)}' (waits FALSE)");

			input = "(])[";
			Console.WriteLine($"for input '{input}' output '{sol.IsValid(input)}' (waits FALSE)");
       // wrong attempts
			input = ")";
			Console.WriteLine($"for input '{input}' output '{sol.IsValid(input)}' (waits FALSE)");

			input = "[";
			Console.WriteLine($"for input '{input}' output '{sol.IsValid(input)}' (waits FALSE)");


			input = "(([{([{}])}]))";
			Console.WriteLine($"for input '{input}' output '{sol.IsValid(input)}' (waits TRUE)");
		}

		public class Solution
		{   // with using stack
			// for ")" - error
			public bool IsValid(string s)
			{
				if (string.IsNullOrEmpty(s))
					return true;
				System.Collections.Stack closesbr = new System.Collections.Stack();
				for (int index = 0; index < s.Length; index++)
				{
					switch (s[index])
					{
						case '(': closesbr.Push(')'); break;
						case '{': closesbr.Push('}'); break;
						case '[': closesbr.Push(']'); break;
						default: {
								if ((closesbr.Count == 0)
								    || (s[index] != (char)closesbr.Pop()))
									return false;
								break;
						}
					}
				}
				return closesbr.Count == 0;
			}
		}

		public class Solution_noGood
		{
			public bool IsValid(string s)
			{
				if (string.IsNullOrEmpty(s))
					return true;
				string acc = "";
				Dictionary<char, char> closeOpen = new Dictionary<char, char>() { { ')', '(' }, { '}', '{' }, { ']', '[' } };

				for (int index = 0; index < s.Length; index++)
				{
					if ("({[".IndexOf(s[index]) > -1)
						acc += s[index];
					else if (closeOpen.ContainsKey(s[index]))
					{
						if (string.IsNullOrEmpty(acc))
							return false;
						if (acc[acc.Length - 1] == closeOpen[s[index]])
						{
							acc = acc.Substring(0, acc.Length - 1);	// remove last bracket
						}
						else
							return false;
					}
				}
				return string.IsNullOrEmpty(acc);
			}
		}
	}//public abstract class Problem_
}