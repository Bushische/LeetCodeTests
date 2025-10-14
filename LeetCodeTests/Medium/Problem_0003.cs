using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Specialized;

namespace LeetCodeTests
{
	public abstract class Problem_0003
	{
		/*
Given a string, find the length of the longest substring without repeating characters.

Examples:

Given "abcabcbb", the answer is "abc", which the length is 3.

Given "bbbbb", the answer is "b", with the length of 1.

Given "pwwkew", the answer is "wke", with the length of 3. Note that the answer must be a substring, "pwke" is a subsequence and not a substring.

		*/
		public static void Test()
		{
			Solution sol = new Solution();

			/*
			var input = new int[] { 2, 7, 11, 15 };
			Console.WriteLine($"Input array: {string.Join(", ", input)}");
			*/
			string s = "abcabcbb";
			Console.WriteLine($"for line '{s}' answer is {sol.LengthOfLongestSubstring(s)} (should be 3)");

			s = "bbbbbb";
			Console.WriteLine($"for line '{s}' answer is {sol.LengthOfLongestSubstring(s)} (should be 1)");

			s = "pwwkew";
			Console.WriteLine($"for line '{s}' answer is {sol.LengthOfLongestSubstring(s)} (should be 3)");

			s = "ababababba";
			Console.WriteLine($"for line '{s}' answer is {sol.LengthOfLongestSubstring(s)} (should be 2)");

			s = "1234567";
			Console.WriteLine($"for line '{s}' answer is {sol.LengthOfLongestSubstring(s)} (should be 7)");
		}

		public class Solution
		{
			public int LengthOfLongestSubstring(string s)
			{
				// main idea: build uniq substring until nonunique character will be found.
				// calculate length and stores as max (if need)
				// remove first symbols from left upto first nonunique character meet
				// add nonunique character to the end
				string substr = "";
				int maxLength = 0;
				int index = 0;
				while (index < s.Length)
				{
					char curchar = s[index];
					if (substr.IndexOf(curchar) != -1)  // non unique character is founded
					{
						maxLength = Math.Max(maxLength, substr.Length);
						substr = substr.Substring(substr.IndexOf(curchar) + 1);
					}
					substr += curchar;
					index++;
				}
				maxLength = Math.Max(maxLength, substr.Length);
				return maxLength;
			}
		}//
	}
}

/*
Java(Using HashMap)

public class Solution
{
	public int lengthOfLongestSubstring(String s)
	{
		int n = s.length(), ans = 0;
		Map<Character, Integer> map = new HashMap<>(); // current index of character
													   // try to extend the range [i, j]
		for (int j = 0, i = 0; j < n; j++)
		{
			if (map.containsKey(s.charAt(j)))
			{
				i = Math.max(map.get(s.charAt(j)), i);
			}
			ans = Math.max(ans, j - i + 1);
			map.put(s.charAt(j), j + 1);
		}
		return ans;
	}
}

*/