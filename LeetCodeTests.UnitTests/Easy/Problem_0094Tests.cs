using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using static LeetCodeTests.Easy.Problem_0094;

namespace LeetCodeTests.Easy
{
    [TestFixture]
    public class Problem_94Tests
    {
        public static IEnumerable<object[]> TestDataArray =>
            [
                [new int?[] { 1, null, 2, 3 }, new int[] { 1, 3, 2 }],
                [
                    new int?[] { 1, 2, 3, 4, 5, null, 8, null, null, 6, 7, 9 },
                    new int[] { 4, 2, 6, 5, 7, 1, 3, 9, 8 },
                ],
                // edge case: left nodes only
                [new int?[] { 1, 2, null, 3, null, 4, null }, new int[] { 4, 3, 2, 1 }],
                // edge case: right nodes only
                [new int?[] { 1, null, 2, null, 3, null, 4 }, new int[] { 1, 2, 3, 4 }],
            ];

        private TreeNode ConvertArrayToTree(int?[] treeNodes)
        {
            // input array contains data by levels
            // we need to use stack to correctly build the result
            if (treeNodes == null)
                return null;

            TreeNode head;
            var nodesQueue = new Queue<TreeNode>(); // here we keep all created nodes

            // head
            var headValue = treeNodes[0];
            if (headValue == null)
                return null;
            head = new TreeNode(headValue.Value);
            nodesQueue.Enqueue(head);

            // subnodes
            var inputIndex = 1;
            while (inputIndex < treeNodes.Length)
            {
                var curNode = nodesQueue.Dequeue();

                var leftVal = treeNodes[inputIndex];
                inputIndex++;
                int? rightVal = null;
                if (inputIndex < treeNodes.Length)
                {
                    rightVal = treeNodes[inputIndex];
                    inputIndex++;
                }

                if (leftVal.HasValue)
                {
                    var newNode = new TreeNode(leftVal.Value);
                    nodesQueue.Enqueue(newNode);
                    curNode.left = newNode;
                }
                if (rightVal.HasValue)
                {
                    var newNode = new TreeNode(rightVal.Value);
                    nodesQueue.Enqueue(newNode);
                    curNode.right = newNode;
                }
            }

            return head;
        }

        [TestCaseSource(nameof(TestDataArray))]
        public void searchInsert_VariousCases(int?[] treeNodes, int[] expected)
        {
            var tree = ConvertArrayToTree(treeNodes);

            var sol = new Solution();
            var res = sol.InorderTraversal(tree).ToArray();
            Assert.AreEqual(expected, res);
        }
    }
}
