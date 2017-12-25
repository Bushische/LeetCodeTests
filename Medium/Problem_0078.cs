using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Specialized;

namespace LeetCodeTests
{
	public abstract class Problem_0078
	{
		/*
Given a set of distinct integers, nums, return all possible subsets(the power set).

Note: The solution set must not contain duplicate subsets.

For example,
If nums = [1, 2, 3], a solution is:

[
  [3],
  [1],
  [2],
  [1,2,3],
  [1,3],
  [2,3],
  [1,2],
  []
]

		*/
		public static void Test()
		{
			Solution sol = new Solution();

			/*
			var input = new int[] { 2, 7, 11, 15 };
			Console.WriteLine($"Input array: {string.Join(", ", input)}");
			*/
			var nums = new int[] { 1, 2, 3 };
			Console.WriteLine($"for input '{Utils.PrintArray(nums)}' -> '{Utils.PrintArray(sol.Subsets(nums))}'");
		}

		public class Solution
		{
			public IList<IList<int>> Subsets(int[] nums)
			{
				List<IList<int>> resList = new List<IList<int>>();
				backtrack(resList, new List<int>(), nums, 0);
				return resList;
			}

			public void backtrack(List<IList<int>> resList, List<int> accum, int[] nums, int startPos)
			{
				resList.Add(new List<int>(accum));
				for (int i = startPos; i < nums.Length; i++)
				{
					accum.Add(nums[i]);
					backtrack(resList, accum, nums, i + 1);
					accum.RemoveAt(accum.Count - 1);
				}
			}
		}
	}//public abstract class Problem_
}