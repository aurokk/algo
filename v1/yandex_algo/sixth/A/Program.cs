using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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

            var nm = ReadArray();
            var n = nm[0];
            var m = nm[1];

            var result = new SortedSet<int>[n];
            for (var i = 0; i < n; i++)
            {
                result[i] = new SortedSet<int>();
            }

            for (var i = 0; i < m; i++)
            {
                var ab = ReadArray();
                var a = ab[0];
                var b = ab[1];
                result[a - 1].Add(b);
            }

            for (var i = 0; i < n; i++)
            {
                var count = result[i].Count;
                var vertices = string.Join(' ', result[i]);
                _writer.WriteLine($"{count} {vertices}");
            }

            _reader.Close();
            _writer.Close();
        }

        private static int[] ReadArray()
        {
            return _reader.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
        }
    }
}