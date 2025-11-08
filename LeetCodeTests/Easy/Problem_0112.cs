using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography.X509Certificates;

namespace LeetCodeTests.Easy
{
    public abstract class Problem_0112
    {
        /*
        URL: https://leetcode.com/problems/path-sum/description/

        Given the root of a binary tree and an integer targetSum, return true if the tree has a root-to-leaf path such that adding up all the values along the path equals targetSum.

A leaf is a node with no children.

Example 1:
Input: root = [5,4,8,11,null,13,4,7,2,null,null,null,1], targetSum = 22
Output: true
Explanation: The root-to-leaf path with the target sum is shown.

Example 2:
Input: root = [1,2,3], targetSum = 5
Output: false
Explanation: There are two root-to-leaf paths in the tree:
(1 --> 2): The sum is 3.
(1 --> 3): The sum is 4.
There is no root-to-leaf path with sum = 5.

Example 3:
Input: root = [], targetSum = 0
Output: false
Explanation: Since the tree is empty, there are no root-to-leaf paths.
 
Constraints:

The number of nodes in the tree is in the range [0, 5000].
-1000 <= Node.val <= 1000
-1000 <= targetSum <= 1000

        */

        public class Solution
        {
            /*
            IDEA: Recursive algorithm.
            In the node N we have a value Nval.
            We can reach target Sum if
                * Nval is equal to the target Sum
                * Nval < target Sum, and (Sum-Nval) is reachable for one of the branch
            */
            public bool HasPathSum(TreeNode root, int targetSum)
            {
                if (root is null)
                    return false; // special case for empty tree

                return CheckPathSum(root, targetSum);
            }

            private bool CheckPathSum(TreeNode root, int targetSum)
            {
                if (root is null)
                    return false;
                return ((root.val == targetSum) && (root.left is null) && (root.right is null))
                    || CheckPathSum(root.left, targetSum - root.val)
                    || CheckPathSum(root.right, targetSum - root.val);
            }
        }
    } //public abstract class Problem_
}
