using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace LeetCodeTests.Medium
{
    public abstract class Problem_0171
    {
        /* 171. Excel Sheet Column Number
        URL: https://leetcode.com/problems/excel-sheet-column-number/

Given a string columnTitle that represents the column title as appears in an Excel sheet, return its corresponding column number.

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
Input: columnTitle = "A"
Output: 1

Example 2:
Input: columnTitle = "AB"
Output: 28

Example 3:
Input: columnTitle = "ZY"
Output: 701

Constraints:
1 <= columnTitle.length <= 7
columnTitle consists only of uppercase English letters.
columnTitle is in the range ["A", "FXSHRXW"].

        */
        public class Solution
        {
            /* IDEA: this is a classic task for changing counting systems
            pass from left to right
            take one element and convert it to decimal system
            add the result to buffer and multiply the buffer to 26 (base of counting system)
            continue with the next element

            dry run:
            A => (A - char(A))+1 = 1
            B => (B - char(A))+1 = 2
            Z => (Z - char(A))+1 = 26
            AA => 1*26+1 = 27
            ZY => 26*26 + 25 = 701
            */
            public int TitleToNumber(string columnTitle)
            {
                int buffer = 0;
                var digits = columnTitle.ToCharArray();
                int countingBase = 26;
                byte aIndex = (byte)'A';

                foreach (var digit in digits)
                {
                    var converted = (byte)digit - aIndex + 1;
                    buffer = buffer * countingBase + converted;
                }

                return buffer;
            }
        }
    } //public abstract class Problem_
}
