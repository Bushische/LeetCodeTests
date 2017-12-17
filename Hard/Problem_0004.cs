using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Specialized;
using System.Linq;

namespace LeetCodeTests
{
	public abstract class Problem_0004
	{
		/*
There are two sorted arrays nums1 and nums2 of size m and n respectively.

Find the median of the two sorted arrays.The overall run time complexity should be O(log (m+n)).

Example 1:
nums1 = [1, 3]
nums2 = [2]

The median is 2.0
Example 2:
nums1 = [1, 2]
nums2 = [3, 4]

The median is (2 + 3)/2 = 2.5

Median - element wich devide array in two parts (less and greater MEDIAN) same size

[1, 12, 15, 26, 38] and [2, 13, 17, 30, 45] -> median = 16

----
Runtime error
Last executed input:
[]
[1]

Input:
[1]
[2,3]
Output: 1.50000
Expected: 2.00000
		*/

		/*
		Idea:
		1. Find median of each arrays (m1 and m2)
		2. if m1 < m2: repeat for right part A1 and left part A2
		3. if m1 > m2: repeat for left part A1 and right part A2
		4. if size of array is 1 - median = A[0]
		5. if size of array is 2 - median = (A[0]+A[1]) / 2
		*/
		public static void Test()		// NOT SOLVED!!!
		{
			Solution sol = new Solution();

			Func<int[], string> PrintArray = (x => x == null? "" : ("{" + string.Join(", ", x.Select(y => y.ToString()).ToArray()) + "}"));
			/*
			var input = new int[] { 2, 7, 11, 15 };
			Console.WriteLine($"Input array: {string.Join(", ", input)}");
			*/
			int[] arr = new int[] { 1, 2, 3, 4 };
			Console.WriteLine($"median of '{PrintArray(arr)}' is '{sol.CalcMedian(arr)}'");

			arr = new int[] { 1, 2, 3, 4, 5, 6, 7 };
			Console.WriteLine($"median of '{PrintArray(arr)}' is '{sol.CalcMedian(arr)}'");

			arr = new int[] { 1, 2, 3, 4, 5, 6, 7 };
			Console.WriteLine($"median of '{PrintArray(arr)}' is '{sol.CalcMedian(arr, 3)}'");

			Console.WriteLine("-----");
			int[] arr1 = new int[] { 1, 3 };
			int[] arr2 = new int[] { 2 };
			Console.WriteLine($"median of arrays '{PrintArray(arr1)}' and '{PrintArray(arr2)}' is '{sol.FindMedianSortedArrays(arr1, arr2)}' (wait 2)");
		
			arr1 = new int[] { 1, 2 };
			arr2 = new int[] { 3, 4 };
			Console.WriteLine($"median of arrays '{PrintArray(arr1)}' and '{PrintArray(arr2)}' is '{sol.FindMedianSortedArrays(arr1, arr2)}' (wait 2.5)");

			arr1 = new int[] { 1};
			arr2 = new int[] { 2, 3};
			Console.WriteLine($"median of arrays '{PrintArray(arr1)}' and '{PrintArray(arr2)}' is '{sol.FindMedianSortedArrays(arr1, arr2)}' (wait 2)");

			arr1 = new int[] { 1, 12, 15, 26, 38 };
			arr2 = new int[] { 2, 13, 17, 30, 45};
			Console.WriteLine($"median of arrays '{PrintArray(arr1)}' and '{PrintArray(arr2)}' is '{sol.FindMedianSortedArrays(arr1, arr2)}' (wait 16)");

			arr1 = new int[] { };
			arr2 = new int[] { 2, 13, 17, 30, 45};
			Console.WriteLine($"median of arrays '{PrintArray(arr1)}' and '{PrintArray(arr2)}' is '{sol.FindMedianSortedArrays(arr1, arr2)}' (wait 17)");

			arr1 = null;
			arr2 = new int[] { 2, 13, 17, 30, 45};
	//		Console.WriteLine($"median of arrays '{PrintArray(arr1)}' and '{PrintArray(arr2)}' is '{sol.FindMedianSortedArrays(arr1, arr2)}' (wait 17)");
		}


		public class Solution
		{
			public double FindMedianSortedArrays(int[] nums1, int[] nums2)
			{
				if ((nums1 == null) || (nums1.Length == 0)) 
					return CalcMedian(nums2);
				if ((nums2 == null) || (nums2.Length == 0))
					return CalcMedian(nums1);
				return prvCalcMedianForTwo(nums1, nums2, 0, nums1.Length - 1, 0, nums2.Length - 1);
			}

			private double prvCalcMedianForTwo(int[] nums1, int[] nums2, int left1, int right1, int left2, int right2)
			{
				double m1 = CalcMedian(nums1, left1, right1);
				double m2 = CalcMedian(nums2, left2, right2);
				if (Math.Abs(m1 - m2) < 0.0001)
					return m1;
				if ((left1 == right1) && (left2 == right2))
					return (m1 + m2) / 2;
				if (m1 < m2)    // right from left and left from right
				{
					int center1 = (int)(left1 + ((double)(right1 - left1)) / 2 + 0.5);  // 1 2 3 4 5 -> index of 3 | 1 2 3 4 5 6 -> 4
					int center2 = (int)(left2 + ((double)(right2 - left2)) / 2);       	// 1 2 3 4 5 -> index of 3 | 1 2 3 4 5 6 -> 3 
					return prvCalcMedianForTwo(nums1, nums2, center1, right1, left2, center2);
				}
				else
				{
					int center1 = (int)(left1 + ((double)(right1 - left1)) / 2);  		// 1 2 3 4 5 -> index of 3 | 1 2 3 4 5 6 -> 3
					int center2 = (int)(left2 + ((double)(right2 - left2)) / 2 + 0.5);       	// 1 2 3 4 5 -> index of 3 | 1 2 3 4 5 6 -> 3 
					return prvCalcMedianForTwo(nums1, nums2, left1, center1, center2, right2);
				}
			}

			internal double CalcMedian(int[] nums, int left = 0, int right = -1)
			{
				if (nums == null) return 0;
				if (nums.Length == 0) return 0;
				if (left == right) 
					return nums[left];
				if ((right > nums.Length) || (right == 0) || (right < left))
					right = nums.Length - 1;
				if ((right - left + 1) % 2 == 1)  //odd length => return element in middle
				{
					int middle = left + (right - left) / 2;
					return (double)nums[middle];
				}
				else
				{
					int lmiddle = left + (right - left) / 2;
					int rmiddle = lmiddle + 1;
					return ((double)(nums[lmiddle] + nums[rmiddle])) / 2.0;
				}
			}


		}
	}//
}