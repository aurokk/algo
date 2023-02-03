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

            var t = long.Parse(_reader.ReadLine());
            for (long i = 0; i < t; i++)
            {
                Check();
            }

            void Check()
            {
                var n = long.Parse(_reader.ReadLine());

                var diff = 'k' - 'a' + 1;

                var m = new int[diff][];
                for (var i = 0; i < diff; i++)
                    m[i] = new int[diff];

                long r = 0;
                for (var i = 0; i < n; i++)
                {
                    var pair = _reader.ReadLine();

                    var s = pair[0] - 'a';
                    var e = pair[1] - 'a';

                    for (var j = 0; j < 11; j++)
                    {
                        if (e != j)
                            r += m[s][j];
                    }

                    for (var j = 0; j < 11; j++)
                    {
                        if (s != j)
                            r += m[j][e];
                    }

                    m[s][e]++;
                }


                _writer.WriteLine(r);
            }

            _reader.Close();
            _writer.Close();
        }
    }
}