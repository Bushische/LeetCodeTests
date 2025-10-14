using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Specialized;

namespace LeetCodeTests
{
	public abstract class Problem_0087
	{
		/*
87. Scramble String_

Given a string s1, we may represent it as a binary tree by partitioning it to two non-empty substrings recursively.

Below is one possible representation of s1 = "great":

    great
   /    \
  gr    eat
 / \    /  \
g   r  e    at
           / \
          a   t
To scramble the string, we may choose any non-leaf node and swap its two children.

For example, if we choose the node "gr" and swap its two children, it produces a scrambled string "rgeat".

    rgeat
   /    \
  rg    eat
 / \    /  \
r   g  e   at
           / \
          a   t
We say that "rgeat" is a scrambled string of "great".

Similarly, if we continue to swap the children of nodes "eat" and "at", it produces a scrambled string "rgtae".

    rgtae
   /    \
  rg    tae
 / \    /  \
r   g  ta   e
       / \
      t   a
We say that "rgtae" is a scrambled string of "great".

Given two strings s1 and s2 of the same length, determine if s2 is a scrambled string of s1.
		*/
		public static void Test()
		{
			Solution sol = new Solution();

			/*
			var input = new int[] { 2, 7, 11, 15 };
			Console.WriteLine($"Input array: {string.Join(", ", input)}");
			*/
			var word1 = "rgeat";
			var word2 = "great";
			Console.WriteLine($"Word '{word1}' is scramble of '{word2}' -> {sol.IsScramble(word1, word2)} (waits TRUE)");

			word1 = "rgtae";
			word2 = "great";
			Console.WriteLine($"Word '{word1}' is scramble of '{word2}' -> {sol.IsScramble(word1, word2)} (waits TRUE)");

			word1 = "rtgae";
			word2 = "great";
			Console.WriteLine($"Word '{word1}' is scramble of '{word2}' -> {sol.IsScramble(word1, word2)} (waits FALSE)");

			word1 = "dcba";
			word2 = "abcd";
			Console.WriteLine($"Word '{word1}' is scramble of '{word2}' -> {sol.IsScramble(word1, word2)} (waits TRUE)");

			word1 = "dabc";
			word2 = "abcd";
			Console.WriteLine($"Word '{word1}' is scramble of '{word2}' -> {sol.IsScramble(word1, word2)} (waits TRUE)");

			/*
Submission Result: Wrong Answer
Input: "abc" "bac"
Output: false
Expected:true
			*/
			word1 = "abc";
			word2 = "bac";
			Console.WriteLine($"Word '{word1}' is scramble of '{word2}' -> {sol.IsScramble(word1, word2)} (waits TRUE)");
		}

		/*
Based on the wrong answer can make assumption, separation can be made in any place of string
		*/
		public class Solution
		{
			public bool IsScramble(string s1, string s2)
			{
				if (s1.Equals(s2))
					return true;
				int mid = s1.Length / 2;
				if (mid == 0) return false;
				if (s1.Length != s2.Length)
					return false;

				#region check need process more
				// s1 should be anagram of s2
				int[] charsCounters = new int[256];
				for (int i = 0; i < s1.Length; i++)
				{
					charsCounters[s1[i]]++;
					charsCounters[s2[i]]--;
				}

				for (int i = 0; i < charsCounters.Length; i++)
					if (charsCounters[i] != 0)
						return false;       // not same char sets
				#endregion

				// devide s1 to 2 parts and 
				int len = s1.Length;
				for (int i = 1; i < len; i++)
				{
					if ((IsScramble(s1.Substring(0, i), s2.Substring(0, i)) && IsScramble(s1.Substring(i), s2.Substring(i)))
						|| (IsScramble(s1.Substring(len - i), s2.Substring(0, i)) && IsScramble(s1.Substring(0, len - i), s2.Substring(i))))
						return true;
				}
				return false;
			}


		}
	}//public abstract class Problem_
}

/*// Incorrect assumption, based on example
public class Solution
{
	public bool IsScramble(string s1, string s2)
	{
		if (s1.Equals(s2))
			return true;
		int mid = s1.Length / 2;
		if (mid == 0) return false;

		int even = s1.Length % 2;
		// 1234
		// 12 34 && 34 12
		if (even == 0)
			return ((IsScramble(s1.Substring(0, mid), s2.Substring(0, mid)) && IsScramble(s1.Substring(mid), s2.Substring(mid)))
					|| (IsScramble(s1.Substring(mid), s2.Substring(0, mid)) && IsScramble(s1.Substring(0, mid), s2.Substring(mid))));
		else
			//12345  
			// 12 345 && 123 45
			return (IsScramble(s1.Substring(0, mid), s2.Substring(0, mid)) && IsScramble(s1.Substring(mid), s2.Substring(mid))
					|| (IsScramble(s1.Substring(mid + 1), s2.Substring(0, mid)) && IsScramble(s1.Substring(0, mid + 1), s2.Substring(mid))));
	}


}
*/