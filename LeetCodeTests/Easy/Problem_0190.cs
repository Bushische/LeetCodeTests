using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Xml.XPath;

namespace LeetCodeTests.Easy
{
    public abstract class Problem_0190
    {
        /* 190. Reverse Bits
        URL: https://leetcode.com/problems/reverse-bits/description/

Reverse bits of a given 32 bits signed integer.

Example 1:
Input: n = 43261596
Output: 964176192
Explanation:
Integer	Binary
43261596	00000010100101000001111010011100
964176192	00111001011110000010100101000000

Example 2:
Input: n = 2147483644
Output: 1073741822
Explanation:
Integer	Binary
2147483644	01111111111111111111111111111100
1073741822	00111111111111111111111111111110

Constraints:
0 <= n <= 2^31 - 2
n is even.
 

Follow up: If this function is called many times, how would you optimize it?

        */
        public class Solution
        {
            /* IDEA: use two mask, for one move from left to right, for the other from right to left.
            Every mask is one bit 1. At every step move it to right or left, accordingly.
            Use operation AND to identify the value at the position, apply by reverse mask.
            */
            public int ReverseBits1(int n)
            {
                int buffer = 0;
                int leftMask = 1 << 30; // int.MinValue; // 1000...000
                // need to initiate leftMask this way, as int.MinValue assign the left bit to 1
                // and next operatoin >> 1, bring new "1" to the left. We need to get "0"
                int rightMask = 2; // 000...0001
                for (int i = 1; i < 31; i++)
                {
                    var digit = n & leftMask;
                    if (digit > 0)
                    {
                        buffer = buffer | rightMask;
                    }
                    leftMask = leftMask >> 1;
                    rightMask = rightMask << 1;
                }

                return buffer;
            }

            /* IDEA 2:
            check the right bit of n: n & 1 = bit
            put it to the buffer: (buffer = buffer << 1) | bit
            repeat for all 32 bit
            */
            public int ReverseBits(int n)
            {
                int buffer = 0;
                for (int i = 0; i < 32; i++)
                {
                    var bit = n & 1;
                    buffer = (buffer << 1) | bit;
                    n = n >> 1;
                }
                return buffer;
            }
        }
    } //public abstract class Problem_
}
