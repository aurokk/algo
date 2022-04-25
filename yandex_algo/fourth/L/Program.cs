using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace L
{
    public static class L
    {
        private static TextReader _reader;
        private static TextWriter _writer;

        private static int[] _qPows1;
        private static int[] _qPows2;

        private static long[] GeneratePrefixes(int a, int m, string s)
        {
            var array = new long[s.Length + 1];

            array[0] = s[0];
            for (var i = 1; i < s.Length + 1; i++)
            {
                array[i] = (array[i - 1] * a + s[i - 1]) % m;
            }

            return array;
        }

        private static long[] GeneratePowersOfA(int a, int m, int n)
        {
            var array = new long[n + 1];

            array[0] = 1;
            for (var i = 1; i < n + 1; i++)
            {
                array[i] = (array[i - 1] * a) % m;
            }

            return array;
        }

        public static void Main(string[] args)
        {
            _reader = new StreamReader(Console.OpenStandardInput());
            _writer = new StreamWriter(Console.OpenStandardOutput());

            var nk = ReadArray();
            var n = nk[0];
            var k = nk[1];
            var s = ReadString();

            var a1 = 133337;
            var a2 = 1334339;
            var m1 = 10000000;
            var m2 = 10000000;

            var prefixes1 = GeneratePrefixes(a1, m1, s);
            var powersOfA1 = GeneratePowersOfA(a1, m1, n);

            var prefixes2 = GeneratePrefixes(a2, m2, s);
            var powersOfA2 = GeneratePowersOfA(a2, m2, n);

            var check = new Dictionary<Tuple<long, long>, List<int>>();

            for (var i = 0; i < s.Length - n; i++)
            {
                var left = i;
                var right = i + n;

                var hashI1 = prefixes1[left];
                var hashJ1 = prefixes1[right];
                var mult1 = powersOfA1[right - left];
                long hash1 = (((hashJ1 - mult1 * hashI1) % m1) + m1) % m1;

                var hashI2 = prefixes2[left];
                var hashJ2 = prefixes2[right];
                var mult2 = powersOfA2[right - left];
                long hash2 = (((hashJ2 - mult2 * hashI2) % m2) + m2) % m2;

                var key = new Tuple<long, long>(hash1, hash2);
                if (check.ContainsKey(key))
                {
                    check[key].Add(i);
                }
                else
                {
                    check[key] = new List<int> {i};
                }
            }

            var results = new List<int>();
            foreach (var value in check.Values)
            {
                if (value.Count >= k)
                {
                    results.Add(value[0]);
                }
            }

            _writer.WriteLine(string.Join(" ", results));

            _reader.Close();
            _writer.Close();
        }

        private static int ReadInt()
        {
            return int.Parse(_reader.ReadLine());
        }

        private static int[] ReadArray()
        {
            return _reader.ReadLine()
                .Split(new[] {' ', '\t',}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }

        private static string ReadString()
        {
            return _reader.ReadLine();
        }
    }
}