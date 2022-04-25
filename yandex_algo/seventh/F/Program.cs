using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace F
{
    public static class F
    {
        private static TextReader _reader;
        private static TextWriter _writer;

        public static void Main(string[] args)
        {
            _reader = new StreamReader(Console.OpenStandardInput());
            _writer = new StreamWriter(Console.OpenStandardOutput());

            var nk = ReadArray();
            var n = nk[0];
            var k = nk[1];

            var dp = new long[n];
            for (long i = 1; i < n; i++)
            {
                var to = Math.Max(0, i - k);

                for (long j = i - 1; j >= to; j--)
                    dp[i] += dp[j];

                if (i <= k)
                    dp[i] += 1;

                dp[i] %= 1_000_000_007;
            }

            _writer.WriteLine(dp[n - 1]);
            _reader.Close();
            _writer.Close();
        }

        private static long[] ReadArray()
        {
            return _reader.ReadLine()
                .Split(' ')
                .Select(long.Parse)
                .ToArray();
        }
    }
}