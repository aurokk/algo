using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace H
{
    public static class H
    {
        private static TextReader _reader;
        private static TextWriter _writer;

        public static string GetResult(string num1, string num2)
        {
            var revNum1 = num1.ToCharArray().Select(x => x.ToString()).Select(int.Parse).Reverse().ToArray();
            var revNum2 = num2.ToCharArray().Select(x => x.ToString()).Select(int.Parse).Reverse().ToArray();
            var maxLength = Math.Max(num1.Length, num2.Length);

            var n3 = 0;

            var resultList = new List<int>();

            for (int i = 0; i < maxLength; i++)
            {
                var n1 = i < revNum1.Length ? revNum1[i] : 0;
                var n2 = i < revNum2.Length ? revNum2[i] : 0;

                var sum = n1 + n2 + n3;
                n3 = 0;

                switch (sum)
                {
                    case 0:
                        resultList.Add(0);
                        break;

                    case 1:
                        resultList.Add(1);
                        break;

                    case 2:
                        n3 = 1;
                        resultList.Add(0);
                        if (i == maxLength - 1)
                        {
                            resultList.Add(1);
                        }

                        break;

                    case 3:
                        n3 = 1;
                        resultList.Add(1);
                        if (i == maxLength - 1)
                        {
                            resultList.Add(1);
                        }

                        break;
                }
            }

            resultList.Reverse();
            return string.Join(string.Empty, resultList);
        }

        public static void Main(string[] args)
        {
            _reader = new StreamReader(Console.OpenStandardInput());
            _writer = new StreamWriter(Console.OpenStandardOutput());

            var num1 = ReadLine();
            var num2 = ReadLine();
            var result = GetResult(num1, num2);
            _writer.WriteLine(result);

            _reader.Close();
            _writer.Close();
        }

        private static string ReadLine()
        {
            return _reader.ReadLine()
                .Trim();
        }
    }
}