using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Specialized;

namespace LeetCodeTests
{
	public abstract class Problem_0031
	{
		/*
Implement next permutation, which rearranges numbers into the lexicographically next greater permutation of numbers.
If such arrangement is not possible, it must rearrange it as the lowest possible order(ie, sorted in ascending order).
The replacement must be in-place, do not allocate extra memory.

Here are some examples.Inputs are in the left-hand column and its corresponding outputs are in the right-hand column.
1,2,3 → 1,3,2
3,2,1 → 1,2,3
1,1,5 → 1,5,1

		*/
		public static void Test()
		{
			Solution sol = new Solution();

			/*
			var input = new int[] { 2, 7, 11, 15 };
			Console.WriteLine($"Input array: {string.Join(", ", input)}");
			*/
			#region normal test variation
			var input = new int[] { 1, 2, 3 };
			Console.Write($"input {Utils.PrintArray(input)} -> ");
			sol.NextPermutation(input);
			Console.WriteLine($" {Utils.PrintArray(input)} \t waits: [1, 3, 2]");

			input = new int[] { 3, 2, 1 };
			Console.Write($"input {Utils.PrintArray(input)} -> ");
			sol.NextPermutation(input);
			Console.WriteLine($" {Utils.PrintArray(input)} \t waits: [1, 2, 3]");

			input = new int[] { 1, 1, 5 };
			Console.Write($"input {Utils.PrintArray(input)} -> ");
			sol.NextPermutation(input);
			Console.WriteLine($" {Utils.PrintArray(input)} \t waits: [1, 5, 1]");

			input = new int[] { 1, 2 };
			Console.Write($"input {Utils.PrintArray(input)} -> ");
			sol.NextPermutation(input);
			Console.WriteLine($" {Utils.PrintArray(input)} \t waits: [2, 1]");

			input = new int[] { 1 };
			Console.Write($"input {Utils.PrintArray(input)} -> ");
			sol.NextPermutation(input);
			Console.WriteLine($" {Utils.PrintArray(input)} \t waits: [1]");

			input = new int[0];
			Console.Write($"input {Utils.PrintArray(input)} -> ");
			sol.NextPermutation(input);
			Console.WriteLine($" {Utils.PrintArray(input)} \t waits: [ ]");
			#endregion

			/*
Submission Result: Wrong Answer
Input:    [1,3,2]
Output:   [3,1,2]
Expected: [2,1,3]
			*/
			input = new int[] { 1, 3, 2 };
			Console.Write($"input {Utils.PrintArray(input)} -> ");
			sol.NextPermutation(input);
			Console.WriteLine($" {Utils.PrintArray(input)} \t waits: [2, 1, 3]");

			input = new int[] { 1, 6, 5, 4, 3, 2 };
			Console.Write($"input {Utils.PrintArray(input)} -> ");
			sol.NextPermutation(input);
			Console.WriteLine($" {Utils.PrintArray(input)} \t waits: [2, 1, 3, 4, 5, 6]");

			/*
Submission Result: Wrong Answer
Input:	 [2,3,1]
Output:	 [1,2,3]
Expected:[3,1,2]
			*/

			input = new int[] { 2, 3, 1 };
			Console.Write($"input {Utils.PrintArray(input)} -> ");
			sol.NextPermutation(input);
			Console.WriteLine($" {Utils.PrintArray(input)} \t waits: [3, 1, 2]");

			/*
Submission Result: Wrong Answer
Input:		[5,1,1]
Output:		[5,1,1]
Expected:	[1,1,5]
			*/

			input = new int[] { 5, 1, 1 };
			Console.Write($"input {Utils.PrintArray(input)} -> ");
			sol.NextPermutation(input);
			Console.WriteLine($" {Utils.PrintArray(input)} \t waits: [1, 1, 5]");
		}

		public class Solution
		{
			public void NextPermutation(int[] nums)
			{
				// for ai = nums[i] (starts from 0) try to find min element aj = nums[j] in right part of array (j > i):
				//	ai < aj
				//  aj - min(ak), ai < ak
				// need start from right
				if (nums == null) return;

				// skip all ascending line from right
				int fleft = nums.Length - 2;
				while ((fleft >= 0) && (nums[fleft] >= nums[fleft + 1]))
					fleft--;
				if (fleft < 0)
				{
					Array.Sort(nums);
					 return; 
				}
				// set min element bigger than nums[fleft] from right to fleft postion and order right rest of array
				// look for min element in right
				int minind = fleft + 1;
				int minval = nums[minind];
				for (int ind = minind; ind < nums.Length; ind++)
				{
					if ((nums[ind] > nums[fleft]) && (nums[ind] < minval))
					{
						minval = nums[ind];
						minind = ind;
					}
				}
				// swap min element and fleft
				nums[minind] = nums[fleft];
				nums[fleft] = minval;
				//sort right part
				Array.Sort(nums, fleft + 1, nums.Length - fleft-1);
			}
		}
	}//public abstract class Problem_
}