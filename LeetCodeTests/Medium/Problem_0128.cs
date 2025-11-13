using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.Specialized;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace LeetCodeTests.Medium
{
    public abstract class Problem_0128
    {
        /*
        URL: https://leetcode.com/problems/longest-consecutive-sequence/description/

Given an unsorted array of integers nums, return the length of the longest consecutive elements sequence.

You must write an algorithm that runs in O(n) time.

Example 1:
Input: nums = [100,4,200,1,3,2]
Output: 4
Explanation: The longest consecutive elements sequence is [1, 2, 3, 4]. Therefore its length is 4.

Example 2:
Input: nums = [0,3,7,2,5,8,4,6,0,1]
Output: 9

Example 3:
Input: nums = [1,0,1,2]
Output: 3
 
Constraints:
0 <= nums.length <= 10^5
-10^9 <= nums[i] <= 10^9

        */

        public class Solution_dont_like
        {
            public int LongestConsecutive(int[] nums)
            {
                if (nums.Length == 0)
                    return 0;

                var sortedNums = nums.OrderBy(x => x).Distinct().ToList();

                int sequenceCount = 1;
                int maxSeqLength = 1;
                int prev = sortedNums[0];

                foreach (var el in sortedNums)
                {
                    if (el == prev)
                        continue;
                    if (el == prev + 1)
                    {
                        sequenceCount += 1;
                        maxSeqLength = int.Max(maxSeqLength, sequenceCount);
                    }
                    else
                    {
                        sequenceCount = 1;
                    }
                    prev = el;
                }

                return maxSeqLength;
            }
        }

        public class Solution
        {
            /* IDEA: use hashmap to get rid of duplicates
                - pass through the set and find any element without previous in HT
                - calculate a sequence length for this element
                - find max from the length
            */
            public int LongestConsecutive(int[] nums)
            {
                if (nums.Length == 0)
                    return 0;

                var set = new HashSet<int>(nums);

                int maxSeqLength = 0;
                foreach (int el in set)
                {
                    if (!set.Contains(el - 1)) // first in the subsequence
                    {
                        int length = 0;
                        while (set.Contains(el + length))
                        {
                            length++;
                        }
                        maxSeqLength = int.Max(maxSeqLength, length);
                    }
                }

                return maxSeqLength;
            }
        }

        public class Solution_wrong
        {
            /* IDEA: as we need to make an algorithm that runs in O(n) (need to remember that O(2n) is still O(n))
            Convert array to binary tree
            make LNR (in order) pass and collect the most consecutive sub-sequence
            */

            class BinaryTree
            {
                public int val;
                public BinaryTree left;
                public BinaryTree right;

                public BinaryTree(int val, BinaryTree left, BinaryTree right)
                {
                    this.val = val;
                    this.left = left;
                    this.right = right;
                }

                // Add element to the tree
                public void Add(int newVal)
                {
                    if (newVal <= val)
                    {
                        if (left is null)
                            left = new BinaryTree(newVal, null, null);
                        else
                            left.Add(newVal);
                    }
                    else
                    {
                        if (right is null)
                            right = new BinaryTree(newVal, null, null);
                        else
                            right.Add(newVal);
                    }
                }
            };

            public int LongestConsecutive(int[] nums)
            {
                if (nums.Length == 0)
                    return 0;

                // 1. Build a binary tree
                BinaryTree root = null;
                foreach (int element in nums)
                {
                    if (root is null)
                    {
                        root = new BinaryTree(element, null, null);
                    }
                    else
                    {
                        root.Add(element);
                    }
                }

                // 2. LNR pass
                var (_, _, maxCount) = CollectSubseq(root, root?.val ?? int.MaxValue, 1, 1);
                return maxCount;
            }

            // the goal is pass through the tree as LNR (left - this - right) and try to calculate length of sequence
            // return (last visited, current count)
            private (int, int, int) CollectSubseq(
                BinaryTree node,
                int lastVisited,
                int subseqCount,
                int foundMax
            )
            {
                if (node is null)
                    return (lastVisited, subseqCount, foundMax);
                // go left
                var (llast, lcount, lmax) = CollectSubseq(
                    node.left,
                    lastVisited,
                    subseqCount,
                    foundMax
                );
                // compare with this
                if (llast + 1 == node.val) // next element in sequence
                {
                    llast = node.val;
                    lcount += 1;
                    lmax = int.Max(lcount, lmax);
                } // if (llast == node.val)   // just skip
                else if (llast != node.val) // flash the sequence
                {
                    llast = node.val;
                    lcount = 1;
                }
                // go right
                var (rlast, rcount, rmax) = CollectSubseq(node.right, llast, lcount, lmax);
                // return the result
                return (rlast, rcount, rmax);
            }
        }
    } //public abstract class Problem_
}
