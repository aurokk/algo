using System;
using System.Collections.Generic;
using System.IO;

namespace H
{
    public static class StackExtensions
    {
        public static bool TryPeekC<T>(this Stack<T> stack, out T result)
        {
            try
            {
                result = stack.Peek();
                return true;
            }
            catch
            {
                result = default(T);
                return false;
            }
        }
    }

    public class H
    {
        private static TextReader _reader;
        private static TextWriter _writer;

        public static bool GetResult()
        {
            var characters = ReadCharacters();
            var stack = new Stack<char>();
            foreach (var character in characters)
            {
                switch (character)
                {
                    case '{':
                    case '(':
                    case '[':
                    {
                        stack.Push(character);
                        continue;
                    }

                    case '}':
                    {
                        char peek;
                        if (!stack.TryPeekC(out peek))
                            return false;

                        if (peek != '{')
                            return false;

                        stack.Pop();
                        continue;
                    }

                    case ')':
                    {
                        char peek;
                        if (!stack.TryPeekC(out peek))
                            return false;
                        if (peek != '(')
                            return false;

                        stack.Pop();
                        continue;
                    }

                    case ']':
                    {
                        char peek;
                        if (!stack.TryPeekC(out peek))
                            return false;
                        if (peek != '[')
                            return false;

                        stack.Pop();
                        continue;
                    }
                }
            }

            return stack.Count == 0;
        }

        public static void Main(string[] args)
        {
            _reader = new StreamReader(Console.OpenStandardInput());
            _writer = new StreamWriter(Console.OpenStandardOutput());

            var result = GetResult() ? "True" : "False";
            _writer.WriteLine(result);

            _reader.Close();
            _writer.Close();
        }

        private static char[] ReadCharacters()
        {
            return _reader
                .ReadLine()
                .ToCharArray();
        }
    }
}