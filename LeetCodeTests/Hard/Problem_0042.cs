using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Specialized;

namespace LeetCodeTests
{
	public abstract class Problem_0042
	{
		/*
Given n non-negative integers representing an elevation map where the width of each bar is 1, compute how much water it is able to trap after raining.

For example,
Given[0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1], return 6.

https://leetcode.com/problems/trapping-rain-water/description/
The above elevation map is represented by array[0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1]. In this case, 6 units of rain water (blue section) are being trapped. Thanks Marcos for contributing this image!
		*/
		public static void Test()
		{
			Solution sol = new Solution();

			/*
			var input = new int[] { 2, 7, 11, 15 };
			Console.WriteLine($"Input array: {string.Join(", ", input)}");
			*/

			var input = new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 };
			Console.WriteLine($"for input: '{Utils.PrintArray(input)}' -> {sol.Trap(input)} waits 6");

			input = new int[] { 4, 2, 3,5,2,3,4,5};
			Console.WriteLine($"for input: '{Utils.PrintArray(input)}' -> {sol.Trap(input)} waits 9");

			input = new int[] { 8,7,6,5,4,3,2,1};
			Console.WriteLine($"for input: '{Utils.PrintArray(input)}' -> {sol.Trap(input)} waits 0");

			input = new int[] { 1,2,3,4,5,6,7,8};
			Console.WriteLine($"for input: '{Utils.PrintArray(input)}' -> {sol.Trap(input)} waits 0");

			/*
Submission Result: Wrong Answer
Input:	[4,2,3]
Output:	 0
Expected:1
			*/
			input = new int[] { 4,2,3};
			Console.WriteLine($"for input: '{Utils.PrintArray(input)}' -> {sol.Trap(input)} waits 1");

			input = new int[] {9,1,8,1,7,1,6};
			Console.WriteLine($"for input: '{Utils.PrintArray(input)}' -> {sol.Trap(input)} waits 18");
		}

		public class Solution
		{
			public int Trap(int[] height)
			{
				// find pools
				// from left to right - search for any biggest or same size as left
				// if there is no same or biggest need find max in right part
				if ((height == null) || (height.Length <= 1))
					return 0;
				//1 pass to find all pools
				SortedDictionary<int, int> pools = new SortedDictionary<int, int>();
				int left = 0;
				while (left < height.Length)
				{
					int maxInRight = 0;		// max element in right
					int maxInRightIndex = left;
					for (int ind = left+1; ind < height.Length; ind++)
					{
						if ((height[ind] >= height[left]) && (ind == left + 1)) // need move LEFT brace
							left = ind;
						else if (height[ind] >= height[left])                   // found RIGHT brace
						{
							pools.Add(left, ind);
							left = ind;

							maxInRight = 0;
							maxInRightIndex = left;
						}
						else if (height[ind] > maxInRight)
						{
							if (ind > left)
							{
								maxInRight = height[ind];
								maxInRightIndex = ind;
							}
						}
					}
					if (maxInRightIndex > left)
					{
						pools.Add(left, maxInRightIndex);
						left = maxInRightIndex;
					}
					else
						left++;
				}

				//2 pass: calculate for each pool in POOLS collection

				int resTrap = 0;
				foreach (int leftind in pools.Keys)
				{
					int leftBrace = Math.Min(height[leftind], height[pools[leftind]]);
					for (int ind = leftind+1; ind < pools[leftind]; ind++)
					{
						resTrap += (leftBrace - height[ind]);
					}
				}

				return resTrap;
			}
		}
	}//public abstract class Problem_
}