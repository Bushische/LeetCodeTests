using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Specialized;

namespace LeetCodeTests
{
	public abstract class Problem_0086
	{
		/*
Given a linked list and a value x, partition it such that all nodes less than x come before nodes greater than or equal to x.

You should preserve the original relative order of the nodes in each of the two partitions.

For example,
Given 1->4->3->2->5->2 and x = 3,
return 1->2->2->4->3->5.
		*/
		public static void Test()
		{
			Solution sol = new Solution();

			/*
			var input = new int[] { 2, 7, 11, 15 };
			Console.WriteLine($"Input array: {string.Join(", ", input)}");
			*/

			var input = Utils.GenerateList(new int[] { 1, 4, 3, 2, 5, 2 });
			var part = 3;
			Console.WriteLine($"for input list '{Utils.PrintList(input)}' and barier '{part}':\n\toutput: '{Utils.PrintList(sol.Partition(input, part))}'");

			input = Utils.GenerateList(new int[] { 1,9,2,8,3,7,4,7,5,6});
			part = 5;
			Console.WriteLine($"for input list '{Utils.PrintList(input)}' and barier '{part}':\n\toutput: '{Utils.PrintList(sol.Partition(input, part))}'");

			input = Utils.GenerateList(new int[] {});
			part = 5;
			Console.WriteLine($"for input list '{Utils.PrintList(input)}' and barier '{part}':\n\toutput: '{Utils.PrintList(sol.Partition(input, part))}'");

			input = Utils.GenerateList(new int[] {1,2,3,4});
			part = 5;
			Console.WriteLine($"for input list '{Utils.PrintList(input)}' and barier '{part}':\n\toutput: '{Utils.PrintList(sol.Partition(input, part))}'");

			input = Utils.GenerateList(new int[] {6,7,8,9});
			part = 5;
			Console.WriteLine($"for input list '{Utils.PrintList(input)}' and barier '{part}':\n\toutput: '{Utils.PrintList(sol.Partition(input, part))}'");
		}

		public class Solution
		{
			public ListNode Partition(ListNode head, int x)
			{
				ListNode left = new ListNode(0);
				ListNode right = new ListNode(0);
				ListNode leftLast = left;
				ListNode rightLast = right;

				while (head != null)
				{
					if (head.val < x)
					{
						leftLast.next = head;
						leftLast = head;
					}
					else
					{
						rightLast.next = head;
						rightLast = head;
					}
					head = head.next;
				}
				rightLast.next = null;
				leftLast.next = right.next;
				return left.next;
			}
		}

		public class Solution_passed
		{
			public ListNode Partition(ListNode head, int x)
			{
				ListNode headLast = null;
				ListNode right = null;
				ListNode rightLast = null;

				ListNode cur = head;
				head = null;
				while (cur != null)
				{
					if (cur.val < x)
					{
						if (head == null)
						{
							head = cur;
							headLast = cur;
						}
						else
						{
							headLast.next = cur;
							headLast = cur;
						}
					}
					else
					{
						if (right == null)
						{
							right = cur;
							rightLast = cur;
						}
						else
						{
							rightLast.next = cur;
							rightLast = cur;
						}
					}
					cur = cur.next;
				}
				if (head == null)
					head = right;
				if (headLast != null)
					headLast.next = right;
				if (rightLast != null)
					rightLast.next = null;
				return head;

			}
		}
	}//public abstract class Problem_
}