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

        public static int GetY(int a, int b, int c, int x)
        {
            return a * x * x + b * x + c;
        }

        public static void Main(string[] args)
        {
            _reader = new StreamReader(Console.OpenStandardInput());
            _writer = new StreamWriter(Console.OpenStandardOutput());

            var ints = ReadList();
            _writer.WriteLine(GetY(ints[0], ints[2], ints[3], ints[1]));

            _reader.Close();
            _writer.Close();
        }

        private static List<int> ReadList()
        {
            return _reader.ReadLine()
                .Split(new[] {' ', '\t',}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
        }
    }
}