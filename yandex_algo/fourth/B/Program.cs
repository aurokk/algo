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

        private static readonly Random Random = new Random();

        public static string RandomString(int length)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyz";
            return new string(Enumerable.Repeat(chars, Random.Next(1, length))
                .Select(s => s[Random.Next(s.Length)]).ToArray());
        }

        public static void Main(string[] args)
        {
            _reader = new StreamReader(Console.OpenStandardInput());
            _writer = new StreamWriter(Console.OpenStandardOutput());

            var s1 = "1";
            var s2 = "2";
            var hash1 = 1;
            var hash2 = 2;
            while (true)
            {
                s1 = RandomString(20);
                s2 = RandomString(20);
                hash1 = CalculateHash(1000, 123987123, s1.ToCharArray());
                hash2 = CalculateHash(1000, 123987123, s2.ToCharArray());
                if (s1 != s2 && hash1 == hash2)
                {
                    break;
                }
            }

            _writer.WriteLine(s1);
            _writer.WriteLine(s2);
            _writer.WriteLine(hash1);
            _writer.WriteLine(hash2);

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
    }
}