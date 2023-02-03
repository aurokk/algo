using System;
using System.Collections;
using System.IO;
using System.Linq;

namespace L
{
    public static class L
    {
        private static StreamReader _reader;
        private static StreamWriter _writer;

        public static void Main(string[] args)
        {
            _reader = new StreamReader(Console.OpenStandardInput());
            _writer = new StreamWriter(Console.OpenStandardOutput());

            var s = _reader.ReadLine();

            int[] Prefix(string s)
            {
                var result = new int[s.Length];

                for (var i = 1; i < s.Length; i++)
                {
                    var k = result[i - 1];

                    while (k > 0 && s[k] != s[i])
                    {
                        k = result[k - 1];
                    }

                    if (s[k] == s[i])
                    {
                        k += 1;
                    }

                    result[i] = k;
                }

                return result;
            }

            var result = Prefix(s);

            _writer.WriteLine(string.Join(" ", result));

            _reader.Close();
            _writer.Close();
        }
    }
}