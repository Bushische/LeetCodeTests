using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using static LeetCodeTests.Medium.Problem_0204;

namespace LeetCodeTests.Medium
{
    [TestFixture]
    public class Problem_0204Tests
    {
        public static IEnumerable<object[]> TestDataArray =>
            [
                [10, 4],
                [1, 0],
                [0, 0],
                // extra
                [9, 4],
                [7, 3],
                [6, 3],
                // wrong
                [2, 0],
                // wrong
                [10000, 1229],
                // timeout
                [499979, 41537],
                // timeout
                // [999983, ...]
                // timeout
                // [5000000, ...]`
            ];

        [TestCaseSource(nameof(TestDataArray))]
        public void test_VariousCases(int checkN, int expected)
        {
            var sol = new Solution();
            var result = sol.CountPrimes(checkN);

            Assert.AreEqual(expected, result);
        }
    }
}
