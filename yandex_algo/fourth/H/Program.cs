using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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

            try
            {
                var s1 = ReadCharArray();
                var s2 = ReadCharArray();

                if (s1.Length != s2.Length)
                {
                    _writer.WriteLine("NO");
                    return;
                }

                // agg
                // xda

                var d1 = new Dictionary<char, char>();
                var d2 = new Dictionary<char, char>();
                for (var i = 0; i < s2.Length; i++)
                {
                    var s1c = s1[i];
                    var s2c = s2[i];

                    if (!d1.ContainsKey(s1c))
                    {
                        d1[s1c] = s2c;
                    }

                    if (!d2.ContainsKey(s2c))
                    {
                        d2[s2c] = s1c;
                    }

                    if (d1[s1c] != s2c || d2[s2c] != s1c)
                    {
                        _writer.WriteLine("NO");
                        return;
                    }
                }

                _writer.WriteLine("YES");
            }
            finally
            {
                _reader.Close();
                _writer.Close();
            }
        }

        private static char[] ReadCharArray()
        {
            return _reader.ReadLine()
                .ToCharArray();
        }
    }
}