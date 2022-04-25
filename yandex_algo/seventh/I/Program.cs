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

        public static void Main(string[] args)
        {
            _reader = new StreamReader(Console.OpenStandardInput());
            _writer = new StreamWriter(Console.OpenStandardOutput());

            var nm = ReadSpacedArray();
            var n = nm[0];
            var m = nm[1];

            var reversedPath = new List<char>();

            var input = new int[n][];
            var output = new int[n][];
            for (var i = n - 1; i >= 0; i--)
            {
                input[i] = ReadStringArray();
                output[i] = new int[m];
            }

            for (var i = 0; i < n; i++)
            for (var j = 0; j < m; j++)
            {
                var left = j > 0 ? output[i][j - 1] : 0;
                var bottom = i > 0 ? output[i - 1][j] : 0;
                output[i][j] = Math.Max(left, bottom) + input[i][j];
            }

            var ii = n - 1;
            var jj = m - 1;

            while (ii != 0 || jj != 0)
            {
                var left = jj > 0 ? output[ii][jj - 1] : 0;
                var bottom = ii > 0 ? output[ii - 1][jj] : 0;

                if (bottom > left)
                {
                    reversedPath.Add('U');
                    if (ii > 0)
                        ii--;
                }
                else
                {
                    if (jj > 0)
                    {
                        reversedPath.Add('R');
                        jj--;
                    }
                    else
                    {
                        reversedPath.Add('U');
                        ii--;
                    }
                }
            }

            reversedPath.Reverse();

            _writer.WriteLine(output[n - 1][m - 1]);
            _writer.WriteLine(string.Join(string.Empty, reversedPath));

            _reader.Close();
            _writer.Close();
        }

        private static int[] ReadStringArray() =>
            _reader.ReadLine()
                .ToCharArray()
                .Select(x => x - '0')
                .ToArray();

        private static int[] ReadSpacedArray() =>
            _reader.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
    }
}