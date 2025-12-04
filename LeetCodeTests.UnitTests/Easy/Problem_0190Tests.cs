using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using static LeetCodeTests.Easy.Problem_0190;

namespace LeetCodeTests.Easy
{
    [TestFixture]
    public class Problem_0190Tests
    {
        public static IEnumerable<object[]> TestDataArray =>
            [
                [43261596, 964176192],
                [2147483644, 1073741822],
                // wrong
                [2, 1073741824],
            ];

        [TestCaseSource(nameof(TestDataArray))]
        public void test_VariousCases(int number, int expected)
        {
            var sol = new Solution();
            var res = sol.ReverseBits(number);

            Assert.AreEqual(expected, res);
        }
    }
}
