using System;
using System.Collections.Generic;
using System.IO;

namespace J
{
    public static class J
    {
        private static TextReader _reader;
        private static TextWriter _writer;

        public static string GetResult(int num)
        {
            var results = new List<int>();

            var div = 2;
            while (num % div == 0)
            {
                results.Add(div);
                num /= div;
            }

            div = 3;
            while (div <= num)
            {
                if (num % div == 0)
                {
                    results.Add(div);
                    num /= div;
                }
                else
                {
                    div += 2;
                }
            }

            if (num > 1)
            {
                results.Add(num);
            }


            results.Sort();
            return string.Join(" ", results);
        }

        public static void Main(string[] args)
        {
            _reader = new StreamReader(Console.OpenStandardInput());
            _writer = new StreamWriter(Console.OpenStandardOutput());

            var num = ReadLine();
            var result = GetResult(num);
            _writer.WriteLine(result);

            _reader.Close();
            _writer.Close();
        }

        private static int ReadLine()
        {
            return int.Parse(_reader.ReadLine());
        }
    }
}