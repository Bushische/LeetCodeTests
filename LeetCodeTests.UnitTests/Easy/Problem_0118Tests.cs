using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using static LeetCodeTests.Easy.Problem_0118;

namespace LeetCodeTests.Easy
{
    [TestFixture]
    public class Problem_0118Tests
    {
        public static IEnumerable<object[]> TestDataArray =>
            [
                [5, new int[][] { [1], [1, 1], [1, 2, 1], [1, 3, 3, 1], [1, 4, 6, 4, 1] }],
                [1, new int[][] { [1] }],
                [
                    6,
                    new int[][]
                    {
                        [1],
                        [1, 1],
                        [1, 2, 1],
                        [1, 3, 3, 1],
                        [1, 4, 6, 4, 1],
                        [1, 5, 10, 10, 5, 1],
                    },
                ],
            ];

        [TestCaseSource(nameof(TestDataArray))]
        public void searchInsert_VariousCases(int rowNumber, int[][] expected)
        {
            var sol = new Solution();
            var res = sol.Generate(rowNumber).ToArray();

            var convertedExpected = Utils.GetInvariantListOfList(expected);
            var convertedResult = Utils.GetInvariantListOfList(res);
            Assert.AreEqual(convertedExpected, convertedResult);
        }
    }
}
