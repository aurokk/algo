using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace H
{
    public class Comparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            var a = x + y;
            var b = y + x;
            return string.Compare(a, b, StringComparison.Ordinal);
        }
    }

    public static class H
    {
        private static TextReader _reader;
        private static TextWriter _writer;

        public static string[] Sort(string[] input)
        {
            return input.OrderByDescending(x => x, new Comparer()).ToArray();
        }

        public static void Main(string[] args)
        {
            _reader = new StreamReader(Console.OpenStandardInput());
            _writer = new StreamWriter(Console.OpenStandardOutput());

            ReadInt();
            var array = ReadArray();
            var sortedArray = Sort(array);
            _writer.WriteLine(string.Join("", sortedArray));

            _reader.Close();
            _writer.Close();
        }

        private static int ReadInt()
        {
            return int.Parse(_reader.ReadLine());
        }

        private static string[] ReadArray()
        {
            return _reader.ReadLine()
                .Split(new[] {' ', '\t',}, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
        }
    }
}