using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using static LeetCodeTests.Easy.Problem_0144;

namespace LeetCodeTests.Easy
{
    [TestFixture]
    public class Problem_144Tests
    {
        public static IEnumerable<object[]> TestDataArray =>
            [
                [new int?[] { 1, null, 2, 3 }, new int[] { 1, 2, 3 }],
                [
                    new int?[] { 1, 2, 3, 4, 5, null, 8, null, null, 6, 7, 9 },
                    new int[] { 1, 2, 4, 5, 6, 7, 3, 8, 9 },
                ],
                [new int?[] { }, new int[] { }],
                // edge case: left nodes only
                [new int?[] { 1, 2, null, 3, null, 4, null }, new int[] { 1, 2, 3, 4 }],
                // edge case: right nodes only
                [new int?[] { 1, null, 2, null, 3, null, 4 }, new int[] { 1, 2, 3, 4 }],
            ];

        [TestCaseSource(nameof(TestDataArray))]
        public void searchInsert_VariousCases(int?[] treeNodes, int[] expected)
        {
            var tree = TreeNode.ConvertArrayToTree(treeNodes);

            var sol = new Solution();
            var res = sol.PreorderTraversal(tree).ToArray();
            Assert.AreEqual(expected, res);
        }
    }
}
