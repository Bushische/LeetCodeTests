using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.InteropServices;

namespace LeetCodeTests.Medium
{
    public abstract class Problem_0093
    {
        /*
        URL: https://leetcode.com/problems/restore-ip-addresses/
A valid IP address consists of exactly four integers separated by single dots. Each integer is between 0 and 255 (inclusive) and cannot have leading zeros.

For example, "0.1.2.201" and "192.168.1.1" are valid IP addresses, but "0.011.255.245", "192.168.1.312" and "192.168@1.1" are invalid IP addresses.
Given a string s containing only digits, return all possible valid IP addresses that can be formed by inserting dots into s. You are not allowed to reorder or remove any digits in s. You may return the valid IP addresses in any order.

Example 1:
Input: s = "25525511135"
Output: ["255.255.11.135","255.255.111.35"]

Example 2:
Input: s = "0000"
Output: ["0.0.0.0"]

Example 3:
Input: s = "101023"
Output: ["1.0.10.23","1.0.102.3","10.1.0.23","10.10.2.3","101.0.2.3"]


Constraints:
1 <= s.length <= 20
s consists of digits only.
        */

        public class Solution
        {
            /*
            IDEA: use 3 pointers for possible dots, check each component and find all possible variations
            when find a valid IP, create a string representation for it
            position 1 is equal "Just before char with index 1"
                for "12345" if we split by 1 we get "1" and "2345"
            */
            public IList<string> RestoreIpAddresses(string s)
            {
                List<string> resultList = [];
                if (string.IsNullOrEmpty(s))
                    return resultList;
                var length = s.Length;

                // check, that selection is a valid segment
                bool isValidIpSegment(int start, int end)
                {
                    byte segmentAsByte = 0;
                    if (end > length)
                        return false;
                    if (end < start)
                        return false;
                    if (byte.TryParse(s.AsSpan(start..end), out segmentAsByte))
                    {
                        // check leading 0s
                        if ((end - start == 1) && (segmentAsByte == 0))
                            return true;
                        if (segmentAsByte >= Math.Pow(10, end - start - 1))
                            return true;
                    }
                    return false;
                }

                // get valid IP
                string getValidIp(int seg1, int seg2, int seg3)
                {
                    return s.Substring(0, seg1)
                        + "."
                        + s.Substring(seg1, seg2 - seg1)
                        + "."
                        + s.Substring(seg2, seg3 - seg2)
                        + "."
                        + s.Substring(seg3, length - seg3);
                }

                for (int dot1 = 1; dot1 < length; dot1++)
                {
                    if (!isValidIpSegment(0, dot1))
                        break;
                    for (int dot2 = dot1 + 1; dot2 < length; dot2++)
                    {
                        if (!isValidIpSegment(dot1, dot2))
                            break;
                        for (int dot3 = dot2 + 1; dot3 < length; dot3++)
                        {
                            if (!isValidIpSegment(dot2, dot3))
                                break;

                            if (isValidIpSegment(dot3, length))
                            {
                                resultList.Add(getValidIp(dot1, dot2, dot3));
                            }
                        }
                    }
                }
                return resultList;
            }
        }
    } //public abstract class Problem_
}
