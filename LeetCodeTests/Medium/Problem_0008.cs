using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Specialized;

namespace LeetCodeTests
{
	public abstract class Problem_0008
	{
		/*
Implement atoi to convert a string to an integer.

Hint: Carefully consider all possible input cases. If you want a challenge, please do not see below and ask yourself what are the possible input cases.

Notes: It is intended for this problem to be specified vaguely (ie, no given input specs). You are responsible to gather all the input requirements up front.

Update (2015-02-10):
The signature of the C++ function had been updated.If you still see your function signature accepts a const char* argument, please click the reload button to reset your code definition.

	Requirements for atoi:
	The function first discards as many whitespace characters as necessary until the first non-whitespace character is found.Then, starting from this character, takes an optional initial plus or minus sign followed by as many numerical digits as possible, and interprets them as a numerical value.

	The string can contain additional characters after those that form the integral number, which are ignored and have no effect on the behavior of this function.

	If the first sequence of non-whitespace characters in str is not a valid integral number, or if no such sequence exists because either str is empty or it contains only whitespace characters, no conversion is performed.

	If no valid conversion could be performed, a zero value is returned.If the correct value is out of the range of representable values, INT_MAX (2147483647) or INT_MIN (-2147483648) is returned.

cases:
* negative numbers
* decimal numbers
* spaces between numbers
* dots between numbers
		*/
		public static void Test()
		{
			Solution sol = new Solution();

			/*
			var input = new int[] { 2, 7, 11, 15 };
			Console.WriteLine($"Input array: {string.Join(", ", input)}");
			*/
			string input = "-1234";
			Console.WriteLine($"input is '{input}' func output is '{sol.MyAtoi(input)}'");

			input = "+12asd";
			Console.WriteLine($"input is '{input}' func output is '{sol.MyAtoi(input)}'");

			input = "";
			Console.WriteLine($"input is '{input}' func output is '{sol.MyAtoi(input)}'");

			input = null;
			Console.WriteLine($"input is '{input}' func output is '{sol.MyAtoi(input)}'");

			// "-" index out of range
			input = "-";
			Console.WriteLine($"input is '{input}' func output is '{sol.MyAtoi(input)}'");

			/*
			Input:"-2147483648"
			Output:0
			Expected:-2147483648
			*/
			input = "-2147483648";
			Console.WriteLine($"input is '{input}' func output is '{sol.MyAtoi(input)}'");

			/*
			Input:"2147483648"
			Output:0
			Expected:2147483647
			*/
			input = "2147483648";
			Console.WriteLine($"input is '{input}' func output is '{sol.MyAtoi(input)}'");

			input = "-2147483649";
			Console.WriteLine($"input is '{input}' func output is '{sol.MyAtoi(input)}'");
		}

		public class Solution
		{
			public int MyAtoi(string str)
			{
				if (string.IsNullOrEmpty(str)) return 0;

				int maxIndex = str.Length;
				int index = 0;

				//skip whitespaces
				while ((str[index] == ' ') && (index < maxIndex))
				{
					index++;
				}

				if (index >= maxIndex) return 0;

				int sign = 1;
				int resNumber = 0;
				if (str[index] == '-')
				{
					sign = -1;
					index++;
				}
				else if (str[index] == '+')
					index++;

				while (index < maxIndex)
				{
					if ((str[index] >= '0') && (str[index] <= '9'))
					{
						try
						{
							resNumber = checked(resNumber * 10 + (int)(str[index] - '0')*sign);
							index++;
						}
						catch (ArithmeticException)
						{
							if (sign > 0)
								return int.MaxValue;
							else
								return int.MinValue;
							//string sex = ex.ToString();
							//return 0;
						}
					}
					else
					{
						index = maxIndex;       // to stop parsing
					}
				}
				//return resNumber * sign;
				return resNumber;
			}

			public int MyAtoi_no(string str)
			{
				if (string.IsNullOrEmpty(str)) return 0;

				//skip whitespaces
				while ((!string.IsNullOrEmpty(str)) && (str.StartsWith(" ", StringComparison.InvariantCulture)))
				{
					str = str.Substring(1);
				}

				if (string.IsNullOrEmpty(str)) return 0;

				int sign = 1;
				int resNumber = 0;
				if (str[0] == '-')
				{
					sign = -1;
					str = str.Substring(1);
				}
				if (str[0] == '+')
					str = str.Substring(1);

				while (str.Length > 0)
				{
					if ((str[0] >= '0') && (str[0] <= '9'))
					{
						resNumber = resNumber * 10 + (int)(str[0] - '0');
						str = str.Substring(1);
					}
					else
					{
						str = "";       // to stop parsing
					}
				}
				return resNumber * sign;
			}
		}
	}//public abstract class Problem_
}