using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Specialized;

namespace LeetCodeTests
{
	public abstract class Problem_0006
	{
		/*
The string "PAYPALISHIRING" is written in a zigzag pattern on a given number of rows like this: (you may want to display this pattern in a fixed font for better legibility)

P   A   H   N
A P L S I I G
Y   I   R
And then read line by line: "PAHNAPLSIIGYIR"
Write the code that will take a string and make this conversion given a number of rows:

string convert(string text, int nRows);
convert("PAYPALISHIRING", 3) should return "PAHNAPLSIIGYIR".

General schema:
1    7
2  6 8
3 5  9
4    10
		*/

		/*
ERROR:
Last executed input:
"A"
1
		*/
		public static void Test()
		{
			Solution sol = new Solution();

			/*
			var input = new int[] { 2, 7, 11, 15 };
			Console.WriteLine($"Input array: {string.Join(", ", input)}");
			*/
			string input = "PAYPALISHIRING";
			int numRows = 3;
			Console.WriteLine($"for input '{input}' -> '{sol.Convert(input, numRows)}', wait 'PAHNAPLSIIGYIR'");

			input = "ABCDEFGHIJKLMN";
			numRows = 3;
			Console.WriteLine($"for input '{input}' -> '{sol.Convert(input, numRows)}', wait 'AEIMBDFHJLNCGK'");

			input = "ABCDEFGHIJKLMN";
			numRows = 4;
			Console.WriteLine($"for input '{input}' -> '{sol.Convert(input, numRows)}', wait 'AGMBFHLNCEIKDJ'");

			// after error
			input = "A";
			numRows = 1;
			Console.WriteLine($"for input '{input}' -> '{sol.Convert(input, numRows)}', wait 'AGMBFHLNCEIKDJ'");
		}

		public class Solution
		{
			public string Convert(string s, int numRows)
			{
				if (string.IsNullOrEmpty(s))
					return s;
				if (numRows == 1)
					return s;
				
				// for i line (i != 1, i != n)
				// vert part: i + (j-1)(2n-2)
				// diag part: (i-2) + j(2n-2)
				int length = s.Length;
				int stepLength = 2 * numRows - 2;
				int stepCount = s.Length / stepLength;
				if ((s.Length % stepLength) != 0)
					stepCount++;
				System.Text.StringBuilder sb = new System.Text.StringBuilder();
				for (int i = 1; i <= numRows; i++)
				{
					for (int j = 1; j <= stepCount; j++)
					{
						// vert part
						int index = i + (j - 1) * stepLength;
						if (index <= length)
							sb.Append(s[index-1]);
						// diag part
						if ((i > 1) && (i < numRows))
						{
							index = j * stepLength - (i - 2);
							if (index <= length)
								sb.Append(s[index-1]);
						}
					}// for i
				} //for j
				return sb.ToString();
			}
		}
	}//public abstract class Problem_
}

/*
Beautiful solution:
class Solution
{
	public:
    string convert(string s, int numRows)
	{
		if (numRows == 1) return s;
		vector<string> res(numRows);
		int row = 0;
		int increase = -1;
		for (int i = 0; i < s.size(); ++i)
		{
			// every time at turning point, we change the increase direction
			if (i % (numRows - 1) == 0) increase *= -1;
			res[row].push_back(s[i]);
			row += increase;
		}
		string ret;
		for (const auto&str:res){
			ret += str;
		}
		return ret;
	}
};
*/