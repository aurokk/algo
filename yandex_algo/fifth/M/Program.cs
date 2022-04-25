using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace M
{
    public static class M
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