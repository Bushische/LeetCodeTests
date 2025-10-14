using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Specialized;

namespace LeetCodeTests
{
	public abstract class Problem_0009
	{
		/*
			Determine whether an integer is a palindrome.Do this without extra space.

			Some hints:
			Could negative integers be palindromes? (ie, -1)

			If you are thinking of converting the integer to string, note the restriction of using extra space.

			You could also try reversing an integer.However, if you have solved the problem "Reverse Integer", you know that the reversed integer might overflow.How would you handle such case?


			There is a more generic way of solving this problem.
		*/
		public static void Test()
		{
			Solution sol = new Solution();

			/*
			var input = new int[] { 2, 7, 11, 15 };
			Console.WriteLine($"Input array: {string.Join(", ", input)}");
			*/
			int input = 1234321;
			Console.WriteLine($"Check number'{input}' is palindrom = {sol.IsPalindrome(input)}");

			input = -22;
			Console.WriteLine($"Check number'{input}' is palindrom = {sol.IsPalindrome(input)}");

			input = 2;
			Console.WriteLine($"Check number'{input}' is palindrom = {sol.IsPalindrome(input)}");

			input = 23;
			Console.WriteLine($"Check number'{input}' is palindrom = {sol.IsPalindrome(input)}");

			input = int.MaxValue;
			Console.WriteLine($"Check number'{input}' is palindrom = {sol.IsPalindrome(input)}");

			//-2147483648
			input = -2147483648;
			Console.WriteLine($"Check number'{input}' is palindrom = {sol.IsPalindrome(input)}");

			/*
			Input: -101
			Output:true
			Expected:false
			*/
			input = -101;
			Console.WriteLine($"Check number'{input}' is palindrom = {sol.IsPalindrome(input)}");

			/*
			Input:1073773701
			Output:false
			Expected:true
			*/
			input = 1073773701;
			Console.WriteLine($"Check number'{input}' is palindrom = {sol.IsPalindrome(input)}");

		}

		public class Solution
		{
			/*
				if we have number abcdf
				try to build number fdcba
				and if (abcdf + fdcba) / 2 = abcdf => is palindrome
				if any overflow - not palindrome
			*/
			public bool IsPalindrome(int x)
			{
				try
				{
					int num1 = Math.Abs(x);
					int num2 = 0;

					while (num1 > 0)
					{
						num2 = checked(num2 * 10 + (num1 % 10));
						num1 = num1 / 10;   //rest of division by 10
					}//while
					 //num1 = Math.Abs(x);
					 //num1 = x;
					 //return ((num1 + num2) / 2) == num1;
					return num2 == x;
				}
				catch (Exception ex)
				{
					string sex = ex.ToString();
					return false;
				}

				//return false;
			}
		}
	}//
}