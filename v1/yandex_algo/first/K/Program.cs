using System;
using System.IO;
using System.Linq;

namespace K
{
    public static class K
    {
        private static TextReader _reader;
        private static TextWriter _writer;

        public static string GetResult(int[] num1Arr, int[] num2Arr)
        {
            var num1 = int.Parse(string.Join(string.Empty, num1Arr));
            var num2 = num2Arr.First();
            var result = num1 + num2;
            return string.Join(" ", result.ToString().ToCharArray());
        }

        public static void Main(string[] args)
        {
            _reader = new StreamReader(Console.OpenStandardInput());
            _writer = new StreamWriter(Console.OpenStandardOutput());

            ReadLine();
            var num1 = ReadLine();
            var num2 = ReadLine();
            var result = GetResult(num1, num2);
            _writer.WriteLine(result);

            _reader.Close();
            _writer.Close();
        }

        private static int[] ReadLine()
        {
            return _reader.ReadLine()
                .Split(new[] {' ', '\t',}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}