using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata;

namespace LeetCodeTests.Medium
{
    public abstract class Problem_0130
    {
        /*
        URL: https://leetcode.com/problems/surrounded-regions/

You are given an m x n matrix board containing letters 'X' and 'O', capture regions that are surrounded:

Connect: A cell is connected to adjacent cells horizontally or vertically.
Region: To form a region connect every 'O' cell.
Surround: The region is surrounded with 'X' cells if you can connect the region with 'X' cells and none of the region cells are on the edge of the board.
To capture a surrounded region, replace all 'O's with 'X's in-place within the original board. You do not need to return anything.

Example 1:
Input: board = [["X","X","X","X"],
                ["X","O","O","X"],
                ["X","X","O","X"],
                ["X","O","X","X"]]

Output: [["X","X","X","X"],
         ["X","X","X","X"],
         ["X","X","X","X"],
         ["X","O","X","X"]]
Explanation:
In the above diagram, the bottom region is not captured because it is on the edge of the board and cannot be surrounded.

Example 2:
Input: board = [["X"]]
Output: [["X"]]

Constraints:
m == board.length
n == board[i].length
1 <= m, n <= 200
board[i][j] is 'X' or 'O'.

        */
        public class Solution
        {
            /* IDEA: as the only the region that has connection to the edge cell, let's just check with edges and find all connected elements.
            All the rest can be safely updated to X (they are in isolated and surrounded regions)


            Instead of collecting the list of nodes, let's mark all secured one with 'T'
            After check, pass through the whole array and update:
                O -> X
                T -> O
            */

            public void Solve(char[][] board)
            {
                MarkAllEdgeConnectedCells(board);
                CaptureInternalRegions(board);
            }

            /// <summary>
            /// COllect all cells, that are on the edge, or directly connected to such
            /// </summary>
            /// <param name="board"></param>
            /// <returns>List of all cells, that cannot be surrounded</returns>
            private void MarkAllEdgeConnectedCells(char[][] board)
            {
                // first and last row - full
                // all other - only 0 and the last
                for (int row = 0; row < board.Length; row++)
                {
                    if ((row == 0) || (row == board.Length - 1))
                    {
                        for (int element = 0; element < board[row].Length; element++)
                        {
                            CollectAllConnectedRecursively(row, element, board);
                        }
                    }
                    else
                    {
                        CollectAllConnectedRecursively(row, 0, board);
                        CollectAllConnectedRecursively(row, board[row].Length - 1, board);
                    }
                }
                // all intermediate rows
            }

            private void CollectAllConnectedRecursively(int row, int element, char[][] board)
            {
                // out of bounds
                if (
                    (row < 0)
                    || (row >= board.Length)
                    || (element < 0)
                    || (element >= board[0].Length)
                )
                    return;
                if (board[row][element] == 'O')
                {
                    board[row][element] = 'T';
                    CollectAllConnectedRecursively(row - 1, element, board);
                    CollectAllConnectedRecursively(row + 1, element, board);
                    CollectAllConnectedRecursively(row, element - 1, board);
                    CollectAllConnectedRecursively(row, element + 1, board);
                }
            }

            /// <summary>
            /// Execute final change:
            /// * O -> X
            /// * T -> O (T is for temporary secured and connected to the edge cells)
            /// </summary>
            private void CaptureInternalRegions(char[][] board)
            {
                for (int row = 0; row < board.Length; row++)
                {
                    for (int el = 0; el < board[row].Length; el++)
                    {
                        if (board[row][el] == 'O')
                            board[row][el] = 'X';
                        if (board[row][el] == 'T')
                            board[row][el] = 'O';
                    }
                }
            }
        }
    } //public abstract class Problem_
}
