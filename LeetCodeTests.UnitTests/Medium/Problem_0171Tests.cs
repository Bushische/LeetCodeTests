using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using static LeetCodeTests.Medium.Problem_0171;

namespace LeetCodeTests.Medium
{
    [TestFixture]
    public class Problem_0171Tests
    {
        public static IEnumerable<object[]> TestDataArray =>
            [
                ["A", 1],
                ["AB", 28],
                ["ZY", 701],
                // extra
                ["B", 2],
                ["Z", 26],
            ];

        [TestCaseSource(nameof(TestDataArray))]
        public void test_VariousCases(string input, int expected)
        {
            var sol = new Solution();
            var res = sol.TitleToNumber(input);

            Assert.AreEqual(expected, res);
        }
    }
}
