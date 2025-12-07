using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using static LeetCodeTests.Medium.Problem_0191;

namespace LeetCodeTests.Medium
{
    [TestFixture]
    public class Problem_0191Tests
    {
        public static IEnumerable<object[]> TestDataArray =>
            [
                [11, 3],
                [128, 1],
                [2147483645, 30],
                // extra
                [64, 1],
                [1, 1],
                [2, 1],
                [3, 2],
            ];

        [TestCaseSource(nameof(TestDataArray))]
        public void test_VariousCases(int input, int expected)
        {
            var sol = new Solution();
            var res = sol.HammingWeight(input);

            Assert.AreEqual(expected, res);
        }
    }
}
