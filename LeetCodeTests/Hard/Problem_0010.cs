using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Specialized;

namespace LeetCodeTests
{
	public abstract class Problem_0010
	{
		/*
Implement regular expression matching with support for '.' and '*'.

'.' Matches any single character.
'*' Matches zero or more of the preceding element.
	!!! * - refer to previos character c* = zero 'c' or >=1 'c' character

The matching should cover the entire input string (not partial).

The function prototype should be:
bool isMatch(const char* s, const char* p)

Some examples:
isMatch("aa","a") → false
isMatch("aa","aa") → true
isMatch("aaa","aa") → false
isMatch("aa", "a*") → true
isMatch("aa", ".*") → true
isMatch("ab", ".*") → true
isMatch("aab", "c*a*b") → true

		*/
		public static void Test()
		{
			Solution sol = new Solution();

			/*
			var input = new int[] { 2, 7, 11, 15 };
			Console.WriteLine($"Input array: {string.Join(", ", input)}");
			*/
			Console.WriteLine($"isMatch(\"aa\",\"a\") → {sol.IsMatch("aa", "a")} → false");
			Console.WriteLine($"isMatch(\"aa\",\"aa\") → {sol.IsMatch("aa", "aa")} → true");
			Console.WriteLine($"isMatch(\"aaa\",\"aa\") → {sol.IsMatch("aaa", "aa")} → false");
			Console.WriteLine($"isMatch(\"aa\", \"..\") → {sol.IsMatch("aa", "..")} → true");
			Console.WriteLine($"isMatch(\"aa\", \"a*\") → {sol.IsMatch("aa", "a*")} → true");
			Console.WriteLine($"isMatch(\"aaa\", \"a*\") → {sol.IsMatch("aaa", "a*")} → true");
			Console.WriteLine($"isMatch(\"aa\", \".*\") → {sol.IsMatch("aa", ".*")} → true");
			Console.WriteLine($"isMatch(\"ab\", \".*\") → {sol.IsMatch("ab", ".*")} → true");
			Console.WriteLine($"isMatch(\"aab\", \"c*a*b\") → {sol.IsMatch("aab", "c*a*b")} → true");

			Console.WriteLine($"isMatch(\"aabcda\", \".*\") → {sol.IsMatch("aabcda", ".*")} → true");
			Console.WriteLine($"isMatch(\"aabcda\", \".*e\") → {sol.IsMatch("aabcda", ".*e")} → false");

			/*   Submission Result: Wrong Answer
Input:"a" "ab*"
Output: false
Expected: true
			*/
			Console.WriteLine($"isMatch(\"a\", \"ab*\") → {sol.IsMatch("a", "ab*")} → true");
		}

		public class Solution
		{
			public bool IsMatch(string s, string p)
			{
				var pattern = ParsePattern(p);
				return prvMatch(s, pattern, 0, 0);
			}

			enum ApplyRule
			{
				Once,
				ZeroOrMore
			}

			/// <summary>
			/// Char sustitution rules
			/// </summary>
			class CharSubs
			{
				public char Char { get; set; }
				public ApplyRule Rule {get; set;}
			}

			/// <summary>
			/// Convert pattern to char apply rule list
			/// </summary>
			/// <returns>The pattern.</returns>
			/// <param name="inPat">In pat.</param>
			private IList<CharSubs> ParsePattern(string inPat)
			{
				List<CharSubs> resList = new List<CharSubs>();
				if (string.IsNullOrEmpty(inPat))
					return resList;
				int chindex = inPat.Length - 1;
				while (chindex >= 0)
				{
					if (inPat[chindex] == '*')
					{
						chindex--;
						resList.Insert(0, new CharSubs() { Char = inPat[chindex], Rule = ApplyRule.ZeroOrMore });
					}
					else
					{
						resList.Insert(0, new CharSubs() { Char = inPat[chindex], Rule = ApplyRule.Once });
					}
					chindex--;
				}
				return resList;
			}

			/// <summary>
			/// recursively check string and pattern char by char
			/// </summary>
			/// <returns><c>true</c>, if match was prved, <c>false</c> otherwise.</returns>
			/// <param name="str">String.</param>
			/// <param name="pat">Pat.</param>
			/// <param name="strIndex">String index.</param>
			/// <param name="patIndex">Pat index.</param>
			private bool prvMatch(string str, IList<CharSubs> pat, int strIndex, int patIndex)
			{
				if ((patIndex >= pat.Count) && (strIndex >= str.Length))
					return true;        // mean we are check all chars in String
				if ((patIndex >= pat.Count) && (strIndex < str.Length))
					return false;       // Pattern is empty, but there are chars in String
				if ((patIndex < pat.Count) && (strIndex >= str.Length))
				{       // need check rest of pattern. If there only ZeroOrMore chars, that's OK
					for (int patAdd = 0; patAdd < pat.Count-patIndex; patAdd++)
					{
						if (pat[patIndex + patAdd].Rule != ApplyRule.ZeroOrMore)
							return false;
					}
					return true;       // String is empty, but Pattern - not
				}
				if (pat[patIndex].Rule == ApplyRule.Once)
				{
					if ((pat[patIndex].Char == '.')
					    || (pat[patIndex].Char == str[strIndex]))
						return prvMatch(str, pat, strIndex + 1, patIndex + 1);
					return false;	// not matched => result = FALSE
				}
				else // zero or more occurance of Char
				{
					if (prvMatch(str, pat, strIndex, patIndex + 1))		// zero
						return true;
					for (int strAdd = 0; strAdd <= str.Length - strIndex; strAdd++)
					{
						if ((strIndex + strAdd) < str.Length)
						{
							if ((pat[patIndex].Char == '.')
								|| (pat[patIndex].Char == str[strIndex + strAdd]))
							{
								if (prvMatch(str, pat, strIndex + strAdd+1, patIndex + 1))
									return true;
							}
							else // 
								return false;

						}
					}
					return false;
				}
			}// prvMatch
		}
	}//public abstract class Problem_
}

/* wrong attempt. Assume '*' mean zero or more ANY CHARACTER, not preceding
   /// <summary>
   /// recursively check string and pattern char by char
   /// </summary>
   /// <returns><c>true</c>, if match was prved, <c>false</c> otherwise.</returns>
   /// <param name="str">String.</param>
   /// <param name="pat">Pat.</param>
   /// <param name="strIndex">String index.</param>
   /// <param name="patIndex">Pat index.</param>
		 private bool prvMatch(string str, string pat, int strIndex, int patIndex)
{
	if ((patIndex >= pat.Length) && (strIndex >= str.Length))
		return true;        // mean we are check all chars in String
	if ((patIndex >= pat.Length) && (strIndex < str.Length))
		return false;       // Pattern is empty, but there are chars in String
	if ((patIndex < pat.Length) && (strIndex >= str.Length))
		return false;       // String is empty, but Pattern - not
	if (pat[patIndex] != '*')
	{
		if ((pat[patIndex] == '.')
			|| (pat[patIndex] == str[strIndex]))
			return prvMatch(str, pat, strIndex + 1, patIndex + 1);
		return false;   // not matched => result = FALSE
	}
	else // previos character should be checked additional
	{
		if (prvMatch(str, pat, strIndex, patIndex + 1))
			return true;
		for (int strAdd = 1; strAdd <= str.Length - strIndex; strAdd++)
		{
			if (prvMatch(str, pat, strIndex + strAdd, patIndex + 1))
				return true;
		}
		return false;
	}
}// prvMatch

*/