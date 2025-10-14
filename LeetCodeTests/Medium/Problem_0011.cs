using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Specialized;

namespace LeetCodeTests
{
	public abstract class Problem_0011
	{
		/*
Given n non-negative integers a1, a2, ..., an, where each represents a point at coordinate(i, ai). 
n vertical lines are drawn such that the two endpoints of line i is at(i, ai) and(i, 0). 
Find two lines, which together with x-axis forms a container, such that the container contains the most water.

Note: You may not slant the container and n is at least 2.
		*/
		public static void Test()
		{
			Solution sol = new Solution();

			/*
			var input = new int[] { 2, 7, 11, 15 };
			Console.WriteLine($"Input array: {string.Join(", ", input)}");
			*/

			var input = new int[] { 4, 1, 2, 1, 1, 1 };
			Console.WriteLine($"look for max area: {sol.MaxArea(input)}");

			input = new int[] { 5, 3, 8, 2, 6, 1};
			Console.WriteLine($"look for max area: {sol.MaxArea(input)} waits - 20");

			input = new int[] { 5, 3, 18, 2, 16, 1};
			Console.WriteLine($"look for max area: {sol.MaxArea(input)} waits - 32");

//Time Limit Exceeded More Details 
//Last executed input:
//[1,2,3,4,5,6,7,8,9,10,11,... 3000]

			input = new int[] { 1, 3, 5, 7, 9, 11};
			Console.WriteLine($"look for max area: {sol.MaxArea(input)} waits - 15");

			input = new int[] { 11, 9, 7, 5, 3, 1};
			Console.WriteLine($"look for max area: {sol.MaxArea(input)} waits - 15");
//Time Limit Exceeded More Details 
//Last executed input:
//[15000, 14999, 14998,... , 4, 3, 2, 1]

		}


		public class Solution
		{
			public int MaxArea(int[] height)
			{
				int maxArea = 0;
				int left = 0;
				int right = height.Length - 1;
				while (left < right)
				{
					int h = Math.Min(height[left], height[right]);
					maxArea = Math.Max(maxArea, h * (right - left));
					while ((height[left] <= h) && (left < right)) left++;
					while ((height[right] <= h) && (left < right)) right--;
				}
				return maxArea;
			}
		}
		public class Solution2
		{
			/* ideas for optimizing
			i - index from left
			j - index from right for i
			1. if found h[j] >= h[i] - not need look more j => (j-i)*h[i] = MaxArea
			2. during pass from right to lelft (by j) find local max - H=h[l] < h[i]
				no need go j < h[l]*(l-i)/h[i] + i
			*/
			public int MaxArea(int[] height)
			{
				int TotalMaxArea = 0;
				for (int left = 0; left < height.Length - 1; left++)
				{
					int leftH = height[left];
					if ((leftH * (height.Length - left)) <= TotalMaxArea)
						continue;	// skip = not need to calc

					bool stopFlag = false;
					int locMax = 0;
					int locArea = 0;
					for (int right = height.Length - 1;(right > left) && (!stopFlag) ; right--)
					{
						int rightH = height[right];
						if (rightH >= leftH)
						{
							locArea = Math.Max(locArea, (right - left) * leftH);
							stopFlag = true;        // will no find more
						}
						else
						{
							if (rightH > locMax)
							{
								locMax = rightH;
								locArea = Math.Max(locArea, (right - left) * rightH);
							}
							stopFlag = right < ((locArea / leftH) + left);
						}
					}
					TotalMaxArea = Math.Max(TotalMaxArea, locArea);
				}//left
				return TotalMaxArea;
			}
		}

		// time out exception
		public class Solution1
		{
			public int MaxArea(int[] height)
			{
				int maxArea = 0;
				for (int left = 0; left < height.Length; left++)
				{
					for (int right = left + 1; right < height.Length; right++)
					{
						maxArea = Math.Max(maxArea, CalcArea(height[left], height[right], right - left));
					}
				}
				return maxArea;
			}

			//Calculate area
			private int CalcArea(int leftH, int rightH, int length)
			{
				return length * Math.Min(leftH, rightH);
			}
		}
	}//public abstract class Problem_
}