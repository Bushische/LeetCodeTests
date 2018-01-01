using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Specialized;

namespace LeetCodeTests
{
	public abstract class Problem_0072
	{
		/*
Given two words word1 and word2, find the minimum number of steps required to convert word1 to word2. (each operation is counted as 1 step.)

You have the following 3 operations permitted on a word:

a) Insert a character
b) Delete a character
c) Replace a character
		*/
		public static void Test()
		{
			Solution sol = new Solution();

			/*
			var input = new int[] { 2, 7, 11, 15 };
			Console.WriteLine($"Input array: {string.Join(", ", input)}");
			*/

			var word1 = "abc";
			var word2 = "abd";
			Console.WriteLine($"For '{word1}' and '{word2}' -> {sol.MinDistance(word1, word2)} (waits 1)");

			word1 = "abc";
			word2 = "aebwc";
			Console.WriteLine($"For '{word1}' and '{word2}' -> {sol.MinDistance(word1, word2)} (waits 2 insertion)");

			word1 = "aebwc";
			word2 = "abc";
			Console.WriteLine($"For '{word1}' and '{word2}' -> {sol.MinDistance(word1, word2)} (waits 2 deletion)");

			word1 = "qwe";
			word2 = "abc";
			Console.WriteLine($"For '{word1}' and '{word2}' -> {sol.MinDistance(word1, word2)} (waits 3 replace)");

			word1 = "abc";
			word2 = "cba";
			Console.WriteLine($"For '{word1}' and '{word2}' -> {sol.MinDistance(word1, word2)} (waits 2 replace)");

			/*
Submission Result: Time Limit Exceeded 
Last executed input:
"dinitrophenylhydrazine"
"acetylphenylhydrazine"
			*/

			word1 = "dinitro";
			word2 = "acetyl";
			Console.WriteLine($"For '{word1}' and '{word2}' -> {sol.MinDistance(word1, word2)} (waits 6 replace)");

			word1 = "dinitrophenylhydrazine";
			word2 = "acetylphenylhydrazine";
			Console.WriteLine($"For '{word1}' and '{word2}' -> {sol.MinDistance(word1, word2)} (waits 6 replace)");

		}

		/// <summary>
		/// Try to solve, base on idea split to small parts
		/// </summary>
		public class Solution
		{
			public int MinDistance(string word1, string word2)
			{
				if (string.IsNullOrEmpty(word1) && string.IsNullOrEmpty(word2))
					return 0;
				if (string.IsNullOrEmpty(word1))
					return word2.Length;
				if (string.IsNullOrEmpty(word2))
					return word1.Length;
				
				int l1 = word1.Length;
				int l2 = word2.Length;

				int[] nc = new int[l2 + 1];
				for (int j = 0; j <= l2; j++)
					nc[j] = j;

				for (int i = 1; i <= l1; i++)
				{
					int prev = i;
					for (int j = 1; j <= l2; j++)
					{
						int cur = 0;
						if (word1[i - 1] == word2[j - 1])
							cur = nc[j - 1];        // as word[i-2] == word2[j-2]
						else
							cur = Math.Min(Math.Min(nc[j - 1], prev), nc[j]) + 1;
						nc[j - 1] = prev;
						prev = cur;
					}
					nc[l2] = prev;
				}

				return nc[l2];
			}
		}

		/*
Use f[i][j] to represent the shortest edit distance between word1[0, i) and word2[0, j). Then compare the last character of word1[0, i) and word2[0, j),
which are c and d respectively(c == word1[i - 1], d == word2[j - 1]):
if c == d, then : f[i][j] = f[i - 1][j - 1]
Otherwise we can use three operations to convert word1 to word2:
(a) if we replaced c with d: f[i][j] = f[i - 1][j - 1] + 1;
(b) if we added d after c: f[i][j] = f[i][j - 1] + 1;
(c) if we deleted c: f[i][j] = f[i - 1][j] + 1;
Note that f[i][j] only depends on f[i - 1][j - 1], f[i - 1][j] and f[i][j - 1], therefore we can reduce the space to O(n) by using only the(i-1)th array and previous updated element(f[i][j - 1]).

 int minDistance(string word1, string word2)
{

	int l1 = word1.size();
	int l2 = word2.size();

	vector<int> f(l2 + 1, 0);
	for (int j = 1; j <= l2; ++j)
		f[j] = j;

	for (int i = 1; i <= l1; ++i)
	{
		int prev = i;
		for (int j = 1; j <= l2; ++j)
		{
			int cur;
			if (word1[i - 1] == word2[j - 1])
			{
				cur = f[j - 1];
			}
			else
			{
				cur = min(min(f[j - 1], prev), f[j]) + 1;
			}

			f[j - 1] = prev;
			prev = cur;
		}
		f[l2] = prev;
	}
	return f[l2];

}
Actually at first glance I thought this question was similar to Word Ladder and I tried to solve it using BFS(pretty stupid huh?). 
But in fact, the main difference is that there's a strict restriction on the intermediate words in Word Ladder problem, 
while there's no restriction in this problem.If we added some restriction on intermediate words for this question, 
I don't think this DP solution would still work.
		*/

		public class Solution_too_long_and_not_optimal
		{
			public int MinDistance(string word1, string word2)
			{
				FoundedMin = int.MaxValue;
				if (string.IsNullOrEmpty(word1))
					word1 = "";
				if (string.IsNullOrEmpty(word2))
					return word1.Length;
				ModelWord = word2;
				FindVariants(word1, 0, 0);

				return FoundedMin;
			}
			/// <summary>
			/// Founded minimum distance
			/// </summary>
			private int FoundedMin = int.MaxValue;
			private string ModelWord = "";
			private void FixMin(int newValue)
			{
				if (newValue < FoundedMin)
					FoundedMin = newValue;
			}


			private void FindVariants(string word, int changePos, int madeChanges)
			{
				if (madeChanges > FoundedMin)
					return;
				else if (word == ModelWord)
					FixMin(madeChanges);
				else if (changePos >= ModelWord.Length)		//word1 > ModelWord => fix made changes + all needed deletion
					FixMin(madeChanges + word.Length - ModelWord.Length);
				else if ((changePos < word.Length) && (changePos < ModelWord.Length) && (word[changePos] == ModelWord[changePos]))
					FindVariants(word, changePos + 1, madeChanges);
				else if (changePos >= word.Length)
					FixMin(madeChanges + ModelWord.Length - word.Length);   // made changes plus all needed insertion
				else
				{
					// insert a character
					string wins = word.Insert(changePos, ModelWord[changePos].ToString());
					FindVariants(wins, changePos + 1, madeChanges + 1);
					// delete a character
					string wdel = word.Remove(changePos, 1);
					FindVariants(wdel, changePos, madeChanges + 1);
					// replace a character
					string wrep = word.Substring(0, changePos) + ModelWord[changePos] + word.Substring(changePos + 1);
					FindVariants(wrep, changePos + 1, madeChanges + 1);
				}
			}
		}
	}//public abstract class Problem_
}