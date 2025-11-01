using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.NetworkInformation;

namespace LeetCodeTests.Easy
{
    public abstract class Problem_0144
    {
        /* URL: https://leetcode.com/problems/binary-tree-preorder-traversal/description/

        Given the root of a binary tree, return the preorder traversal of its nodes' values.

 

Example 1:
Input: root = [1,null,2,3]
Output: [1,2,3]

Example 2:
Input: root = [1,2,3,4,5,null,8,null,null,6,7,9]
Output: [1,2,4,5,6,7,3,8,9]

Example 3:
Input: root = []
Output: []

Example 4:
Input: root = [1]
Output: [1]

Constraints:
The number of nodes in the tree is in the range [0, 100].
-100 <= Node.val <= 100

Follow up: Recursive solution is trivial, could you do it iteratively?
        */
        public static void Test()
        {
            Solution sol = new Solution();

            /*
            var input = new int[] { 2, 7, 11, 15 };
            Console.WriteLine($"Input array: {string.Join(", ", input)}");
            */
        }

        public class Solution
        {
            public IList<int> PreorderTraversal(TreeNode root)
            {
                return NonRecursiveImpl(root);
            }

            private static IList<int> RecursiveImpl(TreeNode root)
            {
                if (root is null)
                    return [];

                var thisNode = new List<int> { root.val };
                var leftNodeOrdered = RecursiveImpl(root.left);
                var rightNodeOrdered = RecursiveImpl(root.right);

                return [.. thisNode, .. leftNodeOrdered, .. rightNodeOrdered];
            }

            private static IList<int> NonRecursiveImpl(TreeNode root)
            {
                // based on Stack
                IList<int> resultList = new List<int>();
                var stack = new Stack<TreeNode>();
                var curNode = root;

                while ((curNode != null) || (stack.Count > 0))
                {
                    if (curNode != null)
                    {
                        resultList.Add(curNode.val);
                        stack.Push(curNode);
                        curNode = curNode.left;
                    }
                    else
                    {
                        curNode = stack.Pop();
                        curNode = curNode.right;
                    }
                }
                return resultList;
            }
        }
    } //public abstract class Problem_
}
