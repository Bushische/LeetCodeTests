using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace LeetCodeTests.Easy
{
    public abstract class Problem_0169
    {
        /* 169. Majority Element
        URL: https://leetcode.com/problems/majority-element/

Given an array nums of size n, return the majority element.

The majority element is the element that appears more than ⌊n / 2⌋ times. You may assume that the majority element always exists in the array.

Example 1:
Input: nums = [3,2,3]
Output: 3

Example 2:
Input: nums = [2,2,1,1,1,2,2]
Output: 2
 
Constraints:

n == nums.length
1 <= n <= 5 * 10^4
-10^9 <= nums[i] <= 10^9
The input is generated such that a majority element will exist in the array.
 
Follow-up: Could you solve the problem in linear time and in O(1) space?

        */
        public class Solution
        {
            /* IDEA: don't know the solution with O(1) memory and O(n) time
            naive: hashtable with counter => linear + O(n) memory
            sort: sort array and pass it once with calculation of number entries
            */
            public int MajorityElement(int[] nums)
            {
                var ht = new Dictionary<int, int>();
                for (int i = 0; i < nums.Length; i++)
                {
                    var el = nums[i];
                    if (ht.TryGetValue(el, out int value))
                        ht[el] = value + 1;
                    else
                        ht[el] = 1;
                }
                var maxEl = ht.MaxBy(kv => kv.Value);
                return maxEl.Key;
            }

            //from: https://leetcode.com/problems/majority-element/solutions/6445097/o1-space-on-time-100-beats-0-ms-c-by-5ld-nf7m/
            /* As "majority elements" apears more than half times
                finally, we will get it in Majority variable with count > 0
                1,1,1,2,2,2,2 -> 2
                1,2,1,2,1,2,2 -> 2
                2,1,2,1,2,1,2 -> 2
            */
            public int MajorityElement_linear_O1(int[] nums)
            {
                int Majority = 0;
                int Count = 0;
                for (int i = 0; i < nums.Length; i++)
                {
                    if (Count == 0)
                        Majority = nums[i];

                    if (nums[i] == Majority)
                        Count++;
                    else
                        Count--;
                }
                return Majority;
            }
        }
    } //public abstract class Problem_
}
