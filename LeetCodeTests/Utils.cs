using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeTests
{
    public static class Utils
    {
        /// Prints the array of objects
        /// </summary>
        /// <returns>The array.</returns>
        /// <param name="obj">Object.</param>
        public static string PrintArray(object obj)
        {
            string res = "";
            if (obj is IEnumerable)
            {
                res = "[";
                foreach (object ob in (obj as IEnumerable))
                {
                    res += " " + PrintArray(ob) + ",";
                }
                if (res[res.Length - 1] == ',')
                    res = res.Substring(0, res.Length - 1);
                res += "]";
            }
            else
                res = obj.ToString();
            return res;
        }

        /// <summary>
        /// Print 2D array.
        /// </summary>
        /// <returns>The DA rray.</returns>
        /// <param name="obj">Object.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static string Print2DArray<T>(T[,] obj)
        {
            string res = "[";
            int m = obj.GetLength(0);
            int n = obj.GetLength(1);
            for (int i = 0; i < m; i++)
            {
                res += "[";
                for (int j = 0; j < n; j++)
                {
                    res += " " + obj[i, j].ToString() + ",";
                }
                if (res[res.Length - 1] == ',')
                    res = res.Substring(0, res.Length - 1);
                res += "]";
                if (i < m - 1)
                    res += ",\n ";
            }
            if (res[res.Length - 1] == ',')
                res = res.Substring(0, res.Length - 1);
            return res + "]";
        }

        /// <summary>
        /// Print List (ListNode class)
        /// </summary>
        /// <returns>The list.</returns>
        /// <param name="head">Head.</param>
        public static string PrintList(ListNode head)
        {
            if (head == null)
                return "";
            else
                return head.val.ToString()
                    + ((head.next == null) ? "" : ":" + PrintList(head.next));
        }

        /// <summary>
        /// Create a list based on int array
        /// </summary>
        /// <returns>The list.</returns>
        /// <param name="inArr">In arr.</param>
        /// <param name="index">Index.</param>
        public static ListNode GenerateList(int[] inArr, int index = 0)
        {
            if (index >= inArr.Length)
                return null;

            ListNode res = new ListNode(inArr[index]);
            res.next = GenerateList(inArr, index + 1);
            return res;
        }

        /// <summary>
        /// Get bit view of integer. Minimal length if length is not passed and length is equal to passed value otherwise.
        /// </summary>
        /// <returns>The bit view.</returns>
        /// <param name="n">N.</param>
        /// <param name="length">Length.</param>
        public static string GetBitView(int n, int length = 0)
        {
            string res = "";
            while (((length == 0) && (n > 0)) || ((length > 0) && (res.Length < length)))
            {
                res = (n & 1).ToString() + res;
                n = n >> 1;
            }
            return res;
        }
    } //

    /*** Additional classes ***/
    public class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode(int x)
        {
            val = x;
        }

        public string PrintList()
        {
            return val.ToString() + ((next == null) ? "" : (" -> " + next.PrintList()));
        }

        public static bool AreEqualTo(ListNode oldList, ListNode newList)
        {
            var thisListStr = oldList?.PrintList() ?? "";
            var thatListStr = newList?.PrintList() ?? "";
            return thisListStr == thatListStr;
        }

        /// <summary>
        /// Create a list from array
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static ListNode CreateFromTheList(List<int> list)
        {
            ListNode head = null;
            var prevNode = head;
            foreach (int elem in list)
            {
                var newNode = new ListNode(elem);
                if (prevNode != null)
                    prevNode.next = newNode;
                head ??= newNode;
                prevNode = newNode;
            }
            return head;
        }
    }

    /// <summary>
    /// Definition for a binary tree node.
    /// </summary>
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;

        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }

        public static TreeNode ConvertArrayToTree(int?[] treeNodes)
        {
            // input array contains data by levels
            // we need to use stack to correctly build the result
            if ((treeNodes == null) || (treeNodes.Length == 0))
                return null;

            TreeNode head;
            var nodesQueue = new Queue<TreeNode>(); // here we keep all created nodes

            // head
            var headValue = treeNodes[0];
            if (headValue == null)
                return null;
            head = new TreeNode(headValue.Value);
            nodesQueue.Enqueue(head);

            // subnodes
            var inputIndex = 1;
            while (inputIndex < treeNodes.Length)
            {
                var curNode = nodesQueue.Dequeue();

                var leftVal = treeNodes[inputIndex];
                inputIndex++;
                int? rightVal = null;
                if (inputIndex < treeNodes.Length)
                {
                    rightVal = treeNodes[inputIndex];
                    inputIndex++;
                }

                if (leftVal.HasValue)
                {
                    var newNode = new TreeNode(leftVal.Value);
                    nodesQueue.Enqueue(newNode);
                    curNode.left = newNode;
                }
                if (rightVal.HasValue)
                {
                    var newNode = new TreeNode(rightVal.Value);
                    nodesQueue.Enqueue(newNode);
                    curNode.right = newNode;
                }
            }

            return head;
        }
    }

    /// <summary>
    /// Benchmark.
    /// </summary>
    public static class Benchmark
    {
        private static DateTime _start;

        public static void Start()
        {
            _start = DateTime.Now;
        }

        public static TimeSpan Finish()
        {
            return DateTime.Now - _start;
        }
    } // Benchmark
}
