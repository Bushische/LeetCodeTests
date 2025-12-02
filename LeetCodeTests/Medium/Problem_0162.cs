using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace LeetCodeTests.Medium
{
    public abstract class Problem_0162
    {
        /* 162. Find Peak Element
        URL: https://leetcode.com/problems/find-peak-element/description/

A peak element is an element that is strictly greater than its neighbors.

Given a 0-indexed integer array nums, find a peak element, and return its index. If the array contains multiple peaks, return the index to any of the peaks.
You may imagine that nums[-1] = nums[n] = -∞. In other words, an element is always considered to be strictly greater than a neighbor that is outside the array.
You must write an algorithm that runs in O(log n) time.

Example 1:
Input: nums = [1,2,3,1]
Output: 2
Explanation: 3 is a peak element and your function should return the index number 2.

Example 2:
Input: nums = [1,2,1,3,5,6,4]
Output: 5
Explanation: Your function can return either index number 1 where the peak element is 2, or index number 5 where the peak element is 6.
 

Constraints:

1 <= nums.length <= 1000
-2^31 <= nums[i] <= 2^31 - 1 ==> INT
nums[i] != nums[i + 1] for all valid i.
        */
        public class Solution
        {
            /* IDEA: pass the array from left to right and find the Peak element:
                nums[i] > nums[i-1] and nums[i] > nums[i+1]
                
                Approach: for any element [j], we should keep status for [j-1]:
                    - was [j-1] bigger than [j-2]
                    - is [j-1] bigger than [j]
                if ([j-1] > [j]) && ( [j-2] < [j-1]) we can return (j-1) as a Peak element index.

            */
            public int FindPeakElement(int[] nums)
            {
                var prev = nums[0]; // previous element value
                var prevIsBiggerThanPrevious = true; // flag that [j-1] was bigger than previos one. Any elemen on the edge is bigger than previous
                for (int j = 1; j < nums.Length; j++)
                {
                    if ((nums[j] < prev) && prevIsBiggerThanPrevious)
                        return j - 1;
                    if (nums[j] > prev)
                    {
                        prevIsBiggerThanPrevious = true;
                    }
                    else
                    {
                        prevIsBiggerThanPrevious = false;
                    }
                    prev = nums[j];
                }
                // edge case, we pass the whole array and didn't find the peak
                if (prevIsBiggerThanPrevious)
                    return nums.Length - 1;
                return -1; // should be unreachable
            }

            //from: https://leetcode.com/problems/find-peak-element/solutions/3291626/easy-to-understand-c-solution-using-bina-so2l/
            // Strange solution
            public int FindPeakElemen_binary(int[] nums)
            {
                var left = 0;
                var right = nums.Length - 1;

                while (left + 1 < right)
                {
                    var mid = left + (right - left) / 2;

                    if (nums[mid] < nums[mid + 1])
                    {
                        left = mid;
                    }
                    else
                    {
                        right = mid;
                    }
                }

                return nums[left] > nums[right] ? left : right;
            }
        }
    } //public abstract class Problem_
}
