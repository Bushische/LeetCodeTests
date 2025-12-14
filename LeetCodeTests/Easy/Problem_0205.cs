using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace LeetCodeTests.Easy
{
    public abstract class Problem_0205
    {
        /* 205. Isomorphic Strings
        URL: https://leetcode.com/problems/isomorphic-strings/description/

Given two strings s and t, determine if they are isomorphic.
Two strings s and t are isomorphic if the characters in s can be replaced to get t.
All occurrences of a character must be replaced with another character while preserving the order of characters. No two characters may map to the same character, but a character may map to itself.

 Example 1:
Input: s = "egg", t = "add"
Output: true
Explanation:
The strings s and t can be made identical by:
Mapping 'e' to 'a'.
Mapping 'g' to 'd'.

Example 2:
Input: s = "foo", t = "bar"
Output: false
Explanation:
The strings s and t can not be made identical as 'o' needs to be mapped to both 'a' and 'r'.

Example 3:
Input: s = "paper", t = "title"
Output: true

Constraints:
1 <= s.length <= 5 * 10^4
t.length == s.length
s and t consist of any valid ascii character.

        */
        public class Solution
        {
            /* IDEA:
                two string isomorphic if:
                    1. the length is the same
                    2. We can build a non overlapping mapping letters from the First word to the letters of the Second
                algorithm:
                    pass from left to right and build mapping A->B
                if for letter i of A we already have a mapping to different letter of B, two string are not isomorphic
            */
            public bool IsIsomorphic(string s, string t)
            {
                if ((s?.Length ?? 0) != (t?.Length ?? 0))
                    return false;

                var dictionaryST = new Dictionary<char, char>(); // from S to T
                var dictionaryTS = new Dictionary<char, char>(); // from T to S
                for (int index = 0; index < s.Length; index++)
                {
                    char cs = s[index];
                    char ct = t[index];
                    if (dictionaryST.TryGetValue(cs, out char stv) && (stv != ct))
                        return false;
                    if (dictionaryTS.TryGetValue(ct, out char ctv) && (ctv != cs))
                        return false;
                    // if (dictionaryTS.ContainsKey(ct) && (dictionaryTS[ct] != cs))
                    dictionaryST[cs] = ct;
                    dictionaryTS[ct] = cs;
                }
                return true;
            }

            // nice approach
            // https://leetcode.com/problems/isomorphic-strings/solutions/3470905/c-clean-and-simple-solution-by-nikbrons-yiqc/
            public bool IsIsomorphic_fromInternet(string text1, string text2)
            {
                var codes1 = GetCodes(text1);
                var codes2 = GetCodes(text2);
                return codes1.SequenceEqual(codes2);
            }

            private IEnumerable<int> GetCodes(string text)
            {
                var set = new HashSet<char>();
                return text.Select((key, i) => set.Add(key) ? i : text.IndexOf(key));
            }
        }
    } //public abstract class Problem_
}
