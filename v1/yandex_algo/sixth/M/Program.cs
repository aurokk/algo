using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace M
{
    public enum Side
    {
        None = 0,
        Left = 1,
        Right = 2,
    }

    public static class M
    {
        private static StreamReader _reader;
        private static StreamWriter _writer;

        private static Dictionary<int, SortedSet<int>> _vertices;
        private static Side[] _sides;
        private static bool _ok = true;

        public static void Main(string[] args)
        {
            _reader = new StreamReader(Console.OpenStandardInput());
            _writer = new StreamWriter(Console.OpenStandardOutput());

            var nm = ReadArray();
            var n = nm[0];
            var m = nm[1];

            _vertices = new Dictionary<int, SortedSet<int>>(n);
            for (var i = 0; i < n; i++)
                _vertices[i] = new SortedSet<int>();

            for (var i = 0; i < m; i++)
            {
                var ab = ReadArray();
                var a = ab[0] - 1;
                var b = ab[1] - 1;
                _vertices[a].Add(b);
                _vertices[b].Add(a);
            }

            _sides = new Side[n];

            foreach (var (key, _) in _vertices)
                if (_sides[key] == Side.None)
                    Dfs(key, Side.Left);

            _writer.WriteLine(_ok ? "YES" : "NO");

            _reader.Close();
            _writer.Close();
        }

        private static void Dfs(int v, Side side)
        {
            _sides[v] = side;

            foreach (var u in _vertices[v])
            {
                if (_sides[u] == Side.None)
                    Dfs(u, side == Side.Left ? Side.Right : Side.Left);
                else if (_sides[u] == side)
                    _ok = false;
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