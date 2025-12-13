using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace LeetCodeTests.Medium
{
    public abstract class Problem_0204
    {
        /* 204. Count Primes
        UR: https://leetcode.com/problems/count-primes/description/

Given an integer n, return the number of prime numbers that are strictly less than n.

Example 1:
Input: n = 10
Output: 4
Explanation: There are 4 prime numbers less than 10, they are 2, 3, 5, 7.

Example 2:
Input: n = 0
Output: 0

Example 3:
Input: n = 1
Output: 0
 
Constraints:
0 <= n <= 5 * 10^6

        */
        public class Solution
        {
            /* IDEA:
                base check: division by 2, 3, 5, 7
                if cannot, check all odd numbers from each ten:
                    x1, x3, x7, x9
                we don't need to check any even, as we checked with 2
                we don't need to check any x5, as we checked with 5
                we need to check xy < n/2, as any number > n/2 cannot be division
            
            */

            public int CountPrimes(int n)
            {
                if (n <= 1)
                    return 0;
                var primes = EratosthenesSieve(n);
                return primes;
            }

            // implementation of the EratosthenesSieve algorithm, but return just a number
            private int EratosthenesSieve(int n)
            {
                var cnt = 0;
                bool[] isNotPrime = new bool[n + 1]; // for better index operations
                for (int num = 2; num < n; num++)
                {
                    if (!isNotPrime[num]) // found prime
                    {
                        cnt++;
                        // mark all products as NotPrime
                        for (int j = 2; j * num < n; j++)
                        {
                            isNotPrime[j * num] = true;
                        }
                    }
                }
                return cnt;
            }

            public int CountPrimes_fromInternet(int n)
            {
                var notPrime = new bool[n];
                var count = 0;
                for (int i = 2; i < n; i++)
                {
                    if (!notPrime[i])
                    {
                        count++;
                        for (int j = 2; j * i < n; j++)
                            notPrime[i * j] = true;
                    }
                }

                return count;
            }

            // found in Google
            // The diff with my implementation is how I work with array
            // in this (below) implementation we can save some time on checking, in my case, we need to pass up to n
            /// <summary>
            /// Finds all prime numbers up to the given limit 'n'.
            /// </summary>
            /// <param name="n">The upper limit for finding primes.</param>
            /// <returns>A List of integers containing all prime numbers up to n.</returns>
            public static List<int> FindPrimesUpToN(int n)
            {
                // 1. Create a boolean array "isPrime[0..n]" and initialize
                //    all entries as true. A value in isPrime[i] will
                //    finally be false if i is Not a prime, else true.
                bool[] isPrime = new bool[n + 1];
                for (int i = 0; i <= n; i++)
                {
                    isPrime[i] = true;
                }

                // 0 and 1 are not prime numbers, so explicitly mark them as false.
                isPrime[0] = isPrime[1] = false;

                // 2. The algorithm starts with the first prime number, 2.
                //    We only need to iterate up to the square root of n.
                for (int p = 2; p * p <= n; p++)
                {
                    // If isPrime[p] is not changed, then it is a prime.
                    if (isPrime[p] == true)
                    {
                        // 3. Mark all multiples of p as false (composite numbers).
                        //    Optimization: Start marking from p*p, as smaller multiples
                        //    (e.g., 2*p, 3*p) would have already been marked by their
                        //    respective prime factors (2, 3).
                        for (int i = p * p; i <= n; i += p)
                        {
                            isPrime[i] = false;
                        }
                    }
                }

                // 4. Collect all the numbers that remained marked as true into a list.
                List<int> primeNumbers = new List<int>();
                for (int p = 2; p <= n; p++)
                {
                    if (isPrime[p] == true)
                    {
                        primeNumbers.Add(p);
                    }
                }

                return primeNumbers;
            }

            // this version cannot return result in expected time
            // decided to implement a proper EratosthenesSieve algorithm
            public int CountPrimes_timeout(int n)
            {
                var knownPrimes = new HashSet<int>(predefinedListOfPrimes);
                for (int i = 2; i < n; i++)
                {
                    if (IsPrime(i, knownPrimes))
                    {
                        knownPrimes.Add(i);
                    }
                }
                if (knownPrimes.Last() < n)
                    return knownPrimes.Count;

                var resultCount = knownPrimes.Count(prime => prime < n);
                return resultCount;
            }

            private static int[] predefinedListOfPrimes = [2, 3, 5, 7, 11, 13, 17, 19];

            /// <summary>
            /// check if the "n" is prime
            /// </summary>
            /// <param name="n">the number to check</param>
            /// <param name="primes">list of known primes</param>
            /// <returns></returns>
            private bool IsPrime(int n, HashSet<int> primes)
            {
                // need to check up to n/2
                var barrier = (int)Math.Sqrt(n); // n / 2;
                // base check
                foreach (var divider in primes)
                {
                    if (divider > barrier)
                        break; // stop foreach
                    if (n % divider == 0)
                        return false;
                }
                // check more detailed
                /* // as we run this for all numbers, we can check only with founded primes // almost Sieve of Eratosthenes

                   var last = primes.Last();
                   if (barrier < last)
                       return true; // we already checked it with PassBaseCheck
                   var checkDivider = last + 2; // all primes (except 2) is odd
                   while (checkDivider < barrier)
                   {
                       if (n % checkDivider == 0)
                           return false;
                       checkDivider += 2; // only odds
                   }
               */
                return true;
            }
        }
    } //public abstract class Problem_
}
