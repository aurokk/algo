using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace N
{
    public static class N
    {
        private static StreamReader _reader;
        private static StreamWriter _writer;

        public static void Main(string[] args)
        {
            _reader = new StreamReader(Console.OpenStandardInput());
            _writer = new StreamWriter(Console.OpenStandardOutput());

            _reader.Close();
            _writer.Close();
        }
    }
}