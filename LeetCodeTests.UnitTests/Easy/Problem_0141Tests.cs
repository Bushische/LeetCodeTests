using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using static LeetCodeTests.Easy.Problem_0141;

namespace LeetCodeTests.Easy
{
    [TestFixture]
    public class Problem_141Tests
    {
        public static IEnumerable<object[]> TestDataArray =>
            [
                [new List<int> { 3, 2, 0, -4 }, 1, true],
                [new List<int> { 1, 2 }, 0, true],
                [new List<int> { 1 }, -1, false],
            ];

        [TestCaseSource(nameof(TestDataArray))]
        public void test_VariousCases(List<int> listNodes, int tailNextIndex, bool expected)
        {
            var list = ListNode.CreateFromTheList(listNodes);
            if ((tailNextIndex >= 0) && (tailNextIndex <= listNodes.Count)) // create cycle
            {
                var tailNext = list;
                while (tailNextIndex > 0)
                {
                    tailNext = tailNext.next;
                    tailNextIndex--;
                }
                var listTail = list;
                while (listTail?.next != null)
                {
                    listTail = listTail.next;
                }

                listTail.next = tailNext;
            }

            var sol = new Solution();
            var res = sol.HasCycle(list);
            Assert.AreEqual(expected, res);
        }
    }
}
