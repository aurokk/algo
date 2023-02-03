using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace K
{
    public static class K
    {
        private static TextReader _reader;
        private static TextWriter _writer;

        public static void Main(string[] args)
        {
            _reader = new StreamReader(Console.OpenStandardInput());
            _writer = new StreamWriter(Console.OpenStandardOutput());

            var n = ReadInt();
            var metro = new int[n][];
            for (var i = 0; i < n; i++)
            {
                metro[i] = ReadArray();
            }

            var m = ReadInt();
            var bus = new int[m][];
            for (var i = 0; i < m; i++)
            {
                bus[i] = ReadArray();
            }

            var sectors = new Dictionary<Tuple<int, int>, List<int[]>>();
            foreach (var bStop in bus)
            {
                var sectorX = (int) Math.Floor(bStop[0] / (double) 20);
                var sectorY = (int) Math.Floor(bStop[1] / (double) 20);
                var sectorXY = new Tuple<int, int>(sectorX, sectorY);
                if (sectors.ContainsKey(sectorXY))
                {
                    sectors[sectorXY].Add(bStop);
                }
                else
                {
                    sectors[sectorXY] = new List<int[]> {bStop};
                }
            }

            var index = -1;
            var maxStops = 0;
            for (var mIndex = 0; mIndex < metro.Length; mIndex++)
            {
                var mStop = metro[mIndex];
                var sectorX = (int) Math.Floor(mStop[0] / (double) 20);
                var sectorY = (int) Math.Floor(mStop[1] / (double) 20);

                var stops = 0;
                for (var i = sectorX - 1; i < sectorX + 2; i++)
                {
                    for (var j = sectorY - 1; j < sectorY + 2; j++)
                    {
                        var sectorXY = new Tuple<int, int>(i, j);
                        if (sectors.ContainsKey(sectorXY))
                        {
                            foreach (var bStop in sectors[sectorXY])
                            {
                                var xDistance = mStop[0] - bStop[0];
                                var yDistance = mStop[1] - bStop[1];
                                var distance = Math.Sqrt(Math.Pow(xDistance, 2) + Math.Pow(yDistance, 2));
                                if (distance <= 20)
                                {
                                    stops++;
                                }

                                if (stops > maxStops)
                                {
                                    index = mIndex;
                                    maxStops = stops;
                                }
                            }
                        }
                    }
                }
            }

            _writer.WriteLine(index + 1);

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