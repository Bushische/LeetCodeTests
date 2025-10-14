using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Specialized;

namespace LeetCodeTests
{
	public abstract class Problem_0039
	{
		/*
Given a set of candidate numbers(C) (without duplicates) and a target number(T), find all unique combinations in C where the candidate numbers sums to T.

The same repeated number may be chosen from C unlimited number of times.


Note:
All numbers (including target) will be positive integers.
The solution set must not contain duplicate combinations.
For example, given candidate set[2, 3, 6, 7] and target 7,
A solution set is: 
[
  [7],
  [2, 2, 3]
]
		*/
		public static void Test()
		{
			Solution sol = new Solution();

			/*
			var input = new int[] { 2, 7, 11, 15 };
			Console.WriteLine($"Input array: {string.Join(", ", input)}");
			*/
			var input = new int[] { 2, 3, 6, 7 };
			int target = 7;
			Console.WriteLine($"For input '{Utils.PrintArray(input)}' and target '{target}': {Utils.PrintArray(sol.CombinationSum(input, target))}");
		}

		public class Solution
		{
			public IList<IList<int>> CombinationSum(int[] candidates, int target)
			{
				List<IList<int>> resList = new List<IList<int>>();

				Array.Sort(candidates);
				FillPermutations(candidates, resList, new List<int>(), target, 0, startIndex: 0);

				return resList;
			}
			/// <summary>
			/// Fill permutations list.
			/// </summary>
			/// <param name="candidates">Candidates numbers.</param>
			/// <param name="resList">Result list.</param>
			/// <param name="curList">Current list.</param>
			/// <param name="Target">Target.</param>
			/// <param name="curListSum">Sum of Current list.</param>
			/// <param name="startIndex">Start index in candidates.</param>
			private void FillPermutations(int[] candidates, IList<IList<int>> resList, List<int> curList, int Target, int curListSum, int startIndex)
			{
				if (curList.Count > 20) return;	// just to avoid 0 numbers infinite row
				if (curListSum == Target)
				{
					resList.Add(curList);
					return;	// stop search, no more possibilities
				}

				for (int nextInd = startIndex; nextInd < candidates.Length; nextInd++)
				{
					if (curListSum + candidates[nextInd] > Target)		// array is ordered, so no need to check next
						return;
					var tmpList = new List<int>(curList);
					tmpList.Add(candidates[nextInd]);
					FillPermutations(candidates, resList, tmpList, Target, curListSum + candidates[nextInd], startIndex: nextInd);
				}//for
			}
		}
	}//public abstract class Problem_
}