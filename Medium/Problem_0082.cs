using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Specialized;

namespace LeetCodeTests
{
	public abstract class Problem_0082
	{
		/*
Given a sorted linked list, delete all nodes that have duplicate numbers, leaving only distinct numbers from the original list.

For example,
Given 1->2->3->3->4->4->5, return 1->2->5.
Given 1->1->1->2->3, return 2->3.


		*/
		public static void Test()
		{
			Solution sol = new Solution();

			/*
			var input = new int[] { 2, 7, 11, 15 };
			Console.WriteLine($"Input array: {string.Join(", ", input)}");
			*/
			var input = Utils.GenerateList(new int[] { 1, 2, 3, 3, 4, 4, 5 });
			Console.WriteLine($"For input list '{Utils.PrintList(input)}' -> output is '{Utils.PrintList(sol.DeleteDuplicates(input))}'");

			input = Utils.GenerateList(new int[] { 1, 1,1,1,1});
			Console.WriteLine($"For input list '{Utils.PrintList(input)}' -> output is '{Utils.PrintList(sol.DeleteDuplicates(input))}'");

			input = Utils.GenerateList(new int[] { 1, 2, 2, 3, 4, 4, 5, 5 });
			Console.WriteLine($"For input list '{Utils.PrintList(input)}' -> output is '{Utils.PrintList(sol.DeleteDuplicates(input))}'");

			/*
Submission Result: Runtime Error
Runtime Error Message: Line 16: System.NullReferenceException: Object reference not set to an instance of an object
Last executed input: []
			*/
			input = Utils.GenerateList(new int[] { });
			Console.WriteLine($"For input list '{Utils.PrintList(input)}' -> output is '{Utils.PrintList(sol.DeleteDuplicates(input))}'");

			/*
Submission Result: Wrong Answer
Input:[2,1]
Output:[2]
Expected:[2,1]
			*/
			input = Utils.GenerateList(new int[] { 2, 1});
			Console.WriteLine($"For input list '{Utils.PrintList(input)}' -> output is '{Utils.PrintList(sol.DeleteDuplicates(input))}'");

			/*
Submission Result: Time Limit Exceeded
Last executed input:[1,1,2]
			*/
			input = Utils.GenerateList(new int[] { 1,1,2});
			Console.WriteLine($"For input list '{Utils.PrintList(input)}' -> output is '{Utils.PrintList(sol.DeleteDuplicates(input))}'");

		}

		public class Solution
		{
			public ListNode DeleteDuplicates(ListNode head)
			{
				if (head == null) return null;
				var first = head;
				var prev = head;	// last unique value
				var cur = head;		// work node
				int? skipValue = null;
				while (cur != null)
				{
					if ((cur.next != null) && (cur.val == cur.next.val))
						skipValue = cur.val;
					else if((cur.next != null) && (cur.val != cur.next.val))
					{
						if (cur.val == skipValue)
						{
							if (first.val == skipValue)
							{
								first = cur.next;
								prev = cur.next;
							}
							else
								prev.next = cur.next;
						}
						else
							prev = cur;
					}
					cur = cur.next;
				}//while
				if (first.val == skipValue)		// list of same values
					return null;
				if ((prev.next != null) && (prev.next.val == skipValue))	// process duplicates at last position.
					prev.next = null;
				return first;
			}
		}
	}//public abstract class Problem_
}