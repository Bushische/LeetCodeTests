using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using static LeetCodeTests.Medium.Problem_0122;

namespace LeetCodeTests.Medium
{
    [TestFixture]
    public class Problem_0122Tests
    {
        public static IEnumerable<object[]> TestDataArray =>
            [
                [new int[] { 7, 1, 5, 3, 6, 4 }, 7],
                [new int[] { 1, 2, 3, 4, 5 }, 4],
                [new int[] { 7, 6, 4, 3, 1 }, 0],
                // edge case
                [new int[] { 1 }, 0],
            ];

        [TestCaseSource(nameof(TestDataArray))]
        public void searchInsert_VariousCases(int[] priceList, int expected)
        {
            var sol = new Solution();
            var res = sol.MaxProfit(priceList);

            Assert.AreEqual(expected, res);
        }
    }
}
