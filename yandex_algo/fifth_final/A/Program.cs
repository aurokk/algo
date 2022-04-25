// -- ТЕСТЫ --
// https://contest.yandex.ru/contest/24810/run-report/65692502/
// 
// -- ПРИНЦИП РАБОТЫ -- 
// Сделал кучу на основе массива, размер массива определяется входными данными.
// При добавлении делаю просеивание вверх, при удалении вниз.
// Вставка и удаление в кучу работают за O(logN). 
//
// Данные представил в виде класс Actor, к нему написал IComparer, и заимплементил в нём IComparable.
// 
// -- ДОКАЗАТЕЛЬСТВО КОРРЕКТНОСТИ --
// Куча — структура данных, где наверху находятся самые приоритетные элементы, а ниже менее приоритетные.
// Свойство может нарушиться при вставке новых элементов и при удалении.
// 
// При вставке элемента в кучу, мы добавляем его в первую свободную ячейку, затем делаем просеивание вверх
// для того, чтобы восстановить свойства кучи.
//
// При удалении, в свою очередь, мы удаляем корень дерева, ставим на его место последний элемент кучи
// и затем делаем просеивание вниз, чтобы восстановить свойства кучи.
//
// Остальное тут: https://practicum.yandex.ru/learn/algorithms/courses/7f101a83-9539-4599-b6e8-8645c3f31fad/sprints/21363/topics/e7dbf42a-fd5a-434b-990d-9cfe0e3a10c8/lessons/116802f2-0842-4195-9d12-13e7bf0efad1/
//
// -- ВРЕМЕННАЯ СЛОЖНОСТЬ --
// O(N*logN), так как каждая операция (добавление и удаление) работает за O(logH), где H высота дерева, то 
// N операция выполняется в среднем за O(N*logH), мы делаем это дважды, когда добавляем в кучу элементы и затем
// когда удаляем, получается O(2N*logH) -> отбрасываем константы и прочее O(NlogN) или O(NlogH), где H-высота дерева
//
// -- ПРОСТРАНСТВЕННАЯ СЛОЖНОСТЬ --
// O(N), так как в основе кучи массив, размером N элементов.
//
// P.S.: про то, что можно заинлайнить однострочные методы для чтения входящих данных знаю, просто мне так удобнее.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace A
{
    public sealed class ActorComparer : IComparer<Actor>
    {
        public static IComparer<Actor> Instance { get; } = new ActorComparer();

        public int Compare(Actor x, Actor y)
        {
            if (ReferenceEquals(x, y)) return 0;
            if (ReferenceEquals(null, y)) return 1;
            if (ReferenceEquals(null, x)) return -1;

            // big first
            var tasksSolvedComparison = x.TasksSolved.CompareTo(y.TasksSolved);
            if (tasksSolvedComparison != 0) return tasksSolvedComparison;

            // low first
            var penaltyComparison = -1 * x.Penalty.CompareTo(y.Penalty);
            if (penaltyComparison != 0) return penaltyComparison;

            // low first
            var nameComparison = -1 * string.Compare(x.Name, y.Name, StringComparison.Ordinal);
            return nameComparison;
        }
    }

    public class Actor : IComparable<Actor>
    {
        public string Name { get; }
        public int TasksSolved { get; }
        public int Penalty { get; }

        public Actor(string name, int tasksSolved, int penalty)
        {
            Name = name;
            TasksSolved = tasksSolved;
            Penalty = penalty;
        }

        public int CompareTo(Actor other)
        {
            return ActorComparer.Instance.Compare(this, other);
        }
    }

    public class Heap
    {
        private readonly Actor[] _actors;
        private int _size;

        public Heap(int size)
        {
            var normalizedSize = size + 1;
            _size = 0;
            _actors = new Actor[normalizedSize];
        }

        public void Push(Actor actor)
        {
            _size += 1;
            _actors[_size] = actor;
            SiftUp(_actors, _size);
        }

        public Actor Pop()
        {
            var actor = _actors[1];
            _actors[1] = _size > 1 ? _actors[_size] : null;
            _actors[_size] = null;
            _size -= 1;
            SiftDown(_actors, 1);
            return actor;
        }

        private static void SiftDown(Actor[] actors, int index)
        {
            var curr = actors[index];
            var left = index * 2 < actors.Length ? actors[index * 2] : null;
            var right = index * 2 + 1 < actors.Length ? actors[index * 2 + 1] : null;
            var max = new[] {left, curr, right,}.Max();
            if (max == curr)
                return;
            if (max == left)
            {
                actors[index] = left;
                actors[index * 2] = curr;
                SiftDown(actors, index * 2);
            }
            else
            {
                actors[index] = right;
                actors[index * 2 + 1] = curr;
                SiftDown(actors, index * 2 + 1);
            }
        }

        private static void SiftUp(Actor[] actors, int index)
        {
            if (index == 1)
                return;

            var parentIndex = index / 2;
            var result = ActorComparer.Instance.Compare(actors[parentIndex], actors[index]);
            if (result < 0)
            {
                // ReSharper disable once SwapViaDeconstruction
                var tmp = actors[parentIndex];
                actors[parentIndex] = actors[index];
                actors[index] = tmp;
                SiftUp(actors, parentIndex);
            }
        }
    }

    public static class A
    {
        private static TextReader _reader;
        private static TextWriter _writer;

        public static void Main(string[] args)
        {
            _reader = new StreamReader(Console.OpenStandardInput());
            _writer = new StreamWriter(Console.OpenStandardOutput());

            var n = ReadInt();
            var heap = new Heap(n);

            for (var i = 0; i < n; i++)
            {
                var data = ReadArray();
                var name = data[0];
                var tasksSolved = int.Parse(data[1]);
                var penalty = int.Parse(data[2]);
                var actor = new Actor(name, tasksSolved, penalty);
                heap.Push(actor);
            }

            for (var i = 0; i < n; i++)
            {
                var actor = heap.Pop();
                _writer.WriteLine(actor.Name);
            }

            _reader.Close();
            _writer.Close();
        }

        private static int ReadInt()
        {
            return int.Parse(_reader.ReadLine());
        }

        private static string[] ReadArray()
        {
            return _reader.ReadLine().Split(' ');
        }
    }
}