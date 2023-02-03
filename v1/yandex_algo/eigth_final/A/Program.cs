// -- ТЕСТЫ --
// https://contest.yandex.ru/contest/26133/run-report/66793448/
// 
// -- ПРИНЦИП РАБОТЫ -- 
// 1. Считываю строку
// 2. Распаковываю её согласно алгоритму описанному в условиях задачи 
// 3. Сравниваю строку посимвольно с той строкой, которая у меня хранится, чтобы вычислить их общий префикс
//
// Две оптимизации:
// 1. По-памяти — храню только одну строку и текущую длину максимального общего префикса
// 2. По-времени — сравнимаю только до текущей длины максимального общего префикса
// 
// -- ДОКАЗАТЕЛЬСТВО КОРРЕКТНОСТИ --
// Алгоритм распаковки строки описан в условиях задачи — https://contest.yandex.ru/contest/26133/problems/?nc=nqfntsXR&success=66793448#51450/2020_07_22/Lxm8FGkQIC
// Далее решение основывается на посимвольном сравнении строк
//
// -- ВРЕМЕННАЯ СЛОЖНОСТЬ --
// Обозначим длину строки через N, и количество строк через M
// Каждую строку я сначала распаковываю, примерно за N операций,
// затем закидываю в контейнер, чтобы посчитать максимальный префикс, что требует N операций в худшем случае
// Итоговая сложность M*(N+N) => O(M*N)
//
// -- ПРОСТРАНСТВЕННАЯ СЛОЖНОСТЬ --
// Храню только одну строку, в контейнере, остальные обрабатываю на лету и выкидываю.
// Поэтому памяти нужно O(N), где N — длина первой считаной строки
// Итоговая сложность O(N)

using System;
using System.IO;
using System.Linq;
using System.Text;

namespace A
{
    public class PrefixContainer
    {
        private char[] _chars;
        private int _max;

        public void Apply(string word)
        {
            if (_chars == null)
            {
                _max = word.Length;
                _chars = word.ToCharArray();
                return;
            }

            var max = Math.Min(_max, word.Length);
            for (var i = 0; i < max; i++)
            {
                if (word[i] != _chars[i])
                {
                    _max = i;
                    return;
                }
            }
        }

        public string GetResult()
        {
            var chars = _chars.Take(_max);
            return string.Join(string.Empty, chars);
        }
    }

    public static class A
    {
        private static StreamReader _reader;
        private static StreamWriter _writer;

        public static void Main(string[] args)
        {
            _reader = new StreamReader(Console.OpenStandardInput());
            _writer = new StreamWriter(Console.OpenStandardOutput());

            var n = int.Parse(_reader.ReadLine());
            var c = new PrefixContainer();
            for (var i = 0; i < n; i++)
            {
                var s = _reader.ReadLine();
                var us = Unpack(s);
                c.Apply(us);
            }

            _writer.WriteLine(c.GetResult());

            _reader.Close();
            _writer.Close();
        }

        private static string Unpack(string s)
        {
            var sb = new StringBuilder();

            for (var i = 0; i < s.Length;)
            {
                // group found
                if (s[i] is >= '0' and <= '9')
                {
                    var (unpacked, skip) = UnpackInternal(s, i);
                    sb.Append(unpacked);
                    i += skip;
                }

                // other symbols
                else
                {
                    sb.Append(s[i]);
                    i++;
                }
            }

            return sb.ToString();
        }

        private static (string, int) UnpackInternal(string s, int start)
        {
            var started = false;

            var countSb = new StringBuilder();
            var groupSb = new StringBuilder();

            for (var i = start; i < s.Length;)
            {
                if (s[i] is >= '0' and <= '9')
                {
                    // recursive group found
                    if (started)
                    {
                        var (unpacked, skip) = UnpackInternal(s, i);
                        groupSb.Append(unpacked);
                        i += skip;
                    }

                    // next digit of group repetitions
                    else
                    {
                        countSb.Append(s[i]);
                        i++;
                    }
                }

                // group started
                else if (s[i] == '[')
                {
                    started = true;
                    i++;
                }

                // group ended
                else if (s[i] == ']')
                {
                    var countStr = countSb.ToString();
                    var count = int.Parse(countStr);

                    var groupStr = groupSb.ToString();
                    var sb = new StringBuilder();
                    for (var j = 0; j < count; j++)
                        sb.Append(groupStr);

                    var unpacked = sb.ToString();
                    var skip = i - start + 1;

                    return (unpacked, skip);
                }

                // other symbols
                else
                {
                    groupSb.Append(s[i]);
                    i++;
                }
            }

            throw new ApplicationException();
        }
    }
}