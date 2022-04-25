using System;
using System.IO;
using System.Linq;

namespace A
{
    public enum Action
    {
        Nothing = 0,
        Buy = 1,
        Sell = 2,
    }

    public static class A
    {
        private static TextReader _reader;
        private static TextWriter _writer;

        public static void Main(string[] args)
        {
            _reader = new StreamReader(Console.OpenStandardInput());
            _writer = new StreamWriter(Console.OpenStandardOutput());

            ReadArray();

            var vA = ReadArray();
            var actions = new Action[vA.Length];

            var profit = 0;
            var buyPrice = 0;
            var sellPrice = 0;

            var lastAction = Action.Nothing;
            var lastActionI = -1;
            for (var i = 0; i < vA.Length; i++)
            {
                if (lastAction == Action.Nothing)
                {
                    actions[i] = lastAction = Action.Buy;
                    lastActionI = i;
                    buyPrice = vA[i];
                    continue;
                }

                if (lastAction == Action.Buy)
                {
                    var lastPrice = vA[lastActionI];
                    var currPrice = vA[i];
                    if (lastPrice > currPrice)
                    {
                        buyPrice = vA[i];

                        actions[lastActionI] = Action.Nothing;
                        actions[i] = Action.Buy;
                        lastActionI = i;
                        continue;
                    }

                    if (lastPrice < currPrice)
                    {
                        sellPrice = vA[i];

                        actions[i] = lastAction = Action.Sell;
                        lastActionI = i;
                        continue;
                    }
                }

                if (lastAction == Action.Sell)
                {
                    var lastPrice = vA[lastActionI];
                    var currPrice = vA[i];
                    if (lastPrice > currPrice)
                    {
                        profit += sellPrice - buyPrice;
                        buyPrice = vA[i];
                        sellPrice = 0;

                        actions[i] = lastAction = Action.Buy;
                        lastActionI = i;
                        continue;
                    }

                    if (lastPrice < currPrice)
                    {
                        sellPrice = vA[i];

                        actions[lastActionI] = Action.Nothing;
                        actions[i] = Action.Sell;
                        lastActionI = i;
                        continue;
                    }
                }
            }

            if (sellPrice > buyPrice)
                profit += sellPrice - buyPrice;

            _writer.WriteLine(profit);

            _reader.Close();
            _writer.Close();
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