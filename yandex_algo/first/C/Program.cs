using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace C
{
    public static class C
    {
        private static TextReader _reader;
        private static TextWriter _writer;

        public static string GetResult(int[][] table, int row, int cell)
        {
            var results = new List<int>();

            if (row - 1 >= 0)
            {
                results.Add(table[row - 1][cell]);
            }

            if (row + 1 < table.Length)
            {
                results.Add(table[row + 1][cell]);
            }

            if (cell - 1 >= 0)
            {
                results.Add(table[row][cell - 1]);
            }

            if (cell + 1 < table[row].Length)
            {
                results.Add(table[row][cell + 1]);
            }

            results.Sort();

            return string.Join(" ", results);
        }

        public static void Main(string[] args)
        {
            _reader = new StreamReader(Console.OpenStandardInput());
            _writer = new StreamWriter(Console.OpenStandardOutput());

            var rows = ReadIntLine();
            var cells = ReadIntLine();
            var table = Enumerable
                .Range(0, rows)
                .Select(_ => ReadLine())
                .ToArray();
            var row = ReadIntLine();
            var cell = ReadIntLine();

            _writer.WriteLine(GetResult(table, row, cell));

            _reader.Close();
            _writer.Close();
        }

        private static int ReadIntLine()
        {
            var line = _reader.ReadLine();
            return int.Parse(line);
        }

        private static int[] ReadLine()
        {
            return _reader.ReadLine()
                .Split(new[] {' ', '\t',}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}