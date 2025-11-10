using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.InteropServices;

namespace LeetCodeTests.Medium
{
    public abstract class Problem_0122
    {
        /*
        URL: https://leetcode.com/problems/best-time-to-buy-and-sell-stock-ii/description/

You are given an integer array prices where prices[i] is the price of a given stock on the ith day.

On each day, you may decide to buy and/or sell the stock. You can only hold at most one share of the stock at any time. However, you can sell and buy the stock multiple times on the same day, ensuring you never hold more than one share of the stock.

Find and return the maximum profit you can achieve.

Example 1:
Input: prices = [7,1,5,3,6,4]
Output: 7
Explanation: Buy on day 2 (price = 1) and sell on day 3 (price = 5), profit = 5-1 = 4.
Then buy on day 4 (price = 3) and sell on day 5 (price = 6), profit = 6-3 = 3.
Total profit is 4 + 3 = 7.

Example 2:
Input: prices = [1,2,3,4,5]
Output: 4
Explanation: Buy on day 1 (price = 1) and sell on day 5 (price = 5), profit = 5-1 = 4.
Total profit is 4.

Example 3:
Input: prices = [7,6,4,3,1]
Output: 0
Explanation: There is no way to make a positive profit, so we never buy the stock to achieve the maximum profit of 0.
 
Constraints:

1 <= prices.length <= 3 * 104
0 <= prices[i] <= 104
        */

        public class Solution
        {
            /* IDEA: naive approach, by on the min, sell on the local Max, as soon as price go down.
            In example: [7,1,5,3,6,4]
            there is two intervals of consistent grow: 1-5 and 3-6 = 4 + 3 == 7
            there is an interval 1-6, but it gives only 5, as we don't earn on drop 5-3

            Idea of the algorithm:
                * search for all rising periods and fix profit in them
                * if there is no growing price interval, the result should be 0

            INT for result should be enough
            */
            public int MaxProfit(int[] prices)
            {
                if (prices.Length <= 1)
                    return 0;

                int resultSum = 0;
                int left = 0;
                int right = 1;
                int prev = prices[0];
                while (right < prices.Length)
                {
                    if (prices[right] < prev) // fix profit
                    {
                        if (prices[left] < prev)
                            resultSum += prev - prices[left];
                        left = right;
                    }
                    prev = prices[right];
                    right++;
                }
                if (prices[left] < prev)
                    resultSum += prev - prices[left];

                return resultSum;
            }
        }
    } //public abstract class Problem_
}
