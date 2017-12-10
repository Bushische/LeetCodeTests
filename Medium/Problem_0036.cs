using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Specialized;

namespace LeetCodeTests
{
	public abstract class Problem_0036
	{
		/*
Determine if a Sudoku is valid, according to: Sudoku Puzzles - The Rules.
The Sudoku board could be partially filled, where empty cells are filled with the character '.'.
A partially filled sudoku which is valid.: https://leetcode.com/problems/valid-sudoku/description/

Note:
A valid Sudoku board (partially filled) is not necessarily solvable.Only the filled cells need to be validated.
		*/
		public static void Test()
		{
			Solution sol = new Solution();

			/*
			var input = new int[] { 2, 7, 11, 15 };
			Console.WriteLine($"Input array: {string.Join(", ", input)}");
			*/
			var board = new char[9, 9];
			#region valid example
			for (int row = 0; row < 9; row++)
				for (int col = 0; col < 9; col++)
					board[row, col] = '.';

			board[0, 0] = '5';
			board[0, 1] = '3';
			board[0, 4] = '7';

			board[1, 0] = '6';
			board[1, 3] = '1';
			board[1, 4] = '9';
			board[1, 5] = '5';

			board[2, 1] = '9';
			board[2, 2] = '8';
			board[2, 7] = '6';

			board[3, 0] = '8';
			board[3, 4] = '6';
			board[3, 8] = '3';

			board[4, 0] = '4';
			board[4, 3] = '8';
			board[4, 5] = '3';
			board[4, 8] = '1';

			board[5, 0] = '7';
			board[5, 4] = '2';
			board[5, 8] = '6';

			board[6, 1] = '6';
			board[6, 6] = '2';
			board[6, 7] = '8';

			board[7, 3] = '4';
			board[7, 4] = '1';
			board[7, 5] = '9';
			board[7, 8] = '5';

			board[8, 4] = '8';
			board[8, 7] = '7';
			board[8, 8] = '9';
			#endregion

			Console.WriteLine($"Test sudoku:");
            PrintSudokuBoard(board);
			Console.WriteLine($"result: {sol.IsValidSudoku(board)}");

			board = new char[,] {
				{'.', '.', '.',  '.', '.', '.',  '.', '.', '.'},
				{'.', '.', '.',  '.', '.', '.',  '.', '.', '.'},
				{'.', '.', '.',  '.', '.', '.',  '.', '.', '.'},

				{'.', '.', '.',  '.', '.', '.',  '.', '.', '.'},
				{'.', '.', '.',  '.', '.', '.',  '.', '.', '.'},
				{'.', '.', '.',  '.', '.', '.',  '.', '.', '.'},

				{'.', '.', '.',  '.', '.', '.',  '.', '.', '.'},
				{'.', '.', '.',  '.', '.', '.',  '.', '.', '.'},
				{'.', '.', '.',  '.', '.', '.',  '.', '.', '.'}
			};

			Console.WriteLine($"Test sudoku:");
            PrintSudokuBoard(board);
			Console.WriteLine($"result: {sol.IsValidSudoku(board)}");

			// wrong answer: 
			/*
Input:
[[".","8","7","6","5","4","3","2","1"],
 ["2",".",".",".",".",".",".",".","."],
 ["3",".",".",".",".",".",".",".","."],
 ["4",".",".",".",".",".",".",".","."],
 ["5",".",".",".",".",".",".",".","."],
 ["6",".",".",".",".",".",".",".","."],
 ["7",".",".",".",".",".",".",".","."],
 ["8",".",".",".",".",".",".",".","."],
 ["9",".",".",".",".",".",".",".","."]]
Output:  false
Expected:true
			*/
			board = new char[,] {
				{'.', '8', '7',  '6', '5', '4',  '3', '2', '1'},
				{'2', '.', '.',  '.', '.', '.',  '.', '.', '.'},
				{'3', '.', '.',  '.', '.', '.',  '.', '.', '.'},

				{'4', '.', '.',  '.', '.', '.',  '.', '.', '.'},
				{'5', '.', '.',  '.', '.', '.',  '.', '.', '.'},
				{'6', '.', '.',  '.', '.', '.',  '.', '.', '.'},

				{'7', '.', '.',  '.', '.', '.',  '.', '.', '.'},
				{'8', '.', '.',  '.', '.', '.',  '.', '.', '.'},
				{'9', '.', '.',  '.', '.', '.',  '.', '.', '.'}
			};

			Console.WriteLine($"Test sudoku:");
			PrintSudokuBoard(board);
			Console.WriteLine($"result: {sol.IsValidSudoku(board)}");


		}
		private static void PrintSudokuBoard(char[,] board)
		{
			for (int row = 0; row < 9; row++)
			{
				if ((row % 3) == 0)
					Console.WriteLine();
				for (int col = 0; col < 9; col++)
				{
					if ((col % 3) == 0)
						Console.Write("  ");
					Console.Write($" {board[row, col]}");
				}
				Console.WriteLine();
			}
		}
	

		public class Solution
		{
			public bool IsValidSudoku(char[,] board)
			{
				return isCorrectrlyFilled(board);
			}

			/// <summary>
			/// check board is correctly filled
			/// </summary>
			/// <returns><c>true</c>, if correctrly filled was ised, <c>false</c> otherwise.</returns>
			/// <param name="board">Board.</param>
			private bool isCorrectrlyFilled(char[,] board)
			{
				// check rows
				// check columns
				// check squares (3x3)
				HashSet<char> els = new HashSet<char>();

				#region Check all rows
				for (int row = 0; row < 9; row++)
				{
					els.Clear();
					for (int col = 0; col < 9; col++)
					{
						if (board[row, col] == '.')
							continue;
						if (els.Contains(board[row, col]))
							return false;
						els.Add(board[row, col]);
					}
				}
				#endregion

				#region Check all columns
				for (int col = 0; col < 9; col++)
				{
					els.Clear();
					for (int row = 0; row < 9; row++)
					{
						if (board[row, col] == '.')
							continue;
						if (els.Contains(board[row, col]))
							return false;
						els.Add(board[row, col]);
					}
				}
				#endregion

				#region Check all squares
				for (int sr = 0; sr < 3; sr++)
				{
					for (int sc = 0; sc < 3; sc++)
					{
						els.Clear();
						for (int row = sr * 3; row < sr * 3 + 3; row++)
							for (int col = sc * 3; col < sc * 3 + 3; col++)
							{
								if (board[row, col] == '.')
									continue;
								if (els.Contains(board[row, col]))
									return false;
								els.Add(board[row, col]);
							}
					}
				}
				#endregion
				return true;
			}
		}
	}//public abstract class Problem_
}