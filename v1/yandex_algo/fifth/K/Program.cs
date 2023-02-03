using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace K
{
    public static class K
    {
        private static StreamReader _reader;
        private static StreamWriter _writer;

        public static void Main(string[] args)
        {
            _reader = new StreamReader(Console.OpenStandardInput());
            _writer = new StreamWriter(Console.OpenStandardOutput());

            var root = new Node(5);
            root.Left = new Node(1);
            root.Left.Right = new Node(2);
            root.Right = new Node(10);
            root.Right.Left = new Node(9);
            root.Right.Left.Left = new Node(8);
            root.Right.Left.Left.Right = new Node(8);

            Solution.PrintRange(root, 2, 8, _writer);

            _reader.Close();
            _writer.Close();
        }
    }
}