using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using static LeetCodeTests.Medium.Problem_0200;

namespace LeetCodeTests.Medium
{
    [TestFixture]
    public class Problem_0200Tests
    {
        public static IEnumerable<object[]> TestDataArray =>
            [
                [ // option 1
                    new char[][]
                    {
                        ['1', '1', '1', '1', '0'],
                        ['1', '1', '0', '1', '0'],
                        ['1', '1', '0', '0', '0'],
                        ['0', '0', '0', '0', '0'],
                    },
                    1,
                    "option 1",
                ],
                [ // option 2
                    new char[][]
                    {
                        ['1', '1', '0', '0', '0'],
                        ['1', '1', '0', '0', '0'],
                        ['0', '0', '1', '0', '0'],
                        ['0', '0', '0', '1', '1'],
                    },
                    3,
                    "option 2",
                ],
                // Time exceeded => let's replace elements we found
                // and don't use collection foundLand
            ];

        [TestCaseSource(nameof(TestDataArray))]
        public void test_VariousCases(char[][] array, int expected, string key)
        {
            var sol = new Solution();
            var result = sol.NumIslands(array); // update array

            Assert.AreEqual(expected, result);
        }
    }
}
