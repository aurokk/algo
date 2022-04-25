// -- ТЕСТЫ --
// https://contest.yandex.ru/contest/26133/run-report/66800616/
// 
// -- ПРИНЦИП РАБОТЫ -- 
// Использую бор и динамическое программирование
// Алгоритм такой:
// 1. Внешний цикл идёт по позициям текста
// 2. Если предыдущая позиция в dp[i] = true запускаем от этой позиции проверку входит ли слово в бор
// 3. Ответ будет лежать в dp[text.Length]
//
// -- ДОКАЗАТЕЛЬСТВО КОРРЕКТНОСТИ --
// На каждой итерации цикла программа проверяет все слова в словаре на вхождение в текст от выбраной позиции,
// и добавляет следующие за окончаниями позиции в очередь на обработку
// Это значит что решение эквивалентно перебору всех вариантов
//
// -- ВРЕМЕННАЯ СЛОЖНОСТЬ --
// Проверка вхождения слов с некоторой позиции выполняется за O(M), где M - длина самого длинного из искомых слов
// Количество проверок в худшем случае равно длине текста N
// Таким образом временная сложность => O(N*M)
//
// -- ПРОСТРАНСТВЕННАЯ СЛОЖНОСТЬ --
// Обозначим число слов в словаре как N, длину текста как M
// В программе хранится массив позиций текста, которые уже были обработаны длиной M
// Так же храним все допустимые слова в виде бора, что несколько оптимальнее чем хранить просто список слов, но
// в худшем случае будет равно сумме длин слов, обозначим её как L
// Таким образом пространственная сложность примерно равна M+M+L => O(M+L)

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace B
{
    public class Node
    {
        public readonly Dictionary<char, Node> Children = new();
        public bool Terminal;
    }

    public class Trie
    {
        public readonly Node Root = new();

        public void Add(string word)
        {
            var node = Root;

            foreach (var ch in word)
            {
                if (!node.Children.ContainsKey(ch))
                    node.Children[ch] = new Node();

                node = node.Children[ch];
            }

            node.Terminal = true;
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

            // read text
            var text = _reader.ReadLine();

            // read dict
            var n = int.Parse(_reader.ReadLine());
            var dict = new Trie();
            for (var i = 0; i < n; i++)
            {
                var w = _reader.ReadLine();
                dict.Add(w);
            }

            // process
            var dp = new bool[text.Length + 1];
            dp[0] = true;
            for (var i = 1; i < text.Length + 1; i++)
            {
                if (!dp[i - 1])
                {
                    continue;
                }

                var node = dict.Root;
                for (var j = i - 1; j < text.Length; j++)
                {
                    if (node.Children.ContainsKey(text[j]))
                    {
                        node = node.Children[text[j]];
                        if (node.Terminal)
                        {
                            dp[j + 1] = true;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }

            // write answer
            _writer.WriteLine(dp[text.Length] ? "YES" : "NO");
            _reader.Close();
            _writer.Close();
        }
    }
}