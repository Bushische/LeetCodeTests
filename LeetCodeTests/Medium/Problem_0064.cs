using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace LeetCodeTests.Medium
{
    public abstract class Problem_0064
    {
        /*
        URL: https://leetcode.com/problems/minimum-path-sum/description/

Given a m x n grid filled with non-negative numbers, find a path from top left to bottom right, which minimizes the sum of all numbers along its path.
Note: You can only move either down or right at any point in time.

Example 1:
Input: grid = [[1,3,1],[1,5,1],[4,2,1]]
Output: 7
Explanation: Because the path 1 → 3 → 1 → 1 → 1 minimizes the sum.

Example 2:
Input: grid = [[1,2,3],[4,5,6]]
Output: 12

Constraints:

m == grid.length
n == grid[i].length
1 <= m, n <= 200
0 <= grid[i][j] <= 200
        */

        public class Solution
        {
            /**
            IDEA: with only one line, for every line calculate the cheapest way to reach i-th element using left and up elements.
            Example:
                row R: a, s, d, f
                previous row calculated: z, x, c, v
                new calcualted row:
                    z+a, min(z+a, s)+x, min(<-, d)+c, min(<-, f)+v
            After finish calculation, at the bottom right element we should have a calculated best way.
            */
            public int MinPathSum(int[][] grid)
            {
                var m = grid.GetLength(0);
                var n = grid[0].Length;

                var buffer = new int[n]; // buffer, starting value is +inf, except 0 at [0] index;
                for (int i = 1; i < n; i++)
                    buffer[i] = int.MaxValue;

                for (int j = 0; j < m; j++)
                {
                    for (int i = 0; i < n; i++)
                    {
                        var prevValue = buffer[i];
                        if (i == 0)
                        {
                            buffer[i] = grid[j][i] + prevValue;
                        }
                        else
                        {
                            buffer[i] = int.Min(buffer[i - 1], prevValue) + grid[j][i];
                        }
                    }
                }
                return buffer[n - 1];
            }
        }
    } //public abstract class Problem_
}
