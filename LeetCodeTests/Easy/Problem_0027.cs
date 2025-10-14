using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Specialized;

namespace LeetCodeTests
{
	public abstract class Problem_0027
	{
		/*
Given an array and a value, remove all instances of that value in-place and return the new length.
Do not allocate extra space for another array, you must do this by modifying the input array in-place with O(1) extra memory.
The order of elements can be changed. It doesn't matter what you leave beyond the new length.

Example:
Given nums = [3,2,2,3], val = 3,
Your function should return length = 2, with the first two elements of nums being 2.
		*/
		public static void Test()
		{
			Solution sol = new Solution();

			/*
			var input = new int[] { 2, 7, 11, 15 };
			Console.WriteLine($"Input array: {string.Join(", ", input)}");
			*/
			var nums = new int[] { 3, 2, 2, 3 };
			var val = 3;
			Console.WriteLine($"For array '{Utils.PrintArray(nums)}' and val '{val}': new array length is {sol.RemoveElement(nums, val)}");

			nums = new int[] { 1, 2, 7, 4, 5, 6, 7, 7, 7, 7, 7 };
			val = 7;
			Console.WriteLine($"For array '{Utils.PrintArray(nums)}' and val '{val}': new array length is {sol.RemoveElement(nums, val)} (wait 5)");

			/*
Submission Result: Wrong Answer
Input:[1]  1
Output:[1]
Expected:[]
			*/
			nums = new int[] { 1};
			val = 1;
			Console.WriteLine($"For array '{Utils.PrintArray(nums)}' and val '{val}': new array length is {sol.RemoveElement(nums, val)} (wait 0)");

			nums = new int[] { 1, 1, 1, 1, 1, 1, 1};
			val = 1;
			Console.WriteLine($"For array '{Utils.PrintArray(nums)}' and val '{val}': new array length is {sol.RemoveElement(nums, val)} (wait 0)");

			/*
Submission Result: Wrong Answer
Input:[4,5]  5
Output:[4,5]
Expected:[4]
			*/
			nums = new int[] { 4, 5};
			val = 5;
			Console.WriteLine($"For array '{Utils.PrintArray(nums)}' and val '{val}': new array length is {sol.RemoveElement(nums, val)} (wait 0)");

			nums = new int[] { 1, 2, 3, 4, 5, 6 };
			val = 7;
			Console.WriteLine($"For array '{Utils.PrintArray(nums)}' and val '{val}': new array length is {sol.RemoveElement(nums, val)} (wait 6)");

		}

		public class Solution
		{
			public int RemoveElement(int[] nums, int val)
			{
				if ((nums == null) || (nums.Length == 0))
					return 0;
				int left = 0;
				int right = nums.Length - 1;
				while (left <= right)
				{
					if (nums[left] == val)
					{
						while ((right > left) && (nums[right] == val))
							right--;
						nums[left] = nums[right];
						right--;
					}
					left++;
				}
				if (nums[0] == val)
					return 0;
				return right+1;
			}
		}
	}//public abstract class Problem_
}