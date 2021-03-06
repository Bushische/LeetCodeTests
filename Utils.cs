﻿using System;
using System.Collections;

namespace LeetCodeTests
{
	public static class Utils
	{
		/// <summary>
		/// Prints the array of objects
		/// </summary>
		/// <returns>The array.</returns>
		/// <param name="obj">Object.</param>
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

		/// <summary>
		/// Print 2D array. 
		/// </summary>
		/// <returns>The DA rray.</returns>
		/// <param name="obj">Object.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public static string Print2DArray<T>(T[,] obj)
		{
			string res = "[";
			int m = obj.GetLength(0);
			int n = obj.GetLength(1);
			for (int i = 0; i < m; i++)
			{
				res += "[";
				for (int j = 0; j < n; j++)
				{
					res += " " + obj[i, j].ToString() + ",";
				}
				if (res[res.Length - 1] == ',')
					res = res.Substring(0, res.Length - 1);
				res += "]";
				if (i < m - 1)
					res += ",\n ";
			}
			if (res[res.Length - 1] == ',')
					res = res.Substring(0, res.Length - 1);
			return res + "]";
		}

		/// <summary>
		/// Print List (ListNode class)
		/// </summary>
		/// <returns>The list.</returns>
		/// <param name="head">Head.</param>
		public static string PrintList(ListNode head)
		{
			if (head == null)
				return "";
			else
				return head.val.ToString() + ((head.next == null) ? "" : ":" + PrintList(head.next));
		}

		/// <summary>
		/// Create a list based on int array
		/// </summary>
		/// <returns>The list.</returns>
		/// <param name="inArr">In arr.</param>
		/// <param name="index">Index.</param>
		public static ListNode GenerateList(int[] inArr, int index = 0)
		{
			if (index >= inArr.Length)
				return null;

			ListNode res = new ListNode(inArr[index]);
			res.next = GenerateList(inArr, index + 1);
			return res;
		}

		/// <summary>
		/// Get bit view of integer. Minimal length if length is not passed and length is equal to passed value otherwise.
		/// </summary>
		/// <returns>The bit view.</returns>
		/// <param name="n">N.</param>
		/// <param name="length">Length.</param>
		public static string GetBitView(int n, int length = 0)
		{
			string res = "";
			while (((length == 0) && (n > 0))
				   || ((length > 0) && (res.Length < length)))
			{
				res = (n & 1).ToString() + res;
				n = n >> 1;
			}
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

	/// <summary>
	/// Benchmark.
	/// </summary>
	public static class Benchmark
	{
		private static DateTime _start;
		public static void Start()
		{
			_start = DateTime.Now;
		}

		public static TimeSpan Finish()
		{
			return DateTime.Now - _start;
		}
	}// Benchmark
}
