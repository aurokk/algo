using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace C
{
    public class Gold
    {
        public long PricePerKg { get; set; }
        public long Weight { get; set; }
    }

    public static class C
    {
        private static TextReader _reader;
        private static TextWriter _writer;

        public static void Main(string[] args)
        {
            _reader = new StreamReader(Console.OpenStandardInput());
            _writer = new StreamWriter(Console.OpenStandardOutput());

            var rr = ReadArray();
            var nn = ReadArray();
            var golds = new List<Gold>();

            long n = nn[0];
            for (long i = 0; i < n; i++)
            {
                var t = ReadArray();
                golds.Add(new Gold {PricePerKg = t[0], Weight = t[1],});
            }

            long maxWeight = rr[0];
            long price = 0;
            long weight = 0;

            while (true)
            {
                var t = golds
                    .Where(x => x.Weight > 0)
                    .OrderByDescending(x => x.PricePerKg)
                    .FirstOrDefault();
                if (t == null)
                    break;
                long weightDiff = Math.Min(maxWeight - weight, t.Weight);
                t.Weight -= weightDiff;
                weight += weightDiff;
                price += t.PricePerKg * weightDiff;
                if (weight == maxWeight)
                    break;
            }

            _writer.WriteLine(price);
            _reader.Close();
            _writer.Close();
        }

        private static long[] ReadArray()
        {
            return _reader.ReadLine()
                .Split(' ')
                .Select(long.Parse)
                .ToArray();
        }
    }
}