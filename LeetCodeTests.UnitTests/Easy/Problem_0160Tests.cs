using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using static LeetCodeTests.Easy.Problem_0160;

namespace LeetCodeTests.Easy
{
    [TestFixture]
    public class Problem_160Tests
    {
        public static IEnumerable<object[]> TestDataArray =>
            [
                [
                    new List<int> { 4, 1, 8, 4, 5 }, // listA
                    new List<int> { 5, 6, 1, 8, 4, 5 }, // listB
                    2, // skipA
                    3, // skipB
                    8, // expected
                ],
                [
                    new List<int> { 1, 9, 1, 2, 4 }, // listA
                    new List<int> { 3, 2, 4 }, // listB
                    3, // skipA
                    1, // skipB
                    2, // expected
                ],
                [
                    new List<int> { 2, 6, 4 }, // listA
                    new List<int> { 1, 5 }, // listB
                    3, // skipA
                    2, // skipB
                    0, // expected  // NO INTERSECTION
                ],
            ];

        [TestCaseSource(nameof(TestDataArray))]
        public void test_VariousCases(
            List<int> listNodesA,
            List<int> listNodesB,
            int skipA,
            int skipB,
            int expected
        )
        {
            var listA = ListNode.CreateFromTheList(listNodesA);
            var listB = ListNode.CreateFromTheList(listNodesB);

            var restA = listA;
            var skip = skipA - 1;
            while (skip > 0)
            {
                restA = restA.next;
                skip--;
            }

            var restB = listB;
            skip = skipB - 1;
            while (skip > 0)
            {
                restB = restB.next;
                skip--;
            }

            // assign the end of A to B
            restB.next = restA.next;

            var sol = new Solution();
            var res = sol.GetIntersectionNode(listA, listB);
            Assert.AreEqual(expected, res?.val ?? 0);
        }
    }
}
