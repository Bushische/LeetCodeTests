using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Specialized;

namespace LeetCodeTests
{
	public abstract class Problem_0005
	{
		/*
Given a string s, find the longest palindromic substring in s.You may assume that the maximum length of s is 1000.

Example:
Input: "babad"
Output: "bab"
Note: "aba" is also a valid answer.

Example:
Input: "cbbd"
Output: "bb"
		*/
		public static void Test()
		{
			Solution sol = new Solution();

			/*
			var input = new int[] { 2, 7, 11, 15 };
			Console.WriteLine($"Input array: {string.Join(", ", input)}");
			*/

			//Console.WriteLine($"check for palindrome 'abasd' = {sol.IsPalindrome("abasd")}");
			//Console.WriteLine($"check for palindrome 'ababa' = {sol.IsPalindrome("ababa")}");
			Console.WriteLine($"check for palindrome 'ababa' = {sol.FindPalindromFromCenter("ababa", 2, 2)}");
			Console.WriteLine($"check for palindrome 'bb' = {sol.FindPalindromFromCenter("bb", 0, 0)}");
			Console.WriteLine($"check for palindrome 'bb' = {sol.FindPalindromFromCenter("bb", 0, 1)}");

			var input = "babad";
			Console.WriteLine($"For input '{input}' longest palindrome is '{sol.LongestPalindrome(input)}'. Waits 'bab'/'aba'");

			input = "cbbd";
			Console.WriteLine($"For input '{input}' longest palindrome is '{sol.LongestPalindrome(input)}'. Waits 'bb'");

			input = "abcdefgh";		// nothing
			Console.WriteLine($"For input '{input}' longest palindrome is '{sol.LongestPalindrome(input)}'. Waits 'a'/''b'...");

			input = "abcdcefgh";
			Console.WriteLine($"For input '{input}' longest palindrome is '{sol.LongestPalindrome(input)}'. Waits 'cdc'");

			// wrong attempt:
			//Input:"bb"
			//Output:""
			input = "bb";
			Console.WriteLine($"For input '{input}' longest palindrome is '{sol.LongestPalindrome(input)}'. Waits 'bb'");

			// wrong attempt:
			//Input:"abcda"
			//Output:""
			//Expected:"a"
			input = "abcda";
			Console.WriteLine($"For input '{input}' longest palindrome is '{sol.LongestPalindrome(input)}'. Waits 'a'");

			// TimeLimit :
			//Last executed input: "anugnxshgonmqydttcvmtsoaprxnhpmpovdolbidqiyqubirkvhwppcdyeouvgedccipsvnobrccbndzjdbgxkzdb
			//cjsjjovnhpnbkurxqfupiprpbiwqdnwaqvjbqoaqzkqgdxkfczdkznqxvupdmnyiidqpnbvgjraszbvvztpapxmomnghfaywkzlrupvjpcvascgvst
			//qmvuveiiixjmdofdwyvhgkydrnfuojhzulhobyhtsxmcovwmamjwljioevhafdlpjpmqstguqhrhvsdvinphejfbdvrvabthpyyphyqharjvzriosr
			//dnwmaxtgriivdqlmugtagvsoylqfwhjpmjxcysfujdvcqovxabjdbvyvembfpahvyoybdhweikcgnzrdqlzusgoobysfmlzifwjzlazuepimhbgkrf
			//immemhayxeqxynewcnynmgyjcwrpqnayvxoebgyjusppfpsfeonfwnbsdonucaipoafavmlrrlplnnbsaghbawooabsjndqnvruuwvllpvvhuepmqt
			//prgktnwxmflmmbifbbsfthbeafseqrgwnwjxkkcqgbucwusjdipxuekanzwimuizqynaxrvicyzjhulqjshtsqswehnozehmbsdmacciflcgsrlyhj
			//ukpvosptmsjfteoimtewkrivdllqiotvtrubgkfcacvgqzxjmhmmqlikrtfrurltgtcreafcgisjpvasiwmhcofqkcteudgjoqqmtucnwcocsoiqtfuoazxdayricnmwcg"
		}

		public class Solution
		{
			public string LongestPalindrome(string s)
			{
				if (string.IsNullOrEmpty(s))
					return "";
				if (s.Length< 2)
					return s;
				
				string maxPal = "";
				string tmp = "";
				// try to find palindrom from it center 
				for (int i = 0; i < s.Length - 1; i++)
				{
					tmp = FindPalindromFromCenter(s, i, i);
					if (tmp.Length > maxPal.Length)
						maxPal = tmp;
					tmp = FindPalindromFromCenter(s, i, i + 1);
					if (tmp.Length > maxPal.Length)
						maxPal = tmp;
				}
				return maxPal;
			}
			public string FindPalindromFromCenter(string s, int left, int right)
			{
				while ((left >= 0) && (right < s.Length) && (s[left] == s[right]))
				{
					left--;
					right++;
				}

				left++;
				right--;
				if (left > right)
					return "";
				return s.Substring(left, (right - left + 1));
			}


			public string LongestPalindrome_longTime(string s)
			{
				// need check all 2 char strings
				// all 3 char strings
				// all ... 
				// all N char strings
				// better start from end. If we found palindrom length J, we not need look for palindrom length I (I < J)
				if (string.IsNullOrEmpty(s))
					return "";
				if (s.Length < 2)
					return s;
				for (int j = s.Length; j >= 1; j--)		// for all lengths
				{
					for (int i = 0; i <= s.Length - j; i++) // for all substring with length j
					{
						if (IsPalindrome(s.Substring(i, j)))
							return s.Substring(i, j);
					}
				}
				return "";
			}	// O(n^2)*O(n) = O(n^3)

			private bool IsPalindrome(string s)
			{
				if (string.IsNullOrEmpty(s))
					return false;
				int left = 0;
				int right = s.Length - 1;
				while (left < right)
				{
					if (s[left] != s[right])
						return false;
					left++;
					right--;
				}
				return true;
			}	// O(n)
		}
	}//public abstract class Problem_
}