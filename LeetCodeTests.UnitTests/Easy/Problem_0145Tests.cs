using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using static LeetCodeTests.Easy.Problem_0145;

namespace LeetCodeTests.Easy
{
    [TestFixture]
    public class Problem_145Tests
    {
        public static IEnumerable<object[]> TestDataArray =>
            [
                [new int?[] { 1, null, 2, 3 }, new int[] { 3, 2, 1 }],
                [
                    new int?[] { 1, 2, 3, 4, 5, null, 8, null, null, 6, 7, 9 },
                    new int[] { 4, 6, 7, 5, 2, 9, 8, 3, 1 },
                ],
                [new int?[] { }, new int[] { }],
                [new int?[] { 1 }, new int[] { 1 }],
            ];

        [TestCaseSource(nameof(TestDataArray))]
        public void searchInsert_VariousCases(int?[] treeNodes, int[] expected)
        {
            var tree = TreeNode.ConvertArrayToTree(treeNodes);

            var sol = new Solution();
            var res = sol.PostorderTraversal(tree).ToArray();
            Assert.AreEqual(expected, res);
        }
    }
}
