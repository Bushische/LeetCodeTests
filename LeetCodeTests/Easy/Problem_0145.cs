using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace LeetCodeTests.Easy
{
    public abstract class Problem_0145
    {
        /* 145. Binary Tree Postorder Traversal
        URL: https://leetcode.com/problems/binary-tree-postorder-traversal/

Given the root of a binary tree, return the postorder traversal of its nodes' values.

Example 1:
Input: root = [1,null,2,3]
Output: [3,2,1]
Explanation:

Example 2:
Input: root = [1,2,3,4,5,null,8,null,null,6,7,9]
Output: [4,6,7,5,2,9,8,3,1]
Explanation:

Example 3:
Input: root = []
Output: []

Example 4:
Input: root = [1]
Output: [1]

Constraints:

The number of the nodes in the tree is in the range [0, 100].
-100 <= Node.val <= 100
 

Follow up: Recursive solution is trivial, could you do it iteratively?

        */
        public class Solution
        {
            public IList<int> PostorderTraversal(TreeNode root)
            {
                var resultList = new List<int>();
                nonRecursiveLRN(root, resultList);
                return resultList;
            }

            private void recursiveLRN(TreeNode root, IList<int> result)
            {
                if (root is null)
                    return;
                recursiveLRN(root.left, result);
                recursiveLRN(root.right, result);
                result.Add(root.val);
            }

            /* IDEA: use two stacks:
                1. for keeping the list of nodes that should be processed.
                2. for keeping nodes to result
                    Add root at the beginning to stack1
                    R: take one from stack1
                    put one.left to stack1
                    put one.right to stack1
                    put one.val to stack2
                    repeat from R
                Thus, we process right nodes first and put values to stack.
                When collect result from stack2, we will get a correct order
            */
            private void nonRecursiveLRN(TreeNode root, IList<int> result)
            {
                if (root is null)
                    return;

                var stackNodes = new Stack<TreeNode>();
                var stackValues = new Stack<int>();
                stackNodes.Push(root);

                while (stackNodes.Count > 0)
                {
                    var node = stackNodes.Pop();
                    var lnode = node.left;
                    if (lnode is not null)
                        stackNodes.Push(lnode);
                    var rnode = node.right;
                    if (rnode is not null)
                        stackNodes.Push(rnode);

                    stackValues.Push(node.val);
                }

                while (stackValues.Count > 0)
                {
                    result.Add(stackValues.Pop());
                }
            }
        }
    } //public abstract class Problem_
}
