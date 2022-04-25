using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace C
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

    public static class C
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

            try
            {
                var string1 = ReadCharArray();
                var string2 = ReadCharArray();
                var queue = new Queue<char>();
                foreach (var ch in string1)
                {
                    queue.Enqueue(ch);
                }

                if (queue.Any())
                {
                    foreach (var ch in string2)
                    {
                        if (queue.First() == ch)
                        {
                            queue.Dequeue();
                        }

                        if (!queue.Any())
                        {
                            break;
                        }
                    }
                }

                _writer.WriteLine(queue.Any() ? "False" : "True");
            }
            finally
            {
                _reader.Close();
                _writer.Close();
            }
        }

        private static char[] ReadCharArray()
        {
            return _reader.ReadLine().ToCharArray();
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