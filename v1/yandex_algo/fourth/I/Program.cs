using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace I
{
    public static class I
    {
        private static TextReader _reader;
        private static TextWriter _writer;

        public static void Main(string[] args)
        {
            _reader = new StreamReader(Console.OpenStandardInput());
            _writer = new StreamWriter(Console.OpenStandardOutput());

            ReadInt();
            var array1 = ReadArray();
            ReadInt();
            var array2 = ReadArray();

            var maxLength = 0;
            for (var i = 0; i < array1.Length; i++)
            {
                var length = 0;
                for (var j = i; j < array1.Length;)
                {
                    for (var k = 0; k < array2.Length && j < array1.Length;)
                    {
                        if (array1[j] == array2[k])
                        {
                            length++;
                            if (length > maxLength)
                            {
                                maxLength = length;
                            }
                            j++;
                            k++;
                        }
                        else
                        {
                            j = i;
                            k++;
                            length = 0;
                        }
                    }

                    break;
                }
            }
            
            _writer.WriteLine(maxLength);

            _reader.Close();
            _writer.Close();
        }

        private static int ReadInt()
        {
            return int.Parse(_reader.ReadLine());
        }

        private static int[] ReadArray()
        {
            return _reader.ReadLine()
                .Split(new[] {' ', '\t',}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}