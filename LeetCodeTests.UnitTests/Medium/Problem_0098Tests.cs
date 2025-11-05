using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using static LeetCodeTests.Medium.Problem_0098;

namespace LeetCodeTests.Medium
{
    [TestFixture]
    public class Problem_0098Tests
    {
        public static IEnumerable<object[]> TestDataArray =>
            [
                [new int?[] { 2, 1, 3 }, true],
                [new int?[] { 5, 1, 4, null, null, 3, 6 }, false],
                // edge case: left nodes only
                [new int?[] { 1, 2, null, 3, null, 4, null }, false],
                // edge case: right nodes only
                [new int?[] { 1, null, 2, null, 3, null, 4 }, true],
                // from check, wrong cases
                [new int?[] { 2147483647 }, true],
                [new int?[] { -2147483648 }, true],
                // one more error:
                [new int?[] { -2147483648, null, 2147483647 }, true],
            ];

        [TestCaseSource(nameof(TestDataArray))]
        public void isValidBST_VariousCases(int?[] treeNodes, bool expected)
        {
            var tree = TreeNode.ConvertArrayToTree(treeNodes);

            var sol = new Solution();
            var res = sol.IsValidBST(tree);
            Assert.AreEqual(expected, res);
        }
    }
}
