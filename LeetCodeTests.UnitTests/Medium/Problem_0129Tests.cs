using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using static LeetCodeTests.Medium.Problem_0129;

namespace LeetCodeTests.Medium
{
    [TestFixture]
    public class Problem_0129Tests
    {
        public static IEnumerable<object[]> TestDataArray =>
            [
                [new int?[] { 1, 2, 3 }, 25],
                [new int?[] { 4, 9, 0, 5, 1 }, 1026],
                // edge case
                [new int?[] { }, 0],
            ];

        [TestCaseSource(nameof(TestDataArray))]
        public void searchInsert_VariousCases(int?[] treeAsArray, int expected)
        {
            var root = TreeNode.ConvertArrayToTree(treeAsArray);

            var sol = new Solution();
            var res = sol.SumNumbers(root);

            Assert.AreEqual(expected, res);
        }
    }
}
