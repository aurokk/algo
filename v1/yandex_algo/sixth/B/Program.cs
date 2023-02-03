using System;
using System.IO;
using System.Linq;

namespace B
{
    public static class B
    {
        private static TextReader _reader;
        private static TextWriter _writer;

        public static void Main(string[] args)
        {
            _reader = new StreamReader(Console.OpenStandardInput());
            _writer = new StreamWriter(Console.OpenStandardOutput());

            var nm = ReadArray();
            var n = nm[0];
            var m = nm[1];

            var result = new int[n][];
            for (var i = 0; i < n; i++)
                result[i] = new int[n];

            for (var i = 0; i < m; i++)
            {
                var ab = ReadArray();
                var a = ab[0];
                var b = ab[1];
                result[a - 1][b - 1] = 1;
            }

            for (var i = 0; i < n; i++)
                _writer.WriteLine(string.Join(' ', result[i]));

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