using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace A
{
    public static class A
    {
        private static TextReader _reader;
        private static TextWriter _writer;

        public static int CalculateHash(int a, int m, char[] s)
        {
            if (s.Length == 0)
            {
                return 0;
            }
            
            long hash = s[0];

            for (var i = 1; i < s.Length; i++)
            {
                hash = (hash * a + s[i]) % m;
            }

            return (int) hash;
        }

        public static void Main(string[] args)
        {
            _reader = new StreamReader(Console.OpenStandardInput());
            _writer = new StreamWriter(Console.OpenStandardOutput());

            var a = ReadInt();
            var m = ReadInt();
            var s = ReadCharArray();
            var hash = CalculateHash(a, m, s);

            _writer.WriteLine(hash);

            // var one = BinSearch(array, price, 0, array.Length);
            // var two = BinSearch(array, price * 2, 0, array.Length);
            // _writer.WriteLine(one + " " + two);

            _reader.Close();
            _writer.Close();
        }

        private static int ReadInt()
        {
            return int.Parse(_reader.ReadLine());
        }

        private static char[] ReadCharArray()
        {
            return _reader.ReadLine()
                .ToCharArray();
        }
    }
}