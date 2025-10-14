using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Specialized;

namespace LeetCodeTests
{
	public abstract class Problem_0018
	{
		/*
Given an array S of n integers, are there elements a, b, c, and d in S such that a + b + c + d = target? Find all unique quadruplets in the array which gives the sum of target.

Note: The solution set must not contain duplicate quadruplets.

For example, given array S = [1, 0, -1, 0, -2, 2], and target = 0.

A solution set is:
[
  [-1,  0, 0, 1],
  [-2, -1, 1, 2],
  [-2,  0, 0, 2]
]
		*/
		public static void Test()
		{
			Solution sol = new Solution();

			/*
			var input = new int[] { 2, 7, 11, 15 };
			Console.WriteLine($"Input array: {string.Join(", ", input)}");
			*/
			var input = new int[] { 1, 0, -1, 0, -2, 2 };
			var target = 0;
			Console.WriteLine($"in array '{Utils.PrintArray(input)}' with target '{target}' -> '{Utils.PrintArray(sol.FourSum(input, target))}'");
		}

		public class Solution
		{
			public IList<IList<int>> FourSum(int[] nums, int target)
			{
				IList < IList < int >> resList = new List<IList<int>>();
				Array.Sort(nums);
				// like 3 sum
				int first = 0;
				while (first < nums.Length - 3) 
				{
					int second = first + 1;
					while (second < nums.Length -2)
					{
						int left = second + 1;
						int right = nums.Length - 1;
						int sumfs = nums[first] + nums[second];
						while (left < right)
						{
							if (sumfs + nums[left] + nums[right] == target)	// emit result
							{
								resList.Add(new List<int>() { nums[first], nums[second], nums[left], nums[right] });
								while ((left < right) && (nums[left] == nums[left + 1])) left++;	// skip same numbers from left
								while ((left < right) && (nums[right] == nums[right - 1])) right--;	// skip same numbers from right
								left++;
								right--;
							}
							else if (sumfs + nums[left] + nums[right] > target)
								right--;
							else
								left++;
						}
						while ((second < nums.Length - 2) && (nums[second] == nums[second + 1])) second++;
						second++;
					}//second
					while ((first < nums.Length - 3) && (nums[first] == nums[first + 1])) first++;  // skip same numbers
					first++;
				}//first
				return resList;
			}
		}
	}//public abstract class Problem_
}