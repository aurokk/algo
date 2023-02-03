namespace P_01_05;

public class Class1
{
    public bool DistanceOne_000(string a, string b)
    {
        var l = a.Length > b.Length ? a : b;
        var s = a.Length > b.Length ? b : a;

        var diff = l.Length - s.Length;
        if (diff >= 2)
        {
            return false;
        }

        var li = 0;
        var si = 0;
        var isUsed = false;
        for (; li < l.Length && si < s.Length;)
        {
            if (s[si] != l[li] && isUsed)
            {
                return false;
            }

            if (s[si] != l[li] && diff > 0)
            {
                li++;
                isUsed = true;
                continue;
            }

            if (s[si] != l[li] && diff == 0)
            {
                isUsed = true;
                li++;
                si++;
                continue;
            }

            if (s[si] == l[li])
            {
                li++;
                si++;
                continue;
            }
        }

        return true;
    }
}