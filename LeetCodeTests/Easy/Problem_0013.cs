using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Specialized;

namespace LeetCodeTests
{
	public abstract class Problem_0013
	{
		/*
Given a roman numeral, convert it to an integer.
Input is guaranteed to be within the range from 1 to 3999.

Symbol  I   V 	X   L 	C   D 	M
Value	1	5	10	50	100	500	1,000
----

XXX - 30
XXIX - 29
XXVIII - 28
MCM - 1900
MCMLXXXIV - 1984
1 -> I
4 -> IV
8 -> VIII
9 -> IX

---
If y < x and y placed before x than x-y
correct?: XXIVX = ?
IIX = 8?
		*/
		public static void Test()
		{
			Solution sol = new Solution();

			/*
			var input = new int[] { 2, 7, 11, 15 };
			Console.WriteLine($"Input array: {string.Join(", ", input)}");
			*/


			string input = "XXX";
			int waits = 30;
			Console.WriteLine($"Roman '{input}' is equal to '{sol.RomanToInt(input)}' wait '{waits}'");

			input = "XXIX";
			waits = 29;
			Console.WriteLine($"Roman '{input}' is equal to '{sol.RomanToInt(input)}' wait '{waits}'");

			input = "XXVIII";
			waits = 28;
			Console.WriteLine($"Roman '{input}' is equal to '{sol.RomanToInt(input)}' wait '{waits}'");

			input = "MCM";
			waits = 1900;
			Console.WriteLine($"Roman '{input}' is equal to '{sol.RomanToInt(input)}' wait '{waits}'");

			input = "MCMLXXXIV";
			waits = 1984;
			Console.WriteLine($"Roman '{input}' is equal to '{sol.RomanToInt(input)}' wait '{waits}'");

			input = "VL";
			waits = 45;
			Console.WriteLine($"Roman '{input}' is equal to '{sol.RomanToInt(input)}' wait '{waits}'");

			input = "XLV";
			waits = 45;
			Console.WriteLine($"Roman '{input}' is equal to '{sol.RomanToInt(input)}' wait '{waits}'");
		}

		public class Solution
		{

			public int RomanToInt(string s)
			{
				if (string.IsNullOrEmpty(s))
					return 0;

				Dictionary<char, int> Romans = new Dictionary<char, int>() { { 'I', 1 }, { 'V', 5 },
								{ 'X', 10 }, { 'L', 50 },{ 'C', 100 },{ 'D', 500 },{'M', 1000 } };

				// read number from left to right
				// collect letters until same value or bigger will be met
				// if meet same or less letter - add previos part to accumulator

				// assume it is only one element for minus can be met
				int res = 0;
				int index = 0;
				int? prev = null;
				int cur = 0;

				while (index < s.Length)
				{
					cur = Romans[s[index]];
					if (cur <= (prev ?? 0))
					{
						res += prev ?? 0;
						prev = cur;
					}
					else
					{
						if (prev.HasValue)
						{
							res += cur - prev.Value;
							prev = null;
						}
						else
							prev = cur;
					}

					index++;
				}//while
				if (prev.HasValue)
					res += prev.Value;

				return res;
			}
		}
	}//public abstract class Problem_

	/*
cool solution - read number from right to left;
public:
    int romanToInt(string s)
{
	unordered_map<char, int> T = { { 'I', 1 }, { 'V', 5 }, { 'X', 10 }, { 'L', 50 }, { 'C', 100 }, { 'D', 500 }, { 'M', 1000 } };
	int sum = T[s.back()];
	for (int i = s.length() - 2; i >= 0; --i)
	{
		sum += (T[s[i]] < T[s[i + 1]] ? -T[s[i]] : T[s[i]]);
	}
	return sum;
}
	*/
}