using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Specialized;

namespace LeetCodeTests
{
	public abstract class Problem_0060
	{
		/*
The set[1, 2, 3,…, n] contains a total of n! unique permutations.

  By listing and labeling all of the permutations in order,
  We get the following sequence (ie, for n = 3):

"123"
"132"
"213"
"231"
"312"
"321"
Given n and k, return the kth permutation sequence.

Note: Given n will be between 1 and 9 inclusive.
		*/
		public static void Test()
		{
			Solution sol = new Solution();

			/*
			var input = new int[] { 2, 7, 11, 15 };
			Console.WriteLine($"Input array: {string.Join(", ", input)}");
			*/
			int n = 3;
			int k = 3;
			Console.WriteLine($"For n={n} and k={k} -> '{sol.GetPermutation(n, k)}' (waits '213')");

			k = 5;
			Console.WriteLine($"For n={n} and k={k} -> '{sol.GetPermutation(n, k)}' (waits '312')");

			k = 1;
			Console.WriteLine($"For n={n} and k={k} -> '{sol.GetPermutation(n, k)}' (waits '123')");

			n = 4;
			k = 5;
			Console.WriteLine($"For n={n} and k={k} -> '{sol.GetPermutation(n, k)}' (waits '1423')");

			k = 10;
			Console.WriteLine($"For n={n} and k={k} -> '{sol.GetPermutation(n, k)}' (waits '2341')");

			k = 15;
			Console.WriteLine($"For n={n} and k={k} -> '{sol.GetPermutation(n, k)}' (waits '3214')");

			k = 20;
			Console.WriteLine($"For n={n} and k={k} -> '{sol.GetPermutation(n, k)}' (waits '4132')");
		}

		/*
n=3 => 6 permutation
n=4 => 24 permutation
1: 1234
2: 1243
3: 1324
4: 1342
5: 1423
6: 1432

7: 2134
8: 2143
9: 2314
10:2341
11:2413
12:2431

13:3124
14:3142
15:3214
16:3241
17:3412
18:3421

19:4123
20:4132
21:4213
22:4231
23:4312
24:4321
... 

For given N and K:
Build SET = 1,2,3,4,...N
Build result string (index from 1)
For index i from 1 to N do
	ind = K / (N-i)!  -  index element in SET
	RESULT += SET[ind]
	SET = SET \ SET[ind]
	K = K % (N-i)! 	  -  rest of division
Repeat in loop while K > 0
If K > 0 and SET not empty, add SET to RESULT
return RESULT

		*/

		public class Solution
		{
			public string GetPermutation(int n, int k)
			{
				k = k - 1;  // make shift to 0

				string resPermutation = "";		// result
				string restNums = "";			// set of elements to place
				for (int ij = 1; ij <= n; ij++)
					restNums += ij.ToString();
				int i = 1;						// position
				while ((k > 0) && (i <= n)) 
				{
					int ind = (int)(k / Fact(n - i));
					k = (int)(k % Fact(n - i));
					if (ind >= restNums.Length)
						ind = 0;
					resPermutation += restNums[ind];
					restNums = restNums.Remove(ind, 1);
					i++;
				}
				resPermutation += restNums;

				return resPermutation;
			}

			private long Fact(int n)
			{
				long res = 1;
				while (n > 0)
				{
					res *= n;
					n--;
				}
				return res;
			}
		}
	}//public abstract class Problem_
}