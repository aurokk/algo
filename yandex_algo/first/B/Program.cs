using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace B
{
    public static class B
    {
        private static TextReader _reader;
        private static TextWriter _writer;

        private static int PositiveMod(int a, int b)
        {
            var result = a % b;
            return result < 0 ? result + b : result;
        }

        public static string GetResult(IEnumerable<int> ints)
        {
            var intsArray = ints.ToArray();
            var allEven = intsArray.All(x => PositiveMod(x, 2) == 0);
            var allOdd = intsArray.All(x => PositiveMod(x, 2) == 1);
            return allEven || allOdd ? "WIN" : "FAIL";
        }

        public static void Main(string[] args)
        {
            _reader = new StreamReader(Console.OpenStandardInput());
            _writer = new StreamWriter(Console.OpenStandardOutput());

            var ints = ReadList();
            _writer.WriteLine(GetResult(ints));

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