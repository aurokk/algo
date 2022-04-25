using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace K
{
    public class K
    {
        private static TextReader _reader;
        private static TextWriter _writer;

        private static int GetFibonacci(int n)
        {
            if (n < 2)
            {
                return 1;
            }

            return (GetFibonacci(n - 1) + GetFibonacci(n - 2));
        }

        public static int GetResult(int n)
        {
            return GetFibonacci(n);
        }

        public static void Main(string[] args)
        {
            _reader = new StreamReader(Console.OpenStandardInput());
            _writer = new StreamWriter(Console.OpenStandardOutput());

            var n = ReadInt();
            _writer.WriteLine(string.Join(" ", GetResult(n)));

            _reader.Close();
            _writer.Close();
        }

        private static int ReadInt()
        {
            return int.Parse(_reader.ReadLine());
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