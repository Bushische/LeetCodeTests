using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace LeetCodeTests.Easy
{
    public abstract class Problem_0118
    {
        /*
        URL: https://leetcode.com/problems/pascals-triangle/description/

Given an integer numRows, return the first numRows of Pascal's triangle.

In Pascal's triangle, each number is the sum of the two numbers directly above it as shown:

Example 1:
Input: numRows = 5
Output: [[1],[1,1],[1,2,1],[1,3,3,1],[1,4,6,4,1]]

Example 2:
Input: numRows = 1
Output: [[1]]

Constraints:

1 <= numRows <= 30
        */

        public class Solution
        {
            /* IDEA: calculate line by line and print result
            number of rows == number of element in row
            every row starts with 1 and finish with 1
            */
            public IList<IList<int>> Generate(int numRows)
            {
                var resultList = new List<IList<int>>();
                List<int> rowList = [1];

                // initial state
                resultList.Add(rowList);

                for (int row = 1; row < numRows; row++)
                {
                    var prevList = rowList;
                    rowList = new List<int> { 1 };
                    for (int index = 1; index < row; index++)
                    {
                        rowList.Add(prevList[index - 1] + prevList[index]);
                    }
                    rowList.Add(1); // finish 1
                    resultList.Add(rowList);
                }

                return resultList;
            }
        }
    } //public abstract class Problem_
}
