using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace D
{
    public static class D
    {
        private static TextReader _reader;
        private static TextWriter _writer;

        public static void Main(string[] args)
        {
            _reader = new StreamReader(Console.OpenStandardInput());
            _writer = new StreamWriter(Console.OpenStandardOutput());

            var nm = ReadArray();
            var n = nm[0];

            var dp = new int[n + 1];
            dp[0] = dp[1] = 1;

            for (var i = 2; i < n + 1; i++)
                dp[i] = (dp[i - 2] + dp[i - 1]) % 1_000_000_007;

            _writer.WriteLine(dp[n]);

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