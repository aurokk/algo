using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace A
{
    public static class A
    {
        private static TextReader _reader;
        private static TextWriter _writer;

        public static void Generate(int n, int m, string acc)
        {
            if (n == 0 && m == 0)
            {
                _writer.WriteLine(acc);
                return;
            }

            if (n > 0)
            {
                Generate(n - 1, m + 1, acc + "(");
            }

            if (m > 0)
            {
                Generate(n, m - 1, acc + ")");
            }
        }

        public static void Main(string[] args)
        {
            _reader = new StreamReader(Console.OpenStandardInput());
            _writer = new StreamWriter(Console.OpenStandardOutput());

            var n = ReadInt();
            Generate(n, 0, string.Empty);

            // var one = BinSearch(array, price, 0, array.Length);
            // var two = BinSearch(array, price * 2, 0, array.Length);
            // _writer.WriteLine(one + " " + two);

            _reader.Close();
            _writer.Close();
        }

        private static int ReadInt()
        {
            return int.Parse(_reader.ReadLine());
        }

        private static int[] ReadArray()
        {
            return _reader.ReadLine()
                .Split(new[] {' ', '\t',}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}