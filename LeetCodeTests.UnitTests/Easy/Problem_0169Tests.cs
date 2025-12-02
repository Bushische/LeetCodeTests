using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using static LeetCodeTests.Easy.Problem_0169;

namespace LeetCodeTests.Easy
{
    [TestFixture]
    public class Problem_169Tests
    {
        public static IEnumerable<object[]> TestDataArray =>
            [
                [new int[] { 3, 2, 3 }, 3],
                [new int[] { 2, 2, 1, 1, 1, 2, 2 }, 2],
                [new int[] { 1, 1, 2, 1, 2, 3, 3, 4, 3, 4, 3 }, 3],
            ];

        [TestCaseSource(nameof(TestDataArray))]
        public void test_VariousCases(int[] nums, int expected)
        {
            var sol = new Solution();
            var res = sol.MajorityElement(nums);
            Assert.AreEqual(expected, res);
        }
    }
}
