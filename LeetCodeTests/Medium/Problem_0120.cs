using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace LeetCodeTests.Medium
{
    public abstract class Problem_0120
    {
        /*
        URL: https://leetcode.com/problems/triangle/

        Given a triangle array, return the minimum path sum from top to bottom.

For each step, you may move to an adjacent number of the row below. More formally, if you are on index i on the current row, you may move to either index i or index i + 1 on the next row.

 

Example 1:
Input: triangle = [[2],[3,4],[6,5,7],[4,1,8,3]]
Output: 11
Explanation: The triangle looks like:
   2
  3 4
 6 5 7
4 1 8 3
The minimum path sum from top to bottom is 2 + 3 + 5 + 1 = 11 (underlined above).

Example 2:
Input: triangle = [[-10]]
Output: -10

Constraints:
1 <= triangle.length <= 200
triangle[0].length == 1
triangle[i].length == triangle[i - 1].length + 1
-104 <= triangle[i][j] <= 104
 
Follow up: Could you do this using only O(n) extra space, where n is the total number of rows in the triangle?

        */

        public class Solution
        {
            /* IDEA:
            make a gradient descent from top to bottom on every step calculate a minimum path to each element of the row
            As soon as we reach the bottom line and calucate it, the minimum value in the final calculation will be our target path.

            row I (0 .. n) has I+1 element
            any J element can be reached from (I-1)(J-1) or (I-1)(J) element of the previous row (if exists).
            the edge case - the first and the last element in the row.

            we don't need more than N elements to keep the max row number
            */
            public int MinimumTotal(IList<IList<int>> triangle)
            {
                int N = triangle.Count; // number rows and the number elements in the last row
                if (N == 0)
                    return 0;
                int[] acc = new int[N];
                acc[0] = triangle[0][0];

                // special buffer for original acc values, as we change them during the pass
                int el0 = 0;
                int el1 = acc[0];

                for (var row = 1; row < N; row++)
                {
                    for (var el = 0; el <= row; el++)
                    {
                        el0 = el1;
                        el1 = acc[el];
                        if (el == 0)
                        {
                            acc[el] = el1 + triangle[row][el];
                        }
                        else if (el == row)
                        {
                            acc[el] = triangle[row][el] + el0;
                        }
                        else
                        {
                            acc[el] = triangle[row][el] + int.Min(el0, el1);
                        }
                    }
                }
                return acc.Min();
            }
        }

        // best alternatives:
        // 1. got from the bottom (-2) to the up, can leave without any accumulators
    } //public abstract class Problem_
}
