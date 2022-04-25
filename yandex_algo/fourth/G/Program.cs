using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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

            var n = ReadInt();

            if (n == 0)
            {
                _writer.WriteLine(0);
            }
            else
            {
                var a = ReadArray();
                var r = new Dictionary<int, List<int>>
                {
                    [0] = new List<int>
                    {
                        0,
                    },
                };

                var sum = 0;
                for (var i = 0; i < n; i++)
                {
                    if (a[i] == 0)
                    {
                        sum -= 1;
                    }
                    else
                    {
                        sum += 1;
                    }

                    if (r.ContainsKey(sum))
                    {
                        r[sum].Add(i + 1);
                    }
                    else
                    {
                        r[sum] = new List<int> {i + 1};
                    }
                }

                var maxStreak = 0;
                foreach (var values in r.Values)
                {
                    var min = values.Min();
                    var max = values.Max();
                    var streak = max - min;
                    if (streak > maxStreak)
                    {
                        maxStreak = streak;
                    }
                }

                _writer.WriteLine(maxStreak);
            }

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