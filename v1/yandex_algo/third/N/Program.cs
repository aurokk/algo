using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace N
{
    public static class N
    {
        private static TextReader _reader;
        private static TextWriter _writer;

        public static string[] Sort(string[] input)
        {
            throw new NotImplementedException();
        }

        public static void Main(string[] args)
        {
            _reader = new StreamReader(Console.OpenStandardInput());
            _writer = new StreamWriter(Console.OpenStandardOutput());

            var n = ReadInt();
            var input = new int[n][];
            for (var i = 0; i < n; i++)
            {
                input[i] = ReadArray();
            }

            var sortedInput = input
                .OrderBy(x => x[0])
                .ThenBy(x => x[1])
                .ToArray();

            var start = sortedInput[0][0];
            var end = sortedInput[0][1];
            foreach (var elem in sortedInput)
            {
                if (elem[0] >= start && elem[0] <= end)
                {
                    if (elem[1] > end)
                    {
                        end = elem[1];
                    }
                }
                else
                {
                    _writer.WriteLine(start + " " + end);
                    start = elem[0];
                    end = elem[1];
                }
            }

            _writer.WriteLine(start + " " + end);

            // var results = new List<int[]>();
            // foreach (var elem in sortedInput)
            // {
            //     var match = results.FirstOrDefault(result => elem[0] >= result[0] && elem[0] <= result[1]);
            //     if (match != null)
            //     {
            //         if (elem[1] >= match[1])
            //         {
            //             match[1] = elem[1];
            //         }
            //     }
            //     else
            //     {
            //         results.Add(elem);
            //     }
            // }
            //
            // foreach (var result in results)
            // {
            //     _writer.WriteLine(string.Join(" ", result));
            // }

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