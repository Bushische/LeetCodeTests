using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using static LeetCodeTests.Medium.Problem_0114;

namespace LeetCodeTests.Medium
{
    [TestFixture]
    public class Problem_0114Tests
    {
        public static IEnumerable<object[]> TestDataArray =>
            [
                [
                    new int?[] { 1, 2, 5, 3, 4, null, 6 },
                    new int?[] { 1, null, 2, null, 3, null, 4, null, 5, null, 6 },
                ],
                [new int?[] { }, new int?[] { }],
                [new int?[] { 0 }, new int?[] { 0 }],
            ];

        [TestCaseSource(nameof(TestDataArray))]
        public void tests_VariousCases(int?[] treeNodes, int?[] expectedNodes)
        {
            var tree = TreeNode.ConvertArrayToTree(treeNodes);
            var expectedTree = TreeNode.ConvertArrayToTree(expectedNodes);

            var sol = new Solution();
            sol.Flatten(tree);

            Assert.IsTrue(expectedTree?.CompareToTree(tree) ?? true);
        }


        [TestCaseSource(nameof(TestDataArray))]
        public void testsO1_VariousCases(int?[] treeNodes, int?[] expectedNodes)
        {
            var tree = TreeNode.ConvertArrayToTree(treeNodes);
            var expectedTree = TreeNode.ConvertArrayToTree(expectedNodes);

            var sol = new Solution();
            sol.FlattenWithO1(tree);

            Assert.IsTrue(expectedTree?.CompareToTree(tree) ?? true);
        }
    }
}
