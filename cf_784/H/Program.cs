using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace H
{
    public static class H
    {
        private static TextReader _reader;
        private static TextWriter _writer;

        public static void Main(string[] args)
        {
            _reader = new StreamReader(Console.OpenStandardInput());
            _writer = new StreamWriter(Console.OpenStandardOutput());


            int[] Search(string p, string text)
            {
                var result = new List<int>();
                var s = p + '#' + text;
                var n = new int[p.Length];
                var nPrev = 0;
                for (var i = 1; i < s.Length; i++)
                {
                    var k = nPrev;
                    while (k > 0 && s[k] != s[i])
                    {
                        k = n[k - 1];
                    }

                    if (s[k] == s[i])
                    {
                        k += 1;
                    }

                    if (i < p.Length)
                    {
                        n[i] = k;
                    }

                    nPrev = k;

                    if (k == p.Length)
                    {
                        result.Add(i - 2 * p.Length);
                    }
                }

                return result.ToArray();
            }

            var input = _reader.ReadLine();
            var pattern = _reader.ReadLine();
            var replace = _reader.ReadLine();
            var positions = Search(pattern, input);
            var positionsDict = positions.ToDictionary(x => x, _ => true);
            var i = 0;
            var result = new StringBuilder();
            while (i < input.Length)
            {
                if (positionsDict.ContainsKey(i))
                {
                    result.Append(replace);
                    i += pattern.Length;
                }
                else
                {
                    result.Append(input[i]);
                    i += 1;
                }
            }

            _writer.WriteLine(result.ToString());

            _reader.Close();
            _writer.Close();
        }
    }
}