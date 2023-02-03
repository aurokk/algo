using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace J
{
    public static class J
    {
        private static TextReader _reader;
        private static TextWriter _writer;

        public static void BubbleSort(int[] array)
        {
            for (var i = array.Length - 1; i > 0; i--)
            {
                var swapped = false;
                for (var j = 0; j < i; j++)
                {
                    var curElem = array[j];
                    var nextElem = array[j + 1];
                    if (curElem > nextElem)
                    {
                        swapped = true;
                        array[j] = nextElem;
                        array[j + 1] = curElem;
                    }
                }

                if (swapped || i == array.Length - 1)
                {
                    _writer.WriteLine(string.Join(" ", array));
                }
            }
        }

        public static void Main(string[] args)
        {
            _reader = new StreamReader(Console.OpenStandardInput());
            _writer = new StreamWriter(Console.OpenStandardOutput());

            ReadInt();
            var array = ReadArray();
            BubbleSort(array);

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