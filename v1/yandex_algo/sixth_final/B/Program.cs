// -- ТЕСТЫ --
// https://contest.yandex.ru/contest/25070/run-report/66315688/
// 
// -- ПРИНЦИП РАБОТЫ -- 
// Все ребра одного цвета R(i,j) добавляю в граф прямом порядке (i, j), все ребра B(i,j) добавляю в обратно (j, i)
// В конце запускаю на графе обход в грубину, если обнаруживаются циклы, то железная дорога не оптимальна
// 
// https://practicum.yandex.ru/learn/algorithms/courses/7f101a83-9539-4599-b6e8-8645c3f31fad/sprints/21364/topics/45179065-a73b-473d-94d1-24774573f266/lessons/adb9a06e-f8a5-4d9b-b88a-2085cc8458f9/
//
// -- ДОКАЗАТЕЛЬСТВО КОРРЕКТНОСТИ --
// Обычный DFS, не знаю что писать в доказательстве :)
//
// -- ВРЕМЕННАЯ СЛОЖНОСТЬ --
// Так как граф представлен списками смежности, то O(∣E∣+∣V∣),
// где ∣E∣ — количество рёбер в графе, а ∣V∣ — количество вершин.
//
// -- ПРОСТРАНСТВЕННАЯ СЛОЖНОСТЬ --
// O(∣E∣+∣V∣), где ∣E∣ — количество рёбер в графе, а ∣V∣ — количество вершин.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace B
{
    public enum Color
    {
        White = 0,
        Gray = 1,
        Black = 2,
    }

    public class Graph
    {
        public List<int>[] Vertices { get; }

        public Graph(int vertices)
        {
            Vertices = new List<int>[vertices];
            for (var i = 0; i < vertices; i++)
                Vertices[i] = new List<int>();
        }
    }

    public static class B
    {
        private static StreamReader _reader;
        private static StreamWriter _writer;

        public static void Main(string[] args)
        {
            _reader = new StreamReader(Console.OpenStandardInput());
            _writer = new StreamWriter(Console.OpenStandardOutput());

            var n = ReadInt();
            var g = new Graph(n);
            var c = new Color[n];
            for (var i = 1; i < n; i++)
            {
                var paths = ReadCharArray();
                for (var j = 1; j < n - (i - 1); j++)
                {
                    var from = i - 1;
                    var to = i + j - 1;
                    switch (paths[j - 1])
                    {
                        case 'R':
                        {
                            g.Vertices[from].Add(to);
                            break;
                        }

                        case 'B':
                        {
                            g.Vertices[to].Add(from);
                            break;
                        }
                    }
                }
            }

            var optimal = true;
            for (var i = 0; i < g.Vertices.Length; i++)
                if (c[i] == Color.White)
                    if (!Dfs(g, c, i))
                    {
                        optimal = false;
                        break;
                    }

            _writer.WriteLine(optimal ? "YES" : "NO");
            _reader.Close();
            _writer.Close();
        }

        private static bool Dfs(Graph graph, Color[] colors, int startV)
        {
            var stack = new Stack<int>();
            stack.Push(startV);
            while (stack.Any())
            {
                var v = stack.Pop();
                switch (colors[v])
                {
                    case Color.White:
                        colors[v] = Color.Gray;
                        stack.Push(v);
                        var children = graph.Vertices[v];
                        if (children.Any(x => colors[x] == Color.Gray))
                            return false;
                        foreach (var w in children.Where(w => colors[w] == Color.White))
                            stack.Push(w);
                        break;

                    case Color.Gray:
                        colors[v] = Color.Black;
                        break;
                }
            }

            return true;
        }

        private static int ReadInt() =>
            int.Parse(_reader.ReadLine());

        private static char[] ReadCharArray() =>
            _reader.ReadLine()
                .ToCharArray();
    }
}