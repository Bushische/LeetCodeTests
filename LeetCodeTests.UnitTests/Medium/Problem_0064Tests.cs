using System;
using System.Collections.Generic;
using NUnit.Framework;
using static LeetCodeTests.Medium.Problem_0064;

namespace LeetCodeTests.Medium
{
    [TestFixture]
    public class Problem_0064Tests
    {
        public static IEnumerable<object[]> TestDataArrays =>
            new[]
            {
                new object[] { new int[][] { [1, 3, 1], [1, 5, 1], [4, 2, 1] }, 7 },
                new object[] { new int[][] { [1, 2, 3], [4, 5, 6] }, 12 },
                // edge case
                new object[] { new int[][] { [1] }, 1 },
                new object[] { new int[][] { [1, 2, 3] }, 6 },
                new object[] { new int[][] { [1], [2], [3] }, 6 },
            };

        [TestCaseSource(nameof(TestDataArrays))]
        public void minPathSum_VariousCases(int[][] grid, int expected)
        {
            var calc = new Solution();
            var result = calc.MinPathSum(grid);
            Assert.AreEqual(expected, result);
        }
    }
}
