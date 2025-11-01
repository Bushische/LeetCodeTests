using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace LeetCodeTests.Easy
{
    public abstract class Problem_83
    {
        /*
Given the head of a sorted linked list, delete all duplicates such that each element appears only once. Return the linked list sorted as well.

Example 1:
Input: head = [1,1,2]
Output: [1,2]

Example 2:
Input: head = [1,1,2,3,3]
Output: [1,2,3]

Constraints:
The number of nodes in the list is in the range [0, 300].
-100 <= Node.val <= 100
The list is guaranteed to be sorted in ascending order.
        */
        public static void Test()
        {
            Solution sol = new Solution();

            /*
            var input = new int[] { 2, 7, 11, 15 };
            Console.WriteLine($"Input array: {string.Join(", ", input)}");
            */
        }

        /**
         * Definition for singly-linked list.
         */
        // public class ListNode
        // {
        // 	public int val;
        // 	public ListNode next;

        // 	public ListNode(int val = 0, ListNode next = null)
        // 	{
        // 		this.val = val;
        // 		this.next = next;
        // 	}

        // 	/// <summary>
        // 	/// Create a list from array
        // 	/// </summary>
        // 	/// <param name="list"></param>
        // 	/// <returns></returns>
        // 	static ListNode CreateFromTheList(List<int> list)
        // 	{
        // 		ListNode head = null;
        // 		var prevNode = head;
        // 		foreach (int elem in list)
        // 		{
        // 			var newNode = new ListNode(elem);
        // 			if (prevNode != null) prevNode.next = newNode;
        // 			head ??= newNode;
        // 			prevNode = newNode;
        // 		}
        // 		return head;
        // 	}
        // }

        public class Solution
        {
            public ListNode DeleteDuplicates(ListNode head)
            {
                var prevNode = head;
                var curNode = head?.next;
                while (curNode != null)
                {
                    if (curNode.val == prevNode.val)
                    {
                        curNode = curNode.next;
                        prevNode.next = curNode;
                    }
                    else
                    {
                        prevNode = curNode;
                        curNode = curNode.next;
                    }
                }
                return head;
            }
        }
    } //public abstract class Problem_
}
