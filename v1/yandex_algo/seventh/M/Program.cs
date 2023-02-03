using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace M
{
    public static class M
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

            var weight = new int[n];
            var cost = new int[n];

            for (var i = 0; i < n; i++)
            {
                var wc = ReadArray();
                var w = wc[0];
                var c = wc[1];
                weight[i] = w;
                cost[i] = c;
            }

            var dp = new int[n][];
            for (var i = 0; i < n; i++)
                dp[i] = new int[m + 1];

            for (var i = 0; i < n; i++)
            for (var j = 0; j < m + 1; j++)
            {
                var maxPrevious = 0;
                var maxCurrent = 0;

                if (i > 0)
                {
                    maxPrevious = dp[i - 1][j];
                }

                if (j - weight[i] >= 0)
                {
                    maxCurrent = i > 0 ? cost[i] + dp[i - 1][j - weight[i]] : cost[i];
                }


                dp[i][j] = Math.Max(maxPrevious, maxCurrent);
            }

            // DEBUG ONLY
            // for (var i = 0; i < n; i++)
            //     _writer.WriteLine(string.Join("\t", dp[i]));
            // _writer.WriteLine();

            // _writer.WriteLine(dp[n - 1][m]);

            var items = new List<int>();
            var ii = n - 1;
            var jj = m;
            while (jj > 0 && ii >= 0)
            {
                var curr = dp[ii][jj];
                var left = dp[ii][jj - 1];
                if (ii - 1 >= 0)
                {
                    var top = dp[ii - 1][jj];
                    if (top == curr)
                    {
                        ii -= 1;
                        continue;
                    }
                }

                if (left == curr)
                {
                    jj -= 1;
                    continue;
                }

                items.Add(ii + 1);
                jj -= weight[ii];
                ii -= 1;
            }

            _writer.WriteLine(items.Count);
            _writer.WriteLine(string.Join(" ", items));

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