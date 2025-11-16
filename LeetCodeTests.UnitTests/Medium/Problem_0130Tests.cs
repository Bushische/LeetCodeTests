using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using static LeetCodeTests.Medium.Problem_0130;

namespace LeetCodeTests.Medium
{
    [TestFixture]
    public class Problem_0130Tests
    {
        public static IEnumerable<object[]> TestDataArray =>
            [
                [ // option 1
                    new char[][]
                    {
                        ['X', 'X', 'X', 'X'],
                        ['X', 'O', 'O', 'X'],
                        ['X', 'X', 'O', 'X'],
                        ['X', 'O', 'X', 'X'],
                    },
                    new char[][]
                    {
                        ['X', 'X', 'X', 'X'],
                        ['X', 'X', 'X', 'X'],
                        ['X', 'X', 'X', 'X'],
                        ['X', 'O', 'X', 'X'],
                    },
                ],
                [new char[][] { ['X'] }, new char[][] { ['X'] }],
                [ // option 3
                    new char[][]
                    {
                        ['X', 'X', 'X', 'X', 'X'],
                        ['X', 'O', 'O', 'X', 'X'],
                        ['X', 'X', 'O', 'X', 'X'],
                        ['X', 'X', 'X', 'X', 'X'],
                        ['X', 'X', 'X', 'X', 'X'],
                    },
                    new char[][]
                    {
                        ['X', 'X', 'X', 'X', 'X'],
                        ['X', 'X', 'X', 'X', 'X'],
                        ['X', 'X', 'X', 'X', 'X'],
                        ['X', 'X', 'X', 'X', 'X'],
                        ['X', 'X', 'X', 'X', 'X'],
                    },
                ],
                [ // option 4
                    new char[][]
                    {
                        ['X', 'X', 'X', 'X', 'X'],
                        ['X', 'O', 'O', 'X', 'X'],
                        ['X', 'X', 'O', 'O', 'O'],
                        ['X', 'X', 'X', 'X', 'X'],
                        ['X', 'X', 'X', 'X', 'X'],
                        ['X', 'X', 'X', 'X', 'X'],
                    },
                    new char[][]
                    {
                        ['X', 'X', 'X', 'X', 'X'],
                        ['X', 'O', 'O', 'X', 'X'],
                        ['X', 'X', 'O', 'O', 'O'],
                        ['X', 'X', 'X', 'X', 'X'],
                        ['X', 'X', 'X', 'X', 'X'],
                        ['X', 'X', 'X', 'X', 'X'],
                    },
                ],
            ];

        [TestCaseSource(nameof(TestDataArray))]
        public void searchInsert_VariousCases(char[][] array, char[][] expected)
        {
            var sol = new Solution();
            sol.Solve(array); // update array

            Assert.AreEqual(expected, array);
        }
    }
}
