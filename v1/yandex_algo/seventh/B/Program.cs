using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace B
{
    public record Interval(double Start, double End);

    public static class B
    {
        private static TextReader _reader;
        private static TextWriter _writer;

        public static void Main(string[] args)
        {
            _reader = new StreamReader(Console.OpenStandardInput());
            _writer = new StreamWriter(Console.OpenStandardOutput());

            var input = new List<Interval>();
            var output = new List<Interval>();

            // read input
            var nn = ReadArray();
            var n = nn[0];
            for (var i = 0; i < n; i++)
            {
                var data = ReadArray();
                var interval = new Interval(data[0], data[1]);
                input.Add(interval);
            }

            // process
            var start = -0.1;
            while (true)
            {
                var interval = input
                    .Where(x => x.Start >= start)
                    .OrderBy(x => x.End)
                    .ThenBy(x => x.Start)
                    .FirstOrDefault();

                if (interval == null)
                    break;

                start = interval.End;
                input.Remove(interval);
                output.Add(interval);
            }

            // write output
            _writer.WriteLine(output.Count);
            foreach (var interval in output)
                _writer.WriteLine($"{interval.Start} {interval.End}");

            _reader.Close();
            _writer.Close();
        }

        private static double[] ReadArray()
        {
            return _reader.ReadLine()
                .Split(' ')
                .Select(s => double.Parse(s, NumberStyles.AllowDecimalPoint))
                .ToArray();
        }
    }
}