using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace F
{
    public static class F
    {
        private static TextReader _reader;
        private static TextWriter _writer;

        public static void Main(string[] args)
        {
            _reader = new StreamReader(Console.OpenStandardInput());
            _writer = new StreamWriter(Console.OpenStandardOutput());

            ReadInt();
            var strings = ReadArray();

            var results = new Dictionary<string, List<int>>();
            for (var i = 0; i < strings.Length; i++)
            {
                var itemChars = string.Join("", strings[i].ToCharArray().OrderBy(x => x));
                if (results.ContainsKey(itemChars))
                {
                    results[itemChars].Add(i);
                }
                else
                {
                    results[itemChars] = new List<int> {i};
                }
            }

            var groups = results.Values.OrderBy(x => x.First()).ToArray();
            foreach (var group in groups)
            {
                _writer.WriteLine(string.Join(" ", group));
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