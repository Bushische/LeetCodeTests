using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace LeetCodeTests.Medium
{
    public abstract class Problem_0153
    {
        /* 153. Find Minimum in Rotated Sorted Array
        URL: https://leetcode.com/problems/find-minimum-in-rotated-sorted-array/

Suppose an array of length n sorted in ascending order is rotated between 1 and n times. For example, the array nums = [0,1,2,4,5,6,7] might become:

[4,5,6,7,0,1,2] if it was rotated 4 times.
[0,1,2,4,5,6,7] if it was rotated 7 times.
Notice that rotating an array [a[0], a[1], a[2], ..., a[n-1]] 1 time results in the array [a[n-1], a[0], a[1], a[2], ..., a[n-2]].

Given the sorted rotated array nums of unique elements, return the minimum element of this array.

You must write an algorithm that runs in O(log n) time.

Example 1:
Input: nums = [3,4,5,1,2]
Output: 1
Explanation: The original array was [1,2,3,4,5] rotated 3 times.

Example 2:
Input: nums = [4,5,6,7,0,1,2]
Output: 0
Explanation: The original array was [0,1,2,4,5,6,7] and it was rotated 4 times.

Example 3:
Input: nums = [11,13,15,17]
Output: 11
Explanation: The original array was [11,13,15,17] and it was rotated 4 times.
 
Constraints:
n == nums.length
1 <= n <= 5000
-5000 <= nums[i] <= 5000
All the integers of nums are unique.
nums is sorted and rotated between 1 and n times.

        */

        public class Solution
        {
            /* IDEA: O(log n) means we should implement the dihothomy algorithm (divide by 2)
            Let's see possible cases. Assume:
                a - first element
                z - last element
                m - mid element (in [n/2] position)
            cases:
                - min element in left position: a < m < z
                - min in the first half: a > z, a > m < z < a
                - min in the second half: a < m > z, z < a
                - if a == m, a and z are siblings, so we can just take a min of their values
            using these rules we can easily decide which side to go

            */
            public int FindMin(int[] nums)
            {
                // int mid index
                var mid = (int a, int z) => (a + z) / 2;

                int a,
                    m,
                    z;

                a = 0;
                z = nums.Length - 1;

                while (a < z)
                {
                    m = mid(a, z);
                    #region //
                    // ordered sub array, return the left boarder element
                    // if ((nums[a] < nums[m]) && (nums[m] < nums[z]))
                    //     return nums[a];
                    // if (a == m)
                    //     return int.Min(nums[a], nums[z]);
                    // else if ((nums[a] > nums[z]) && (nums[a] > nums[m]) && (nums[m] < nums[z]))
                    //     z = m;
                    // else if ((nums[a] > nums[z]) && (nums[a] < nums[m]) && (nums[m] > nums[z]))
                    //     a = m;
                    #endregion
                    if (nums[m] < nums[z])
                        z = m;
                    else
                        a = m + 1;
                }
                return nums[a];
            }

            // from here: https://leetcode.com/problems/find-minimum-in-rotated-sorted-array/solutions/5149850/fastest-100-easiest-shortest-binary-sear-2ysf/
            public int FindMinEasiest(int[] nums)
            {
                int left = 0,
                    right = nums.Length - 1;
                while (left < right)
                {
                    int mid = left + (right - left) / 2;
                    if (nums[mid] < nums[right])
                    {
                        right = mid;
                    }
                    else
                    {
                        left = mid + 1;
                    }
                }

                return nums[left];
            }
        }
    } //public abstract class Problem_
}
