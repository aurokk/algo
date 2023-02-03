using System;
using System.IO;

namespace I
{
    public static class I
    {
        private static TextReader _reader;
        private static TextWriter _writer;

        public static void Main(string[] args)
        {
            _reader = new StreamReader(Console.OpenStandardInput());
            _writer = new StreamWriter(Console.OpenStandardOutput());

            var s = _reader.ReadLine();
            var parts = s.Length + 1;
            while (parts > 0)
            {
                parts--;

                if (s.Length % parts == 0)
                {
                    var length = s.Length / parts;
                    for (var i = 0; i < length; i++)
                    {
                        var ch = s[i];
                        for (var j = 0; j < parts; j++)
                        {
                            var ch2 = s[j * length + i];
                            if (ch != ch2)
                            {
                                goto cont;
                            }
                        }
                    }

                    break;
                }

                cont: ;
            }

            _writer.WriteLine(parts == 0 ? 1 : parts);

            _reader.Close();
            _writer.Close();
        }
    }
}