using System.Text;

namespace P_01_06;

public class Class1
{
    public string Compress_000(string s)
    {
        if (s.Length == 0)
        {
            return s;
        }

        var result = new StringBuilder();

        var counter = 0;
        var lastCharacter = s[0];
        foreach (var ch in s)
        {
            if (lastCharacter == ch)
            {
                counter++;
            }
            else
            {
                Append();
                counter = 1;
                lastCharacter = ch;
            }
        }

        Append();

        var compressed = result.ToString();

        return s.Length > compressed.Length
            ? compressed
            : s;

        void Append()
        {
            result.Append(lastCharacter);
            result.Append(counter);
        }
    }
}