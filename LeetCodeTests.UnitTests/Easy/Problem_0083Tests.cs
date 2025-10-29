using System;
using System.Collections.Generic;
using NUnit.Framework;
using static LeetCodeTests.Easy.Problem_83;

namespace LeetCodeTests.Easy
{
    [TestFixture]
    public class Problem_83Tests
    {
        public static IEnumerable<object[]> TestDataArrays =>
        [
            new object[] { new List<int> {1, 1, 2}, new List<int> { 1, 2 }},
            [new List<int> {1,1,2,3,3}, new List<int> { 1, 2, 3 }],
            [new List<int> {1}, new List<int> { 1}],
            [new List<int> {1,1,1,1,1,1,1,1,1}, new List<int> { 1}],
            [new List<int> { }, new List<int> { }]
        ];
            
        [TestCaseSource(nameof(TestDataArrays))]
        public void deleteDuplicates_VariousCases(List<int> inList, List<int> expectedList)
        {
            var calc = new Solution();
            var result = calc.DeleteDuplicates(ListNode.CreateFromTheList(inList));
            var expected = ListNode.CreateFromTheList(expectedList);
            // Assert.AreEqual(result, expectedList);
            Assert.IsTrue(ListNode.AreEqualTo(result, expected));
        }
    }
}