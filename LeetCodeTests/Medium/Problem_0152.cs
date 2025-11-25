using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.InteropServices;

namespace LeetCodeTests.Medium
{
    public abstract class Problem_0152
    {
        /* 152. Maximum Product Subarray
        URL: https://leetcode.com/problems/maximum-product-subarray/description/

Given an integer array nums, find a subarray that has the largest product, and return the product.

The test cases are generated so that the answer will fit in a 32-bit integer.

Note that the product of an array with a single element is the value of that element.

 

Example 1:

Input: nums = [2,3,-2,4]
Output: 6
Explanation: [2,3] has the largest product 6.
Example 2:

Input: nums = [-2,0,-1]
Output: 0
Explanation: The result cannot be 2, because [-2,-1] is not a subarray.
 

Constraints:

1 <= nums.length <= 2 * 10^4
-10 <= nums[i] <= 10
The product of any subarray of nums is guaranteed to fit in a 32-bit integer.

        */
        public class Solution
        {
            /* IDEA:
            example: -1, 1, 0, 2, -3, 4, -5, 6, -7
            there are several edge cases:
                0 = stop all production
                <0 = inverse the result, make it negative.
                    BUT, can make negative value positive

            IDEA: traverse from left to right
                keep MAX - the founded max
                keep a list of local products:
                    if list is empty, put the current value as a first element in list
                    if list is not empty, multiply all elements in the list with the current value, DON'T ADD a new value to the list. Recheck MAX.
                    if current value is 0, empty the list.
                    if current value is <0, in addition to multiply, add the current value to the list
                After passing the whole array, the MAX should contain the local MAX product
            */
            public int MaxProduct1(int[] nums)
            {
                var tempProducts = new List<int>();
                var localMax = int.MinValue;

                var prevSign = Math.Sign(nums[0]);
                foreach (int val in nums)
                {
                    if (val == 0)
                    {
                        tempProducts.Clear();
                    }
                    var valSign = Math.Sign(val); // if there was sign change or negative value we should add to temp list
                    if ((val < 0) || (valSign != prevSign) || (tempProducts.Count == 0))
                    {
                        tempProducts.Add(1); // to get val in array in next step
                    }
                    for (int ind = 0; ind < tempProducts.Count; ind++)
                    {
                        var prod = tempProducts[ind] * val;
                        if (prod > localMax)
                        {
                            localMax = prod;
                        }
                        tempProducts[ind] = prod;
                    }
                    prevSign = valSign;
                }
                return localMax;
            }

            // taken from: https://leetcode.com/problems/maximum-product-subarray/solutions/6265682/c-python-dynamic-programming-explained-f-8xyu/
            public int MaxProduct(int[] nums)
            {
                int result,
                    minProduct,
                    maxProduct;
                result = minProduct = maxProduct = nums[0];

                for (int i = 1; i < nums.Length; i++)
                {
                    var current = nums[i];

                    if (current < 0)
                    {
                        (minProduct, maxProduct) = (maxProduct, minProduct);
                    }

                    maxProduct = Math.Max(current, maxProduct * current);
                    minProduct = Math.Min(current, minProduct * current);

                    result = Math.Max(result, maxProduct);
                }

                return result;
            }
        }
    } //public abstract class Problem_
}
