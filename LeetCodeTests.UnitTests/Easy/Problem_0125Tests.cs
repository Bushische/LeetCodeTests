using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using static LeetCodeTests.Easy.Problem_0125;

namespace LeetCodeTests.Easy
{
    [TestFixture]
    public class Problem_125Tests
    {
        [TestCase("A man, a plan, a canal: Panama", true)]
        [TestCase("race a car", false)]
        [TestCase(" ", true)]
        public void searchInsert_VariousCases(string text, bool expected)
        {
            var sol = new Solution();
            var res = sol.IsPalindrome(text);
            Assert.AreEqual(expected, res);
        }
    }
}
