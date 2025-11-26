using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using Microsoft.VisualBasic;

namespace LeetCodeTests.Medium
{
    public abstract class Problem_0155
    {
        /* 155. Min Stack
        URL: https://leetcode.com/problems/min-stack/description/

Design a stack that supports push, pop, top, and retrieving the minimum element in constant time.

Implement the MinStack class:

MinStack() initializes the stack object.
void push(int val) pushes the element val onto the stack.
void pop() removes the element on the top of the stack.
int top() gets the top element of the stack.
int getMin() retrieves the minimum element in the stack.
You must implement a solution with O(1) time complexity for each function.


Example 1:

Input
["MinStack","push","push","push","getMin","pop","top","getMin"]
[[],[-2],[0],[-3],[],[],[],[]]

Output
[null,null,null,null,-3,null,0,-2]

Explanation
MinStack minStack = new MinStack();
minStack.push(-2);
minStack.push(0);
minStack.push(-3);
minStack.getMin(); // return -3
minStack.pop();
minStack.top();    // return 0
minStack.getMin(); // return -2
 

Constraints:

-2^31 <= val <= 2^31 - 1
Methods pop, top and getMin operations will always be called on non-empty stacks.
At most 3 * 104 calls will be made to push, pop, top, and getMin.

        */
        public class MinStack
        {
            /* IDEA: for every element in stack we should keep previous MIN
                when we Push, we should re-evaluate MIN and save it together with the value
                when we Pop, we should ... nothing
                when GetMin - take top and return MIN from it.

                Internal structure Stack<(value, MIN)>
            */
            private Stack<Tuple<int, int>> _internal = null;

            public MinStack()
            {
                _internal = new();
            }

            public void Push(int val)
            {
                var min = val;
                if (_internal.Count > 0)
                {
                    var prevValue = _internal.Peek();
                    min = int.Min(min, prevValue.Item2);
                }
                _internal.Push(new Tuple<int, int>(val, min));
            }

            public void Pop()
            {
                _internal.Pop();
            }

            public int Top()
            {
                if (_internal.TryPeek(out var top))
                {
                    return top.Item1;
                }
                throw new InvalidOperationException("Stack is empty");
            }

            public int GetMin()
            {
                if (_internal.TryPeek(out var top))
                {
                    return top.Item2;
                }
                throw new InvalidOperationException("Stack is empty");
            }
        }

        /**
         * Your MinStack object will be instantiated and called as such:
         * MinStack obj = new MinStack();
         * obj.Push(val);
         * obj.Pop();
         * int param_3 = obj.Top();
         * int param_4 = obj.GetMin();
         */
    } //public abstract class Problem_
}
