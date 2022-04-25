using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

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

            var s = _reader.ReadLine();
            var n = int.Parse(_reader.ReadLine());
            var ss = new Dictionary<int, string>();
            for (var i = 0; i < n; i++)
            {
                var tp = _reader.ReadLine().Split(' ');
                var t = tp[0];
                var p = int.Parse(tp[1]);
                ss.Add(p, t);
            }

            var sb = new StringBuilder();
            for (var i = 0; i < s.Length; i++)
            {
                if (ss.ContainsKey(i))
                {
                    sb.Append(ss[i]);
                }

                sb.Append(s[i]);
            }

            if (ss.ContainsKey(s.Length))
            {
                sb.Append(ss[s.Length]);
            }

            _writer.WriteLine(sb.ToString());

            _reader.Close();
            _writer.Close();
        }
    }
}