using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace D
{
    public enum Color
    {
        White = 0,
        Gray = 1,
        Black = 2,
    }

    public static class D
    {
        private static TextReader _reader;
        private static TextWriter _writer;

        private static SortedSet<int>[] _vertices;
        private static Color[] _colors;
        private static List<int> _result;

        public static void Main(string[] args)
        {
            _reader = new StreamReader(Console.OpenStandardInput());
            _writer = new StreamWriter(Console.OpenStandardOutput());

            var nm = ReadArray();
            var n = nm[0];
            var m = nm[1];

            _result = new List<int>();

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

            _colors = new Color[n];

            var ss = ReadArray();
            var s = ss[0];
            Bfs(s - 1);

            _writer.WriteLine(string.Join(' ', _result));

            _reader.Close();
            _writer.Close();
        }

        private static void Bfs(int startVertex)
        {
            var queue = new Queue<int>();
            queue.Enqueue(startVertex);
            while (queue.Any())
            {
                var v = queue.Dequeue();
                switch (_colors[v])
                {
                    case Color.White:
                        _result.Add(v + 1);
                        _colors[v] = Color.Gray;
                        var whiteVertices = _vertices[v]
                            .Where(w => _colors[w] == Color.White);
                        foreach (var w in whiteVertices)
                            queue.Enqueue(w);
                        break;

                    case Color.Gray:
                        _colors[v] = Color.Black;
                        break;
                }
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