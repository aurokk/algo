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

            var n = int.Parse(_reader.ReadLine());
            for (var i = 0; i < n; i++)
            {
                var rating = int.Parse(_reader.ReadLine());
                var div = MapToDivision(rating);
                _writer.WriteLine($"Division {div}");
            }

            _reader.Close();
            _writer.Close();
        }

        private static int MapToDivision(int rating)
        {
            if (1900 <= rating)
            {
                return 1;
            }
            else if (1600 <= rating && rating <= 1899)
            {
                return 2;
            }
            else if (1400 <= rating && rating <= 1599)
            {
                return 3;
            }
            else
            {
                return 4;
            }
        }
    }
}