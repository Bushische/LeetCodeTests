using System;
using System.Collections;

namespace LeetCodeTests
{
	public static class Utils
	{
		public static string PrintArray(object obj)
		{
			string res = "";
			if (obj is IEnumerable)
			{
				res = "[";
				foreach (object ob in (obj as IEnumerable))
				{
					res += " " + PrintArray(ob) + ",";
				}
				if (res[res.Length - 1] == ',')
					res = res.Substring(0, res.Length - 1);
				res += "]";
			}
			else
				res = obj.ToString();
			return res;
		}

		public static string PrintList(ListNode head)
		{
			if (head == null)
				return "";
			else
				return head.val.ToString() + ((head.next == null) ? "" : ":" + PrintList(head.next));
		}

		public static ListNode GenerateList(int[] inArr, int index = 0)
		{
			if (index >= inArr.Length)
				return null;

			ListNode res = new ListNode(inArr[index]);
			res.next = GenerateList(inArr, index + 1);
			return res;
		}
	}//

	/*** Additional classes ***/
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
}
