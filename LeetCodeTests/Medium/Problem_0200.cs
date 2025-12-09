using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace LeetCodeTests.Medium
{
    public abstract class Problem_0200
    {
        /* 200. Number of Islands
        URL: https://leetcode.com/problems/number-of-islands/description/

Given an m x n 2D binary grid grid which represents a map of '1's (land) and '0's (water), return the number of islands.
An island is surrounded by water and is formed by connecting adjacent lands horizontally or vertically. You may assume all four edges of the grid are all surrounded by water.

Example 1:
Input: grid = [
  ["1","1","1","1","0"],
  ["1","1","0","1","0"],
  ["1","1","0","0","0"],
  ["0","0","0","0","0"]
]
Output: 1

Example 2:
Input: grid = [
  ["1","1","0","0","0"],
  ["1","1","0","0","0"],
  ["0","0","1","0","0"],
  ["0","0","0","1","1"]
]
Output: 3
 
Constraints:
m == grid.length
n == grid[i].length
1 <= m, n <= 300
grid[i][j] is '0' or '1'.

        */
        public class Solution
        {
            /* IDEA: pass the array from left top to right bottom
            if we find a land element, and we didn't check it before, increase the number
            of islands, mark all island's land as checked

            we need a set of elements we already passed
            we need a counter of islands
            */
            public int NumIslands(char[][] grid)
            {
                List<(int, int)> foundLand = new();
                int islandsFound = 0;
                for (int row = 0; row < grid.Length; row++)
                {
                    for (int cell = 0; cell < grid[row].Length; cell++)
                    {
                        if ((GetCell(row, cell) == '1') && (!foundLand.Contains((row, cell))))
                        {
                            islandsFound++;
                            MarkIslandLand(row, cell);
                        }
                    }
                }

                return islandsFound;
                // safely return element by coordinates with fallback to "water"
                char GetCell(int r, int c)
                {
                    if ((r < 0) || (r >= grid.Length))
                        return '0';
                    if ((c < 0) || (c >= grid[r].Length))
                        return '0';
                    return grid[r][c];
                }
                // local function to mark all connected land as checked
                // TIME EXCEEDED
                void CollectIslandLand(int r, int c)
                {
                    if (!foundLand.Contains((r, c)))
                    {
                        if (GetCell(r, c) == '1')
                        {
                            foundLand.Add((r, c));
                            CollectIslandLand(r - 1, c);
                            CollectIslandLand(r, c + 1);
                            CollectIslandLand(r + 1, c);
                            CollectIslandLand(r, c - 1);
                        }
                    }
                }

                // local function to mark all connected land as checked
                void MarkIslandLand(int r, int c)
                {
                    if (GetCell(r, c) == '1')
                    {
                        grid[r][c] = '2';
                        MarkIslandLand(r - 1, c);
                        MarkIslandLand(r, c + 1);
                        MarkIslandLand(r + 1, c);
                        MarkIslandLand(r, c - 1);
                    }
                }
            }
        }
    } //public abstract class Problem_
}
