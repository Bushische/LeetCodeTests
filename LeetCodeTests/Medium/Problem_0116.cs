using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography.X509Certificates;

namespace LeetCodeTests.Medium
{
    public abstract class Problem_0116
    {
        /*
        URL: https://leetcode.com/problems/populating-next-right-pointers-in-each-node/description/

You are given a perfect binary tree where all leaves are on the same level, and every parent has two children. The binary tree has the following definition:

struct Node {
  int val;
  Node *left;
  Node *right;
  Node *next;
}
Populate each next pointer to point to its next right node. If there is no next right node, the next pointer should be set to NULL.

Initially, all next pointers are set to NULL.

Example 1:
Input: root = [1,2,3,4,5,6,7]
Output: [1,#,2,3,#,4,5,6,7,#]
Explanation: Given the above perfect binary tree (Figure A), your function should populate each next pointer to point to its next right node, just like in Figure B. The serialized output is in level order as connected by the next pointers, with '#' signifying the end of each level.

Example 2:
Input: root = []
Output: []
 
Constraints:
The number of nodes in the tree is in the range [0, 212 - 1].
-1000 <= Node.val <= 1000
 
Follow-up:
You may only use constant extra space.
The recursive approach is fine. You may assume implicit stack space does not count as extra space for this problem.
        */

        // Definition for a Node.
        public class Node
        {
            public int val;
            public Node left;
            public Node right;
            public Node next;

            public Node() { }

            public Node(int _val)
            {
                val = _val;
            }

            public Node(int _val, Node _left, Node _right, Node _next)
            {
                val = _val;
                left = _left;
                right = _right;
                next = _next;
            }

            public static Node ConvertFromTreeNode(TreeNode root)
            {
                if (root is null)
                    return null;
                var leftSubTree = Node.ConvertFromTreeNode(root.left);
                var rightSubTree = Node.ConvertFromTreeNode(root.right);
                var result = new Node(root.val, leftSubTree, rightSubTree, null);
                return result;
            }

            // print to expected format (as in tests)
            public string PrintTree()
            {
                var result = "";
                var rootNode = this;
                while (rootNode != null)
                {
                    var node = rootNode;
                    while (node != null)
                    {
                        result += $"{node.val},";
                        node = node.next;
                    }
                    result += "#,";
                    rootNode = rootNode.left;
                }
                if (result.EndsWith(','))
                    result = result[..^1];
                return result;
            }
        }

        public class Solution
        {
            /* IDEA: use Breadth First Search algorithm to pass the tree from left to right by levels.
            Using 2 queues for keeping the current level nods and then pass through it, set Next and calculate the next level queue

            */
            public Node Connect(Node root)
            {
                var currentLevel = new Queue<Node>(); // current level of tree, to set Next

                currentLevel.Enqueue(root);

                while (currentLevel.Count > 0)
                {
                    var nextLevel = new Queue<Node>(); // collecting nodes from the next level during the passing the currentLevel
                    var currentNode = currentLevel.Dequeue();
                    while (currentNode != null)
                    {
                        nextLevel.Enqueue(currentNode.left);
                        nextLevel.Enqueue(currentNode.right);

                        var nextNode = (currentLevel.Count > 0) ? currentLevel.Dequeue() : null;
                        currentNode.next = nextNode;
                        currentNode = nextNode;
                    }
                    currentLevel = nextLevel;
                }

                return root;
            }

            // recursive approach (from Solutions)
            // start from (SetNext(root.left, root.right))
            public void SetNext(Node node1, Node node2)
            {
                if (node1 == null && node2 == null)
                {
                    return;
                }
                node1.next = node2;
                SetNext(node1.left, node1.right);
                SetNext(node1.right, node2.left);
                SetNext(node2.left, node2.right);
            }

            // another non-recursive approach
            public Node Connect(Node root)
            {
                if (root == null)
                    return root;

                Node L = root.left,
                    R = root.right,
                    N = root.next;

                if (L != null)
                {
                    L.next = R;
                    if (N != null)
                    {
                        R.next = N.left;
                    }
                    Connect(L);
                    Connect(R);
                }
                return root;
            }
        }
    } //public abstract class Problem_
}
