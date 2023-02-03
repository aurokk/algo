using System;
using System.IO;

namespace F
{
    public static class F
    {
        private static TextReader _reader;
        private static TextWriter _writer;

        public static void Main(string[] args)
        {
            _reader = new StreamReader(Console.OpenStandardInput());
            _writer = new StreamWriter(Console.OpenStandardOutput());

            _reader.Close();
            _writer.Close();
        }
    }
}