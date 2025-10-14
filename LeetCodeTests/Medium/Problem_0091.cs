using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Specialized;

namespace LeetCodeTests
{
	public abstract class Problem_0091
	{
		/*
91. Decode Ways

A message containing letters from A-Z is being encoded to numbers using the following mapping:

'A' -> 1
'B' -> 2
...
'Z' -> 26
Given an encoded message containing digits, determine the total number of ways to decode it.

For example,
Given encoded message "12", it could be decoded as "AB" (1 2) or "L" (12).

The number of ways decoding "12" is 2.


		*/
		public static void Test()
		{
			Solution sol = new Solution();

			/*
			var input = new int[] { 2, 7, 11, 15 };
			Console.WriteLine($"Input array: {string.Join(", ", input)}");
			*/
			string s = "12";
			Console.WriteLine($"String '{s}' can be decoded with {sol.NumDecodings(s)} ways (=2)");

			s = "27";
			Console.WriteLine($"String '{s}' can be decoded with {sol.NumDecodings(s)} ways (=1)");

			s = "126";
			Console.WriteLine($"String '{s}' can be decoded with {sol.NumDecodings(s)} ways (=3)");

			s = "103456789";
			Console.WriteLine($"String '{s}' can be decoded with {sol.NumDecodings(s)} ways (=1)");

			/*
Submission Result: Wrong Answer
Input:""
Output:1
Expected:0
			*/
			s = "";
			Console.WriteLine($"String '{s}' can be decoded with {sol.NumDecodings(s)} ways (=0)");

			/*
Submission Result: Wrong Answer
Input:"0"
Output:1
Expected:0
			*/
			s = "0";
			Console.WriteLine($"String '{s}' can be decoded with {sol.NumDecodings(s)} ways (=0)");

			/*
Submission Result: Wrong Answer
Input:"10"
Output:2
Expected:1
			*/
			s = "10";
			Console.WriteLine($"String '{s}' can be decoded with {sol.NumDecodings(s)} ways (=1)");

			/*
Submission Result: Wrong Answer
Input:"00"
Output:1
Expected:0
			*/
			s = "00";
			Console.WriteLine($"String '{s}' can be decoded with {sol.NumDecodings(s)} ways (=0)");

			/*
Submission Result: Wrong Answer
Input:"01"
Output:1
Expected:0
			*/
			s = "01";
			Console.WriteLine($"String '{s}' can be decoded with {sol.NumDecodings(s)} ways (=0)");

			/*
Submission Result: Wrong Answer
Input:"110"
Output:0
Expected:1
			*/
			s = "110";
			Console.WriteLine($"String '{s}' can be decoded with {sol.NumDecodings(s)} ways (=1)");

			/*
Submission Result: Time Limit Exceeded
Last executed input:
"1787897759966261825913315262377298132516969578441236833255596967132573482281598412163216914566534565"
			*/
			s = "1787897759966261825913315262377298132516969578441236833255596967132573482281598412163216914566534565";
			Console.WriteLine($"String '{s}' can be decoded with {sol.NumDecodings(s)} ways (=?)");

		}

		public class Solution
		{
			public int NumDecodings(string s)
			{
				if (string.IsNullOrEmpty(s)) return 0;
				if (s[0] == '0') return 0;

				int waysCur = 1;		// ... prev cur ...
				int waysPrev = 1;
				int waysTmp = 0;

				for (int i = 1; i < s.Length; i++)
				{
					waysTmp = 0;
					if (s[i] != '0')
						waysTmp += waysCur;
					if ((s[i - 1] == '1') || ((s[i - 1] == '2') && (s[i] < '7')))
						waysTmp += waysPrev;
					waysPrev = waysCur;
					waysCur = waysTmp;
				}
				return waysCur;
			}

			public int NumDecodings_copypaste(string s)
			{
				if (string.IsNullOrEmpty(s)) return 0;
				if (s[0] == '0')
					return 0;

				int f0 = 1;
				int f1 = 1;
				int f2;
				for (int i = 2; i <= s.Length; i++)
				{
					f2 = f1 * ((s[i - 1] != '0') ? 1 : 0) + f0 * (((s[i-2]=='1') || ((s[i-2]=='2') && (s[i-1]<'7')))?1:0);
					f0 = f1;
					f1 = f2;
				}
				return f1;
			}
		}
		/*
int numDecodings(string s)
{
	int n = s.size();
	if (!n || s[0] == '0')
		return 0;
	int f0 = 1, f1 = 1, f2, i;
	for (i = 2; i <= n; ++i)
	{
		f2 = (int)(s[i - 1] != '0') * f1 + (int)((s[i - 2] == '1') || (s[i - 2] == '2' && s[i - 1] < '7')) * f0;
		f0 = f1;
		f1 = f2;
	}
	return f1;
}
		*/
		/// <summary>
		/// Time limited solution
		/// </summary>
		public class Solution_TL
		{
			public int NumDecodings(string s)
			{
				if (string.IsNullOrEmpty(s))
					return 0;
				return WaysToDecode(s, 0);
			}

			/// <summary>
			/// Calculate ways to decode part of string S starting from StartPos
			/// </summary>
			/// <returns>The to decode.</returns>
			/// <param name="s">S.</param>
			/// <param name="startPos">Start position.</param>
			private int WaysToDecode(string s, int startPos)
			{
				int resWays = 0;
				if (startPos >= s.Length)
					return 1;
				if (s[startPos] == '0')
					return 0;
				if (startPos <= s.Length - 2)
				{
					int secNum = (s[startPos + 1] - '0');
					if ((secNum == 0) && ((s[startPos] == '1') || (s[startPos] == '2')))
						resWays = WaysToDecode(s, startPos + 2);
					else if ((s[startPos] == '1')
						|| ((s[startPos] == '2') && (secNum  <= 6)))
					{
						resWays = WaysToDecode(s, startPos + 2) + WaysToDecode(s, startPos+1);
					}
					else
						resWays = WaysToDecode(s, startPos+1);
				}
				else
					resWays = WaysToDecode(s, startPos + 1);
					
				return resWays;
			}
		}


	}//public abstract class Problem_
}

/*
1111
1 1 1 1
1 1 11
1 11 1
11 1 1
11 11

*/