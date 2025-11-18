using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using static LeetCodeTests.Medium.Problem_2707;

namespace LeetCodeTests.Medium
{
    [TestFixture]
    public class Problem_2707Tests
    {
        public static IEnumerable<object[]> TestDataArray =>
            [
                [ // option 1
                    "leetscode",
                    new string[] { "leet", "code", "leetcode" },
                    1,
                ],
                [ // option 2
                    "sayhelloworld",
                    new string[] { "hello", "world" },
                    3,
                ],
            ];

        [TestCaseSource(nameof(TestDataArray))]
        public void test_VariousCases(string s, string[] dict, int expected)
        {
            var sol = new Solution();
            var index = sol.MinExtraChar(s, dict);

            Assert.AreEqual(expected, index);
        }
    }
}
