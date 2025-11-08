using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace LeetCodeTests.Medium
{
    public abstract class Problem_0113
    {
        /*
        URL: https://leetcode.com/problems/path-sum-ii/description/

        Given the root of a binary tree and an integer targetSum, return all root-to-leaf paths where the sum of the node values in the path equals targetSum. Each path should be returned as a list of the node values, not node references.

A root-to-leaf path is a path starting from the root and ending at any leaf node. A leaf is a node with no children.

 

Example 1:


Input: root = [5,4,8,11,null,13,4,7,2,null,null,5,1], targetSum = 22
Output: [[5,4,11,2],[5,8,4,5]]
Explanation: There are two paths whose sum equals targetSum:
5 + 4 + 11 + 2 = 22
5 + 8 + 4 + 5 = 22
Example 2:


Input: root = [1,2,3], targetSum = 5
Output: []
Example 3:

Input: root = [1,2], targetSum = 0
Output: []
 

Constraints:

The number of nodes in the tree is in the range [0, 5000].
-1000 <= Node.val <= 1000
-1000 <= targetSum <= 1000

        */

        public class Solution
        {
            /* IDEA: recursive algorithm (non-recursive with Stack or Queue)
            Go down to the leaf, reducing the targetSum on every step.
            if at the leaf (no left, no right) the val is equal to targetSum, it's possible.

            If we found, that the Sum is correct, we should return the path.
            Thus, the result of the recursive function is (bool, Stack<int>).
                Stack here as we need return from the bottom to root.

            There is possible to have several paths for one node (if possible to find several paths from current node)

            */
            public IList<IList<int>> PathSum(TreeNode root, int targetSum)
            {
                IList<IList<int>> resultList = new List<IList<int>>();
                List<int> acc = [];

                CheckAndFixPathSum(root, targetSum, acc, resultList);

                return resultList;
            }

            /// <summary>
            ///
            /// </summary>
            /// <param name="root"></param>
            /// <param name="targetSum"></param>
            /// <param name="acc">accumulator of the current path</param>
            /// <param name="resultList">result list of founded paths</param>
            private void CheckAndFixPathSum(
                TreeNode root,
                int targetSum,
                List<int> acc,
                IList<IList<int>> resultList
            )
            {
                if (root is null)
                    return; // nothing to add
                acc.Add(root.val); // temporary add element to the acc
                if ((root.val == targetSum) && (root.left is null) && (root.right is null))
                { // fix result
                    List<int> newResult = [.. acc];
                    resultList.Add(newResult);
                }
                if (root.left != null)
                    CheckAndFixPathSum(root.left, targetSum - root.val, acc, resultList);
                if (root.right != null)
                    CheckAndFixPathSum(root.right, targetSum - root.val, acc, resultList);

                acc.RemoveAt(acc.Count - 1); // remove element before leave
            }
        }
    } //public abstract class Problem_
}
