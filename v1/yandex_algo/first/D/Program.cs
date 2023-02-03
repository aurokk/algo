using System;
using System.IO;
using System.Linq;

namespace D
{
    public static class D
    {
        private static TextReader _reader;
        private static TextWriter _writer;

        public static int GetResult(int[] temps)
        {
            var count = 0;
            for (var i = 0; i < temps.Length; i++)
            {
                var isFirst = i == 0;
                var isLast = i == temps.Length - 1;
                if ((isFirst || temps[i] > temps[i - 1]) &&
                    (isLast  || temps[i] > temps[i + 1]))
                {
                    count++;
                }
            }

            return count;
        }

        public static void Main(string[] args)
        {
            _reader = new StreamReader(Console.OpenStandardInput());
            _writer = new StreamWriter(Console.OpenStandardOutput());

            var ints = ReadIntLine();
            var temps = ReadLine();

            _writer.WriteLine(GetResult(temps));

            _reader.Close();
            _writer.Close();
        }

        private static int ReadIntLine()
        {
            var line = _reader.ReadLine();
            return int.Parse(line);
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