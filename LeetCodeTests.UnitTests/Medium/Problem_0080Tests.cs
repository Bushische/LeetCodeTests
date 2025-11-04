using System;
using System.Collections.Generic;
using NUnit.Framework;
using static LeetCodeTests.Medium.Problem_0080;

namespace LeetCodeTests.Medium
{
    [TestFixture]
    public class Problem_0080Tests
    {
        public static IEnumerable<object[]> TestDataArrays =>
            new[]
            {
                new object[] { new int[] { 1, 1, 1, 2, 2, 3 }, 5 },
                new object[] { new int[] { 0, 0, 1, 1, 1, 1, 2, 3, 3 }, 7 },
                // edge case
                new object[] { new int[] { 1 }, 1 },
                new object[] { new int[] { 1, 2, 3 }, 3 },
                new object[] { new int[] { }, 0 },
            };

        [TestCaseSource(nameof(TestDataArrays))]
        public void minPathSum_VariousCases(int[] array, int expected)
        {
            var calc = new Solution();
            var result = calc.RemoveDuplicates(array);
            Assert.AreEqual(expected, result);
        }
    }
}
