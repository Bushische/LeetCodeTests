using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using static LeetCodeTests.Medium.Problem_0128;

namespace LeetCodeTests.Medium
{
    [TestFixture]
    public class Problem_0128Tests
    {
        public static IEnumerable<object[]> TestDataArray =>
            [ // array, expected result
                [new int[] { 100, 4, 200, 1, 3, 2 }, 4],
                [new int[] { 0, 3, 7, 2, 5, 8, 4, 6, 0, 1 }, 9],
                [new int[] { 1, 0, 1, 2 }, 3],
                // edge case
                [new int[] { }, 0],
                // wrong answer
                [new int[] { 0 }, 1],
                // Time limit for a very long massive
                // wrong answer for SET:
                [new int[] { 0, 1, 2, 4, 8, 5, 6, 7, 9, 3, 55, 88, 77, 99, 999999999 }, 10],
                // wrong answer
                [new int[] { 9, 1, 4, 7, 3, -1, 0, 5, 8, -1, 6 }, 7],
            ];

        [TestCaseSource(nameof(TestDataArray))]
        public void searchInsert_VariousCases(int[] nums, int expected)
        {
            var sol = new Solution();
            var res = sol.LongestConsecutive(nums);

            Assert.AreEqual(expected, res);
        }
    }
}
