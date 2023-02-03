using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace D
{
    public static class D
    {
        private static TextReader _reader;
        private static TextWriter _writer;

        public static void Main(string[] args)
        {
            _reader = new StreamReader(Console.OpenStandardInput());
            _writer = new StreamWriter(Console.OpenStandardOutput());

            var n = ReadInt();
            var results = new List<string>();
            for (var i = 0; i < n; i++)
            {
                var section = ReadString();
                if (!results.Contains(section))
                {
                    results.Add(section);
                }
            }

            foreach (var result in results)
            {
                _writer.WriteLine(result);
            }

            _reader.Close();
            _writer.Close();
        }

        private static int ReadInt()
        {
            return int.Parse(_reader.ReadLine());
        }

        private static string ReadString()
        {
            return _reader.ReadLine();
        }
    }
}