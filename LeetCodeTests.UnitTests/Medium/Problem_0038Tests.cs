using System;
using NUnit.Framework;
using static LeetCodeTests.Medium.Problem_0038;

namespace LeetCodeTests.Medium
{
    [TestFixture]
    public class Problem_0038Tests
    {
        [TestCase(1, "1")]
        [TestCase(2, "11")]
        [TestCase(3, "21")]
        [TestCase(4, "1211")]
        [TestCase(5, "111221")]
        public void countAndSay_VariousCases(int n, string expected)
        {
            var calc = new Solution();
            var result = calc.CountAndSay(n);
            Assert.AreEqual(expected, result);
        }

        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(46)]
        [TestCase(1000)]
        public void climbStairs_OutOfRange(int n)
        {
            var calc = new Solution();
            Assert.Throws<ArgumentOutOfRangeException>(() => calc.CountAndSay(n));
        }
    }
}
