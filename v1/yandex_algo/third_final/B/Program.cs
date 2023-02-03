using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace A
{
    public class TupleComparator : IComparer<Tuple<string, int, int>>
    {
        public int Compare(Tuple<string, int, int> a, Tuple<string, int, int> b)
        {
            // a  < b — -1
            // a == b —  0
            // a  > b —  1
            if (a == null)
            {
                return 1;
            }

            if (b == null)
            {
                return -1;
            }

            if (a.Item2 > b.Item2
                || (a.Item2 == b.Item2 && a.Item3 < b.Item3)
                || (a.Item2 == b.Item2 && a.Item3 == b.Item3 && string.CompareOrdinal(a.Item1, b.Item1) < 0))
            {
                return 1;
            }
            else if (a.Item2 == b.Item2 && a.Item3 == b.Item3 && string.CompareOrdinal(a.Item1, b.Item1) == 0)
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }
    }

    public static class A
    {
        private static TextReader _reader;
        private static TextWriter _writer;

        private static readonly Random Random = new Random();
        private static readonly TupleComparator Comparator = new TupleComparator();

        public static void QuickSort(Tuple<string, int, int>[] data, int start, int end)
        {
            if (end - start < 2)
            {
                return;
            }

            var pivotIndex = Random.Next(start, end);
            var pivot = data[pivotIndex];

            var left = start;
            var right = end - 1;

            while (left != right)
            {
                if (Comparator.Compare(pivot, data[left]) > 0)
                {
                    left++;
                }
                else if (Comparator.Compare(data[right], pivot) > 0)
                {
                    right--;
                }
                else
                {
                    var dummy = data[left];
                    data[left] = data[right];
                    data[right] = dummy;
                }
            }

            QuickSort(data, start, left);
            QuickSort(data, left, end);
        }

        public static void Main(string[] args)
        {
            _reader = new StreamReader(Console.OpenStandardInput());
            _writer = new StreamWriter(Console.OpenStandardOutput());

            var n = ReadInt();
            var data = new Tuple<string, int, int>[n];
            for (var i = 0; i < n; i++)
            {
                var array = ReadArray();
                data[i] = new Tuple<string, int, int>(array[0], int.Parse(array[1]), int.Parse(array[2]));
            }

            QuickSort(data, 0, n);

            for (int i = n - 1; i >= 0; i--)
            {
                _writer.WriteLine(data[i].Item1);
            }

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