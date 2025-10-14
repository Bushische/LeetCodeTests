using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Specialized;

namespace LeetCodeTests
{
	public abstract class Problem_0033
	{
		/*
Suppose an array sorted in ascending order is rotated at some pivot unknown to you beforehand.
(i.e., 0 1 2 4 5 6 7 might become 4 5 6 7 0 1 2).

You are given a target value to search.If found in the array return its index, otherwise return -1.
You may assume no duplicate exists in the array.
		*/
		public static void Test()
		{
			Solution sol = new Solution();

			/*
			var input = new int[] { 2, 7, 11, 15 };
			Console.WriteLine($"Input array: {string.Join(", ", input)}");
			*/
			var nums = new int[] { 4, 5, 6, 7, 0, 1, 2 };
			var target = 8;
			Console.WriteLine($"Find '{target}' in array '{Utils.PrintArray(nums)}' -> '{sol.Search(nums, target)}' waits (-1)");

			nums = new int[] { 6, 7, 0, 1, 2, 4, 5 };
			target = 7;
			Console.WriteLine($"Find '{target}' in array '{Utils.PrintArray(nums)}' -> '{sol.Search(nums, target)}' waits (1)");

			nums = new int[] { 4, 5, 6, 7, 0, 1, 2 };
			target = 1;
			Console.WriteLine($"Find '{target}' in array '{Utils.PrintArray(nums)}' -> '{sol.Search(nums, target)}' waits (5)");

			target = 2;
			Console.WriteLine($"Find '{target}' in array '{Utils.PrintArray(nums)}' -> '{sol.Search(nums, target)}' waits (6)");

			target = 7;
			Console.WriteLine($"Find '{target}' in array '{Utils.PrintArray(nums)}' -> '{sol.Search(nums, target)}' waits (3)");

			target = 4;
			Console.WriteLine($"Find '{target}' in array '{Utils.PrintArray(nums)}' -> '{sol.Search(nums, target)}' waits (0)");


			nums = new int[] { 0,1, 2,4, 5, 6, 7 };
			target = 0;
			Console.WriteLine($"Find '{target}' in array '{Utils.PrintArray(nums)}' -> '{sol.Search(nums, target)}' waits (0)");

			target = 2;
			Console.WriteLine($"Find '{target}' in array '{Utils.PrintArray(nums)}' -> '{sol.Search(nums, target)}' waits (2)");

			target = 6;
			Console.WriteLine($"Find '{target}' in array '{Utils.PrintArray(nums)}' -> '{sol.Search(nums, target)}' waits (5)");


			nums = new int[] { 7, 0,1, 2,4, 5, 6};
			target = 0;
			Console.WriteLine($"Find '{target}' in array '{Utils.PrintArray(nums)}' -> '{sol.Search(nums, target)}' waits (1)");

			target = 7;
			Console.WriteLine($"Find '{target}' in array '{Utils.PrintArray(nums)}' -> '{sol.Search(nums, target)}' waits (0)");

			target = 6;
			Console.WriteLine($"Find '{target}' in array '{Utils.PrintArray(nums)}' -> '{sol.Search(nums, target)}' waits (6)");

			nums = new int[] { 1, 2, 4, 5, 6, 7, 0 };
			target = 0;
			Console.WriteLine($"Find '{target}' in array '{Utils.PrintArray(nums)}' -> '{sol.Search(nums, target)}' waits (6)");

			target = 7;
			Console.WriteLine($"Find '{target}' in array '{Utils.PrintArray(nums)}' -> '{sol.Search(nums, target)}' waits (5)");

			target = 2;
			Console.WriteLine($"Find '{target}' in array '{Utils.PrintArray(nums)}' -> '{sol.Search(nums, target)}' waits (1)");

			/*
Submission Result: Wrong Answer 
Input:[1] 1
Output:-1
Expected:0
			*/
			nums = new int[] { 1};
			target = 1;
			Console.WriteLine($"Find '{target}' in array '{Utils.PrintArray(nums)}' -> '{sol.Search(nums, target)}' waits (0)");

		}

		public class Solution
		{
			public int Search(int[] nums, int target)
			{
				//dihotomia
				if ((nums == null) || (nums.Length == 0))
					return -1;
				int left = 0;
				int right = nums.Length - 1;
				int mid;
				while (left <= right)
				{
					if (nums[left] == target) return left;
					if (nums[right] == target) return right;
					mid = left + (right - left) / 2;
					if (nums[mid] == target) return mid;
					if (mid == left)
						return -1;      // stop searching
										// A B C   , a= nums[left] , b = nums[mid] , c = nums[mid];
										// A<B<C	array is ordered - look in suitable part
										// A<B>C	left part is ordered OK, right - mixed
										// A>B>C	impossible
										// A>B<C	left part is mixed, right - ordered OK

					// left part is ordered
					if (nums[left] < nums[mid])
					{
						if ((nums[left] < target) && (target < nums[mid]))
							right = mid;
						else
							left = mid;
					}
					// right part is ordered
					else if (nums[left] > nums[mid])
					{
						if ((nums[mid] < target) && (target < nums[right]))
							left = mid;
						else
							right = mid;
					}

					#region try 1
					/*
					if ((nums[left] < nums[mid]) && (nums[left] < target) && (nums[mid] > target))
						right = mid;		// search in left part
					else if ((nums[left] < nums[mid]) && (nums[mid] < target))
						left = mid;
					else if ((nums[left] > nums[mid]) && (nums[mid] < target) && (nums[right] > target))
						left = mid;
					else //if ((nums[left] > nums[mid]) && (nums[right] < target))
						right = mid;
					*/
					#endregion
				}// while
				return -1;
			}
		}
	}//public abstract class Problem_
}