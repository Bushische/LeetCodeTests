using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using static LeetCodeTests.Medium.Problem_0147;

namespace LeetCodeTests.Medium
{
    [TestFixture]
    public class Problem_0147Tests
    {
        public static IEnumerable<object[]> TestDataArray =>
            [
                [new List<int> { 4, 2, 1, 3 }, new List<int> { 1, 2, 3, 4 }, 1],
                [new List<int> { -1, 5, 3, 4, 0 }, new List<int> { -1, 0, 3, 4, 5 }, 2],
                // extra cases
                [new List<int> { 1 }, new List<int> { 1 }, 3],
            ];

        [TestCaseSource(nameof(TestDataArray))]
        public void test_VariousCases(
            List<int> listNodes,
            List<int> expectedListNodes,
            int randomValue
        )
        {
            var head = ListNode.CreateFromTheList(listNodes);
            var headExpected = ListNode.CreateFromTheList(expectedListNodes);

            var sol = new Solution();
            var res = sol.InsertionSortList(head);

            Assert.IsTrue(ListNode.AreEqualTo(headExpected, res));
        }
    }
}
