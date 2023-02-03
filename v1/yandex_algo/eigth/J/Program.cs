using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace J
{
    public class BorNode
    {
        public IReadOnlyDictionary<char, BorNode> Children => _children;
        private readonly Dictionary<char, BorNode> _children = new();

        public IReadOnlyCollection<string> Values => _values;
        private readonly List<string> _values = new();

        public void Add(char character) =>
            _children.Add(character, new BorNode());

        public void AddValue(string word) =>
            _values.Add(word);
    }

    public class Bor
    {
        private readonly BorNode _root;

        public Bor() =>
            _root = new BorNode();

        public void Add(string word)
        {
            var node = _root;
            var abb = word.Where(char.IsUpper).ToArray();
            foreach (var character in abb)
            {
                if (!node.Children.ContainsKey(character))
                {
                    node.Add(character);
                }

                node = node.Children[character];
            }

            node.AddValue(word);
        }

        public string[] GetByAbb(string abb)
        {
            var acc = new List<string>();

            var node = _root;
            foreach (var character in abb)
            {
                if (!node.Children.ContainsKey(character))
                {
                    return Array.Empty<string>();
                }

                node = node.Children[character];
            }

            AddFromChildren(node, acc);

            return acc
                .OrderBy(x => x, StringComparer.Ordinal)
                .ToArray();
        }

        private static void AddFromChildren(BorNode node, List<string> acc)
        {
            acc.AddRange(node.Values);
            foreach (var child in node.Children)
                AddFromChildren(child.Value, acc);
        }
    }

    public static class J
    {
        private static TextReader _reader;
        private static TextWriter _writer;

        public static void Main(string[] args)
        {
            _reader = new StreamReader(Console.OpenStandardInput());
            _writer = new StreamWriter(Console.OpenStandardOutput());

            var bor = new Bor();

            var n = int.Parse(_reader.ReadLine());
            for (var i = 0; i < n; i++)
            {
                var name = _reader.ReadLine();
                bor.Add(name);
            }

            var m = int.Parse(_reader.ReadLine());
            for (var i = 0; i < m; i++)
            {
                var request = _reader.ReadLine();
                var values = bor.GetByAbb(request);
                foreach (var value in values)
                    _writer.WriteLine(value);
            }

            _reader.Close();
            _writer.Close();
        }
    }
}