using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace LeetCodeTests.Medium
{
    public abstract class Problem_0172
    {
        /* 172. Factorial Trailing Zeroes
        URL: https://leetcode.com/problems/factorial-trailing-zeroes/description/

Given an integer n, return the number of trailing zeroes in n!.
Note that n! = n * (n - 1) * (n - 2) * ... * 3 * 2 * 1.

Example 1:
Input: n = 3
Output: 0
Explanation: 3! = 6, no trailing zero.

Example 2:
Input: n = 5
Output: 1
Explanation: 5! = 120, one trailing zero.

Example 3:
Input: n = 0
Output: 0

Constraints:
0 <= n <= 10^4
 
Follow up: Could you write a solution that works in logarithmic time complexity?

        */
        public class Solution
        {
            /* IDEA: how we can get 0 at the end
            we should multiply to 10 or 2*5, there is no other combinations that give us 0 at the end
            dry run: 5! has 1 zero
                    10! has 2 zero, as it contains (2*5) and (10), where 10 = 5*2
                    15! 1,2,3,4,5,6,7,8,9,10,11,12,13,14,15
                        2*5=10, 4*15=60, 10 => should be only 3
            It seems, the number of zeros is equal to number of times we can divide the input to 5
            for every 5 digit (from factorial representation), there is 5 and some even, so they will give 0 at the end
            */
            public int TrailingZeroes(int n)
            {
                // return (n / 5) + (n / 25) + (n / 125);
                // it seems, every 5*5..(i times) gives additional zeros
                var sum = 0;
                var divider = 5;
                while (divider <= n)
                {
                    sum += n / divider;
                    divider *= 5;
                }
                return sum;
            }

            // from: https://leetcode.com/problems/factorial-trailing-zeroes/solutions/7210790/100-beats-in-c-solution-by-jahidulcse15-0qy4/
            public int TrailingZeroes_shorter(int n)
            {
                int ans = 0;
                while (n > 0)
                {
                    n /= 5;
                    ans += n;
                }
                return ans;
            }
        }
    } //public abstract class Problem_
}
