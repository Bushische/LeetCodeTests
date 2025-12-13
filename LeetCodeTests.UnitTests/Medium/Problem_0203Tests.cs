using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using static LeetCodeTests.Medium.Problem_0203;

namespace LeetCodeTests.Medium
{
    [TestFixture]
    public class Problem_0203Tests
    {
        public static IEnumerable<object[]> TestDataArray =>
            [
                [new List<int> { 1, 2, 6, 3, 4, 5, 6 }, 6, new List<int> { 1, 2, 3, 4, 5 }, "1"],
                [new List<int> { }, 1, new List<int> { }, "2"],
                [new List<int> { 7, 7, 7, 7 }, 7, new List<int> { }, "3"],
                // extra
                [new List<int> { 1, 1, 1, 2, 3 }, 1, new List<int> { 2, 3 }, "4"],
            ];

        [TestCaseSource(nameof(TestDataArray))]
        public void test_VariousCases(List<int> nums, int val, List<int> expected, string key)
        {
            var numList = ListNode.CreateFromTheList(nums);
            var expectedList = ListNode.CreateFromTheList(expected);

            var sol = new Solution();
            var result = sol.RemoveElements(numList, val);

            Assert.IsTrue(ListNode.AreEqualTo(result, expectedList));
        }
    }
}
