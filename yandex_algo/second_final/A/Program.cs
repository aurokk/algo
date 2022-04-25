/*
 * Тесты:
 * https://contest.yandex.ru/contest/22781/run-report/64122604/
 *
 * Объяснение:
 * Реализовал дек на основе массива, используя его как кольцевой буфер. В деке храню два указателя на первую свободную
 * ячейку в начале и в конце. Каждый раз при добавлении/удалении элемента из дека сдвигаю указатель на единицу
 * в соответствующую сторону.
 *
 * В случае если при добавлении дек заполнен, то методы добавление возвращают false, если массив пуст,
 * то методы удаления возвращают null, что обработано снаружи записью в консоль соответствующих сообщений.
 * 
 * Так как все операции выполняются через обращение к конкретным элементам в массиве то все они выполняются
 * за контантное время О(1). Массив выделяется длиной ровно n элементов, что даёт нам O(n) по памяти.
 *
 */

using System;
using System.IO;

namespace A
{
    public class Deque
    {
        private readonly int[] _data;
        private readonly int _capacity;
        private int _size = 0;
        private int _head = 0;
        private int _tail = 0;

        public Deque(int capacity)
        {
            _capacity = capacity;
            _data = new int[capacity];
            _head = (-1 + _capacity) % _capacity;
        }

        public int? PopBack()
        {
            if (_size == 0)
            {
                return null;
            }

            _tail = PositiveMod(_tail - 1, _capacity);
            _size -= 1;
            return _data[_tail];
        }

        public int? PopFront()
        {
            if (_size == 0)
            {
                return null;
            }

            _head = PositiveMod(_head + 1, _capacity);
            _size -= 1;
            return _data[_head];
        }

        public bool PushBack(int x)
        {
            if (_size == _capacity)
            {
                return false;
            }

            _data[_tail] = x;
            _size += 1;
            _tail = PositiveMod(_tail + 1, _capacity);
            return true;
        }

        public bool PushFront(int x)
        {
            if (_size == _capacity)
            {
                return false;
            }

            _data[_head] = x;
            _size += 1;
            _head = PositiveMod(_head - 1, _capacity);
            return true;
        }

        private static int PositiveMod(int input, int mod)
        {
            return (input + mod) % mod;
        }
    }

    public class A
    {
        private static TextReader _reader;
        private static TextWriter _writer;

        public static void Main(string[] args)
        {
            _reader = new StreamReader(Console.OpenStandardInput());
            _writer = new StreamWriter(Console.OpenStandardOutput());

            var n = ReadInt();
            var m = ReadInt();

            var deque = new Deque(m);

            for (var i = 0; i < n; i++)
            {
                var command = ReadString();
                if (command.StartsWith("push_front"))
                {
                    var xString = command.Substring(10);
                    var x = int.Parse(xString);
                    var result = deque.PushFront(x);
                    if (!result)
                    {
                        _writer.WriteLine("error");
                    }

                    continue;
                }

                if (command.StartsWith("push_back"))
                {
                    var xString = command.Substring(9);
                    var x = int.Parse(xString);
                    var result = deque.PushBack(x);
                    if (!result)
                    {
                        _writer.WriteLine("error");
                    }

                    continue;
                }

                if (command.StartsWith("pop_front"))
                {
                    var result = deque.PopFront();
                    if (result == null)
                    {
                        _writer.WriteLine("error");
                        continue;
                    }

                    _writer.WriteLine(result);
                    continue;
                }

                if (command.StartsWith("pop_back"))
                {
                    var result = deque.PopBack();
                    if (result == null)
                    {
                        _writer.WriteLine("error");
                        continue;
                    }

                    _writer.WriteLine(result);
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