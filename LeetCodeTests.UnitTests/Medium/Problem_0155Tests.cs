using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using static LeetCodeTests.Medium.Problem_0155;

namespace LeetCodeTests.Medium
{
    [TestFixture]
    public class Problem_0155Tests
    {
        public static IEnumerable<object[]> TestDataArray =>
            [
                [
                    new string[]
                    {
                        "MinStack",
                        "push",
                        "push",
                        "push",
                        "getMin",
                        "pop",
                        "top",
                        "getMin",
                    },
                    new int[][] { [], [-2], [0], [-3], [], [], [], [] },
                    new int?[] { null, null, null, null, -3, null, 0, -2 },
                ],
                // extra
                [
                    new string[]
                    {
                        "MinStack",
                        "push",
                        "push",
                        "push",
                        "push",
                        "push",
                        "top",
                        "getMin",
                        "pop",
                        "top",
                        "getMin",
                        "pop",
                        "pop",
                        "pop",
                        "top",
                        "getMin",
                    },
                    new int[][]
                    {
                        [],
                        [-2],
                        [-3],
                        [-4],
                        [-5],
                        [-6],
                        [],
                        [],
                        [],
                        [],
                        [],
                        [],
                        [],
                        [],
                        [],
                        [],
                    },
                    new int?[]
                    {
                        null,
                        null,
                        null,
                        null,
                        null,
                        null,
                        -6,
                        -6,
                        null,
                        -5,
                        -5,
                        null,
                        null,
                        null,
                        -2,
                        -2,
                    },
                ],
            ];

        [TestCaseSource(nameof(TestDataArray))]
        public void test_VariousCases(string[] commands, int[][] args, int?[] expected)
        {
            // len(commands) should be equal len(args)
            MinStack stack = null;
            int?[] result = new int?[commands.Length];

            for (int index = 0; index < commands.Length; index++)
            {
                var command = commands[index];
                switch (command)
                {
                    case "MinStack":
                        stack = new MinStack();
                        result[index] = null;
                        break;
                    case "push":
                        stack.Push(args[index][0]);
                        result[index] = null;
                        break;
                    case "pop":
                        stack.Pop();
                        result[index] = null;
                        break;
                    case "top":
                        var top = stack.Top();
                        result[index] = top;
                        break;
                    case "getMin":
                        var min = stack.GetMin();
                        result[index] = min;
                        break;
                }
            }
            Assert.AreEqual(expected, result);
        }
    }
}
