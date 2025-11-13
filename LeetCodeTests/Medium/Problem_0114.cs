using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace LeetCodeTests.Medium
{
    public abstract class Problem_0114
    {
        /*
        URL: https://leetcode.com/problems/flatten-binary-tree-to-linked-list/description/

Given the root of a binary tree, flatten the tree into a "linked list":

The "linked list" should use the same TreeNode class where the right child pointer points to the next node in the list and the left child pointer is always null.
The "linked list" should be in the same order as a pre-order traversal of the binary tree.
 

Example 1:
Input: root = [1,2,5,3,4,null,6]
Output: [1,null,2,null,3,null,4,null,5,null,6]

Example 2:
Input: root = []
Output: []

Example 3:
Input: root = [0]
Output: [0]
 
Constraints:

The number of nodes in the tree is in the range [0, 2000].
-100 <= Node.val <= 100
 

Follow up: Can you flatten the tree in-place (with O(1) extra space)?
        */

        public class Solution
        {
            /* IDEA: use stack for passing through the tree. Add nodes in order:
                1. push root
                2. repeat algorithm for the left subtree
                3. repeat algorithm for the right subtree
            we have required sequence in the reverse order.
            keep previous node (as previous, with initial state as NULL)
            pop value from stack, set left to NULL and right to previous
            assign popped node to previous
            repeat until the stack is empty
            
            return last previous as the function result
            // Initial root will be updated and will be the root of the tree

            Recursive
            O(N) memory (to keep in stack references)
            O(N) operations

            can be done without recursion with two stacks. One for passing the tree
            and the second for keeping track of all nodes
            */
            public void Flatten(TreeNode root)
            {
                Stack<TreeNode> stack = new();
                convertTreeToStack(root, stack);

                // unwrap the tree to the list
                TreeNode previous = null;
                while (stack.Count > 0)
                {
                    var node = stack.Pop();
                    node.left = null;
                    node.right = previous;
                    previous = node;
                }
            }

            // IDEA of non-recursive method is:
            // * for any node A we take A.right and try to move it as right of most deep right node without right from A.left
            // * then move A.left as A.right, set A.left = null
            public void FlattenWithO1(TreeNode root)
            {
                var node = root;
                while (node != null)
                {
                    var right = node.right;
                    var left = node.left;
                    if (left != null)
                    {
                        if (right != null) // move deep inside
                        {
                            while (left.right != null)
                                left = left.right;
                            left.right = right;
                        }
                        node.right = node.left;
                        node.left = null;
                    }
                    node = node.right;
                }
            }

            private void convertTreeToStack(TreeNode root, Stack<TreeNode> stack)
            {
                if (root is null)
                    return;
                stack.Push(root);
                convertTreeToStack(root.left, stack);
                convertTreeToStack(root.right, stack);
            }
        }
    } //public abstract class Problem_
}
