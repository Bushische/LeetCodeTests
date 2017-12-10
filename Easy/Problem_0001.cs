using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Specialized;

namespace LeetCodeTests
{
	public abstract class Problem_0001
	{
		/*
Given an array of integers, return indices of the two numbers such that they add up to a specific target.

You may assume that each input would have exactly one solution, and you may not use the same element twice.

Example:
Given nums = [2, 7, 11, 15], target = 9,

Because nums[0] + nums[1] = 2 + 7 = 9,
return [0, 1].
		*/
		public static void Test()
		{
			Solution sol = new Solution();
			var input = new int[] { 2, 7, 11, 15 };
			Console.WriteLine($"Input array: {string.Join(", ", input)}");

			var res = sol.TwoSum(input, 9);
			Console.WriteLine($"Problem 1: for 9 returns {string.Join(", ", res)}");

			res = sol.TwoSum(input, 13);
			Console.WriteLine($"Problem 1: for 13 returns {string.Join(", ", res)}");

			res = sol.TwoSum(input, 10);
			Console.WriteLine($"Problem 1: for 10 returns {string.Join(", ", res)}");

			//[0,4,3,0]
			//0

			res = sol.TwoSum(new int[] { 0, 4, 3, 0 }, 0);
			Console.WriteLine($"Problem 1: [0,4,3,0] for 0 returns {string.Join(", ", res)}");

			//[-8, -3, -5, -1]
			// -4
		}

		public class Solution
		{
			public int[] TwoSum1(int[] nums, int target)
			{
				int left, right;
				left = 0;
				while (left < nums.Length)
				{
					//if (nums[left] <= target)
					{
						right = left + 1;
						while (right < nums.Length)
						{
							if (nums[left] + nums[right] == target)
								return new int[] { left, right };
							right++;
						}
					}
					left++;
				}
				return new int[0];
			}

			public int[] TwoSum(int[] nums, int target)
			{
				var map = new Dictionary<int, int>();
				for (int i = 0; i < nums.Length; i++)
				{
					int complement = target - nums[i];
					if (map.ContainsKey(complement))
					{
						return new int[] { map[complement], i };
					}
					map.Add(nums[i], i);
				}
				//throw new Exception("No two sum solution");
				return new int[0];
			}

		}

	}
}

/* Correct quick solution

public int[] twoSum(int[] nums, int target)
{
	Map<Integer, Integer> map = new HashMap<>();
	for (int i = 0; i < nums.length; i++)
	{
		int complement = target - nums[i];
		if (map.containsKey(complement))
		{
			return new int[] { map.get(complement), i };
		}
		map.put(nums[i], i);
	}
	throw new IllegalArgumentException("No two sum solution");
}
*/
