using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace C
{
// закомментируйте перед отправкой

    public class Node<TValue>
    {
        public TValue Value { get; private set; }
        public Node<TValue> Next { get; set; }

        public Node(TValue value, Node<TValue> next)
        {
            Value = value;
            Next = next;
        }
    }

    public class Solution<TValue>
    {
        public static Node<TValue> Solve(Node<TValue> head, int idx)
        {
            var index = idx;
            var previous = (Node<TValue>) null;
            var item = head;
            while (index > 0)
            {
                previous = item;
                item = previous.Next;
                index--;
            }

            if (previous == null)
            {
                return item.Next;
            }
            else
            {
                previous.Next = item.Next;
                return head;
            }
        }

        public static void Print(Node<TValue> head)
        {
            System.Console.WriteLine(head.Value);
            if (head.Next != null)
            {
                Print(head.Next);
            }
        }
    }

    public class C
    {
        public static void Main(string[] args)
        {
            var node3 = new Node<string>("node3", null);
            var node2 = new Node<string>("node2", node3);
            var node1 = new Node<string>("node1", node2);
            var node0 = new Node<string>("node0", node1);
            var newHead = Solution<string>.Solve(node0, 3);
            Solution<string>.Print(newHead);
        }
    }
}