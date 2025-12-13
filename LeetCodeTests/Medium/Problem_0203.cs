using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace LeetCodeTests.Medium
{
    public abstract class Problem_0203
    {
        /* 203. Remove Linked List Elements
        URL: https://leetcode.com/problems/remove-linked-list-elements/

Given the head of a linked list and an integer val, remove all the nodes of the linked list that has Node.val == val, and return the new head.

Example 1:
Input: head = [1,2,6,3,4,5,6], val = 6
Output: [1,2,3,4,5]

Example 2:
Input: head = [], val = 1
Output: []

Example 3:
Input: head = [7,7,7,7], val = 7
Output: []

Constraints:

The number of nodes in the list is in the range [0, 10^4].
1 <= Node.val <= 50
0 <= val <= 50

        */
        public class Solution
        {
            /* IDEA: use two ref: current and previous
            if current == val the prev.next = cur.next
            else prev = cur, cur = cur.next
            until cur != null
            
            */
            public ListNode RemoveElements(ListNode head, int val)
            {
                var dummyHead = new ListNode(0, head);

                var prev = dummyHead;
                var cur = head;
                while (cur != null)
                {
                    if (cur.val == val)
                    {
                        prev.next = cur.next;
                    }
                    else
                    {
                        prev = cur;
                    }
                    cur = cur.next;
                }
                return dummyHead.next;
            }
        }
    } //public abstract class Problem_
}
