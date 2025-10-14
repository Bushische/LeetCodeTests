using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Specialized;

namespace LeetCodeTests
{
	public abstract class Problem_0012
	{
		/*
Write function to convert int value to Roman
		*/
		public static void Test()
		{
			Solution sol = new Solution();

			/*
			var input = new int[] { 2, 7, 11, 15 };
			Console.WriteLine($"Input array: {string.Join(", ", input)}");
			*/
			int input = 3999;
			Console.WriteLine($"Test '{input}' with result '{sol.IntToRoman(input)}' wait 'MMMCMXCIX'");

			input = 99;
			Console.WriteLine($"Test '{input}' with result '{sol.IntToRoman(input)}' wait 'XCIX'");

			input = 909;
			Console.WriteLine($"Test '{input}' with result '{sol.IntToRoman(input)}' wait 'CMIX'");

			input = 949;
			Console.WriteLine($"Test '{input}' with result '{sol.IntToRoman(input)}' wait 'CMXLIX'");


		}

		public class Solution
		{
			Dictionary<int, string> Romans = new Dictionary<int, string>() { { 1, "I" }, { 5, "V" }, { 10, "X" }, { 50, "L" }, { 100, "C" }, { 500, "D" }, { 1000, "M" } };
			/// <summary> 
			/// Конвертация числа в Римский формат 
			/// </summary> 
			/// <param name="inNumber"></param> 
			/// <returns></returns> 
			public string IntToRoman(int inNumber)
			{

				// не более одной меньшей цифры перед большей 
				// единицы, десятки, сотни, тыщи должны быть разделены ( 99 = 90 + 9 = XC + IX = XCIX) (909 = 9*100 + 0*10 + 9 = CM + '' + IX = CMIX) 

				string result = "";
				int mult = 1000;
				while (mult >= 1)
				{
					int decade = inNumber / mult;
					if (decade > 0)
						result += DigitInRoman(decade, mult);
					inNumber = inNumber % mult;
					mult = mult / 10;
				}
				return result;
			}
			/// <summary> 
			/// Преобразуем один разряд в римкое число 
			/// </summary> 
			/// <param name="digit">число разрядов</param> 
			/// <param name="mult">разряд</param> 
			/// <returns></returns> 
			private string DigitInRoman(int digit, int mult)
			{
				Func<int, string, string> padString = (num, temp) =>
				{
					string res = "";
					for (int i = 0; i < num; i++)
						res += Romans[mult];
					return res;
				};

				string result = "";
				if (Romans.ContainsKey(mult * 10))
				{
					if (digit == 9)
					{
						result += Romans[mult] + Romans[mult * 10];
						digit = 0;
					}
					if (digit >= 5)
					{
						result += Romans[mult * 5];
						digit = digit - 5;
					}
					if (digit == 4)
					{
						result += Romans[mult] + Romans[mult * 5];
						digit = 0;
					}
					result += padString(digit, Romans[mult]);
				}
				else if (Romans.ContainsKey(mult))      // Для тысяч - просто столько тысяч, сколько передали 
				{
					result = padString(digit, Romans[mult]);
				}

				return result;
			}
		}// 

	}//public abstract class Problem_
}