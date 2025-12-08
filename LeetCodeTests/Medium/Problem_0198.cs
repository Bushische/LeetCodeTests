using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace LeetCodeTests.Medium
{
    public abstract class Problem_0198
    {
        /* 198. House Robber
        URL: https://leetcode.com/problems/house-robber/

You are a professional robber planning to rob houses along a street. Each house has a certain amount of money stashed, the only constraint stopping you from robbing each of them is that adjacent houses have security systems connected and it will automatically contact the police if two adjacent houses were broken into on the same night.
Given an integer array nums representing the amount of money of each house, return the maximum amount of money you can rob tonight without alerting the police.

Example 1:
Input: nums = [1,2,3,1]
Output: 4
Explanation: Rob house 1 (money = 1) and then rob house 3 (money = 3).
Total amount you can rob = 1 + 3 = 4.

Example 2:
Input: nums = [2,7,9,3,1]
Output: 12
Explanation: Rob house 1 (money = 2), rob house 3 (money = 9) and rob house 5 (money = 1).
Total amount you can rob = 2 + 9 + 1 = 12.

Constraints:

1 <= nums.length <= 100
0 <= nums[i] <= 400

        */
        public class Solution
        {
            /* IDEA: use memorization
                - introduce an array of max sum the robber can reach by this house (include it)
                - memory[0] = nums[0]
                - memory[1] = nums[1]
                - memory[2] = memory[0] + nums[2]
                - memory[3] = max(memory[0], memory[1]) + nums[3]

                need check max from [-2] and [-3] house.
                there is no reason to check [-4], as if we rob [-4] we also can rob [-2] without any violation.

                the max sum the robber can get can be calculated as Max of the last and previous elements in memory
            */
            public int Rob(int[] nums)
            {
                var memory = new int[nums.Length];
                // helper to get value
                var getMemory = (int i) =>
                {
                    if ((i >= 0) && (i < memory.Length))
                        return memory[i];
                    return 0;
                };

                for (int i = 0; i < nums.Length; i++)
                {
                    memory[i] = nums[i] + Math.Max(getMemory(i - 2), getMemory(i - 3));
                }

                if (nums.Length == 1)
                    return memory[0];
                return Math.Max(memory[memory.Length - 1], memory[memory.Length - 2]); // max of two last elements
            }

            // from https://leetcode.com/problems/house-robber/solutions/7015224/house-robber-problem-beats-100-time-on-s-yr7l/
            // O(1) memory +++
            public int Rob_shorter(int[] nums)
            {
                if (nums.Length == 0)
                    return 0;

                int prev = 0,
                    curr = nums[0];
                for (int i = 1; i < nums.Length; i++)
                {
                    int newMax = nums[i] + prev;
                    prev = curr;
                    curr = Math.Max(curr, newMax);
                }
                return curr;
            }
        }
    } //public abstract class Problem_
}
