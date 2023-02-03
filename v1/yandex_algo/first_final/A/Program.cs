// Решение: https://contest.yandex.ru/contest/22450/run-report/63977141/

using System;
using System.IO;
using System.Linq;

namespace A
{
    public static class A
    {
        private static TextReader _reader;
        private static TextWriter _writer;

        public static int[] GetDistances(int[] array)
        {
            var results = new int[array.Length];
            var zeroIndexLeftToRight = -1;
            for (var i = 0; i < array.Length; i++)
            {
                if (array[i] == 0)
                {
                    zeroIndexLeftToRight = i;
                    results[i] = 0;
                    continue;
                }

                if (zeroIndexLeftToRight == -1)
                {
                    results[i] = int.MaxValue;
                    continue;
                }

                var distance = i - zeroIndexLeftToRight;
                results[i] = distance;
            }

            var zeroIndexRightToLeft = -1;
            for (var i = array.Length - 1; i >= 0; i--)
            {
                if (array[i] == 0)
                {
                    zeroIndexRightToLeft = i;
                    results[i] = 0;
                    continue;
                }

                if (zeroIndexRightToLeft == -1)
                {
                    continue;
                }

                var distance = zeroIndexRightToLeft - i;
                results[i] = Math.Min(distance, results[i]);
            }

            return results;
        }

        public static void Main(string[] args)
        {
            _reader = new StreamReader(Console.OpenStandardInput());
            _writer = new StreamWriter(Console.OpenStandardOutput());

            var n = ReadInt();
            var array = ReadList();
            _writer.WriteLine(string.Join(" ", GetDistances(array)));

            _reader.Close();
            _writer.Close();
        }

        private static int ReadInt()
        {
            return int.Parse(_reader.ReadLine());
        }

        private static int[] ReadList()
        {
            return _reader.ReadLine()
                .Split(new[] {' ', '\t',}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}