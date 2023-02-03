using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace K
{
    public static class K
    {
        private static StreamReader _reader;
        private static StreamWriter _writer;

        public static void Main(string[] args)
        {
            _reader = new StreamReader(Console.OpenStandardInput());
            _writer = new StreamWriter(Console.OpenStandardOutput());

            var string1 = _reader.ReadLine();
            var string2 = _reader.ReadLine();

            var string1fixed = string.Join("", string1.Where(x => x % 2 == 0));
            var string2fixed = string.Join("", string2.Where(x => x % 2 == 0));

            var result = string1fixed.CompareTo(string2fixed);
            switch (result)
            {
                case 0:
                    _writer.WriteLine(0);
                    break;
                case > 0:
                    _writer.WriteLine(1);
                    break;
                case < 0:
                    _writer.WriteLine(-1);
                    break;
            }

            _reader.Close();
            _writer.Close();
        }
    }
}