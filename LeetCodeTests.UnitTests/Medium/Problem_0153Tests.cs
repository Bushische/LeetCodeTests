using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using static LeetCodeTests.Medium.Problem_0153;

namespace LeetCodeTests.Medium
{
    [TestFixture]
    public class Problem_0153Tests
    {
        public static IEnumerable<object[]> TestDataArray =>
            [
                [new int[] { 3, 4, 5, 1, 2 }, 1], // min right half
                [new int[] { 4, 5, 6, 7, 0, 1, 2 }, 0], // min right half
                [new int[] { 11, 13, 15, 17 }, 11], // min left
                // extra
                [new int[] { 8, 1, 2, 3, 4, 5, 6, 7 }, 1], // min left half
                [new int[] { 2, 3, 4, 5, 6, 7, 8, 1 }, 1], // min left half
                // wrong
                [new int[] { 1 }, 1],
            ];

        [TestCaseSource(nameof(TestDataArray))]
        public void test_VariousCases(int[] nums, int expected)
        {
            var sol = new Solution();
            var res = sol.FindMin(nums);

            Assert.AreEqual(expected, res);
        }
    }
}
