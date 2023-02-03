using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace F
{
    public enum Color
    {
        White = 0,
        Gray = 1,
        Black = 2,
    }

    public static class F
    {
        private static TextReader _reader;
        private static TextWriter _writer;

        private static SortedSet<int>[] _vertices;
        private static Color[] _colors;
        private static int[] _previous;
        private static int[] _distances;

        public static void Main(string[] args)
        {
            _reader = new StreamReader(Console.OpenStandardInput());
            _writer = new StreamWriter(Console.OpenStandardOutput());

            var nm = ReadArray();
            var n = nm[0];
            var m = nm[1];

            _previous = new int[n];
            _distances = new int[n];
            for (var i = 0; i < n; i++)
                _distances[i] = -1;
            _vertices = new SortedSet<int>[n];
            _colors = new Color[n];

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

            var se = ReadArray();
            var s = se[0] - 1;
            var e = se[1] - 1;
            Bfs(s);

            _writer.WriteLine(_distances[e]);

            _reader.Close();
            _writer.Close();
        }

        private static void Bfs(int startVertex)
        {
            var queue = new Queue<int>();
            queue.Enqueue(startVertex);
            _colors[startVertex] = Color.Gray;
            _distances[startVertex] = 0;
            while (queue.Any())
            {
                var v = queue.Dequeue();
                var whiteVertices = _vertices[v].Where(w => _colors[w] == Color.White);
                foreach (var w in whiteVertices)
                {
                    queue.Enqueue(w);
                    _colors[w] = Color.Gray;
                    _previous[w] = v;
                    _distances[w] = _distances[v] + 1;
                }

                _colors[v] = Color.Black;
            }
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