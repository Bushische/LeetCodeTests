using System;
using System.Collections;
using System.Collections.Generic;
namespace LeetCodeTests
{
	public abstract class Problem_0002
	{
		/*
You are given two non-empty linked lists representing two non-negative integers.The digits are stored in reverse order and each of their nodes contain a single digit.Add the two numbers and return it as a linked list.

You may assume the two numbers do not contain any leading zero, except the number 0 itself.

Input: (2 -> 4 -> 3) + (5 -> 6 -> 4)
Output: 7 -> 0 -> 8
		*/
		/**
		* Definition for singly-linked list.
		* public class ListNode {
		*     public int val;
		*     public ListNode next;
		*     public ListNode(int x) { val = x; }
		* }
*/
		public class ListNode
		{
			public int val;
			public ListNode next;
			public ListNode(int x) { val = x; }

			public override string ToString()
			{
				string str = "";
				ListNode el = this;
				List<string> numbers = new List<string>();
				while (el != null)
				{
					numbers.Add(el.val.ToString());
					el = el.next;
				}
				str = string.Join("->", numbers);
				return str;
			}
		}

		public class Solution
		{
			public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
			{
				ListNode reslist = prvAddTwoNumbers(l1, l2, 0);
				return reslist;
			}
			private ListNode prvAddTwoNumbers(ListNode l1, ListNode l2, int additional)
			{
				if ((l1 == null) && (l2 == null) && (additional == 0))
					return null;
				int digit = (l1?.val??0) + (l2?.val??0) + additional;
				additional = digit / 10;	// next additional
				digit = digit % 10;         // reminder

				ListNode resNode = new ListNode(digit);
				resNode.next = prvAddTwoNumbers(l1?.next, l2?.next, additional);

				return resNode;
			}
		}

		public static void Test()
		{
			ListNode l1 = CreateListFromNumber(342);
			ListNode l2 = CreateListFromNumber(465);

			Solution sol = new Solution();

			ListNode l3 = sol.AddTwoNumbers(l1, l2);
			Console.WriteLine($"sum of {l1} and {l2} is {l3}");

			l2 = null;
			l3 = sol.AddTwoNumbers(l1, l2);
			Console.WriteLine($"sum of {l1} and {l2} is {l3}");

			l1 = null;
			l2 = null;
			l3 = sol.AddTwoNumbers(l1, l2);
			Console.WriteLine($"sum of {l1} and {l2} is {l3}");

			l1 = CreateListFromNumber(5);
			l2 = CreateListFromNumber(5);
			l3 = sol.AddTwoNumbers(l1, l2);
			Console.WriteLine($"sum of {l1} and {l2} is {l3}");
		}

		private static ListNode CreateListFromNumber(int number)
		{
			ListNode resList = new ListNode(number % 10);
			int rest = number / 10;
			if (rest > 0)
				resList.next = CreateListFromNumber(rest);
			return resList;
		}
	}//
}
