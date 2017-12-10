using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Specialized;

namespace LeetCodeTests
{
	public abstract class Problem_0019
	{
		/*
Given a linked list, remove the nth node from the end of list and return its head.

For example,

   Given linked list: 1->2->3->4->5, and n = 2.

   After removing the second node from the end, the linked list becomes 1->2->3->5.
Note:
Given n will always be valid.
Try to do this in one pass.
		*/
		public static void Test()
		{
			Solution sol = new Solution();

			/*
			var input = new int[] { 2, 7, 11, 15 };
			Console.WriteLine($"Input array: {string.Join(", ", input)}");
			*/

			ListNode head = GenerateList(new int[] { 1, 2, 3, 4, 5 });
			int nth = 2;
			Console.WriteLine($"For list '{head?.PrintList()}' and n={nth} -> '{sol.RemoveNthFromEnd(head, nth)?.PrintList()}'");

			//nth = 8;
			//Console.WriteLine($"For list '{head?.PrintList()}' and n={nth} -> '{sol.RemoveNthFromEnd(head, nth)?.PrintList()}'");

			//nth = 0;
			//Console.WriteLine($"For list '{head?.PrintList()}' and n={nth} -> '{sol.RemoveNthFromEnd(head, nth)?.PrintList()}'");

			nth = 1;
			Console.WriteLine($"For list '{head?.PrintList()}' and n={nth} -> '{sol.RemoveNthFromEnd(head, nth)?.PrintList()}'");

			nth = 3;
			Console.WriteLine($"For list '{head?.PrintList()}' and n={nth} -> '{sol.RemoveNthFromEnd(head, nth)?.PrintList()}'");

			//head = null;
			//nth = 2;
			//Console.WriteLine($"For list '{head?.PrintList()}' and n={nth} -> '{sol.RemoveNthFromEnd(head, nth)?.PrintList()}'");

			head = GenerateList(new int[] { 1, 2});
			nth = 1;
			Console.WriteLine($"For list '{head?.PrintList()}' and n={nth} -> '{sol.RemoveNthFromEnd(head, nth)?.PrintList()}'");
		}

		private static ListNode GenerateList(int[] inArr, int index = 0)
		{
			if (index >= inArr.Length)
				return null;
			
			ListNode res = new ListNode(inArr[index]);
			res.next = GenerateList(inArr, index + 1);
			return res;
		}

		/**
		* Definition for singly-linked list.
		**/
		public class ListNode
		{
			public int val;
			public ListNode next;
			public ListNode(int x) { val = x; }

			public string PrintList()
			{
				return val.ToString() + ((next == null) ? "" : (" -> " + next.PrintList()));
			}
		}

		public class Solution
		{
			/*
Submission Result: Wrong Answer 

Input: [1,2] 1
Output:[2]
Expected:[1]
			*/
			public ListNode RemoveNthFromEnd(ListNode head, int n)
			{
				ListNode t1 = head;
				ListNode t2 = head;
				for (int i = 0; i < n; i++)
					t2 = t2.next;
				if (t2 != null)
				{
					while (t2.next != null)
					{
						t2 = t2.next;
						t1 = t1.next;
					}
					t1.next = t1.next?.next;
				}
				else if (t1 == head)
					head = t1.next;
				
				return head;
			}
		}

		public class Solution_noGood
		{
			public ListNode RemoveNthFromEnd(ListNode head, int n)
			{
				int length = 0;
				return GetListWithoutNth(head, n, out length);
			}
//Given linked list: 1->2->3->4->5, and n = 2.
			private ListNode GetListWithoutNth(ListNode node, int n, out int tailLength)
			{
				tailLength = 0;
				if (node == null)
					return node;
				node.next = GetListWithoutNth(node.next, n, out tailLength);
				tailLength++;
				if (tailLength == n)
					return node.next;
				else
					return node;
			}
		}
	}//public abstract class Problem_
}