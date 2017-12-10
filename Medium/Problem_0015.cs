using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Specialized;

namespace LeetCodeTests
{
	public abstract class Problem_0015
	{
		/*
Given an array S of n integers, are there elements a, b, c in S such that a + b + c = 0? Find all unique triplets in the array which gives the sum of zero.

Note: The solution set must not contain duplicate triplets.

For example, given array S = [-1, 0, 1, 2, -1, -4],

A solution set is:
[
  [-1, 0, 1],
  [-1, -1, 2]
]
		*/
		public static void Test()
		{
			Solution sol = new Solution();

			
			/*
			var input = new int[] { 2, 7, 11, 15 };
			Console.WriteLine($"Input array: {string.Join(", ", input)}");
			*/
			var input = new int[] { -1, 0, 1, 2, -1, -4 };
			Console.WriteLine($"Check for array '{PrintArray(input)}' -> '{PrintArray(sol.ThreeSum(input))}'");

			input = new int[] { -1,-1,-1,-1,0,0,0,0,0,0};
			Console.WriteLine($"Check for array '{PrintArray(input)}' -> '{PrintArray(sol.ThreeSum(input))}'");

			input = new int[] { -1,-1};
			Console.WriteLine($"Check for array '{PrintArray(input)}' -> '{PrintArray(sol.ThreeSum(input))}'");

//Submission Result: Time Limit Exceeded 
//Last executed input:
//[82597,-9243,62390,83030,-97960,-26521,-61011,83390,-38677,12333,75987,46091,83794,19355,...]
		}
		private static string PrintArray(object obj)
		{
			string res = "";
			if (obj is IEnumerable)
			{
				res = "[";
				foreach (object ob in (obj as IEnumerable))
				{
					res += " "+PrintArray(ob) + ",";
				}
				if (res[res.Length - 1] == ',')
					res = res.Substring(0, res.Length - 1) ;
				res += "]";
			}
			else
				res = obj.ToString();
			return res;
		}

		public class Solution
		{
			public IList<IList<int>> ThreeSum(int[] nums)
			{
				List<IList<int>> resList = new List<IList<int>>();
				Array.Sort(nums);
				// like sum of two (PRoblem_0001)
				for (int i1 = 0; i1 < nums.Length - 2; i1++)
				{
					if ((i1 >= 1) && (nums[i1] == nums[i1 - 1])) continue;  // same
					int target = -nums[i1];
					int left = i1 + 1;
					int right = nums.Length - 1;
					while (left < right)
					{
						int ts = nums[left] + nums[right];
						if (ts == target)
						{
							resList.Add(new List<int>() { nums[i1], nums[left], nums[right] });
							left++; right--;
							while ( (left < right) && (nums[left] == nums[left - 1])) left++;			//skip same
							while ( (left < right) && (nums[right] == nums[right + 1])) right--;
						}
						else if (ts > target) // move right
							right--;
						else
							left++;
					}//while
				}//i1;

				return resList;
			}// O(n^
		}

		public class Solution_orig
		{
			public IList<IList<int>> ThreeSum(int[] nums)
			{
				List<IList<int>> resList = new List<IList<int>>();
				Array.Sort(nums);
				// in ordered array for any couple of numbers we can quik find a barier to stop check
				int a, b, c;
				int? preva = null;
				int? prevb = null;
				for (int i1 = 0; i1 < nums.Length - 2; i1++)
				{
					a = nums[i1];
					if (preva.HasValue && preva == a)
						continue;
					for (int i2 = i1+1; i2 < nums.Length - 1; i2++)
					{
						b = nums[i2];
						if (prevb.HasValue && prevb == b)
							continue;
						c = a + b;
						for (int i3 = i2+1; i3 < nums.Length; i3++)
						{
							if (c + nums[i3] == 0)
							{
								resList.Add(new List<int>() { a, b, nums[i3] });
								break;
							}
						}//i3
						prevb = b;
					}//i2
					preva = a;
					prevb = null;
				}//i1
				return resList;
			}// O(n^3)
		}
	}//public abstract class Problem_
}