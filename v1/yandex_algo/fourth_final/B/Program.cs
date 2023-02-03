using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace B
{
    public class MyDictionary
    {
        private readonly int _size;
        private readonly LinkedList<Tuple<int, int>>[] _data;

        public MyDictionary(int size)
        {
            _size = size;
            _data = new LinkedList<Tuple<int, int>>[size];
        }

        public void Put(int key, int value)
        {
            var bucket = Bucket(key);
            _data[bucket] ??= new LinkedList<Tuple<int, int>>();

            var newItem = new Tuple<int, int>(key, value);
            var bucketValue = _data[bucket];
            var oldItem = bucketValue.FirstOrDefault(bucketItem => bucketItem.Item1 == key);
            if (oldItem != null)
            {
                _data[bucket].Remove(oldItem);
            }

            _data[bucket].AddLast(newItem);
        }

        public int? Get(int key)
        {
            var bucket = Bucket(key);
            var bucketValue = _data[bucket];
            var bucketItem = bucketValue?.FirstOrDefault(bucketItem => bucketItem.Item1 == key);
            return bucketItem?.Item2;
        }

        public int? Delete(int key)
        {
            var bucket = Bucket(key);
            var bucketValue = _data[bucket];
            var oldItem = bucketValue?.FirstOrDefault(bucketItem => bucketItem.Item1 == key);
            if (oldItem != null)
            {
                _data[bucket].Remove(oldItem);
            }

            return oldItem?.Item2;
        }

        private int Bucket(int key)
        {
            return (int) (Hash(key) % _size);
        }

        private static long Hash(int key)
        {
            const long prime = 135787;
            return key * prime;
        }
    }

    public static class B
    {
        private static TextReader _reader;
        private static TextWriter _writer;

        public static void Main(string[] args)
        {
            _reader = new StreamReader(Console.OpenStandardInput());
            _writer = new StreamWriter(Console.OpenStandardOutput());

            var n = ReadInt();
            
            // Поделил входные данные на 100, чтоб побольше коллизий было
            var size = (int) Math.Ceiling((decimal) n / 100);
            var dict = new MyDictionary(size);

            for (var i = 0; i < n; i++)
            {
                var request = ReadArray();
                var command = request[0];
                switch (command)
                {
                    case "put":
                    {
                        var key = int.Parse(request[1]);
                        var value = int.Parse(request[2]);
                        dict.Put(key, value);
                        break;
                    }

                    case "get":
                    {
                        var key = int.Parse(request[1]);
                        var value = dict.Get(key);
                        if (value != null)
                        {
                            _writer.WriteLine(value);
                        }
                        else
                        {
                            _writer.WriteLine("None");
                        }

                        break;
                    }

                    case "delete":
                    {
                        var key = int.Parse(request[1]);
                        var value = dict.Delete(key);
                        if (value != null)
                        {
                            _writer.WriteLine(value);
                        }
                        else
                        {
                            _writer.WriteLine("None");
                        }

                        break;
                    }
                }
            }

            _writer.Flush();

            _reader.Close();
            _writer.Close();
        }

        private static int ReadInt()
        {
            return int.Parse(_reader.ReadLine());
        }

        private static string[] ReadArray()
        {
            return _reader.ReadLine()
                .Split(new[] {' ', '\t',}, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
        }
    }
}