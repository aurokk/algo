using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace C
{
    public enum Color
    {
        White = 0,
        Gray = 1,
        Black = 2,
    }

    public static class C
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
            Dfs(s - 1);

            _writer.WriteLine(string.Join(' ', _result));

            _reader.Close();
            _writer.Close();
        }

        private static void Dfs(int startVertex)
        {
            var stack = new Stack<int>();
            stack.Push(startVertex);
            while (stack.Any())
            {
                var v = stack.Pop();
                switch (_colors[v])
                {
                    case Color.White:
                        _colors[v] = Color.Gray;
                        _result.Add(v + 1);
                        stack.Push(v);
                        var whiteVertices = _vertices[v]
                            .Where(w => _colors[w] == Color.White)
                            .OrderByDescending(x => x);
                        foreach (var w in whiteVertices)
                            stack.Push(w);
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