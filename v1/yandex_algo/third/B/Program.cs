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

        private static readonly Dictionary<char, char[]> Dict = new Dictionary<char, char[]>
        {
            {'2', new[] {'a', 'b', 'c'}},
            {'3', new[] {'d', 'e', 'f'}},
            {'4', new[] {'g', 'h', 'i'}},
            {'5', new[] {'j', 'k', 'l'}},
            {'6', new[] {'m', 'n', 'o'}},
            {'7', new[] {'p', 'q', 'r', 's'}},
            {'8', new[] {'t', 'u', 'v'}},
            {'9', new[] {'w', 'x', 'y', 'z'}},
        };

        public static void Combine(char[] input, int n, int length, string acc)
        {
            if (n == length)
            {
                _writer.Write(acc + " ");
                return;
            }

            var ic = input[n];
            var alphabet = Dict[ic];
            foreach (var ac in alphabet)
            {
                Combine(input, n + 1, length, acc + ac);
            }
        }

        public static void Main(string[] args)
        {
            _reader = new StreamReader(Console.OpenStandardInput());
            _writer = new StreamWriter(Console.OpenStandardOutput());

            var chars = ReadCharArray();
            Combine(chars, 0, chars.Length, string.Empty);

            _reader.Close();
            _writer.Close();
        }

        private static char[] ReadCharArray()
        {
            return _reader.ReadLine()
                .ToCharArray();
        }
    }
}