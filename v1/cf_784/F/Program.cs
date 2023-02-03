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

            var t = int.Parse(_reader.ReadLine());
            for (var i = 0; i < t; i++)
            {
                var n = int.Parse(_reader.ReadLine());
                var w = _reader.ReadLine().Split(' ').Select(int.Parse).ToArray();

                var i1 = 0;
                var i2 = w.Length - 1;

                var lw = 0;
                var l = 0;

                var rw = 0;
                var r = 0;

                while (i1 <= i2)
                {
                    if (lw > rw)
                    {
                        rw += w[i2];
                        i2--;
                    }
                    else
                    {
                        lw += w[i1];
                        i1++;
                    }

                    if (lw == rw)
                    {
                        l = i1;
                        r = (w.Length - 1) - i2;
                    }
                }
                
                _writer.WriteLine(l + r);
            }

            _reader.Close();
            _writer.Close();
        }
    }
}