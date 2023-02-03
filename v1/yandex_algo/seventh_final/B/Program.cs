// -- ТЕСТЫ --
// https://contest.yandex.ru/contest/25597/run-report/66725574/
// 
// -- ПРИНЦИП РАБОТЫ -- 
// Подошел к решению задачи так же, как к решению задачи про рюкзак динамикой
// 1. Сначала я суммирую все элементы
// 2. Затем проверяю делится ли на 2 без остатка
//    если делится — то можно решать дальше
//    если не делится — выводим False
// 3. Затем делим сумму на 2 и считаем это вместимостью нашего рюкзака
// 4. Пытаемся заполнить рюкзак так, чтобы получить ровно вместимость нашего рюкзака
//    если получилось — выводим True
//    если не получилось — выводим False
//
// По динамике
// 1. В элементах массива dp хранится текущая оптимальная вес элементов не превышающая j
// 2. Базовый случай — dp[0][0] = 0
// 3. Переход динамики будет таким Math.Max(dp[i - 1][j], wn[i - 1] + dp[i - 1][j - wn[i - 1]])
//    Берем максимум из
//      вес без учета текущего элемента dp[i - 1][j]
//      вес с учетом текущего элемента wn[i - 1] + dp[i - 1][j - wn[i - 1]]
// 4. Порядок вычисления — по возрастанию индекса
// 5. Ответ на исходный вопрос будет располагаться в последней ячейке dp[n][m],
//    точнее, чтобы получить ответ нужно взять элемент dp[n][m] и сравнить его с вместимостью рюкзака
//
// Сделал одну оптимизацию
// 1. Не делаю дальнейших расчетов, если на некотором шаге уже получилось набрать нужный вес
// 
// -- ДОКАЗАТЕЛЬСТВО КОРРЕКТНОСТИ --
// База
// dp[0][0] = 0, dp[0][j] = 0 — когда нет никаких элементов рюкзак пустой
// Когда берем первый элемент dp[1][j] — в тот момент, когда элемент может быть помещен в рюкзак (w <= j) dp[1][j] = w
//
// Шаг
// для вычисления dp[i][j] мы операемся на предыдущие вычисления и берем лучшее значение из
// 1. мы не берем текущий элемент — берем лучший вес для рюкзака вместимостью j
// 2. мы берем текущий элемент — берем вес текущего предмета + лучший вес, которую мы можем получить для рюкзака вместимостью j - wn[i - 1]
//
// Вывод
// Таким образом на каждом шаге инвариант выполняется, мы имеем оптимальное значение и в конце получаем ответ
//
// -- ВРЕМЕННАЯ СЛОЖНОСТЬ --
// O(N*M) где N, количество элементов в массиве на входе, M — половина суммы этих элементов
//
// -- ПРОСТРАНСТВЕННАЯ СЛОЖНОСТЬ --
// O(N*M) где N, количество элементов в массиве на входе, M — половина суммы этих элементов
// dp — массив такого размера 

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace B
{
    public static class B
    {
        private static StreamReader _reader;
        private static StreamWriter _writer;

        public static void Main(string[] args)
        {
            _reader = new StreamReader(Console.OpenStandardInput());
            _writer = new StreamWriter(Console.OpenStandardOutput());

            // var nm = ReadArray();
            // var n = nm[0];
            // var m = nm[1];
            var n = ReadInt();
            var wn = ReadArray(); // = cost = weight
            var sum = wn.Sum();
            if (sum % 2 == 1)
            {
                // Можно не делать никаких расчетов дальше
                // так как сумма элементов на два не делится
                _writer.WriteLine("False");
                _reader.Close();
                _writer.Close();
                return;
            }

            var m = sum / 2;
            var dp = new int[n + 1][];
            for (var i = 0; i < n + 1; i++)
                dp[i] = new int[m + 1];

            for (var i = 1; i < n + 1; i++)
            for (var j = 0; j < m + 1; j++)
            {
                var maxPrevious = dp[i - 1][j];
                var maxCurrent = 0;

                if (j - wn[i - 1] >= 0)
                {
                    maxCurrent = wn[i - 1] + dp[i - 1][j - wn[i - 1]];
                }

                dp[i][j] = Math.Max(maxPrevious, maxCurrent);

                if (dp[i][j] == m)
                {
                    // Оптимизация
                    // Можно не делать никаких расчетов дальше
                    // так как мы уже набрали нужную сумму
                    _writer.WriteLine("True");
                    _reader.Close();
                    _writer.Close();
                    return;
                }
            }

            // DEBUG ONLY
            // for (var i = 0; i < n; i++)
            //     _writer.WriteLine(string.Join("\t", dp[i]));
            // _writer.WriteLine();
            // _writer.WriteLine(dp[n - 1][m]);

            _writer.WriteLine("False");
            _reader.Close();
            _writer.Close();
        }

        private static int ReadInt() =>
            int.Parse(_reader.ReadLine());

        private static int[] ReadArray() =>
            _reader.ReadLine()
                .Split(' ')
                .Select(int.Parse).ToArray();
    }
}