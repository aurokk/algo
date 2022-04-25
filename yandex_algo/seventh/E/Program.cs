using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace E
{
    public static class E
    {
        private static TextReader _reader;
        private static TextWriter _writer;

        // public static void Main(string[] args)
        // {
        //     _reader = new StreamReader(Console.OpenStandardInput());
        //     _writer = new StreamWriter(Console.OpenStandardOutput());
        //
        //     var nn = ReadArray();
        //     var sum = nn[0];
        //
        //     var kk = ReadArray();
        //     var notes = kk[0];
        //
        //     var values = ReadArray();
        //     Array.Sort(values);
        //     Array.Reverse(values);
        //
        //     var dp = new int[notes + 1][];
        //     for (var i = 0; i < notes + 1; i++)
        //         dp[i] = new int[sum + 1];
        //
        //     for (var i = 1; i < notes + 1; i++)
        //     for (var j = 1; j < sum + 1; j++)
        //     {
        //         var note = values[i - 1];
        //         if (note > j)
        //             continue;
        //
        //         if (note == j)
        //         {
        //             dp[i][j] = 1;
        //             continue;
        //         }
        //
        //         dp[i][j] = dp[i - 1][j];
        //         for (var k = note; k <= j; k += note)
        //         {
        //             var diffCount = dp[i][j - k];
        //             if (diffCount > 0)
        //             {
        //                 dp[i][j] = dp[i][j] > 0
        //                     ? Math.Min(dp[i][j], diffCount + k / note)
        //                     : diffCount + k / note;
        //                 continue;
        //             }
        //         }
        //     }
        //
        //     // DEBUG ONLY
        //     // for (var i = 0; i < notes + 1; i++)
        //     //     _writer.WriteLine(string.Join("\t", dp[i]));
        //     // _writer.WriteLine();
        //
        //     _writer.WriteLine(dp[notes][sum] > 0 ? dp[notes][sum] : -1);
        //
        //     _reader.Close();
        //     _writer.Close();
        // }

        public static void Main(string[] args)
        {
            _reader = new StreamReader(Console.OpenStandardInput());
            _writer = new StreamWriter(Console.OpenStandardOutput());

            var nn = ReadArray();
            var sum = nn[0];

            var kk = ReadArray();
            var notes = kk[0];

            var values = ReadArray()
                .OrderByDescending(x => x)
                .ToArray();

            var dp = new int[sum + 1];
            for (var i = 0; i < sum + 1; i++)
            {
                for (var j = 0; j < notes; j++)
                {
                    var value = values[j];
                    if (value > i)
                        continue;

                    if (value == i)
                        dp[i] = 1;

                    for (var l = 1; l <= i; l++)
                    {
                        var multValue = l * value;
                        var diff = i - multValue;
                        if (diff < 0)
                            // Оптимизация
                            break;

                        var diffCount = dp[diff];
                        if (diffCount == 0)
                            // Нет диффа
                            continue;

                        if (dp[i] != 0 && l >= dp[i])
                            // Оптимизация
                            break;

                        dp[i] = dp[i] > 0
                            ? Math.Min(dp[i], l + diffCount)
                            : l + diffCount;
                    }
                }
            }

            // DEBUG ONLY
            // for (var i = 0; i < notes + 1; i++)
            //     _writer.WriteLine(string.Join("\t", dp[i]));
            // _writer.WriteLine();

            _writer.WriteLine(dp[sum]);

            _reader.Close();
            _writer.Close();
        }

        private static int[] ReadArray() =>
            _reader.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
    }
}