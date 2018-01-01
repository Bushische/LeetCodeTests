using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Specialized;

namespace LeetCodeTests
{
	public abstract class Problem_0088
	{
		/*
88. Merge Sorted Array

Given two sorted integer arrays nums1 and nums2, merge nums2 into nums1 as one sorted array.

Note:
You may assume that nums1 has enough space(size that is greater or equal to m + n) to hold additional elements from nums2.
The number of elements initialized in nums1 and nums2 are m and n respectively.
		*/
		public static void Test()
		{
			Solution sol = new Solution();

			/*
			var input = new int[] { 2, 7, 11, 15 };
			Console.WriteLine($"Input array: {string.Join(", ", input)}");
			*/
			int m = 5;
			int n = 3;
			int[] nums1 = new int[] { 1, 3, 5, 0, 0, 0, 0, 0, 0, 0 };
			int[] nums2 = new int[] { 2, 4, 6, 8, 10 };
			Console.WriteLine($@"For input '{Utils.PrintArray(nums1)}' (m={m}) 
and      '{Utils.PrintArray(nums2)}' (n={n})");
			sol.Merge(nums1, m, nums2, n);
			Console.WriteLine($"Output: '{Utils.PrintArray(nums1)}'");

			/*
Submission Result: Wrong Answer
Input: [0] 0 [1] 1
Output:   [0]
Expected: [1]
			*/
			m = 0;
			n = 1;
			nums1 = new int[] { 0 };
			nums2 = new int[] { 1 };
			Console.WriteLine($@"For input '{Utils.PrintArray(nums1)}' (m={m}) 
and      '{Utils.PrintArray(nums2)}' (n={n})");
			sol.Merge(nums1, m, nums2, n);
			Console.WriteLine($"Output: '{Utils.PrintArray(nums1)}'");
		}

		public class Solution
		{
			public void Merge(int[] nums1, int m, int[] nums2, int n)
			{
				int insPos = m + n - 1;
				m--; n--;       // change to indexes
				Func<int[], int, int> getAtIndex = (nums, ind) =>
				{
					if (ind < 0)
						return int.MinValue;
					return nums[ind];
				};
				while (insPos >= 0)
				{
					if (getAtIndex(nums1, m) >= getAtIndex(nums2, n))
					{
						nums1[insPos] = getAtIndex(nums1, m);
						m--;
					}
					else
					{
						nums1[insPos] = getAtIndex(nums2, n);
						n--;
					}
					insPos--;
				}
			}//
		}
	}//public abstract class Problem_
}