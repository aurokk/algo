using System;
using System.IO;

namespace E
{
    public static class E
    {
        private static TextReader _reader;
        private static TextWriter _writer;

        public static string GetResult(string text)
        {
            var longest = string.Empty;

            var word = string.Empty;
            for (var i = 0; i < text.Length; i++)
            {
                switch (text[i])
                {
                    case ' ':
                        if (word.Length > longest.Length)
                            longest = word;
                        word = string.Empty;
                        break;

                    default:
                        word += text[i];
                        break;
                }
            }

            if (word.Length > longest.Length)
                longest = word;

            return longest;
        }

        public static void Main(string[] args)
        {
            _reader = new StreamReader(Console.OpenStandardInput());
            _writer = new StreamWriter(Console.OpenStandardOutput());

            ReadLine();
            var text = ReadLine();
            var result = GetResult(text);
            _writer.WriteLine(result);
            _writer.WriteLine(result.Length);

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