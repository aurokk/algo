namespace P_01_02;

public class Class1
{
    public bool Permutation_000(string a, string b)
    {
        var ca = a.ToCharArray();
        var cb = b.ToCharArray();
        Array.Sort(ca);
        Array.Sort(cb);
        var cas = new string(ca);
        var cbs = new string(cb);
        return cas.Equals(cbs);
    }

    public bool Permutation_001(string a, string b)
    {
        if (a.Length != b.Length) return false;

        var chars = new int[128];
        foreach (var sac in a)
        {
            chars[sac]++;
        }

        foreach (var sab in b)
        {
            chars[sab]--;
            if (chars[sab] < 0)
            {
                return false;
            }
        }

        return true;
    }
}