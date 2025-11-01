using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using static LeetCodeTests.Easy.Problem_0035;

namespace LeetCodeTests.Easy
{
    [TestFixture]
    public class EmptyTests
    {
        public static IEnumerable<object[]> TestDataArray =>
            [
                [new int[] { 1, 3, 5, 6 }, 5, 2],
                [new int[] { 1, 3, 5, 6 }, 2, 1],
                [new int[] { 1, 3, 5, 6 }, 7, 4],
                [new int[] { 1, 3, 5, 6 }, 1, 0], // left border
                [new int[] { 1, 3, 5, 6 }, 6, 3], // right border
                [new int[] { 1 }, 2, 1],
                [new int[] { }, 1, 0],
            ];

        [TestCaseSource(nameof(TestDataArray))]
        public void searchInsert_VariousCases(int[] nums, int target, int expectedIndex)
        {
            var sol = new Solution();
            var res = sol.SearchInsert(nums, target);
            Assert.AreEqual(expectedIndex, res);
        }
    }
}
