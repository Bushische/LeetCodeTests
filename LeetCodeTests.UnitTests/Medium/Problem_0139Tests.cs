using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using static LeetCodeTests.Medium.Problem_0139;

namespace LeetCodeTests.Medium
{
    [TestFixture]
    public class Problem_0139Tests
    {
        public static IEnumerable<object[]> TestDataArray =>
            [
                [ // option 1
                    "leetcode",
                    new string[] { "leet", "code" },
                    true,
                ],
                [ // option 2
                    "applepenapple",
                    new string[] { "apple", "pen" },
                    true,
                ],
                [ // option 3
                    "catsandog",
                    new string[] { "cats", "dog", "sand", "and", "cat" },
                    false,
                ],
                // additional cases
                [ // option 4
                    "abcdefgh",
                    new string[] { "a", "ab", "abc", "abcd", "e", "ef", "efg", "h" },
                    true,
                ],
                // time limit
                [ // option 5
                    "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaab",
                    new string[]
                    {
                        "a",
                        "aa",
                        "aaa",
                        "aaaa",
                        "aaaaa",
                        "aaaaaa",
                        "aaaaaaa",
                        "aaaaaaaa",
                        "aaaaaaaaa",
                        "aaaaaaaaaa",
                    },
                    false,
                ],
                // wrong answer
                [ // option 6
                    "bb",
                    new string[] { "a", "b", "bbb", "bbbb" },
                    true,
                ],
                // time limit
                [ // option 7 // there is impossible combination ba|A|ba
                    "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaabaabaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
                    new string[]
                    {
                        "aa",
                        "aaa",
                        "aaaa",
                        "aaaaa",
                        "aaaaaa",
                        "aaaaaaa",
                        "aaaaaaaa",
                        "aaaaaaaaa",
                        "aaaaaaaaaa",
                        "ba",
                    },
                    false,
                ],
            ];

        [TestCaseSource(nameof(TestDataArray))]
        public void searchInsert_VariousCases(string s, string[] dict, bool expected)
        {
            var sol = new Solution();
            var index = sol.WordBreak(s, dict);

            Assert.AreEqual(expected, index);
        }
    }
}
