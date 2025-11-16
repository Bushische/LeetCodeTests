using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using static LeetCodeTests.Easy.Problem_0136;

namespace LeetCodeTests.Easy
{
    [TestFixture]
    public class Problem_136Tests
    {
        public static IEnumerable<object[]> TestDataArray =>
            [
                [new int[] { 2, 2, 1 }, 1],
                [new int[] { 4, 1, 2, 1, 2 }, 4],
                [new int[] { 1 }, 1],
                //extra
                [new int[] { 0 }, 0],
                [new int[] { 1, 1, -2, -2, 3, 3, -4, -4, 5 }, 5],
            ];

        [TestCaseSource(nameof(TestDataArray))]
        public void searchInsert_VariousCases(int[] nums, int expected)
        {
            var sol = new Solution();
            var res = sol.SingleNumber(nums);
            Assert.AreEqual(expected, res);
        }
    }
}
