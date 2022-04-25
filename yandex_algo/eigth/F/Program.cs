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


            var n = int.Parse(_reader.ReadLine());
            var d = new Dictionary<string, int>();
            for (var i = 0; i < n; i++)
            {
                var s = _reader.ReadLine();
                d[s] = d.ContainsKey(s) ? d[s] + 1 : 1;
            }

            var answer = d.OrderByDescending(x => x.Value).ThenBy(x => x.Key).First().Key;
            _writer.WriteLine(answer);

            _reader.Close();
            _writer.Close();
        }
    }
}