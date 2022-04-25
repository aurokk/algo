using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace G
{
    public static class G
    {
        private static TextReader _reader;
        private static TextWriter _writer;


        public static void Main(string[] args)
        {
            _reader = new StreamReader(Console.OpenStandardInput());
            _writer = new StreamWriter(Console.OpenStandardOutput());

            ReadInt();
            var array = ReadArray();
            var data = new int[3];
            foreach (var elem in array)
            {
                data[elem] += 1;
            }

            var result = new List<int>();
            for (var i = 0; i < data.Length; i++)
            {
                var item = data[i];
                for (var j = 0; j < item; j++)
                {
                    result.Add(i);
                }
            }

            _writer.WriteLine(string.Join(" ", result));

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