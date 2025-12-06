using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace LeetCodeTests.Medium
{
    public abstract class Problem_0166
    {
        /* 166. Fraction to Recurring Decimal
        URL: https://leetcode.com/problems/fraction-to-recurring-decimal/description/

Given two integers representing the numerator and denominator of a fraction, return the fraction in string format.
If the fractional part is repeating, enclose the repeating part in parentheses
If multiple answers are possible, return any of them.
It is guaranteed that the length of the answer string is less than 10^4 for all the given inputs.
Note that if the fraction can be represented as a finite length string, you must return it.

Example 1:
Input: numerator = 1, denominator = 2
Output: "0.5"

Example 2:
Input: numerator = 2, denominator = 1
Output: "2"

Example 3:
Input: numerator = 4, denominator = 333
Output: "0.(012)"

Constraints:
-2^31 <= numerator, denominator <= 2^31 - 1
denominator != 0

        */
        public class Solution
        {
            /* IDEA:
            use hash table to keep a track of numbers in `numerator` position and referenced string length (for the future bracket insert)
            if we meet the exaclty the same number in HT, we can group result to period
            we should skip all integer part (> 0), the period is possible only in fractional part
            */
            public string FractionToDecimal(int numerator, int denominator)
            {
                var memory = new Dictionary<long, int>();
                var buffer = ""; // where we will construct the result

                // calculate sign
                int inum = int.Sign(numerator) * int.Sign(denominator);
                if (inum < 0)
                {
                    buffer = "-";
                }
                long lnumerator = Math.Abs((long)numerator);
                long ldenominator = Math.Abs((long)denominator);

                // calculate integer part
                long num = lnumerator / ldenominator;
                buffer = $"{buffer}{num}";
                num = (lnumerator % ldenominator) * 10;
                // calculate decimal point
                if (num != 0)
                    buffer = buffer + ".";
                // calculate cycle in fractional part
                while (num != 0)
                {
                    if (memory.ContainsKey(num))
                        break; // found a cycle
                    memory.Add(num, buffer.Length);
                    buffer += (num / ldenominator).ToString();
                    num = (num % ldenominator) * 10;
                }
                // we found a cycle
                if (memory.ContainsKey(num))
                {
                    var index = memory[num];
                    buffer = buffer.Insert(index, "(") + ")";
                }
                return buffer;
            }
        }
    } //public abstract class Problem_
}
