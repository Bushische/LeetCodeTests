using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace LeetCodeTests.Medium
{
    public abstract class Problem_2707
    {
        /* 2707. Extra Characters in a String
        URL: https://leetcode.com/problems/extra-characters-in-a-string/description/

You are given a 0-indexed string s and a dictionary of words dictionary. You have to break s into one or more non-overlapping substrings such that each substring is present in dictionary. There may be some extra characters in s which are not present in any of the substrings.

Return the minimum number of extra characters left over if you break up s optimally.

Example 1:
Input: s = "leetscode", dictionary = ["leet","code","leetcode"]
Output: 1
Explanation: We can break s in two substrings: "leet" from index 0 to 3 and "code" from index 5 to 8. There is only 1 unused character (at index 4), so we return 1.

Example 2:
Input: s = "sayhelloworld", dictionary = ["hello","world"]
Output: 3
Explanation: We can break s in two substrings: "hello" from index 3 to 7 and "world" from index 8 to 12. The characters at indices 0, 1, 2 are not used in any substring and thus are considered as extra characters. Hence, we return 3.
 
Constraints:
1 <= s.length <= 50
1 <= dictionary.length <= 50
1 <= dictionary[i].length <= 50
dictionary[i] and s consists of only lowercase English letters
dictionary contains distinct words
        */
        public class Solution
        {
            /* IDEA: use memoization for keeping the track of our findings
                DP[i] = min extra chars till here
                example: sayhello with [hello]: s=>dp[0] = 0, a=>dp[1] = 1, y=>dp[2] = 2, h=>dp[3]=3, then `hello` => dp[7], the end of `hello` = 3
                //  for dp[6] we have sayhell, that cannot be covered with any combination => dp[6] should be 7
                We need change dp only for the last charracter
                // dp should be initiated with 1...N characters
                // the searcing result is the dp[n]
                if, during the permutation variants from dictionary, we find that we can reqch some point with less "extra chars", we should update dp[i]
            */
            public int MinExtraChar(string s, string[] dictionary)
            {
                var DP = new Dictionary<int, int>(); // to keep track of minimum extra chars
                var sLength = s.Length;
                for (int i = 0; i <= sLength; i++)
                    DP[i] = i;

                for (int i = 0; i <= sLength; i++)
                {
                    var min = DP[i]; // the current MIN we can reach by this element
                    if (i > 0)
                    {
                        min = int.Min(min, DP[i - 1] + 1); // if we skip the previous step
                        DP[i] = min;
                    }
                    foreach (var word in dictionary)
                    {
                        if (i + word.Length > sLength) // skip this
                            continue;
                        var subStr = s.Substring(i, word.Length);
                        if (subStr == word)
                        {
                            var endIndex = i + word.Length;
                            DP[endIndex] = int.Min(DP[endIndex], min); // the next symbol after found word
                        }
                    }
                }
                return DP[sLength];
            }
        }
    } //public abstract class Problem_
}
// leetscode
// 012345678
// 01230
