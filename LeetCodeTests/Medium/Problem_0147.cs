using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net.Http.Headers;
using System.Security.Cryptography;

namespace LeetCodeTests.Medium
{
    public abstract class Problem_0147
    {
        /* 147. Insertion Sort List
        URL: https://leetcode.com/problems/insertion-sort-list/description/

Given the head of a singly linked list, sort the list using insertion sort, and return the sorted list's head.

The steps of the insertion sort algorithm:

Insertion sort iterates, consuming one input element each repetition and growing a sorted output list.
At each iteration, insertion sort removes one element from the input data, finds the location it belongs within the sorted list and inserts it there.
It repeats until no input elements remain.
The following is a graphical example of the insertion sort algorithm. The partially sorted list (black) initially contains only the first element in the list. One element (red) is removed from the input data and inserted in-place into the sorted list with each iteration.

Example 1:
Input: head = [4,2,1,3]
Output: [1,2,3,4]

Example 2:
Input: head = [-1,5,3,4,0]
Output: [-1,0,3,4,5]
 
Constraints:

The number of nodes in the list is in the range [1, 5000].
-5000 <= Node.val <= 5000

        */
        /**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
        public class Solution
        {
            /* IDEA: implement insert sort in the list
            use refs:
                - head - head of the list, returning result
                - check - first node in the unsorted part
                - preCheck - the last node in the sorted part (preCheck.next == check)
                - ins - the node before which we should insert the "check"
                - preIns - the previous to ins. if preIns == head, we need to replace the head
            */
            public ListNode InsertionSortList(ListNode head)
            {
                /* NOTE: the logic could be simplify if introduce a dummy node,
                that will held head as "next"
                we don't need to reassign Head in this case, less comparisons are required
                */
                // var originalHead = head;
                ListNode preCheck = head;
                var check = head?.next;
                while (check != null)
                {
                    // exclude "check" from the list
                    if (check != null)
                    {
                        preCheck.next = check.next;
                    }

                    // find a position to insert
                    var ins = head;
                    var preIns = head;
                    while ((ins != null) && (ins.val < check.val))
                    {
                        preIns = ins;
                        ins = ins.next;
                    }

                    // insert
                    if (preIns == head) // replace head
                    {
                        check.next = head;
                        head = check;
                    }
                    else
                    {
                        check.next = preIns.next;
                        preIns.next = check;
                    }

                    // find next check
                    preCheck = head;
                    check = head;
                    while ((check != null) && (check.val >= preCheck.val))
                    {
                        preCheck = check;
                        check = check.next;
                    }
                }

                return head;
            }
        }
    } //public abstract class Problem_
}
