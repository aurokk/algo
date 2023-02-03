/**
 * Тесты:
 * https://contest.yandex.ru/contest/22781/run-report/64124619/
 *
 * Объяснение:
 * Решение ровно такое, как описано в задаче. Беру строку на вход, разбиваю на части по пробелу,
 * в случае, если элемент является операндом добавляю его в стек, если операцией, то достаю из стека два числа и
 * выполняю соответствующую операцию, результат кладу обратно в стек. При делении сделал округление вниз.
 *
 * Корректность:
 * Как такового алгоритма тут нет, задача скорее на логику, поэтому непонятно как доказать корректность.
 * Хочется заметить лишь то, что стек, лежащий в основе, позволяет эффективно работать с обратной польской нотацией —
 * доставать нужные операнды и обеспечивает правильный порядок вычислений. Каждые два операнда после выполнения операции
 * над ними становятся операндом следующей операции.
 *
 * Стоимость:
 * Так как мы обрабатываем каждый элемент на вход единожды, за константное количество операций, то сложность O(n),
 * пространственная сложность тоже O(n), так как в стеке всегда будет около n элементов-операндов.
 * 
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace B
{
    public class B
    {
        private static TextReader _reader;
        private static TextWriter _writer;

        public static void Main(string[] args)
        {
            _reader = new StreamReader(Console.OpenStandardInput());
            _writer = new StreamWriter(Console.OpenStandardOutput());

            var data = new Stack<int>();
            var items = ReadList();
            foreach (var item in items)
            {
                switch (item)
                {
                    case "*":
                    {
                        var op2 = data.Pop();
                        var op1 = data.Pop();
                        var res = op1 * op2;
                        data.Push(res);
                        break;
                    }

                    case "/":
                    {
                        var op2 = data.Pop();
                        if (op2 == 0)
                        {
                            _writer.WriteLine("Incorrect input");
                            return;
                        }

                        var op1 = data.Pop();
                        var res = (int) Math.Floor(op1 / (decimal) op2);
                        data.Push(res);
                        break;
                    }

                    case "-":
                    {
                        var op2 = data.Pop();
                        var op1 = data.Pop();
                        var res = op1 - op2;
                        data.Push(res);
                        break;
                    }

                    case "+":
                    {
                        var op2 = data.Pop();
                        var op1 = data.Pop();
                        var res = op1 + op2;
                        data.Push(res);
                        break;
                    }

                    default:
                    {
                        var num = int.Parse(item);
                        data.Push(num);
                        break;
                    }
                }
            }

            _writer.WriteLine(data.Pop());

            _reader.Close();
            _writer.Close();
        }

        private static List<string> ReadList()
        {
            return _reader.ReadLine()
                .Split(new[] {' ', '\t',}, StringSplitOptions.RemoveEmptyEntries)
                .ToList();
        }
    }
}