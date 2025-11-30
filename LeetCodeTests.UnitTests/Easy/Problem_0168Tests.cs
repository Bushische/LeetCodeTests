using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using static LeetCodeTests.Easy.Problem_0168;

namespace LeetCodeTests.Easy
{
    [TestFixture]
    public class Problem_168Tests
    {
        public static IEnumerable<object[]> TestDataArray =>
            [
                [1, "A"],
                [2, "B"],
                [26, "Z"],
                [27, "AA"],
                [28, "AB"],
                [52, "AZ"],
                [53, "BA"],
            ];

        [TestCaseSource(nameof(TestDataArray))]
        public void test_VariousCases(int columnNumber, string expected)
        {
            var sol = new Solution();
            var res = sol.ConvertToTitle(columnNumber);
            Assert.AreEqual(expected, res);
        }
    }
}
