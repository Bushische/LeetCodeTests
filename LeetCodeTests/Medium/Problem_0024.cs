using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Specialized;

namespace LeetCodeTests
{
	public abstract class Problem_0024
	{
		/*
Given a linked list, swap every two adjacent nodes and return its head.

For example,
Given 1->2->3->4, you should return the list as 2->1->4->3.

Your algorithm should use only constant space.You may not modify the values in the list, only nodes itself can be changed.


		*/
		public static void Test()
		{
			Solution sol = new Solution();

			/*
			var input = new int[] { 2, 7, 11, 15 };
			Console.WriteLine($"Input array: {string.Join(", ", input)}");
			*/
			var input = Utils.GenerateList(new int[] { 1, 2, 3, 4 });
			Console.WriteLine($"input '{Utils.PrintList(input)}' -> '{Utils.PrintList(sol.SwapPairs(input))}'");

			input = Utils.GenerateList(new int[] { 1, 2, 3});
			Console.WriteLine($"input '{Utils.PrintList(input)}' -> '{Utils.PrintList(sol.SwapPairs(input))}'");

			input = Utils.GenerateList(new int[] { 1, 2, 3, 4, 5});
			Console.WriteLine($"input '{Utils.PrintList(input)}' -> '{Utils.PrintList(sol.SwapPairs(input))}'");

			input = Utils.GenerateList(new int[0]);
			Console.WriteLine($"input '{Utils.PrintList(input)}' -> '{Utils.PrintList(sol.SwapPairs(input))}'");

			input = Utils.GenerateList(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9});
			Console.WriteLine($"input '{Utils.PrintList(input)}' -> '{Utils.PrintList(sol.SwapPairs(input))}'");
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
			public ListNode SwapPairs(ListNode head)
			{
				if ((head == null) || (head.next == null))
					return head;

				ListNode h = head;
				ListNode t = head.next;

				head = t;
				h.next = t.next;
				t.next = h;

				ListNode tail = h;
				ListNode nh = h.next;
				while ((nh != null) && (nh.next != null))
				{
					tail = h;
					h = nh;
					t = nh.next;

					tail.next = t;
					h.next = t.next;
					t.next = h;

					nh = h.next;
				}

				return head;
			}
		}

		// accepted
		public class Solution_recursion
		{
			public ListNode SwapPairs(ListNode head)
			{
				if ((head == null) || (head.next == null)) return head;
				ListNode h = head;
				ListNode t = head.next;
				ListNode nh = head.next.next;
				t.next = h;
				h.next = SwapPairs(nh);

				return t;
			}
		}
	}//public abstract class Problem_
}