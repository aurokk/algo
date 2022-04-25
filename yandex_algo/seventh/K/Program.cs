using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace K
{
    public static class K
    {
        private static StreamReader _reader;
        private static StreamWriter _writer;

        public static void Main(string[] args)
        {
            _reader = new StreamReader(Console.OpenStandardInput());
            _writer = new StreamWriter(Console.OpenStandardOutput());

            var nn = ReadArray();
            var n = nn[0];
            var ns = ReadArray();

            var mm = ReadArray();
            var m = mm[0];
            var ms = ReadArray();

            var dp = new int[n + 1][];
            for (var i = 0; i < n + 1; i++)
                dp[i] = new int[m + 1];

            for (var i = 1; i < n + 1; i++)
            for (var j = 1; j < m + 1; j++)
            {
                var ii = i - 1;
                var jj = j - 1;
                var prevD = dp[ii][jj];
                var prevL = dp[ii][j];
                var prevT = dp[i][jj];
                var curr = ns[ii] == ms[jj] ? prevD + 1 : Math.Max(prevL, prevT);
                dp[i][j] = curr;
            }

            _writer.WriteLine(dp[n][m]);

            var answerN = new List<int>();
            var answerM = new List<int>();

            var ip = n;
            var jp = m;
            while (ip != 0 && jp != 0)
            {
                var i = ip - 1;
                var j = jp - 1;

                if (ns[i] == ms[j])
                {
                    answerN.Add(ip);
                    answerM.Add(jp);
                    ip -= 1;
                    jp -= 1;
                }
                else if (dp[ip][jp] == dp[ip - 1][jp])
                {
                    ip -= 1;
                }
                else
                {
                    jp -= 1;
                }
            }

            answerN.Reverse();
            answerM.Reverse();

            _writer.WriteLine(string.Join(" ", answerN));
            _writer.WriteLine(string.Join(" ", answerM));

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