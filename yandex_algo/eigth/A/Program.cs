using System;
using System.IO;
using System.Linq;

namespace A
{
    public static class A
    {
        private static TextReader _reader;
        private static TextWriter _writer;

        public static void Main(string[] args)
        {
            _reader = new StreamReader(Console.OpenStandardInput());
            _writer = new StreamWriter(Console.OpenStandardOutput());

            var strings = _reader.ReadLine()
                .Split(' ')
                .ToArray()
                .Reverse();

            _writer.WriteLine(string.Join(' ', strings));

            _reader.Close();
            _writer.Close();
        }
    }
}