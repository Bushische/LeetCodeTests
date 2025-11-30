using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;

namespace LeetCodeTests.Easy
{
    public abstract class Problem_0168
    {
        /* 168. Excel Sheet Column Title
        URL: https://leetcode.com/problems/excel-sheet-column-title/description/

Given an integer columnNumber, return its corresponding column title as it appears in an Excel sheet.

For example:

A -> 1
B -> 2
C -> 3
...
Z -> 26
AA -> 27
AB -> 28
...
 
Example 1:
Input: columnNumber = 1
Output: "A"

Example 2:
Input: columnNumber = 28
Output: "AB"

Example 3:
Input: columnNumber = 701
Output: "ZY"
 
Constraints:
1 <= columnNumber <= 2^31 - 1

        */
        public class Solution
        {
            /* IDEA: make conversion to 26-letter basis
            take a number
                tail = number % 26;     // convert to Letter as ()
                rest = number / 26;
            but!
                26 = Z
                26%26 = 0
                26/26 = 1
            
            Updated conversion rule:
                number => number' = number-1
                tail = number' % 26 + char(A)
                rest = number' / 26
            for the rest repeat the cycle

            Dry run: for 27 (should be AA)
                iteration 1 : for 27
                    26 % 26 = 0 -> A
                    26 / 26 = 1
                iteration 2 : for 1
                    0 % 26 = 0 -> A
                    0 / 26 = 0  -> stop the loop
            Dry run: for 26 (should be Z)
                iteration 1: for 26
                    25%26 = 25 + char(A) -> Z
                    25/26 = 0 -> stop the loop
            Dry run: 28 -> AB
                27 % 26 = 1 -> B
                27 / 26 = 1
                ... -> A

            */
            private static int countingBase = 26;
            private static byte firstCharIndex = (byte)'A';

            public string ConvertToTitle(int columnNumber)
            {
                string result = "";
                var number = columnNumber;
                while (number > 0)
                {
                    var tail = (number - 1) % countingBase;
                    number = (number - 1) / countingBase;
                    result = (char)(tail + firstCharIndex) + result;    // add to left
                }
                return result;
            }
        }
    } //public abstract class Problem_
}
