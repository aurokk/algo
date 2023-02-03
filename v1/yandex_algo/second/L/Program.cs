using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace L
{
    public class L
    {
        private static TextReader _reader;
        private static TextWriter _writer;


        private static int IntPow(int bas, int pow)
        {
            return Enumerable
                .Repeat(bas, pow)
                .Aggregate(1, (a, b) => a * b);
        }

        private static int GetFibonacci(int n, int k)
        {
            var mod = IntPow(10, k);
            var num2 = 1;
            if (n == 0)
            {
                return num2;
            }

            var num1 = 1;
            if (n == 1)
            {
                return num1;
            }

            var num = 0;
            for (var i = 2; i <= n; i++)
            {
                num = (num2 + num1) % mod;
                num2 = num1;
                num1 = num;
            }

            return num;
        }

        public static int GetResult(int n, int k)
        {
            return GetFibonacci(n, k);
        }

        public static void Main(string[] args)
        {
            _reader = new StreamReader(Console.OpenStandardInput());
            _writer = new StreamWriter(Console.OpenStandardOutput());

            var list = ReadList();
            _writer.WriteLine(string.Join(" ", GetResult(list[0], list[1])));

            _reader.Close();
            _writer.Close();
        }

        private static int ReadInt()
        {
            return int.Parse(_reader.ReadLine());
        }

        private static List<int> ReadList()
        {
            return _reader.ReadLine()
                .Split(new[] {' ', '\t',}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
        }
    }
}