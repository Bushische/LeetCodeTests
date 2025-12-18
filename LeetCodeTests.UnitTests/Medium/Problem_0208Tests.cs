using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using static LeetCodeTests.Medium.Problem_0208;

namespace LeetCodeTests.Medium
{
    [TestFixture]
    public class Problem_0208Tests
    {
        public static IEnumerable<object[]> TestDataArray =>
            [
                [
                    new string[]
                    {
                        "Trie",
                        "insert",
                        "search",
                        "search",
                        "startWith",
                        "insert",
                        "search",
                    },
                    new string[][] { [], ["apple"], ["apple"], ["app"], ["app"], ["app"], ["app"] },
                    new bool?[] { null, null, true, false, true, null, true },
                ],
            ];

        [TestCaseSource(nameof(TestDataArray))]
        public void test_VariousCases(string[] commands, string[][] arguments, bool?[] expected)
        {
            Trie trie = null;
            for (int i = 0; i < commands.Length; i++)
            {
                var command = commands[i];
                var arg = arguments[i];
                var expectedResult = expected[i];
                var result = false;
                switch (command)
                {
                    case "Trie":
                        trie = new Trie();
                        break;
                    case "insert":
                        trie.Insert(arg[0]);
                        break;
                    case "search":
                        result = trie.Search(arg[0]);
                        Assert.AreEqual(expectedResult, result);
                        break;
                    case "startWith":
                        result = trie.StartsWith(arg[0]);
                        Assert.AreEqual(expectedResult, result);
                        break;
                    case "":
                        Assert.Fail("unknown command");
                        break;
                }
            }
        }
    }
}
