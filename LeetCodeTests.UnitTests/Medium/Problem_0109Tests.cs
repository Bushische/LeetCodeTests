using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using static LeetCodeTests.Medium.Problem_0109;

namespace LeetCodeTests.Medium
{
    [TestFixture]
    public class Problem_0109Tests
    {
        public static IEnumerable<object[]> TestDataArray =>
            [
                [new List<int> { -10, -3, 0, 5, 9 }, new int?[] { 0, -3, 9, -10, null, 5 }],
                [
                    new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 },
                    new int?[] { 6, 3, 9, 2, 5, 8, 10, 1, null, 4, null, 7 },
                ],
                // edge case
                [new List<int> { }, new int?[] { }],
            ];

        [TestCaseSource(nameof(TestDataArray))]
        public void isValidBST_VariousCases(List<int> listHead, int?[] treeNodes)
        {
            var list = ListNode.CreateFromTheList(listHead);
            var tree = TreeNode.ConvertArrayToTree(treeNodes);

            var sol = new Solution();
            var res = sol.SortedListToBST(list);
            Assert.IsTrue(tree?.CompareToTree(res) ?? (res is null));
        }
    }
}
