using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace B
{
    public static class B
    {
        private static TextReader _reader;
        private static TextWriter _writer;

        public static void Main(string[] args)
        {
            _reader = new StreamReader(Console.OpenStandardInput());
            _writer = new StreamWriter(Console.OpenStandardOutput());

            var changeUsed = false;
            var nameA = _reader.ReadLine();
            var nameB = _reader.ReadLine();
            var minName = nameA.Length > nameB.Length ? nameB : nameA;
            var maxName = nameA.Length > nameB.Length ? nameA : nameB;

            var i = 0;
            var j = 0;
            for (; i < minName.Length; i++, j++)
            {
                if (minName[i] != maxName[j])
                {
                    if (changeUsed)
                    {
                        _writer.WriteLine("FAIL");
                        _reader.Close();
                        _writer.Close();
                        return;
                    }

                    changeUsed = true;

                    if (minName.Length != maxName.Length)
                    {
                        i--;
                    }
                }
            }

            _writer.WriteLine("OK");
            _reader.Close();
            _writer.Close();
        }
    }
}