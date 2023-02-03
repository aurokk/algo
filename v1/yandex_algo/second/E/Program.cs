using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace E
{
// закомментируйте перед отправкой

    public class Node<TValue>
    {
        public TValue Value { get; private set; }
        public Node<TValue> Next { get; set; }
        public Node<TValue> Prev { get; set; }

        public Node(TValue value, Node<TValue> next, Node<TValue> prev)
        {
            Value = value;
            Next = next;
            Prev = prev;
        }
    }

    public class Solution
    {
        public static Node<string> Solve(Node<string> head)
        {
            var item = head;
            while (true)
            {
                var next = item.Next;
                item.Next = item.Prev;
                item.Prev = next;

                if (next == null)
                {
                    return item;
                }

                item = next;
            }
        }

        public static void Print(Node<string> head)
        {
            System.Console.WriteLine(head.Value);
            if (head.Next != null)
            {
                Print(head.Next);
            }
        }
    }

    public class D
    {
        public static void Main(string[] args)
        {
            var node3 = new Node<string>("node3", null, null);
            var node2 = new Node<string>("node2", null, null);
            var node1 = new Node<string>("node1", null, null);
            var node0 = new Node<string>("node0", null, null);
            node0.Next = node1;
            node0.Prev = null;
            node1.Next = node2;
            node1.Prev = node0;
            node2.Next = node3;
            node2.Prev = node1;
            node3.Next = null;
            node3.Prev = node2;

            var newNode = Solution.Solve(node0);
            Solution.Print(newNode);
        }
    }
}