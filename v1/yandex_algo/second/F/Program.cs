using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace F
{
    public class StackMax
    {
        private readonly List<int> _data = new List<int>();

        public void Push(int number)
        {
            _data.Add(number);
        }

        public int? Pop()
        {
            if (_data.Count > 0)
            {
                var index = _data.Count - 1;
                var result = _data[index];
                _data.RemoveAt(index);
                return result;
            }

            return null;
        }

        public int? GetMax()
        {
            if (_data.Count > 0)
            {
                return _data.Max();
            }

            return null;
        }
    }

    public class F
    {
        private static TextReader _reader;
        private static TextWriter _writer;

        public static void Main(string[] args)
        {
            _reader = new StreamReader(Console.OpenStandardInput());
            _writer = new StreamWriter(Console.OpenStandardOutput());

            var stack = new StackMax();

            var n = ReadInt();
            for (var i = 0; i < n; i++)
            {
                var commandString = ReadString();
                if (commandString.StartsWith("push"))
                {
                    var numberString = commandString.Substring(4);
                    var number = int.Parse(numberString);
                    stack.Push(number);
                    continue;
                }

                if (commandString.StartsWith("pop"))
                {
                    var result = stack.Pop();
                    if (result == null)
                    {
                        Console.WriteLine("error");
                    }

                    continue;
                }

                if (commandString.StartsWith("get"))
                {
                    var result = stack.GetMax();
                    var text = result != null ? result.ToString() : "None";
                    Console.WriteLine(text);
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