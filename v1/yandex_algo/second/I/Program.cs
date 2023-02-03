using System;
using System.IO;

namespace I
{
    public class SizedQueue
    {
        private readonly int[] _data;
        private int _size = 0;
        private int _head = 0;
        private int _tail = 0;

        public SizedQueue(int size)
        {
            _data = new int[size];
        }

        public int? Peek()
        {
            if (_size == 0)
            {
                return null;
            }

            return _data[_head];
        }

        public int? Pop()
        {
            if (_size == 0)
            {
                return null;
            }

            var result = _data[_head];
            _head = (_head + 1) % _data.Length;
            _size -= 1;
            return result;
        }

        public bool Push(int number)
        {
            if (_size == _data.Length)
            {
                return false;
            }

            _data[_tail] = number;
            _tail = (_tail + 1) % _data.Length;
            _size += 1;
            return true;
        }

        public int Size()
        {
            return _size;
        }
    }

    public class I
    {
        private static TextReader _reader;
        private static TextWriter _writer;


        public static void Main(string[] args)
        {
            _reader = new StreamReader(Console.OpenStandardInput());
            _writer = new StreamWriter(Console.OpenStandardOutput());


            var n = ReadInt();

            var m = ReadInt();
            var q = new SizedQueue(m);

            for (var i = 0; i < n; i++)
            {
                var command = ReadString();
                if (command.StartsWith("peek"))
                {
                    var result = q.Peek();
                    if (result == null)
                    {
                        Console.WriteLine("None");
                        continue;
                    }

                    Console.WriteLine(result);
                    continue;
                }

                if (command.StartsWith("push"))
                {
                    var numberString = command.Substring(4);
                    var number = int.Parse(numberString);
                    if (!q.Push(number))
                    {
                        Console.WriteLine("error");
                    }

                    continue;
                }

                if (command.StartsWith("pop"))
                {
                    var result = q.Pop();
                    if (result == null)
                    {
                        Console.WriteLine("None");
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