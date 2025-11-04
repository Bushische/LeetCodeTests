using System;
using System.Collections.Generic;
using NUnit.Framework;
using static LeetCodeTests.Medium.Problem_0093;

namespace LeetCodeTests.Medium
{
    [TestFixture]
    public class Problem_0093Tests
    {
        public static IEnumerable<object[]> TestDataArrays =>
            [
                ["0000", new string[] { "0.0.0.0" }],
                ["25525511135", new string[] { "255.255.11.135", "255.255.111.35" }],
                [
                    "101023",
                    new string[]
                    {
                        "1.0.10.23",
                        "1.0.102.3",
                        "10.1.0.23",
                        "10.10.2.3",
                        "101.0.2.3",
                    },
                ],
            ];

        [TestCaseSource(nameof(TestDataArrays))]
        public void minPathSum_VariousCases(string input, string[] expected)
        {
            var calc = new Solution();
            var result = calc.RestoreIpAddresses(input);
            Assert.AreEqual(expected, result);
        }
    }
}
