using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using static LeetCodeTests.Medium.Problem_0120;

namespace LeetCodeTests.Medium
{
    [TestFixture]
    public class Problem_0120Tests
    {
        public static IEnumerable<object[]> TestDataArray =>
            [
                [new int[][] { [2], [3, 4], [6, 5, 7], [4, 1, 8, 3] }, 11],
                [new int[][] { [-10] }, -10],
                [new int[][] { [1], [3, 2], [4, 5, 6], [10, 9, 8, 7] }, 16],
                // edge case
                [new int[][] { }, 0],
                [new int[][] { [1], [2, 1], [3, 2, 1], [4, 3, 2, 1] }, 4],
            ];

        [TestCaseSource(nameof(TestDataArray))]
        public void searchInsert_VariousCases(IList<IList<int>> inTriangle, int expected)
        {
            var sol = new Solution();
            var res = sol.MinimumTotal(inTriangle);

            Assert.AreEqual(expected, res);
        }
    }
}
