using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace O
{
    public static class O
    {
        private static StreamReader _reader;
        private static StreamWriter _writer;

        public static void Main(string[] args)
        {
            _reader = new StreamReader(Console.OpenStandardInput());
            _writer = new StreamWriter(Console.OpenStandardOutput());

            const long mod = 1_000_000_007;

            var nm = ReadArray();
            var n = nm[0];
            var m = nm[1];

            var g = new List<int>[n];
            for (var i = 0; i < n; i++)
                g[i] = new List<int>();

            for (var i = 0; i < m; i++)
            {
                var se = ReadArray();
                var start = se[0] - 1;
                var end = se[1] - 1;
                g[end].Add(start);
            }

            var w = new bool[n];
            var d = new long[n];

            long Count(int v)
            {
                if (w[v])
                    return d[v];

                w[v] = true;
                long sum = 0;
                foreach (var c in g[v])
                    sum = (sum + Count(c)) % mod;

                d[v] = sum;
                return sum;
            }

            long CountPaths(int s, int t)
            {
                d[s] = 1;
                w[s] = true;
                var answer = Count(t);
                return answer;
            }

            var ab = ReadArray();
            var a = ab[0] - 1;
            var b = ab[1] - 1;
            var result = CountPaths(a, b);

            _writer.WriteLine(result);
            _reader.Close();
            _writer.Close();
        }

        private static int[] ReadArray() =>
            _reader.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
    }
}