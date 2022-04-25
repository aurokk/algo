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

            var wn = ReadArray(); // = cost = weight

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

                if (j - wn[i] >= 0)
                {
                    maxCurrent = i > 0 ? wn[i] + dp[i - 1][j - wn[i]] : wn[i];
                }


                dp[i][j] = Math.Max(maxPrevious, maxCurrent);
            }

            // DEBUG ONLY
            for (var i = 0; i < n; i++)
                _writer.WriteLine(string.Join("\t", dp[i]));
            _writer.WriteLine();
            _writer.WriteLine(dp[n - 1][m]);

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