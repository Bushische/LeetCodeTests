using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text.RegularExpressions;

namespace LeetCodeTests.Easy
{
    public abstract class Problem_0125
    {
        /*
        URL: https://leetcode.com/problems/valid-palindrome/

A phrase is a palindrome if, after converting all uppercase letters into lowercase letters and removing all non-alphanumeric characters, it reads the same forward and backward. Alphanumeric characters include letters and numbers.

Given a string s, return true if it is a palindrome, or false otherwise.

Example 1:
Input: s = "A man, a plan, a canal: Panama"
Output: true
Explanation: "amanaplanacanalpanama" is a palindrome.

Example 2:
Input: s = "race a car"
Output: false
Explanation: "raceacar" is not a palindrome.

Example 3:
Input: s = " "
Output: true
Explanation: s is an empty string "" after removing non-alphanumeric characters.
Since an empty string reads the same forward and backward, it is a palindrome.

Constraints:
1 <= s.length <= 2 * 105
s consists only of printable ASCII characters.

        */

        public class Solution
        {
            /* IDEA: convert all to lower case and remove all insignificant chars
            Use two reference, one from the begin and another from the end to check
            if characters are the same, move to the next character (-1 for the last ref)
            Repeat until First >= Last
            */
            public bool IsPalindrome(string s)
            {
                var regex = new Regex("[^a-z0-9]*");
                var Text = regex.Replace(s.ToLower(), ""); // remove all unneeded chars

                int left = 0;
                int right = Text.Length - 1;
                while ((left < right) && (Text[left] == Text[right]))
                {
                    left++;
                    right--;
                }
                return left >= right;
            }
        }

        public bool IsPalindrome_nice(string s)
        {
            var clean = s.ToLower().Where(x => char.IsLetterOrDigit(x));
            return clean.Reverse().SequenceEqual(clean);
        }
    } //public abstract class Problem_
}
