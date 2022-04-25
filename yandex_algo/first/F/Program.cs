using System;
using System.IO;
using System.Text.RegularExpressions;

namespace F
{
    public static class F
    {
        private static TextReader _reader;
        private static TextWriter _writer;

        public static string GetResult(string rawText)
        {
            var clearText = Regex
                .Replace(rawText, "[^a-z]", "", RegexOptions.IgnoreCase)
                .ToLowerInvariant();

            for (var i = 0; i < clearText.Length / 2; i++)
            {
                if (clearText[i] != clearText[clearText.Length - i - 1])
                {
                    return "False";
                }
            }

            return "True";
        }

        public static void Main(string[] args)
        {
            _reader = new StreamReader(Console.OpenStandardInput());
            _writer = new StreamWriter(Console.OpenStandardOutput());

            var text = ReadLine();
            var result = GetResult(text);
            _writer.WriteLine(result);

            _reader.Close();
            _writer.Close();
        }

        private static string ReadLine()
        {
            return _reader.ReadLine()
                .Trim();
        }
    }
}