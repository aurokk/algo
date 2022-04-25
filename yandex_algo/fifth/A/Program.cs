using System;
using System.IO;

namespace A
{
    public static class A
    {
        private static TextReader _reader;
        private static TextWriter _writer;

        public static void Main(string[] args)
        {
            _reader = new StreamReader(Console.OpenStandardInput());
            _writer = new StreamWriter(Console.OpenStandardOutput());

            var root = new Node(1);
            root.Left = new Node(3);
            root.Left.Left = new Node(8);
            root.Left.Left.Left = new Node(14);
            root.Left.Left.Right = new Node(15);
            root.Left.Right = new Node(10);
            root.Left.Right.Right = new Node(3);
            root.Right = new Node(5);
            root.Right.Left = new Node(2);
            root.Right.Right = new Node(6);
            root.Right.Right.Left = new Node(0);
            root.Right.Right.Right = new Node(1);

            var result = Solution.Solve(root);
            _writer.WriteLine(result);

            _reader.Close();
            _writer.Close();
        }
    }
}