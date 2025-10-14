using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Specialized;

namespace LeetCodeTests
{
	public abstract class Problem_0029
	{
		/*
Divide two integers without using multiplication, division and mod operator.

If it is overflow, return MAX_INT.
		*/
		public static void Test()
		{
			Solution sol = new Solution();

			/*
			var input = new int[] { 2, 7, 11, 15 };
			Console.WriteLine($"Input array: {string.Join(", ", input)}");
			*/
			#region OK tests
			var dividend = 15;
			var divisor = 3;
			Console.WriteLine($" {dividend} / {divisor} = {sol.Divide(dividend, divisor)} wait {dividend / divisor}");

			dividend = 17;
			divisor = 3;
			Console.WriteLine($" {dividend} / {divisor} = {sol.Divide(dividend, divisor)} wait {dividend / divisor}");

			dividend = 13;
			divisor = 3;
			Console.WriteLine($" {dividend} / {divisor} = {sol.Divide(dividend, divisor)} wait {dividend / divisor}");

			dividend = 16;
			divisor = 1;
			Console.WriteLine($" {dividend} / {divisor} = {sol.Divide(dividend, divisor)} wait {dividend / divisor}");

			dividend = 16;
			divisor = 0;
			Console.WriteLine($" {dividend} / {divisor} = {sol.Divide(dividend, divisor)} wait +oo");

			dividend = 1;
			divisor = 3;
			Console.WriteLine($" {dividend} / {divisor} = {sol.Divide(dividend, divisor)} wait {dividend / divisor}");

			dividend = -16;
			divisor = 3;
			Console.WriteLine($" {dividend} / {divisor} = {sol.Divide(dividend, divisor)} wait {dividend / divisor}");

			dividend = -16;
			divisor = -3;
			Console.WriteLine($" {dividend} / {divisor} = {sol.Divide(dividend, divisor)} wait {dividend / divisor}");
			#endregion
			/*
Status: Time Limit Exceeded
Last executed input: 2147483647 / 2
			*/
			dividend = 2147483647;
			divisor = 2;
			Console.WriteLine($" {dividend} / {divisor} = {sol.Divide(dividend, divisor)} wait {dividend / divisor}");

			/*
Runtime error: -2147483648 / -1
			*/
			dividend = -2147483648;
			divisor = -1;
			Console.WriteLine($" {dividend} / {divisor} = {sol.Divide(dividend, divisor)} wait +oo");

			/*
Submission Result: Runtime Error 
Last executed input: 1004958205 / -2137325331
			*/
			dividend = 1004958205;
			divisor = -2137325331;
			Console.WriteLine($" {dividend} / {divisor} = {sol.Divide(dividend, divisor)} wait {dividend / divisor}");

			/*
Submission Result: Runtime Error 
Last executed input: -1010369383 / -2147483648
			*/
			dividend = -1010369383;
			divisor = -2147483648;
			Console.WriteLine($" {dividend} / {divisor} = {sol.Divide(dividend, divisor)} wait {dividend / divisor}");

			/*
Submission Result: Runtime Error 
Last executed input: 1026117192 / -874002063
			*/
			dividend = 1026117192;
			divisor = -874002063;
			Console.WriteLine($" {dividend} / {divisor} = {sol.Divide(dividend, divisor)} wait {dividend / divisor}");

			/*
Input: -2147483648 / 2
Output: 0
Expected: -1073741824
			*/
			dividend = -2147483648;
			divisor = 2;
			Console.WriteLine($" {dividend} / {divisor} = {sol.Divide(dividend, divisor)} wait {dividend / divisor}");

			/*
Input: 1038925803 / -2147483648
Output: 2147483647
Expected: 0			 
			*/
			dividend = 1038925803;
			divisor = -2147483648;
			Console.WriteLine($" {dividend} / {divisor} = {sol.Divide(dividend, divisor)} wait {dividend / divisor}");

			/*
Input: -2147483648 / -2147483648
Output: 2147483647
Expected: 1
			*/
			dividend = -2147483648;
			divisor = -2147483648;
			Console.WriteLine($" {dividend} / {divisor} = {sol.Divide(dividend, divisor)} wait {dividend / divisor}");
		}

		public class Solution
		{
			public int Divide(int dividend, int divisor)
			{
				try
				{
					#region input checks
					if (divisor == 0)
						return int.MaxValue;
					if (divisor == 1)
						return dividend;
					if (divisor == -1)
						return checked(-dividend);
					if (dividend == divisor)
						return 1;
					#endregion

					int sign1 = (dividend < 0) ? -1 : 1;
					int sign2 = (divisor < 0) ? -1 : 1;

					//dividend = Math.Abs(dividend);
					//divisor = Math.Abs(divisor);

					#region extremum cases checks
					if (sign1 == sign2)
					{
						
						if (((sign1 > 0) && (dividend < divisor))
							|| ((sign1 < 0) && (dividend > divisor)))
							return 0;
					}
					else// sign1 != sign2
					{
						if (sign2 < 0)
						{
							if (divisor == int.MinValue)
								return 0;
						}
						if (((sign1 < 0) && (dividend > -divisor))
							|| ((sign2 < 0) && (dividend < -divisor)))
							return 0;
					}
					#endregion

					dividend -= (sign1 == sign2) ? divisor : -divisor;

					long minused = divisor;

					int res = 1;
					//while (minused + minused <= (long)dividend)
					while ( ((sign1 == sign2) && (sign1 > 0) && (minused + minused <= (long)dividend))
						  ||((sign1 == sign2) && (sign1 < 0) && (minused + minused >= (long)dividend))
					      ||((sign1 != sign2) && (sign2 < 0) && (-(minused + minused) <= (long)dividend))
					       ||((sign1 != sign2) && (sign2 > 0) && (minused + minused <= -(long)dividend))
					      )
					{
						dividend -= (sign1 == sign2) ? (int)minused : -(int)minused;
						minused += minused;
						res += res;
					}
					// need calc in rest
					res = checked(res + Divide((sign1 > 0)?dividend:-dividend, (sign2 > 0)?divisor: -divisor));

					if (sign1 == sign2)
						return res;
					else
						return -res;
				}
				catch (Exception)
				{
					return int.MaxValue;
				}

			}
		}

		public class Solution_long
		{
			public int Divide(int dividend, int divisor)
			{
				if (divisor == 0)
					return int.MaxValue;
				if (divisor == 1)
					return dividend;
				try
				{
					int sign1 = (dividend < 0) ? -1 : 1;
					int sign2 = (divisor < 0) ? -1 : 1;

					dividend = Math.Abs(dividend);
					divisor = Math.Abs(divisor);

					int res = 0;
					while (dividend >= 0)
					{
						res++;
						dividend -= divisor;
					}
					return (res-1) * sign1 * sign2;
				}
				catch
				{
					return int.MaxValue;
				}
			}
		}
	}//public abstract class Problem_
}