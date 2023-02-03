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

        public static void Main(string[] args)
        {
            _reader = new StreamReader(Console.OpenStandardInput());
            _writer = new StreamWriter(Console.OpenStandardOutput());

            var n = ReadInt();
            var s = ReadInt();
            var array = ReadArray();
            Array.Sort(array);

            var pairs = new Dictionary<long, List<int[]>>();
            for (var i = 0; i < n; i++)
            {
                for (var j = i + 1; j < n; j++)
                {
                    long sum = array[i] + array[j];
                    if (pairs.ContainsKey(sum))
                    {
                        pairs[sum].Add(new[] {i, j});
                    }
                    else
                    {
                        pairs[sum] = new List<int[]> {new[] {i, j}};
                    }
                }
            }

            var results = new HashSet<Tuple<long, long, long, long>>();
            var keys = pairs.Keys.ToArray();
            Array.Sort(keys);

            foreach (var key in keys)
            {
                var remainder = s - key;
                if (pairs.ContainsKey(remainder))
                {
                    foreach (var k1 in pairs[key])
                    {
                        foreach (var k2 in pairs[remainder])
                        {
                            if (k1[0] != k2[0] && k1[0] != k2[1] && k1[1] != k2[0] && k1[1] != k2[1])
                            {
                                var result = new[]
                                    {
                                        array[k1[0]],
                                        array[k1[1]],
                                        array[k2[0]],
                                        array[k2[1]]
                                    }
                                    .OrderBy(x => x)
                                    .ToArray();
                                results.Add(new Tuple<long, long, long, long>(
                                    result[0],
                                    result[1],
                                    result[2],
                                    result[3]
                                ));
                            }
                        }
                    }
                }
            }


            // var results = new Dictionary<int[], bool>();
            // var keys = pairs.Keys.ToArray();
            // foreach (var key in keys)
            // {
            //     var previous = 
            //     // var remainder = s - key;
            //     // if (pairs.ContainsKey(remainder))
            //     // {
            //     //     var leftIndexes = pairs[key];
            //     //     var rightIndexes = pairs[remainder];
            //     //     foreach (var leftIndexCoords in leftIndexes)
            //     //     {
            //     //         foreach (var rightIndexCoords in rightIndexes)
            //     //         {
            //     //             var result = new[]
            //     //                 {
            //     //                     array[leftIndexCoords[0]],
            //     //                     array[leftIndexCoords[1]],
            //     //                     array[rightIndexCoords[0]],
            //     //                     array[rightIndexCoords[1]]
            //     //                 }
            //     //                 .OrderBy(x => x)
            //     //                 .ToArray();
            //     //             results.Add(result, true);
            //     //         }
            //     //     }
            //     // }
            // }
            // while (leftIndex != rightIndex)
            // {
            //     var left = keys[leftIndex];
            //     var right = keys[rightIndex];
            //     // if (left + right == s)
            //     // {
            //     //     var leftIndexes = pairs[left];
            //     //     var rightIndexes = pairs[right];
            //     //     foreach (var leftIndexCoords in leftIndexes)
            //     //     {
            //     //         foreach (var rightIndexCoords in rightIndexes)
            //     //         {
            //     //             results.Add(
            //     //                 new Tuple<int, int, int, int>(
            //     //                     leftIndexCoords[0],
            //     //                     leftIndexCoords[1],
            //     //                     rightIndexCoords[0],
            //     //                     rightIndexCoords[1]
            //     //                 )
            //     //             );
            //     //         }
            //     //     }
            //     // }
            //     // else if (left + right > s)
            //     // {
            //     //     rightIndex--;
            //     // }
            //     // else
            //     // {
            //     //     leftIndex++;
            //     // }
            // }

            var orderedResults = results
                .OrderBy(x => x.Item1)
                .ThenBy(x => x.Item2)
                .ThenBy(x => x.Item3)
                .ThenBy(x => x.Item4)
                .ToArray();

            _writer.WriteLine(orderedResults.Length);
            foreach (var result in orderedResults)
            {
                _writer.WriteLine($"{result.Item1} {result.Item2} {result.Item3} {result.Item4}");
            }

            _reader.Close();
            _writer.Close();
        }

        private static long ReadInt()
        {
            return long.Parse(_reader.ReadLine());
        }

        private static long[] ReadArray()
        {
            return _reader.ReadLine()
                .Split(new[] {' ', '\t',}, StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToArray();
        }
    }
}