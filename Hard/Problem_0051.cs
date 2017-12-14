using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Specialized;

namespace LeetCodeTests
{
	public abstract class Problem_0051
	{
		/*
The n-queens puzzle is the problem of placing n queens on an n×n chessboard such that no two queens attack each other.



Given an integer n, return all distinct solutions to the n-queens puzzle.

Each solution contains a distinct board configuration of the n-queens' placement, where 'Q' and '.' both indicate a queen and an empty space respectively.

For example,
There exist two distinct solutions to the 4-queens puzzle:

[
 [".Q..",  // Solution 1
  "...Q",
  "Q...",
  "..Q."],

 ["..Q.",  // Solution 2
  "Q...",
  "...Q",
  ".Q.."]
]
		*/
		public static void Test()
		{
			Solution sol = new Solution();

			/*
			var input = new int[] { 2, 7, 11, 15 };
			Console.WriteLine($"Input array: {string.Join(", ", input)}");
			*/
			var input = 4;
			var resList = sol.SolveNQueens(input);
			Console.WriteLine($"For input {input} -> ");
			PrintSolutions(resList);

			input = 5;
			resList = sol.SolveNQueens(input);
			Console.WriteLine($"For input {input} -> ");
			PrintSolutions(resList);
		}

		private static void PrintSolutions(IList<IList<string>> inSol)
		{
			int index = 1;
			foreach (var list in inSol)
			{
				Console.WriteLine($"Solution {index}");
				Console.WriteLine("[");
				foreach (string line in list)
				{
					Console.WriteLine(line);
				}
				Console.WriteLine("]");
				Console.WriteLine();
			}
		}

		public class Solution
		{
			/// <summary>
			/// Result list of list of lines
			/// </summary>
			List<IList<string>> resList = null;
			/// <summary>
			/// Count of Queens
			/// </summary>
			int N = 0;

			/// <summary>
			/// struct to store Queen position
			/// </summary>
			struct Cell
			{
				public int row;
				public int col;

				public override string ToString()
				{
					return $"({row}, {col})";
				}
			}

			/// <summary>
			/// Get solution for N Queens
			/// </summary>
			/// <returns>The NQ ueens.</returns>
			/// <param name="n">N.</param>
			public IList<IList<string>> SolveNQueens(int n)
			{
				N = n;
				resList = new List<IList<string>>();

				FillList(new List<Cell>());

				return resList;
			}

			/// <summary>
			/// Gets the new line with '.'
			/// </summary>
			/// <returns>The new line.</returns>
			private string GetNewLine()
			{
				string pattern = "........................";
				string res = pattern;
				while (res.Length < N)
					res += pattern;
				return res.Substring(0, N - 1);
			}

			/// <summary>
			/// Gets all possibile positions for Queens in line lineNum
			/// </summary>
			/// <returns>The all possibilities.</returns>
			/// <param name="curSolution">Current solution.</param>
			/// <param name="lineNum">Line number.</param>
			private List<Cell> GetAllPossibilities(List<Cell> curSolution, int lineNum)
			{
				List<Cell> resLine = new List<Cell>();
				bool[] linePosition = new bool[N];
				foreach (Cell cell in curSolution)
				{
					if (cell.row == lineNum)
						return resLine;
					linePosition[cell.col] = true;
					// two diagonals
					// D1 - line on growing diagonal y=x
					// D2 - line on fallling diagonal y=-x
					// if fixing ROW, to find COLUMN we need
					// Q = (qr, qc) =>
					// COLUMN = ROW+(qc-qr) && COLUMN = (qc+qr)-ROW
					int col1 = lineNum + (cell.col - cell.row);
					if ((col1 >= 0) && (col1 < N))
						linePosition[col1] = true;
					col1 = (cell.col + cell.row) - lineNum;
					if ((col1 >= 0) && (col1 < N))
						linePosition[col1] = true;
				}
				for (int col = 0; col < N; col++)
				{
					if (!linePosition[col])
						resLine.Add(new Cell() { row = lineNum, col = col });
				}
				return resLine;
			}

			/// <summary>
			/// Fill board line by line
			/// </summary>
			/// <param name="curList">Current list.</param>
			private void FillList(List<Cell> curList)
			{	// in curList should be ordered by rownumber cells with Q
				if (curList.Count == N)
				{   // fix solution
					List<string> solution = new List<string>();
					foreach (var cell in curList)
					{
						string s = GetNewLine();
						s = s.Substring(0, Math.Max(0, cell.col)) + "Q" + s;
						s = s.Substring(0, N);
						solution.Add(s);
					}
					resList.Add(solution);
				}
				else // recursive pass
				{
					int lineNum = curList.Count;
					foreach (Cell cell in GetAllPossibilities(curList, lineNum))
					{
						curList.Add(cell);
						FillList(curList);
						curList.Remove(cell);
					}
				}
			}
		}
	}//public abstract class Problem_
}