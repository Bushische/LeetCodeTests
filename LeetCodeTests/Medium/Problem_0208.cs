using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace LeetCodeTests.Medium
{
    public abstract class Problem_0208
    {
        /* 208. Implement Trie (Prefix Tree)
        URL: https://leetcode.com/problems/implement-trie-prefix-tree/description/

A trie (pronounced as "try") or prefix tree is a tree data structure used to efficiently store and retrieve keys in a dataset of strings. There are various applications of this data structure, such as autocomplete and spellchecker.

Implement the Trie class:

Trie() Initializes the trie object.
void insert(String word) Inserts the string word into the trie.
boolean search(String word) Returns true if the string word is in the trie (i.e., was inserted before), and false otherwise.
boolean startsWith(String prefix) Returns true if there is a previously inserted string word that has the prefix prefix, and false otherwise.

Example 1:
Input
["Trie", "insert", "search", "search", "startsWith", "insert", "search"]
[[], ["apple"], ["apple"], ["app"], ["app"], ["app"], ["app"]]
Output
[null, null, true, false, true, null, true]
Explanation
Trie trie = new Trie();
trie.insert("apple");
trie.search("apple");   // return True
trie.search("app");     // return False
trie.startsWith("app"); // return True
trie.insert("app");
trie.search("app");     // return True
 
Constraints:
1 <= word.length, prefix.length <= 2000
word and prefix consist only of lowercase English letters.
At most 3 * 10^4 calls in total will be made to insert, search, and startsWith.

        */
        public class Trie
        {
            /// <summary>
            /// All edged from the current node as dictionary char -> Trie
            /// </summary>
            private Dictionary<char, Trie> edges = new();

            /// <summary>
            /// The flag, that at this node the inserted word was ends (as in the example for `app` it should be false)
            /// </summary>
            private bool wordEnd = false;

            public Trie() { }

            // can be called only for the root
            public void Insert(string word)
            {
                if (string.IsNullOrEmpty(word))
                {
                    wordEnd = true;
                    return;
                }
                var key = word[0];
                if (edges.TryGetValue(key, out Trie value))
                {
                    value.Insert(word[1..]);
                }
                else
                {
                    var newEdge = new Trie();
                    edges.Add(key, newEdge);
                    newEdge.Insert(word[1..]);
                }
            }

            public bool Search(string word)
            {
                if (string.IsNullOrEmpty(word))
                {
                    return wordEnd;
                }
                var key = word[0];
                if (edges.TryGetValue(key, out Trie value))
                {
                    return value.Search(word[1..]);
                }
                return false;
            }

            public bool StartsWith(string prefix)
            {
                if (string.IsNullOrEmpty(prefix))
                {
                    return true;
                }
                var key = prefix[0];
                if (edges.TryGetValue(key, out Trie value))
                {
                    return value.StartsWith(prefix[1..]);
                }
                return false;
            }
            // Search and StartWith can be generalized with FindTrieNode with aftercheck

            // Can be solved iterative, not recursive
        }
    } //public abstract class Problem_
}
