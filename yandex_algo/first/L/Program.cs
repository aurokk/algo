using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace L
{
    public static class L
    {
        private static TextReader _reader;
        private static TextWriter _writer;

        public static string GetResult(string str1, string str2)
        {
            var dict = new Dictionary<char, int>();

            var longString = str1.Length > str2.Length ? str1 : str2;
            var shortString = str1.Length < str2.Length ? str1 : str2;

            foreach (var ch in longString)
            {
                if (dict.ContainsKey(ch))
                    dict[ch] += 1;
                else
                    dict[ch] = 1;
            }

            foreach (var ch in shortString)
            {
                dict[ch] -= 1;
            }

            var result = dict.First(x => x.Value == 1).Key;
            return result.ToString();
        }

        public static void Main(string[] args)
        {
            _reader = new StreamReader(Console.OpenStandardInput());
            _writer = new StreamWriter(Console.OpenStandardOutput());

            var str1 = ReadLine();
            var str2 = ReadLine();
            var result = GetResult(str1, str2);
            _writer.WriteLine(result);

            _reader.Close();
            _writer.Close();
        }

        private static string ReadLine()
        {
            return _reader.ReadLine();
        }
    }
}