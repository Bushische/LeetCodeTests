using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using static LeetCodeTests.Medium.Problem_0172;

namespace LeetCodeTests.Medium
{
    [TestFixture]
    public class Problem_0172Tests
    {
        public static IEnumerable<object[]> TestDataArray =>
            [
                [0, 0],
                [1, 0],
                [2, 0],
                [5, 1],
                [10, 2],
                [11, 2],
                // wrong
                [30, 7], // because 25*4 gives 100 - two zeros
                //1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30
                //2*5->1,10->1,4*15->1,20->1,25*8->2,30->1
                // wrong
                [200, 49],
                // wrong
                [625, 156],
            ];

        [TestCaseSource(nameof(TestDataArray))]
        public void test_VariousCases(int input, int expected)
        {
            var sol = new Solution();
            var res = sol.TrailingZeroes(input);

            Assert.AreEqual(expected, res);
        }
    }
}
