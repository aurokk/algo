using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace E
{
    public static class E
    {
        private static TextReader _reader;
        private static TextWriter _writer;

        private static SortedSet<int>[] _vertices;
        private static int[] _colors;
        private static Stack<int> _result;
        private static int _components;

        public static void Main(string[] args)
        {
            _reader = new StreamReader(Console.OpenStandardInput());
            _writer = new StreamWriter(Console.OpenStandardOutput());

            var nm = ReadArray();
            var n = nm[0];
            var m = nm[1];

            _colors = new int[n];
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
                _vertices[b - 1].Add(a - 1);
            }

            for (var i = 0; i < n; i++)
                if (_colors[i] == 0)
                {
                    _components++;
                    Dfs(i, _components);
                }

            _writer.WriteLine(_components);

            for (var i = 1; i <= _components; i++)
            {
                var group = new List<int>();
                for (var j = 0; j < n; j++)
                {
                    if (_colors[j] == i)
                        group.Add(j + 1);
                }

                _writer.WriteLine(string.Join(' ', group));
            }

            _reader.Close();
            _writer.Close();
        }

        private static void Dfs(int v, int color)
        {
            _colors[v] = -1;
            var whiteVertices = _vertices[v]
                .Where(w => _colors[w] == 0);
            foreach (var w in whiteVertices)
                Dfs(w, color);
            _colors[v] = color;
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