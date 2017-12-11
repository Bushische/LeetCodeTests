using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Specialized;

namespace LeetCodeTests
{
	public abstract class Problem_0046
	{
		/*
Given a collection of distinct numbers, return all possible permutations.

For example,
[1, 2, 3] have the following permutations:
[
  [1,2,3],
  [1,3,2],
  [2,1,3],
  [2,3,1],
  [3,1,2],
  [3,2,1]
]
		*/
		public static void Test()
		{
			Solution sol = new Solution();

			/*
			var input = new int[] { 2, 7, 11, 15 };
			Console.WriteLine($"Input array: {string.Join(", ", input)}");
			*/
			var input = new int[] { 1, 2, 3 };
			Console.WriteLine($"for input '{Utils.PrintArray(input)}' -> '{Utils.PrintArray(sol.Permute(input))}'");

			input = new int[] { 1, 2, 3, 4 };
			Console.WriteLine($"for input '{Utils.PrintArray(input)}' -> '{Utils.PrintArray(sol.Permute(input))}'");
		}

		public class Solution
		{
			public IList<IList<int>> Permute(int[] nums)
			{
				List<IList<int>> resList = new List<IList<int>>();
				if ((nums == null) || (nums.Length == 0))
					return resList;

				ProcessList(nums, resList, new List<int>());
				return resList;
			}

			private void ProcessList(int[] nums, IList<IList<int>> resList, List<int> curPermute)
			{
				//if (curPermute == null) curPermute = new List<int>();
				if (curPermute.Count == nums.Length)
				{
					List<int> rl = new List<int>();
					foreach (int ind in curPermute)
						rl.Add(nums[ind]);
					resList.Add(rl);
					return;
				}
				for (int ind = 0; ind < nums.Length; ind++)
				{
					if (curPermute.Contains(ind))
						continue;
					curPermute.Add(ind);
					ProcessList(nums, resList, curPermute);
					curPermute.Remove(ind);
				}
			}
		}//Solution
	}//public abstract class Problem_
}