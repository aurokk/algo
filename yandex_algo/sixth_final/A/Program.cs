// -- ТЕСТЫ --
// https://contest.yandex.ru/contest/25070/run-report/66292904/
// 
// -- ПРИНЦИП РАБОТЫ -- 
// В основе решения лежит алгоритм Прима на очереди с приоритетами.
// Единственное, что изменил — достаю ребро с максимальным весом вместо минимального.
// Данные представлены классом Edge, к нему написан компаратор.
// 
// https://practicum.yandex.ru/learn/algorithms/courses/7f101a83-9539-4599-b6e8-8645c3f31fad/sprints/21364/topics/45179065-a73b-473d-94d1-24774573f266/lessons/adb9a06e-f8a5-4d9b-b88a-2085cc8458f9/
//
// -- ДОКАЗАТЕЛЬСТВО КОРРЕКТНОСТИ --
// 1. Строим граф Т1 присоединяя к пустому графу ребро максимального веса
// 2. Если граф Ti уже построен и i < n+1, то строим Ti+1, присоединяя ребро имеющее максимальный вес,
//    не входящее в Ti и не образующее циклов с текущими ребрами
// 
// - Если граф Ti уже построен и i < n+1 и нет больше смежных вершит — то граф не связный и алгоритм закончит работу
// - Если граф T построен не оптимальным образом, т.е. мы выбрали ребро не с максимальным весом
//   на одном из предыдущих шагов, то добавляя очереднре ребро в некоторый момент мы получим цикл,
//   такое ребро можно удалить и оставить только самые дорогие, из которых и должно состоять Tmax.
//
// -- ВРЕМЕННАЯ СЛОЖНОСТЬ --
// O(∣E∣⋅log∣V∣), где ∣E∣ — количество рёбер в графе, а ∣V∣ — количество вершин.
//
// -- ПРОСТРАНСТВЕННАЯ СЛОЖНОСТЬ --
// O(∣E∣+∣V∣), где ∣E∣ — количество рёбер в графе, а ∣V∣ — количество вершин.
// Так как я храню "почти" все ребра и у меня есть массив вершин, которые алгоритм ещё не обработал.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace A
{
    public class Edge : IComparable<Edge>
    {
        public int Start { get; set; }
        public int End { get; set; }
        public int Length { get; set; }

        public int CompareTo(Edge other) =>
            EdgeComparer.Instance.Compare(this, other);
    }

    public class EdgeComparer : IComparer<Edge>
    {
        public static readonly EdgeComparer Instance = new EdgeComparer();

        public int Compare(Edge x, Edge y)
        {
            if (ReferenceEquals(x, y)) return 0;
            if (ReferenceEquals(null, y)) return 1;
            if (ReferenceEquals(null, x)) return -1;
            var lengthComparison = x.Length.CompareTo(y.Length);
            if (lengthComparison != 0) return lengthComparison;
            var startComparison = x.Start.CompareTo(y.Start);
            if (startComparison != 0) return startComparison;
            return x.End.CompareTo(y.End);
        }
    }

    public class Heap<T>
        where T : class, IComparable<T>
    {
        private readonly T[] _edges;
        private int _size;

        public Heap(int size)
        {
            var normalizedSize = size + 1;
            _size = 0;
            _edges = new T[normalizedSize];
        }

        public void Push(T edge)
        {
            _size += 1;
            _edges[_size] = edge;
            SiftUp(_edges, _size);
        }

        public T Pop()
        {
            var edge = _edges[1];
            _edges[1] = _size > 1 ? _edges[_size] : null;
            _edges[_size] = null;
            _size -= 1;
            SiftDown(_edges, 1);
            return edge;
        }

        private static void SiftDown(T[] edges, int index)
        {
            var curr = edges[index];
            var left = index * 2 < edges.Length ? edges[index * 2] : null;
            var right = index * 2 + 1 < edges.Length ? edges[index * 2 + 1] : null;
            var max = new[] {left, curr, right,}.Max();
            if (max == curr)
                return;
            if (max == left)
            {
                edges[index] = left;
                edges[index * 2] = curr;
                SiftDown(edges, index * 2);
            }
            else
            {
                edges[index] = right;
                edges[index * 2 + 1] = curr;
                SiftDown(edges, index * 2 + 1);
            }
        }

        private static void SiftUp(T[] edges, int index)
        {
            if (index == 1)
                return;

            var parentIndex = index / 2;
            var result = edges[parentIndex].CompareTo(edges[index]);
            if (result < 0)
            {
                // ReSharper disable once SwapViaDeconstruction
                var tmp = edges[parentIndex];
                edges[parentIndex] = edges[index];
                edges[index] = tmp;
                SiftUp(edges, parentIndex);
            }
        }

        public bool Any() => _size > 0;
    }

    public class Graph
    {
        public int Vertices { get; set; }
        public Dictionary<int, Edge>[] Edges { get; set; }
    }

    public static class A
    {
        private static StreamReader _reader;
        private static StreamWriter _writer;

        private static long _sum;
        private static Heap<Edge> _edges;
        private static Dictionary<int, bool> _notAdded;

        public static void Main(string[] args)
        {
            _reader = new StreamReader(Console.OpenStandardInput());
            _writer = new StreamWriter(Console.OpenStandardOutput());

            // INIT GRAPH
            var nm = ReadArray();
            var n = nm[0];
            var m = nm[1];

            var vertices = n;
            var edges = new Dictionary<int, Edge>[n];
            for (var i = 0; i < n; i++)
                edges[i] = new Dictionary<int, Edge>();

            for (var i = 0; i < m; i++)
            {
                var vul = ReadArray();
                var v = vul[0] - 1;
                var u = vul[1] - 1;
                var l = vul[2];

                if (!edges[v].ContainsKey(u))
                    edges[v][u] = new Edge {Start = v, End = u, Length = l,};
                else if (l > edges[v][u].Length)
                    edges[v][u] = new Edge {Start = edges[v][u].Start, End = edges[v][u].End, Length = l,};

                if (!edges[u].ContainsKey(v))
                    edges[u][v] = new Edge {Start = u, End = v, Length = l,};
                else if (l > edges[u][v].Length)
                    edges[u][v] = new Edge {Start = edges[u][v].Start, End = edges[u][v].End, Length = l,};
            }

            var graph = new Graph {Vertices = vertices, Edges = edges,};

            // RUN FIND MST
            _notAdded = new Dictionary<int, bool>();
            _edges = new Heap<Edge>(m);

            var isSuccess = FindMst(graph);
            if (!isSuccess)
                _writer.WriteLine("Oops! I did it again");
            else
                _writer.WriteLine(_sum);

            _reader.Close();
            _writer.Close();
        }

        private static void AddVertex(Graph graph, int v)
        {
            _notAdded.Remove(v);
            var nes = graph.Edges[v].Where(w => _notAdded.ContainsKey(w.Key));
            foreach (var (_, ne) in nes)
                _edges.Push(ne);
        }

        private static bool FindMst(Graph graph)
        {
            _notAdded = Enumerable
                .Range(0, graph.Vertices)
                .ToDictionary(x => x, _ => true);

            AddVertex(graph, 0);
            while (_notAdded.Any() && _edges.Any())
            {
                var e = _edges.Pop();
                if (_notAdded.ContainsKey(e.End))
                {
                    _sum += e.Length;
                    AddVertex(graph, e.End);
                }
            }

            return !_notAdded.Any();
        }

        private static int[] ReadArray() =>
            _reader.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
    }
}