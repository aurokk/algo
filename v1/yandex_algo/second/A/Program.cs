using System;
using System.IO;
using System.Linq;

namespace A
{
    public class A
    {
        private static TextReader _reader;
        private static TextWriter _writer;

        public static int[][] Transpose(int[][] table, int n, int m)
        {
            var result = new int[m][];
            for (var i = 0; i < m; i++)
            {
                result[i] = new int[n];
            }

            for (var i = 0; i < n; i++)
            {
                for (var j = 0; j < m; j++)
                {
                    result[j][i] = table[i][j];
                }
            }

            return result;
        }

        public static void Main(string[] args)
        {
            _reader = new StreamReader(Console.OpenStandardInput());
            _writer = new StreamWriter(Console.OpenStandardOutput());

            var n = ReadInt();
            var m = ReadInt();

            var table = new int[n][];
            for (var i = 0; i < n; i++)
            {
                table[i] = ReadArray();
            }

            var transposedTable = Transpose(table, n, m);
            for (var i = 0; i < m; i++)
            {
                _writer.WriteLine(string.Join(" ", transposedTable[i]));
            }

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