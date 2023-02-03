using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace K
{
    public class Graph
    {
        public int Vertices { get; }
        public int?[][] Distances { get; }

        public Graph(int vertices, int?[][] distances)
        {
            Vertices = vertices;
            Distances = distances;
        }

        public int[] OutgoingEdges(int v)
        {
            var outgoingEdges = new List<int>();
            for (var i = 0; i < Vertices; i++)
            {
                if (Distances[v][i] != null)
                {
                    outgoingEdges.Add(i);
                }
            }

            return outgoingEdges.ToArray();
        }
    }

    public static class K
    {
        private static StreamReader _reader;
        private static StreamWriter _writer;

        private static int[] _distances;
        private static int?[] _previous;
        private static bool[] _visited;

        private static int[][] _result;

        public static void Main(string[] args)
        {
            _reader = new StreamReader(Console.OpenStandardInput());
            _writer = new StreamWriter(Console.OpenStandardOutput());

            // INIT GRAPH
            var nm = ReadArray();
            var n = nm[0];
            var m = nm[1];

            var vertices = n;
            var distances = new int?[n][];
            for (var i = 0; i < n; i++)
                distances[i] = new int?[n];

            for (var i = 0; i < m; i++)
            {
                var vul = ReadArray();
                var v = vul[0] - 1;
                var u = vul[1] - 1;
                var l = vul[2];

                var curDistance = distances[v][u];
                if (curDistance == null || curDistance > l)
                {
                    distances[v][u] = l;
                    distances[u][v] = l;
                }
            }

            var graph = new Graph(vertices, distances);

            // INIT RESULT
            _result = new int[n][];

            for (var i = 0; i < n; i++)
                _result[i] = new int[n];

            for (var i = 0; i < n; i++)
            for (var j = 0; j < n; j++)
                _result[i][j] = -1;

            // RUN DIJKSTRA
            for (var i = 0; i < n; i++)
            {
                Dijkstra(graph, i);

                // PROCESS RESULTS
                for (var j = 0; j < n; j++)
                    if (_distances[j] < int.MaxValue)
                        _result[i][j] = _distances[j];
            }

            for (var i = 0; i < n; i++)
                _writer.WriteLine(string.Join(' ', _result[i]));

            _reader.Close();
            _writer.Close();
        }

        private static void Relax(Graph graph, int u, int v)
        {
            var notNullUv = graph.Distances[u][v] ?? throw new ApplicationException();
            if (_distances[v] > _distances[u] + notNullUv)
            {
                _distances[v] = _distances[u] + notNullUv;
                _previous[v] = u;
            }
        }

        private static int? GetMinDistanceNotVisitedVertex(Graph graph)
        {
            var currentMinimum = int.MaxValue;
            var currentMinimumVertex = (int?) null;
            for (var v = 0; v < graph.Vertices; v++)
            {
                if (!_visited[v] && _distances[v] < currentMinimum)
                {
                    currentMinimum = _distances[v];
                    currentMinimumVertex = v;
                }
            }

            return currentMinimumVertex;
        }

        private static void Dijkstra(Graph graph, int s)
        {
            // INIT DIJKSTRA
            _distances = new int[graph.Vertices];
            _previous = new int?[graph.Vertices];
            _visited = new bool[graph.Vertices];
            for (var i = 0; i < graph.Vertices; i++)
                _distances[i] = int.MaxValue;

            _distances[s] = 0;

            var u = (int?) s;
            while (u != null)
            {
                var notNullU = u ?? throw new ApplicationException();
                _visited[notNullU] = true;

                var outgoingEdges = graph.OutgoingEdges(notNullU);
                foreach (var v in outgoingEdges)
                {
                    Relax(graph, notNullU, v);
                }

                u = GetMinDistanceNotVisitedVertex(graph);
            }
        }

        private static int[] ReadArray()
        {
            return _reader.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
        }
    }
}