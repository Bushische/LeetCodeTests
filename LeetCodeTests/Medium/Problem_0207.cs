using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;

namespace LeetCodeTests.Medium
{
    public abstract class Problem_0207
    {
        /* 207. Course Schedule
        URL: https://leetcode.com/problems/course-schedule/
    
There are a total of numCourses courses you have to take, labeled from 0 to numCourses - 1. You are given an array prerequisites where prerequisites[i] = [ai, bi] indicates that you must take course bi first if you want to take course ai.
For example, the pair [0, 1], indicates that to take course 0 you have to first take course 1.
Return true if you can finish all courses. Otherwise, return false.

Example 1:
Input: numCourses = 2, prerequisites = [[1,0]]
Output: true
Explanation: There are a total of 2 courses to take.
To take course 1 you should have finished course 0. So it is possible.

Example 2:
Input: numCourses = 2, prerequisites = [[1,0],[0,1]]
Output: false
Explanation: There are a total of 2 courses to take.
To take course 1 you should have finished course 0, and to take course 0 you should also have finished course 1. So it is impossible.
 
Constraints:
1 <= numCourses <= 2000
0 <= prerequisites.length <= 5000
prerequisites[i].length == 2
0 <= ai, bi < numCourses
All the pairs prerequisites[i] are unique.

        */
        public class Solution
        {
            /* IDEA: we cannot compleate all courses if ther is a loop/cycle in the graph of dependencies.
                we can build a graph and identify loop in it
                idea of implementation: array of dependencies int[numCourses][<dependencies>] - keep a list of deps for course
                for every course we must to check, that we can finish it

                algorithm:
                take a course I
                collect all dependencies of I: dep[I]
                for each element in dep[I]
                    if any of dependency in {I + dep[I]} we have a loop ==> FALSE

                NOTES:
                    it seems, we can use memorization
                    if the cource can be achieved, any other course depend on it, can not create a loop

            */
            public bool CanFinish(int numCourses, int[][] prerequisites)
            {
                // init dep collection
                var deps = new List<int>[numCourses];
                for (int i = 0; i < numCourses; i++)
                    deps[i] = [];

                // fill dep collection
                foreach (var prereq in prerequisites)
                {
                    deps[prereq[0]].Add(prereq[1]);
                }

                // set to check courses that can be finite
                var canFinish = new HashSet<int>(); // here we keep all cources, that can be finite
                var wasFoundNewFiniteCource = true; // flag that during the iteration a new finite cource was found
                while (wasFoundNewFiniteCource)
                {
                    wasFoundNewFiniteCource = false;
                    for (int i = 0; i < numCourses; i++)
                    {
                        if (canFinish.Contains(i))
                            continue; // skip this course
                        var courseCanBeFinished = (deps[i].Count == 0);
                        courseCanBeFinished =
                            courseCanBeFinished || (deps[i].All(dep => canFinish.Contains(dep)));

                        if (courseCanBeFinished)
                        {
                            canFinish.Add(i);
                            wasFoundNewFiniteCource = true;
                        }
                    }
                }
                return canFinish.Count == numCourses; // if every course can be finished
            }

            // Kahn's algorithm:
            // https://leetcode.com/problems/course-schedule/solutions/3614546/c-kahns-algorithm-topological-sort-detai-pifx/
        }
    } //public abstract class Problem_
}


/*
TRUE
0: 1
1: <>
---
FALSE
0: 1
1: 2
2: 0
3: <>
---
TRUE
0: 1, 2
1: 3
2: 3
3: <>

*/
