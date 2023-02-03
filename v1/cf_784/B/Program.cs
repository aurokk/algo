using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace B
{
    public static class B
    {
        private static TextReader _reader;
        private static TextWriter _writer;

        public static void Main(string[] args)
        {
            _reader = new StreamReader(Console.OpenStandardInput());
            _writer = new StreamWriter(Console.OpenStandardOutput());

            var t = int.Parse(_reader.ReadLine());
            for (var i = 0; i < t; i++)
                FindTriplet();

            void FindTriplet()
            {
                var n = int.Parse(_reader.ReadLine());
                var a = _reader.ReadLine().Split(' ').Select(int.Parse).ToArray();
                var r = new Dictionary<int, int>();
                for (var j = 0; j < n; j++)
                {
                    if (r.ContainsKey(a[j]) && r[a[j]] == 2)
                    {
                        _writer.WriteLine(a[j]);
                        return;
                    }

                    if (r.ContainsKey(a[j]))
                        r[a[j]] += 1;
                    else
                        r[a[j]] = 1;
                }

                _writer.WriteLine("-1");
            }

            _reader.Close();
            _writer.Close();
        }
    }
}