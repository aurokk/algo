// Решение: https://contest.yandex.ru/contest/22450/run-report/63977364/

using System;
using System.IO;
using System.Linq;

namespace B
{
    public static class B
    {
        private static TextReader _reader;
        private static TextWriter _writer;

        public static int Calculate(string[] inputStrings, int k)
        {
            var counts = new int[9];

            var characters = inputStrings
                .Select(x => x.ToCharArray())
                .SelectMany(x => x)
                .Where(x => x != '.')
                .Select(x => x - '0')
                .ToArray();

            foreach (var character in characters)
            {
                counts[character - 1] += 1;
            }

            return counts
                .Aggregate(0, (i, value) => 0 < value && value <= k * 2 ? i + 1 : i);
        }

        public static void Main(string[] args)
        {
            _reader = new StreamReader(Console.OpenStandardInput());
            _writer = new StreamWriter(Console.OpenStandardOutput());

            var k = ReadInt();
            var input = new[]
            {
                ReadLine(),
                ReadLine(),
                ReadLine(),
                ReadLine(),
            };
            _writer.WriteLine(string.Join(" ", Calculate(input, k)));

            _reader.Close();
            _writer.Close();
        }

        private static int ReadInt()
        {
            return int.Parse(_reader.ReadLine());
        }

        private static string ReadLine()
        {
            return _reader.ReadLine();
        }
    }
}