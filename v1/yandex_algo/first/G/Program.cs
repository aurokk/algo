using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace G
{
    public static class F
    {
        private static TextReader _reader;
        private static TextWriter _writer;

        public static string GetResult(int number)
        {
            var result = new List<int>();
            var temp = number;
            while (temp > 1)
            {
                result.Add(temp % 2);
                temp /= 2;
            }
            result.Add(temp);
            result.Reverse();
            return string.Join(string.Empty, result);
        }

        public static void Main(string[] args)
        {
            _reader = new StreamReader(Console.OpenStandardInput());
            _writer = new StreamWriter(Console.OpenStandardOutput());

            var number = ReadLine();
            var result = GetResult(number);
            _writer.WriteLine(result);

            _reader.Close();
            _writer.Close();
        }

        private static int ReadLine()
        {
            return int.Parse(_reader.ReadLine());
        }
    }
}