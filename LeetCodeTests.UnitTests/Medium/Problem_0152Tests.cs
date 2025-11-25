using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using static LeetCodeTests.Medium.Problem_0152;

namespace LeetCodeTests.Medium
{
    [TestFixture]
    public class Problem_0152Tests
    {
        public static IEnumerable<object[]> TestDataArray =>
            [
                [new int[] { 2, 3, -2, 4 }, 6],
                [new int[] { -2, 0, -1 }, 0],
                [new int[] { -2 }, -2],
                // extra
                [new int[] { -1, 1, 0, 2, -3, 4, -5, 6, -7 }, 840],
                [new int[] { -1, 1, 0 }, 1],
            ];

        [TestCaseSource(nameof(TestDataArray))]
        public void test_VariousCases(int[] nums, int expected)
        {
            var sol = new Solution();
            var res = sol.MaxProduct(nums);

            Assert.AreEqual(expected, res);
        }
    }
}
