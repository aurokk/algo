using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace B
{
    public class Node<TValue>
    {
        // закомментируйте перед отправкой
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
        public static void Solve(Node<TValue> head)
        {
            System.Console.WriteLine(head.Value);
            if (head.Next != null)
            {
                Solve(head.Next);
            }
        }
    }

    public class B
    {
        private static TextReader _reader;
        private static TextWriter _writer;

        public static List<int> Zip(List<int> a, List<int> b)
        {
            // Здесь реализация вашего решения
            throw new NotImplementedException();
        }

        public static void Main(string[] args)
        {
            // _reader = new StreamReader(Console.OpenStandardInput());
            // _writer = new StreamWriter(Console.OpenStandardOutput());

            // var n = ReadInt();
            // var arrayA = ReadList();
            // var arrayB = ReadList();
            // _writer.WriteLine(string.Join(" ", Zip(arrayA, arrayB)));

            // _reader.Close();
            // _writer.Close();

            var node3 = new Node<string>("node3", null);
            var node2 = new Node<string>("node2", node3);
            var node1 = new Node<string>("node1", node2);
            var node0 = new Node<string>("node0", node1);
            Solution<string>.Solve(node0);
        }

        private static int ReadInt()
        {
            return int.Parse(_reader.ReadLine());
        }

        private static List<int> ReadList()
        {
            return _reader.ReadLine()
                .Split(new[] {' ', '\t',}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
        }
    }
}