using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using static LeetCodeTests.Medium.Problem_0113;

namespace LeetCodeTests.Medium
{
    [TestFixture]
    public class Problem_0113Tests
    {
        public static IEnumerable<object[]> TestDataArray =>
            [
                [
                    new int?[] { 5, 4, 8, 11, null, 13, 4, 7, 2, null, null, 5, 1 },
                    22,
                    new int[][] { [5, 4, 11, 2], [5, 8, 4, 5] },
                ],
                [new int?[] { 1, 2, 3 }, 5, new int[][] { }],
                [new int?[] { 1, 2 }, 0, new int[][] { }],
                // additional cases
                [
                    new int?[] { 1, 2, 3, 1, 1, 0 },
                    4,
                    new int[][] { [1, 2, 1], [1, 2, 1], [1, 3, 0] },
                ],
            ];

        [TestCaseSource(nameof(TestDataArray))]
        public void searchInsert_VariousCases(
            int?[] treeNodes,
            int targetSum,
            IList<IList<int>> expectedResult
        )
        {
            var tree = TreeNode.ConvertArrayToTree(treeNodes);

            var sol = new Solution();
            var res = sol.PathSum(tree, targetSum);

            var convertedExpected = convert(expectedResult);
            var convertedResult = convert(res);

            Assert.AreEqual(convertedExpected, convertedResult);
        }

        /// <summary>
        /// Convert to the same format
        /// </summary>
        /// <param name="inList"></param>
        /// <returns></returns>
        private IList<IList<int>> convert(IList<IList<int>> inList)
        {
            var result = new List<IList<int>>();
            foreach (var list in inList)
            {
                result.Add(new List<int>(list));
            }
            return result;
        }
    }
}
