using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Specialized;

namespace LeetCodeTests
{
	public abstract class Problem_0065
	{
		/*
Validate if a given string is numeric.

Some examples:
"0" => true
" 0.1 " => true
"abc" => false
"1 a" => false
"2e10" => true
Note: It is intended for the problem statement to be ambiguous.You should gather all requirements up front before implementing one.

Update (2015-02-10):
The signature of the C++ function had been updated.If you still see your function signature accepts a const char* argument, please click the reload button to reset your code definition.
		*/
		public static void Test()
		{
			Solution sol = new Solution();

			/*
			var input = new int[] { 2, 7, 11, 15 };
			Console.WriteLine($"Input array: {string.Join(", ", input)}");
			*/
			var input = "0";
			Console.WriteLine($"Input '{input}' -> is Number = '{sol.IsNumber(input)}' waits TRUE");

			input = " 0.1 ";
			Console.WriteLine($"Input '{input}' -> is Number = '{sol.IsNumber(input)}' waits TRUE");

			input = "abc";
			Console.WriteLine($"Input '{input}' -> is Number = '{sol.IsNumber(input)}' waits FALSE");

			input = "1 a";
			Console.WriteLine($"Input '{input}' -> is Number = '{sol.IsNumber(input)}' waits FALSE");

			input = "2e10";
			Console.WriteLine($"Input '{input}' -> is Number = '{sol.IsNumber(input)}' waits TRUE");

			input = "-123";
			Console.WriteLine($"Input '{input}' -> is Number = '{sol.IsNumber(input)}' waits TRUE");

			input = "-2e-10";
			Console.WriteLine($"Input '{input}' -> is Number = '{sol.IsNumber(input)}' waits TRUE");

			input = "-2e";
			Console.WriteLine($"Input '{input}' -> is Number = '{sol.IsNumber(input)}' waits FALSE");

			input = "-.093";
			Console.WriteLine($"Input '{input}' -> is Number = '{sol.IsNumber(input)}' waits TRUE");
			/*
Submission Result: Runtime Error 
Runtime Error Message: Line 32: System.IndexOutOfRangeException: Index was outside the bounds of the array.
Last executed input:"e"
			*/
			input = "e";
			Console.WriteLine($"Input '{input}' -> is Number = '{sol.IsNumber(input)}' waits FALSE");

			/*
Submission Result: Wrong Answer
Input:   ".1"
Output:  false
Expected:true
			*/
			input = ".1";
			Console.WriteLine($"Input '{input}' -> is Number = '{sol.IsNumber(input)}' waits TRUE");

			/*
Submission Result: Wrong Answer
Input:	 "."
Output:  true
Expected:false
			*/
			input = ".";
			Console.WriteLine($"Input '{input}' -> is Number = '{sol.IsNumber(input)}' waits FALSE");

			input = "1.";
			Console.WriteLine($"Input '{input}' -> is Number = '{sol.IsNumber(input)}' waits TRUE");

			/*
Submission Result: Wrong Answer 
Input:   " +0e-"
Output:  true
Expected:false
			*/
			input = " +0e-";
			Console.WriteLine($"Input '{input}' -> is Number = '{sol.IsNumber(input)}' waits FALSE");

			/*
Submission Result: Wrong Answer 
Input:   " 005047e+6"
Output:	 false
Expected:true
			*/
			input = " 005047e+6";
			Console.WriteLine($"Input '{input}' -> is Number = '{sol.IsNumber(input)}' waits TRUE");

		}


		/*
Rules:
1. All spaces from left or end - is OK
2. Any symbol not digit, point or e - is not OK
3. Only one '-' or '+' on leading position is acepted, or after 'e':  2e-10 - it is OK

123
-123
+123
1.123
2e-10
2e14
-2e-3
		*/

		public class Solution
		{
			private HashSet<char> digitChars = new HashSet<char>() { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

			public bool IsNumber(string s)
			{
				if (string.IsNullOrEmpty(s))
					return false;

				int left = 0;
				int right = s.Length-1;
				// skip all spaces
				while ((s[left] == ' ') && (left < right)) left++;
				while ((s[right] == ' ') && (left < right)) right--;

				int eind = s.ToLower().IndexOf('e', left);
				if (eind > -1)
					return CheckBase(s.Substring(left, eind - left)) && CheckExp(s.Substring(eind+1, right - eind));
				else
					return CheckBase(s.Substring(left, right - left+1));
			}

			/// <summary>
			/// Check left part of number (before E)
			/// Can start from '-' or '+', can contains '.'. But only one of them.
			/// </summary>
			/// <returns><c>true</c>, if base was checked, <c>false</c> otherwise.</returns>
			/// <param name="s">S.</param>
			private bool CheckBase(string s)
			{
				if (string.IsNullOrEmpty(s))
					return false;
				int ind = 0;
				if ((s[ind] == '-') || (s[ind] == '+'))
					ind++;
				int dotCounter = 0;
				bool wasNumbers = false;
				for (int i = ind; i < s.Length; i++)
				{
					if (s[i] == '.')
					{
						//if (i == ind) return false;     // number can not starts from '.' (???)
						dotCounter++;
						if (dotCounter > 1)
							return false;               // only ONE '.' is possible
					}
					else if (!digitChars.Contains(s[i]))
						return false;
					else
						wasNumbers = true;
				}
				return wasNumbers;
			}

			/// <summary>
			/// Check right part of number (after E)
			/// Can start from '-', but not possible for '+' or '.'
			/// </summary>
			/// <returns><c>true</c>, if exp was checked, <c>false</c> otherwise.</returns>
			/// <param name="s">S.</param>
			private bool CheckExp(string s)
			{
				if (string.IsNullOrEmpty(s))
					return false;	// empty EXP part is unacceptable
				int ind = 0;
				if ((s[ind] == '-') || (s[ind] == '+'))
					ind++;
				bool wasNumbers = false;
				for (int i = ind; i < s.Length; i++)
				{
					if (!digitChars.Contains(s[i]))
						return false;
					wasNumbers = true;
				}
				return wasNumbers;
			}
		}
	}//public abstract class Problem_
}