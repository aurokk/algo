using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace J
{
    public static class J
    {
        private static TextReader _reader;
        private static TextWriter _writer;

        // VERSION 1 O(N^2*M^2)
        // public static void Main(string[] args)
        // {
        //     _reader = new StreamReader(Console.OpenStandardInput());
        //     _writer = new StreamWriter(Console.OpenStandardOutput());
        //
        //     // ONE SEQUENCE
        //     // var nn = ReadArray();
        //     // var n = nn[0];
        //     // var m = n;
        //     //
        //     // var input = ReadArray();
        //     // var a = input;
        //     // var b = input;
        //
        //     // HARDCODED TWO SEQUENCES
        //     var n = 8;
        //     var m = 7;
        //
        //     var a = new[] {3, 8, 9, 1, 3, 1, 2, 1};
        //     var b = new[] {1, 3, 1, 2, 8, 9, 1};
        //
        //     var dp = new int[n + 1][];
        //     for (var i = 0; i < n + 1; i++)
        //         dp[i] = new int[m + 1];
        //
        //     for (var i = 1; i < n + 1; i++)
        //     for (var j = 1; j < m + 1; j++)
        //     {
        //         if (a[i - 1] != b[j - 1])
        //             continue;
        //
        //         var maxLength = 0;
        //         for (var iPrev = 1; iPrev < i; iPrev++)
        //         {
        //             if (a[iPrev - 1] >= a[i - 1])
        //                 continue;
        //
        //             for (var jPrev = 1; jPrev < j; jPrev++)
        //                 maxLength = Math.Max(maxLength, dp[iPrev][jPrev]);
        //         }
        //
        //         dp[i][j] = maxLength + 1;
        //     }
        //
        //     _writer.WriteLine();
        //     for (var i = 0; i < n + 1; i++)
        //         _writer.WriteLine(string.Join(" ", dp[i]));
        //     _writer.WriteLine();
        //
        //     var answer = 0;
        //     for (var i = 0; i < n + 1; i++)
        //     for (var j = 0; j < m + 1; j++)
        //         answer = Math.Max(answer, dp[i][j]);
        //
        //     _writer.WriteLine(answer);
        //
        //     _reader.Close();
        //     _writer.Close();
        // }


        // VERSION 2 O(N*M^2)
        // public static void Main(string[] args)
        // {
        //     _reader = new StreamReader(Console.OpenStandardInput());
        //     _writer = new StreamWriter(Console.OpenStandardOutput());
        //
        //     // ONE SEQUENCE
        //     // var nn = ReadArray();
        //     // var n = nn[0];
        //     // var m = n;
        //     //
        //     // var input = ReadArray();
        //     // var a = input;
        //     // var b = input;
        //
        //     // HARDCODED TWO SEQUENCES
        //     var n = 8;
        //     var m = 7;
        //
        //     var a = new[] {3, 8, 9, 1, 3, 1, 2, 1};
        //     var b = new[] {1, 3, 1, 2, 8, 9, 1};
        //
        //     var dp = new int[n + 1][];
        //     for (var i = 0; i < n + 1; i++)
        //         dp[i] = new int[m + 1];
        //
        //     for (var i = 1; i < n + 1; i++)
        //     for (var j = 1; j < m + 1; j++)
        //     {
        //         dp[i][j] = dp[i - 1][j];
        //
        //         if (a[i - 1] != b[j - 1])
        //             continue;
        //
        //         var maxLength = 0;
        //         for (var jPrev = 1; jPrev < j; jPrev++)
        //         {
        //             if (b[jPrev - 1] < b[j - 1])
        //                 maxLength = Math.Max(maxLength, dp[i - 1][jPrev]);
        //
        //             dp[i][j] = Math.Max(dp[i][j], 1 + maxLength);
        //         }
        //     }
        //
        //     _writer.WriteLine();
        //     for (var i = 0; i < n + 1; i++)
        //         _writer.WriteLine(string.Join(" ", dp[i]));
        //     _writer.WriteLine();
        //
        //     var answer = 0;
        //     for (var j = 0; j < m + 1; j++)
        //         answer = Math.Max(answer, dp[n][j]);
        //
        //     _writer.WriteLine(answer);
        //
        //     _reader.Close();
        //     _writer.Close();
        // }


        // VERSION 3 O(N*M)
        public static void Main(string[] args)
        {
            _reader = new StreamReader(Console.OpenStandardInput());
            _writer = new StreamWriter(Console.OpenStandardOutput());
        
            // ONE SEQUENCE
            // var nn = ReadArray();
            // var n = nn[0];
            // var m = n;
            //
            // var input = ReadArray();
            // var a = input;
            // var b = input;
        
            // HARDCODED TWO SEQUENCES
            var n = 8;
            var m = 7;
            
            var a = new[] {3, 8, 9, 1, 3, 1, 2, 1};
            var b = new[] {1, 3, 1, 2, 8, 9, 1};
        
            var dp = new int[n + 1][];
            for (var i = 0; i < n + 1; i++)
                dp[i] = new int[m + 1];
        
            for (var i = 1; i < n + 1; i++)
            {
                var maxLength = 0;
                for (var j = 1; j < m + 1; j++)
                {
                    dp[i][j] = dp[i - 1][j];
        
                    if (a[i - 1] == b[j - 1])
                        dp[i][j] = Math.Max(dp[i][j], maxLength + 1);
        
                    if (b[j - 1] < a[i - 1])
                        maxLength = Math.Max(maxLength, dp[i - 1][j]);
                }
            }
        
            _writer.WriteLine();
            for (var i = 0; i < n + 1; i++)
                _writer.WriteLine(string.Join(" ", dp[i]));
            _writer.WriteLine();
        
            var answer = 0;
            for (var j = 0; j < m + 1; j++)
                answer = Math.Max(answer, dp[n][j]);
        
            _writer.WriteLine(answer);
        
            var curr = answer;
            var path1 = new List<int>();
            var path2 = new List<int>();
            for (var i = n; i >= 0 && curr > 0; i--)
            for (var j = m; j >= 0 && curr > 0; j--)
            {
                if (dp[i][j] == curr)
                {
                    path1.Add(i);
                    path2.Add(j);
                    curr--;
                }
            }
        
            path1.Reverse();
            path2.Reverse();
        
            // _writer.WriteLine(string.Join(" ", path1));
            _writer.WriteLine(string.Join(" ", path2));
        
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