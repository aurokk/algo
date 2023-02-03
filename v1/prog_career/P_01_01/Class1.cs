using System.Collections;

namespace P_01_01;

public class Class1
{
    public bool IsUniqueChars_000(string s)
    {
        if (s.Length > 128) return false;

        var charset = new bool[128];
        foreach (var ch in s)
        {
            if (charset[ch]) return false;
            charset[ch] = true;
        }

        return true;
    }

    public bool IsUniqueChars_001(string s)
    {
        if (s.Length > 128) return false;

        var charset = new BitArray(128);
        foreach (var ch in s)
        {
            if (charset[ch]) return false;
            charset[ch] = true;
        }

        return true;
    }
}