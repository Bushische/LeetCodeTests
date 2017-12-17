using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Specialized;

namespace LeetCodeTests
{
	public abstract class Problem_0061
	{
		/*
Given a list, rotate the list to the right by k places, where k is non-negative.

Example:
Given 1->2->3->4->5->NULL and k = 2,
return 4->5->1->2->3->NULL.
		*/
		public static void Test()
		{
			Solution sol = new Solution();

			/*
			var input = new int[] { 2, 7, 11, 15 };
			Console.WriteLine($"Input array: {string.Join(", ", input)}");
			*/
			var head = Utils.GenerateList(new int[] { 1, 2, 3, 4, 5 });
			var k = 2;
			Console.WriteLine($"For list '{Utils.PrintList(head)}' and k={k} -> '{Utils.PrintList(sol.RotateRight(head, k))}' (wait 4->5->1->2->3->NULL)");

			// k = length
			head = Utils.GenerateList(new int[] { 1, 2, 3, 4, 5 });
			k = 5;
			Console.WriteLine($"For list '{Utils.PrintList(head)}' and k={k} -> '{Utils.PrintList(sol.RotateRight(head, k))}' (wait 1->2->3->4->5->NULL)");

			// k > length
			head = Utils.GenerateList(new int[] { 1, 2 });
			k = 7;
			Console.WriteLine($"For list '{Utils.PrintList(head)}' and k={k} -> '{Utils.PrintList(sol.RotateRight(head, k))}' (wait 2->1->NULL)");

			// length = 1
			head = Utils.GenerateList(new int[] { 1});
			k = 7;
			Console.WriteLine($"For list '{Utils.PrintList(head)}' and k={k} -> '{Utils.PrintList(sol.RotateRight(head, k))}' (wait 1->NULL)");

		}

		/**
		* Definition for singly-linked list.
		* public class ListNode {
		*     public int val;
		*     public ListNode next;
		*     public ListNode(int x) { val = x; }
		* }
*/
		public class Solution
		{
			public ListNode RotateRight(ListNode head, int k)
			{
				if ((k <= 0) || (head == null))
					return head;
				ListNode first = head;
				ListNode second = head;
				int tmpk = k;
				int length = 0;
				while (tmpk > 0)
				{
					first = first.next;
					length++;
					tmpk--;
					if ((first == null) && (tmpk >= 0))
					{   // k > length
						if (length == 1)
							return head;
						first = head;
						tmpk = tmpk % length;
					}
				}
				if (first == null) 	// k = length  => no need to rotate
					return null;
				while (first.next != null)
				{
					first = first.next;
					second = second.next;
				}
				// make rotation
				first.next = head;
				head = second.next;
				second.next = null;

				return head;
			}
		}
	}//public abstract class Problem_
}