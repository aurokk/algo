namespace ImplementStrStr;

public class Solution
{
    public int StrStr_000(string haystack, string needle)
    {
        if (needle.Length == 0)
        {
            return 0;
        }

        if (needle.Length > haystack.Length)
        {
            return -1;
        }

        for (var i = 0; i < haystack.Length - needle.Length + 1; i++)
        {
            var match = true;
            for (var j = 0; j < needle.Length; j++)
            {
                if (needle[j] != haystack[i + j])
                {
                    match = false;
                    break;
                }
            }

            if (match)
            {
                return i;
            }
        }

        return -1;
    }

    public int StrStr_001(string haystack, string needle)
    {
        if (needle.Length == 0)
        {
            return 0;
        }

        if (needle.Length > haystack.Length)
        {
            return -1;
        }

        var ps = $"{needle}#{haystack}";
        var p = new int[ps.Length];
        for (var i = 1; i < ps.Length; i++)
        {
            var j = p[i - 1];

            while (ps[i] != ps[j] && j > 0)
            {
                j = p[j - 1];
            }

            if (ps[i] == ps[j])
            {
                j++;
            }

            p[i] = j;

            if (j == needle.Length)
            {
                return i - 2 * needle.Length;
            }
        }

        return -1;
    }

    public static int[] Prefixes_000(string needle)
    {
        var result = new int[needle.Length];

        for (var i = 1; i < needle.Length; i++)
        {
            var j = result[i - 1];

            while (j > 0 && needle[j] != needle[i])
            {
                j = result[j - 1];
            }

            if (needle[j] == needle[i])
            {
                j++;
            }

            result[i] = j;
        }

        return result;
    }

    public static int[] Prefixes_001(string needle)
    {
        var result = new int[needle.Length];

        for (var i = 1; i < needle.Length; i++)
        {
            var j = result[i - 1];

            while (needle[i] != needle[j] && j > 0)
            {
                j = result[j - 1];
            }

            if (needle[i] == needle[j])
            {
                j++;
            }

            result[i] = j;
        }

        return result;
    }

    public static int[] Prefixes_002(string s)
    {
        var p = new int[s.Length];

        for (var i = 1; i < s.Length; i++)
        {
            var j = p[i - 1];

            while (j > 0 && s[i] != s[j])
            {
                j = p[j - 1];
            }

            if (s[i] == s[j])
            {
                j++;
            }

            p[i] = j;
        }

        return p;
    }
}