using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Specialized;

namespace LeetCodeTests
{
    public abstract class Problem_0040
    {
        /*
         * 40. Combination Sum II
Given a collection of candidate numbers (C) and a target number (T), find all unique combinations in C where the candidate numbers sums to T.

Each number in C may only be used once in the combination.

Note:
All numbers (including target) will be positive integers.
The solution set must not contain duplicate combinations.

For example, given candidate set [10, 1, 2, 7, 6, 1, 5] and target 8, 
A solution set is: 
[
  [1, 7],
  [1, 2, 5],
  [2, 6],
  [1, 1, 6]
]
		*/
        public static void Test()
        {
            Solution sol = new Solution();

            /*
			var input = new int[] { 2, 7, 11, 15 };
			Console.WriteLine($"Input array: {string.Join(", ", input)}");
			*/
            int[] inList = new int[] { 10, 1, 2, 7, 6, 1, 5 };
            int target = 8;
            var outList = sol.CombinationSum2(inList, target);
            Console.WriteLine($"Input: {Utils.PrintArray(inList)}, target : {target}, output: {Utils.PrintArray(outList)}");

            target = 40;
            outList = sol.CombinationSum2(inList, target);
            Console.WriteLine($"Input: {Utils.PrintArray(inList)}, target : {target}, output: {Utils.PrintArray(outList)}");

            inList = new int[0];
            target = 40;
            outList = sol.CombinationSum2(inList, target);
            Console.WriteLine($"Input: {Utils.PrintArray(inList)}, target : {target}, output: {Utils.PrintArray(outList)}");

        }

        public class Solution
        {
            private int Target;
            private int Length;
            IList<IList<int>> ResList;
            int[] Elements;

            public IList<IList<int>> CombinationSum2(int[] candidates, int target)
            {
                Target = target;
                Length = candidates.Length;
                ResList = new List<IList<int>>();
                Array.Sort(candidates);
                Elements = candidates;

                var tList = new List<int>();
                ProcessNextVariant(0, tList, 0);

                return ResList;
            }

            private void ProcessNextVariant(int left, List<int> testCand, int sum)
            {
                int prevElement = -1;
                while (left < Length)
                {
                    int elem = Elements[left];

                    if (prevElement != elem)
                    {
                        if (sum + elem == Target)
                        {
                            testCand.Add(elem);
                            FixVariant(testCand);
                            testCand.RemoveAt(testCand.Count - 1);
                        }
                        else if (sum + elem < Target)
                        {
                            testCand.Add(elem);
                            ProcessNextVariant(left + 1, testCand, sum + elem);
                            testCand.RemoveAt(testCand.Count - 1);
                        }
                        else if (sum + elem > Target)
                        {
                            // should stop process
                            return;
                        }
                    }
                    left++;
                    prevElement = elem;
                }
            }

            private void FixVariant(List<int> inList)
            {
                var newVar = new List<int>(inList);
                ResList.Add(newVar);
            }
        }
    }//public abstract class Problem_
}