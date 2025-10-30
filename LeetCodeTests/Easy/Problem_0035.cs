using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace LeetCodeTests.Easy
{
    public abstract class Problem_0035
    {
        /*
Given a sorted array of distinct integers and a target value, return the index if the target is found. If not, return the index where it would be if it were inserted in order.

You must write an algorithm with O(log n) runtime complexity.

 

Example 1:
Input: nums = [1,3,5,6], target = 5
Output: 2

Example 2:
Input: nums = [1,3,5,6], target = 2
Output: 1

Example 3:
Input: nums = [1,3,5,6], target = 7
Output: 4

Constraints:

1 <= nums.length <= 104
-104 <= nums[i] <= 104
nums contains distinct values sorted in ascending order.
-104 <= target <= 104
        */
        public static void Test()
        {
            Solution sol = new Solution();

            /*
            var input = new int[] { 2, 7, 11, 15 };
            Console.WriteLine($"Input array: {string.Join(", ", input)}");
            */
        }

        public class Solution
        {
            // Dichotomy
            public int SearchInsert(int[] nums, int target)
            {
                if (nums.Length == 0)
                    return 0;
                var range = 0..(nums.Length - 1);
                return getIndex(nums, target, range);
            }

            /// <summary>
            /// Find an suitable index
            /// </summary>
            /// <param name="nums"></param>
            /// <param name="target"></param>
            /// <param name="range">Range of left and right boarders (not from End)</param>
            /// <returns></returns>
            private int getIndex(int[] nums, int target, Range range)
            {
                var rangeA = range.Start.Value;
                var rangeB = range.End.Value;

                // if target <= nums[A] return range.start
                if (target <= nums[rangeA])
                    return rangeA;

                // if target > nums[B] return range.end
                if (nums[rangeB] < target)
                    return rangeB + 1;

                // edge case, target out of array
                if (nums[rangeB] == target)
                    return rangeB;

                // if range A..A return A
                if (rangeA == rangeB)
                    return rangeA;

                // if target inside, take a mid and find suitable interval
                var mid = (rangeB + rangeA) / 2;
                if (target <= nums[mid])
                    return getIndex(nums, target, rangeA..mid);
                else
                    return getIndex(nums, target, (mid + 1)..rangeB);
            }
        }
    } //public abstract class Problem_
}
