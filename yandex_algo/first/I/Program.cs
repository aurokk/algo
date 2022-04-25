using System;
using System.IO;

namespace I
{
    public static class I
    {
        private static TextReader _reader;
        private static TextWriter _writer;

        public static string GetResult(int num)
        {
            var i = 0;
            var x = 1;
            do
            {
                if (i > 0)
                {
                    x *= 4;
                }

                if (x == num)
                {
                    return "True";
                }

                i++;
            } while (x <= 10000);

            return "False";
        }

        public static void Main(string[] args)
        {
            _reader = new StreamReader(Console.OpenStandardInput());
            _writer = new StreamWriter(Console.OpenStandardOutput());

            var num = ReadLine();
            var result = GetResult(num);
            _writer.WriteLine(result);

            _reader.Close();
            _writer.Close();
        }

        private static int ReadLine()
        {
            return int.Parse(_reader.ReadLine());
        }
    }
}