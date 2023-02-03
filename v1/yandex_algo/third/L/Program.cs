using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace L
{
    public static class L
    {
        private static TextReader _reader;
        private static TextWriter _writer;

        public static int BinSearch(int[] arr, int price, int left, int right)
        {
            if (left + 1 == right)
            {
                var leftElement = arr[left];
                if (leftElement >= price)
                {
                    return left + 1;
                }
                else if (right < arr.Length)
                {
                    return right + 1;
                }
                else
                {
                    return -1;
                }
            }

            var mid = (int) Math.Floor((left + right) / 2m);
            var element = arr[mid];
            if (element >= price)
            {
                return BinSearch(arr, price, left, mid);
            }
            else
            {
                return BinSearch(arr, price, mid, right);
            }
        }

        public static void Main(string[] args)
        {
            _reader = new StreamReader(Console.OpenStandardInput());
            _writer = new StreamWriter(Console.OpenStandardOutput());

            ReadInt();

            var array = ReadArray();
            var price = ReadInt();

            var one = BinSearch(array, price, 0, array.Length);
            var two = BinSearch(array, price * 2, 0, array.Length);
            _writer.WriteLine(one + " " + two);

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