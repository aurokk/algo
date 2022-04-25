using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

// ReSharper disable PossibleNullReferenceException

namespace G
{
    public static class G
    {
        private static TextReader _reader;
        private static TextWriter _writer;

        public static void Main(string[] args)
        {
            _reader = new StreamReader(Console.OpenStandardInput());
            _writer = new StreamWriter(Console.OpenStandardOutput());

            var mm = ReadArray();
            var m = mm[0];

            var nn = ReadArray();
            var n = nn[0];

            var values = ReadArray();

            var result = new Dictionary<LinkedList<int>, bool>();
            var count = 0;

            void Generate(LinkedList<int> previousPrefix, int previousSum)
            {
                for (var i = 0; i < n; i++)
                {
                    var value = values[i];
                    if (previousPrefix.Last != null && previousPrefix.Last.Value > value)
                    {
                        continue;
                    }

                    var sum = previousSum + value;
                    if (sum > m)
                    {
                        continue;
                    }

                    var prefix = new LinkedList<int>(previousPrefix);
                    prefix.AddLast(value);

                    if (sum == m)
                    {
                        // _writer.WriteLine(string.Join(" ", prefix));
                        count += 1;
                        result[prefix] = true;
                        continue;
                    }

                    if (sum < m)
                    {
                        Generate(prefix, sum);
                    }
                }
            }

            var prefix = new LinkedList<int>();
            Generate(prefix, 0);

            _writer.WriteLine(count);

            _reader.Close();
            _writer.Close();
        }

        private static int[] ReadArray() =>
            _reader.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
    }
}