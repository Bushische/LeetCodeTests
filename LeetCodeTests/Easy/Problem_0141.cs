using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace LeetCodeTests.Easy
{
    public abstract class Problem_0141
    {
        /* 141. Linked List Cycle
        URL: https://leetcode.com/problems/linked-list-cycle/

Given head, the head of a linked list, determine if the linked list has a cycle in it.

There is a cycle in a linked list if there is some node in the list that can be reached again by continuously following the next pointer. Internally, pos is used to denote the index of the node that tail's next pointer is connected to. Note that pos is not passed as a parameter.

Return true if there is a cycle in the linked list. Otherwise, return false.

Example 1:
Input: head = [3,2,0,-4], pos = 1
Output: true
Explanation: There is a cycle in the linked list, where the tail connects to the 1st node (0-indexed).

Example 2:
Input: head = [1,2], pos = 0
Output: true
Explanation: There is a cycle in the linked list, where the tail connects to the 0th node.

Example 3:
Input: head = [1], pos = -1
Output: false
Explanation: There is no cycle in the linked list.
 
Constraints:

The number of the nodes in the list is in the range [0, 10^4].
-10^5 <= Node.val <= 10^5
pos is -1 or a valid index in the linked-list.
 

Follow up: Can you solve it using O(1) (i.e. constant) memory?

        */
        /**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) {
 *         val = x;
 *         next = null;
 *     }
 * }
 */
        public class Solution
        {
            /* IDEA: if the link has a cycle, it means, that we cannot reach the list end
            There are two options:
            1. check, if we make 10^4+1 step in list
            2. run two pointers, the one with speed x1, the second with x2. If at some point they are equal, we have cycle in the list.
            */
            public bool HasCycle(ListNode head)
            {
                var one = head; // x1
                var two = head?.next; // x2
                while ((one != two) && (two != null) && (one != null))
                {
                    one = one?.next;
                    two = two?.next?.next;
                }
                if ((one == two) && (one != null))
                    return true; // there is a cycle in the list
                return false; // there is no cycle in the list
            }
        }
    } //public abstract class Problem_
}
