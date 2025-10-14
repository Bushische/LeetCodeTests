using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Specialized;

namespace LeetCodeTests
{
	public abstract class Problem_0079
	{
		/*
79. Word Search
		 
Given a 2D board and a word, find if the word exists in the grid.

The word can be constructed from letters of sequentially adjacent cell, where "adjacent" cells are those horizontally or vertically neighboring.
The same letter cell may not be used more than once.

For example,
Given board =

[
  ['A', 'B', 'C', 'E'],
  ['S','F','C','S'],
  ['A','D','E','E']
]
word = "ABCCED", -> returns true,
word = "SEE", -> returns true,
word = "ABCB", -> returns false.
		*/
		public static void Test()
		{
			Solution sol = new Solution();

			/*
			var input = new int[] { 2, 7, 11, 15 };
			Console.WriteLine($"Input array: {string.Join(", ", input)}");
			*/
			Func<char[,]> getCharArray = () =>
			 	new char[,] 
			{
				{'A', 'B', 'C', 'E'},
				{'S', 'F', 'C', 'S'},
				{'A', 'D', 'E', 'E'}
			};

			char[,] input = getCharArray();
			Console.WriteLine($"Input array:\n{Utils.Print2DArray(input)}");
			var word = "ABCCED";
			Console.WriteLine($"Search word '{word}' -> '{sol.Exist(input, word)}' waits TRUE");

			input = getCharArray();
			word = "SEE";
			Console.WriteLine($"Search word '{word}' -> '{sol.Exist(input, word)}' waits TRUE");

			input = getCharArray();
			word = "ABCB";
			Console.WriteLine($"Search word '{word}' -> '{sol.Exist(input, word)}' waits FALSE");

			/*
Submission Result: Wrong Answer
Input: [["a"]] "a"
Output:false
Expected:true
			*/
			input = new char[,] { { 'a' } };
			word = "a";
			Console.WriteLine($"Input array:\n{Utils.Print2DArray(input)}");
			Console.WriteLine($"Search word '{word}' -> '{sol.Exist(input, word)}' waits TRUE");

			/*
Submission Result: Time Limit ExceededMore Details

Last executed input:
[["b","a","a","b","a","b"],["a","b","a","a","a","a"],["a","b","a","a","a","b"],["a","b","a","b","b","a"],
["a","a","b","b","a","b"],["a","a","b","b","b","a"],["a","a","b","a","a","b"]]
"aabbbbabbaababaaaabababbaaba"
			*/
			getCharArray = () =>
			 	new char[,]
			{
				{'b','a','a','b','a','b'},
				{'a','b','a','a','a','b'},
				{'a','b','a','b','b','a'},
				{'a','a','b','b','a','b'},
				{'a','a','b','b','b','a'},
				{'a','a','b','a','a','b'}
			};

			input = getCharArray();
			Console.WriteLine($"Input array:\n{Utils.Print2DArray(input)}");
			word = "aabbbbabbaababaaaabababbaaba";
			Benchmark.Start();
			Console.WriteLine($"Search word '{word}' -> '{sol.Exist(input, word)}' waits TRUE");
			var ts = Benchmark.Finish();
			Console.WriteLine($"spanned: {ts.ToString()}");
		}

		public class Solution
		{
			public bool Exist(char[,] board, string word)
			{
				if (string.IsNullOrEmpty(word) || (board == null))
					return false;
				this.board = board;
				this.word = word;
				for (int row = 0; row < this.m; row++)
					for (int col = 0; col < this.n; col++)
					{
						if (board[row, col] == word[0])
							if (backTrace("", row, col))
								return true;
					}
				return false;
			}

			private char[,] _board;
			private int m = 0;
			private int n = 0;
			private char[,] board
			{
				get { return _board; }
				set
				{
					_board = value;
					m = value.GetLength(0);
					n = value.GetLength(1);
				}
			}
			private string word;

			private bool backTrace(string acc, int row, int col)
			{
				/* mark passed chars with ' ' (space)
				 * if (at position(row, col) == ' ') stop search in this direction
				 * position (row, col) - is started position
				 * will pass in direction 1. to up, 2. to right, 3. to down, 4. to left
				*/
				if (acc.Equals(this.word))
					return true;
				if (acc.Length > this.word.Length)
					return false;
				if ((row >= m) || (col >= n) || (row < 0) || (col < 0))
					return false;		// out of board
				//if (board[row, col] == ' ')
				//	return false;
				if (board[row, col] != this.word[acc.Length])
					return false;
				acc += board[row, col];
				board[row, col] = ' ';
				if (backTrace(acc, row - 1, col)) return true;
				if (backTrace(acc, row, col + 1)) return true;
				if (backTrace(acc, row + 1, col)) return true;
				if (backTrace(acc, row, col - 1)) return true;
				//restore board state
				board[row, col] = acc[acc.Length - 1];
				return false;
			}
		}
	}//public abstract class Problem_
}