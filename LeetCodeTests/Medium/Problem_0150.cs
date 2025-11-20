using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using Microsoft.VisualBasic;

namespace LeetCodeTests.Medium
{
    public abstract class Problem_0150
    {
        /* 150. Evaluate Reverse Polish Notation
        URL: https://leetcode.com/problems/evaluate-reverse-polish-notation/description/

You are given an array of strings tokens that represents an arithmetic expression in a Reverse Polish Notation.

Evaluate the expression. Return an integer that represents the value of the expression.

Note that:

The valid operators are '+', '-', '*', and '/'.
Each operand may be an integer or another expression.
The division between two integers always truncates toward zero.
There will not be any division by zero.
The input represents a valid arithmetic expression in a reverse polish notation.
The answer and all the intermediate calculations can be represented in a 32-bit integer.
 

Example 1:
Input: tokens = ["2","1","+","3","*"]
Output: 9
Explanation: ((2 + 1) * 3) = 9

Example 2:
Input: tokens = ["4","13","5","/","+"]
Output: 6
Explanation: (4 + (13 / 5)) = 6

Example 3:
Input: tokens = ["10","6","9","3","+","-11","*","/","*","17","+","5","+"]
Output: 22
Explanation: ((10 * (6 / ((9 + 3) * -11))) + 17) + 5
= ((10 * (6 / (12 * -11))) + 17) + 5
= ((10 * (6 / -132)) + 17) + 5
= ((10 * 0) + 17) + 5
= (0 + 17) + 5
= 17 + 5
= 22

Constraints:

1 <= tokens.length <= 10^4
tokens[i] is either an operator: "+", "-", "*", or "/", or an integer in the range [-200, 200].

        */
        public class Solution
        {
            /* IDEA: implement a real Reverse Polish notation
            Stack for arguments
            if we take "number" from "tokens", put them on top of the argument stack
            When we get "operation" from "tokens", we need to take 2 elements from stack and apply operation between arg2 and arg1,
                where arg2 - the element from the top
                      arg1 - the second element from stack
            the result of the operation should be put to the stack.

            Repeat until tokens is empty
            */
            private static HashSet<string> operands = new HashSet<string> { "+", "-", "/", "*" };

            private static int Apply(string operand, int arg1, int arg2)
            {
                return operand switch
                {
                    "+" => arg1 + arg2,
                    "-" => arg1 - arg2,
                    "*" => arg1 * arg2,
                    "/" => arg1 / arg2, // int division (towards 0)
                    _ => throw new ArgumentException("Invalid operand", nameof(operand)),
                };
            }

            public int EvalRPN(string[] tokens)
            {
                var argStack = new Stack<int>();
                for (int tokenIndex = 0; tokenIndex < tokens.Length; tokenIndex++) // as tokens unchangable
                {
                    var token = tokens[tokenIndex];
                    if (int.TryParse(token, out int intToken))
                    {
                        argStack.Push(intToken);
                    }
                    else // execute calculation
                    {
                        var arg2 = argStack.Pop();
                        var arg1 = argStack.Pop();
                        var opResult = Apply(token, arg1, arg2);
                        argStack.Push(opResult);
                    }
                }
                var result = argStack.Pop();
                return result;
            }
        }
    } //public abstract class Problem_
}
