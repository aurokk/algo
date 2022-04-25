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

            var t = int.Parse(_reader.ReadLine());
            for (var i = 0; i < t; i++)
            {
                var nm = _reader.ReadLine().Split(' ').Select(int.Parse).ToArray();
                var n = nm[0];
                var m = nm[1];

                var matrix = new char[n][];
                for (var j = 0; j < n; j++)
                    matrix[j] = _reader.ReadLine().ToCharArray();

                for (var j = m - 1; j >= 0; j--)
                {
                    for (var k = n - 1; k >= 0; k--)
                    {
                        if (matrix[k][j] != '.')
                        {
                            continue;
                        }

                        for (var l = k - 1; l >= 0; l--)
                        {
                            if (matrix[l][j] == '*')
                            {
                                matrix[k][j] = '*';
                                matrix[l][j] = '.';
                                break;
                            }

                            if (matrix[l][j] == 'o')
                            {
                                k = l;
                                break;
                            }
                        }
                    }
                }

                for (var j = 0; j < n; j++)
                    _writer.WriteLine(string.Join(string.Empty, matrix[j]));
            }


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