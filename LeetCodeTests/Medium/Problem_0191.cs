using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace LeetCodeTests.Medium
{
    public abstract class Problem_0191
    {
        /* 191. Number of 1 Bits
        URL: https://leetcode.com/problems/number-of-1-bits/description/

Given a positive integer n, write a function that returns the number of set bits in its binary representation (also known as the Hamming weight).

Example 1:
Input: n = 11
Output: 3
Explanation:
The input binary string 1011 has a total of three set bits.

Example 2:
Input: n = 128
Output: 1
Explanation:
The input binary string 10000000 has a total of one set bit.

Example 3:
Input: n = 2147483645
Output: 30
Explanation:
The input binary string 1111111111111111111111111111101 has a total of thirty set bits.

Constraints:
1 <= n <= 2^31 - 1
Follow up: If this function is called many times, how would you optimize it?

        */

        public class Solution
        {
            /* IDEA: instead of creating a mask, just examine the 1 bit and shift right, while N > 0
            
            BAD IDEA: use a binary shift to examine the input with 1-bit mask (with binary AND).
            to optimize for many use, we can put in set/list all 1-bit masks (or all powers of 2)
            */
            public int HammingWeight(int n)
            {
                int bitCount = 0;
                while (n > 0)
                {
                    if ((n & 1) > 0)
                        bitCount++;
                    n = n >> 1;
                }
                return bitCount;
            }
        }
    } //public abstract class Problem_
}
