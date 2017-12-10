using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Specialized;

namespace LeetCodeTests
{
	public abstract class Problem_0037
	{
		/*

		*/
		public static void Test()
		{
			Solution sol = new Solution();

			/*
			var input = new int[] { 2, 7, 11, 15 };
			Console.WriteLine($"Input array: {string.Join(", ", input)}");
			*/
			var board = new char[9, 9];
			#region empty sudoku
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
			#endregion

			board = new char[,] {
				{'5', '3', '.',  '.', '7', '.',  '.', '.', '.'},
				{'6', '.', '.',  '1', '9', '5',  '.', '.', '.'},
				{'.', '9', '8',  '.', '.', '.',  '.', '6', '.'},

				{'8', '.', '.',  '.', '6', '.',  '.', '.', '3'},
				{'4', '.', '.',  '8', '.', '3',  '.', '.', '1'},
				{'7', '.', '.',  '.', '2', '.',  '.', '.', '6'},

				{'.', '6', '.',  '.', '.', '.',  '2', '8', '.'},
				{'.', '.', '.',  '4', '1', '9',  '.', '.', '5'},
				{'.', '.', '.',  '.', '8', '.',  '.', '7', '9'}
			};


			Console.WriteLine($"input sudoku:");
			PrintSudokuBoard(board);
			sol.SolveSudoku(board);
			Console.WriteLine($"result: ");
			PrintSudokuBoard(board);

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

			Console.WriteLine($"input sudoku:");
			PrintSudokuBoard(board);
			sol.SolveSudoku(board);
			Console.WriteLine($"result: ");
			PrintSudokuBoard(board);
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

			private void PrintSudokuBoard(char[,] board)
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

			public void SolveSudoku(char[,] board)
			{
    			tryFill(board, 0, 0);
			}

			/// <summary>
			/// check input set contains all numbers from 1 to 9
			/// </summary>
			/// <returns><c>true</c>, if set full was ised, <c>false</c> otherwise.</returns>
			/// <param name="inset">Inset.</param>
			private bool isSetFull(HashSet<char> inset)
			{
				for (int i = 1; i <= 9; i++)
					//if (!inset.Contains(i.ToString()[0]))
					if (!inset.Contains((char)(i + (int)'0')))
						return false;
				return true;
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
						els.Add(board[row, col]);
					}
					if (!isSetFull(els))
						return false;
				}
				#endregion

				#region Check all columns
				for (int col = 0; col < 9; col++)
				{
					els.Clear();
					for (int row = 0; row < 9; row++)
					{
						els.Add(board[row, col]);
					}
					if (!isSetFull(els))
						return false;
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
								els.Add(board[row, col]);
						if (!isSetFull(els))
							return false;
					}
				}
				#endregion

				//PrintSudokuBoard(board);
				return true;
			}

			/// <summary>
			/// returns all possible numbers for cell
			/// </summary>
			/// <returns>The possible numbers.</returns>
			/// <param name="board">Board.</param>
			/// <param name="inRow">In row.</param>
			/// <param name="inCol">In col.</param>
			private HashSet<char> getPossibleNumbers(char[,] board, int inRow, int inCol)
			{
				HashSet<char> resSet = new HashSet<char>();
				HashSet<char> rowSet = new HashSet<char>();
				HashSet<char> colSet = new HashSet<char>();
				HashSet<char> squSet = new HashSet<char>();
				for (int ind = 0; ind < 9; ind++)       // collect all chars that can not be used more
				{
					if (board[ind, inCol] != '.')
						colSet.Add(board[ind, inCol]);
					if (board[inRow, ind] != '.')
						rowSet.Add(board[inRow, ind]);
				}
				for (int row = (inRow / 3) * 3; row < (inRow / 3) * 3 + 3; row++)
					for (int col = (inCol / 3) * 3; col < (inCol / 3) * 3 + 3; col++)
						if (board[row, col] != '.')
							squSet.Add(board[row, col]);
				for (int ind = 1; ind <= 9; ind++)
				{
					char ch = (char)(ind + (int)'0');
					if (!colSet.Contains(ch)
						&& !rowSet.Contains(ch)
						&& !squSet.Contains(ch)
					   )
						resSet.Add(ch);
				}
				return resSet;
			}

			/// <summary>
			/// recursive fill of board
			/// </summary>
			/// <returns><c>true</c>, if fill was tryed, <c>false</c> otherwise.</returns>
			/// <param name="board">Board.</param>
			/// <param name="inRow">In row.</param>
			/// <param name="inCol">In col.</param>
			private bool tryFill(char[,] board, int inRow, int inCol)
			{
				if ((inRow == 8) && (inCol == 9))
					return isCorrectrlyFilled(board);       // there need to check all board
				if (inCol == 9)
					return tryFill(board, inRow + 1, 0);    // move to next line
				if (inRow >= 9) return false;
				if (board[inRow, inCol] == '.') // try to find next possible number
				{
					HashSet<char> possibilities = getPossibleNumbers(board, inRow, inCol);
					foreach (char possible in possibilities)
					{
						board[inRow, inCol] = possible;
						if (tryFill(board, inRow, inCol + 1))
							return true;
					}
					board[inRow, inCol] = '.';
					return false;
				}
				else // at possition board[inROw, inCol] = NUMBER, cant change
				{
					return tryFill(board, inRow, inCol + 1);
				}
			}
		}
	}//public abstract class Problem_
}