using System;
using System.Collections.Generic;
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

            var index = new Dictionary<string, Dictionary<int, int>>();

            var n = ReadInt();
            for (var i = 0; i < n; i++)
            {
                var document = ReadString();
                UpdateIndex(index, document, i);
            }

            var m = ReadInt();
            for (var i = 0; i < m; i++)
            {
                var request = ReadString();
                var documents = SearchDocuments(index, request);
                _writer.WriteLine(string.Join(' ', documents));
            }

            _reader.Close();
            _writer.Close();
        }

        private static int[] SearchDocuments(
            Dictionary<string, Dictionary<int, int>> index,
            string request)
        {
            var words = request.Split(' ').Distinct();
            var relevancy = new Dictionary<int, int>();
            foreach (var word in words)
            {
                if (index.ContainsKey(word))
                {
                    var docs = index[word].Keys;
                    foreach (var doc in docs)
                    {
                        if (!relevancy.ContainsKey(doc))
                        {
                            relevancy[doc] = 0;
                        }

                        relevancy[doc] += index[word][doc];
                    }
                }
            }

            return relevancy
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .Take(5)
                .Select(x => x.Key + 1)
                .ToArray();
        }

        private static void UpdateIndex(
            Dictionary<string, Dictionary<int, int>> index,
            string document,
            int documentIndex)
        {
            var words = document.Split(' ');
            foreach (var word in words)
            {
                if (!index.ContainsKey(word))
                {
                    index[word] = new Dictionary<int, int>();
                }

                if (!index[word].ContainsKey(documentIndex))
                {
                    index[word][documentIndex] = 0;
                }

                index[word][documentIndex]++;
            }
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