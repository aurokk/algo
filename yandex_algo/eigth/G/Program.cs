using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

// ReSharper disable PossibleNullReferenceException

namespace G
{
    public static class G
    {
        private static TextReader _reader;
        private static TextWriter _writer;

        public static void Main(string[] args)
        {
            _reader = new StreamReader(Console.OpenStandardInput());
            _writer = new StreamWriter(Console.OpenStandardOutput());

            var n = ReadInt();
            var xi = ReadArray();

            var m = ReadInt();
            var ai = ReadArray();

            var xid = new int[n];
            for (var i = 1; i < n; i++)
            {
                xid[i] = xi[i] - xi[i - 1];
            }

            var aid = new int[m];
            for (var i = 1; i < m; i++)
            {
                aid[i] = ai[i] - ai[i - 1];
            }

            var res = new List<int>(0);
            for (var i = 0; i < n; i++)
            {
                var match = true;

                for (var j = 0; j < m; j++)
                {
                    if (j == 0)
                    {
                        continue;
                    }

                    if (i + j >= xid.Length)
                    {
                        match = false;
                        break;
                    }

                    if (xid[i + j] != aid[j])
                    {
                        match = false;
                        break;
                    }
                }

                if (match)
                {
                    res.Add(i + 1);
                }
            }

            _writer.WriteLine(string.Join(" ", res));

            _reader.Close();
            _writer.Close();
        }

        private static int ReadInt() =>
            int.Parse(_reader.ReadLine());

        private static int[] ReadArray() =>
            _reader.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
    }
}