using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Specialized;

namespace LeetCodeTests
{
	public abstract class Problem_0071
	{
		/*
Given an absolute path for a file(Unix-style), simplify it.

For example,
path = "/home/", => "/home"
path = "/a/./b/../../c/", => "/c"
click to show corner cases.

Corner Cases:
Did you consider the case where path = "/../" ?
In this case, you should return "/".
Another corner case is the path might contain multiple slashes '/' together, such as "/home//foo/".
In this case, you should ignore redundant slashes and return "/home/foo".
		*/
		public static void Test()
		{
			Solution sol = new Solution();

			/*
			var input = new int[] { 2, 7, 11, 15 };
			Console.WriteLine($"Input array: {string.Join(", ", input)}");
			*/
			var input = "/home/";
			Console.WriteLine($"'{input}' -> '{sol.SimplifyPath(input)}' (waits '/home')");

			input = "/a/./b/../../c/";
			Console.WriteLine($"'{input}' -> '{sol.SimplifyPath(input)}' (waits '/c')");

			input = "/../";
			Console.WriteLine($"'{input}' -> '{sol.SimplifyPath(input)}' (waits '/')");

			input = "/home//foo/";
			Console.WriteLine($"'{input}' -> '{sol.SimplifyPath(input)}' (waits '/home/foo')");

			input = "/../home/./foo/";
			Console.WriteLine($"'{input}' -> '{sol.SimplifyPath(input)}' (waits '/home/foo')");
		}

		/*
Rules:
/./ - same folder => /
/../ - one level up: /a/b/../ => /a
// -  just skip redundant  // => /
		*/

		public class Solution
		{
			public string SimplifyPath(string path)
			{
				if (string.IsNullOrEmpty(path))
					return path;
				var parts = path.Split('/');
				List<string > pathParts = new List<string>(parts);
				int ind = 0;
				while (ind < pathParts.Count)	// pass through all elements
				{
					if (string.IsNullOrEmpty(pathParts[ind]))       // skip empty parts
						pathParts.RemoveAt(ind);
					else if (pathParts[ind] == ".")                 // same folder
						pathParts.RemoveAt(ind);
					else if (pathParts[ind] == "..")                // to level up
					{
						pathParts.RemoveAt(ind);
						ind--;
						if (ind >= 0)
						{
							pathParts.RemoveAt(ind);
							//ind--;		// not need, but no bad if do
						}
						if (ind < 0)
							ind = 0;
					}
					else
						ind++;
				}

				return "/" + string.Join("/", pathParts);
			}
		}
	}//public abstract class Problem_
}