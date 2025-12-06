using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using static LeetCodeTests.Medium.Problem_0166;

namespace LeetCodeTests.Medium
{
    [TestFixture]
    public class Problem_0166Tests
    {
        public static IEnumerable<object[]> TestDataArray =>
            [
                [1, 2, "0.5"],
                [2, 1, "2"],
                [4, 333, "0.(012)"],
                // extra cases
                [1, 3, "0.(3)"],
                [2, 13, "0.(153846)"],
                [1, 13, "0.(076923)"],
                // wrong
                [-50, 8, "-6.25"],
                // wrong
                [-1, -2147483648, "0.0000000004656612873077392578125"],
            ];

        [TestCaseSource(nameof(TestDataArray))]
        public void test_VariousCases(int numerator, int denominator, string expected)
        {
            var sol = new Solution();
            var res = sol.FractionToDecimal(numerator, denominator);

            Assert.AreEqual(expected, res);
        }
    }
}
