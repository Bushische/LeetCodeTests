using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace LeetCodeTests.Medium
{
    public abstract class Problem_0139
    {
        /*
        URL: https://leetcode.com/problems/word-break/

Given a string s and a dictionary of strings wordDict, return true if s can be segmented into a space-separated sequence of one or more dictionary words.

Note that the same word in the dictionary may be reused multiple times in the segmentation.

Example 1:
Input: s = "leetcode", wordDict = ["leet","code"]
Output: true
Explanation: Return true because "leetcode" can be segmented as "leet code".

Example 2:
Input: s = "applepenapple", wordDict = ["apple","pen"]
Output: true
Explanation: Return true because "applepenapple" can be segmented as "apple pen apple".
Note that you are allowed to reuse a dictionary word.

Example 3:
Input: s = "catsandog", wordDict = ["cats","dog","sand","and","cat"]
Output: false
 
Constraints:
1 <= s.length <= 300
1 <= wordDict.length <= 1000
1 <= wordDict[i].length <= 20
s and wordDict[i] consist of only lowercase English letters.
All the strings of wordDict are unique.

        */
        public class Solution_DontWORK
        {
            /* IDEA: search for all words from wordDict, that are in the begining of the s
            For each words, remove them from the begining of s, get the rest of s and pass to next iteration
            */
            public bool WordBreak(string s, IList<string> wordDict)
            {
                // simplify input dictionary
                var simplifiedDict = SimplifyList(wordDict);

                // check all chars from word are in wordDict options
                var sset = s.ToHashSet();
                var wordsSet = simplifiedDict.SelectMany(x => x.ToHashSet());
                if (!sset.IsSubsetOf(wordsSet))
                    return false;

                try
                {
                    return BruteForce(s, simplifiedDict);
                }
                catch (InsufficientExecutionStackException)
                { // catch final stop
                    return false;
                }
            }

            private bool BruteForce(string s, IList<string> wordDict)
            {
                if (string.IsNullOrEmpty(s))
                    return true;
                var startWords = wordDict
                    .Where(word => s.StartsWith(word))
                    .OrderByDescending(word => word.Length);
                foreach (var word in startWords)
                {
                    var restS = s.Substring(word.Length);
                    if (BruteForce(restS, wordDict))
                        return true;
                }
                // if (startWords.Count() == 1)
                //     throw new InsufficientExecutionStackException();    // full stop, as we cannot
                return false;
            }

            /// <summary>
            /// Goal: to remove all optios from dictionary, that can be decompose
            /// </summary>
            /// <param name="wordDict"></param>
            private IList<String> SimplifyList(IList<String> wordDict)
            {
                var distinctWords = wordDict.Distinct().ToList();
                int index = 0;
                while (index < distinctWords.Count)
                {
                    var word = distinctWords[index];
                    distinctWords.RemoveAt(index);
                    if (!BruteForce(word, distinctWords))
                    {
                        distinctWords.Insert(index, word);
                        index++;
                    }
                }
                return distinctWords;
            }
        }

        // With memoization
        public class Solution
        {
            private Dictionary<int, bool> memo;

            public bool WordBreak(string s, IList<string> wordDict)
            {
                memo = new Dictionary<int, bool> { { s.Length, true } };
                return Dfs(s, wordDict, 0);
            }

            private bool Dfs(string s, IList<string> wordDict, int i)
            {
                if (memo.ContainsKey(i))
                {
                    return memo[i];
                }

                foreach (var w in wordDict)
                {
                    if (i + w.Length <= s.Length && s.Substring(i, w.Length) == w)
                    {
                        if (Dfs(s, wordDict, i + w.Length))
                        {
                            memo[i] = true;
                            return true;
                        }
                    }
                }
                memo[i] = false;
                return false;
            }
        }
    } //public abstract class Problem_
}
