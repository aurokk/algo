using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace J
{
    public class Q
    {
        private readonly LinkedList<int> _data = new LinkedList<int>();

        public int? Get()
        {
            if (_data.Count == 0)
            {
                return null;
            }

            var result = _data.FirstOrDefault();
            _data.RemoveFirst();
            return result;
        }

        public void Put(int number)
        {
            _data.AddLast(number);
        }

        public int Size()
        {
            return _data.Count;
        }
    }

    public static class J
    {
        private static TextReader _reader;
        private static TextWriter _writer;

        public static List<int> Zip(List<int> a, List<int> b)
        {
            // Здесь реализация вашего решения
            throw new NotImplementedException();
        }

        public static void Main(string[] args)
        {
            _reader = new StreamReader(Console.OpenStandardInput());
            _writer = new StreamWriter(Console.OpenStandardOutput());

            var n = ReadInt();

            var q = new Q();

            for (var i = 0; i < n; i++)
            {
                var command = ReadString();

                if (command.StartsWith("put"))
                {
                    var numberString = command.Substring(3);
                    var number = int.Parse(numberString);
                    q.Put(number);
                    continue;
                }

                if (command.StartsWith("get"))
                {
                    var result = q.Get();
                    if (result == null)
                    {
                        Console.WriteLine("error");
                        continue;
                    }

                    Console.WriteLine(result);
                    continue;
                }

                if (command.StartsWith("size"))
                {
                    var size = q.Size();
                    Console.WriteLine(size);
                    continue;
                }
            }

            _reader.Close();
            _writer.Close();
        }

        private static int ReadInt()
        {
            return int.Parse(_reader.ReadLine());
        }

        private static string ReadString()
        {
            return _reader.ReadLine();
        }
    }
}