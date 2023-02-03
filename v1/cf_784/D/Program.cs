using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace D
{
    public static class D
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
                var a = _reader.ReadLine().ToCharArray();

                var isColored = false;
                var isRed = false;
                var isBlue = false;
                for (var i = 0; i < n; i++)
                {
                    switch (a[i])
                    {
                        case 'R':
                            isColored = true;
                            isRed = true;
                            break;
                        case 'B':
                            isColored = true;
                            isBlue = true;
                            break;
                        case 'W':
                            if (isColored && !(isBlue && isRed))
                            {
                                _writer.WriteLine("NO");
                                return;
                            }

                            isColored = false;
                            isBlue = false;
                            isRed = false;

                            break;
                    }
                }

                if (isColored && !(isBlue && isRed))
                {
                    _writer.WriteLine("NO");
                    return;
                }

                _writer.WriteLine("YES");
            }

            _reader.Close();
            _writer.Close();
        }

        private static int[] ReadArray() =>
            _reader.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
    }
}