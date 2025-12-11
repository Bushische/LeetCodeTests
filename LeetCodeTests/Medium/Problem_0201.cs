using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.ExceptionServices;
using System.Security.Authentication.ExtendedProtection;
using System.Security.Cryptography.X509Certificates;

namespace LeetCodeTests.Medium
{
    public abstract class Problem_0201
    {
        /* 201. Bitwise AND of Numbers Range
        URL: https://leetcode.com/problems/bitwise-and-of-numbers-range/description/

Given two integers left and right that represent the range [left, right], return the bitwise AND of all numbers in this range, inclusive.

 

Example 1:

Input: left = 5, right = 7
Output: 4
Example 2:

Input: left = 0, right = 0
Output: 0
Example 3:

Input: left = 1, right = 2147483647
Output: 0
 

Constraints:

0 <= left <= right <= 2^31 - 1

        */

        public class Solution
        {
            /* IDEA the result is a common prefix
            WHY? Because in binary representation right bits will switch with
            every step (increase by 1), so only left same bits will be the common
            */
            public int RangeBitwiseAnd(int left, int right)
            {
                int count = 0;
                while (left != right)
                {
                    left = left >> 1;
                    right = right >> 1;
                    count++;
                }
                return left << count; // fill with 0s on the right;
            }

            /* IDEA: find a common prefix
           check bits from left to right for both numbers
           if bit_l == bit_r == 1, set corresponding bit to 1 in the result
           as soon bit_l != bit_r, we have the result in buffer
           */
            public int RangeBitwiseAnd_unOptimized(int left, int right)
            {
                int bitToMove = 30; // to get first element
                int buffer = 0;
                for (int shift = 30; shift >= 0; shift--)
                {
                    var bitL = (left >> shift) & 1;
                    var bitR = (right >> shift) & 1;
                    if (bitL != bitR)
                    {
                        buffer = buffer << (shift + 1);
                        break;
                    }
                    buffer = (buffer << 1) | bitL;
                }
                return buffer;
            }
        }

        public class Solution_wrong
        {
            /* IDEA: don't need to enumerate all numbers in [left, right]
            buffer = left & right -- maximum possible result (with max 1s)
            and we should make &= for all power(2) numbers from [left, right]
            if there is more than 1 power(2), the result will be 0
            if there is no powe(2) between, we need to &= for all in between, while not 0

            [1000, 3000] => 1024 will remove all exclude 10th, 2048 will remove all exclude 11th => 0

            */
            public int RangeBitwiseAnd(int left, int right)
            {
                var buffer = left & right;
                // find all power(2) from [left, right]
                var pow = 2 << (int)Math.Log2(left); // the first bigger then left power(2)
                if ((pow > right) || (pow == int.MinValue))
                {
                    return RangeBitwiseAnd_naive(left, right);
                }

                var maxIteration = 31;
                while ((pow <= right) && (maxIteration >= 0) && (buffer > 0))
                {
                    if (pow >= left)
                    {
                        buffer = buffer & pow;
                    }
                    pow = pow << 1;
                    maxIteration--;
                }
                return buffer;
            }

            // time out on 1..Max
            public int RangeBitwiseAnd_naive(int left, int right)
            {
                var buffer = left;
                if (left == 0)
                    return 0;
                for (int i = left; (i > 0) && (i <= right) && (buffer > 0); i++)
                {
                    buffer = buffer & i;
                }
                return buffer;
            }
        }
    } //public abstract class Problem_
}
