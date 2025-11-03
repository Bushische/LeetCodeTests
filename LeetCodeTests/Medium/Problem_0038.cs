using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace LeetCodeTests.Medium
{
    public abstract class Problem_0038
    {
        /*
        URL: https://leetcode.com/problems/count-and-say/description/

        The count-and-say sequence is a sequence of digit strings defined by the recursive formula:

countAndSay(1) = "1"
countAndSay(n) is the run-length encoding of countAndSay(n - 1).
Run-length encoding (RLE) is a string compression method that works by replacing consecutive identical characters
 (repeated 2 or more times) with the concatenation of the character and the number marking the count of
 the characters (length of the run). For example, to compress the string "3322251" we replace "33" with "23",
 replace "222" with "32", replace "5" with "15" and replace "1" with "11".
 Thus the compressed string becomes "23321511".

Given a positive integer n, return the nth element of the count-and-say sequence.

 

Example 1:
Input: n = 4
Output: "1211"
Explanation:
    countAndSay(1) = "1"
    countAndSay(2) = RLE of "1" = "11"
    countAndSay(3) = RLE of "11" = "21"
    countAndSay(4) = RLE of "21" = "1211"

Example 2:
Input: n = 1
Output: "1"
Explanation:
    This is the base case.

Constraints:

1 <= n <= 30
 

Follow up: Could you solve it iteratively?

        */
        public static void Test()
        {
            Solution sol = new Solution();

            /*
            var input = new int[] { 2, 7, 11, 15 };
            Console.WriteLine($"Input array: {string.Join(", ", input)}");
            */
        }

        public class Solution
        {
            public string CountAndSay(int n)
            {
                if ((n < 1) || (n > 30))
                    throw new ArgumentOutOfRangeException();
                return CalculateNonRecursive(n);
            }

            private string CalculateNonRecursive(int n)
            {
                var result = "1";
                if (n == 1)
                    result = "1";

                var loopIndex = 2;
                while (loopIndex <= n)
                {
                    result = GetRleRepresentation(result);
                    loopIndex++;
                }
                return result;
            }

            record Rle(int count, char symbol)
            {
                public override string ToString()
                {
                    return $"{count}{symbol}";
                }
            }

            /// <summary>
            /// get string and return its RLE representation
            /// </summary>
            /// <param name="input"></param>
            /// <returns>LIst of Rle objects</returns>
            private string GetRleRepresentation(string input)
            {
                if (string.IsNullOrEmpty(input))
                    return "";
                var resultList = new List<Rle>();

                int prevIndex = 0;
                int curIndex = 1;
                char symbol = input[prevIndex];
                while (curIndex < input.Length)
                {
                    if (input[curIndex] != symbol)
                    {
                        resultList.Add(new Rle(curIndex - prevIndex, symbol));
                        symbol = input[curIndex];
                        prevIndex = curIndex;
                    }
                    curIndex++;
                }
                resultList.Add(new Rle(curIndex - prevIndex, symbol));

                return string.Concat(resultList.Select(par => par.ToString()));
            }

            /* Possible improvement:
            1. we don't need to calculate count as a diff between to values
                we can just calculate COUNT instead
            2. We can get rid of Rle record, it just raise memory consumption
            

            */
        }
    } //public abstract class Problem_
}
