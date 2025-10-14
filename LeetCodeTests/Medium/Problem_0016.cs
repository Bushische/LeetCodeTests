using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Specialized;

namespace LeetCodeTests
{
	public abstract class Problem_0016
	{
		/*
Given an array S of n integers, find three integers in S such that the sum is closest to a given number, target.
Return the sum of the three integers.You may assume that each input would have exactly one solution.

For example, given array S = { -1 2 1 - 4 }, and target = 1.
The sum that is closest to the target is 2. (-1 + 2 + 1 = 2).
		*/
		public static void Test()
		{
			Solution sol = new Solution();

			/*
			var input = new int[] { 2, 7, 11, 15 };
			Console.WriteLine($"Input array: {string.Join(", ", input)}");
			*/
			var input = new int[] { -1, 2, 1, -4 };
			var target = 1;
			Console.WriteLine($"Input: {Utils.PrintArray(input)}, target: {target} -> nearest {sol.ThreeSumClosest(input, target)} (wait 2)");

			input = new int[] { -1, 2, 1, -4 };
			target = 0;
			Console.WriteLine($"Input: {Utils.PrintArray(input)}, target: {target} -> nearest {sol.ThreeSumClosest(input, target)} (wait -1)");

			input = new int[] { -1, 2, 1, -4 };
			target = -2;
			Console.WriteLine($"Input: {Utils.PrintArray(input)}, target: {target} -> nearest {sol.ThreeSumClosest(input, target)} (wait -3)");
		}

		public class Solution
		{
			public int ThreeSumClosest(int[] nums, int target)
			{
				// try modified algorithm of 3sum
				// fix first element, and use bidirectional search to find min Abs(Target-First-Second-Third)
				Array.Sort(nums);
				int resMin = int.MaxValue;		// for real sum
				int resDif = int.MaxValue;      // for abs sum
				string resOut = "";
				for (int first = 0; first < nums.Length - 2; first++)
				{
					int sum = target - nums[first];
					int left = first + 1;
					int right = nums.Length - 1;
					while (left < right)
					{
						if (Math.Abs(sum - nums[left] - nums[right]) < resDif)
						{
							resDif = Math.Abs(sum - nums[left] - nums[right]);
							resMin = nums[first] + nums[left] + nums[right];
							resOut = $"{nums[first]} + {nums[left]} + {nums[right]}";
						}
						if (sum > (nums[left] + nums[right]))
							left++;
						else
							right--;
					}
				}
				Console.WriteLine($"Found solution: {resOut}");
				return resMin;
			}
		}
	}//public abstract class Problem_
}