using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using static LeetCodeTests.Medium.Problem_0162;

namespace LeetCodeTests.Medium
{
    [TestFixture]
    public class Problem_0162Tests
    {
        public static IEnumerable<object[]> TestDataArray =>
            [
                [new int[] { 1, 2, 3, 1 }, 2],
                [new int[] { 1, 2, 1, 3, 5, 6, 4 }, 1],
                // extra
                [new int[] { 5, 3, 2, 1 }, 0],
                [new int[] { 1, 2, 3, 4, 5 }, 4],
                [new int[] { 19, 9, 8, 7, 6, 5, 6, 7, 8 }, 0],
            ];

        [TestCaseSource(nameof(TestDataArray))]
        public void test_VariousCases(int[] nums, int expected)
        {
            var sol = new Solution();
            var res = sol.FindPeakElement(nums);

            Assert.AreEqual(expected, res);
        }
    }
}
