using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using static LeetCodeTests.Medium.Problem_0198;

namespace LeetCodeTests.Medium
{
    [TestFixture]
    public class Problem_0198Tests
    {
        public static IEnumerable<object[]> TestDataArray =>
            [
                [new int[] { 1, 2, 3, 1 }, 4],
                [new int[] { 2, 7, 9, 3, 1 }, 12],
                // extra
                [new int[] { 5, 1, 3, 2, 1, 8, 3, 7 }, 23],
            ];

        [TestCaseSource(nameof(TestDataArray))]
        public void test_VariousCases(int[] input, int expected)
        {
            var sol = new Solution();
            var res = sol.Rob(input);

            Assert.AreEqual(expected, res);
        }
    }
}
