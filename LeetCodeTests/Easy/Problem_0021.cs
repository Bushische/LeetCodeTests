using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Specialized;

namespace LeetCodeTests
{
	public abstract class Problem_0021
	{
		/*
Merge two sorted linked lists and return it as a new list.The new list should be made by splicing together the nodes of the first two lists.


		*/
		public static void Test()
		{
			Solution sol = new Solution();

			/*
			var input = new int[] { 2, 7, 11, 15 };
			Console.WriteLine($"Input array: {string.Join(", ", input)}");
			*/
			ListNode l1 = Utils.GenerateList(new int[] { 1, 3, 5, 7, 9 });
			ListNode l2 = Utils.GenerateList(new int[] { 2, 4, 6, 8 });
			Console.WriteLine($"Merge two list:\n\t{l1?.PrintList()}\n\t{l2?.PrintList()}\nResult: {sol.MergeTwoLists(l1, l2)?.PrintList()}");
		}

		public class Solution
		{
			public ListNode MergeTwoLists(ListNode l1, ListNode l2)
			{
				if (l1 == null)
					return l2;
				if (l2 == null)
					return l1;
				
				ListNode head = null;
				ListNode tail = null;
				ListNode t1 = l1;
				ListNode t2 = l2;
				if (t1.val < t2.val)
				{
					head = t1;
					t1 = t1.next;
				}
				else
				{
					head = t2;
					t2 = t2.next;
				}
				tail = head;
				while ((t1 != null) || (t2 != null))
				{
					if ((t1 != null) && (t1.val <= (t2?.val ?? int.MaxValue)))
					{
						tail.next = t1;
						t1 = t1.next;
					}
					else
					{
						tail.next = t2;
						t2 = t2?.next;
					}
					tail = tail.next;
				}

				return head;
			}
		}
	}//public abstract class Problem_
}