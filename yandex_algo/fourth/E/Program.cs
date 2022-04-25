using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace E
{
    public static class E
    {
        private static TextReader _reader;
        private static TextWriter _writer;

        public static void Main(string[] args)
        {
            _reader = new StreamReader(Console.OpenStandardInput());
            _writer = new StreamWriter(Console.OpenStandardOutput());

            var maxLength = 0;
            var input = ReadString();
            for (var i = 0; i < input.Length; i++)
            {
                var check = new Dictionary<char, bool>();
                var length = 0;
                for (var j = i; j < input.Length; j++)
                {
                    if (check.ContainsKey(input[j]))
                    {
                        break;
                    }
                    else
                    {
                        length++;

                        if (length > maxLength)
                        {
                            maxLength = length;
                        }

                        check.Add(input[j], true);
                    }
                }
            }

            _writer.WriteLine(maxLength);

            _reader.Close();
            _writer.Close();
        }

        private static string ReadString()
        {
            return _reader.ReadLine();
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