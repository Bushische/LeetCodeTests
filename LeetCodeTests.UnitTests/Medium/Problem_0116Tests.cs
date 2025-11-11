using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using static LeetCodeTests.Medium.Problem_0116;

namespace LeetCodeTests.Medium
{
    [TestFixture]
    public class Problem_0116Tests
    {
        public static IEnumerable<object[]> TestDataArray =>
            [
                [new int?[] { 1, 2, 3, 4, 5, 6, 7 }, "1,#,2,3,#,4,5,6,7,#"],
                [new int?[] { }, ""],
                [new int?[] { 1, 2, 3 }, "1,#,2,3,#"],
            ];

        [TestCaseSource(nameof(TestDataArray))]
        public void test_VariousCases(int?[] arrayNodes, string expectedNodesAsString)
        {
            var treeNodes = TreeNode.ConvertArrayToTree(arrayNodes);
            var nodes = Node.ConvertFromTreeNode(treeNodes);

            var sol = new Solution();
            var res = sol.Connect(nodes);
            ;

            var convertedResult = res?.PrintTree() ?? "";

            Assert.AreEqual(expectedNodesAsString, convertedResult);
        }
    }
}
