using System;
using System.IO;

namespace C
{
    public static class C
    {
        private static TextReader _reader;
        private static TextWriter _writer;

        public static void Main(string[] args)
        {
            _reader = new StreamReader(Console.OpenStandardInput());
            _writer = new StreamWriter(Console.OpenStandardOutput());

            // Solution.Test();

            _reader.Close();
            _writer.Close();
        }
    }
}