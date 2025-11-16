using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace LeetCodeTests.Easy
{
    public abstract class Problem_0136
    {
        /*
        URL: https://leetcode.com/problems/single-number/

Given a non-empty array of integers nums, every element appears twice except for one. Find that single one.

You must implement a solution with a linear runtime complexity and use only constant extra space.

Example 1:
Input: nums = [2,2,1]
Output: 1

Example 2:
Input: nums = [4,1,2,1,2]
Output: 4

Example 3:
Input: nums = [1]
Output: 1

Constraints:
1 <= nums.length <= 3 * 10^4
-3 * 10^4 <= nums[i] <= 3 * 10^4
Each element in the array appears twice except for one element which appears only once.

        */

        public class Solution
        {
            /* IDEA:
            1. Order the array, pass from left to right and sum elements:
                a) if element on left is another number sum as (+)
                b) if element on left is the same number sum as (-)
                Final result will be exactly the number we need
                O(n*log(n)) for sorting
                O(n) for summing

            2. Allocate an array of int numbers (0). Every number will keep 32 flags. Let's consider this array as a Bloom filter for our set of numbers:
                we have -30000...+30000 numbers, so, there are 600001 element
                => 1876 int32 values to keep all 600001 flags.
                Algorithm: if we pass the element, we should find the index of the number in array of flags and invert it
                => in the end only one flag should be 1
                Complexity: O(n) to pass array in one way + pass the array of flags in the end
            */
            public int SingleNumber(int[] nums)
            {
                if (nums.Length == 1)
                    return nums[0];
                int[] flags = new int[MAX_ELEMENT_NUMBER / FLAG_ELEMENT_SIZE + 1];
                foreach (int element in nums)
                    InvertFlag(element, flags);

                return FindTheValue(flags);
            }

            /// <summary>
            /// To bring all numbers to possitive values for easier operations
            /// </summary>
            private int SHIFT = 30000;
            private int FLAG_ELEMENT_SIZE = sizeof(int) * 8;
            private int MAX_ELEMENT_NUMBER = 60001;

            /// <summary>
            /// For passed value, find the container index and the in-container index and invert the flag 0->1 or 1->0 (using XOR)
            /// </summary>
            private void InvertFlag(int value, int[] flags)
            {
                value += SHIFT; // make it possitive
                var containerIndex = value / FLAG_ELEMENT_SIZE;
                var inContainerIndex = value % FLAG_ELEMENT_SIZE;

                var container = flags[containerIndex];

                var mask = 1 << inContainerIndex;

                container = container ^ mask; // invert the flag
                flags[containerIndex] = container;
            }

            /// <summary>
            /// Find the non 0 value
            /// </summary>
            /// <param name="flags"></param>
            /// <returns></returns>
            private int FindTheValue(int[] flags)
            {
                var containerIndex = 0;
                for (int index = 0; index < flags.Length; index++)
                {
                    if (flags[index] > 0)
                    {
                        containerIndex = index;
                        break;
                    }
                }

                var container = flags[containerIndex];
                var valueIndex = 0;
                while ((container != 1) && (container > 0))
                {
                    valueIndex++;
                    container = container >> 1;
                }

                var result = containerIndex * FLAG_ELEMENT_SIZE + valueIndex - SHIFT;
                return result;
            }
        }

        // borrowed solution:
        public int SingleNumberWithXOR(int[] nums)
        {
            int output = 0;
            foreach (int n in nums)
                output = output ^ n;

            return output;
        }
    } //public abstract class Problem_
}
