using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using static LeetCodeTests.Medium.Problem_0150;

namespace LeetCodeTests.Medium
{
    [TestFixture]
    public class Problem_0150Tests
    {
        public static IEnumerable<object[]> TestDataArray =>
            [
                [new string[] { "2", "1", "+", "3", "*" }, 9],
                [new string[] { "4", "13", "5", "/", "+" }, 6],
                [
                    new string[]
                    {
                        "10",
                        "6",
                        "9",
                        "3",
                        "+",
                        "-11",
                        "*",
                        "/",
                        "*",
                        "17",
                        "+",
                        "5",
                        "+",
                    },
                    22,
                ],
            ];

        [TestCaseSource(nameof(TestDataArray))]
        public void test_VariousCases(string[] tokens, int expected)
        {
            var sol = new Solution();
            var res = sol.EvalRPN(tokens);

            Assert.AreEqual(expected, res);
        }
    }
}
