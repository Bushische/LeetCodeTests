using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using static LeetCodeTests.Easy.Problem_0112;

namespace LeetCodeTests.Easy
{
    [TestFixture]
    public class Problem_0112Tests
    {
        public static IEnumerable<object[]> TestDataArray =>
            [
                [new int?[] { 5, 4, 8, 11, null, 13, 4, 7, 2, null, null, null, 1 }, 22, true],
                [new int?[] { 1, 2, 3 }, 5, false],
                [new int?[] { }, 0, false],
                // additional cases
                [new int?[] { 5, 1, 2, null, 4, null, 4 }, 5, false], // finish not on leaf
                [new int?[] { 5, 1, 2, null, 4, null, 4 }, 10, true],
                // wrong test
                [new int?[] { 1, 2 }, 0, false],
                // wrong test
                [new int?[] { 1, 2 }, 1, false], // not a leaf
                // wrong test
                [new int?[] { 10, 2, 11, 0 }, 12, true],
                // wrong test
                [new int?[] { -2, null, -3 }, -5, true],
            ];

        [TestCaseSource(nameof(TestDataArray))]
        public void searchInsert_VariousCases(int?[] treeNodes, int targetSum, bool expectedResult)
        {
            var tree = TreeNode.ConvertArrayToTree(treeNodes);

            var sol = new Solution();
            var res = sol.HasPathSum(tree, targetSum);
            Assert.AreEqual(expectedResult, res);
        }
    }
}
