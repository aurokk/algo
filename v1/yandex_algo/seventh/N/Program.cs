using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace N
{
    public static class N
    {
        private static StreamReader _reader;
        private static StreamWriter _writer;

        public static void Main(string[] args)
        {
            _reader = new StreamReader(Console.OpenStandardInput());
            _writer = new StreamWriter(Console.OpenStandardOutput());

            // READ
            var n = ReadInt();
            var input = new int[n];
            for (var i = 0; i < n; i++)
            {
                input[i] = ReadInt();
            }

            // INIT
            var dp = new (int, int)[n + 1][];
            for (var i = 0; i < n + 1; i++)
            {
                dp[i] = new (int, int)[n + 1];
                for (var j = 0; j < n + 1; j++)
                {
                    dp[i][j] = (int.MaxValue, 0);
                }
            }

            dp[0][0] = (0, 0);

            for (var i = 1; i < n + 1; i++)
            for (var j = 0; j < n; j++)
            {
                if (input[i - 1] <= 500)
                {
                    if (dp[i - 1][j].Item1 == int.MaxValue)
                    {
                        dp[i][j] = (int.MaxValue, 0);
                    }
                    else
                    {
                        var useMoney = dp[i - 1][j].Item1 + input[i - 1];
                        var useDiscount = dp[i - 1][j + 1].Item1;
                        if (useDiscount < useMoney)
                        {
                            dp[i][j] = (useDiscount, dp[i - 1][j + 1].Item2);
                        }
                        else
                        {
                            dp[i][j] = (useMoney, dp[i - 1][j].Item2);
                        }
                    }
                }
                else
                {
                    var jj = Math.Clamp(j - 1, 0, n - 1);
                    if (dp[i - 1][jj].Item1 == int.MaxValue)
                    {
                        dp[i][j] = (int.MaxValue, 0);
                    }
                    else
                    {
                        var useMoney = dp[i - 1][jj].Item1 + input[i - 1];
                        var useDiscount = dp[i - 1][j + 1].Item1;
                        if (useDiscount < useMoney)
                        {
                            dp[i][j] = (useDiscount, dp[i - 1][j + 1].Item2);
                        }
                        else
                        {
                            dp[i][j] = (useMoney, dp[i - 1][jj].Item2 + 1);
                        }
                    }
                }
            }

            var (item1, _) = dp[n].First();

            var value1 = item1;
            var value2 = 0;

            var path = new List<int>();
            for (var i = n; i > 0; i--)
            {
                if (dp[i - 1][value2 + 1].Item1 == value1)
                {
                    path.Add(i);
                    value2 += 1;
                    goto next;
                }

                for (var j = 0; j <= value2; j++)
                {
                    if (dp[i][value2].Item1 - input[i - 1] == dp[i - 1][j].Item1)
                    {
                        value1 = dp[i - 1][j].Item1;
                        value2 = j;
                        goto next;
                    }
                }

                next:
                continue;
            }

            // DEBUG
            _writer.WriteLine();
            for (var i = 0; i < n + 1; i++)
                _writer.WriteLine($"{i}\t {string.Join("\t", dp[i])}");
            _writer.WriteLine();

            path.Reverse();

            _writer.WriteLine($"{item1} {path.Count}");
            foreach (var t in path)
                _writer.WriteLine(t);

            _reader.Close();
            _writer.Close();
        }

        private static int ReadInt() =>
            int.Parse(_reader.ReadLine());
    }
}