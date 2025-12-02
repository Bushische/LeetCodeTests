using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using static LeetCodeTests.Medium.Problem_0165;

namespace LeetCodeTests.Medium
{
    [TestFixture]
    public class Problem_0165Tests
    {
        public static IEnumerable<object[]> TestDataArray =>
            [
                ["1.2", "1.10", -1],
                ["1.01", "1.001", 0],
                ["1.0", "1.0.0.0", 0],
                //extra
                ["1.00010", "1.2", 1],
            ];

        [TestCaseSource(nameof(TestDataArray))]
        public void test_VariousCases(string version1, string version2, int expected)
        {
            var sol = new Solution();
            var result = sol.CompareVersion(version1, version2);
            Assert.AreEqual(expected, result);
        }
    }
}
