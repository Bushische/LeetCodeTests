using System.Runtime.Intrinsics.Arm;
using NUnit.Framework;

namespace LeetCodeTests.Hard
{
    [TestFixture]
    public class Problem_0087Tests
    {
        [TestCase("rgeat", "great", true)] //true
        [TestCase("rgtae", "great", true)]
        [TestCase("rtgae", "great", false)]
        [TestCase("dcba", "abcd", true)]
        [TestCase("dabc", "abcd", true)]
        [TestCase("abc", "bac", true)]
        [TestCase("great", "great", true)]
        [TestCase("a", "ab", false)]
        [TestCase("", "", true)]
        [TestCase("a", "a", true)]
        [TestCase("a", "b", false)]
        public void IsScramble_VariousCases(string s1, string s2, bool expected)
        {
            var sol = new Problem_0087.Solution();
            bool actual = sol.IsScramble(s1, s2);
            Assert.AreEqual(
                expected,
                actual,
                $"IsScramble(\"{s1}\", \"{s2}\") should be {expected}"
            );
        }

        [Test]
        public void IsScramble_VariousCases2()
        {
            string s1 = "rgeat";
            string s2 = "great";
            bool expected = true;
            var sol = new Problem_0087.Solution();
            bool actual = sol.IsScramble(s1, s2);
            Assert.AreEqual(
                expected,
                actual,
                $"IsScramble(\"{s1}\", \"{s2}\") should be {expected}"
            );
        }
    }
}
