using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace LeetCodeTests.Medium
{
    public abstract class Problem_0165
    {
        /* 165. Compare Version Numbers
        URL: https://leetcode.com/problems/compare-version-numbers/description/

Given two version strings, version1 and version2, compare them. A version string consists of revisions separated by dots '.'. The value of the revision is its integer conversion ignoring leading zeros.

To compare version strings, compare their revision values in left-to-right order. If one of the version strings has fewer revisions, treat the missing revision values as 0.

Return the following:

If version1 < version2, return -1.
If version1 > version2, return 1.
Otherwise, return 0.

Example 1:
Input: version1 = "1.2", version2 = "1.10"
Output: -1
Explanation:
version1's second revision is "2" and version2's second revision is "10": 2 < 10, so version1 < version2.

Example 2:
Input: version1 = "1.01", version2 = "1.001"
Output: 0
Explanation:
Ignoring leading zeroes, both "01" and "001" represent the same integer "1".

Example 3:
Input: version1 = "1.0", version2 = "1.0.0.0"
Output: 0
Explanation:
version1 has less revisions, which means every missing revision are treated as "0".

Constraints:
1 <= version1.length, version2.length <= 500
version1 and version2 only contain digits and '.'.
version1 and version2 are valid version numbers.
All the given revisions in version1 and version2 can be stored in a 32-bit integer.

        */
        public class Solution
        {
            /* IDEA: split string to component
                compare from left to right
                if any pair of components are not equal, return the result of comparisson
                if one of version is out of components, check the rest:
                    a) all rest components are equal to 0s, means versions are the same
                    b) else, the rest version is bigger
            */
            public int CompareVersion(string version1, string version2)
            {
                var componentsV1 = version1.Split('.');
                var componentsV2 = version2.Split('.');

                var vIndex = 0;
                while ((vIndex < componentsV1.Length) && (vIndex < componentsV2.Length))
                {
                    var v1Component = int.Parse(componentsV1[vIndex]);
                    var v2Component = int.Parse(componentsV2[vIndex]);

                    if (v1Component != v2Component)
                    {
                        return (v1Component < v2Component) ? -1 : +1;
                    }

                    vIndex++;
                }
                // Check the equality
                // if v1 longer then v2, most probably the result is 1. Or 0.
                // if v2 longer then v1, most probably the result is -1. Or 0.
                var tempResult = (vIndex >= componentsV1.Length) ? -1 : 1;
                var longerVersion = (vIndex >= componentsV1.Length) ? componentsV2 : componentsV1;
                while (vIndex < longerVersion.Length)
                {
                    var component = int.Parse(longerVersion[vIndex]);
                    if (component != 0)
                        return tempResult;
                    vIndex++;
                }
                return 0;
            }
        }
    } //public abstract class Problem_
}
