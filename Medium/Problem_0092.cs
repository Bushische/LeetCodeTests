using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Specialized;

namespace LeetCodeTests
{
	public abstract class Problem_0092
	{
		/*
92. Reverse Linked List II

Reverse a linked list from position m to n.Do it in-place and in one-pass.

For example:
Given 1->2->3->4->5->NULL, m = 2 and n = 4,

return 1->4->3->2->5->NULL.

Note:
Given m, n satisfy the following condition:
1 ≤ m ≤ n ≤ length of list.


		*/
		public static void Test()
		{
			Solution sol = new Solution();

			/*
			var input = new int[] { 2, 7, 11, 15 };
			Console.WriteLine($"Input array: {string.Join(", ", input)}");
			*/
			var List = Utils.GenerateList(new int[] { 1, 2, 3, 4, 5 });
			var m = 2;
			var n = 4;
			Console.WriteLine($"Original list: '{Utils.PrintList(List)}'. Try reverse from {m} to {n}");
			Console.WriteLine($"Rotated list:  '{Utils.PrintList(sol.ReverseBetween(List, m, n))}' (waits 1-4-3-2-5)");

			List = Utils.GenerateList(new int[] { 1, 2, 3, 4, 5 });
			m = 1;
			n = 5;
			Console.WriteLine($"Original list: '{Utils.PrintList(List)}'. Try reverse from {m} to {n}");
			Console.WriteLine($"Rotated list:  '{Utils.PrintList(sol.ReverseBetween(List, m, n))}' (waits 5-4-3-2-1)");
		}


		public class Solution
		{
			public ListNode ReverseBetween(ListNode head, int m, int n)
			{
				var reshead = new ListNode(0);		//artificial node
				reshead.next = head;        // last node which not touched

				var reverseHead = reshead;
				int index = 1;
				while (index < m)
				{
					reverseHead = reverseHead.next;
					index++;
				}
				var reverseTail = reverseHead.next;
				index++;
				while (index <= n)
				{
					var tmp = reverseTail.next;								//3
					reverseTail.next = tmp.next;							//4
					tmp.next = reverseHead.next;
					reverseHead.next = tmp;

					index++;
				}
				return reshead.next;
			}
		}
	}//public abstract class Problem_
}