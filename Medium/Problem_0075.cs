using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Specialized;

namespace LeetCodeTests
{
	public abstract class Problem_0075
	{
		/*
Given an array with n objects colored red, white or blue, sort them so that objects of the same color are adjacent, 
with the colors in the order red, white and blue.

Here, we will use the integers 0, 1, and 2 to represent the color red, white, and blue respectively.

Note:
You are not suppose to use the library's sort function for this problem.

Follow up:
A rather straight forward solution is a two-pass algorithm using counting sort.
First, iterate the array counting number of 0's, 1's, and 2's, then overwrite array with total number of 0's, then 1's and followed by 2's.

Could you come up with an one-pass algorithm using only constant space?
		*/
		public static void Test()
		{
			Solution sol = new Solution();

			/*
			var input = new int[] { 2, 7, 11, 15 };
			Console.WriteLine($"Input array: {string.Join(", ", input)}");
			*/

			var input = new int[] { 0, 0, 0, 0, 0, 1, 1, 2, 2, 2 };
			Console.WriteLine($"Input '{Utils.PrintArray(input)}'");
			sol.SortColors(input);
			Console.WriteLine($"Output '{Utils.PrintArray(input)}'\n");

			input = new int[] { 2, 0, 1, 0, 0, 1, 1, 1, 2, 0 };
			Console.WriteLine($"Input '{Utils.PrintArray(input)}'");
			sol.SortColors(input);
			Console.WriteLine($"Output '{Utils.PrintArray(input)}'\n");

			input = new int[] { 2,2,0,0,2,2,0,0 };
			Console.WriteLine($"Input '{Utils.PrintArray(input)}'");
			sol.SortColors(input);
			Console.WriteLine($"Output '{Utils.PrintArray(input)}'\n");

			input = new int[] { 0,0,0,0,0};
			Console.WriteLine($"Input '{Utils.PrintArray(input)}'");
			sol.SortColors(input);
			Console.WriteLine($"Output '{Utils.PrintArray(input)}'\n");

			input = new int[] { 1,1,1,1,1};
			Console.WriteLine($"Input '{Utils.PrintArray(input)}'");
			sol.SortColors(input);
			Console.WriteLine($"Output '{Utils.PrintArray(input)}'\n");

			input = new int[] { 2,2,2,2};
			Console.WriteLine($"Input '{Utils.PrintArray(input)}'");
			sol.SortColors(input);
			Console.WriteLine($"Output '{Utils.PrintArray(input)}'\n");

			/*
Submission Result: Wrong Answer
Input:[1,0]
Output:[1,0]
Expected:[0,1]
			*/
			input = new int[] { 1, 0};
			Console.WriteLine($"Input '{Utils.PrintArray(input)}'");
			sol.SortColors(input);
			Console.WriteLine($"Output '{Utils.PrintArray(input)}'\n");

			/*
Submission Result: Wrong Answer
Input:[0,0,1]
Output:[0,1,0]
Expected:[0,0,1]
			*/
			input = new int[] { 0, 0, 1};
			Console.WriteLine($"Input '{Utils.PrintArray(input)}'");
			sol.SortColors(input);
			Console.WriteLine($"Output '{Utils.PrintArray(input)}'\n");

			/*
Submission Result: Wrong Answer 
Input:[1,1,2,0,1,1,1,2]
Output:[1,1,1,0,1,1,2,2]
Expected:[0,1,1,1,1,1,2,2]
			*/
			input = new int[] { 1,1,2,0,1,1,1,2};
			Console.WriteLine($"Input '{Utils.PrintArray(input)}'");
			sol.SortColors(input);
			Console.WriteLine($"Output '{Utils.PrintArray(input)}'\n");

		}


		public class Solution
		{
			public void SortColors(int[] nums)
			{
				if ((nums == null) || (nums.Length <= 1))
					return;
				Action<int, int> Swap = (left, right) =>
				{
					int tmp = nums[left];
					nums[left] = nums[right];
					nums[right] = tmp;
				};

				int zero = 0;
				int two = nums.Length - 1;
				int i = 0;
				//for (int i = 0; i <= two; i++)
				while (i <= two)
				{
					if (nums[i] == 0)
					{
						Swap(zero, i);
						zero++;
					}
					if (nums[i] == 2)
					{
						Swap(two, i);
						two--;
						i--;
					}
					i++;
				}
			}
		}
		/// <summary>
		///  to difficult solution
		/// </summary>
		public class Solution_bad
		{	// the list of 0, 1 and 2
			public void SortColors(int[] nums)
			{
				if ((nums == null) || (nums.Length <= 1))
					return;
				Action<int, int> Swap = (left, right) =>
				{
					int tmp = nums[left];
					nums[left] = nums[right];
					nums[right] = tmp;
				};
				int ind0 = 0;
				int ind1 = nums.Length / 2;
				int ind1dx = 1;		// direction to move middle index
				int ind2 = nums.Length - 1;
				while (ind0 < ind2)
				{
					while ((nums[ind0] == 0) && (ind0 < ind2)) ind0++;
					while ((nums[ind2] == 2) && (ind0 < ind2)) ind2--;
					while ((ind1 < ind2) && (ind0 < ind1) && (nums[ind1] == 1)) ind1 += ind1dx;
					if (ind0 >= ind2)
						return;
					if (ind1 < ind0)
						return;
					else if (ind1 > ind2)
					{
						ind1dx = -1;        // will move 1 to left, not to right
						ind1--;
					}
					else if (((nums[ind0] != 0) && (nums[ind2] == 0))
					         || ((nums[ind2] != 2) && (nums[ind0] == 2)))
						Swap(ind0, ind2);
					else if (((nums[ind0] != 0) && (nums[ind1]) == 0)
					         || ((nums[ind1] != 1) && (nums[ind0] == 1)))
						Swap(ind0, ind1);
					else if (((nums[ind2] != 2) && (nums[ind1] == 2))
					         || ((nums[ind1] != 1) && (nums[ind2] == 1)))
						Swap(ind1, ind2);
					else
						ind1 += ind1dx;
						//ind0++;
				}
			}
		}
	}//public abstract class Problem_
}

/*
102
120
201
210

else if ((nums[ind0] != 0) && (nums[ind2] == 0))
                        Swap(ind0, ind2);
					else if ((nums[ind0] != 0) && (nums[ind1]) == 0)
						Swap(ind0, ind1);
					else if ((nums[ind2] != 2) && (nums[ind0] == 2))
						Swap(ind0, ind2);
					else if ((nums[ind2] != 2) && (nums[ind1] == 2))
						Swap(ind1, ind2);
					else if ((nums[ind1] != 1) && (nums[ind0] == 1))
						Swap(ind0, ind1);
					else if ((nums[ind1] != 1) && (nums[ind2] == 1))
						Swap(ind1, ind2);
					else
						ind0++;
*/