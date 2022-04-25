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

        private static long[] GeneratePrefixes(int a, int m, char[] s)
        {
            var array = new long[s.Length + 1];

            array[0] = s[0];
            for (var i = 1; i < s.Length + 1; i++)
            {
                array[i] = (array[i - 1] * a + s[i - 1]) % m;
            }

            return array;
        }

        private static long[] GeneratePowersOfA(int a, int m, char[] s)
        {
            var array = new long[s.Length + 1];

            array[0] = 1;
            for (var i = 1; i < s.Length + 1; i++)
            {
                array[i] = (array[i - 1] * a) % m;
            }

            return array;
        }

        public static void Main(string[] args)
        {
            _reader = new StreamReader(Console.OpenStandardInput());
            _writer = new StreamWriter(Console.OpenStandardOutput());

            var a = ReadInt();
            var m = ReadInt();
            var s = ReadCharArray();
            var prefixes = GeneratePrefixes(a, m, s);
            var powersOfA = GeneratePowersOfA(a, m, s);

            // a    = 97
            // ab   = 97 * a1  +  98
            // abc  = 97 * a2  +  98 * a1  +  99
            // abcd = 97 * a3  +  98 * a2  +  99 * a1  +  100 * a0
            // 
            // c = abc - ab * a1 = 97 * a2  +  98 * a1  +  99 - 97 * a2  +  98 * a1 = 99
            // b = ab - a * a1 = 97 * a1  +  98 - 97 * a1 = 98

            var n = ReadInt();
            for (var i = 0; i < n; i++)
            {
                var range = ReadArray();
                var left = range[0];
                var right = range[1];
                var hashI = prefixes[left - 1];
                var hashJ = prefixes[right];
                var mult = powersOfA[right - left + 1];
                long result = (((hashJ - mult * hashI) % m) + m) % m;
                _writer.WriteLine(result);
            }

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

        private static string ReadString()
        {
            return _reader.ReadLine();
        }

        private static int[] ReadArray()
        {
            return _reader.ReadLine()
                .Split(new[] {' ', '\t',}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}