using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using static LeetCodeTests.Medium.Problem_0201;

namespace LeetCodeTests.Medium
{
    [TestFixture]
    public class Problem_0201Tests
    {
        public static IEnumerable<object[]> TestDataArray =>
            [
                [5, 7, 4],
                [0, 0, 0],
                [1, 2147483647, 0],
                // wrong answer
                [2147483646, 2147483647, 2147483646],
                // time out
                [1073741824, 2147483647, 1073741824],
            ];

        [TestCaseSource(nameof(TestDataArray))]
        public void test_VariousCases(int left, int right, int expected)
        {
            var sol = new Solution();
            var result = sol.RangeBitwiseAnd(left, right);

            Assert.AreEqual(expected, result);
        }
    }
}
