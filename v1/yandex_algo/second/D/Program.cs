using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace D
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
        public static int Solve(Node<string> head, string item)
        {
            var currentIndex = 0;
            var element = head;
            while (true)
            {
                if (element.Value == item)
                {
                    return currentIndex;
                }

                if (element.Next == null)
                {
                    return -1;
                }

                currentIndex++;
                element = element.Next;
            }
        }

        // private static void Test()
        // {
        //     var node3 = new Node<string>("node3", null);
        //     var node2 = new Node<string>("node2", node3);
        //     var node1 = new Node<string>("node1", node2);
        //     var node0 = new Node<string>("node0", node1);
        //     var idx = Solve(node0, "node0");
        //     // result is : idx == 2
        // }

        public static void Print(Node<TValue> head)
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
            var node3 = new Node<string>("node3", null);
            var node2 = new Node<string>("node2", node3);
            var node1 = new Node<string>("node1", node2);
            var node0 = new Node<string>("node0", node1);
            var idx = Solution<string>.Solve(node0, "node2");
            Console.WriteLine(idx);
        }
    }
}