using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using static LeetCodeTests.Easy.Problem_0205;

namespace LeetCodeTests.Easy
{
    [TestFixture]
    public class Problem_0205Tests
    {
        public static IEnumerable<object[]> TestDataArray =>
            [
                ["egg", "add", true],
                ["foo", "bar", false],
                ["paper", "title", true],
                // wrong
                ["badc", "baba", false],
            ];

        [TestCaseSource(nameof(TestDataArray))]
        public void test_VariousCases(string s, string t, bool expected)
        {
            var sol = new Solution();
            var result = sol.IsIsomorphic(s, t);

            Assert.AreEqual(expected, result);
        }
    }
}
