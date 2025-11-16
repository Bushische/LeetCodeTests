using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using static LeetCodeTests.Medium.Problem_0134;

namespace LeetCodeTests.Medium
{
    [TestFixture]
    public class Problem_0134Tests
    {
        public static IEnumerable<object[]> TestDataArray =>
            [ // gas = [1,2,3,4,5], cost = [3,4,5,1,2], true = 3
                [ // option 1
                    new int[] { 1, 2, 3, 4, 5 },
                    new int[] { 3, 4, 5, 1, 2 },
                    3, // diff: -2, -2, -2, 3!, 3 => sum(0, i): -2, -4, -6, -3!, 0
                ],
                //gas = [2,3,4], cost = [3,4,3]
                [ // option 2
                    new int[] { 2, 3, 4 },
                    new int[] { 3, 4, 3 },
                    -1, // -1, -1, -1
                ],
                //-2, -1, 0, -1, 3, 6
                [ // option 3
                    new int[] { 2, 3, 4, 5, 6, 9 },
                    new int[] { 4, 4, 4, 6, 3, 3 },
                    4, // -2, -1, 0, -1, 3!, 6 => -2, -3, -3, -4, -1!, 5
                ],
                // wrong gas = [5,1,2,3,4] cost = [4,4,1,5,1] expected 4
                [ // option 4
                    new int[] { 5, 1, 2, 3, 4 },
                    new int[] { 4, 4, 1, 5, 1 },
                    4, // 1, -3, 1, -2, 3! => 1, -2, -1, -3, 0!
                ],
                // wrong gas = [3,1,1] cost =[1,2,2] expected 0
                [ // option 5
                    new int[] { 3, 1, 1 },
                    new int[] { 1, 2, 2 },
                    0, // 2!, -1, -1 => 2!, 1, 0
                ],
                // wrong gas = [6,1,4,3,5] cost = [3,8,2,4,2] expected 2
                [ // option 6
                    new int[] { 6, 1, 4, 3, 5 },
                    new int[] { 3, 8, 2, 4, 2 },
                    2, // 3, -7, !2, -1, 3 => 3, -4, !-2, -3, 0
                    // => by diff array (in cost) sum from right to left while sum >= 0
                ],
            ];

        [TestCaseSource(nameof(TestDataArray))]
        public void searchInsert_VariousCases(int[] gas, int[] cost, int expected)
        {
            var sol = new Solution();
            var index = sol.CanCompleteCircuit(gas, cost);

            Assert.AreEqual(expected, index);
        }
    }
}
