using System;
using System.Collections;
using System.IO;
using System.Linq;

namespace L
{
    public static class L
    {
        private static StreamReader _reader;
        private static StreamWriter _writer;

        public static void Main(string[] args)
        {
            _reader = new StreamReader(Console.OpenStandardInput());
            _writer = new StreamWriter(Console.OpenStandardOutput());

            var nm = ReadArray();
            var n = nm[0];
            var m = nm[1];

            long sum = 0;
            for (var i = 1; i < n; i++)
                sum += i;

            if (m < sum)
            {
                _writer.WriteLine("NO");
                _reader.Close();
                _writer.Close();
                return;
            }

            var edges = new BitArray[n];
            for (var i = 0; i < n; i++)
                edges[i] = new BitArray(i);

            for (var i = 0; i < m; i++)
            {
                var ab = ReadArray();
                var a = ab[0] - 1;
                var b = ab[1] - 1;
                if (a == b)
                    continue;
                var l = a > b ? a : b;
                var r = a > b ? b : a;
                edges[l][r] = true;
            }

            for (var i = 0; i < n; i++)
            for (var j = 0; j < i; j++)
                if (edges[i][j] == false)
                {
                    _writer.WriteLine("NO");
                    _reader.Close();
                    _writer.Close();
                    return;
                }

            _writer.WriteLine("YES");
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