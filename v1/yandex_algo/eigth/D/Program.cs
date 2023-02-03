using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace D
{
    public class Container
    {
        public readonly char[] Chars;
        public readonly bool[] Mask;
        public int Max;

        public Container(string word)
        {
            Chars = word.ToCharArray();
            Mask = new bool[word.Length];
            for (var i = 0; i < word.Length; i++)
                Mask[i] = true;
            Max = word.Length;
        }

        public void Reduce(string word)
        {
            var min = Math.Min(word.Length, Max);
            for (var i = 0; i < min; i++)
            {
                if (!Mask[i])
                {
                    break;
                }

                if (Chars[i] != word[i])
                {
                    Max = i;
                    break;
                }
            }

            for (var i = Max; i < Mask.Length; i++)
                if (Mask[i] == false)
                    break;
                else
                    Mask[i] = false;
        }
    }

    public static class D
    {
        private static TextReader _reader;
        private static TextWriter _writer;

        public static void Main(string[] args)
        {
            _reader = new StreamReader(Console.OpenStandardInput());
            _writer = new StreamWriter(Console.OpenStandardOutput());

            var n = int.Parse(_reader.ReadLine());
            var c = new Container(_reader.ReadLine());
            for (var i = 1; i < n; i++)
                c.Reduce(_reader.ReadLine());

            _writer.WriteLine(c.Max);

            _reader.Close();
            _writer.Close();
        }

        private static int[] ReadArray() =>
            _reader.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
    }
}