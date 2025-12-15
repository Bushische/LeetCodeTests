using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using static LeetCodeTests.Medium.Problem_0207;

namespace LeetCodeTests.Medium
{
    [TestFixture]
    public class Problem_0207Tests
    {
        public static IEnumerable<object[]> TestDataArray =>
            [
                [2, new int[][] { [1, 0] }, true],
                [2, new int[][] { [1, 0], [0, 1] }, false],
                // extra
                [2, new int[][] { [0, 1] }, true],
                [4, new int[][] { [0, 1], [1, 2], [2, 0] }, false],
                [4, new int[][] { [0, 1], [0, 2], [1, 3], [2, 3] }, true],
            ];

        [TestCaseSource(nameof(TestDataArray))]
        public void test_VariousCases(int numCourses, int[][] prerequisites, bool expected)
        {
            var sol = new Solution();
            var result = sol.CanFinish(numCourses, prerequisites);

            Assert.AreEqual(expected, result);
        }
    }
}
