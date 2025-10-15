using System;
using NUnit.Framework;
using static LeetCodeTests.Easy.Problem_70;

namespace LeetCodeTests.Easy
{
    [TestFixture]
    public class Problem_70Tests
    {
        [TestCase(1, 1)]
        [TestCase(2, 2)]
        [TestCase(3, 3)]
        [TestCase(4, 5)]
        [TestCase(5, 8)]
        public void climbStairs_VariousCases(int n, int expected)
        {
            var calc = new Solution();
            var result = calc.climbStairs(n);
            Assert.AreEqual(result, expected);
        }

        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(46)]
        [TestCase(1000)]
        public void climbStairs_OutOfRange(int n)
        {
            var calc = new Solution();
            Assert.Throws<ArgumentOutOfRangeException>(() => calc.climbStairs(n));
        }
    }
}