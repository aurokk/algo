using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace J
{
    public enum Color
    {
        White = 0,
        Gray = 1,
        Black = 2,
    }

    public static class J
    {
        private static TextReader _reader;
        private static TextWriter _writer;

        private static SortedSet<int>[] _vertices;
        private static Color[] _colors;
        private static Stack<int> _result;

        public static void Main(string[] args)
        {
            _reader = new StreamReader(Console.OpenStandardInput());
            _writer = new StreamWriter(Console.OpenStandardOutput());

            var nm = ReadArray();
            var n = nm[0];
            var m = nm[1];

            _colors = new Color[n];
            _result = new Stack<int>();

            _vertices = new SortedSet<int>[n];
            for (var i = 0; i < n; i++)
                _vertices[i] = new SortedSet<int>();

            for (var i = 0; i < m; i++)
            {
                var ab = ReadArray();
                var a = ab[0];
                var b = ab[1];
                _vertices[a - 1].Add(b - 1);
            }

            for (var i = 0; i < n; i++)
                if (_colors[i] == Color.White)
                    Dfs(i);

            _writer.WriteLine(string.Join(' ', _result));

            _reader.Close();
            _writer.Close();
        }

        private static void Dfs(int v)
        {
            _colors[v] = Color.Gray;
            var whiteVertices = _vertices[v]
                .Where(w => _colors[w] == Color.White);
            foreach (var w in whiteVertices)
                Dfs(w);
            _colors[v] = Color.Black;
            _result.Push(v + 1);
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