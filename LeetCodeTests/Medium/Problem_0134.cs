using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace LeetCodeTests.Medium
{
    public abstract class Problem_0134
    {
        /*
        URL: https://leetcode.com/problems/gas-station/description/

        There are n gas stations along a circular route, where the amount of gas at the ith station is gas[i].

You have a car with an unlimited gas tank and it costs cost[i] of gas to travel from the ith station to its next (i + 1)th station. You begin the journey with an empty tank at one of the gas stations.

Given two integer arrays gas and cost, return the starting gas station's index if you can travel around the circuit once in the clockwise direction, otherwise return -1. If there exists a solution, it is guaranteed to be unique.

Example 1:
Input: gas = [1,2,3,4,5], cost = [3,4,5,1,2]
Output: 3
Explanation:
Start at station 3 (index 3) and fill up with 4 unit of gas. Your tank = 0 + 4 = 4
Travel to station 4. Your tank = 4 - 1 + 5 = 8
Travel to station 0. Your tank = 8 - 2 + 1 = 7
Travel to station 1. Your tank = 7 - 3 + 2 = 6
Travel to station 2. Your tank = 6 - 4 + 3 = 5
Travel to station 3. The cost is 5. Your gas is just enough to travel back to station 3.
Therefore, return 3 as the starting index.

Example 2:
Input: gas = [2,3,4], cost = [3,4,3]
Output: -1
Explanation:
You can't start at station 0 or 1, as there is not enough gas to travel to the next station.
Let's start at station 2 and fill up with 4 unit of gas. Your tank = 0 + 4 = 4
Travel to station 0. Your tank = 4 - 3 + 2 = 3
Travel to station 1. Your tank = 3 - 3 + 3 = 3
You cannot travel back to station 2, as it requires 4 unit of gas but you only have 3.
Therefore, you can't travel around the circuit once no matter where you start.

Constraints:

n == gas.length == cost.length
1 <= n <= 10^5
0 <= gas[i], cost[i] <= 10^4
The input is generated such that the answer is unique.

        */

        public class Solution
        {
            /* IDEA: we can start only from the station for which is true: gas[i] >= const[i]. It means, we can reach the next station and something will left in the tank.
            if all |gas - cost| < 0, we definitely cannot pass the cycle. RETURN -1.
            if Sum(|gas - cost|) >= 0, we can pass the cycle. RETURN index of first possitive element. It's not enough
            
            */
            public int CanCompleteCircuit(int[] gas, int[] cost)
            {
                var startIndex = -1;
                var pathSum = 0;
                for (int ind = 0; ind < gas.Length; ind++)
                {
                    var diff = gas[ind] - cost[ind];
                    if ((diff >= 0) && (startIndex == -1))
                        startIndex = ind;
                    pathSum += diff;

                    gas[ind] = pathSum; // use gas to keep the sum paths (if the value is negative, it's impossible to reach it from the 0 index)
                    cost[ind] = diff; // diff
                }
                if (pathSum < 0)
                    return -1; // NO POSSIBLE

                // DO BRUTE FORCE
                // from left to right by diff array
                // if diff[ind] > 0, try to sum diffs from ind to [end]
                // if never sum < 0, use Ind as a result
                startIndex = 0;
                for (int ind = 0; ind < gas.Length; ind++)
                {
                    if (cost[ind] > 0) // make a check
                    {
                        var sum = 0;
                        for (int sumInd = ind; sumInd < gas.Length; sumInd++)
                        {
                            sum += cost[sumInd];
                            if (sum < 0)
                                break; // sumInd
                        }
                        if (sum >= 0)
                            return ind;
                    }
                }

                #region /// wrong approach
                // DON'T WORK
                // // to find the first node, need to pass from right to left for gas(which is used for keep sum path)
                // // and find the node, where we get first positive

                // for (int ind = gas.Length - 1; ind >= 0; ind--)
                // {
                //     if (gas[ind] < 0)
                //     {
                //         startIndex = ind + 1;
                //         break;
                //     }
                // }

                // // from this possition move left while local diff (in cost) is positive
                // for (int ind = startIndex; ind >= 0; ind--)
                // {
                //     if (cost[ind] < 0)
                //         return ind + 1;
                // }
                #endregion

                // approach 2: sum from right to left gas (Sgas) and cost (Scost), when Scost > Sgas
                // if we can close the cycle, we should pass via end, so start from right
                // WILL NOT WORK

                // try to calculate from right to left sum of diff
                return 0;
            }
        }

        // borrowed:
        public int CanCompleteCircuit_good(int[] gas, int[] cost)
        {
            // the tank should be empty before travelling through the stations.
            int total = 0,
                tank = 0,
                start = 0;
            for (int i = 0; i < gas.Length; i++)
            {
                int diff = gas[i] - cost[i];
                total += diff;
                tank += diff;

                if (tank < 0)
                {
                    start = i + 1;
                    tank = 0;
                }
            }
            return total < 0 ? -1 : start;
        }
    } //public abstract class Problem_
}
