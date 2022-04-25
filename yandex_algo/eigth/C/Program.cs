using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace C
{
    public class Gold
    {
        public long PricePerKg { get; set; }
        public long Weight { get; set; }
    }

    public static class C
    {
        private static TextReader _reader;
        private static TextWriter _writer;

        public static void Main(string[] args)
        {
            _reader = new StreamReader(Console.OpenStandardInput());
            _writer = new StreamWriter(Console.OpenStandardOutput());

            var str = _reader.ReadLine();
            var chs = new SortedDictionary<char, int>();
            foreach (var ch in str)
                chs[ch] = chs.ContainsKey(ch)
                    ? chs[ch] + 1
                    : 1;

            var half = new List<char>();
            char? midCh = null;
            foreach (var (key, value) in chs)
            {
                if (value % 2 == 1 && midCh == null)
                    midCh = key;

                for (var i = 0; i < value / 2; i++)
                    half.Add(key);
            }

            var result = new StringBuilder();
            for (var i = 0; i < half.Count; i++)
                result.Append(half[i]);

            if (midCh != null)
                result.Append(midCh);

            for (var i = half.Count - 1; i >= 0; i--)
                result.Append(half[i]);

            _writer.WriteLine(result.ToString());

            _reader.Close();
            _writer.Close();
        }

        private static long[] ReadArray()
        {
            return _reader.ReadLine()
                .Split(' ')
                .Select(long.Parse)
                .ToArray();
        }
    }
}