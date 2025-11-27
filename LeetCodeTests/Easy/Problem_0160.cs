using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace LeetCodeTests.Easy
{
    public abstract class Problem_0160
    {
        /* 160. Intersection of Two Linked Lists
        URL: https://leetcode.com/problems/intersection-of-two-linked-lists/description/

Given the heads of two singly linked-lists headA and headB, return the node at which the two lists intersect. If the two linked lists have no intersection at all, return null.

For example, the following two linked lists begin to intersect at node c1:
The test cases are generated such that there are no cycles anywhere in the entire linked structure.

Note that the linked lists must retain their original structure after the function returns.

Custom Judge:
The inputs to the judge are given as follows (your program is not given these inputs):
- intersectVal - The value of the node where the intersection occurs. This is 0 if there is no intersected node.
- listA - The first linked list.
- listB - The second linked list.
- skipA - The number of nodes to skip ahead in listA (starting from the head) to get to the intersected node.
- skipB - The number of nodes to skip ahead in listB (starting from the head) to get to the intersected node.
The judge will then create the linked structure based on these inputs and pass the two heads, headA and headB to your program. If you correctly return the intersected node, then your solution will be accepted.

Example 1:
Input: intersectVal = 8, listA = [4,1,8,4,5], listB = [5,6,1,8,4,5], skipA = 2, skipB = 3
Output: Intersected at '8'
Explanation: The intersected node's value is 8 (note that this must not be 0 if the two lists intersect).
From the head of A, it reads as [4,1,8,4,5]. From the head of B, it reads as [5,6,1,8,4,5]. There are 2 nodes before the intersected node in A; There are 3 nodes before the intersected node in B.
- Note that the intersected node's value is not 1 because the nodes with value 1 in A and B (2nd node in A and 3rd node in B) are different node references. In other words, they point to two different locations in memory, while the nodes with value 8 in A and B (3rd node in A and 4th node in B) point to the same location in memory.

Example 2:
Input: intersectVal = 2, listA = [1,9,1,2,4], listB = [3,2,4], skipA = 3, skipB = 1
Output: Intersected at '2'
Explanation: The intersected node's value is 2 (note that this must not be 0 if the two lists intersect).
From the head of A, it reads as [1,9,1,2,4]. From the head of B, it reads as [3,2,4]. There are 3 nodes before the intersected node in A; There are 1 node before the intersected node in B.

Example 3:
Input: intersectVal = 0, listA = [2,6,4], listB = [1,5], skipA = 3, skipB = 2
Output: No intersection
Explanation: From the head of A, it reads as [2,6,4]. From the head of B, it reads as [1,5]. Since the two lists do not intersect, intersectVal must be 0, while skipA and skipB can be arbitrary values.
Explanation: The two lists do not intersect, so return null.

Constraints:

The number of nodes of listA is in the m.
The number of nodes of listB is in the n.
1 <= m, n <= 3 * 10^4
1 <= Node.val <= 10^5
0 <= skipA <= m
0 <= skipB <= n
intersectVal is 0 if listA and listB do not intersect.
intersectVal == listA[skipA] == listB[skipB] if listA and listB intersect.
 

Follow up: Could you write a solution that runs in O(m + n) time and use only O(1) memory?

        */
        /**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
        public class Solution
        {
            /* IDEA: as we limited with memory O(1), we cannot introduce two stacks for back processing.
            We can:
                - calculate length n and m
                - for the longest stack:
                    - skip (max-min)
                - so we will have same elements to pass for both links
                - move towards the end until values are not the same
                - this value will be the result

                Memory: O(1) - for two references
                Time: O(2m+2n) or O(m+n) as required
            
            */
            public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
            {
                // 1. calculate lengths len(A) = n, len(B) = m
                var n = 0;
                var refA = headA;
                while (refA != null)
                {
                    n++;
                    refA = refA.next;
                }

                var m = 0;
                var refB = headB;
                while (refB != null)
                {
                    m++;
                    refB = refB.next;
                }

                // 2. set A as a longest list
                if (n > m)
                {
                    refA = headA;
                    refB = headB;
                }
                else
                {
                    refA = headB;
                    refB = headA;
                }

                // 3. Skip first (max-min) elements in refA
                var extra = int.Max(n, m) - int.Min(n, m);
                while (extra > 0)
                {
                    extra--;
                    refA = refA.next;
                }

                // 4. Search for a common value
                while ((refA != null) && (refB != null) && (refA != refB))
                {
                    refA = refA.next;
                    refB = refB.next;
                }

                // 5. return result;
                if ((refA is null) || (refB is null))
                    return null;
                return refA;
            }

            // from https://leetcode.com/problems/intersection-of-two-linked-lists/solutions/6332289/two-pointers-approach-c-by-ramidahadov-mjvy/
            /* IDEA: if we add listA to the end of listB
                and listB to the end of listA
                we will get two list with the same number of elements
                and we will easily find common element at the end.
            */
            public ListNode nice_GetIntersectionNode(ListNode headA, ListNode headB)
            {
                if (headA == null || headB == null)
                {
                    return null;
                }

                ListNode pointerA = headA;
                ListNode pointerB = headB;

                while (pointerA != pointerB)
                {
                    pointerA = pointerA == null ? headB : pointerA.next;
                    pointerB = pointerB == null ? headA : pointerB.next;
                }

                return pointerA;
            }
        }
    } //public abstract class Problem_
}
