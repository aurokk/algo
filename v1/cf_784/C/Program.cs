using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace C
{
    public static class C
    {
        private static TextReader _reader;
        private static TextWriter _writer;

        public static void Main(string[] args)
        {
            _reader = new StreamReader(Console.OpenStandardInput());
            _writer = new StreamWriter(Console.OpenStandardOutput());

            var t = int.Parse(_reader.ReadLine());
            for (var i = 0; i < t; i++)
            {
                Check();
            }

            void Check()
            {
                var n = int.Parse(_reader.ReadLine());
                var a = _reader.ReadLine().Split(' ').Select(int.Parse).ToArray();
                var first = a[0] % 2;
                var second = a[1] % 2;
                for (var j = 2; j < n; j++)
                {
                    if ((j % 2 == 0 && a[j] % 2 != first) || (j % 2 == 1 && a[j] % 2 != second))
                    {
                        _writer.WriteLine("NO");
                        return;
                    }
                }

                _writer.WriteLine("YES");
            }

            _reader.Close();
            _writer.Close();
        }
    }
}