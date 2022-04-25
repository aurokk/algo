using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace H
{
    public enum Color
    {
        White = 0,
        Gray = 1,
        Black = 2,
    }

    public static class H
    {
        private static TextReader _reader;
        private static TextWriter _writer;

        private static SortedSet<int>[] _vertices;

        private static Color[] _colors;
        private static int[] _enter;
        private static int[] _leave;
        private static int _time = 0;

        public static void Main(string[] args)
        {
            _reader = new StreamReader(Console.OpenStandardInput());
            _writer = new StreamWriter(Console.OpenStandardOutput());

            var nm = ReadArray();
            var n = nm[0];
            var m = nm[1];

            _enter = new int[n];
            _leave = new int[n];
            _colors = new Color[n];

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

            for (var i = 0; i < n; i++)
            {
                _writer.WriteLine($"{_enter[i]} {_leave[i]}");
            }

            _reader.Close();
            _writer.Close();
        }

        private static void Dfs(int v)
        {
            _enter[v] = _time;
            _colors[v] = Color.Gray;
            _time += 1;

            var whiteVertices = _vertices[v]
                .Where(w => _colors[w] == Color.White);
            foreach (var w in whiteVertices)
                Dfs(w);

            _leave[v] = _time;
            _colors[v] = Color.Black;
            _time += 1;
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