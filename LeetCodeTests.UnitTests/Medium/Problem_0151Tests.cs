using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using static LeetCodeTests.Medium.Problem_0151;

namespace LeetCodeTests.Medium
{
    [TestFixture]
    public class Problem_0151Tests
    {
        public static IEnumerable<object[]> TestDataArray =>
            [
                ["the sky is blue", "blue is sky the"],
                ["  hello world  ", "world hello"],
                ["a good   example", "example good a"],
            ];

        [TestCaseSource(nameof(TestDataArray))]
        public void test_VariousCases(string inputString, string expected)
        {
            var sol = new Solution();
            var res = sol.ReverseWords(inputString);

            Assert.AreEqual(expected, res);
        }
    }
}
