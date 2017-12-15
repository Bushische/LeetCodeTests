using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Specialized;

namespace LeetCodeTests
{
	public abstract class Problem_0056
	{
		/*
Given a collection of intervals, merge all overlapping intervals.

For example,
Given[1, 3], [2,6], [8,10], [15,18],
return [1,6], [8,10], [15,18].
		*/
		public static void Test()
		{
			Solution sol = new Solution();

			/*
			var input = new int[] { 2, 7, 11, 15 };
			Console.WriteLine($"Input array: {string.Join(", ", input)}");
			*/
			var input = new List<Interval>() { new Interval(2, 6), new Interval(1, 3), new Interval(8, 10), new Interval(15, 18) };
			Console.WriteLine($"For input '{Utils.PrintArray(input)}' -> '{Utils.PrintArray( sol.Merge(input))}'");
			Console.WriteLine("waits for '[1,6], [8,10], [15,18]'");

			input = new List<Interval>() {  new Interval(1, 3), new Interval(8, 10), new Interval(15, 18) };
			Console.WriteLine($"For input '{Utils.PrintArray(input)}' -> '{Utils.PrintArray( sol.Merge(input))}'");
			Console.WriteLine("waits for '[1,3], [8,10], [15,18]'");

			input = new List<Interval>() {  new Interval(1, 2), new Interval(2, 10), new Interval(10, 18) };
			Console.WriteLine($"For input '{Utils.PrintArray(input)}' -> '{Utils.PrintArray( sol.Merge(input))}'");
			Console.WriteLine("waits for '[1,18]'");

			input = new List<Interval>() {  new Interval(1, 2)};
			Console.WriteLine($"For input '{Utils.PrintArray(input)}' -> '{Utils.PrintArray( sol.Merge(input))}'");
			Console.WriteLine("waits for '[1,2]'");

			input = new List<Interval>() { };
			Console.WriteLine($"For input '{Utils.PrintArray(input)}' -> '{Utils.PrintArray( sol.Merge(input))}'");
			Console.WriteLine("waits for ''");

			/*
Submission Result: Time Limit Exceeded
Last executed input: [[3,3],[2,6],[4,6]]
			*/

			input = new List<Interval>() {  new Interval(3, 3), new Interval(2, 6), new Interval(4, 6)};
			Console.WriteLine($"For input '{Utils.PrintArray(input)}' -> '{Utils.PrintArray( sol.Merge(input))}'");
			Console.WriteLine("waits for '[2,6]'");
		}

		/// <summary>
		/// Interval.
		/// </summary>
		public class Interval
		{
			public int start;
			public int end;
			public Interval() { start = 0; end = 0; }
			public Interval(int s, int e) { start = s; end = e; }
			public override string ToString()
			{
				return $"({start}, {end})";
			}
		}

		public class Solution
		{
			private int IntervalComparer(Interval A, Interval B)
			{
				return A.start.CompareTo(B.start);
			}
			public IList<Interval> Merge(IList<Interval> intervals)
			{
				if (intervals.Count <= 1)
					return intervals;

				List<Interval> list = new List<Interval>(intervals);
				list.Sort(IntervalComparer);
				var orderedIntervals = list;

				List<Interval> resList = new List<Interval>();
				int left = list[0].start;
				int right = list[0].end;

				foreach (Interval tmp in orderedIntervals)
				{
					if (tmp.start <= right)
					{
						right = Math.Max(right, tmp.end);
					}
					else
					{
						resList.Add(new Interval(left, right));
						left = tmp.start;
						right = tmp.end;
					}
				}
				resList.Add(new Interval(left, right));
				return resList;
				//return System.Linq.Enumerable.ToList( res);
			}
		}
	}//public abstract class Problem_
}