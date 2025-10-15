using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Specialized;

namespace LeetCodeTests.Easy
{
	public abstract class Problem_70
    {
		/*
You are climbing a staircase. It takes n steps to reach the top.

Each time you can either climb 1 or 2 steps. In how many distinct ways can you climb to the top?

 

Example 1:

Input: n = 2
Output: 2
Explanation: There are two ways to climb to the top.
1. 1 step + 1 step
2. 2 steps
Example 2:

Input: n = 3
Output: 3
Explanation: There are three ways to climb to the top.
1. 1 step + 1 step + 1 step
2. 1 step + 2 steps
3. 2 steps + 1 step
 
Input: n = 4
Output: 5
1: 1+1+1+1
2: 2+1+1
3: 2+2
4: 1+2+1
5: 1+1+2

Input: n = 5
Output: 8

it looks like, for the next N we can calculate the result as a sum of two previous step (N-1) and (N-2).
Why?
for any N: we can reach N with `+1` from (N-1) climb and with `+2` from (N-2) climb.
So, if we know the result for (N-1) and (N-2) we can calculate the result for N = (N-1) + (N-2)
And we get Fibonacci sequence. With a small adjustment: for calculation i-th element of F.sequence we need to pass (i-1) as an argument.

==> Fibonacci sequence
Constraints:

1 <= n <= 45
		*/
		public static void Test()
		{
			Solution sol = new Solution();

			/*
			var input = new int[] { 2, 7, 11, 15 };
			Console.WriteLine($"Input array: {string.Join(", ", input)}");
			*/
		}

        public class Solution
        {
            public int climbStairs(int n)
            {
                ArgumentOutOfRangeException.ThrowIfGreaterThan(n, 45);
                ArgumentOutOfRangeException.ThrowIfLessThan(n, 1);
                var n0 = 1; // prev to prev sum
                var n1 = 1; // prev sum
                for (int i = 1; i < n; i++)
                {
                    var newSum = n0 + n1;
                    n0 = n1;
                    n1 = newSum;
                }
                return n1;
            }
        }
	}//public abstract class Problem_0070
}