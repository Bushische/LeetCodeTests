using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Specialized;

namespace LeetCodeTests
{
	public abstract class Problem_0050
	{
		/*
Implement pow(x, n).


Example 1:

Input: 2.00000, 10
Output: 1024.00000
Example 2:

Input: 2.10000, 3
Output: 9.26100
		*/
		public static void Test()
		{
			Solution sol = new Solution();

			/*
			var input = new int[] { 2, 7, 11, 15 };
			Console.WriteLine($"Input array: {string.Join(", ", input)}");
			*/
			double input = 2.0;
			int power = 10;
			Console.WriteLine($"{input}^{power} = {sol.MyPow(input, power)} (waits 1024.0000)");

			input = 2.10;
			power = 3;
			Console.WriteLine($"{input}^{power} = {sol.MyPow(input, power)} (waits 9.26100)");

			input = 2.0;
			power = 5;
			Console.WriteLine($"{input}^{power} = {sol.MyPow(input, power)} (waits 32)");

			input = 2.0;
			power = -5;
			Console.WriteLine($"{input}^{power} = {sol.MyPow(input, power)} (waits 1/32 = 0.03125)");
		}

		public class Solution
		{
			public double MyPow(double x, int n)
			{
				if (n == 0)
					return 1;
				double tmp = MyPow(x, n / 2);
				if ((n % 2) == 0)
					return tmp * tmp;
				else if (n > 0)
					return x * tmp * tmp;
				else
					return (tmp * tmp) / x;
			}
		}

		/*
public double MyPow_r(double x, int n)
{
	if (n == 0)
		return 1;
	if (n < 0)
	{
		x = 1 / x;
		n = -n;
	}
	double tmp = MyPow(x, n / 2);
	if ((n % 2) == 0)
		return tmp * tmp;
	else
		return x * tmp * tmp;
}
		*/
	}//public abstract class Problem_
}