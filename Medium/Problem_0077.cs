using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Specialized;

namespace LeetCodeTests
{
	public abstract class Problem_0077
	{
		/*
Given two integers n and k, return all possible combinations of k numbers out of 1 ... n.

For example,
If n = 4 and k = 2, a solution is:

[
  [2,4],
  [3,4],
  [2,3],
  [1,2],
  [1,3],
  [1,4],
]
		*/
		public static void Test()
		{
			Solution sol = new Solution();

			/*
			var input = new int[] { 2, 7, 11, 15 };
			Console.WriteLine($"Input array: {string.Join(", ", input)}");
			*/
			int n = 4;
			int k = 2;
			Console.WriteLine($"All combinations for n={n} and k={k}: {Utils.PrintArray(sol.Combine(n, k))}");
		}

		public class Solution
		{
			public IList<IList<int>> Combine(int n, int k)
			{
				List<IList<int>> resList = new List<IList<int>>();
				FillListWithCombinations(resList, new List<int>(), n, k, 1);
				return resList;
			}

			private void FillListWithCombinations(IList<IList<int>> resList, List<int> accum, int n, int k, int startFrom)
			{
				if (k == 0)
				{
					resList.Add(new List<int>(accum));
				}
				else
				{
					for (int i = startFrom; i <= n - k + 1; i++)
					{
						accum.Add(i);
						FillListWithCombinations(resList, accum, n, k - 1, i + 1);
						accum.Remove(i);
					}
				}
			}
		}
	}//public abstract class Problem_
}