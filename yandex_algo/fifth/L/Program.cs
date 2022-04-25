using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace L
{
    public static class L
    {
        private static StreamReader _reader;
        private static StreamWriter _writer;

        public static void Main(string[] args)
        {
            _reader = new StreamReader(Console.OpenStandardInput());
            _writer = new StreamWriter(Console.OpenStandardOutput());

            Solution.Test();

            _reader.Close();
            _writer.Close();
        }
    }
}