using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace LeetCodeTests.Medium
{
    public abstract class Problem_0098
    {
        /*
        URL: https://leetcode.com/problems/validate-binary-search-tree/description/

Given the root of a binary tree, determine if it is a valid binary search tree (BST).

A valid BST is defined as follows:
The left subtree of a node contains only nodes with keys strictly less than the node's key.
The right subtree of a node contains only nodes with keys strictly greater than the node's key.
Both the left and right subtrees must also be binary search trees.

Example 1:
Input: root = [2,1,3]
Output: true

Example 2:
Input: root = [5,1,4,null,null,3,6]
Output: false
Explanation: The root node's value is 5 but its right child's value is 4.

Constraints:

The number of nodes in the tree is in the range [1, 104].
-231 <= Node.val <= 231 - 1

        */
        public class Solution
        {
            /*
            IDEA: the tree is valid if:
                1. left < root
                2. right > root
                3. left subtree is valid tree
                4. max from left subtree < root
                5. right subtree is valid tree
                6. min from right subtree > root
            */
            public bool IsValidBST(TreeNode root)
            {
                var (treeValid, _, _) = isValidTree(root);
                return treeValid;
            }

            /// <summary>
            /// recursive implementation
            /// </summary>
            /// <param name="root"></param>
            /// <returns> (is valid BST, MIN, MAX) </returns>
            private (bool, int, int) isValidTree(TreeNode root)
            {
                if (root == null)
                    return (true, int.MaxValue, int.MinValue); // need to provide opposite values for Min and Max

                var (leftValid, leftMin, leftMax) = isValidTree(root.left);
                if (!leftValid)
                    return (false, 0, 0); // doesn't matter what return as Min and Max with False

                var (rightValid, rightMin, rightMax) = isValidTree(root.right);
                if (!rightValid)
                    return (false, 0, 0); // doesn't matter what return as Min and Max with False

                return (
                    ((root.left == null) || (leftMax < root.val))
                        && ((root.right == null) || (rightMin > root.val)),
                    int.Min(root.val, leftMin),
                    int.Max(root.val, rightMax)
                );
            }
        }
    } //public abstract class Problem_
}
