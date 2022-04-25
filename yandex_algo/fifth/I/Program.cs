using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace I
{
    public static class I
    {
        private static TextReader _reader;
        private static TextWriter _writer;

        private static readonly Dictionary<int, int> Cache = new Dictionary<int, int>
        {
            [0] = 1,
        };

        public static void Main(string[] args)
        {
            _reader = new StreamReader(Console.OpenStandardInput());
            _writer = new StreamWriter(Console.OpenStandardOutput());

            var n = ReadInt();
            for (var i = 1; i <= n; i++)
            {
                Cache[i] = CalculateCombinations(i);
            }

            _writer.WriteLine(Cache[n]);

            _reader.Close();
            _writer.Close();
        }

        private static int CalculateCombinations(int n)
        {
            var sum = 0;
            for (var i = 0; i < n; i++)
            {
                var j = n - i - 1;
                sum += Cache[i] * Cache[j];
            }

            return sum;
        }

        private static int ReadInt()
        {
            return int.Parse(_reader.ReadLine());
        }
    }
}