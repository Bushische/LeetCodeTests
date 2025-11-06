using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Headers;
using System.Xml.Schema;

namespace LeetCodeTests.Medium
{
    public abstract class Problem_0109
    {
        /*
URL: https://leetcode.com/problems/convert-sorted-list-to-binary-search-tree/

Given the head of a singly linked list where elements are sorted in ascending order, convert it to a height-balanced binary search tree.

Example 1:
Input: head = [-10,-3,0,5,9]
Output: [0,-3,9,-10,null,5]
Explanation: One possible answer is [0,-3,9,-10,null,5], which represents the shown height balanced BST.

Example 2:
Input: head = []
Output: []

Constraints:

The number of nodes in head is in the range [0, 2 * 104].
-105 <= Node.val <= 105
        */
        public class Solution
        {
            /*
                IDEA: As array is ordered, we can take a mid of the array
                as a root of the tree.
                Do the same for left and for the right half.
                
                if array has even elements, use n/2 index (first element of the second half) as split
            */
            public TreeNode SortedListToBST(ListNode head)
            {
                if (head is null)
                    return null;

                // count elements in array:
                int count = 0;
                var cur = head;
                while (cur != null)
                {
                    count++;
                    cur = cur.next;
                }

                return BuildTree(head, count);
            }

            private ListNode SkipFirstN(ListNode head, int n)
            {
                while ((n > 0) && (head != null))
                {
                    head = head?.next;
                    n--;
                }
                return head;
            }

            // to avoid duplicate list, we specify how many elements of list should be used (count)
            /// <summary>
            /// Create a tree from the sublist (specified from [head] to next [count] elements)
            /// </summary>
            /// <param name="head">head of the list</param>
            /// <param name="count">elements count</param>
            /// <returns></returns>
            private TreeNode BuildTree(ListNode head, int count)
            {
                if ((head is null) || (count == 0))
                    return null;
                if (count == 1)
                    return new TreeNode(head.val, null, null);
                int leftCount = count / 2; // if odd, this int division will give lower value
                var leftTree = BuildTree(head, leftCount);
                var rootElem = SkipFirstN(head, leftCount);
                var rightTree = BuildTree(rootElem.next, count - leftCount - 1);

                return new TreeNode(rootElem.val, leftTree, rightTree);
            }
        }
    } //public abstract class Problem_
}
